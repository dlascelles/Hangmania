/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanModels;

namespace HangmanTests
{
    [TestClass]
    public class GameInfiniteTest
    {
        public static Random rnd = new Random();
        private static bool isWordFound = false;
        private static bool isWordNotFound = false;

        [TestMethod]
        public void GameInfinitePlay()
        {
            GameInfinite currentGameEnglish = new GameInfinite(Alphabet.EnglishAlphabet);
            Assert.IsTrue(currentGameEnglish.GameMode == GameMode.Infinite);
            currentGameEnglish.RequestNewWord += this.CurrentGameEnglish_RequestNewWord;
            currentGameEnglish.GameStart();
            int previousScore = currentGameEnglish.Score;
            Assert.IsFalse(currentGameEnglish.TryLetter("B"));
            Assert.IsTrue(currentGameEnglish.TotalTriesPerWordRemaining == Game.MaxTriesPerWord - 1);
            Assert.IsTrue(currentGameEnglish.Score == previousScore - Game.LetterNotFoundPoints);
            previousScore = currentGameEnglish.Score;
            try { currentGameEnglish.TryLetter("B"); Assert.Fail(); } catch (ArgumentException) { }
            try { currentGameEnglish.TryLetter("Γ"); Assert.Fail(); } catch (ArgumentException) { }
            try { currentGameEnglish.TryLetter(null); Assert.Fail(); } catch (ArgumentException) { }
            Assert.IsTrue(currentGameEnglish.TryLetter("A"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.LetterFoundPoints);
            previousScore = currentGameEnglish.Score;
            Assert.IsTrue(currentGameEnglish.TryLetter("C"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.LetterFoundPoints);
            previousScore = currentGameEnglish.Score;
            Assert.IsTrue(currentGameEnglish.TryLetter("O"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.LetterFoundPoints);
            previousScore = currentGameEnglish.Score;
            Assert.IsFalse(currentGameEnglish.TryLetter("P"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore - Game.LetterNotFoundPoints);           
            Assert.IsTrue(currentGameEnglish.TotalTriesPerWordRemaining == Game.MaxTriesPerWord - 2);
            previousScore = currentGameEnglish.Score;
            int currentPercent = currentGameEnglish.GetWordPercentRemaining();
            Assert.IsTrue(currentPercent == 56);
            Assert.IsTrue(currentGameEnglish.TryWord("ACCORDING"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.WordFoundPoints + currentPercent);
            previousScore = currentGameEnglish.Score;
            Assert.IsTrue(currentGameEnglish.CurrentWord.Text == "ACCOUNT");
            Assert.IsTrue(currentGameEnglish.TotalTriesPerWordRemaining == Game.MaxTriesPerWord);
            currentPercent = currentGameEnglish.GetWordPercentRemaining();
            Assert.IsTrue(currentGameEnglish.TryWord("ACCOUNT"));
            Assert.IsTrue(currentGameEnglish.TotalWords == 2);
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.WordFoundPoints + currentPercent);
            previousScore = currentGameEnglish.Score;
            currentPercent = currentGameEnglish.GetWordPercentRemaining();
            Assert.IsTrue(currentGameEnglish.TryWord("ACROSS"));
            Assert.IsTrue(currentGameEnglish.TotalWords == 3);
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.WordFoundPoints + currentPercent);
            previousScore = currentGameEnglish.Score;
            currentPercent = currentGameEnglish.GetWordPercentRemaining();
            Assert.IsTrue(currentGameEnglish.TryWord("ACT"));
            Assert.IsTrue(currentGameEnglish.TotalWords == 4);
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.WordFoundPoints + currentPercent);
            previousScore = currentGameEnglish.Score;
            currentPercent = currentGameEnglish.GetWordPercentRemaining();
            Assert.IsTrue(currentGameEnglish.TryWord("ACTION"));
            Assert.IsTrue(currentGameEnglish.TotalWords == 5);
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.WordFoundPoints + currentPercent);
            previousScore = currentGameEnglish.Score;
            currentPercent = currentGameEnglish.GetWordPercentRemaining();
            Assert.IsTrue(currentGameEnglish.TryWord("ACTIVITY"));
            Assert.IsTrue(currentGameEnglish.TotalWords == 6);
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.WordFoundPoints + currentPercent);
            previousScore = currentGameEnglish.Score;
            currentPercent = currentGameEnglish.GetWordPercentRemaining();
            Assert.IsTrue(currentGameEnglish.TryWord("ACTUALLY"));
            Assert.IsTrue(currentGameEnglish.TotalWords == 7);
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.WordFoundPoints + currentPercent);
            previousScore = currentGameEnglish.Score;
            currentPercent = currentGameEnglish.GetWordPercentRemaining();
            Assert.IsTrue(currentGameEnglish.TryWord("ADD"));
            Assert.IsTrue(currentGameEnglish.TotalWords == 8);
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.WordFoundPoints + currentPercent);
            previousScore = currentGameEnglish.Score;
            currentPercent = currentGameEnglish.GetWordPercentRemaining();
            Assert.IsTrue(currentGameEnglish.TryWord("ADDRESS"));
            Assert.IsTrue(currentGameEnglish.TotalWords == 9);
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.WordFoundPoints + currentPercent);
            previousScore = currentGameEnglish.Score;
            Assert.IsTrue(currentGameEnglish.TryLetter("A"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.LetterFoundPoints);
            previousScore = currentGameEnglish.Score;
            Assert.IsTrue(currentGameEnglish.TryLetter("D"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.LetterFoundPoints);
            previousScore = currentGameEnglish.Score;
            currentPercent = currentGameEnglish.GetWordPercentRemaining();
            Assert.IsFalse(currentGameEnglish.TryLetter("Z"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore - Game.LetterNotFoundPoints);
            previousScore = currentGameEnglish.Score;
            currentPercent = currentGameEnglish.GetWordPercentRemaining();
            Assert.IsTrue(currentPercent == 79);
            Assert.IsTrue(currentGameEnglish.TryLetter("M"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.LetterFoundPoints);
            previousScore = currentGameEnglish.Score;
            Assert.IsTrue(currentGameEnglish.TryLetter("I"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.LetterFoundPoints);
            previousScore = currentGameEnglish.Score;
            currentPercent = currentGameEnglish.GetWordPercentRemaining();
            Assert.IsTrue(currentPercent == 50);
            Assert.IsTrue(currentGameEnglish.TryWord("ADMINISTRATION"));
            Assert.IsTrue(currentGameEnglish.TotalWords == 10);
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.WordFoundPoints + currentPercent);
            //BROTHER
            previousScore = currentGameEnglish.Score;
            Assert.IsFalse(currentGameEnglish.TryLetter("A"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore - Game.LetterNotFoundPoints);
            Assert.IsTrue(currentGameEnglish.TotalTriesPerWordRemaining == Game.MaxTriesPerWord - 1);
            previousScore = currentGameEnglish.Score;
            Assert.IsFalse(currentGameEnglish.TryLetter("Z"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore - Game.LetterNotFoundPoints);
            Assert.IsTrue(currentGameEnglish.TotalTriesPerWordRemaining == Game.MaxTriesPerWord - 2);
            previousScore = currentGameEnglish.Score;
            Assert.IsTrue(currentGameEnglish.TryLetter("B"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.LetterFoundPoints);
            Assert.IsTrue(currentGameEnglish.TotalTriesPerWordRemaining == Game.MaxTriesPerWord - 2);
            previousScore = currentGameEnglish.Score;
            Assert.IsTrue(currentGameEnglish.TryLetter("R"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.LetterFoundPoints);
            Assert.IsTrue(currentGameEnglish.TotalTriesPerWordRemaining == Game.MaxTriesPerWord - 2);
            previousScore = currentGameEnglish.Score;
            Assert.IsTrue(currentGameEnglish.TryLetter("O"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore + Game.LetterFoundPoints);
            Assert.IsTrue(currentGameEnglish.TotalTriesPerWordRemaining == Game.MaxTriesPerWord - 2);
            previousScore = currentGameEnglish.Score;
            Assert.IsFalse(currentGameEnglish.TryLetter("V"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore - Game.LetterNotFoundPoints);
            Assert.IsTrue(currentGameEnglish.TotalTriesPerWordRemaining == Game.MaxTriesPerWord - 3);
            previousScore = currentGameEnglish.Score;
            Assert.IsFalse(currentGameEnglish.TryLetter("Q"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore - Game.LetterNotFoundPoints);
            Assert.IsTrue(currentGameEnglish.TotalTriesPerWordRemaining == Game.MaxTriesPerWord - 4);
            previousScore = currentGameEnglish.Score;
            Assert.IsFalse(currentGameEnglish.TryLetter("W"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore - Game.LetterNotFoundPoints);
            Assert.IsTrue(currentGameEnglish.TotalTriesPerWordRemaining == Game.MaxTriesPerWord - 5);
            previousScore = currentGameEnglish.Score;
            Assert.IsFalse(currentGameEnglish.TryLetter("Y"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore - Game.LetterNotFoundPoints);
            Assert.IsTrue(currentGameEnglish.TotalTriesPerWordRemaining == Game.MaxTriesPerWord - 6);
            previousScore = currentGameEnglish.Score;
            Assert.IsFalse(currentGameEnglish.TryLetter("I"));
            Assert.IsTrue(currentGameEnglish.Score == previousScore - Game.LetterNotFoundPoints - Game.WordNotFoundPoints);
            Assert.IsTrue(currentGameEnglish.TotalTriesPerWordRemaining == Game.MaxTriesPerWord);
            Assert.IsFalse(currentGameEnglish.Started);
        }

        private void CurrentGameEnglish_RequestNewWord(object sender, EventArgs e)
        {
            //"ACCORDING","ACCOUNT","ACROSS","ACT","ACTION","ACTIVITY","ACTUALLY","ADD","ADDRESS","ADMINISTRATION","BROTHER"
            ((GameInfinite)(sender)).CurrentWord = new Word() { Id = 1, Text = MockData.EnglishWordList[((GameInfinite)(sender)).TotalWords] };
        }

        [TestMethod]
        public void GameInfinitePlayRandom()
        {
            for (int g = 0; g < 10000; g++)
            {
                GameInfinite currentGameEnglishRandom = new GameInfinite(Alphabet.EnglishAlphabet);
                currentGameEnglishRandom.RequestNewWord += this.CurrentGameEnglishRandom_RequestNewWord;
                currentGameEnglishRandom.WordFound += this.CurrentGameEnglishRandom_WordFound;
                currentGameEnglishRandom.WordNotFound += this.CurrentGameEnglishRandom_WordNotFound;
                currentGameEnglishRandom.GameStart();
                Assert.IsTrue(currentGameEnglishRandom.TotalWords == 0);
                Assert.IsTrue(currentGameEnglishRandom.Score == 0);
                Assert.IsTrue(currentGameEnglishRandom.CurrentWord != null);
                Assert.IsTrue(currentGameEnglishRandom.Started);
                Assert.IsTrue(currentGameEnglishRandom.GameMode == GameMode.Infinite);

                while (currentGameEnglishRandom.Started)
                {                    
                    int previousScore = currentGameEnglishRandom.Score;
                    int previousMaxTriesLeft = currentGameEnglishRandom.TotalTriesPerWordRemaining;
                    bool foundLetter = currentGameEnglishRandom.TryLetter(MockData.GetRandomEnglishAvailableLetter(currentGameEnglishRandom.Letters, rnd));
                    if (foundLetter)
                    {
                        if (!isWordFound)
                        {
                            Assert.IsTrue(currentGameEnglishRandom.Score == previousScore + Game.LetterFoundPoints);
                            Assert.IsTrue(previousMaxTriesLeft == currentGameEnglishRandom.TotalTriesPerWordRemaining);
                        }
                        else
                        {
                            Assert.IsTrue(currentGameEnglishRandom.Score == previousScore + Game.LetterFoundPoints + Game.WordFoundPoints);
                            Assert.IsTrue(currentGameEnglishRandom.TotalTriesPerWordRemaining == Game.MaxTriesPerWord);
                        }
                    }
                    else
                    {
                        if (!isWordNotFound)
                        {
                            Assert.IsTrue(currentGameEnglishRandom.Score == previousScore - Game.LetterNotFoundPoints);
                            Assert.IsTrue(previousMaxTriesLeft == currentGameEnglishRandom.TotalTriesPerWordRemaining + 1);
                        }
                        else
                        {
                            Assert.IsTrue(currentGameEnglishRandom.Score == previousScore - Game.LetterNotFoundPoints - Game.WordNotFoundPoints);
                            Assert.IsTrue(currentGameEnglishRandom.TotalTriesPerWordRemaining == Game.MaxTriesPerWord);
                        }
                    }
                    isWordNotFound = false;
                    isWordFound = false;
                }
            }
        }

        private void CurrentGameEnglishRandom_WordNotFound(object sender, string e)
        {
            isWordNotFound = true;
        }

        private void CurrentGameEnglishRandom_WordFound(object sender, string e)
        {
            isWordFound = true;
        }

        private void CurrentGameEnglishRandom_RequestNewWord(object sender, EventArgs e)
        {
            ((GameInfinite)(sender)).CurrentWord = new Word() { Id = 1, Text = MockData.GetRandomEnglishWord(rnd) };
        }        
    }
}
