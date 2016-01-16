using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelIconController : MonoBehaviour {
    
    public Text LevelNumber;
    public Image [] Stars;

    LevelData _levelData;

    public void SetData(LevelData levelData) 
    {
        _levelData = levelData;
        LevelNumber.text = levelData.LevelNumber.ToString();
        for (int i = 0; i < levelData.NumberOfStarsEarned; i++)
        {
            Stars[i].gameObject.SetActive(true);
        }
    }

    public void OnIconClick()
    {
        GameController.Instance.LevelToPlay = _levelData;
        GameController.Instance.LoadScene(GameConstants.GAME_PLAY_SCENE);
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }
	
}
