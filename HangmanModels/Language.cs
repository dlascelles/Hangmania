/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/

namespace HangmanModels
{
    public class Language : ModelBase
    {
        public Language(string name, string code, string[] alphabet)
        {
            this.Name = name;
            this.Code = code;
            this.Alphabet = alphabet;
        }

        private string name;
        public string Name
        {
            get { return this.name; }
            private set { this.SetField(ref this.name, value); }
        }

        private string code;
        public string Code
        {
            get { return this.code; }
            private set { this.SetField(ref this.code, value); }
        }

        private string[] alphabet;
        public string[] Alphabet
        {
            get { return this.alphabet; }
            private set { this.SetField(ref this.alphabet, value); }
        }
    }
}
