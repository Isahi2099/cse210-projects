using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration; // in seconds

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");

        string input = Console.ReadLine();
        while (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a positive whole number of seconds: ");
            input = Console.ReadLine();
        }

        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(2);

        Console.WriteLine();
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] sequence = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(sequence[index]);
            Thread.Sleep(200);
            Console.Write("\b \b");

            index++;
            if (index >= sequence.Length)
            {
                index = 0;
            }
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}
