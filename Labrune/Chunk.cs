using System.IO;

namespace Labrune
{
    public class Chunk
    {
        public uint Offset;
        public uint ID;
        public int Size;
        public byte[] Data;

        public virtual void Read(BinaryReader br)
        {
            Data = br.ReadBytes(Size); // Read all chunk data
        }

        public virtual void Write(BinaryWriter bw)
        {
            bw.Write(ID); // Write chunk ID
            bw.Write(Size); // Write chunk size
            bw.Write(Data); // Write all chunk data
        }
    }

    // Chunks that can be found in the language files
    public enum ChunkID : uint
    {
        BCHUNK_LANGUAGE = 0x00039000,
        BCHUNK_LANGUAGEHISTOGRAM = 0x00039001,
        BCHUNK_FENG_FONT = 0x00030201
    }
}
