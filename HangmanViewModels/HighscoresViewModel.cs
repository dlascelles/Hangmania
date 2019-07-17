/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using HangmanModels;
using HangmanViewModels.Messages;
using HangmanViewModels.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HangmanViewModels
{
    /// <summary>
    /// The Highscore's window ViewModel
    /// </summary>
    public class HighscoresViewModel : ViewModelBase
    {
        private readonly IHighscoresDataService highscoresDataService = new HighscoresDataService();

        public HighscoresViewModel()
        {
            this.SaveHighScoreCommand = new RelayCommand(this.SaveHighScore, this.CanSaveHighScore);
            this.ResetHighscoresCommand = new RelayCommand(this.ResetHighscores, this.CanResetHighscores);
        }

        public HighscoresViewModel(Language language, Highscore highscore = null, IHighscoresDataService highscoresDataService = null)
            : this()
        {
            this.CurrentLanguage = language;
            this.ChangeLanguageStrings(language);
            this.HighscorePagingEnumDictionary.Add(HighscorePaging.Five, "5");
            this.HighscorePagingEnumDictionary.Add(HighscorePaging.Ten, "10");
            this.HighscorePagingEnumDictionary.Add(HighscorePaging.Twenty, "20");
            this.HighscorePagingEnumDictionary.Add(HighscorePaging.None, this.LangAll);
            if (highscoresDataService != null)
            {
                this.highscoresDataService = highscoresDataService;
            }
            this.CurrentHighscore = highscore;
            this.HighscorePaging = HighscorePaging.Ten;
            this.LoadData();
        }

        private void LoadData()
        {
            List<Highscore> tenWordHighscores;
            List<Highscore> timedHighscores;
            List<Highscore> infiniteHighscores;

            tenWordHighscores = this.highscoresDataService.Retrieve(GameMode.TenWord, this.CurrentLanguage, (int)this.HighscorePaging);
            timedHighscores = this.highscoresDataService.Retrieve(GameMode.Timed, this.CurrentLanguage, (int)this.HighscorePaging);
            infiniteHighscores = this.highscoresDataService.Retrieve(GameMode.Infinite, this.CurrentLanguage, (int)this.HighscorePaging);

            this.TenWordHighscores = new ObservableCollection<Highscore>(tenWordHighscores);
            this.TimedHighscores = new ObservableCollection<Highscore>(timedHighscores);
            this.InfiniteHighscores = new ObservableCollection<Highscore>(infiniteHighscores);
        }

        public RelayCommand SaveHighScoreCommand { get; private set; }
        private void SaveHighScore()
        {
            this.highscoresDataService.Create(this.CurrentHighscore, this.CurrentLanguage);
            this.LoadData();
            this.CurrentHighscore = null;
        }
        private bool CanSaveHighScore()
        {
            return this.CurrentHighscore != null && !String.IsNullOrEmpty(this.CurrentHighscore.Name);
        }

        public RelayCommand ResetHighscoresCommand { get; private set; }
        private void ResetHighscores()
        {
            ConfirmationMessage cm = new ConfirmationMessage(this, this.LangMsgResetConfirmation, (selection) =>
            {
                if (selection == true)
                {
                    this.highscoresDataService.Reset(this.CurrentLanguage);
                    this.LoadData();
                }
            });
            Messenger.Default.Send(cm);
        }
        private bool CanResetHighscores()
        {
            return true;
        }

        private string playerName;
        public string PlayerName
        {
            get { return this.playerName; }
            set { this.SetField(ref this.playerName, value); }
        }

        private Highscore currentHighscore;
        public Highscore CurrentHighscore
        {
            get { return this.currentHighscore; }
            set { this.SetField(ref this.currentHighscore, value); }
        }

        private ObservableCollection<Highscore> tenWordHighscores = new ObservableCollection<Highscore>();
        public ObservableCollection<Highscore> TenWordHighscores
        {
            get { return this.tenWordHighscores; }
            set { this.SetField(ref this.tenWordHighscores, value); }
        }

        private ObservableCollection<Highscore> timedHighscores = new ObservableCollection<Highscore>();
        public ObservableCollection<Highscore> TimedHighscores
        {
            get { return this.timedHighscores; }
            set { this.SetField(ref this.timedHighscores, value); }
        }

        private ObservableCollection<Highscore> infiniteHighscores = new ObservableCollection<Highscore>();
        public ObservableCollection<Highscore> InfiniteHighscores
        {
            get { return this.infiniteHighscores; }
            set { this.SetField(ref this.infiniteHighscores, value); }
        }

        private Language currentLanguage;
        public Language CurrentLanguage
        {
            get { return this.currentLanguage; }
            set { this.SetField(ref this.currentLanguage, value); }
        }

        public Dictionary<HighscorePaging, string> HighscorePagingEnumDictionary { get; } = new Dictionary<HighscorePaging, string>();

        private HighscorePaging hiscorePaging = HighscorePaging.Ten;
        public HighscorePaging HighscorePaging
        {
            get { return this.hiscorePaging; }
            set
            {
                if (this.SetField(ref this.hiscorePaging, value))
                {
                    this.LoadData();
                }
            }
        }
    }
}