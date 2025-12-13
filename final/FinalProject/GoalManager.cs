using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== Goal Tracker ===");
            Console.WriteLine($"Score: {_score}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Display Score");
            Console.WriteLine("7. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine()?.Trim() ?? "";

            Console.WriteLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": DisplayScore(); break;
                case "7": return;
                default:
                    Console.WriteLine("Invalid option. Please choose 1-7.");
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type would you like to create? ");

        string type = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Description: ");
        string description = Console.ReadLine() ?? "";

        int points = ReadInt("Points: ");

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
            Console.WriteLine("Simple goal created.");
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
            Console.WriteLine("Eternal goal created.");
        }
        else if (type == "3")
        {
            int target = ReadInt("How many times to complete it? ");
            int bonus = ReadInt("Bonus points when completed: ");
            _goals.Add(new ChecklistGoal(name, description, points, bonus, target));
            Console.WriteLine("Checklist goal created.");
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        Console.WriteLine("Your goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Create one first.");
            return;
        }

        ListGoals();
        int index = ReadInt("Which goal did you accomplish? ") - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int earned = _goals[index].RecordEvent();
        _score += earned;

        if (earned > 0)
        {
            Console.WriteLine($"Nice! You earned {earned} points.");
        }
        else
        {
            Console.WriteLine("That goal is already complete (or gave no points).");
        }
    }

    private void DisplayScore()
    {
        Console.WriteLine($"Your current score is: {_score}");
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save (example: goals.txt): ");
        string filename = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        try
        {
            using StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine(_score);

            foreach (Goal g in _goals)
            {
                writer.WriteLine(g.GetStringRepresentation());
            }

            Console.WriteLine($"Saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    private void LoadGoals()
    {
        Console.Write("Enter filename to load (example: goals.txt): ");
        string filename = Console.ReadLine()?.Trim() ?? "";

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0)
            {
                Console.WriteLine("File is empty.");
                return;
            }

            _goals.Clear();
            _score = int.Parse(lines[0].Trim());

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrWhiteSpace(line)) continue;

                // Type|name|description|...
                string[] parts = line.Split('|');
                string type = parts[0];

                if (type == "SimpleGoal")
                {
                    // SimpleGoal|name|description|points|isComplete
                    string name = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);
                    _goals.Add(SimpleGoal.FromString(name, desc, points, isComplete));
                }
                else if (type == "EternalGoal")
                {
                    // EternalGoal|name|description|points
                    string name = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    _goals.Add(EternalGoal.FromString(name, desc, points));
                }
                else if (type == "ChecklistGoal")
                {
                    // ChecklistGoal|name|description|points|bonus|target|completed
                    string name = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    int bonus = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int completed = int.Parse(parts[6]);
                    _goals.Add(ChecklistGoal.FromString(name, desc, points, bonus, target, completed));
                }
            }

            Console.WriteLine($"Loaded from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    private int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim() ?? "";

            if (int.TryParse(input, out int value) && value >= 0)
            {
                return value;
            }

            Console.WriteLine("Please enter a valid non-negative whole number.");
        }
    }
}
