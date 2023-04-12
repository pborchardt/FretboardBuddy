
namespace FretboardBuddy.Library {
    public class FretBoard: IFretBoard {

        private int _fretNum;
        private int _stringNum;

        private Dictionary<int, Dictionary<int,INote?>> _fretBoard = new ();   
        
        public FretBoard(int fretNum, int stringNum, Dictionary<int, Note> defaultTuning) {
            if (fretNum < 1) {
                throw new ArgumentException($"FretBoard: Invalid fretNum '{fretNum}'.");
            }
            if (stringNum < 1) {
                throw new ArgumentException($"FretBoard: Invalid stringNum '{stringNum}'.");
            }


            _fretNum = fretNum;
            _stringNum = stringNum;

            Note tempNote;
            for (int i = 1; i <= stringNum; i++) {
                _fretBoard[i] = new Dictionary<int, INote?>();
                _fretBoard[i][0] = defaultTuning[i];
                tempNote = new Note(defaultTuning[i].GetNote(), defaultTuning[i].GetOctive());
                for (int j = 1; j <= fretNum; j++) {
                    tempNote.PitchUp(1);
                    _fretBoard[i][j] = new Note(tempNote.GetNote(), tempNote.GetOctive());
                }
            }

        }

        public FretBoard(int fretNum, int stringNum, Dictionary<int,Dictionary<int, INote?>> freboard) {
            if (fretNum < 1) {
                throw new ArgumentException($"FretBoard: Invalid fretNum '{fretNum}'.");
            }
            if (stringNum < 1) {
                throw new ArgumentException($"FretBoard: Invalid stringNum '{stringNum}'.");
            }

            _fretNum = fretNum;
            _stringNum = stringNum;
            _fretBoard = freboard;
        }

        public Dictionary<int, INote> GetStringNotes(int stringNumber) {
            if ((stringNumber < 1) || (stringNumber > _stringNum)) {
                throw new ArgumentException($"FretBoard: Given invalid string number '{stringNumber}'.");
            }
            return _fretBoard[stringNumber];
        }

        public void TuneString(int stringNumber, INote note) {
            if ((stringNumber < 1) || (stringNumber > _stringNum)) {
                throw new ArgumentException($"FretBoard: Given invalid string number '{stringNumber}'.");
            }
            for (int i = 0; i < _fretNum; i++) {
                _fretBoard[stringNumber][i] = note;
            }
        }
    }
}
