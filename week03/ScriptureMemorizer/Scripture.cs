using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random random = new Random();

        // New Scripture constructor
        public Scripture(List<Reference> scriptures)
        {
            int index = random.Next(scriptures.Count);
            _reference = scriptures[index];

            _words = new List<Word>();

            string[] wordsList = _reference.GetDisplayText().Split(" ");
            foreach (string word in wordsList)
            {
                _words.Add(new Word(word));
            }
        }

        // HiddenRandomWord method updated
        public void HideRandomWord(int numberToHide)
        {
            List<Word> missingWords = new List<Word>();
            // the method adds the hidden words in a list to doesn't hide the again
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    missingWords.Add(word);
                }
            }
            // If the number of words that haven't been hidden are less the the numberToHide assigned,
            // this variable changes its variable for the word's number missing.
            if (numberToHide > missingWords.Count)
            {
                numberToHide = missingWords.Count;
            }
            for (int i = 0; i < numberToHide; i++)
            {
                int index = random.Next(missingWords.Count);
                missingWords[index].Hide();
                missingWords.RemoveAt(index);
            }
        }

        public string GetDisplayText()
        {
            string text = "";
            foreach (Word word in _words)
            {
                text += word.GetDisplayText() + " ";
            }
            return text;
        }

        // Method created to get access to the reference and display it.
        public string GetDisplayReference()
        {
            return _reference.GetDisplayReference();
        }

        public bool IsCompletelyHidden()
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }
            return true;
        }
    }
}