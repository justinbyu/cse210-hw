using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter output = new StreamWriter(file))
        {
            foreach (Entry entry in entries)
            {
                output.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        string[] lines = File.ReadAllLines(file);

        entries.Clear();

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            Entry entry = new Entry();
            entry.Date = parts[0];
            entry.Prompt = parts[1];
            entry.Response = parts[2];

            entries.Add(entry);
        }
    }
}