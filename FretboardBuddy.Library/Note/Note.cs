

using System.Text.RegularExpressions;

namespace FretboardBuddy.Library {
    public class Note : INote {

        private string _note;
        private int _octive;

        private Dictionary<string, string> _noteTranslation = new Dictionary<string, string>{
            { "Db", "C#"},
            { "Eb", "D#"},
            { "E#", "F"},
            { "Gb", "F#"},
            { "Ab", "G#"},
            { "Bb", "A#"},
            { "B#", "C"}
        };
        private Dictionary<int, string> _chromaticOrder = new Dictionary<int,string>() {
            {1, "C" },
            {2, "C#" },
            {3, "D" },
            {4, "D#" },
            {5, "E" },
            {6, "F" },
            {7, "F#" },
            {8, "G" },
            {9, "G#" },
            {10, "A" },
            {11, "A#" },
            {12, "B" }
        };


        public Note(string note, int octive) { 
            SetNote(note);
            SetOctive(octive);

        }

        public string GetNote() {
            return _note;
        }

        public int GetOctive() {
            return _octive;
        }

        public void PitchDown(int simiToneAmount) {
            if (simiToneAmount < 1) {
                throw new ArgumentException($"Note: Given invalid simiToneAmount '{simiToneAmount}'.");
            }
            var tempNote = _note;
            if (_noteTranslation.ContainsKey(tempNote)) {
                tempNote = _noteTranslation[tempNote];
            }
            while (simiToneAmount >= 12) {
                _octive--;
                simiToneAmount -= 12;
            }
            var noteNumber = 0;
            foreach (var note in _chromaticOrder) {
                if (note.Value.Equals(tempNote)) {
                    noteNumber = note.Key;
                    break;
                }
            }
            noteNumber = noteNumber - simiToneAmount;
            if (noteNumber < 1) {
                _octive--;
                noteNumber = noteNumber + 12;
            }
            if (_octive < 1) {
                throw new ArgumentException($"Note: Simi Tone amount puts note out of range.");
            }
            _note = _chromaticOrder[noteNumber];
        }

        public void PitchUp(int simiToneAmount) {
            if (simiToneAmount < 1) {
                throw new ArgumentException($"Note: Given invalid simiToneAmount '{simiToneAmount}'.");
            }
            var tempNote = _note;
            if (_noteTranslation.ContainsKey(tempNote)) {
                tempNote = _noteTranslation[tempNote];
            }
            while (simiToneAmount >= 12) { 
                _octive++;
                simiToneAmount -= 12;
            }
            var noteNumber = 0;
            foreach (var note in _chromaticOrder){
                if (note.Value.Equals(tempNote)) {
                    noteNumber = note.Key;
                    break;
                }
            }
            noteNumber = noteNumber + simiToneAmount;
            if (noteNumber > 12) {
                _octive++;
                noteNumber = noteNumber - 12;
            }
            _note = _chromaticOrder[noteNumber];
        }

        public void SetNote(string note) {
            if (String.IsNullOrWhiteSpace(note)) {
                throw new ArgumentException("Note: Given null or whitespace note.");
            }
            if (Regex.IsMatch(note, @"^[A|B|C|D|E|F|G][b|#]?$")) {
                _note = note;
                return;
            }
            throw new ArgumentException($"Note: Given invalid note '{note}'.");
        }

        public void SetOctive(int octive) {
            if (octive < 1) {
                throw new ArgumentException($"Note: Given invalid octive '{octive}'.");
            }
            _octive = octive;
        }
    }
}
