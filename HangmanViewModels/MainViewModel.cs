/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using HangmanDAL;
using HangmanModels;
using HangmanViewModels.Messages;
using HangmanViewModels.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HangmanViewModels
{
    /// <summary>
    /// The Main ViewModel of the application
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IWordDataService wordDataService = new WordDataService();

        public MainViewModel()
        {
            this.CurrentLanguage = LanguageDataAccess.AvailableLanguages["English"];
            this.GameMode = GameMode.TenWord;
            foreach (string letter in this.CurrentLanguage.Alphabet)
            {
                this.Letters.Add(letter);
            }
            this.StartGameCommand = new RelayCommand(this.StartGame, this.CanStartGame);
            this.CancelGameCommand = new RelayCommand(this.CancelGame, this.CanCancelGame);
            this.TryLetterCommand = new RelayCommand<string>(this.TryLetter, this.CanTryLetter);
            this.TryWordCommand = new RelayCommand<string>(this.TryWord, this.CanTryWord);
            this.ShowHighscoresCommand = new RelayCommand(this.ShowHighscores, this.CanShowHighscores);
            this.ChangeLanguageCommand = new RelayCommand<string>(this.ChangeLanguage, this.CanChangeLanguage);
        }

        public MainViewModel(IWordDataService wordDataService) : this()
        {
            this.wordDataService = wordDataService;
        }

        private void MainViewModel_RequestNewWord(object sender, EventArgs e)
        {
            this.CurrentGame.CurrentWord = this.wordDataService.RetrieveRandomWord(this.CurrentLanguage);
            this.CurrentWord = this.CurrentGame.CurrentWord.Text;
        }

        private async void MainViewModel_GameEnded(object sender, bool e)
        {
            //If the game ended normally and not canceled by the player
            if (!e)
            {
                if (this.CurrentGame is GameTimed gameTimed)
                {
                    Messenger.Default.Send<string>(null, typeof(WordNotFoundMessage));
                    this.PreviousWordBackground = "Red";
                    this.PreviousWord = this.CurrentWord;
                }
                if (!this.isPaused)
                {
                    await this.Pause(gameEnd: true);
                }
                Highscore highscore = new Highscore();
                highscore.Date = DateTime.Now;
                highscore.TotalWords = this.CurrentGame.TotalWords;
                highscore.Score = this.CurrentGame.Score;
                highscore.GameMode = this.GameMode;
                ShowHighscoresMessage showHighscoresMessage = new ShowHighscoresMessage(this, null);
                showHighscoresMessage.Highscore = highscore;
                showHighscoresMessage.Language = this.CurrentLanguage;
                Messenger.Default.Send(showHighscoresMessage);
            }
            //The following line will reset to a new game of the same mode
            this.GameMode = this.GameMode;
        }

        private async void MainViewModel_WordNotFound(object sender, string e)
        {
            this.PreviousWord = e;
            this.PreviousWordBackground = "Red";
            await this.Pause();
            this.WordToTry = "";
        }

        private async void MainViewModel_WordFound(object sender, string e)
        {
            this.PreviousWord = e;
            this.PreviousWordBackground = "Green";
            await this.Pause();
            this.WordToTry = "";
        }

        private async Task Pause(int miliseconds = 3000, bool gameEnd = false)
        {
            this.IsPaused = true;
            if (!gameEnd && this.GameMode == GameMode.Timed)
            {
                ((GameTimed)this.CurrentGame).TimerStop();
            }
            await Task.Delay(miliseconds);
            this.IsPaused = false;
            if (!gameEnd && this.GameMode == GameMode.Timed && this.CurrentGame.Started)
            {
                ((GameTimed)this.CurrentGame).TimerStart();
            }
        }

        private void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "TimeRemaining" && this.CurrentGame is GameTimed gametimed)
            {
                this.TotalSecondsRemaining = (int)gametimed.TimeRemaining.TotalSeconds;
                this.TimeRemaining = gametimed.TimeRemaining;
            }
            else if (e.PropertyName == "TotalWords")
            {
                this.ProgressMessage = $"{this.CurrentGame.TotalWords} {this.LangOf} 10";
            }
        }

        public RelayCommand StartGameCommand { get; private set; }
        private void StartGame()
        {
            this.CurrentGame.GameStart();
        }
        private bool CanStartGame()
        {
            return !this.CurrentGame.Started;
        }

        public RelayCommand CancelGameCommand { get; private set; }
        private void CancelGame()
        {
            this.CurrentGame.GameCancel();
            if (this.CurrentGame is GameTimed gameTimed)
            {
                this.TimeRemaining = new TimeSpan(0, GameTimed.TotalGameMinutes, GameTimed.TotalGameSeconds);
            }
        }
        private bool CanCancelGame()
        {
            return this.CurrentGame.Started;
        }

        public RelayCommand<string> TryLetterCommand { get; private set; }
        private void TryLetter(string letter)
        {
            bool letterFound = this.CurrentGame.TryLetter(letter);
            int currentPercent = this.CurrentGame.GetWordPercentRemaining();

            if (letterFound && currentPercent == 100)
            {
                WordFoundMessage wf = new WordFoundMessage(this, this.CurrentWord);
                Messenger.Default.Send(wf);
                return;
            }
            else if (!letterFound && (this.currentGame.TotalTriesPerWordRemaining == Game.MaxTriesPerWord || this.currentGame.TotalTriesPerWordRemaining == 0))
            {
                WordNotFoundMessage wnf = new WordNotFoundMessage(this, this.CurrentWord);
                Messenger.Default.Send(wnf);
                return;
            }
            if (letterFound)
            {
                LetterFoundMessage lf = new LetterFoundMessage(this, letter);
                Messenger.Default.Send(lf);
            }
            else
            {
                LetterNotFoundMessage lnf = new LetterNotFoundMessage(this, letter);
                Messenger.Default.Send(lnf);
            }
        }
        private bool CanTryLetter(string letter)
        {
            if (!this.CurrentGame.Started) return false;
            bool? can = null;
            if (this.CurrentGame.Letters.ContainsKey(letter))
            {
                can = this.CurrentGame.Letters[letter];
            }
            return can == null ? true : false;
        }

        public RelayCommand<string> TryWordCommand { get; private set; }
        private void TryWord(string word)
        {
            if (this.CurrentGame.TryWord(word))
            {
                WordFoundMessage wf = new WordFoundMessage(this, word);
                Messenger.Default.Send(wf);
            }
            else
            {
                WordNotFoundMessage wnf = new WordNotFoundMessage(this, word);
                Messenger.Default.Send(wnf);
            }
        }
        private bool CanTryWord(string word)
        {
            return !string.IsNullOrWhiteSpace(word);
        }

        public RelayCommand ShowHighscoresCommand { get; private set; }
        private void ShowHighscores()
        {
            ShowHighscoresMessage showHighscoresMessage = new ShowHighscoresMessage(this, null);
            showHighscoresMessage.Language = this.CurrentLanguage;
            Messenger.Default.Send(showHighscoresMessage);
        }
        private bool CanShowHighscores()
        {
            return !this.CurrentGame.Started;
        }

        public RelayCommand<string> ChangeLanguageCommand { get; private set; }
        private void ChangeLanguage(string language)
        {
            this.CurrentLanguage = LanguageDataAccess.AvailableLanguages[language];
            this.Letters = new ObservableCollection<string>();
            foreach (string letter in this.CurrentLanguage.Alphabet)
            {
                this.Letters.Add(letter);
            }
            this.ChangeLanguageStrings(LanguageDataAccess.AvailableLanguages[language]);
            this.GameMode = this.GameMode;
        }
        private bool CanChangeLanguage(string language)
        {
            return !this.CurrentGame.Started;
        }

        private bool isPaused = false;
        public bool IsPaused
        {
            get { return this.isPaused; }
            set { this.SetField(ref this.isPaused, value); }
        }

        private string previousWordBackground = "Green";
        public string PreviousWordBackground
        {
            get { return this.previousWordBackground; }
            set { this.SetField(ref this.previousWordBackground, value); }
        }

        private string wordToTry;
        public string WordToTry
        {
            get { return this.wordToTry; }
            set { this.SetField(ref this.wordToTry, value); }
        }

        private string previousWord;
        public string PreviousWord
        {
            get { return this.previousWord; }
            set { this.SetField(ref this.previousWord, value); }
        }

        private string currentWord;
        public string CurrentWord
        {
            get { return this.currentWord; }
            set
            {
                //This is necessary because if we get the same word twice the UI won't update.
                if (this.currentWord == value) this.CurrentWord = "";
                this.SetField(ref this.currentWord, value);
            }
        }

        private Game currentGame;
        public Game CurrentGame
        {
            get { return this.currentGame; }
            set { this.SetField(ref this.currentGame, value); }
        }

        private string progressMessage;
        public string ProgressMessage
        {
            get { return this.progressMessage; }
            set { this.SetField(ref this.progressMessage, value); }
        }

        private int totalSecondsRemaining = (int)new TimeSpan(0, GameTimed.TotalGameMinutes, GameTimed.TotalGameSeconds).TotalSeconds;
        public int TotalSecondsRemaining
        {
            get { return this.totalSecondsRemaining; }
            set { this.SetField(ref this.totalSecondsRemaining, value); }
        }

        private TimeSpan timeRemaining = new TimeSpan(0, GameTimed.TotalGameMinutes, GameTimed.TotalGameSeconds);
        public TimeSpan TimeRemaining
        {
            get { return this.timeRemaining; }
            set { this.SetField(ref this.timeRemaining, value); }
        }

        private ObservableCollection<string> letters = new ObservableCollection<string>();
        public ObservableCollection<string> Letters
        {
            get { return this.letters; }
            set { this.SetField(ref this.letters, value); }
        }

        private Language currentLanguage;
        public Language CurrentLanguage
        {
            get { return this.currentLanguage; }
            set { this.SetField(ref this.currentLanguage, value); }
        }

        private bool sound;
        public bool Sound
        {
            get { return this.sound; }
            set { this.SetField(ref this.sound, value); }
        }

        private GameMode gameMode;
        public GameMode GameMode
        {
            get { return this.gameMode; }
            set
            {
                this.SetField(ref this.gameMode, value);
                this.WordToTry = "";
                this.IsPaused = false;
                switch (this.GameMode)
                {
                    case GameMode.TenWord:
                        {
                            this.CurrentGame = new GameTenWord(this.CurrentLanguage.Alphabet);
                            this.ProgressMessage = $"{this.CurrentGame.TotalWords} {this.LangOf} 10";
                            break;
                        }
                    case GameMode.Timed:
                        {
                            this.CurrentGame = new GameTimed(this.CurrentLanguage.Alphabet);
                            this.TimeRemaining = new TimeSpan(0, GameTimed.TotalGameMinutes, GameTimed.TotalGameSeconds);
                            break;
                        }
                    case GameMode.Infinite:
                        {
                            this.CurrentGame = new GameInfinite(this.CurrentLanguage.Alphabet);
                            break;
                        }
                }
                this.CurrentGame.PropertyChanged += this.MainViewModel_PropertyChanged;
                this.CurrentGame.GameEnded += this.MainViewModel_GameEnded;
                this.CurrentGame.WordFound += this.MainViewModel_WordFound;
                this.CurrentGame.WordNotFound += this.MainViewModel_WordNotFound;
                this.CurrentGame.RequestNewWord += this.MainViewModel_RequestNewWord;
            }
        }
    }
}