using System;

namespace SingletonPattern;

public sealed class GameManager //sealed class to ensure singleton pattrn is not broken via inheritance
{

    #region other properties
    private int playerScore;
    private int currentLevel;
    private Dictionary<string, bool> gameSettings;
    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    public int CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }
    #endregion

    //private constructor no initialization by object creation
    private GameManager()
    {
        //game settings
        playerScore = 0;
        currentLevel = 1;
        gameSettings = new Dictionary<string, bool>
        {
            {"SoundEnabled", true},
            {"MusicEnabled", true},
            {"Fullscreen", false}
        };
    }
    
    //private static instance - so that the instance belongs to class not to any instance
    private static GameManager _gameManager; 
    
    //lock object
    private static readonly object lockObject = new object();

    public static GameManager GetInstance()//a static method exposed for giving instance
    { 
        if(_gameManager == null) //optimize performance by avoiding unnecessary locking
        { 
            lock(lockObject) //thread safety, never lock on this keyword.
            {
                //Because multiple threads might have passed the first check simultaneously. 
                //Without the second check, multiple threads could potentially create separate instances
                if(_gameManager == null)  
                {
                    _gameManager = new GameManager();
                }
            }
        }

        return _gameManager;
    }

    #region other methods
    public bool GetSetting(string settingName)
    {
        if (gameSettings.ContainsKey(settingName))
        {
            return gameSettings[settingName];
        }
        else
        {
            return false; // Default to false if setting doesn't exist.
        }
    }

    public void SetSetting(string settingName, bool value)
    {
        if (gameSettings.ContainsKey(settingName))
        {
            gameSettings[settingName] = value;
        }
        else
        {
            gameSettings.Add(settingName, value);
        }
    }

    public void AdvanceLevel()
    {
        currentLevel++;
        Console.WriteLine($"Level advanced to {currentLevel}");
    }

    public void AddScore(int points)
    {
        playerScore += points;
        Console.WriteLine($"Score increased by {points}. Total score: {playerScore}");
    }

    public void ToggleSound()
    {
        SetSetting("SoundEnabled", !GetSetting("SoundEnabled"));
        Console.WriteLine($"Sound toggled to: {GetSetting("SoundEnabled")}");
    }
    #endregion

}
