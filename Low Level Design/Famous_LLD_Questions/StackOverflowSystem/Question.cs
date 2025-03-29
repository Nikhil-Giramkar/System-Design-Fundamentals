using System.Collections.ObjectModel;

namespace StackOverflowSystem;

public class Question : ICommentable, IVotable
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public User Author { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Tag> Tags { get; set; }
    private List<Answer> _answers;
    private List<Comment> _comments;
    private List<Vote> _votes;

    public Question(User author, string title, string content, params string[] tags)
    {
        Author = author;
        Title = title;
        Content = content;
        CreatedAt = DateTime.Now;
        Tags = tags.Select(x => new Tag(x)).ToList();
        Id = Helper.GenerateRandomNumber();
        _comments = new List<Comment>();
        _votes = new List<Vote>();
        _answers = new List<Answer>();
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

    public void AddAnswer(Answer answer)
    {
        _answers.Add(answer);
    }
}