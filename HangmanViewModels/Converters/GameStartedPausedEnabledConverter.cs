/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using System;
using System.Windows.Data;

namespace HangmanViewModels.Converters
{
    /// <summary>
    /// One-way multivalue converter between the Enabled property of the Letters ItemsControl and TryWord textbox when the game ends or when its paused.
    /// </summary>
    public class GameStartedPausedDisabledConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (System.Convert.ToBoolean(values[0]) == true && System.Convert.ToBoolean(values[1]) == true)
            {
                return false;
            }
            else if (System.Convert.ToBoolean(values[0]) == true && System.Convert.ToBoolean(values[1]) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Backwards conversion not supported.");
        }
    }
}