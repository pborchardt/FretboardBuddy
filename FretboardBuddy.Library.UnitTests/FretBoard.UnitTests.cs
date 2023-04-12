using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FretboardBuddy.Library.UnitTests.FretBoardTests {

    public class FretBoardTest {

        public static FretBoard DefaultFretBoard() { 
            return new FretBoard(18, 4, new Dictionary<int, Note> { { 4, new Note("G", 4) }, { 3, new Note("C", 4) }, { 2, new Note("E", 4) }, { 1, new Note("A", 4) } });
        }

        [TestClass]
        public class Constructor {

            [TestMethod]
            public void Constructor_NormalRequest_ReturnsFretBoard() {
                var expectedNumOfFrets = 18;
                var expectedNumOfStrings = 4;

                var testFretBoard = new FretBoard(expectedNumOfFrets, expectedNumOfStrings, new Dictionary<int, Note> { {1, new Note("G", 4) }, { 2, new Note("C", 4) }, { 3, new Note("E", 4) }, { 4, new Note("A", 4) } });

                Assert.IsNotNull(testFretBoard);
            }

            [TestMethod]
            public void Constructor_NormalRequest_SetsFretboardNotesCorrectly() {
                var expectedNumOfFrets = 18;
                var expectedNumOfStrings = 4;
                var expectedNote = new Note("G", 4).GetNote();

                var testFretBoard = new FretBoard(expectedNumOfFrets, expectedNumOfStrings, new Dictionary<int, Note> { { 4, new Note("G", 4) }, { 3, new Note("C", 4) }, { 2, new Note("E", 4) }, { 1, new Note("A", 4) } });

                Assert.AreEqual(expectedNote, testFretBoard.GetStringNotes(4)[0].GetNote());
            }
        }

        [TestClass]
        public class TuneString{

            [TestMethod]
            public void TuneString_NormalRequest_PopulateFretboardWithNotes() {
                var testFretBoard = DefaultFretBoard();
                var currentFirstNote = testFretBoard.GetStringNotes(1)[0];

                testFretBoard.TuneString(1, new Note("C#", 4));

                Assert.AreNotEqual(testFretBoard.GetStringNotes(1)[0], currentFirstNote);
            }

            [DataRow(0)]
            [DataRow(-1)]
            [DataRow(5)]
            [DataTestMethod]
            public void TuneString_InvalidStringNumber_ThrowsException(int testInt) { 
                var testFretBoard = DefaultFretBoard();

                Assert.ThrowsException<ArgumentException>(() => { testFretBoard.TuneString(testInt, new Note("C", 4)); });
            }
        }

        [TestClass]
        public class GetStringNotes {

            [TestMethod]
            public void GetStringNotes_NormalRequest_ReturnNotes() {
                var testFretBoard = DefaultFretBoard();

                var testNotes = testFretBoard.GetStringNotes(1);

                Assert.IsNotNull(testNotes);
            }

            [DataRow(0)]
            [DataRow(-1)]
            [DataRow(5)]
            [DataTestMethod]
            public void GetStringNotes_InvalidStringNumber_ThrowsException(int testInt) {
                var testFretBoard = DefaultFretBoard();

                Assert.ThrowsException<ArgumentException>(() => { testFretBoard.GetStringNotes(testInt); });
            }
        }
    }
}