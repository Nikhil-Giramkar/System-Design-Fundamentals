namespace SingletonPattern;

/*
-----------------------------------------------------------------
                SINGLETON PATTERN
-----------------------------------------------------------------
The Singleton pattern is useful when you need to ensure that only one instance of a class exists 
and that there's a global point of access to that instance.
Usecases

1. Logging
2. Configuration Management (implemented Precision Settings in WPF app in previous company for Healthcare roject)
3. DB Connection Pooling
4. Caching
5. Game Manager
6. Ride Manager (in Uber/Ola System Design)
*/
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        GameManager gameManager = GameManager.GetInstance();

        gameManager.AddScore(100);
        gameManager.AdvanceLevel();
        gameManager.SetSetting("Fullscreen", true);
        gameManager.ToggleSound();

        Console.WriteLine($"Current Level: {gameManager.CurrentLevel}");
        Console.WriteLine($"Player Score: {gameManager.PlayerScore}");
        Console.WriteLine($"Fullscreen: {gameManager.GetSetting("Fullscreen")}");
        Console.WriteLine($"Sound Enabled: {gameManager.GetSetting("SoundEnabled")}");

        // Accessing the game manager from another part of the code:
        GameManager anotherManager = GameManager.GetInstance(); // This will return the same instance.
        anotherManager.AddScore(50); // The score is updated in the original instance.
    }
}