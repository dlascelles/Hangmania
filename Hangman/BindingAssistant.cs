/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using System.Windows;

namespace Hangman
{
    public class BindingAssistant : Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new BindingAssistant();
        }

        public object Content
        {
            get { return this.GetValue(DataProperty); }
            set { this.SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Content", typeof(object), typeof(BindingAssistant), new UIPropertyMetadata(null));
    }
}