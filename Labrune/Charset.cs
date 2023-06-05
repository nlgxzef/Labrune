using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Runtime.ConstrainedExecution;

namespace Labrune
{
    public class Charset
    {
        public int NumberOfEntries;
        public ushort[] EntryTable;

        public Charset()
        {
            NumberOfEntries = 0;
            EntryTable = new ushort[0xC00];
        }

        public int Size()
        { 
            return (sizeof(int) + EntryTable.Length * sizeof(ushort)); // 0x1804 fixed size
        }

        public void Read(BinaryReader br)
        {
            NumberOfEntries = br.ReadInt32();
            for (int i = 0; i<EntryTable.Length; i++)
            {
                EntryTable[i] = br.ReadUInt16();
            }
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(NumberOfEntries);
            foreach(var i in EntryTable) bw.Write(i);
        }

        public string Decode(byte[] bytes)
        {
            var bld = new StringBuilder();
            
            for(int i=0; i<bytes.Length;)
            {
                char chr = Convert.ToChar(bytes[i++]);

                if (chr == 0) break;

                if (chr >= 0x80)
                {
                    char hst = Convert.ToChar(EntryTable[chr]);

                    if (hst >= 0x80)
                    {
                        chr = hst;
                    }
                    else if (hst != 0)
                    {
                        byte nxt = bytes[i++];
                        if (nxt >= 0x80) chr = Convert.ToChar(EntryTable[128 * hst - 128 + nxt]);
                    }
                    else return System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(bytes); // Cannot decode the string
                }

                bld.Append(chr);
            }

            return bld.ToString();
        }

        public byte[] Encode(string str)
        {
            var bytes = new List<byte>();

            char[] chr = str.ToCharArray();

            foreach (char c in chr)
            {
                if (c >= 0xFF80) throw new Exception("Could not encode string");

                char sav = c;

                if (c>=0x80)
                {
                    int cur = 128;
                    int max = NumberOfEntries;

                    if (NumberOfEntries > 128)
                    {
                        while (cur < max)
                        {
                            if (EntryTable[cur] == c) break;
                            cur++;
                        }
                    }

                    if (cur>=256)
                    {
                        if (cur!=max)
                        {
                            sav = (char)128;
                            int src = 128;
                            bool update = true;

                            while (EntryTable[src] != cur>>7)
                            {
                                sav++;
                                if (sav >= 256)
                                {
                                    update = false;
                                    break;
                                }
                                src++;
                            }

                            if (update)
                            {
                                bytes.Add(Convert.ToByte(sav));
                                bytes.Add((byte)Convert.ToSByte(cur%128-128));
                            }
                        }

                        bool notFound = sav == 256 || cur == max;
                        if (notFound) throw new Exception("Could not encode character");
                    }
                    else bytes.Add(Convert.ToByte(cur));
                }
                else bytes.Add(Convert.ToByte(c));
            }

            // Add null character at the end
            bytes.Add((byte)0);

            return bytes.ToArray();
        }
    }
}
