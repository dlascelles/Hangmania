/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using HangmanDAL;
using HangmanModels;
using System.Collections.Generic;

namespace HangmanViewModels.Services
{
    public class HighscoresDataService : IHighscoresDataService
    {
        /// <summary>
        /// Will create a new Highscore record for a given language.
        /// </summary>
        /// <param name="highscore"></param>
        /// <param name="language"></param>
        public void Create(Highscore highscore, Language language)
        {
            new HighscoreDataAccess().Create(highscore, language);
        }

        /// <summary>
        /// Will reset all highscores (of all game modes) for a particular language.
        /// </summary>
        /// <param name="language"></param>
        public void Reset(Language language)
        {
            new HighscoreDataAccess().Reset(language);
        }

        /// <summary>
        /// Retrieves a specific number of highscores of a specific language and game mode in descending order.
        /// </summary>
        /// <param name="gameMode"></param>
        /// <param name="language"></param>
        /// <param name="recordsToRetrieve"></param>
        /// <returns></returns>
        public List<Highscore> Retrieve(GameMode gameMode, Language language, int recordsToRetrieve)
        {
            return new HighscoreDataAccess().Retrieve(gameMode, language, recordsToRetrieve);
        }
    }
}