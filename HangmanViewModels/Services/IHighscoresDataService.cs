/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using HangmanModels;
using System.Collections.Generic;

namespace HangmanViewModels.Services
{
    public interface IHighscoresDataService
    {
        void Create(Highscore highscore, Language language);        
        List<Highscore> Retrieve(GameMode gameMode, Language language, int recordsToRetrieve = 0);
        void Reset(Language language);
    }
}