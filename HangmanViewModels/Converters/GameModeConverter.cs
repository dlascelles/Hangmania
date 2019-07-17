/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using HangmanModels;
using System;
using System.Windows.Data;

namespace HangmanViewModels.Converters
{
    /// <summary>
    /// A two way converter to convert between IsChecked property of a Togglebutton and a GameMode enum.
    /// </summary>
    public class GameModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (System.Convert.ToString(parameter))
            {
                case "TenWord":
                    {
                        return (GameMode)value == GameMode.TenWord;
                    }
                case "Timed":
                    {
                        return (GameMode)value == GameMode.Timed;
                    }
                case "Infinite":
                    {
                        return (GameMode)value == GameMode.Infinite;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (System.Convert.ToString(parameter))
            {
                case "TenWord":
                    {
                        return GameMode.TenWord;
                    }
                case "Timed":
                    {
                        return GameMode.Timed;
                    }
                case "Infinite":
                    {
                        return GameMode.Infinite;
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}