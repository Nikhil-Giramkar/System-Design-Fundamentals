
using StackOverflowSystem;

internal class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello, World!");
        var system = StackOverFlow.GetInstance();
        var nikhil = new User("niks", "niks@yahoo.com");
        var ansh = new User("ansh", "ansh@yahoo.com");
        var suraj = new User("suraj", "suraj@yahoo.com");
        var sachin = new User("sachin", "sachin@yahoo.com");
        
        //Nikhil asked a question
        var polyQuestion = system.AskQuestion(nikhil, "Polymorphism", "What is polymorphism?", "OOP", "Polymorphism", "C#", "Java");
        
        //Suraj comment and vote on question
        system.AddComment(suraj, polyQuestion, "Nice question! interested to know the answer");
        system.AddVote(suraj, polyQuestion, 1);
        
        //Ansh answers the question
        var answer = system.AddAnswer(ansh, polyQuestion, "Its one of the pillars of OOP");
        
        //Suraj votes the answer
        system.AddVote(suraj, answer, 1);
        
        //Sachin comments on answer
        system.AddComment(sachin, answer, "Please explain in detail");
        
        
        //Nikhil marks answer as accepted
        system.AcceptAnswer(answer);

        
        
        
    }
}