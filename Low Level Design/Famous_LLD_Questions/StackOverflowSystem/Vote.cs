namespace StackOverflowSystem;

public class Vote
{
    public User User {get;set;}
    public int Value {get;set;}

    public Vote(User user, int value)
    {
        User = user;
        Value = value;
    }
    
}