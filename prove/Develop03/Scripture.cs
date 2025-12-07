using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private static Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(" ");
        foreach (var p in parts)
        {
            _words.Add(new Word(p));
        }
    }

    public string GetDisplayText()
    {
        List<string> shown = new List<string>();
        foreach (Word w in _words)
        {
            shown.Add(w.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} - {string.Join(" ", shown)}";
    }

    public void HideRandomWords(int count)
    {
        List<int> visible = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
                visible.Add(i);
        }

        if (visible.Count == 0) return;

        int toHide = Math.Min(count, visible.Count);

        for (int i = 0; i < toHide; i++)
        {
            int pick = _random.Next(visible.Count);
            int index = visible[pick];

            _words[index].Hide();
            visible.RemoveAt(pick);
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden()) return false;
        }
        return true;
    }
}
