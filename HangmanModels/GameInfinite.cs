/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/

namespace HangmanModels
{
    /// <summary>
    /// In this mode of game the player will keep playing for as long as all the words are guessed correctly. As soon as a word is not found then the game ends.
    /// </summary>
    public class GameInfinite : Game
    {
        public GameInfinite(string[] alphabet)
            : base(alphabet)
        {
            this.WordFound += this.GameInfinite_WordFound;
            this.WordNotFound += this.GameInfinite_WordNotFound;
            this.GameMode = GameMode.Infinite;
        }

        public override void GameStart()
        {
            this.OnGameStarted();
        }

        public override void GameCancel()
        {
            this.OnGameCanceled();
            this.OnGameEnded(true);
        }

        // If the player does not find a word in an 'infinite' type game, then the game is over.        
        private void GameInfinite_WordNotFound(object sender, string e)
        {
            this.TotalWords++;
            this.TotalTriesPerWordRemaining = Game.MaxTriesPerWord;
            this.Score -= Game.WordNotFoundPoints;
            this.OnGameEnded();
        }

        // If the player correctly guesses a word in an 'infinite' type game, then the game goes to the next word ad infinitum.       
        private void GameInfinite_WordFound(object sender, string e)
        {
            this.TotalWords++;
            this.TotalTriesPerWordRemaining = Game.MaxTriesPerWord;
            this.Score += Game.WordFoundPoints;
            this.OnRequestNewWord();
        }
    }
}