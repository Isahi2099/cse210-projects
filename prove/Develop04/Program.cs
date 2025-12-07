using System;

// NOTE: Creativity / Exceed Requirements:
// - Shared spinner and countdown logic in the base Activity class.
// - All activities share common start/end messages via inheritance.
// - Reflection and Listing activities use random prompts/questions.

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();
            int.TryParse(input, out choice);

            switch (choice)
            {
                case 1:
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;

                case 2:
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    break;

                case 3:
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;

                case 4:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Please enter a valid option (1-4).");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
