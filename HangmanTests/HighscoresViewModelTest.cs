/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using GalaSoft.MvvmLight.Messaging;
using HangmanModels;
using HangmanViewModels;
using HangmanViewModels.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HangmanTests
{
    [TestClass]
    public class HighscoresViewModelTest
    {
        [TestMethod]
        public void HighscoresViewModelSim()
        {
            Messenger.Default.Register<ConfirmationMessage>(this, this.IncomingConfirmation);

            Language englishLanguage = new Language("English", "en-US", Alphabet.EnglishAlphabet);
            Language greekLanguage = new Language("Greek", "el-GR", Alphabet.GreekAlphabet);

            HighscoresViewModel hvm = new HighscoresViewModel(englishLanguage, highscoresDataService: new MockData.HighscoresDataService());
            Assert.IsTrue(hvm.CurrentLanguage.Name == "English");
            Assert.IsTrue(hvm.CurrentHighscore == null);
            Assert.IsTrue(hvm.TenWordHighscores.Count == 10);
            Assert.IsTrue(hvm.TenWordHighscores[0].Name == "Helen" && hvm.TenWordHighscores[0].Score == 507);
            Assert.IsTrue(hvm.TimedHighscores.Count == 5);
            Assert.IsTrue(hvm.TimedHighscores[0].Name == "Dorothy" && hvm.TimedHighscores[0].Score == 830);
            Assert.IsTrue(hvm.InfiniteHighscores.Count == 5);
            Assert.IsTrue(hvm.InfiniteHighscores[0].Name == "Helen" && hvm.InfiniteHighscores[0].Score == 800);

            Highscore newHighscore = new Highscore()
            { Id = 26, Name = "Jason", Score = 666, GameMode = GameMode.TenWord, Date = new DateTime(2017, 12, 25), TotalWords = 10 };

            HighscoresViewModel hvmSave = new HighscoresViewModel(englishLanguage, newHighscore, new MockData.HighscoresDataService());
            hvmSave.SaveHighScoreCommand.Execute(hvmSave);
            Assert.IsTrue(hvmSave.TenWordHighscores.Count == 10);
            Assert.IsTrue(hvmSave.TenWordHighscores[0].Name == "Jason" && hvmSave.TenWordHighscores[0].Score == 666);
            hvmSave.HighscorePaging = HighscorePaging.Twenty;
            Assert.IsTrue(hvmSave.TenWordHighscores.Count == 20);
            hvmSave.HighscorePaging = HighscorePaging.None;
            Assert.IsTrue(hvmSave.TenWordHighscores.Count == 26);
            hvmSave.ResetHighscoresCommand.Execute(hvmSave);
            Assert.IsTrue(hvmSave.TenWordHighscores.Count == 0);
        }

        private void IncomingConfirmation(ConfirmationMessage msg)
        {
            msg.Execute(true);
        }
    }
}
