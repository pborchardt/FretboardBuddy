using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FretboardBuddy.Library.UnitTests.KeyTests {
    public class KeyTest {

        [TestClass]
        public class GetNotesInKey {


            [DataRow("C", "MAJ", "D")]
            [DataRow("A", "min", "B")]
            [DataTestMethod]
            public void GetNotesInKey_NormalRequest_ReturnsNotes(string rootNote, string scaleType, string expectedNote) {
                Assert.AreEqual(expectedNote, Key.GetNotesInKey(rootNote, scaleType)[2]);
            }

            [DataRow("")]
            [DataRow(" ")]
            [DataRow("\t")]
            [DataRow("\n")]
            [DataRow("H")]
            [DataTestMethod]
            public void GetNotesInKey_InvalidNote_ThrowsException(string testString) {
                Assert.ThrowsException<ArgumentException>(() => { Key.GetNotesInKey(testString, "MAJ"); });
            }

            [DataRow("")]
            [DataRow(" ")]
            [DataRow("\t")]
            [DataRow("\n")]
            [DataRow("H")]
            [DataTestMethod]
            public void GetNotesInKey_InvalidKeyType_ThrowsException(string testString) {
                Assert.ThrowsException<ArgumentException>(() => { Key.GetNotesInKey("C", testString); });
            }
        }
    }
}