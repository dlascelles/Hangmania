/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using HangmanModels;
using System.Collections.Generic;

namespace HangmanDAL
{
    /// <summary>
    /// Provides a dictionary with all the available application languages.
    /// </summary>
    public class LanguageDataAccess
    {
        public static Dictionary<string, Language> AvailableLanguages = new Dictionary<string, Language>()
        {
            {"English", new Language("English", "en-US", Alphabet.EnglishAlphabet)},
            {"Greek", new Language("Greek", "el-GR", Alphabet.GreekAlphabet)}
        };
    }
}