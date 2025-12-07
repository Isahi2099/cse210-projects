public class Entry
{
    public string DateText { get; }
    public string Prompt { get; }
    public string Response { get; }
    public int Mood { get; }

    public Entry(string dateText, string prompt, string response, int mood = 3)
    {
        DateText = dateText;
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public override string ToString()
    {
        string moodFace = Mood switch
        {
            <= 1 => "😞",
            2 => "🙁",
            3 => "😐",
            4 => "🙂",
            _ => "😄"
        };
        return $"[{DateText}] (Mood {Mood} {moodFace}) {Prompt}\n> {Response}";
    }

    private const string Sep = "~|~";

    public string Serialize() => $"{DateText}{Sep}{Prompt}{Sep}{Response}{Sep}{Mood}";

    public static Entry Deserialize(string line)
    {
        string[] parts = line.Split(Sep);
        if (parts.Length < 3) throw new System.Exception("Bad entry line (expected 3+ parts).");
        int mood = (parts.Length >= 4 && int.TryParse(parts[3], out var m)) ? m : 3;
        return new Entry(parts[0], parts[1], parts[2], mood);
    }
}
