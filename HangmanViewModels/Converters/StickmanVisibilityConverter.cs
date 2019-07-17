/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HangmanViewModels.Converters
{
    /// <summary>
    /// One-way multivalue converter to control the visibility of the stickman images according to various rules. 
    /// </summary>
    public class StickmanVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int? triesLeft = System.Convert.ToInt32(values[0]);
            bool gameStarted = System.Convert.ToBoolean(values[1]);
            bool isPaused = System.Convert.ToBoolean(values[2]);
            bool isWin = System.Convert.ToString(values[3]) == "Green" ? true : false;
            string param = System.Convert.ToString(parameter);

            if (isPaused && param == "s0" && !isWin)
            {
                return Visibility.Visible;
            }

            if (isPaused && param == "swin" && isWin)
            {
                return Visibility.Visible;
            }
            if (gameStarted)
            {
                switch (triesLeft)
                {
                    case 0:
                        {
                            if (param == "s0" && isPaused)
                            {
                                return Visibility.Visible;
                            }
                            else
                            {
                                return Visibility.Collapsed;
                            }
                        }
                    case 1:
                        {
                            if (param == "s1" && !isPaused)
                            {
                                return Visibility.Visible;
                            }
                            else
                            {
                                return Visibility.Collapsed;
                            }
                        }
                    case 2:
                        {
                            if (param == "s2" && !isPaused)
                            {
                                return Visibility.Visible;
                            }
                            else
                            {
                                return Visibility.Collapsed;
                            }
                        }
                    case 3:
                        {
                            if (param == "s3" && !isPaused)
                            {
                                return Visibility.Visible;
                            }
                            else
                            {
                                return Visibility.Collapsed;
                            }
                        }
                    case 4:
                        {
                            if (param == "s4" && !isPaused)
                            {
                                return Visibility.Visible;
                            }
                            else
                            {
                                return Visibility.Collapsed;
                            }
                        }
                    case 5:
                        {
                            if (param == "s5" && !isPaused)
                            {
                                return Visibility.Visible;
                            }
                            else
                            {
                                return Visibility.Collapsed;
                            }
                        }
                    case 6:
                        {
                            if (param == "s6" && !isPaused)
                            {
                                return Visibility.Visible;
                            }
                            else
                            {
                                return Visibility.Collapsed;
                            }
                        }
                    case 7:
                        {
                            if (param == "s7" && !isPaused)
                            {
                                return Visibility.Visible;
                            }
                            else
                            {
                                return Visibility.Collapsed;
                            }
                        }
                    default:
                        {
                            return Visibility.Collapsed;
                        }
                }
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}