/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using GalaSoft.MvvmLight.Messaging;
using HangmanViewModels.Messages;
using MahApps.Metro.Controls;
using System.Windows;

namespace Hangman
{
    public partial class HighscoresWindow : MetroWindow
    {
        public HighscoresWindow()
        {
            this.InitializeComponent();
            Messenger.Default.Register<ConfirmationMessage>(this, this.IncomingConfirmation);
            this.txtName.Focus();
        }

        private void IncomingConfirmation(ConfirmationMessage msg)
        {
            MessageBoxResult result = MessageBox.Show(msg.Notification, Application.Current.MainWindow.GetType().Assembly.GetName().Name, MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                msg.Execute(true);
            }
            else if (result == MessageBoxResult.No)
            {
                msg.Execute(false);
            }
            else
            {
                msg.Execute(null);
            }
        }

        private void MetroWindow_Closed(object sender, System.EventArgs e)
        {
            Messenger.Default.Unregister<ConfirmationMessage>(this, this.IncomingConfirmation);
        }
    }
}