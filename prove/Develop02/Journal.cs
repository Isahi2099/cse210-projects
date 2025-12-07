using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();
    public int Count => _entries.Count;

    public void AddEntry(Entry e) => _entries.Add(e);

    public void Display()
    {
        Console.WriteLine("------ Journal Entries ------");
        foreach (var e in _entries)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine();
        }
        Console.WriteLine("------ End of Journal -------");
    }

    public void SaveToFile(string filename)
    {
        using (var output = new StreamWriter(filename))
        {
            foreach (var e in _entries) output.WriteLine(e.Serialize());
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename)) throw new FileNotFoundException($"File not found: {filename}");
        _entries.Clear();
        foreach (var line in File.ReadAllLines(filename))
        {
            if (!string.IsNullOrWhiteSpace(line)) _entries.Add(Entry.Deserialize(line));
        }
    }

    public List<Entry> Search(string keyword)
    {
        var results = new List<Entry>();
        if (string.IsNullOrWhiteSpace(keyword)) return results;
        string kw = keyword.Trim().ToLowerInvariant();
        foreach (var e in _entries)
            if ((e.Prompt?.ToLowerInvariant().Contains(kw) ?? false) ||
                (e.Response?.ToLowerInvariant().Contains(kw) ?? false))
                results.Add(e);
        return results;
    }
}
