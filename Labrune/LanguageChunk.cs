using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labrune
{
    public class LanguageChunk
    {
        public int Offset;
        public int Size;
        public LanguageFileVersion Version; // MW will have 0x10 at chunk offset 0x08.
        public int NumberOfStringRecords;
        public int StringRecordsOffset;
        public int TextOffset;
        public string Category; // Size: 0x10 (new files only)
        public byte[] UnkData; // Old chunks only, from 0x10 to the StringRecordsOffset
        public List<LanguageStringRecord> Strings;
    }

    public enum LanguageFileVersion
    {
        Old, New
    };
}
