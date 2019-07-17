/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
namespace HangmanModels
{
    public class Word : DbRecord
    {
        public override string ToString()
        {
            return this.Text;
        }

        private string text;
        public string Text
        {
            get { return this.text; }
            set { this.SetField(ref this.text, value.ToUpper()); }
        }
    }
}