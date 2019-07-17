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

namespace HangmanTests
{
    [TestClass]
    public class MainViewModelTest
    {
        private HighscoresViewModel highscoresViewmodel;
        private bool isLetterFound = false;
        private bool isLetterNotFound = false;

        [TestMethod]
        public void MainViewModelSim()
        {
            Messenger.Default.Register<ShowHighscoresMessage>(this, this.ShowHighscores);
            Messenger.Default.Register<LetterFoundMessage>(this, this.LetterFound);
            Messenger.Default.Register<LetterNotFoundMessage>(this, this.LetterNotFound);          

            MainViewModel mainViewModel = new MainViewModel(new MockData.WordDataService());
            Assert.IsTrue(mainViewModel.CurrentLanguage.Name == "English");
            Assert.IsTrue(mainViewModel.StartGameCommand != null);
            Assert.IsTrue(mainViewModel.CancelGameCommand != null);
            Assert.IsTrue(mainViewModel.TryLetterCommand != null);
            Assert.IsTrue(mainViewModel.TryWordCommand != null);
            Assert.IsTrue(mainViewModel.ShowHighscoresCommand != null);
            Assert.IsTrue(mainViewModel.ChangeLanguageCommand != null);
            Assert.IsFalse(mainViewModel.CurrentGame.Started);
            mainViewModel.StartGameCommand.Execute(mainViewModel);
            Assert.IsTrue(mainViewModel.CurrentGame.Started);
            mainViewModel.CancelGameCommand.Execute(mainViewModel);
            Assert.IsFalse(mainViewModel.CurrentGame.Started);
            mainViewModel.GameMode = GameMode.Infinite;
            mainViewModel.ChangeLanguageCommand.Execute("Greek");
            Assert.IsTrue(mainViewModel.CurrentLanguage.Name == "Greek");
            mainViewModel.StartGameCommand.Execute(mainViewModel);
            Assert.IsTrue(mainViewModel.CurrentGame.CurrentWord != null);
            string word = MockData.GreekWordList[0];
            mainViewModel.CurrentGame.CurrentWord = new Word() { Id = 1, Text = "ΑΓΟΡΑ" };
            int previousScore = mainViewModel.CurrentGame.Score;
            mainViewModel.TryLetterCommand.Execute("Α");
            Assert.IsTrue(this.isLetterFound);
            Assert.IsTrue(!this.isLetterNotFound);
            this.isLetterFound = false;
            this.isLetterNotFound = false;
            Assert.IsTrue(mainViewModel.CurrentGame.Score == previousScore + Game.LetterFoundPoints);
            previousScore = mainViewModel.CurrentGame.Score;
            mainViewModel.TryLetterCommand.Execute("Ω");
            Assert.IsTrue(!this.isLetterFound);
            Assert.IsTrue(this.isLetterNotFound);
            this.isLetterFound = false;
            this.isLetterNotFound = false;
            Assert.IsTrue(mainViewModel.CurrentGame.Score == previousScore - Game.LetterNotFoundPoints);
            Assert.IsTrue(mainViewModel.CurrentGame.TotalTriesPerWordRemaining == Game.MaxTriesPerWord - 1);
            previousScore = mainViewModel.CurrentGame.Score;
            mainViewModel.TryLetterCommand.Execute("Σ");
            Assert.IsTrue(!this.isLetterFound);
            Assert.IsTrue(this.isLetterNotFound);
            this.isLetterFound = false;
            this.isLetterNotFound = false;
            Assert.IsTrue(mainViewModel.CurrentGame.Score == previousScore - Game.LetterNotFoundPoints);
            Assert.IsTrue(mainViewModel.CurrentGame.TotalTriesPerWordRemaining == Game.MaxTriesPerWord - 2);
            int currentPercent = 60;
            Assert.IsTrue(mainViewModel.CurrentGame.GetWordPercentRemaining() == currentPercent);
            previousScore = mainViewModel.CurrentGame.Score;
            mainViewModel.TryWordCommand.Execute("ΑΓΟΡΑ");
            Assert.IsTrue(mainViewModel.CurrentGame.Score == previousScore + Game.WordFoundPoints + currentPercent);
            Assert.IsTrue(mainViewModel.CurrentGame.TotalWords == 1);
            previousScore = mainViewModel.CurrentGame.Score;
            mainViewModel.TryWordCommand.Execute("ΛΑΝΘΑΣΜΕΝΗ");
            Assert.IsFalse(mainViewModel.CurrentGame.Started);
            Assert.IsTrue(this.highscoresViewmodel != null);
            Assert.IsTrue(this.highscoresViewmodel.CurrentHighscore.Score == previousScore - Game.WordNotFoundPoints - 100);
            Assert.IsTrue(this.highscoresViewmodel.CurrentHighscore.TotalWords == 2);
            Assert.IsTrue(this.highscoresViewmodel.CurrentHighscore.GameMode == GameMode.Infinite);
        }

        private void ShowHighscores(ShowHighscoresMessage showHighscoresMessage)
        {
            this.highscoresViewmodel = new HighscoresViewModel(showHighscoresMessage.Language, showHighscoresMessage.Highscore);
        }

        private void LetterFound(LetterFoundMessage letterFoundMessage)
        {
            this.isLetterFound = true;
        }

        private void LetterNotFound(LetterNotFoundMessage letterNotFoundMessage)
        {
            this.isLetterNotFound = true;
        }
    }
}