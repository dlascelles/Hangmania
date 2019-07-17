/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using GalaSoft.MvvmLight.Messaging;
using HangmanModels;

namespace HangmanViewModels.Messages
{
    public class ShowHighscoresMessage : NotificationMessage
    {
        public ShowHighscoresMessage(object sender, string message) : base(sender, message) { }

        public Highscore Highscore { get; set; }

        public Language Language { get; set; }
    }
}