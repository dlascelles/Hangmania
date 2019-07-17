/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using HangmanDAL;
using HangmanModels;
using System;
using System.Globalization;
using System.Windows.Data;

namespace HangmanViewModels.Converters
{
    /// <summary>
    /// A two-way converter to convert between the IsChecked value of the Language Togglebuttons and the current application language.
    /// </summary>
    public class ToggleLanguageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Language language)
            {
                switch (language.Name)
                {
                    case "English":
                        {
                            return (System.Convert.ToString(parameter) == "English");
                        }
                    case "Greek":
                        {
                            return (System.Convert.ToString(parameter) == "Greek");
                        }
                    default:
                        {
                            return false;
                        }
                }
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (System.Convert.ToString(parameter))
            {
                case "English":
                    {
                        return LanguageDataAccess.AvailableLanguages["English"];
                    }
                case "Greek":
                    {
                        return LanguageDataAccess.AvailableLanguages["Greek"];
                    }
                default:
                    {
                        return LanguageDataAccess.AvailableLanguages["English"];
                    }
            }
        }
    }
}