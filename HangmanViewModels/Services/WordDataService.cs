/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using HangmanDAL;
using HangmanModels;

namespace HangmanViewModels.Services
{
    public class WordDataService : IWordDataService
    {
        /// <summary>
        /// Will retrieve a random word from a specific language table.
        /// </summary>
        /// <param name="language">The language of the requested word.</param>
        /// <returns>A Random Word</returns>
        public Word RetrieveRandomWord(Language language)
        {
            return WordDataAccess.RetrieveRandom(language);
        }
    }
}