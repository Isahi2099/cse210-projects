namespace Foundation1;

using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _length; // seconds
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public string GetTitle() => _title;
    public string GetAuthor() => _author;
    public int GetLength() => _length;

    public List<Comment> GetComments()
    {
        return _comments;
    }
}
