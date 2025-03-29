using System.Collections.Concurrent;

namespace StackOverflowSystem;

public sealed class StackOverFlow
{
    private static StackOverFlow _instance;
    private static readonly object _lock = new object();
    
    private ConcurrentBag<Question> _questions;
    private ConcurrentBag<Answer> _answers;
    private ConcurrentBag<User> _users;
    private StackOverFlow()
    {
        //initial settings
        _questions = new ConcurrentBag<Question>();
        _answers = new ConcurrentBag<Answer>();
        _users = new ConcurrentBag<User>();
    }
    
    public static StackOverFlow GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new StackOverFlow();
                }
            }
        }
        return _instance;
    }
    

    public Question AskQuestion(User author, string title, string content, params string[] tags)
    {
        var question = author.AskQuestion(title, content, tags);
        _questions.Add(question);
        return question;
    }
    
    public Answer AddAnswer(User author, Question question, string content)
    {
        var answer = author.AddAnswer(question, content);
        _answers.Add(answer);
        return answer;
    }
    
    public void AddComment(User user, ICommentable commentable, string content)
    {
        user.AddComment(commentable, content);
    }
    
    public void AddVote(User user, IVotable votable, int value)
    {
        user.AddVote(votable, value);
    }

    public void AcceptAnswer(Answer answer)
    {
        answer.MarkAccepted();
    }

    public List<Question> SearchQuestions(string query)
    {
        return _questions
            .Where(q => q.Title.Contains(query,  StringComparison.InvariantCultureIgnoreCase)
                                || q.Content.Contains(query, StringComparison.InvariantCultureIgnoreCase)
                                || q.Tags.Any(t => t.Name.Contains(query, StringComparison.InvariantCultureIgnoreCase)))
            .ToList();
    }
    
}