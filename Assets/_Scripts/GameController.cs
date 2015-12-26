using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton instance to control the gameflow and game state
/// </summary>
public class GameController {

    private static GameController _instance;

    public LevelConfig LevelToPlay
    {
        get
        {
            int levelNumber = PlayerPrefs.GetInt(GameConstants.CURRNET_LEVEL_KEY);
            if (levelNumber == 0)
                levelNumber = 1;
            return LevelDataProvider.Instance.GetLevel(levelNumber);
        }
    }

    public bool IsFTUE
    {
        get
        {
            bool check = (PlayerPrefs.GetInt(GameConstants.FTUE_KEY) == 0);
            if (check)
            {
                PlayerPrefs.SetInt(GameConstants.FTUE_KEY,1);
                PlayerPrefs.Save();
            }
            return check;
        }
    }
    public bool IsGamePaused;

    private GameController()
    {
        if (GameConstants.CLEAR_DATA_ON_PLAY)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
        IsGamePaused = true;
    }

    public static GameController Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameController();
            return _instance;
        }
    }

    public void LoadScene(string scene)
    {
        Application.LoadLevel(scene);
    }

    public void IncrementGameLevel()
    {
        if(LevelToPlay.LevelNumber < LevelDataProvider.Instance.TotalLevels)
        {
            PlayerPrefs.SetInt(GameConstants.CURRNET_LEVEL_KEY, LevelToPlay.LevelNumber + 1);
            PlayerPrefs.Save();
        }
    }

}
