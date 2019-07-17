/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using System;
using System.Collections.Generic;

namespace HangmanModels
{
    public abstract class Game : ModelBase
    {
        public static readonly int WordFoundPoints = 50;
        public static readonly int WordNotFoundPoints = 25;
        public static readonly int LetterFoundPoints = 5;
        public static readonly int LetterNotFoundPoints = 2;
        public static readonly int MaxTriesPerWord = 7;

        public event EventHandler GameStarted;
        public event EventHandler GameCanceled;
        public event EventHandler<bool> GameEnded;
        public event EventHandler<string> WordFound;
        public event EventHandler<string> WordNotFound;
        public event EventHandler RequestNewWord;

        public Game(string[] alphabet)
        {
            this.TotalTriesPerWordRemaining = Game.MaxTriesPerWord;
            this.Alphabet = alphabet;
            this.ResetLetters();
        }

        public abstract void GameStart();
        public abstract void GameCancel();

        protected void OnGameStarted()
        {
            this.TotalWords = 0;
            this.Score = 0;
            this.GameStarted?.Invoke(this, null);
            this.RequestNewWord?.Invoke(this, null);
            this.Started = true;
        }

        protected void OnGameEnded(bool userCanceled = false)
        {
            this.GameEnded?.Invoke(this, userCanceled);
            this.Started = false;
        }

        protected void OnGameCanceled()
        {
            this.GameCanceled?.Invoke(this, null);
            this.Started = false;
        }

        protected void OnRequestNewWord()
        {
            this.RequestNewWord?.Invoke(this, null);
            this.TotalTriesPerWordRemaining = Game.MaxTriesPerWord;
            this.ResetLetters();
        }

        private void ResetLetters()
        {
            this.Letters.Clear();
            foreach (string letter in this.alphabet)
            {
                this.Letters.Add(letter, null);
            }
        }

        /// <summary>
        /// Will attempt to guess if a particular letter exists in the CurrentWord.
        /// </summary>
        /// <param name="letter"></param>
        /// <returns>Boolean</returns>
        public bool TryLetter(string letter)
        {
            if (this.Started && letter != null && letter.Length > 0 && this.Letters.ContainsKey(letter) && this.Letters[letter] == null)
            {
                letter = letter.ToUpper();
                if (this.CurrentWord.Text.Contains(letter))
                {
                    this.Letters[letter] = true;
                    this.Score += Game.LetterFoundPoints;
                    if (this.IsWordFound())
                    {
                        string previousWord = this.CurrentWord.Text;
                        this.WordFound?.Invoke(this, previousWord);
                    }
                    return true;
                }
                else
                {
                    this.TotalTriesPerWordRemaining--;
                    this.Letters[letter] = false;
                    this.Score -= Game.LetterNotFoundPoints;
                    if (this.TotalTriesPerWordRemaining == 0)
                    {
                        string previousWord = this.CurrentWord.Text;
                        this.WordNotFound?.Invoke(this, previousWord);
                    }
                    return false;
                }
            }
            else
            {
                throw new ArgumentException("Illegal letter input.");
            }
        }

        /// <summary>
        /// Will attempt to guess the entire word at once.
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Boolean</returns>
        public bool TryWord(string word)
        {
            if (word != null && word.Length > 0)
            {
                word = word.ToUpper();
                int remainingPercentage = this.GetWordPercentRemaining();
                if (word == this.CurrentWord.Text)
                {
                    this.Score += remainingPercentage;
                    string previousWord = this.CurrentWord.Text;
                    this.WordFound?.Invoke(this, previousWord);
                    return true;
                }
                else
                {
                    this.Score -= remainingPercentage;
                    string previousWord = this.CurrentWord.Text;
                    this.WordNotFound?.Invoke(this, previousWord);
                    return false;
                }

            }
            else
            {
                throw new ArgumentException("Illegal input.");
            }
        }

        /// <summary>
        /// This will get the percentage of found letters in current word and if the word is found points will be given accordingly. The lesser the percentage the more points the player gets.
        /// </summary>
        /// <returns>Integer</returns>
        public int GetWordPercentRemaining()
        {
            if (this.CurrentWord != null && this.CurrentWord.Text.Length > 0)
            {
                int count = 0;
                foreach (char c in this.CurrentWord.Text)
                {
                    if (this.Letters[Convert.ToString(c)] == true) count++;
                }
                return 100 - Convert.ToInt32((count / (decimal)this.CurrentWord.Text.Length) * 100M);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Will check whether the CurrentWord is already found.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool IsWordFound()
        {
            foreach (char c in this.CurrentWord.Text)
            {
                if (this.Letters[c.ToString()] == null)
                {
                    return false;
                }
            }
            return true;
        }

        private Word currentWord = new Word() { Id = 0, Text = "" };
        public Word CurrentWord
        {
            get { return this.currentWord; }
            set { this.SetField(ref this.currentWord, value); }
        }

        public Dictionary<string, bool?> Letters { get; } = new Dictionary<string, bool?>();

        private string[] alphabet;
        public string[] Alphabet
        {
            get { return this.alphabet; }
            set { this.SetField(ref this.alphabet, value); }
        }

        private bool started = false;
        public bool Started
        {
            get { return this.started; }
            protected set { this.SetField(ref this.started, value); }
        }

        private int totalTriesPerWordRemaining;
        public int TotalTriesPerWordRemaining
        {
            get { return this.totalTriesPerWordRemaining; }
            set { this.SetField(ref this.totalTriesPerWordRemaining, value); }
        }

        private int score;
        public int Score
        {
            get { return this.score; }
            set { this.SetField(ref this.score, value); }
        }

        private int totalWords;
        public int TotalWords
        {
            get { return this.totalWords; }
            set { this.SetField(ref this.totalWords, value); }
        }

        private GameMode gameMode;
        public GameMode GameMode
        {
            get { return this.gameMode; }
            set { this.SetField(ref this.gameMode, value); }
        }
    }
}