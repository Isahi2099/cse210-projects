using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();

        bool running = true;
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Search entries by keyword  (EXTRA)");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option (1-6): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine() ?? "";

                    int mood = AskMood();

                    string dateText = DateTime.Now.ToShortDateString();
                    Entry e = new Entry(dateText, prompt, response, mood);
                    journal.AddEntry(e);

                    Console.WriteLine("Entry added!");
                    break;

                case "2":
                    if (journal.Count == 0) Console.WriteLine("No entries yet.");
                    else journal.Display();
                    break;

                case "3":
                    Console.Write("Enter a filename to save (e.g., myjournal.txt): ");
                    string saveName = Console.ReadLine() ?? "journal.txt";
                    try
                    {
                        journal.SaveToFile(saveName);
                        Console.WriteLine($"Saved to {saveName}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error saving file: {ex.Message}");
                    }
                    break;

                case "4":
                    Console.Write("Enter a filename to load (e.g., myjournal.txt): ");
                    string loadName = Console.ReadLine() ?? "journal.txt";
                    try
                    {
                        journal.LoadFromFile(loadName);
                        Console.WriteLine($"Loaded from {loadName}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading file: {ex.Message}");
                    }
                    break;

                case "5":
                    Console.Write("Keyword to search: ");
                    string kw = (Console.ReadLine() ?? "").Trim();
                    var matches = journal.Search(kw);
                    if (matches.Count == 0) Console.WriteLine("No matches found.");
                    else
                    {
                        Console.WriteLine($"Found {matches.Count} matching entr{(matches.Count==1?"y":"ies")}:");
                        foreach (var m in matches)
                        {
                            Console.WriteLine(m);
                            Console.WriteLine();
                        }
                    }
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Please choose a valid option (1-6).");
                    break;
            }
        }
    }

    private static int AskMood()
    {
        while (true)
        {
            Console.Write("Mood today (1=😞 … 5=😄): ");
            string? s = Console.ReadLine();
            if (int.TryParse(s, out int mood) && mood >= 1 && mood <= 5)
                return mood;
            Console.WriteLine("Please enter a number 1–5.");
        }
    }
}
