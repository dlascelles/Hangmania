/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using HangmanModels;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace HangmanDAL
{
    public class HighscoreDataAccess
    {
        public void Create(Highscore highscore, Language language)
        {
            if (highscore != null)
            {
                using (SQLiteConnection con = new SQLiteConnection(DbManager.ConnectionString))
                {
                    string query = $"INSERT INTO {language.Name + "Highscore"} (Date, Name, TotalWords, Score, GameMode) VALUES (@Date, @Name, @TotalWords, @Score, @GameMode)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Date", highscore.Date);
                        cmd.Parameters.AddWithValue("@Name", highscore.Name);
                        cmd.Parameters.AddWithValue("@TotalWords", highscore.TotalWords);
                        cmd.Parameters.AddWithValue("@Score", highscore.Score);
                        cmd.Parameters.AddWithValue("@GameMode", (int)highscore.GameMode);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Reset(Language language)
        {
            using (SQLiteConnection con = new SQLiteConnection(DbManager.ConnectionString))
            {
                string query = $"DELETE FROM {language.Name + "Highscore"}";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Highscore> Retrieve(GameMode gameMode, Language language, int recordsToRetrieve = 0)
        {
            List<Highscore> highscores = new List<Highscore>();

            using (SQLiteConnection con = new SQLiteConnection(DbManager.ConnectionString))
            {
                string query = recordsToRetrieve == 0 ?
                    $"SELECT Id, Date, Name, TotalWords, Score, GameMode FROM {language.Name + "Highscore"} WHERE GameMode=@GameMode ORDER BY Score DESC" :
                    $"SELECT Id, Date, Name, TotalWords, Score, GameMode FROM {language.Name + "Highscore"} WHERE GameMode=@GameMode ORDER BY Score DESC LIMIT {recordsToRetrieve}";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@GameMode", gameMode);
                    con.Open();
                    using (SQLiteDataReader dare = cmd.ExecuteReader())
                    {
                        while (dare.Read())
                        {
                            Highscore highscore = new Highscore()
                            {
                                Id = Convert.ToInt32(dare["Id"]),
                                Date = Convert.ToDateTime(dare["Date"]),
                                Name = dare["Name"].ToString(),
                                TotalWords = Convert.ToInt32(dare["TotalWords"]),
                                Score = Convert.ToInt32(dare["Score"]),
                                GameMode = (GameMode)Convert.ToInt32(dare["GameMode"])
                            };
                            highscores.Add(highscore);
                        }
                    }
                }
            }

            return highscores;
        }
    }
}