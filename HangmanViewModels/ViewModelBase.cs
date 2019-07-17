/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using HangmanModels;
using System.Deployment.Application;

namespace HangmanViewModels
{
    /// <summary>
    /// A base class for all the application's ViewModels
    /// </summary>
    public class ViewModelBase : ModelBase
    {
        private readonly string versionNumber = "";

        public ViewModelBase()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                this.versionNumber = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }

            this.LangMainTitle = this.versionNumber.Length > 0 ? $"Hangmania - Version {this.versionNumber}" : "Hangmania";
            this.LangHighscoresTitle = "Highscores - English -";
            this.LangStart = "Start";
            this.LangCancelGame = "Cancel game";
            this.LangTenWord = "TenWord";
            this.LangTimed = "Timed";
            this.LangInfinite = "Infinite";
            this.LangHighscores = "Highscores";
            this.LangScore = "Score";
            this.LangPlayerName = "Player Name";
            this.LangDate = "Date";
            this.LangTotalWords = "Total Words";
            this.LangSave = "Save";
            this.LangEnterName = "Enter your name:";
            this.LangOf = "of";
            this.LangReset = "Reset";
            this.LangAll = "All";
            this.LangConfirm = "Confirm";
            this.LangMsgResetConfirmation = "Are you sure you want to reset all highscores?";
            this.LangSound = "Sound";
        }

        /// <summary>
        /// A quick way of being able to update the UI strings on the fly. Will work fine for a tiny application as this.
        /// </summary>
        /// <param name="language"></param>
        public void ChangeLanguageStrings(Language language)
        {
            switch (language.Name)
            {
                case "English":
                    {
                        this.LangMainTitle = this.versionNumber.Length > 0 ? $"Hangmania - Version {this.versionNumber}" : "Hangmania";
                        this.LangHighscoresTitle = "Highscores - English -";
                        this.LangStart = "Start";
                        this.LangCancelGame = "Cancel game";
                        this.LangTenWord = "TenWord";
                        this.LangTimed = "Timed";
                        this.LangInfinite = "Infinite";
                        this.LangHighscores = "Highscores";
                        this.LangScore = "Score";
                        this.LangPlayerName = "Player Name";
                        this.LangDate = "Date";
                        this.LangTotalWords = "Total Words";
                        this.LangSave = "Save";
                        this.LangEnterName = "Enter your name:";
                        this.LangOf = "of";
                        this.LangReset = "Reset";
                        this.LangAll = "All";
                        this.LangConfirm = "Confirm";
                        this.LangMsgResetConfirmation = "Are you sure you want to reset all highscores?";
                        this.LangSound = "Sound";
                        break;
                    }
                case "Greek":
                    {
                        this.LangMainTitle = this.versionNumber.Length > 0 ? $"Hangmania - Έκδοση {this.versionNumber}" : "Hangmania";
                        this.LangHighscoresTitle = "Βαθμολογία - Ελληνικά -";
                        this.LangStart = "Έναρξη";
                        this.LangCancelGame = "Ακύρωση";
                        this.LangTenWord = "Δέκα Λέξεις";
                        this.LangTimed = "Με Χρόνο";
                        this.LangInfinite = "Απεριόριστο";
                        this.LangHighscores = "Βαθμολογία";
                        this.LangScore = "Σκόρ";
                        this.LangPlayerName = "Όνομα";
                        this.LangDate = "Ημερομηνία";
                        this.LangTotalWords = "Λέξεις";
                        this.LangSave = "Αποθήκευση";
                        this.LangEnterName = "Εισαγωγή ονόματος:";
                        this.LangOf = "από";
                        this.LangReset = "Εκκαθάριση";
                        this.LangAll = "Όλα";
                        this.LangConfirm = "Επιβεβαίωση";
                        this.LangMsgResetConfirmation = "Θέλετε σίγουρα να διαγράψετε όλες τις βαθμολογίες;";
                        this.LangSound = "Ήχος";
                        break;
                    }
            }
        }

        private string langMainTitle;
        public string LangMainTitle
        {
            get { return this.langMainTitle; }
            set { this.SetField(ref this.langMainTitle, value); }
        }

        private string langHighscoresTitle;
        public string LangHighscoresTitle
        {
            get { return this.langHighscoresTitle; }
            set { this.SetField(ref this.langHighscoresTitle, value); }
        }

        private string langStart;
        public string LangStart
        {
            get { return this.langStart; }
            set { this.SetField(ref this.langStart, value); }
        }

        private string langCancelGame;
        public string LangCancelGame
        {
            get { return this.langCancelGame; }
            set { this.SetField(ref this.langCancelGame, value); }
        }

        private string langTenWord;
        public string LangTenWord
        {
            get { return this.langTenWord; }
            set { this.SetField(ref this.langTenWord, value); }
        }

        private string langTimed;
        public string LangTimed
        {
            get { return this.langTimed; }
            set { this.SetField(ref this.langTimed, value); }
        }

        private string langInfinite;
        public string LangInfinite
        {
            get { return this.langInfinite; }
            set { this.SetField(ref this.langInfinite, value); }
        }

        private string langHighscores;
        public string LangHighscores
        {
            get { return this.langHighscores; }
            set { this.SetField(ref this.langHighscores, value); }
        }

        private string langScore;
        public string LangScore
        {
            get { return this.langScore; }
            set { this.SetField(ref this.langScore, value); }
        }

        private string langPlayerName;
        public string LangPlayerName
        {
            get { return this.langPlayerName; }
            set { this.SetField(ref this.langPlayerName, value); }
        }

        private string langDate;
        public string LangDate
        {
            get { return this.langDate; }
            set { this.SetField(ref this.langDate, value); }
        }

        private string langTotalWords;
        public string LangTotalWords
        {
            get { return this.langTotalWords; }
            set { this.SetField(ref this.langTotalWords, value); }
        }

        private string langSave;
        public string LangSave
        {
            get { return this.langSave; }
            set { this.SetField(ref this.langSave, value); }
        }

        private string langEnterName;
        public string LangEnterName
        {
            get { return this.langEnterName; }
            set { this.SetField(ref this.langEnterName, value); }
        }

        private string langOf;
        public string LangOf
        {
            get { return this.langOf; }
            set { this.SetField(ref this.langOf, value); }
        }

        private string langReset;
        public string LangReset
        {
            get { return this.langReset; }
            set { this.SetField(ref this.langReset, value); }
        }

        private string langAll;
        public string LangAll
        {
            get { return this.langAll; }
            set { this.SetField(ref this.langAll, value); }
        }

        private string langConfirm;
        public string LangConfirm
        {
            get { return this.langConfirm; }
            set { this.SetField(ref this.langConfirm, value); }
        }

        private string langMsgResetConfirmation;
        public string LangMsgResetConfirmation
        {
            get { return this.langMsgResetConfirmation; }
            set { this.SetField(ref this.langMsgResetConfirmation, value); }
        }

        private string langSound;
        public string LangSound
        {
            get { return this.langSound; }
            set { this.SetField(ref this.langSound, value); }
        }
    }
}