using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Labrune
{
    public class File
    {
        public String FileName;
        public List<Chunk> Chunks;

        public File(String name)
        {
            FileName = name;
        }

        public File() { }

        ~File()
        {
            if (Chunks != null) Chunks.Clear();
        }

        public MemoryStream Decrypt()
        {
            byte[] LangFileArray = System.IO.File.ReadAllBytes(FileName); // Read

            if (LangFileArray[0] == 0x6B) // If encrypted
            {
                for (int i = LangFileArray.Length - 1; i >= 1; --i) // Decrypt
                    LangFileArray[i] ^= LangFileArray[i - 1];

                LangFileArray[0] ^= 0x6B;
            }

            return new MemoryStream(LangFileArray);

        }

        public bool IsValid()
        {
            bool IsValid = false;

            // If encrypted, decrypt the file first
            MemoryStream Contents = Decrypt();

            // Check if the file is in the chunk format
            using (var br = new BinaryReader(Contents))
            {
                // Check all the chunks in a file
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    uint ID = br.ReadUInt32();
                    int Size = (br.BaseStream.Position < br.BaseStream.Length) ? br.ReadInt32() : -1;

                    if (Size >= 0 && Size <= br.BaseStream.Length - br.BaseStream.Position) // Check if valid
                    {
                        br.BaseStream.Position += Size;
                        IsValid = true;
                    }
                    else // If the "chunk size" is bigger than the whole file, the file is invalid or not in the chunk format
                    {
                        IsValid = false;
                        break;
                    }
                }
            }
            
            Contents.Dispose();
            return IsValid;
        }

        public void ReadChunks()
        {
            // If encrypted, decrypt the file first
            MemoryStream Contents = Decrypt();

            // Init chunks list
            Chunks = new List<Chunk>();

            using (var br = new BinaryReader(Contents))
            {
                // Read all the chunks in a file
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    var chunk = new Chunk // Read chunk info
                    {
                        Offset = (uint)br.BaseStream.Position,
                        ID = br.ReadUInt32(),
                        Size = br.ReadInt32(),
                    };

                    if (chunk.Size >= 0 && chunk.Size <= br.BaseStream.Length - br.BaseStream.Position) // Check if valid
                    {
                        chunk.Read(br); // Read all the data
                        Chunks.Add(chunk); // Add it to the list
                    }
                    else throw new Exception("The file is invalid or in an incorrect format.");
                }
            }

            Contents.Dispose();
        }

        public void WriteChunks()
        {
            using (var bw = new BinaryWriter(new FileStream(FileName, FileMode.Create)))
            {
                foreach (var chunk in Chunks)
                {
                    chunk.Write(bw);
                }
            }
        }
    }
}
