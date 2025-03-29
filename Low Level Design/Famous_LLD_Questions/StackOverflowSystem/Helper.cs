using System.Security.Cryptography;

namespace StackOverflowSystem;

public class Helper
{
    public static int GenerateRandomNumber()
    {
        return RandomNumberGenerator.GetInt32(0, int.MaxValue);
    }
}