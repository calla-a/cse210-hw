using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptureMemorizer
{
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _verse;
        private int _endVerse;
        
        // New variable.
        private string _verseText;

        public Reference(string book, int chapter, int verse, string text)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _verseText = text;
        }

        public Reference(string book, int chapter, int startVerse, string text, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _verse = startVerse;
            _verseText = text;
            _endVerse = endVerse;
        }

        // GetDisplayText() replaced by GetDisplayReference() and GetDisplayText()
        public string GetDisplayReference()
        {
            string reference = $"{_book} {_chapter}: {_verse}";
            if (_endVerse > _verse)
            {
                reference += $"-{_endVerse}";
            }
            return reference;
        }

        public string GetDisplayText()
        {
            return _verseText;
        }

        // Method that generates the list
        public static List<Reference> GenerateList(string file)
        {
            List<Reference> scriptures = new List<Reference>();
            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);

                foreach (string line in lines)
                {
                    string[] parts = line.Split("|");
                    int length = parts.Length;

                    string lBook = parts[0];
                    int lChapter = int.Parse(parts[1]);
                    int lVerse = int.Parse(parts[2]);
                    string lText = "";
                    if (parts.Length == 4)
                    {
                        lText += parts[3];
                        scriptures.Add(new Reference(lBook, lChapter, lVerse, lText));
                    }
                    else
                    {
                        int lEndVerse = int.Parse(parts[4]);
                        lText += parts[3] + "\n";
                        for (int i = 5; i < parts.Length; i += 2)
                        {
                            lText += parts[i] + "\n";
                        }
                        scriptures.Add(new Reference(lBook, lChapter, lVerse, lText, lEndVerse));
                    }
                }
            }
            return scriptures;
        }
    }
}