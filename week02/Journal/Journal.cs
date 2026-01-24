using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal
{
    public class Journal
    {
        public List<Entry> _entries = new List<Entry>();

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        public string AskForMood(string mood)
        {
            Console.Write("How are you feeling today? ");
            mood = Console.ReadLine();
            return mood;
        }

        public void DisplayAll()
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
                Console.WriteLine();
            }
        }

        public void SaveToFile(string file)
        {
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry._date}|{entry._mood}|{entry._promptText}|{entry._entryText}");
                }
            }
            Console.WriteLine("Journal succesfully saved!");
        }

        public void LoadFromFile(string file)
        {
            _entries.Clear();

            if (File.Exists(file))
            {
                string[] lines = System.IO.File.ReadAllLines(file);

                foreach (string line in lines)
                {
                    string[] parts = line.Split("|");

                    string date = parts[0];
                    string mood = parts[1];
                    string prompt = parts[2];
                    string entry = parts[3];

                    Entry loadedEntry = new Entry();

                    loadedEntry._date = date;
                    loadedEntry._mood = mood;
                    loadedEntry._promptText = prompt;
                    loadedEntry._entryText = entry;

                    _entries.Add(loadedEntry);
                }
                Console.WriteLine($"Your journal have been loaded successfully! Total entries: {_entries.Count}");
            }

            else
            {
                Console.WriteLine("Journal not found.");
            }
        }
    }
}