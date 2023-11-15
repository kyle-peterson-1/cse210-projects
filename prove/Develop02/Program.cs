using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        JournalWriter journalWriter = new JournalWriter();

        string[] prompts = {
            "Who was the most interesting person I encountered today?",
            "What was the best part of my day?",
            "How did I choose to serve someone today?",
            "How have you felt emotional today?",
            "If I had one thing I could do over today, what would it be?"
        };

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var newEntry = new PromptedJournalEntry
                    {
                        Date = DateTime.Now,
                        Prompt = prompts[new Random().Next(prompts.Length)]
                    };
                    Console.WriteLine("Prompt: " + newEntry.Prompt);
                    Console.Write("Response: ");
                    newEntry.Response = Console.ReadLine();

                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter a filename to save: ");
                    string saveFileName = Console.ReadLine();
                    journalWriter.SaveToFile(journal, saveFileName);
                    break;

                case "4":
                    Console.Write("Enter a filename to load: ");
                    string loadFileName = Console.ReadLine();
                    journalWriter.LoadFromFile(journal, loadFileName);
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    //class for the Journal Entry
    public abstract class JournalEntry
    {
        public DateTime Date { get; set; }

        //method for displaying the entry
        public abstract void Display();
    }

    //class for journal entry
    public class PromptedJournalEntry : JournalEntry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }

        public override void Display()
        {
            Console.WriteLine($"Date: {Date.ToShortDateString()}");
            Console.WriteLine($"Prompt: {Prompt}");
            Console.WriteLine($"Response: {Response}");
            Console.WriteLine();
        }
    }

    //class to manage entries
    public class Journal
    {
        private List<JournalEntry> entries;

        public Journal()
        {
            entries = new List<JournalEntry>();
        }

        public List<JournalEntry> Entries
        {
            get { return entries; }
        }

        //add a new entry to the journal
        public void AddEntry(JournalEntry entry)
        {
            entries.Add(entry);
        }

        //display all entries in the journal
        public void DisplayEntries()
        {
            foreach (var entry in entries)
            {
                entry.Display();
            }
        }

        //clear all entries in the journal
        public void ClearEntries()
        {
            entries.Clear();
        }
    }

    // Class to handle writing and reading the journal
    public class JournalWriter
    {
        //save the journal to a file
        public void SaveToFile(Journal journal, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var entry in journal.Entries)
                {
                    if (entry is PromptedJournalEntry promptedEntry)
                    {
                        writer.WriteLine($"{promptedEntry.Date.ToShortDateString()},{promptedEntry.Prompt},{promptedEntry.Response}");
                    }
                }
            }
        }

        //load the journal from a file
        public void LoadFromFile(Journal journal, string fileName)
        {
            journal.ClearEntries();

            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var parts = line.Split(',');

                    if (parts.Length == 3)
                    {
                        var entry = new PromptedJournalEntry
                        {
                            Date = DateTime.Parse(parts[0]),
                            Prompt = parts[1],
                            Response = parts[2]
                        };
                        journal.AddEntry(entry);
                    }
                }
            }
        }
    }
}