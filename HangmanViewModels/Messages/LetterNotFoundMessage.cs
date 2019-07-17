/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using GalaSoft.MvvmLight.Messaging;

namespace HangmanViewModels.Messages
{
    public class LetterNotFoundMessage : NotificationMessage
    {
        public LetterNotFoundMessage(object sender, string message) : base(sender, message) { }
    }
}