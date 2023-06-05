# Labrune - The Language Editor for NFS Games!  
---------------------------
# v2 TODO - WORK IN PROGRESS:
- [x] Rework file loading and saving.
- [ ] Command line support.
- [ ] String file sync-up. (Compare with another file and apply the changes to the one worked on)
- [ ] Ability to change language chunk format.
- [ ] Ability to include/exclude histogram.
- [x] Ability to restore any backup. (.edbackup, .labrunebackup, .bacc, .bak or .bin_)
- [x] Auto-Detect language file version + fix Labrune so it can open the files modified via Binary.
- [ ] Rework Import/Export functionality (export done) + add support for Binary end scripts (import).
- [x] Charset (Language Histogram) support.

---------------------------
# Description:

Labrune is designed as an easy to use, open source language file editor for NFS games. The name comes from one of the NFS Carbon's localization producers, Christophe Labrune.

Currently supported games are:
- Need for Speed: Underground
- Need for Speed: Underground 2
- Need for Speed: Most Wanted (2005)
- Need for Speed: Carbon
- Need for Speed: ProStreet
- Need for Speed: Undercover
- Need for Speed: World

The tool is pretty straightforward and it's made for last user. So, anyone who knows English can easily use it.

----------------------------
# Features and Usage:

File:
- Open (Ctrl+O) : Select any NFS Language Binary File (.bin) to edit it using Labrune.
- Import : You can import string data from various sources. They are described below.
    - Labrune Dump : Import string data from a text file exported using Labrune. It's applied to all language chunks, if the file contains multiple.
    - Ed Config Folder : Select your Ed Configurations (Ed\Config\GAME) folder to import string data. It's applied to currently selected language chunk.
    - ReCompiler Language Folder (New) : Select your ReCompiler Language (ReCompiler\LANGUAGE) folder to import all the .ini files that contains string data. It's applied to currently selected language chunk.
    - ReCompiler Config.ini (Old) : Select your ReCompiler/Texture Compiler Language (Texture Compiler\LANGUAGE\Add\Config.ini) file to import all the string data in it. It's applied to currently selected language chunk.
    - LangEd Dump: Import string data from a text file exported using NFS-LangEd. It's applied to currently selected language chunk.
- Export (Ctrl+E) : You can export string data from currently opened language file to edit it externally. Available options are below:
    - File formats:
        - Labrune Dump : A plain text file with a dump of the strings. Can be edited via any text editor.
	    - End Script Version 2 : Can be used with Binary's User Mode.
    - Chunks:
	    - All : Exports entries from all the chunks the file has.
		- Selected (X) : Exports entries from the selected chunk only.
	- Entries:
	    - All : Exports all entries.
		- Modified : Exports modified entries only.
		- Unmodified : Exports unmodified entries only.
	- End Script Specific Options :
	    - Export End Script for :
		    - Current Language Only : Exports an end script file only for the language you are working on.
		    - All languages : Exports an end script file for all the languages availabe in the same folder with the one you are working on.
		- Use add_or_update_string command: Uses the simpler command instead of creating an if statement.
- Save (Ctrl+S) : Saves the language file and labels file (optionally) you worked on.
    - (NOT YET IMPLEMENTED) Language File Version: 
	    - Old (Underground 1/2 & Most Wanted): Saves the language file with the chunk format from older BB Era NFS games.
	    - New (Carbon & Up): Saves the language file with the chunk format from newer BB Era NFS games.
	- Other Options:
	    - (NOT YET IMPLEMENTED) Include Histogram (Character Set): If checked, the language file will include the language histogram data (character set). It's enforced with the old language files as they always include their character set with the language chunks.
        - Also Save Labels File: If checked, labels will also be saved into their specific file when you are saving your language file. It's useful if you keep editing language files with new stuff.
        - Create Backups: If checked, Labrune will create a backup of the file you worked on, with a time stamp. (For example: English_Global.bin.20191105141233.labrunebackup)
- Restore Backups (Ctrl+R) : Lets you restore the backups which are in the same folder with the file you are working on. (Supported formats are: .bin_, .bak, .bin.bak, .BACC, .edbackup, .DATETIME.labrunebackup.)
- Exit (Alt+F4) : Closes the program. If there are any changes made, it prompts you to save the file before closing.

Edit:
- Add (Alt+A) : It opens a new window for you to add a new string entry. Fields in the window are described below.
    - Hash: A 4-byte number used by the game to access the specified string. It's filled automatically as you write the label, unless you've checked Use Custom Hash option, which allows you to edit the Hash manually.
    - Label: A name for the string, which gets hashed to a 4-byte number by the game to access the specified string. The hash gets updated as you write your label here. It's frozen if you've checked Use Custom Hash option, which allows you to edit the Hash manually.
    - Big text box: That's where you should enter your string as you want to see it in the game.
- Edit (Alt+E) : It opens a new window for you to edit the string you have selected from the list. Fields from Add option are also valid for this one. Alternatively, you can double-click the string you want to edit.
- Remove (Alt+R) : It removes the string you have selected from the list.
- Find (Ctrl+F) : It lets you find strings with specified text data, or hashes and labels.
    - Value to find: The text you want to find in strings.
    - Case sensitive: If you check this, it will only find the results in the case exactly as you write. (It won't find "tReE" if you wrote "Tree".)
    - Find also in hashes and labels: If you check this, hashes and labels are also included into the search.
- Find Previous (F3) : Goes to the next find result in backwards. Wraps around if you are at the first result.
- Find Next (F6) : Goes to the next find result. Wraps around if you are at the last result.
- Go to Previous Modified (F4) : Goes to the next modified string in backwards. Wraps around if you are at the first one.
- Go to Next Modified (F7) : Goes to the next modified string. Wraps around if you are at the last one.
- Font Settings (Alt+F) : Opens font settings window. It's applied to the string view on main screen.

Help:
- About Labrune (F1) : Opens About window.

-----------------------
# Credits:

Coded by:
- nlgxzef

Huge thanks to:
- @Berkayylmao: QoL improvements for the Find feature.
- nfsu360: NFS-LangEd. The tool is inspired from it.
- @LeoCodes21: their great help.
- @redbluescreen: WorldLangEdit & character decoding via language histogram.
- @Felipe379, Neon, RaTT and trackmaniamatt: testing.
- And the people who used my NFS-StrEd before, which is never released to public.

------------------------

See ya!
©2020-2023 nlgxzef @ ExOpts Team - No rights reserved. ;)
