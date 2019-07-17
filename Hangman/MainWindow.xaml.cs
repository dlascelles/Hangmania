/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/

using GalaSoft.MvvmLight.Messaging;
using HangmanViewModels;
using HangmanViewModels.Messages;
using MahApps.Metro.Controls;
using System;
using System.IO;
using System.Windows.Media;
using Thriple.Controls;

namespace Hangman
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            this.InitializeComponent();
            Messenger.Default.Register<ShowHighscoresMessage>(this, this.ShowHighscores);
            Messenger.Default.Register<LetterFoundMessage>(this, this.LetterFound);
            Messenger.Default.Register<LetterNotFoundMessage>(this, this.LetterNotFound);
            Messenger.Default.Register<WordFoundMessage>(this, this.WordFound);
            Messenger.Default.Register<WordNotFoundMessage>(this, this.WordNotFound);
        }

        private void ShowHighscores(ShowHighscoresMessage showHighscoresMessage)
        {
            HighscoresWindow h = new HighscoresWindow();
            h.DataContext = new HighscoresViewModel(showHighscoresMessage.Language, showHighscoresMessage.Highscore);
            if (showHighscoresMessage.Highscore != null)
            {
                this.Mplayer.Open(this.gameOverPath);
                this.Mplayer.Play();
            }
            h.ShowDialog();
        }

        private void LetterFound(LetterFoundMessage letterFoundMessage)
        {
            var c3d = UIAssistant.GetVisualChildren<ContentControl3D>(this, letterFoundMessage.Notification);
            foreach (ContentControl3D c in c3d)
            {
                if (c.IsFrontInView) c.Rotate();
            }
            this.txtTryWord.Focus();
            this.Mplayer.Open(this.letterFoundrPath);
            this.Mplayer.Play();
        }

        private void LetterNotFound(LetterNotFoundMessage letterNotFoundMessage)
        {
            this.txtTryWord.Focus();
            this.Mplayer.Open(this.letterNotFoundPath);
            this.Mplayer.Play();
        }

        private void WordFound(WordFoundMessage wordFoundMessage)
        {
            this.Mplayer.Open(this.wordFoundPath);
            this.Mplayer.Play();
        }

        private void WordNotFound(WordNotFoundMessage wordNotFoundMessage)
        {
            this.Mplayer.Open(this.wordNotFoundPath);
            this.Mplayer.Play();
        }

        private readonly Uri gameOverPath = new Uri(Path.Combine(Environment.CurrentDirectory, "Sounds", "gameover.wav"));
        private readonly Uri wordFoundPath = new Uri(Path.Combine(Environment.CurrentDirectory, "Sounds", "foundword.wav"));
        private readonly Uri wordNotFoundPath = new Uri(Path.Combine(Environment.CurrentDirectory, "Sounds", "notfoundword.wav"));
        private readonly Uri letterFoundrPath = new Uri(Path.Combine(Environment.CurrentDirectory, "Sounds", "foundletter.wav"));
        private readonly Uri letterNotFoundPath = new Uri(Path.Combine(Environment.CurrentDirectory, "Sounds", "notfoundletter.wav"));

        public MediaPlayer Mplayer { get; } = new MediaPlayer();
    }
}