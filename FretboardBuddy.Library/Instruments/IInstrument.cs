
namespace FretboardBuddy.Library {
    public interface IInstrument {

        public Dictionary<int, INote> GetStringNotes(int stringNumber);

        public Dictionary<int, INote> GetStringNotesForKey(int stringNumber, string note, string keyType);

        public FretBoard GetFretBoard();

        public FretBoard GetFretBoardForKey(string key, string keyType);

        public Dictionary<int, INote> GetTuning();

        public void SetTuning(Dictionary<int,Note> tuning);
    }
}
