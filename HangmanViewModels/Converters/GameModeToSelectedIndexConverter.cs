/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using HangmanModels;
using System;
using System.Globalization;
using System.Windows.Data;

namespace HangmanViewModels.Converters
{
    /// <summary>
    /// One-way converter to convert the GameMode enum to a Tab Control selected index.
    /// </summary>
    public class GameModeToSelectedIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((GameMode)value == GameMode.TenWord)
            {
                return 0;
            }
            else if ((GameMode)value == GameMode.Timed)
            {
                return 1;
            }
            else if ((GameMode)value == GameMode.Infinite)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}