using System.IO;

namespace Labrune
{
    public class LanguageHistogramChunk : Chunk
    {
        public Charset CharacterSet; 
        
        public LanguageHistogramChunk(Chunk chunk)
        {
            Offset = chunk.Offset;
            ID = chunk.ID;
            Size = chunk.Size;
            Data = chunk.Data;

            var br = new BinaryReader(new MemoryStream(Data));
            Read(br);
            br.Close();
        }

        public LanguageHistogramChunk() { }

        public override void Read(BinaryReader br)
        {
            CharacterSet = new Charset();
            CharacterSet.Read(br);
        }

        public override void Write(BinaryWriter bw)
        {
            bw.Write(ID); // Write chunk ID
            bw.Write(Size); // Write chunk size
            CharacterSet.Write(bw);
        }
    }
}
