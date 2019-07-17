/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/

namespace HangmanModels
{
    /// <summary>
    /// In this mode of game the player will try to find a total of ten words and amass as many points as possible. If the player fails to find a word the game moves to the next one.
    /// </summary>
    public class GameTenWord : Game
    {
        public GameTenWord(string[] alphabet) : base(alphabet)
        {
            this.WordFound += this.GameTenWord_WordFound;
            this.WordNotFound += this.GameTenWord_WordNotFound;
            this.GameMode = GameMode.TenWord;
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

        private void GameTenWord_WordNotFound(object sender, string e)
        {
            this.Score -= Game.WordNotFoundPoints;
            this.TotalWords++;
            this.ValidateGameState();
        }

        private void GameTenWord_WordFound(object sender, string e)
        {
            this.Score += Game.WordFoundPoints;
            this.TotalWords++;
            this.ValidateGameState();
        }

        private void ValidateGameState()
        {
            if (this.TotalWords == 10)
            {
                this.OnGameEnded();
            }
            else
            {
                this.OnRequestNewWord();
            }
        }
    }
}