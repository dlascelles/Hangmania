/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
namespace HangmanModels
{
    public abstract class DbRecord : ModelBase
    {
        private int id;
        public int Id
        {
            get { return this.id; }
            set { this.SetField(ref this.id, value); }
        }
    }
}