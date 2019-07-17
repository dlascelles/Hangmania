/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using GalaSoft.MvvmLight.Messaging;
using System;

namespace HangmanViewModels.Messages
{
    public class ConfirmationMessage : NotificationMessageAction<bool?>
    {
        public ConfirmationMessage(object sender, string message, Action<bool?> callback) : base(sender, message, callback) { }
    }
}