
using System.Text.RegularExpressions;

namespace FretboardBuddy.Library {

   

    public class Key {

        private static List<string> _keyTypes = new List<string>() { "MAJ", "MIN" };

        public static Dictionary<int,string> GetNotesInKey(string note, string type) {
            type = type.ToUpper();
            if (String.IsNullOrWhiteSpace(note)) { 
                throw new ArgumentException("Key: Given null or whitespace note.");
            }
            if (String.IsNullOrWhiteSpace(type)) {
                throw new ArgumentException("Key: Given null or whitespace scale type.");
            }
            if (Regex.IsMatch(note, @"^[A|B|C|D|E|F|G][b|#]?$") == false) {
                throw new ArgumentException($"Key: Given invalid note '{note}'.");
            }
            if (_keyTypes.Contains(type) == false) {
                throw new ArgumentException($"Key: Given invalid key type '{type}'.");
            }
            var results = new Dictionary<int, string>() { { 1, note } };
            var noteMath = new Note(note, 4);
            switch (type) {
                case "MAJ":
                    // 2: whole step
                    noteMath.PitchUp(2);
                    results[2] = noteMath.GetNote();
                    // 3: whole step
                    noteMath.PitchUp(2);
                    results[3] = noteMath.GetNote();
                    // 4: half step
                    noteMath.PitchUp(1);
                    results[4] = noteMath.GetNote();
                    // 5: whole step
                    noteMath.PitchUp(2);
                    results[5] = noteMath.GetNote();
                    // 6: whole step
                    noteMath.PitchUp(2);
                    results[6] = noteMath.GetNote();
                    // 7: whole step
                    noteMath.PitchUp(2);
                    results[7] = noteMath.GetNote();
                    break;
                case "MIN":
                    // 2: whole step
                    noteMath.PitchUp(2);
                    results[2] = noteMath.GetNote();
                    // 3: half step
                    noteMath.PitchUp(1);
                    results[3] = noteMath.GetNote();
                    // 4: whole step
                    noteMath.PitchUp(2);
                    results[4] = noteMath.GetNote();
                    // 5: whole step
                    noteMath.PitchUp(2);
                    results[5] = noteMath.GetNote();
                    // 6: half step
                    noteMath.PitchUp(1);
                    results[6] = noteMath.GetNote();
                    // 7: whole step
                    noteMath.PitchUp(2);
                    results[7] = noteMath.GetNote();
                    break;
            }
            return results;
        }


    }
}
