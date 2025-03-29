using System.Security.Cryptography;

namespace StackOverflowSystem;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public User Author { get; set; }
    public DateTime CreatedAt { get; set; }

    public Comment(User author, string content)
    {
        this.Author = author;
        this.Content = content;
        this.CreatedAt = DateTime.Now;
        this.Id = Helper.GenerateRandomNumber();
    }
    
}