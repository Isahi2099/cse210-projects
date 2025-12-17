using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Event> events = new List<Event>();

        events.Add(new Lecture(
            "C# Masterclass",
            "Learn the fundamentals of C# and OOP.",
            "15 Dec 2025",
            "6:00 PM",
            new Address("123 Main St", "Rexburg", "ID", "USA"),
            "Dr. Smith",
            100
        ));

        events.Add(new Reception(
            "Company Holiday Reception",
            "A fun night of networking and food.",
            "20 Dec 2025",
            "7:30 PM",
            new Address("456 Center St", "Idaho Falls", "ID", "USA"),
            "rsvp@company.com"
        ));

        events.Add(new OutdoorGathering(
            "Winter Bonfire Meetup",
            "Hot chocolate, stories, and a bonfire outside.",
            "22 Dec 2025",
            "5:00 PM",
            new Address("789 Lake Rd", "Rigby", "ID", "USA"),
            "Cold weather - bring a jacket!"
        ));

        foreach (Event e in events)
        {
            Console.WriteLine("STANDARD DETAILS:");
            Console.WriteLine(e.GetStandardDetails());
            Console.WriteLine();

            Console.WriteLine("FULL DETAILS:");
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine();

            Console.WriteLine("SHORT DESCRIPTION:");
            Console.WriteLine(e.GetShortDescription());
            Console.WriteLine("\n------------------------------\n");
        }
    }
}
