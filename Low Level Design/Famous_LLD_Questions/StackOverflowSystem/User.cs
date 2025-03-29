namespace StackOverflowSystem;

public class User
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public int Id { get; set; }
    public int Reputation { get; set; }
    private List<Question> _questions { get; set; }
    private List<Answer> _answers { get; set; }
    private List<Comment> _comments { get; set; }

    private const int CommentReputation = 5;
    private const int AnswerReputation = 15;
    private const int QuestionReputation = 10;

    public User(string username, string email)
    {
        Id = Helper.GenerateRandomNumber();
        UserName = username;
        Email = email;
        _questions = new List<Question>();
        _answers = new List<Answer>();
        _comments = new List<Comment>();
    }

    public Question AskQuestion(string title, string content, params string[] tags)
    {
        var question  = new Question(this, title, content, tags);
        _questions.Add(question);
        UpdateReputation(QuestionReputation);
        return question;
    }
    
    public Answer AddAnswer(Question question, string content)
    {
        var answer = new Answer(this, question, content);
        _answers.Add(answer);
        question.AddAnswer(answer);
        UpdateReputation(AnswerReputation);
        return answer;
    }
    
    public void AddComment(ICommentable commentable, string content)
    {
        var comment = new Comment(this, content);
        _comments.Add(comment);
        commentable.AddComment(comment); //question or answer
        UpdateReputation(CommentReputation);
    }
    
    public void AddVote(IVotable votable, int value)
    {
        var vote = new Vote(this, value);
        votable.AddVote(vote); //question or answer
    }

    private void UpdateReputation(int value)
    {
        Reputation += value;
    }
    
    
    
    
    
}