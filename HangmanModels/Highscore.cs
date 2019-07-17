/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using System;

namespace HangmanModels
{
    public class Highscore : DbRecord
    {
        public override string ToString()
        {
            return $"{this.Name}: {this.Score}";
        }

        private DateTime date;
        public DateTime Date
        {
            get { return this.date; }
            set { this.SetField(ref this.date, value); }
        }

        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.SetField(ref this.name, value); }
        }

        private int totalWords;
        public int TotalWords
        {
            get { return this.totalWords; }
            set { this.SetField(ref this.totalWords, value); }
        }

        private int score;
        public int Score
        {
            get { return this.score; }
            set { this.SetField(ref this.score, value); }
        }

        private GameMode gameMode;
        public GameMode GameMode
        {
            get { return this.gameMode; }
            set { this.SetField(ref this.gameMode, value); }
        }
    }
}