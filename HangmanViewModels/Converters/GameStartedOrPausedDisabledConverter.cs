/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using System;
using System.Globalization;
using System.Windows.Data;

namespace HangmanViewModels.Converters
{
    /// <summary>
    /// One-way converter to disable a control while the game is started or paused.
    /// </summary>
    public class GameStartedOrPausedDisabledConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool started = System.Convert.ToBoolean(values[0]);
            bool paused = System.Convert.ToBoolean(values[1]);

            if (started || paused)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}