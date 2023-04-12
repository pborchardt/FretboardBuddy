using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FretboardBuddy.Library.UnitTests.UkuleleTests {

    public class UkuleleTest {

        public static Ukulele DefaultUkulele() {
            return new Ukulele(18, 4, new Dictionary<int, Note> { {4, new Note("G", 4)}, {3, new Note("C",4) }, {2, new Note("E",4)}, {1, new Note("A",4)} });
        }

        [TestClass]
        public class Constructor {

            [TestMethod]
            public void Constructor_NormalRequest_ReturnUkulele() {
                var testUke = new Ukulele(18, 4, new Dictionary<int, Note> { { 1, new Note("G", 4) }, { 2, new Note("C", 4) }, { 3, new Note("E", 4) }, { 4, new Note("A", 4) } });
            
                Assert.IsNotNull(testUke);
            }

            [DataRow(0)]
            [DataRow(-1)]
            [DataTestMethod]
            public void Constructor_InvalidFretNum_ThrowsException(int testFrets) {
                Assert.ThrowsException<ArgumentException>(() => {
                    var testUke = new Ukulele(testFrets, 4, new Dictionary<int, Note> { { 1, new Note("G", 4) }, { 2, new Note("C", 4) }, { 3, new Note("E", 4) }, { 4, new Note("A", 4) } });
                });
            }


            [DataRow(0)]
            [DataRow(-1)]
            [DataTestMethod]
            public void Constructor_InvalidStringNum_ThrowsException(int testString) {
                Assert.ThrowsException<ArgumentException>(() => {
                    var testUke = new Ukulele(18, testString, new Dictionary<int, Note> { { 1, new Note("G", 4) }, { 2, new Note("C", 4) }, { 3, new Note("E", 4) }, { 4, new Note("A", 4) } });
                });
            }
        }

        [TestClass]
        public class GetStringNotes {

            [TestMethod]
            public void GetStringNotes_NormalRequest_ReturnNotes() {
                var testUke = DefaultUkulele();

                var testNotes = testUke.GetStringNotes(1);

                Assert.IsNotNull(testNotes);
            }

            [DataRow(0)]
            [DataRow(-1)]
            [DataRow(5)]
            [DataTestMethod]
            public void GetStringNotes_InvalidStringNumber_ThrowException(int testStringNum) {
                var testUke = DefaultUkulele();

                Assert.ThrowsException<ArgumentException>(() => { testUke.GetStringNotes(testStringNum); });
            }
        }

        [TestClass]
        public class GetStringNotesForKey {

            [TestMethod]
            public void GetStringNotesForKey_NormalRequest_ReturnNotes() {
                var testUke = DefaultUkulele();
                var expectedNote = new Note("A", 4).GetNote();

                var stringNotes = testUke.GetStringNotesForKey(4,"C", "MAJ");
                var actualNote = stringNotes[2].GetNote();

                Assert.AreEqual(expectedNote, actualNote);
            }
        }

        [TestClass]
        public class GetFretBoard {

            [TestMethod]
            public void GetFretBoard_NormalRequest_ReturnFretBoard() {
                var testUke = DefaultUkulele();

                var testFretBoard = testUke.GetFretBoard();

                Assert.IsNotNull(testFretBoard);    
            }
        }

        [TestClass]
        public class GetFretBoardForKey {

            [TestMethod]
            public void GetFretBoardForKey_NormalRequest_ReturnPopulatedFretBoard() {
                var testUke = DefaultUkulele();
                var expectedNote = new Note("A", 4).GetNote();

                var fretBoardNotes = testUke.GetFretBoardForKey("C", "MAJ");
                var actualNote = fretBoardNotes.GetStringNotes(4)[2].GetNote();
            
                Assert.AreEqual(expectedNote,actualNote);
            }
        }

        [TestClass]
        public class GetTuning { 

            [TestMethod]
            public void GetTuning_NormalRequest_ReturnTuning() {
                var testUke = DefaultUkulele();

                var testTuning = testUke.GetTuning();

                Assert.IsNotNull(testTuning);
            }
        }

        [TestClass]
        public class SetTuning {

            [TestMethod]
            public void SetTuning_NormalRequest_SetTuning() {
                var testUke = DefaultUkulele();
                var testTuning = testUke.GetTuning();

                testUke.SetTuning(new Dictionary<int, Note> { { 1, new Note("G", 3) }, { 2, new Note("C", 4) }, { 3, new Note("E", 4) }, { 4, new Note("A", 4) } });
                var actualTuning = testUke.GetTuning();

                Assert.AreNotEqual(testTuning[1], actualTuning[1]);
            }

            [TestMethod]
            public void SetTuning_TooFewNotes_ThrowsException() {
                var testUke = DefaultUkulele();
                var testTuning = testUke.GetTuning();

                Assert.ThrowsException<ArgumentException>(() => {
                    testUke.SetTuning(new Dictionary<int, Note> { { 1, new Note("G", 3) }, { 2, new Note("C", 4) }, { 3, new Note("E", 4) } });
                });
            }

            [TestMethod]
            public void SetTuning_TooManyNotes_ThrowsException() {
                var testUke = DefaultUkulele();
                var testTuning = testUke.GetTuning();

                Assert.ThrowsException<ArgumentException>(() => {
                    testUke.SetTuning(new Dictionary<int, Note> { { 1, new Note("G", 3) }, { 2, new Note("C", 4) }, { 3, new Note("E", 4) }, { 4, new Note("F", 4) }, { 5, new Note("G", 4) } });
                });
            }
        }
    }
}