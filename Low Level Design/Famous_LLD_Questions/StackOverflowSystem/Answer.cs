using System.Collections.ObjectModel;

namespace StackOverflowSystem;

public class Answer : IVotable, ICommentable
{
    public int Id { get; set; }
    public User Author { get; set; }
    public string Content { get; set; }
    public bool IsAccepted { get; set; }
    public Question Question { get; set; }
    public DateTime CreatedAt { get; set; }
    private readonly List<Comment> _comments;
    private readonly List<Vote> _votes;

    public Answer(User author, Question question, string content)
    {
        _comments = new List<Comment>();
        _votes = new List<Vote>();
        CreatedAt = DateTime.Now;
        Id = Helper.GenerateRandomNumber();
        Question = question;
        Content = content;
        Author = author;
    }

    public void AddVote(Vote vote)
    {
        _votes.Add(vote);
    }

    public int GetVoteCount()
    {
        return _votes.Sum(v => v.Value);
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public ReadOnlyCollection<Comment> GetComments()
    {
        return _comments.AsReadOnly();
    }

    public void MarkAccepted()
    {
        IsAccepted = true;
    }
}