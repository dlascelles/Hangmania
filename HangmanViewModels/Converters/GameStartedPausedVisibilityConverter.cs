/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using System;
using System.Windows;
using System.Windows.Data;

namespace HangmanViewModels.Converters
{
    /// <summary>
    /// A one-way multivalue converter between a Visibility property and the Game Started and Paused Properties. Use "show" or "hide" as parameter to indicate what is to be done with the particular control
    /// </summary>
    public class GameStartedPausedVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (System.Convert.ToBoolean(values[0]) == true && System.Convert.ToBoolean(values[1]) == true)
            {
                if (System.Convert.ToString(parameter) == "show")
                {
                    return Visibility.Visible;
                }
                else if (System.Convert.ToString(parameter) == "hide")
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            else if (System.Convert.ToBoolean(values[0]) == false && System.Convert.ToBoolean(values[1]) == true)
            {
                if (System.Convert.ToString(parameter) == "show")
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            else if (System.Convert.ToBoolean(values[0]) == true && System.Convert.ToBoolean(values[1]) == false)
            {
                if (System.Convert.ToString(parameter) == "show")
                {
                    return Visibility.Collapsed;
                }
                else if (System.Convert.ToString(parameter) == "hide")
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
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