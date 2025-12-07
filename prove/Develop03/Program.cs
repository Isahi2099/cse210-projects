using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";

        Scripture scripture = new Scripture(reference, text);

        string input = "";

        while (input.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide words or type 'quit': ");
            input = Console.ReadLine();

            if (input.ToLower() != "quit")
                scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine("All done! Good job memorizing.");
    }
}
