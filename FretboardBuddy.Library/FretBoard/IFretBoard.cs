using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FretboardBuddy.Library {
    public interface IFretBoard {
        public Dictionary<int, INote> GetStringNotes(int stringNumber);

        public void TuneString(int stringNumber, INote note);
    }
}
