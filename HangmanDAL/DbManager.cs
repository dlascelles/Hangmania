/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using System;
using System.IO;

namespace HangmanDAL
{
    public static class DbManager
    {
        static DbManager()
        {
            string mainPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.None), "HangmaniaData");
            ConnectionString = $@"Data Source={mainPath}\hangmaniadb.sqlite;Version=3";
        }
        public static string ConnectionString { get; set; }
    }
}