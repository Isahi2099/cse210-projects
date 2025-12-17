namespace Foundation1;

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video("Learning C# Basics", "CodeTeacher", 600);
        v1.AddComment(new Comment("Isahi", "This helped a lot, thank you!"));
        v1.AddComment(new Comment("Maria", "Great explanation."));
        v1.AddComment(new Comment("Josh", "Can you do one on inheritance next?"));

        Video v2 = new Video("Gym Routine for Beginners", "FitCoach", 480);
        v2.AddComment(new Comment("Ana", "Super simple and clear."));
        v2.AddComment(new Comment("Luis", "This motivated me to start today."));
        v2.AddComment(new Comment("Sam", "The pacing was perfect."));

        Video v3 = new Video("SQL Joins Explained", "DataGuy", 720);
        v3.AddComment(new Comment("Chris", "Finally understand LEFT JOINs."));
        v3.AddComment(new Comment("Isahi", "This is exactly what I needed for class."));
        v3.AddComment(new Comment("Nina", "Awesome examples."));

        videos.Add(v1);
        videos.Add(v2);
        videos.Add(v3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length (sec): {video.GetLength()}");
            Console.WriteLine($"# of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment c in video.GetComments())
            {
                Console.WriteLine($"  - {c.GetName()}: {c.GetText()}");
            }

            Console.WriteLine("\n------------------------------\n");
        }
    }
}
