
using System.Diagnostics;

namespace FretboardBuddy.Library {
    public class Ukulele : IInstrument {

        private FretBoard _fretBoard;
        private int _fretNum;
        private int _stringNum;

        public Ukulele(int fretNum, int stringNum, Dictionary<int, Note> defaultTuning) {
            if (fretNum < 1) {
                throw new ArgumentException($"Ukulele: Invalid fretNum '{fretNum}'.");
            }
            if (stringNum < 1) {
                throw new ArgumentException($"Ukulele: Invalid stringNum '{stringNum}'.");
            }

            _fretNum = fretNum;
            _stringNum = stringNum;
            _fretBoard = new FretBoard(fretNum, stringNum, defaultTuning);
        }

        public FretBoard GetFretBoard() {
            return _fretBoard;
        }

        public FretBoard GetFretBoardForKey(string key, string keyType) {
            var keyNotes = Key.GetNotesInKey(key, keyType);
            Dictionary<int, Dictionary<int, INote?>> results = new Dictionary<int, Dictionary<int, INote?>>();
            Dictionary<int, INote?> notes;
            for (int i = 1; i <= _stringNum; i++) {
                notes = new Dictionary<int, INote?>();
                for (int j = 0; j < _fretNum; j++) {
                    if (keyNotes.ContainsValue(_fretBoard.GetStringNotes(i)[j].GetNote())) {
                        notes[j] = new Note(_fretBoard.GetStringNotes(i)[j].GetNote(), _fretBoard.GetStringNotes(i)[j].GetOctive());
                    } else {
                        notes[j] = null;
                    }
                }
                results.Add(i, notes);
            }
            return new FretBoard(_fretNum, _stringNum, results);
        }

        public Dictionary<int, INote> GetStringNotes(int stringNumber) {
            if ((stringNumber < 1) || (stringNumber > _stringNum)) {
                throw new ArgumentException($"Ukulele: Given invalid string number '{stringNumber}'.");
            }
            return _fretBoard.GetStringNotes(stringNumber);
        }

        public Dictionary<int, INote> GetStringNotesForKey(int stringNumber, string note, string keyType) {
            var keyNotes = Key.GetNotesInKey(note, keyType);
            Dictionary<int, INote> results = new Dictionary<int, INote>();
            for (int i = 0; i < _fretNum; i++) {
                if (keyNotes.ContainsValue(_fretBoard.GetStringNotes(stringNumber)[i].GetNote())) {
                    results[i] = _fretBoard.GetStringNotes(stringNumber)[i];
                }
                else {
                    results[i] = null;
                }
            }
            return results;
        }

        public Dictionary<int, INote> GetTuning() {
            var results = new Dictionary<int, INote> { };
            for (int i = 1; i < _stringNum; i++) {
                results[i] = _fretBoard.GetStringNotes(i)[0];
            }
            return results;
        }

        public void SetTuning(Dictionary<int, Note> tuning) {
            if (tuning.Count != _stringNum) {
                throw new ArgumentException("Given invalid amount notes for tuning.");
            }
            foreach (var note in tuning) {
                _fretBoard.TuneString(note.Key, note.Value);
            }
        }
    }
}
