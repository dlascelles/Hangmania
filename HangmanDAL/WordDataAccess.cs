/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using HangmanModels;
using System;
using System.Data.SQLite;

namespace HangmanDAL
{
    public class WordDataAccess
    {
        /// <summary>
        /// Retrieves a random word from a particular language table.
        /// </summary>
        /// <param name="language">The language of the requested word</param>
        /// <returns>A Word Object</returns>
        public static Word RetrieveRandom(Language language)
        {
            Word word = new Word();

            using (SQLiteConnection con = new SQLiteConnection(DbManager.ConnectionString))
            {
                string query = $"SELECT * FROM {language.Name + "Word"} ORDER BY RANDOM() LIMIT 1";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    con.Open();
                    using (SQLiteDataReader dare = cmd.ExecuteReader())
                    {
                        while (dare.Read())
                        {
                            word.Id = Convert.ToInt32(dare["Id"]);
                            word.Text = dare["Text"].ToString();
                        }
                    }
                }
            }

            return word;
        }
    }
}