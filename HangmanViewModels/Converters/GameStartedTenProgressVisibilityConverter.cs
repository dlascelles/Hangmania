/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using HangmanModels;
using System;
using System.Windows;
using System.Windows.Data;

namespace HangmanViewModels.Converters
{
    /// <summary>
    /// Controls the visibility of the progress bar while playing the game in 'Ten Words mode'.
    /// </summary>
    public class GameStartedTenProgressVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (System.Convert.ToBoolean(values[0]) == true && values[1] is GameTenWord)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }            
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Backwards conversion not supported.");
        }
    }
}