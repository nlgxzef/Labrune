using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Labrune
{
    public partial class Labrune : Form
    {
        LabruneFind Finder;
        LabruneExport Exporter;
        LabruneRestore Restorer;
        LabruneOptions Saver;
        public Labrune()
        {
            InitializeComponent();
            Finder = new LabruneFind();
            Exporter = new LabruneExport();
            Restorer = new LabruneRestore();
            Saver = new LabruneOptions();
        }

        List<File> Files = new List<File>();
        List<LanguageChunk> LangChunks = new List<LanguageChunk>();
        LanguageHistogramChunk HistChunk;
        bool IsFileModified = false;
        bool HasLabels = false;

        List<int> FoundValuesIndexes = new List<int>();
        List<int> ModifiedValuesIndexes = new List<int>();
        int FindIndex;
        int ModifyIndex;
        int CurrentChunk = 0;

        public void MarkFileAsModified()
        {
            if (!IsFileModified) Text = "*" + Text;
            IsFileModified = true;
            PrevModifiedToolStripMenuItem.Enabled = true;
            NextModifiedToolStripMenuItem.Enabled = true;
        }

        public void MarkFileAsUnModified()
        {
            if (IsFileModified) Text = Text.TrimStart('*');
            IsFileModified = false;
            ModifiedValuesIndexes.Clear();
            PrevModifiedToolStripMenuItem.Enabled = false;
            NextModifiedToolStripMenuItem.Enabled = false;
        }

        public void SortStringRecords()
        {
            LangChunks[CurrentChunk].Strings.Sort((x, y) => x.Hash.CompareTo(y.Hash));
        }

        public void RefreshStringView()
        {
            String SelectedItem = String.Empty;
            if (LangStringView.SelectedItems.Count != 0) SelectedItem = LangStringView.SelectedItems[0].SubItems[1].Text; // Get the hash as the text

            LangStringView.Items.Clear();
            int StrID = 0;

            LangStringView.BeginUpdate();

            CurrentChunk = LangChunkSelector.SelectedIndex;

            foreach (LanguageStringRecord StR in LangChunks[CurrentChunk].Strings)
            {
                var StrItm = new ListViewItem();

                StrItm.Text = StrID++.ToString();
                StrItm.SubItems.Add(StR.Hash.ToString("X8"));
                StrItm.SubItems.Add(StR.Label);
                StrItm.SubItems.Add(StR.Text);

                int ItemIndex = LangChunks[CurrentChunk].Strings.IndexOf(StR);
                if (ItemIndex >= 0)
                {
                    if (FoundValuesIndexes.Contains(ItemIndex)) // is a find result
                    {
                        StrItm.BackColor = Color.LightGreen;
                        StrItm.ForeColor = Color.Black;
                    }

                    if (StR.IsModified == true) // is modified
                    {
                        StrItm.BackColor = Color.LightYellow;
                        StrItm.ForeColor = Color.Black;

                        ModifiedValuesIndexes.Add(ItemIndex);
                    }
                }

                LangStringView.Items.Add(StrItm);
            }

            if (ModifiedValuesIndexes.Count > 0)
            {
                PrevModifiedToolStripMenuItem.Enabled = true;
                NextModifiedToolStripMenuItem.Enabled = true;
            }

            LangStringView.EndUpdate();

            if (SelectedItem != String.Empty)
            {
                var ItemWithTheHash = LangStringView.FindItemWithText(SelectedItem, true, 0);
                if (ItemWithTheHash != null)
                {
                    LangStringView.Items[ItemWithTheHash.Index].Selected = true;
                    LangStringView.Items[ItemWithTheHash.Index].EnsureVisible();
                }
            }
        }

        public void EditStringRecord(uint _Hash, uint _NewHash, string _NewLabel, string _NewText)
        {
            var StrRec = LangChunks[CurrentChunk].Strings.Find(x => x.Hash == _Hash);
            if (StrRec != null)
            {
                StrRec.Hash = _NewHash;
                StrRec.Label = _NewLabel;
                StrRec.Text = _NewText;
                StrRec.IsModified = true;
            }

            MarkFileAsModified();

            if (_Hash != _NewHash)
            {
                SortStringRecords();
            }
            RefreshStringView();
        }

        public void EditStringRecord_NoUpdate(uint _Hash, uint _NewHash, string _NewLabel, string _NewText)
        {
            var StrRec = LangChunks[CurrentChunk].Strings.Find(x => x.Hash == _Hash);
            if (StrRec != null)
            {
                StrRec.Hash = _NewHash;
                StrRec.Label = _NewLabel;
                StrRec.Text = _NewText;
                StrRec.IsModified = true;
            }
        }

        public void AddNewStringRecord(uint _Hash, string _Label, string _Text)
        {
            var NewStrRec = new LanguageStringRecord(_Hash, _Label, _Text);
            var StrRec = LangChunks[CurrentChunk].Strings.Find(x => x.Hash == _Hash);

            if (StrRec != null) // Add if there isn't another string with the same hash
            {
                EditStringRecord(_Hash, _Hash, _Label, _Text);
            }
            else // Edit if there is already one
            {
                LangChunks[CurrentChunk].Strings.Add(NewStrRec);
            }

            MarkFileAsModified();
            SortStringRecords();
            RefreshStringView();
        }

        public void AddNewStringRecord_NoUpdate(uint _Hash, string _Label, string _Text)
        {
            var NewStrRec = new LanguageStringRecord(_Hash, _Label, _Text);
            var StrRec = LangChunks[CurrentChunk].Strings.Find(x => x.Hash == _Hash);

            if (StrRec != null)  // Add if there isn't another string with the same hash
            {
                EditStringRecord_NoUpdate(_Hash, _Hash, _Label, _Text);
            }
            else
            {
                LangChunks[CurrentChunk].Strings.Add(NewStrRec);
            }

        }

        public void UpdateAfterImport()
        {
            MarkFileAsModified();

            foreach (LanguageChunk i in LangChunks)
            {
                CurrentChunk = LangChunks.IndexOf(i);
                SortStringRecords();
            }

            LangChunkSelector.SelectedIndex = 0;
            RefreshStringView();
        }

        public void RemoveStringRecord(uint _Hash)
        {
            var StrRec = LangChunks[CurrentChunk].Strings.Find(x => x.Hash == _Hash);
            if (StrRec != null)
            {
                LangChunks[CurrentChunk].Strings.Remove(StrRec);
            }

            MarkFileAsModified();
            SortStringRecords();
            RefreshStringView();
        }

        public void ThrowInfo(string Title, string Instruction, string Message)
        {
            TaskDialog ErrDialog = new TaskDialog();
            ErrDialog.StandardButtons = TaskDialogStandardButtons.Ok;
            ErrDialog.Icon = TaskDialogStandardIcon.Information;
            ErrDialog.InstructionText = string.IsNullOrEmpty(Instruction) ? "" : Instruction;
            ErrDialog.Caption = string.IsNullOrEmpty(Title) ? "" : Title;
            ErrDialog.Text = string.IsNullOrEmpty(Message) ? "" : Message;
            ErrDialog.OwnerWindowHandle = this.Handle;
            ErrDialog.Show();
        }

        public void ThrowError(string Title, string Instruction, string Message)
        {
            TaskDialog ErrDialog = new TaskDialog();
            ErrDialog.StandardButtons = TaskDialogStandardButtons.Ok;
            ErrDialog.Icon = TaskDialogStandardIcon.Error;
            ErrDialog.InstructionText = string.IsNullOrEmpty(Instruction) ? "" : Instruction;
            ErrDialog.Caption = string.IsNullOrEmpty(Title) ? "" : Title;
            ErrDialog.Text = string.IsNullOrEmpty(Message) ? "" : Message;
            ErrDialog.OwnerWindowHandle = this.Handle;
            ErrDialog.Show();
        }

        public void ThrowError(string Title, string Instruction, string Message, string Details)
        {
            TaskDialog ErrDialog = new TaskDialog();
            ErrDialog.StandardButtons = TaskDialogStandardButtons.Ok;
            ErrDialog.Icon = TaskDialogStandardIcon.Error;
            ErrDialog.InstructionText = string.IsNullOrEmpty(Instruction) ? "" : Instruction;
            ErrDialog.Caption = string.IsNullOrEmpty(Title) ? "" : Title;
            ErrDialog.Text = string.IsNullOrEmpty(Message) ? "" : Message;
            ErrDialog.DetailsExpanded = false;
            ErrDialog.DetailsExpandedText = string.IsNullOrEmpty(Details) ? "" : Details;
            ErrDialog.ExpansionMode = TaskDialogExpandedDetailsLocation.ExpandFooter;
            ErrDialog.OwnerWindowHandle = this.Handle;
            ErrDialog.Show();
        }

        public void EnableMenuOptions()
        {
            ImportToolStripMenuItem.Enabled = true;
            exportToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            restoreBackupsToolStripMenuItem.Enabled = true;
            AddToolStripMenuItem.Enabled = true;
            EditStrToolStripMenuItem.Enabled = true;
            RemoveToolStripMenuItem.Enabled = true;
            SearchToolStripMenuItem.Enabled = true;
        }

        public void DisableMenuOptions()
        {
            ImportToolStripMenuItem.Enabled = false;
            exportToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            restoreBackupsToolStripMenuItem.Enabled = false;
            AddToolStripMenuItem.Enabled = false;
            EditStrToolStripMenuItem.Enabled = false;
            RemoveToolStripMenuItem.Enabled = false;
            SearchToolStripMenuItem.Enabled = false;
        }

        public bool LoadFile(string filename)
        {
            bool IsFileLoaded = false;

            // Open the file and read all its chunks
            var LngFile = new File(filename);

            if (LngFile.IsValid())
            {
                LngFile.ReadChunks();

                // Look for a language histogram chunk
                for (int i = 0; i < LngFile.Chunks.Count; i++) // foreach doesn't allow what we do here
                {
                    if (LngFile.Chunks[i].ID == (uint)ChunkID.BCHUNK_LANGUAGEHISTOGRAM)
                    {
                        HistChunk = new LanguageHistogramChunk(LngFile.Chunks[i]); // Convert chunk type
                        LngFile.Chunks[i] = HistChunk;
                        break;
                    }
                }

                if (HistChunk == null) // No histogram data in the language file. Look for the Global file instead.
                {
                    // Attempt to open _Global file for a histogram
                    if (!LngFile.FileName.Contains("_Global"))
                    {
                        String fPath = Path.GetDirectoryName(LngFile.FileName);
                        String fNameWOExt = Path.GetFileNameWithoutExtension(LngFile.FileName);
                        String fExt = Path.GetExtension(LngFile.FileName);

                        String fType = fNameWOExt.LastIndexOf('_') == -1 ? "" : fNameWOExt.Substring(0, fNameWOExt.LastIndexOf('_'));
                        String GlobalFileName = Path.Combine(fPath, fType + "_Global" + fExt);

                        if (System.IO.File.Exists(GlobalFileName))
                        {
                            // Open the file and read all its chunks
                            var GlbFile = new File(GlobalFileName);
                            if (GlbFile.IsValid())
                            {
                                GlbFile.ReadChunks();

                                // Try to find the histogram in it
                                for (int j = 0; j < GlbFile.Chunks.Count; j++) // foreach doesn't allow what we do here
                                {
                                    if (GlbFile.Chunks[j].ID == (uint)ChunkID.BCHUNK_LANGUAGEHISTOGRAM)
                                    {
                                        HistChunk = new LanguageHistogramChunk(GlbFile.Chunks[j]); // Convert chunk type
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                // Read language chunks
                for (int i = 0; i < LngFile.Chunks.Count; i++) // foreach doesn't allow what we do here
                {
                    switch (LngFile.Chunks[i].ID)
                    {
                        case (uint)ChunkID.BCHUNK_LANGUAGE:  // Convert chunk type
                            if (HistChunk == null) LngFile.Chunks[i] = new LanguageChunk(LngFile.Chunks[i]);
                            else LngFile.Chunks[i] = new LanguageChunk(LngFile.Chunks[i], HistChunk.CharacterSet);
                            break;
                    }
                }

                // If everything is OK, add the file to the list.
                IsFileLoaded = true;
                Files.Add(LngFile);
            }

            return IsFileLoaded;
        }

        public void LoadLabels(LanguageChunk LngChk)
        {
            foreach (var i in Files[1].Chunks)
            {
                if (i is LanguageChunk l)
                {
                    foreach (LanguageStringRecord LSR in LngChk.Strings)
                    {
                        LanguageStringRecord result = l.Strings.Find(x => x.Hash == LSR.Hash);
                        if (result != null) LSR.Label = result.Text;
                    }
                }
            }
        }

        public bool SaveFile(LabruneOptions Saver)
        {
            bool IsSavedSuccessfully = false;

            String LanguageFileName = Saver.FileName;
            if (LanguageFileName != "")
            {
                /* TODO: Change chunk format if required
                foreach (Chunk i in Files[0].Chunks)
                {
                    if (i is LanguageChunk l)
                    {
                        if (l.Version != Saver.Version) // Switch chunk version
                        {
                            l.Version = Saver.Version;
                        }
                    }
                }*/

                // save into a .tmp file first
                Files[0].FileName = LanguageFileName + ".tmp";
                Files[0].WriteChunks();

                // Create a backup of the original file
                if (Saver.CreateBackups && System.IO.File.Exists(LanguageFileName))
                {
                    System.IO.File.Copy(LanguageFileName, LanguageFileName + "." + DateTime.Now.ToString("yyyyMMddHHmmss") + ".labrunebackup", false);
                }

                // Copy tmp over the language file
                if (System.IO.File.Exists(Files[0].FileName))
                {
                    System.IO.File.Copy(Files[0].FileName, LanguageFileName, true);
                    System.IO.File.Delete(Files[0].FileName);
                    IsSavedSuccessfully = true;
                }

                // Check labels
                if (HasLabels && Saver.AlsoSaveLabels)
                {
                    IsSavedSuccessfully = false;

                    /* todo: Change chunk format if required
                    foreach (Chunk i in Files[1].Chunks)
                    {
                        if (i is LanguageChunk l)
                        {
                            if (l.Version != Saver.Version) // Switch chunk version
                            {
                                l.Version = Saver.Version;
                            }
                        }
                    }*/

                    LanguageFileName = Files[1].FileName;
                    Files[1].FileName = LanguageFileName + ".tmp";
                    Files[1].WriteChunks();

                    // Create a backup of the original file
                    if (Saver.CreateBackups)
                    {
                        System.IO.File.Copy(LanguageFileName, LanguageFileName + "." + DateTime.Now.ToString("yyyyMMddHHmmss") + ".labrunebackup", false);
                    }

                    // Copy tmp over the language file
                    if (System.IO.File.Exists(Files[1].FileName))
                    {
                        System.IO.File.Copy(Files[1].FileName, LanguageFileName, true);
                        System.IO.File.Delete(Files[1].FileName);
                        IsSavedSuccessfully = true;
                    }
                }
            }

            return IsSavedSuccessfully;
        }

        public bool ExportLabruneDump(LabruneExport Exporter)
        {
            bool IsSavedSuccessfully = false;

            String TXTFileName = Exporter.FileName;
            if (TXTFileName != "")
            {
                try
                {
                    using (StreamWriter TXTFile = new StreamWriter(TXTFileName))
                    {
                        TXTFile.WriteLine("#\t" + Text);
                        TXTFile.WriteLine("#\t" + "File created on: " + DateTime.Now.ToString());
                        TXTFile.WriteLine("#");
                        TXTFile.WriteLine("#" + "Chunk" + "\t" + "Hash (HEX)" + "\t" + "Label" + "\t" + "Value");
                        TXTFile.WriteLine("#" + " " + "---------------------------------------------------------------------------------------------------------");

                        foreach (LanguageChunk i in LangChunks)
                        {
                            if (Exporter.SelectedOnly && LangChunks.IndexOf(i) != CurrentChunk) // If exporter it set to the current chunk only and we aren't on it
                            {
                                continue; // skip the chunk
                            }

                            string ChunkName = (String.IsNullOrEmpty(i.Category) ? "GLOBAL" : i.Category).Trim('\0', ' ');
                            TXTFile.WriteLine("# Chunk " + LangChunks.IndexOf(i) + (String.IsNullOrEmpty(ChunkName) ? "" : " - " + ChunkName));

                            foreach (LanguageStringRecord sR in i.Strings)
                            {
                                bool Next = false;

                                switch (Exporter.EntriesToExport) // Check which entries to export
                                {
                                    case -1: // Unmodified
                                        Next = sR.IsModified; // Skip if modified
                                        break;
                                    case 1: // Modified
                                        Next = !sR.IsModified; // Skip if unmodified
                                        break;
                                }

                                if (Next) continue;

                                bool IsLabelFile = Files[0].FileName.Contains("Labels");
                                bool IsLabelTrue = ((uint)BinHash.Hash(sR.Label) == sR.Hash);
                                string Hash = (IsLabelTrue ? "AUTO" : sR.Hash.ToString("X8")).Trim('\0', ' ');
                                string Label = (String.IsNullOrWhiteSpace(sR.Label) ? "0x" + sR.Hash.ToString("X8") : sR.Label).Trim('\0', ' ');
                                string Text = (IsLabelFile ? Label : sR.Text).Trim('\0', ' ');

                                // Export the entry
                                TXTFile.WriteLine("{0}\t{1}\t{2}\t{3}",
                                                    LangChunks.IndexOf(i), // {0} Chunk ID
                                                    Hash, // {1} Hash
                                                    Label, // {2} Label
                                                    Text); // {3} String
                            }
                        }

                        IsSavedSuccessfully = true;
                    }

                }
                catch (Exception ex)
                {
                    IsSavedSuccessfully = false;
                }
            }

            return IsSavedSuccessfully;
        }

        public bool ExportEndScript(LabruneExport Exporter)
        {
            bool IsSavedSuccessfully = false;

            // Detect file names
            if (Exporter.FileName != "")
            {
                var EndScriptFiles = new List<string>();

                if (Exporter.EndScriptLang == 0) // Current language only
                {
                    EndScriptFiles.Add(Exporter.FileName);
                }
                else // All languages (choose file names according to the one we opened)
                {
                    string FileSuffix = ".bin"; // All good old files
                                                // Get .bin files and filter them according to the file we are working on
                    if (Files[0].FileName.Contains("_Global")) // NFSC+
                    {
                        FileSuffix = "_Global.bin";
                    }
                    else if (Files[0].FileName.Contains("_Frontend")) // NFSC, NFSPS, NFSUC
                    {
                        FileSuffix = "_Frontend.bin";
                    }
                    else if (Files[0].FileName.Contains("_InGame")) // NFSC, NFSPS, NFSUC
                    {
                        FileSuffix = "_InGame.bin";
                    }
                    else if (Files[0].FileName.Contains("_Global_DLC")) // NFSPS
                    {
                        FileSuffix = "_Global_DLC.bin";
                    }
                    else if (Files[0].FileName.Contains("_Subtitles")) // NFSUC
                    {
                        FileSuffix = "_Subtitles.bin";
                    }
                    else if (Files[0].FileName.Contains("_Supplement")) // NFSUC
                    {
                        FileSuffix = "_Supplement.bin";
                    }

                    var LanguageFiles = Directory.GetFiles(Path.GetDirectoryName(Files[0].FileName)).Where(s => s.EndsWith(FileSuffix, StringComparison.OrdinalIgnoreCase));

                    foreach (String FileName in LanguageFiles) EndScriptFiles.Add(Path.Combine(Path.GetDirectoryName(Exporter.FileName), Path.GetFileNameWithoutExtension(FileName) + ".end")); // Change format to end and add to the list
                }

                // Now write the files
                foreach (string FileName in EndScriptFiles)
                {
                    if (FileName.Contains("LanguageTextures")) continue; // Skip LanguageTextures.bin

                    try
                    {
                        using (StreamWriter ENDFile = new StreamWriter(FileName))
                        {
                            string LanguageFileName = Path.GetFileName(FileName);
                            // Header
                            ENDFile.WriteLine("[VERSN2]");
                            ENDFile.WriteLine("// " + Text);
                            ENDFile.WriteLine("// " + "File created on: " + DateTime.Now.ToString());
                            ENDFile.WriteLine();
                            // New negate so the user doesn't have to add it to their end launcher
                            ENDFile.WriteLine("if file_exists absolute Languages\\" + LanguageFileName);
                            ENDFile.WriteLine("do");
                            ENDFile.WriteLine("new negate Languages\\" + LanguageFileName);
                            ENDFile.WriteLine();

                            foreach (LanguageChunk i in LangChunks)
                            {
                                if (Exporter.SelectedOnly && LangChunks.IndexOf(i) != CurrentChunk) // If exporter it set to the current chunk only and we aren't on it
                                {
                                    continue; // skip the chunk
                                }

                                string ChunkName = (String.IsNullOrEmpty(i.Category) ? "GLOBAL" : i.Category).Trim('\0', ' ');

                                ENDFile.WriteLine("// Chunk " + LangChunks.IndexOf(i) + (String.IsNullOrEmpty(ChunkName) ? "" : " - " + ChunkName));
                                ENDFile.WriteLine();

                                foreach (LanguageStringRecord sR in i.Strings)
                                {
                                    bool Next = false;

                                    switch (Exporter.EntriesToExport) // Check which entries to export
                                    {
                                        case -1: // Unmodified
                                            Next = sR.IsModified; // Skip if modified
                                            break;
                                        case 1: // Modified
                                            Next = !sR.IsModified; // Skip if unmodified
                                            break;
                                    }

                                    if (Next) continue;

                                    bool IsLabelFile = FileName.Contains("Labels");
                                    bool IsLabelTrue = ((uint)BinHash.Hash(sR.Label) == sR.Hash);
                                    string Hash = (IsLabelTrue ? "AUTO" : "0x" + sR.Hash.ToString("X8")).Trim('\0', ' ');
                                    string Label = (String.IsNullOrWhiteSpace(sR.Label) ? "0x" + sR.Hash.ToString("X8") : sR.Label).Trim('\0', ' ');
                                    string Text = (IsLabelFile ? Label : sR.Text).Trim('\0', ' ');

                                    // Export the entry
                                    if (Exporter.UseAddOrUpdate) // add_or_update_string
                                    {
                                        ENDFile.WriteLine("add_or_update_string {0} STRBlocks {1} {2} {3} \"{4}\"",
                                                        "Languages\\" + LanguageFileName, // {0} File name
                                                        ChunkName, // {1} Chunk name
                                                        Hash, // {2} Hash
                                                        Label, // {3} Label
                                                        Text); // {4} String

                                    }
                                    else // if string_exists...
                                    {
                                        ENDFile.WriteLine("if string_exists absolute {0} STRBlocks {1} {2}",
                                                        "Languages\\" + LanguageFileName, // {0} File name
                                                        ChunkName, // {1} Chunk name
                                                        Label); // {2} Label
                                        ENDFile.WriteLine("do");
                                        ENDFile.WriteLine("update_string {0} STRBlocks {1} {2} Text \"{3}\"",
                                                        "Languages\\" + LanguageFileName, // {0} File name
                                                        ChunkName, // {1} Chunk name
                                                        Label, // {2} Label
                                                        Text); // {3} String
                                        ENDFile.WriteLine("else");
                                        ENDFile.WriteLine("add_string {0} STRBlocks {1} {2} {3} \"{4}\"",
                                                        "Languages\\" + LanguageFileName, // {0} File name
                                                        ChunkName, // {1} Chunk name
                                                        Hash, // {2} Hash
                                                        Label, // {3} Label
                                                        Text); // {4} String
                                        ENDFile.WriteLine("end");
                                        ENDFile.WriteLine();
                                    }
                                }

                                ENDFile.WriteLine();
                            }

                            ENDFile.WriteLine("delete Languages\\" + LanguageFileName);
                            ENDFile.WriteLine("else // do nothing");
                            ENDFile.WriteLine("end");
                            ENDFile.WriteLine();

                            IsSavedSuccessfully = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        IsSavedSuccessfully = false;
                    }
                }
            }

            return IsSavedSuccessfully;
        }

        public bool RestoreBackups(LabruneRestore Restorer)
        {
            bool IsRestoredSuccessfully = false;

            string OriginalFileName, CutFileName;

            foreach (var FileToRestore in Restorer.FilesToRestoreSelected)
            {
                try
                {
                    // Get original name first (keep removing the file extensions till we get the pure file name)
                    OriginalFileName = Path.GetFileNameWithoutExtension(FileToRestore);

                    for (int i = 10; i > 0; i--) // 10 times so we don't have an infinite loop attempting to remove extensions from the name
                    {
                        CutFileName = Path.GetFileNameWithoutExtension(OriginalFileName);
                        if (OriginalFileName == CutFileName) break;
                        else OriginalFileName = CutFileName;
                    }

                    OriginalFileName += ".bin"; // finally add .bin

                    // Copy & overwrite the original file to restore the backup
                    System.IO.File.Copy(Path.Combine(Restorer.BackupDirectory, FileToRestore), Path.Combine(Restorer.BackupDirectory, OriginalFileName), true);

                    IsRestoredSuccessfully = true;
                }
                catch (Exception)
                {
                    IsRestoredSuccessfully = false;
                    break;
                }
            }

            return IsRestoredSuccessfully;
        }

        public void RestoreFile(string FileName)
        {
            bool IsRestoredSuccessfully = false;

            // Show restore dialog
            Restorer.BackupDirectory = Path.GetDirectoryName(FileName);
            Restorer.InitBackups();
            if (Restorer.FilesToRestore.Count > 0)
            {
                var Result = Restorer.ShowDialog();

                if (Result == DialogResult.OK)
                {
                    if (Restorer.FilesToRestoreSelected.Count < 1)
                    {
                        ThrowError("Labrune", "Error", "No backups are selected to restore.");
                        return;
                    }

                    TaskDialog RstrDialog = new TaskDialog()
                    {
                        StandardButtons = TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No,
                        Icon = TaskDialogStandardIcon.Warning,
                        InstructionText = "Restore backups?",
                        Caption = "Labrune",
                        Text = "Are you sure you want to restore " + Restorer.FilesToRestoreSelected.Count + " backup(s)?" + Environment.NewLine + "After this operation, Labrune will reload the current file in case it gets replaced."
                    };
                    var result = RstrDialog.Show();

                    if (result == TaskDialogResult.No) return;

                    IsRestoredSuccessfully = RestoreBackups(Restorer); // Restore the backups

                    if (IsRestoredSuccessfully)
                    {
                        ThrowInfo("Labrune", "Done!", "Succesfully restored the selected backup(s) in " + Path.GetDirectoryName(Restorer.BackupDirectory) + "." + Environment.NewLine + "Labrune will now reload the current file.");
                        OpenFile(FileName);
                    }
                    else ThrowError("Labrune", "Export Error", "Labrune was unable to restore the selected backup(s) in " + Path.GetDirectoryName(Restorer.BackupDirectory) + "." + Environment.NewLine + "The file(s) may be currently used, corrupt or Labrune doesn't have enough permissions to make file operations here.");
                }
            }
            else ThrowError("Labrune", "Error", "Labrune could not find any backups to restore.");
        }

        public void OpenFile(string FileName)
        {
            if (System.IO.File.Exists(FileName))
            {
                // Initialize
                foreach (LanguageChunk c in LangChunks) c.Strings.Clear();
                LangChunks.Clear();
                Files.Clear();
                LangChunkSelector.Items.Clear();
                HistChunk = null;

                int NrLangChk = 0;

                bool IsFileLoaded = LoadFile(FileName); // Read the file

                if (IsFileLoaded)
                {
                    // Check for labels file
                    if (!Files[0].FileName.Contains("Labels"))
                    {
                        String fPath = Path.GetDirectoryName(Files[0].FileName);
                        String fNameWOExt = Path.GetFileNameWithoutExtension(Files[0].FileName);
                        String fExt = Path.GetExtension(Files[0].FileName);

                        String fType = fNameWOExt.LastIndexOf('_') == -1 ? "" : fNameWOExt.Substring(fNameWOExt.LastIndexOf('_'));
                        String LabelFileName = Path.Combine(fPath, "Labels" + (String.IsNullOrEmpty(fType) ? "" : fType) + fExt);

                        if (System.IO.File.Exists(LabelFileName))
                        {
                            IsFileLoaded = LoadFile(LabelFileName);
                            if (IsFileLoaded) HasLabels = true;
                        }
                        else HasLabels = false;
                    }
                    else HasLabels = false;

                    foreach (var i in Files[0].Chunks)
                    {
                        if (i is LanguageChunk l)
                        {
                            LangChunks.Add(l);
                            if (HasLabels) LoadLabels(l);
                            LangChunkSelector.Items.Add("[Language: " + l.Version.ToString() + "] #" + NrLangChk++ + (String.IsNullOrEmpty(l.Category) ? "" : (" - " + l.Category)));
                        }
                    }

                    if (LangChunkSelector.Items.Count > 0)
                    {
                        LangChunkSelector.SelectedItem = LangChunkSelector.Items[0];
                        StatusBarText.Text = "Ready.";
                        Text = "Labrune" + " - " + FileName;
                        EnableMenuOptions();

                        if (LangChunkSelector.Items.Count == 1) LangChunkSelector.Enabled = false;
                        else LangChunkSelector.Enabled = true;
                    }
                    else
                    {
                        ThrowError("Labrune", "Error!", "The file contains no language chunks.");
                        StatusBarText.Text = "No language chunks are detected in the selected file.";
                        DisableMenuOptions();
                        LangChunkSelector.Enabled = false;
                    }
                }
                else
                {
                    TaskDialog RstrDialog = new TaskDialog()
                    {
                        StandardButtons = TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No,
                        Icon = TaskDialogStandardIcon.Error,
                        InstructionText = "Error!",
                        Caption = "Labrune",
                        Text = "The file is in an invalid format." + Environment.NewLine + "Would you like to restore a backup of it?"
                    };
                    var result = RstrDialog.Show();

                    if (result == TaskDialogResult.No)
                    {
                        StatusBarText.Text = "Invalid file.";
                        DisableMenuOptions();
                        LangChunkSelector.Enabled = false;
                    }
                    else RestoreFile(FileName);
                }
            }
            else
            {
                ThrowError("Labrune", "Error!", "File doesn't exist or can't be accessed.");
                StatusBarText.Text = "File doesn't exist or can't be accessed.";
                DisableMenuOptions();
                LangChunkSelector.Enabled = false;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenLanguageFileDlg.ShowDialog() == DialogResult.OK)
            {
                OpenFile(OpenLanguageFileDlg.FileName);
            }
        }

        private void LangChunkSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear find results
            FoundValuesIndexes.Clear();
            FindNextToolStripMenuItem.Enabled = false;
            FindPreviousToolStripMenuItem.Enabled = false;

            // Rebuild modified indexes list
            ModifiedValuesIndexes.Clear();
            NextModifiedToolStripMenuItem.Enabled = false;
            PrevModifiedToolStripMenuItem.Enabled = false;

            RefreshStringView();
        }

        private void fontSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FontSettingsDlg.ShowDialog() == DialogResult.OK)
            {
                LangStringView.Font = FontSettingsDlg.Font;
            }
        }

        private void LangStringView_DoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = LangStringView.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (item != null)
            {
                var StringEditor = new LabruneEdit();
                if (BinHash.Hash(item.SubItems[2].Text).ToString("X8") != item.SubItems[1].Text) StringEditor.CheckUseCustomHash.Checked = true;
                StringEditor.ID = item.Text;
                StringEditor.Hash = item.SubItems[1].Text;
                StringEditor.Label = item.SubItems[2].Text;
                StringEditor.Value = item.SubItems[3].Text;

                var Result = StringEditor.ShowDialog();

                if (Result == DialogResult.OK)
                {
                    EditStringRecord(uint.Parse(StringEditor.Hash, System.Globalization.NumberStyles.HexNumber), uint.Parse(StringEditor.NewHash, System.Globalization.NumberStyles.HexNumber), StringEditor.NewLabel, StringEditor.NewValue);
                }

            }

            else
            {
                LangStringView.SelectedItems.Clear();
            }
        }

        private void Labrune_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsFileModified == true)
            {
                TaskDialog ExitDialog = new TaskDialog();
                ExitDialog.StandardButtons = TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No | TaskDialogStandardButtons.Cancel;
                ExitDialog.Icon = TaskDialogStandardIcon.Warning;
                ExitDialog.InstructionText = "Save?";
                ExitDialog.Caption = "Labrune";
                ExitDialog.Text = "Would you like to save your changes before quitting?";

                var result = ExitDialog.Show();

                if (result == TaskDialogResult.Yes)
                {
                    SaveToolStripMenuItem_Click(this, new EventArgs());
                }
                else if (result == TaskDialogResult.Cancel)
                {
                    // Return to the form
                    e.Cancel = true;
                }

            }
        }

        private void LabruneTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String TXTLineBuffer;
            int ImportedEntries = 0;
            int IgnoredEntries = 0;

            if (OpenLabruneDumpDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream TXTFileStream = System.IO.File.Open(OpenLabruneDumpDialog.FileName, FileMode.Open);

                    using (StreamReader TXTFile = new StreamReader(TXTFileStream))
                    {
                        while ((TXTLineBuffer = TXTFile.ReadLine()) != null)
                        {
                            if (!TXTLineBuffer.StartsWith("#") && !TXTLineBuffer.StartsWith("//")) // If it's not a comment
                            {
                                char[] charsToTrim = { '\t' };
                                String[] Parts = TXTLineBuffer.Split(charsToTrim, StringSplitOptions.None);

                                if (Parts.Length >= 4)
                                {
                                    try
                                    {
                                        // Merge string if it contains tabs
                                        String LabruneString = "";
                                        for (int i = 3; i < Parts.Length; i++) LabruneString += Parts[i] + '\t';

                                        CurrentChunk = Int32.Parse(Parts[0]); // Switch to the specified chunk
                                        if (CurrentChunk <= LangChunks.Count)
                                        {
                                            uint ParsedStringHash = 0;

                                            if (Parts[1] == "AUTO")
                                            {
                                                AddNewStringRecord_NoUpdate((uint)BinHash.Hash(Parts[2]), Parts[2], LabruneString.TrimEnd('\t'));
                                                ImportedEntries++;
                                            }

                                            else if (UInt32.TryParse(Parts[1].StartsWith("0x") ? Parts[1].Substring(2) : Parts[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out ParsedStringHash) == true)
                                            {
                                                AddNewStringRecord_NoUpdate(ParsedStringHash, Parts[2], LabruneString.TrimEnd('\t'));
                                                ImportedEntries++;
                                            }
                                            else IgnoredEntries++;

                                        }
                                        else IgnoredEntries++;

                                    }
                                    catch (Exception)
                                    {
                                        IgnoredEntries++;
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                    UpdateAfterImport();

                    String Status = "Imported" + " " + ImportedEntries + " " + "entries for" + " " + LangChunks.Count + " " + "language chunk(s).";
                    if (IgnoredEntries > 0) Status += "\n" + "Ignored" + " " + IgnoredEntries + " " + "entries due to some formatting errors in selected text file.";

                    //MessageBox.Show(Status, "Labrune", MessageBoxButtons.OK);

                    TaskDialog MsgDialog = new TaskDialog();
                    MsgDialog.StandardButtons = TaskDialogStandardButtons.Ok;
                    MsgDialog.Icon = TaskDialogStandardIcon.Information;
                    MsgDialog.InstructionText = "Done!";
                    MsgDialog.Caption = "Labrune";
                    MsgDialog.Text = Status;
                    MsgDialog.Show();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show("There is something wrong with the selected text file." + Environment.NewLine + "It may be currently used, corrupted or Labrune doesn't have enough permissions to process it.", "Labrune", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TaskDialog ErrDialog = new TaskDialog();
                    ErrDialog.StandardButtons = TaskDialogStandardButtons.Ok;
                    ErrDialog.Icon = TaskDialogStandardIcon.Error;
                    ErrDialog.InstructionText = "Error!";
                    ErrDialog.Caption = "Labrune";
                    ErrDialog.Text = "There is something wrong with the selected text file." + Environment.NewLine + "It may be currently used, corrupted or Labrune doesn't have enough permissions to process it.";
                    ErrDialog.DetailsExpanded = false;
                    ErrDialog.DetailsExpandedText = ex.ToString();
                    ErrDialog.ExpansionMode = TaskDialogExpandedDetailsLocation.ExpandFooter;
                    ErrDialog.Show();
                }
            }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var StringEditor = new LabruneEdit();
            StringEditor.IsNewString = true;

            var Result = StringEditor.ShowDialog();

            if (Result == DialogResult.OK)
            {
                AddNewStringRecord(uint.Parse(StringEditor.NewHash, System.Globalization.NumberStyles.HexNumber), StringEditor.NewLabel, StringEditor.NewValue);
            }
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = null;
            if (LangStringView.SelectedItems.Count != 0) item = LangStringView.SelectedItems[0];

            if (item != null)
            {
                RemoveStringRecord(uint.Parse(item.SubItems[1].Text, System.Globalization.NumberStyles.HexNumber));
            }

            else
            {
                LangStringView.SelectedItems.Clear();
            }
        }

        private void EditStrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = null;
            if (LangStringView.SelectedItems.Count != 0) item = LangStringView.SelectedItems[0];

            if (item != null)
            {
                var StringEditor = new LabruneEdit();
                if (BinHash.Hash(item.SubItems[2].Text).ToString("X8") != item.SubItems[1].Text) StringEditor.CheckUseCustomHash.Checked = true;
                StringEditor.ID = item.Text;
                StringEditor.Hash = item.SubItems[1].Text;
                StringEditor.Label = item.SubItems[2].Text;
                StringEditor.Value = item.SubItems[3].Text;

                var Result = StringEditor.ShowDialog();

                if (Result == DialogResult.OK)
                {
                    EditStringRecord(uint.Parse(StringEditor.Hash, System.Globalization.NumberStyles.HexNumber), uint.Parse(StringEditor.NewHash, System.Globalization.NumberStyles.HexNumber), StringEditor.NewLabel, StringEditor.NewValue);
                }

            }

            else
            {
                LangStringView.SelectedItems.Clear();
            }
        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindNextToolStripMenuItem.Enabled = false;
            FindPreviousToolStripMenuItem.Enabled = false;

            foreach (ListViewItem item in LangStringView.Items) // Clear previous results
            {
                if (item.BackColor == Color.LightGreen)
                {
                    item.BackColor = Color.FromKnownColor(KnownColor.Window);
                    item.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
                }
            }

            var Result = Finder.ShowDialog();

            if ((Result == DialogResult.OK) && (Finder.ValueToFind != String.Empty))
            {
                FoundValuesIndexes.Clear();
                String unhexifiedStr = Finder.ValueToFind.StartsWith("0x") ? Finder.ValueToFind.Substring(2) : Finder.ValueToFind;

                if (Finder.AlsoSearchInHashesAndLabels)
                {
                    if (Finder.IsCaseSensitive)
                    {
                        foreach (ListViewItem item in LangStringView.Items)
                        {
                            if (item.SubItems[1].Text.Contains(unhexifiedStr) || item.SubItems[2].Text.Contains(Finder.ValueToFind) || item.SubItems[3].Text.Contains(Finder.ValueToFind))
                            {
                                FoundValuesIndexes.Add(item.Index);
                                item.BackColor = Color.LightGreen; // Mark results
                                item.ForeColor = Color.Black; // Mark results
                            }
                        }
                    }

                    else
                    {
                        foreach (ListViewItem item in LangStringView.Items)
                        {
                            var enUS = new System.Globalization.CultureInfo("en-US");

                            if (item.SubItems[1].Text.ToUpper(enUS).Contains(unhexifiedStr.ToUpper(enUS)) || item.SubItems[2].Text.ToUpper(enUS).Contains(Finder.ValueToFind.ToUpper(enUS)) || item.SubItems[3].Text.ToUpper(enUS).Contains(Finder.ValueToFind.ToUpper(enUS)))
                            {
                                FoundValuesIndexes.Add(item.Index);
                                item.BackColor = Color.LightGreen; // Mark results
                                item.ForeColor = Color.Black; // Mark results
                            }
                        }
                    }
                }
                else
                {
                    if (Finder.IsCaseSensitive)
                    {
                        foreach (ListViewItem item in LangStringView.Items)
                        {
                            if (item.SubItems[3].Text.Contains(Finder.ValueToFind))
                            {
                                FoundValuesIndexes.Add(item.Index);
                                item.BackColor = Color.LightGreen; // Mark results
                                item.ForeColor = Color.Black; // Mark results
                            }
                        }
                    }

                    else
                    {
                        foreach (ListViewItem item in LangStringView.Items)
                        {
                            if (item.SubItems[3].Text.ToUpper().Contains(Finder.ValueToFind.ToUpper()))
                            {
                                FoundValuesIndexes.Add(item.Index);
                                item.BackColor = Color.LightGreen; // Mark results
                                item.ForeColor = Color.Black; // Mark results
                            }
                        }
                    }
                }

                if (FoundValuesIndexes.Count != 0)
                {
                    FindIndex = 0;
                    LangStringView.SelectedIndices.Clear();
                    LangStringView.Items[FoundValuesIndexes[FindIndex]].Selected = true;
                    LangStringView.Items[FoundValuesIndexes[FindIndex]].EnsureVisible();

                    FindNextToolStripMenuItem.Enabled = true;
                    FindPreviousToolStripMenuItem.Enabled = true;
                }

                else
                {
                    //MessageBox.Show("Search couldn't find anything with text \"" + Finder.ValueToFind + "\".", "Labrune", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TaskDialog MsgDialog = new TaskDialog();
                    MsgDialog.StandardButtons = TaskDialogStandardButtons.Ok;
                    MsgDialog.Icon = TaskDialogStandardIcon.Warning;
                    MsgDialog.InstructionText = "Not found.";
                    MsgDialog.Caption = "Labrune";
                    MsgDialog.Text = "Search couldn't find anything with text \"" + Finder.ValueToFind + "\".";
                    MsgDialog.Show();

                    FindNextToolStripMenuItem.Enabled = false;
                    FindPreviousToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void FindPreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FoundValuesIndexes.Count != 0)
            {
                FindIndex = (FindIndex - 1 + FoundValuesIndexes.Count) % FoundValuesIndexes.Count;
                LangStringView.SelectedIndices.Clear();
                LangStringView.Items[FoundValuesIndexes[FindIndex]].Selected = true;
                LangStringView.Items[FoundValuesIndexes[FindIndex]].EnsureVisible();
            }
        }

        private void FindNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FoundValuesIndexes.Count != 0)
            {
                FindIndex = (FindIndex + 1) % FoundValuesIndexes.Count;
                LangStringView.SelectedIndices.Clear();
                LangStringView.Items[FoundValuesIndexes[FindIndex]].Selected = true;
                LangStringView.Items[FoundValuesIndexes[FindIndex]].EnsureVisible();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReCompilerConfigurationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Title = "Select the folder which contains Language Config files for ReCompiler";

            int ImportedEntries = 0;
            int IgnoredEntries = 0;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                DirectoryInfo di = new DirectoryInfo(dialog.FileName);
                FileInfo[] INIFiles = di.GetFiles("*.ini");

                if (INIFiles.Length == 0)
                {
                    //MessageBox.Show("There aren't any ReCompiler Language Config files in the selected folder.", "Labrune", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TaskDialog MsgNDialog = new TaskDialog();
                    MsgNDialog.StandardButtons = TaskDialogStandardButtons.Ok;
                    MsgNDialog.Icon = TaskDialogStandardIcon.Warning;
                    MsgNDialog.InstructionText = "Not found.";
                    MsgNDialog.Caption = "Labrune";
                    MsgNDialog.Text = "There aren't any ReCompiler Language Config files in the selected folder.";
                    MsgNDialog.Show();
                }
                else
                {
                    foreach (FileInfo i in INIFiles)
                    {
                        try
                        {
                            var IniReader = new IniFile(i.FullName);
                            String RCLabel = Path.GetFileNameWithoutExtension(i.FullName);
                            String RCText = IniReader.GetValue("INFO", "Name", ""); // Get text

                            if (!(String.IsNullOrEmpty(RCLabel) || String.IsNullOrEmpty(RCText)))
                            {
                                uint RCHash = (uint)BinHash.Hash(RCLabel); // Hash the label
                                AddNewStringRecord_NoUpdate(RCHash, RCLabel, RCText); // Add
                                ImportedEntries++;
                            }
                            else IgnoredEntries++;
                        }

                        catch (Exception)
                        {
                            IgnoredEntries++;
                        }
                    }
                    UpdateAfterImport();

                    String Status = "Imported" + " " + ImportedEntries + " " + "entries.";
                    if (IgnoredEntries > 0) Status += "\n" + "Ignored" + " " + IgnoredEntries + " " + "entries due to some errors.";

                    //MessageBox.Show(Status, "Labrune", MessageBoxButtons.OK);
                    TaskDialog MsgDialog = new TaskDialog();
                    MsgDialog.StandardButtons = TaskDialogStandardButtons.Ok;
                    MsgDialog.Icon = TaskDialogStandardIcon.Information;
                    MsgDialog.InstructionText = "Done!";
                    MsgDialog.Caption = "Labrune";
                    MsgDialog.Text = Status;
                    MsgDialog.Show();
                }
            }
        }

        private void EdConfigurationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Title = "Select the folder which contains Config files for Ed";

            int ImportedEntries = 0;
            int IgnoredEntries = 0;
            int NoEntries = 0;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                DirectoryInfo di = new DirectoryInfo(dialog.FileName);
                FileInfo[] INIFiles = di.GetFiles("*.ini");

                if (INIFiles.Length == 0)
                {
                    //MessageBox.Show("There aren't any Ed Config files in the selected folder.", "Labrune", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TaskDialog MsgNDialog = new TaskDialog();
                    MsgNDialog.StandardButtons = TaskDialogStandardButtons.Ok;
                    MsgNDialog.Icon = TaskDialogStandardIcon.Warning;
                    MsgNDialog.InstructionText = "Not found.";
                    MsgNDialog.Caption = "Labrune";
                    MsgNDialog.Text = "There aren't any Ed Config files in the selected folder.";
                    MsgNDialog.Show();
                }
                else
                {
                    foreach (FileInfo i in INIFiles)
                    {
                        try
                        {
                            var IniReader = new IniFile(i.FullName);

                            int NumberOfResources = IniReader.GetInteger("RESOURCES", "NumberOfResources", 0, 0);

                            if (NumberOfResources == 0) // Old ini format
                            {
                                String EdLabel = IniReader.GetValue("RESOURCES", "Label", "");
                                String EdText = IniReader.GetValue("RESOURCES", "Name", "");

                                if (!(String.IsNullOrEmpty(EdLabel) || String.IsNullOrEmpty(EdText)))
                                {
                                    uint EdHash = (uint)BinHash.Hash(EdLabel); // Hash the label
                                    AddNewStringRecord_NoUpdate(EdHash, EdLabel, EdText); // Add
                                    ImportedEntries++;
                                }
                                else NoEntries++;
                            }
                            else // New ini format with multiple resoruces support
                            {
                                for (int r = 1; r <= NumberOfResources; r++)
                                {
                                    String EdLabel = IniReader.GetValue(String.Format("RESOURCE{0}", r), "Label", "");
                                    String EdText = IniReader.GetValue(String.Format("RESOURCE{0}", r), "Name", "");

                                    if (!(String.IsNullOrEmpty(EdLabel) || String.IsNullOrEmpty(EdText)))
                                    {
                                        uint EdHash = (uint)BinHash.Hash(EdLabel); // Hash the label
                                        AddNewStringRecord_NoUpdate(EdHash, EdLabel, EdText); // Add
                                        ImportedEntries++;
                                    }
                                    else NoEntries++;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            IgnoredEntries++;
                        }
                    }
                }
                UpdateAfterImport();

                String Status = "Imported" + " " + ImportedEntries + " " + "entries.";
                if (NoEntries > 0) Status += "\n" + NoEntries + " " + "of the configuration files doesn't contain any string resources.";
                if (IgnoredEntries > 0) Status += "\n" + "Ignored" + " " + IgnoredEntries + " " + "entries due to some errors.";

                //MessageBox.Show(Status, "Labrune", MessageBoxButtons.OK);

                TaskDialog MsgDialog = new TaskDialog();
                MsgDialog.StandardButtons = TaskDialogStandardButtons.Ok;
                MsgDialog.Icon = TaskDialogStandardIcon.Information;
                MsgDialog.InstructionText = "Done!";
                MsgDialog.Caption = "Labrune";
                MsgDialog.Text = Status;
                MsgDialog.Show();

            }
        }

        private void LangEdDumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String TXTLineBuffer;
            int ImportedEntries = 0;
            int IgnoredEntries = 0;

            if (OpenLangEdDumpDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream TXTFileStream = System.IO.File.Open(OpenLangEdDumpDialog.FileName, FileMode.Open);

                    using (StreamReader TXTFile = new StreamReader(TXTFileStream))
                    {
                        while ((TXTLineBuffer = TXTFile.ReadLine()) != null)
                        {
                            char[] charsToTrim = { '\t' };
                            String[] Parts = TXTLineBuffer.Split(charsToTrim, StringSplitOptions.None);

                            if (Parts.Length >= 3)
                            {
                                try
                                {
                                    // Merge string if it contains tabs
                                    String LangEdString = "";
                                    for (int i = 2; i < Parts.Length; i++) LangEdString += Parts[i] + '\t';

                                    if (!(String.IsNullOrEmpty(Parts[1])))
                                    {
                                        uint LangEdHash = (uint)BinHash.Hash(Parts[1]); // Hash the label
                                        AddNewStringRecord_NoUpdate(LangEdHash, Parts[1], LangEdString); // Add
                                        ImportedEntries++;
                                    }

                                }
                                catch (Exception)
                                {
                                    IgnoredEntries++;
                                    continue;
                                }
                            }
                        }
                    }
                    UpdateAfterImport();

                    String Status = "Imported" + " " + ImportedEntries + " " + "entries.";
                    if (IgnoredEntries > 0) Status += "\n" + "Ignored" + " " + IgnoredEntries + " " + "entries due to some formatting errors in selected text file.";

                    //MessageBox.Show(Status, "Labrune", MessageBoxButtons.OK);

                    TaskDialog MsgDialog = new TaskDialog();
                    MsgDialog.StandardButtons = TaskDialogStandardButtons.Ok;
                    MsgDialog.Icon = TaskDialogStandardIcon.Information;
                    MsgDialog.InstructionText = "Done!";
                    MsgDialog.Caption = "Labrune";
                    MsgDialog.Text = Status;
                    MsgDialog.Show();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("There is something wrong with the selected text file." + Environment.NewLine + "It may be currently used, corrupted or Labrune doesn't have enough permissions to process it.", "Labrune", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TaskDialog ErrDialog = new TaskDialog();
                    ErrDialog.StandardButtons = TaskDialogStandardButtons.Ok;
                    ErrDialog.Icon = TaskDialogStandardIcon.Error;
                    ErrDialog.InstructionText = "Error!";
                    ErrDialog.Caption = "Labrune";
                    ErrDialog.Text = "There is something wrong with the selected text file." + Environment.NewLine + "It may be currently used, corrupted or Labrune doesn't have enough permissions to process it.";
                    ErrDialog.DetailsExpanded = false;
                    ErrDialog.DetailsExpandedText = ex.ToString();
                    ErrDialog.ExpansionMode = TaskDialogExpandedDetailsLocation.ExpandFooter;
                    ErrDialog.Show();
                }
            }
        }

        private void ReCompilerOldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String TXTLineBuffer;
            int ImportedEntries = 0;
            int IgnoredEntries = 0;

            if (OpenReCompilerIniDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream TXTFileStream = System.IO.File.Open(OpenReCompilerIniDialog.FileName, FileMode.Open);

                    using (StreamReader TXTFile = new StreamReader(TXTFileStream))
                    {
                        while ((TXTLineBuffer = TXTFile.ReadLine()) != null)
                        {
                            if (!(TXTLineBuffer.StartsWith("#") || TXTLineBuffer.StartsWith("["))) // If it's not a comment or section name
                            {
                                char[] charsToTrim = { '=' };
                                String[] Parts = TXTLineBuffer.Split(charsToTrim, StringSplitOptions.RemoveEmptyEntries);

                                if (Parts.Length == 2)
                                {
                                    try
                                    {
                                        // Remove leading and trailing spaces or tabs.
                                        Parts[0] = Parts[0].TrimStart(' ', '\t').TrimEnd(' ', '\t');
                                        Parts[1] = Parts[1].TrimStart(' ', '\t').TrimEnd(' ', '\t');
                                        AddNewStringRecord_NoUpdate((UInt32)BinHash.Hash(Parts[0]), Parts[0], Parts[1]);
                                        ImportedEntries++;

                                    }
                                    catch (Exception)
                                    {
                                        IgnoredEntries++;
                                        continue;
                                    }
                                }
                                else IgnoredEntries++;
                            }
                        }
                    }
                    UpdateAfterImport();

                    String Status = "Imported" + " " + ImportedEntries + " " + "entries.";
                    if (IgnoredEntries > 0) Status += "\n" + "Ignored" + " " + IgnoredEntries + " " + "entries due to some formatting errors in selected text file.";

                    //MessageBox.Show(Status, "Labrune", MessageBoxButtons.OK);
                    TaskDialog MsgDialog = new TaskDialog();
                    MsgDialog.StandardButtons = TaskDialogStandardButtons.Ok;
                    MsgDialog.Icon = TaskDialogStandardIcon.Information;
                    MsgDialog.InstructionText = "Done!";
                    MsgDialog.Caption = "Labrune";
                    MsgDialog.Text = Status;
                    MsgDialog.Show();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show("There is something wrong with the selected ReCompiler config file." + Environment.NewLine + "It may be currently used, corrupted or Labrune doesn't have enough permissions to process it.", "Labrune", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TaskDialog ErrDialog = new TaskDialog();
                    ErrDialog.StandardButtons = TaskDialogStandardButtons.Ok;
                    ErrDialog.Icon = TaskDialogStandardIcon.Error;
                    ErrDialog.InstructionText = "Error!";
                    ErrDialog.Caption = "Labrune";
                    ErrDialog.Text = "There is something wrong with the selected ReCompiler config file." + Environment.NewLine + "It may be currently used, corrupted or Labrune doesn't have enough permissions to process it.";
                    ErrDialog.DetailsExpanded = false;
                    ErrDialog.DetailsExpandedText = ex.ToString();
                    ErrDialog.ExpansionMode = TaskDialogExpandedDetailsLocation.ExpandFooter;
                    ErrDialog.Show();
                }
            }
        }

        private void NextModifiedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ModifiedValuesIndexes.Count > 0)
            {
                ModifyIndex = (ModifyIndex + 1) % ModifiedValuesIndexes.Count;
                LangStringView.SelectedIndices.Clear();
                LangStringView.Items[ModifiedValuesIndexes[ModifyIndex]].Selected = true;
                LangStringView.Items[ModifiedValuesIndexes[ModifyIndex]].EnsureVisible();
            }

        }

        private void PrevModifiedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ModifiedValuesIndexes.Count > 0)
            {
                ModifyIndex = (ModifyIndex - 1 + ModifiedValuesIndexes.Count) % ModifiedValuesIndexes.Count;
                LangStringView.SelectedIndices.Clear();
                LangStringView.Items[ModifiedValuesIndexes[ModifyIndex]].Selected = true;
                LangStringView.Items[ModifiedValuesIndexes[ModifyIndex]].EnsureVisible();
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsSavedSuccessfully = false;

            Saver.FileName = Files[0].FileName;
            Saver.Version = LangChunks[0].Version;
            Saver.EnableLabelsOption(HasLabels);

            var Result = Saver.ShowDialog();

            if (Result == DialogResult.OK)
            {
                IsSavedSuccessfully = SaveFile(Saver);

                if (IsSavedSuccessfully)
                {
                    ThrowInfo("Labrune", "Done!", "Succesfully saved language file " + Path.GetFileName(Saver.FileName) + " to " + Path.GetDirectoryName(Saver.FileName) + ".");
                    MarkFileAsUnModified();
                }
                else ThrowError("Labrune", "Save Error", "Labrune was unable to save language file" + Path.GetFileName(Saver.FileName) + " to " + Path.GetDirectoryName(Saver.FileName) + "." + Environment.NewLine + "The file may be currently used, corrupt or Labrune doesn't have enough permissions to make file operations here.");
            }
        }

        private void AboutLabruneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var AboutWindow = new LabruneAbout();
            AboutWindow.ShowDialog();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsExportedSuccessfully = false;

            // Show export options dialog
            if (ExportFileDialog.ShowDialog() == DialogResult.OK)
            {
                Exporter.SetFileName(ExportFileDialog.FileName);
                Exporter.SetChunkInfo(CurrentChunk, LangChunks.Count);
                Exporter.SetEntryInfo(ModifiedValuesIndexes.Count);
                var Result = Exporter.ShowDialog();

                if (Result == DialogResult.OK)
                {
                    IsExportedSuccessfully = Exporter.FileFormat == 1 ? ExportEndScript(Exporter) : ExportLabruneDump(Exporter);

                    if (IsExportedSuccessfully) ThrowInfo("Labrune", "Done!", "Succesfully exported " + ((Exporter.FileFormat == 1 && Exporter.EndScriptLang == 1) ? "multiple end script files" : Path.GetFileName(Exporter.FileName)) + " to " + Path.GetDirectoryName(Exporter.FileName) + ".");
                    else ThrowError("Labrune", "Export Error", "Labrune was unable to export " + ((Exporter.FileFormat == 1 && Exporter.EndScriptLang == 1) ? "multiple end script files" : Path.GetFileName(Exporter.FileName)) + " to " + Path.GetDirectoryName(Exporter.FileName) + "." + Environment.NewLine + "The file(s) may be currently used, corrupt or Labrune doesn't have enough permissions to make file operations here.");
                }
            }
        }

        private void restoreBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreFile(Files[0].FileName);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsSavedSuccessfully = false;

            SaveLanguageFileDlg.FileName = Files[0].FileName;
            SaveLanguageFileDlg.InitialDirectory = Files[0].FileName;

            // Show save options dialog
            if (SaveLanguageFileDlg.ShowDialog() == DialogResult.OK)
            {
                Saver.FileName = SaveLanguageFileDlg.FileName;
                Saver.Version = LangChunks[0].Version;
                Saver.EnableLabelsOption(HasLabels);

                var Result = Saver.ShowDialog();

                if (Result == DialogResult.OK)
                {
                    IsSavedSuccessfully = SaveFile(Saver);

                    if (IsSavedSuccessfully)
                    {
                        ThrowInfo("Labrune", "Done!", "Succesfully saved language file " + Path.GetFileName(Saver.FileName) + " to " + Path.GetDirectoryName(Saver.FileName) + ".");
                        MarkFileAsUnModified();
                    }
                    else ThrowError("Labrune", "Save Error", "Labrune was unable to save language file" + Path.GetFileName(Saver.FileName) + " to " + Path.GetDirectoryName(Saver.FileName) + "." + Environment.NewLine + "The file may be currently used, corrupt or Labrune doesn't have enough permissions to make file operations here.");
                }
            }
        }
    }
}