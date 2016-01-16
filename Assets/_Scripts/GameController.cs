using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton instance to control the gameflow and game state
/// </summary>
public class GameController {

    private static GameController _instance;

    public Chapter ChapterToPlay { get; set; }
    public LevelData LevelToPlay { get; set; }

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

        if (scene == GameConstants.GAME_PLAY_SCENE)
            AudioManager.Instance.AdjustBackgroundVolume(-0.1f);
        else
            AudioManager.Instance.AdjustBackgroundVolume(0.9f);

        Application.LoadLevel(scene);
    }
    
}
