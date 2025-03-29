
namespace StackOverflowSystem;

public class Tag
{
    public string Name { get; set; }
    public int Id { get; set; }

    public Tag(string name)
    {
        Name = name;
        Id = Helper.GenerateRandomNumber();
    }
}