/*
* Copyright (c) 2017 Daniel Lascelles, https://github.com/dlascelles
* This code is licensed under The MIT License. See LICENSE file in the project root for full license information.
* License URL: https://github.com/dlascelles/Hangmania/blob/master/LICENSE
*/
using HangmanModels;
using HangmanViewModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HangmanTests
{
    public class MockData
    {
        public static Random rnd = new Random();

        public static List<string> EnglishWordList = new List<string>()
        {
            "ACCORDING","ACCOUNT","ACROSS","ACT","ACTION","ACTIVITY","ACTUALLY",
            "ADD","ADDRESS","ADMINISTRATION","BROTHER","BUDGET","BUILD","BUILDING",
            "BUSINESS","COMPARE","COMPUTER","CONCERN","CONDITION","CONFERENCE","CONGRESS",
            "DESCRIBE","DESIGN","DESPITE","DETAIL","DETERMINE","DEVELOP","EAT","ECONOMIC",
            "ECONOMY","EDGE","FINALLY","FINANCIAL","FIND","FINE","FINGER","FINISH","GAME",
            "GARDEN","GAS","GENERAL","GENERATION","GET","GIRL","HANG","HAPPEN","HAPPY","HARD",
            "HAVE","HEAD","LIKELY","LINE","LIST","LISTEN","LITTLE","MEET","MEETING","MEMBER",
            "MEMORY","MENTION","MESSAGE","PERFORM","PERFORMANCE","PERHAPS","PERIOD","PERSON",
            "PERSONAL","RECENTLY","RECOGNIZE","RECORD","RED","REDUCE","REFLECT","REGION","RELATE",
            "SEA","SEASON","SEAT","SECOND","SECTION","TYPE","UNDER","UNDERSTAND","UNIT","UNTIL","UPON",
            "USE","USUALLY","VALUE","VARIOUS","VERY","VICTIM","VIEW","VIOLENCE","VISIT","WORK","WORKER",
            "WORLD","WORRY","WOULD"
        };

        public static List<string> GreekWordList = new List<string>()
        {
            "ΑΒΑΠΤΙΣΤΑ","ΑΒΑΣΙΛΕΥΤΗΣ","ΑΒΑΣΚΑΝΤΗΣ","ΑΒΓΑ","ΑΒΕΒΗΛΟ","ΑΒΕΛΤΕΡΟ","ΑΒΛΑΠΤΟΣ","ΑΒΟΛΟΣ",
            "ΑΒΟΥΤΥΡΩΤΟ","ΑΒΥΣΣΩΔΗΣ","ΑΓΑΛΗΝΕΥΤΟ","ΑΓΑΛΜΑΤΕΝΙΟΣ","ΑΓΓΕΙΟΔΙΑΣΤΟΛΗ","ΑΓΓΕΛΟΓΡΑΜΜΕΝΟ",
            "ΑΓΕΛΗΣ","ΑΓΕΩΡΓΗΤΟ","ΑΓΙΑΣΜΟΣ","ΑΓΙΟΓΡΑΦΟΣ","ΑΓΙΟΤΑΦΙΤΗΣ","ΑΓΚΑΘΕΡΑ","ΑΓΚΑΛΙΑΣΜΕΝΟ",
            "ΑΓΛΕΟΡΑΣ","ΑΓΝΑΝΤΕΥΤΗΣ","ΑΓΝΟΟΥΜΕΝΗ","ΑΓΝΩΣΤΙΚΙΣΜΟ","ΑΓΟΝΑΤΙΣΤΗ","ΑΓΟΡΑΝΟΜΙΚΗΣ","ΑΓΟΡΑΣΤΟ",
            "ΑΓΡΑΜΜΑΤΟΣ","ΑΓΡΙΑΠΙΔΙΑ","ΑΓΡΙΟΓΑΤΑ","ΑΓΡΙΟΦΩΝΑΡΑ","ΑΓΡΟΚΗΠΟΣ","ΑΓΡΟΤΗ","ΑΓΡΥΠΝΗΣ","ΑΓΥΡΕΥΤΟΣ",
            "ΑΓΧΟΝΗΣ","ΑΓΩΓΙΜΟ","ΑΓΩΝΙΩΔΗ","ΑΔΑΜΑΝΤΟΚΟΛΛΗΤΗ","ΑΔΑΠΑΝΗ","ΑΔΕΙΑ","ΑΔΕΙΠΝΗΣ","ΑΔΕΛΕΑΣΤΗ",
            "ΑΔΕΛΦΟΜΟΙΡΑΔΙ","ΑΔΕΝΙΚΗΣ","ΑΔΕΡΦΙ","ΑΔΕΣΜΕΥΤΟΣ","ΑΔΗΛΗΤΗΡΙΑΣΤΗΣ","ΑΔΗΜΟΣΙΕΥΤΟ","ΑΔΙΑΒΑΣΤΗ",
            "ΑΔΙΑΒΛΗΤΗ","ΑΔΙΑΖΕΥΚΤΟΣ","ΑΔΙΑΚΟΙΝΩΤΟΣ","ΑΔΙΑΚΡΙΤΟΣ","ΑΔΙΑΛΥΤΗ","ΑΔΙΑΜΟΡΦΩΤΟΣ","ΑΔΙΑΠΑΙΔΑΓΩΓΗΤΑ",
            "ΑΔΙΑΠΟΡΕΥΤΟ","ΑΔΙΑΡΘΡΩΤΑ","ΓΕΥΣΤΙΚΟΤΗΤΑΣ","ΓΗΡΑΣΜΕΝΟΣ","ΓΟΡΓΙΕΙΟ","ΔΑΝΤΕΛΕΝΙΟ","ΔΕΚΑΣΤΙΧΗΣ",
            "ΔΗΜΟΓΕΡΟΝΤΙΚΗΣ","ΔΙΑΚΕΙΜΕΝΟΣ","ΔΡΑΓΑΤΗΣ","ΕΓΚΛΙΜΑΤΙΣΜΟ","ΕΙΜΑΡΜΕΝΗ","ΕΚΠΛΗΚΤΙΚΟΤΕΡΗ","ΕΛΑΙΑΣ"
            ,"ΕΜΠΟΡΙΚΗΣ","ΕΝΕΡΓΗΤΙΚΗΣ","ΕΝΣΥΝΕΙΔΗΤΗΣ","ΚΑΠΝΕΜΠΟΡΟΣ","ΚΑΤΑΡΑΤΟΣ","ΚΕΝΟΛΟΓΙΑ","ΚΟΚΑΙΝΙΣΜΟΣ",
            "ΚΟΜΜΩΣΗ","ΚΡΟΚΙΔΩΣΗ","ΚΥΝΙΣΜΟΣ","ΛΑΚΤΙΣΜΑΤΑ","ΛΕΓΕΩΝΑΣ","ΛΙΑΣΤΟ","ΛΙΜΠΕΡΑΛΙΣΤΗΣ","ΛΟΓΟΤΕΧΝΙΣΣΑ",
            "ΜΕΡΑΡΧΙΑΚΟ","ΜΕΤΑΔΟΣΗ","ΜΗΛΟΦΑΓΟΣ","ΜΙΚΡΟΛΩΠΟΔΥΤΗΣ","ΜΟΛΥΝΤΙΚΗ","ΜΟΤΟΣΙΚΛΕΤΙΣΤΗΣ","ΜΠΑΝΙΚΟ",
            "ΜΠΟΥΓΙΟΥΡΝΤΙ","ΜΥΘΟΠΟΙΗΣΗ","ΝΟΗΤΑ","ΝΟΤΙΟΑΝΑΤΟΛΙΚΗΣ","ΞΑΝΘΟΜΑΛΛΗΣ","ΞΕΝΟΜΕΡΙΤΙΣΣΑ"
        };

        public static string GetRandomEnglishWord(Random rnd)
        {
            int index = rnd.Next(0, 100);
            return EnglishWordList[index];
        }

        public static string GetRandomGreekWord(Random rnd)
        {
            int index = rnd.Next(0, 100);
            return GreekWordList[index];
        }

        public static string GetRandomEnglishAvailableLetter(Dictionary<string, bool?> dic, Random rnd)
        {
            //Added some letters several times to weight the random selection towards these more oftenly used letters
            List<string> availableLetters = new List<string>()
            { "E", "E", "E", "E", "E", "E","E","E",
              "A", "A", "A", "A", "A","A","A",
              "O", "O", "O", "O", "O","O",
              "I", "I", "I", "I", "I",
              "U", "U", "U", "U",
              "T", "T", "T", "T","T","T","T",
              "S", "S", "S", "S","S",
              "N", "N", "N", "N","N",
              "H", "H", "H", "H","H",
              "R", "R", "R", "R",
              "D", "D"
            };
            foreach (KeyValuePair<string, bool?> kvp in dic)
            {
                if (kvp.Value == null)
                {
                    availableLetters.Add(kvp.Key);
                }
                else
                {
                    availableLetters.RemoveAll(l => l == kvp.Key);
                }
            }
            int index = rnd.Next(0, availableLetters.Count);
            return availableLetters[index];
        }

        public class WordDataService : IWordDataService
        {
            public Word RetrieveRandomWord(Language language)
            {
                if (language.Name == "English") return new Word() { Id = 1, Text = GetRandomEnglishWord(rnd) };
                if (language.Name == "Greek") return new Word() { Id = 1, Text = GetRandomGreekWord(rnd) };
                return null;
            }
        }

        public class HighscoresDataService : IHighscoresDataService
        {
            public List<Highscore> SavedEnglishHighscores = new List<Highscore>()
            {
                new Highscore() { Id = 1, Name = "John", Score = 150, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,06,06) },
                new Highscore() { Id = 2, Name = "Peter", Score = 250, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,04,07) },
                new Highscore() { Id = 3, Name = "Maria", Score = 450, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,05,15) },
                new Highscore() { Id = 4, Name = "Steve", Score = 75, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,04,13) },
                new Highscore() { Id = 5, Name = "Helen", Score = 120, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,12,12) },
                new Highscore() { Id = 6, Name = "John", Score = 100, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,06,06) },
                new Highscore() { Id = 7, Name = "Peter", Score = 110, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,04,07) },
                new Highscore() { Id = 8, Name = "Maria", Score = 105, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,05,15) },
                new Highscore() { Id = 9, Name = "Steve", Score = 67, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,04,13) },
                new Highscore() { Id = 10, Name = "Helen", Score = 43, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,12,12) },
                new Highscore() { Id = 11, Name = "John", Score = 22, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,06,06) },
                new Highscore() { Id = 12, Name = "Peter", Score = 133, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,04,07) },
                new Highscore() { Id = 13, Name = "Maria", Score = 222, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,05,15) },
                new Highscore() { Id = 14, Name = "Steve", Score = 234, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,04,13) },
                new Highscore() { Id = 15, Name = "Helen", Score = 255, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,12,12) },
                new Highscore() { Id = 16, Name = "John", Score = 111, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,06,06) },
                new Highscore() { Id = 17, Name = "Peter", Score = 156, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,04,07) },
                new Highscore() { Id = 18, Name = "Maria", Score = 121, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,05,15) },
                new Highscore() { Id = 19, Name = "Steve", Score = 115, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,04,13) },
                new Highscore() { Id = 20, Name = "Helen", Score = 89, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,12,12) },
                new Highscore() { Id = 21, Name = "John", Score = 55, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,06,06) },
                new Highscore() { Id = 22, Name = "Peter", Score = 234, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,04,07) },
                new Highscore() { Id = 23, Name = "Maria", Score = 432, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,05,15) },
                new Highscore() { Id = 24, Name = "Steve", Score = 410, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,04,13) },
                new Highscore() { Id = 25, Name = "Helen", Score = 507, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,12,12) },

                new Highscore() { Id = 26, Name = "John", Score = 700, TotalWords = 10, GameMode = GameMode.Timed, Date = new DateTime(2017,05,05) },
                new Highscore() { Id = 27, Name = "Dorothy", Score = 830, TotalWords = 10, GameMode = GameMode.Timed, Date = new DateTime(2017,11,25) },
                new Highscore() { Id = 28, Name = "Maria", Score = 450, TotalWords = 10, GameMode = GameMode.Timed, Date = new DateTime(2017,10,23) },
                new Highscore() { Id = 29, Name = "Steve", Score = 140, TotalWords = 10, GameMode = GameMode.Timed, Date = new DateTime(2017,01,01) },
                new Highscore() { Id = 30, Name = "Helen", Score = 550, TotalWords = 10, GameMode = GameMode.Timed, Date = new DateTime(2017,02,02) },

                new Highscore() { Id = 31, Name = "John", Score = 100, TotalWords = 3, GameMode = GameMode.Infinite, Date = new DateTime(2017,09,10) },
                new Highscore() { Id = 32, Name = "John", Score = 200, TotalWords = 5, GameMode = GameMode.Infinite, Date = new DateTime(2017,10,09) },
                new Highscore() { Id = 33, Name = "Maria", Score = 50, TotalWords = 2, GameMode = GameMode.Infinite, Date = new DateTime(2017,10,08) },
                new Highscore() { Id = 34, Name = "Steve", Score = 36, TotalWords = 1, GameMode = GameMode.Infinite, Date = new DateTime(2017,08,10) },
                new Highscore() { Id = 35, Name = "Helen", Score = 800, TotalWords = 10, GameMode = GameMode.Infinite, Date = new DateTime(2017,11,12) }
            };

            public List<Highscore> SavedGreekHighscores = new List<Highscore>()
            {
                new Highscore() { Id = 1, Name = "Andreas", Score = 25, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,06,06) },
                new Highscore() { Id = 2, Name = "George", Score = 330, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,04,07) },
                new Highscore() { Id = 3, Name = "Maria", Score = 500, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,05,15) },
                new Highscore() { Id = 4, Name = "Andria", Score = 750, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,04,13) },
                new Highscore() { Id = 5, Name = "Anna", Score = 900, TotalWords = 10, GameMode = GameMode.TenWord, Date = new DateTime(2017,12,12) },

                new Highscore() { Id = 6, Name = "Anna", Score = 600, TotalWords = 10, GameMode = GameMode.Timed, Date = new DateTime(2017,05,05) },
                new Highscore() { Id = 7, Name = "Crhistos", Score = 420, TotalWords = 10, GameMode = GameMode.Timed, Date = new DateTime(2017,11,25) },
                new Highscore() { Id = 8, Name = "Maria", Score = 555, TotalWords = 10, GameMode = GameMode.Timed, Date = new DateTime(2017,10,23) },
                new Highscore() { Id = 9, Name = "Petros", Score = 440, TotalWords = 10, GameMode = GameMode.Timed, Date = new DateTime(2017,01,01) },
                new Highscore() { Id = 10, Name = "Helen", Score = 150, TotalWords = 10, GameMode = GameMode.Timed, Date = new DateTime(2017,02,02) },

                new Highscore() { Id = 11, Name = "Giannis", Score = 230, TotalWords = 3, GameMode = GameMode.Infinite, Date = new DateTime(2017,09,10) },
                new Highscore() { Id = 12, Name = "Anna", Score = 310, TotalWords = 5, GameMode = GameMode.Infinite, Date = new DateTime(2017,10,09) },
                new Highscore() { Id = 13, Name = "Maria", Score = 50, TotalWords = 2, GameMode = GameMode.Infinite, Date = new DateTime(2017,10,08) },
                new Highscore() { Id = 14, Name = "Andreas", Score = 36, TotalWords = 1, GameMode = GameMode.Infinite, Date = new DateTime(2017,08,10) },
                new Highscore() { Id = 15, Name = "Anna", Score = 470, TotalWords = 10, GameMode = GameMode.Infinite, Date = new DateTime(2017,11,12) }
            };

            public void Create(Highscore highscore, Language language)
            {
                if (language.Name == "English")
                {
                    this.SavedEnglishHighscores.Add(highscore);
                }
                else if (language.Name == "Greek")
                {
                    this.SavedGreekHighscores.Add(highscore);
                }
            }

            public void Reset(Language language)
            {
                if (language.Name == "English")
                {
                    this.SavedEnglishHighscores.Clear();
                }
                else if (language.Name == "Greek")
                {
                    this.SavedGreekHighscores.Clear();
                }
            }

            public List<Highscore> Retrieve(GameMode gameMode, Language language, int recordsToRetrieve)
            {
                if (language.Name == "English")
                {
                    return recordsToRetrieve == 0 ?
                        this.SavedEnglishHighscores.Where(h => h.GameMode == gameMode).OrderByDescending(h => h.Score).ToList() :
                        this.SavedEnglishHighscores.Where(h => h.GameMode == gameMode).OrderByDescending(h => h.Score).Take(recordsToRetrieve).ToList();
                }
                else if (language.Name == "Greek")
                {
                    return recordsToRetrieve == 0 ?
                        this.SavedGreekHighscores.Where(h => h.GameMode == gameMode).OrderByDescending(h => h.Score).ToList() :
                        this.SavedGreekHighscores.Where(h => h.GameMode == gameMode).OrderByDescending(h => h.Score).Take(recordsToRetrieve).ToList();
                }
                return null;
            }
        }
    }
}