// See https://aka.ms/new-console-template for more information
using FretboardBuddy.Library;

var uke = new Ukulele(18, 4, new Dictionary<int, Note> { {4, new Note("G", 4) }, { 3, new Note("C", 4) }, { 2, new Note("E", 4) }, { 1, new Note("A", 4) }});
var defaultKey = "C";
var defaultKeyType = "MAJ";
var fretboardNotesInKey = uke.GetFretBoardForKey(defaultKey, defaultKeyType);
bool firstNote = true;
var tempString = "";
while (true) {

    for (var i=1; i <= 4; i++) {
        firstNote = true;
        foreach (var note in fretboardNotesInKey.GetStringNotes(i)) {
            if (firstNote) {
                if (note.Value.GetNote().Equals(Key.GetNotesInKey(defaultKey,defaultKeyType)[1])) {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (note.Value.GetNote().Equals(Key.GetNotesInKey(defaultKey, defaultKeyType)[2])) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (note.Value.GetNote().Equals(Key.GetNotesInKey(defaultKey, defaultKeyType)[3])) {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (note.Value.GetNote().Equals(Key.GetNotesInKey(defaultKey, defaultKeyType)[4])) {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else if (note.Value.GetNote().Equals(Key.GetNotesInKey(defaultKey, defaultKeyType)[5])) {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                } else if (note.Value.GetNote().Equals(Key.GetNotesInKey(defaultKey, defaultKeyType)[6])) {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.Write($"{note.Value.GetNote()}{note.Value.GetOctive()}");
                firstNote = false;
                Console.ResetColor();
            }
            else {
                if (note.Value != null) {
                    if (note.Value.GetNote().Equals(Key.GetNotesInKey(defaultKey, defaultKeyType)[1])) {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (note.Value.GetNote().Equals(Key.GetNotesInKey(defaultKey, defaultKeyType)[2])) {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (note.Value.GetNote().Equals(Key.GetNotesInKey(defaultKey, defaultKeyType)[3])) {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (note.Value.GetNote().Equals(Key.GetNotesInKey(defaultKey, defaultKeyType)[4])) {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (note.Value.GetNote().Equals(Key.GetNotesInKey(defaultKey, defaultKeyType)[5])) {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    else if (note.Value.GetNote().Equals(Key.GetNotesInKey(defaultKey, defaultKeyType)[6])) {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    tempString = $"--{note.Value.GetNote()}{note.Value.GetOctive()}"; 
                    tempString = tempString.PadRight(6, '-');
                    Console.Write(tempString);
                    Console.ResetColor();
                }
                else {
                   Console.Write("------");
                }
            }
            Console.Write("|");
        }
        Console.Write("\n");
    }
    break;
}
