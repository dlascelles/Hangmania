/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using System;
using System.Windows.Threading;

namespace HangmanModels
{
    /// <summary>
    /// In this game there is a timer of 5 minutes. It doesn't matter if you find the word or not. You will keep moving onto the next word until the time passes.
    /// </summary>
    public class GameTimed : Game
    {
        public static readonly int TotalGameMinutes = 5;
        public static readonly int TotalGameSeconds = 0;

        public GameTimed(string[] alphabet)
            : base(alphabet)
        {
            this.WordFound += this.GameTimed_WordFound;
            this.WordNotFound += this.GameTimed_WordNotFound;
            this.timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
            this.timer.Tick += this.Timer_Tick;
            this.GameMode = GameMode.Timed;
        }

        public override void GameStart()
        {
            this.TimeRemaining = new TimeSpan(0, TotalGameMinutes, TotalGameSeconds);
            this.OnGameStarted();
            this.TimerStart();
        }

        public override void GameCancel()
        {            
            this.OnGameCanceled();
            this.OnGameEnded(true);
            this.TimerStop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.TimeRemaining -= new TimeSpan(0, 0, 1);            
        }

        private void GameTimed_WordNotFound(object sender, string e)
        {
            this.TotalWords++;
            this.Score -= Game.WordNotFoundPoints;
            this.OnRequestNewWord();
        }

        private void GameTimed_WordFound(object sender, string e)
        {
            this.TotalWords++;
            this.Score += Game.WordFoundPoints;
            this.OnRequestNewWord();
        }

        public void TimerStart()
        {
            if (this.timer != null)
            {
                this.timer.Start();
            }
        }

        public void TimerStop()
        {
            if (this.timer != null)
            {
                this.timer.Stop();
            }
        }

        private readonly DispatcherTimer timer;

        private TimeSpan timeRemaining;
        public TimeSpan TimeRemaining
        {
            get { return this.timeRemaining; }
            private set
            {
                this.SetField(ref this.timeRemaining, value);
                if (this.TimeRemaining <= TimeSpan.Zero)
                {
                    this.TimerStop();
                    this.OnGameEnded();
                }
            }
        }
    }
}