
namespace FretboardBuddy.Library {
    public interface INote {

        public void PitchUp(int simiToneAmount);

        public void PitchDown(int simiToneAmount);

        public int GetOctive();
        public string GetNote();

        public void SetNote(string note);
        public void SetOctive(int octive);
    }
}
