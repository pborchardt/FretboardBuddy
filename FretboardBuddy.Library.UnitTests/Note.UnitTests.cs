using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FretboardBuddy.Library.UnitTests.NoteTests {

    public class NoteTest {

        public static Note DefaultNote() {
            return new Note("C", 4);
        }

        [TestClass]
        public class Constructor {

            [TestMethod]
            public void Constructor_NormalRequest_ReturnNote() {
                var testNote = new Note("C", 4);

                Assert.IsNotNull(testNote);
            }

            [DataRow("")]
            [DataRow(" ")]
            [DataRow("\t")]
            [DataRow("\n")]
            [DataRow("bC")]
            [DataRow("H")]
            [DataTestMethod]
            public void Constructor_InvalidNote_ThrowsException(string testString) {
                Assert.ThrowsException<ArgumentException>(() => { var testNote = new Note(testString, 4); });
            }

            [DataRow(0)]
            [DataRow(-1)]
            [DataTestMethod]
            public void Constructor_InvalidOctive_ThrowsException(int testInt) {
                Assert.ThrowsException<ArgumentException>(() => { var testNote = new Note("C", testInt); });
            }
        }

        [TestClass]
        public class GetNote {

            [TestMethod]
            public void GetNote_NormalRequest_ReturnsNote() { 
                var testNote = DefaultNote();

                var note = testNote.GetNote();

                Assert.IsNotNull(note);
            }
        }

        [TestClass]
        public class GetOctive {

            [TestMethod]
            public void GetOctive_NormalRequest_ReturnOctive() {
                var testNote = DefaultNote();

                var testOctive = testNote.GetOctive();

                Assert.IsNotNull(testOctive);
            }
        }

        [TestClass]
        public class PitchDown {

            [DataRow("C#", 1, "C")]
            [DataRow("E", 2, "D")]
            [DataRow("E", 12, "E")]
            [DataTestMethod]
            public void PitchDown_NormalRequest_SetsNewNote(string originalNote, int pitchChangeAmount, string expectedNote) {
                var testNote = DefaultNote();
                testNote.SetNote(originalNote);

                testNote.PitchDown(pitchChangeAmount);

                Assert.AreEqual(expectedNote, testNote.GetNote());
            }

            [TestMethod]
            public void PitchDown_RequestPutsOctiveOutOfRange_ThrowsException() {
                var testNote = DefaultNote();

                Assert.ThrowsException<ArgumentException>(() => { testNote.PitchDown(1000); });
            }

            [DataRow(0)]
            [DataRow(-1)]
            [DataTestMethod]
            public void PitchDown_InvalidPitchAmount_ThrowsException(int testInt) {
                var testNote = DefaultNote();

                Assert.ThrowsException<ArgumentException>(() => { testNote.PitchDown(testInt); });
            }
        }

        [TestClass]
        public class PitchUp {

            [DataRow("C", 1, "C#")]
            [DataRow("D", 2, "E")]
            [DataRow("E", 12, "E")]
            [DataTestMethod]
            public void PitchUp_NormalRequest_SetsNewNote(string originalNote, int pitchChangeAmount, string newExpectedNote) {
                var testNote = DefaultNote();
                testNote.SetNote(originalNote);

                testNote.PitchUp(pitchChangeAmount);

                Assert.AreEqual(newExpectedNote, testNote.GetNote());
            }

            [DataRow(0)]
            [DataRow(-1)]
            [DataTestMethod]
            public void PitchUp_InvalidPitchAmount_ThrowsException(int testInt) {
                var testNote = DefaultNote();

                Assert.ThrowsException<ArgumentException>(() => { testNote.PitchUp(testInt); });
            }
        }

        [TestClass]
        public class SetNote {

            [TestMethod]
            public void SetNote_NormalRequest_SetsNote() {
                var testNote = DefaultNote();
                var note = testNote.GetNote();

                testNote.SetNote("D");

                Assert.AreNotEqual(testNote.GetNote(), note);
            }

            [DataRow("")]
            [DataRow(" ")]
            [DataRow("\t")]
            [DataRow("\n")]
            [DataRow("H")]
            [DataTestMethod]
            public void SetNote_InvalidNote_ThrowsException(string testString) {
                var testNote = DefaultNote();

                Assert.ThrowsException<ArgumentException>(() => {
                    testNote.SetNote(testString);
                });
            }
        }


        [TestClass]
        public class SetOctive {
            
            [TestMethod]
            public void SetOctive_NormalRequest_SetsOctive() {
                var testNote = DefaultNote();
                var testOctive = testNote.GetOctive();

                testNote.SetOctive(5);

                Assert.AreNotEqual(testNote.GetOctive(), testOctive);
            }

            [DataRow(0)]
            [DataRow(-1)]
            [DataTestMethod]
            public void GetOctive_InvalidOctive_ThrowsException(int testOctive) {
                var testNote = DefaultNote();

                Assert.ThrowsException<ArgumentException>(() => { testNote.SetOctive(testOctive  ); });
            }
        }
    }
}