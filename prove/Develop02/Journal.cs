class Journal
{
    public List<JournalEntry> _entries = new List<JournalEntry>();

    public void DisplayJournal()
    {
        foreach(JournalEntry entry in _entries)
        {
            entry.DisplayJournalEntry();
        }
    }

    public void CreateEntry()
    {
        JournalEntry newEntry = new JournalEntry();
        newEntry.CreateJournalEntry();
        _entries.Add(newEntry);
    }

    public void SaveToFile()
    {
        Console.WriteLine("What is the file name: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }
        Console.WriteLine("Journal saved successfully!");
    }

    public void LoadFromFile()
    {
        Console.WriteLine("What is the filename: ");
        string filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            JournalEntry entry = new JournalEntry();
            entry._date = parts[0].Trim();
            entry._prompt = parts[1].Trim();
            entry._response = parts[2].Trim();

            _entries.Add(entry);
        }

        Console.WriteLine("Journal loaded succesfully!");
    }

    public void CountEntries()
    {
        Console.WriteLine($"You have {_entries.Count} journal entries.");
    }
}