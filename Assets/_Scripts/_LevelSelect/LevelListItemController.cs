using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelListItemController : MonoBehaviour {

    [SerializeField]
    Sprite StartOn;
    [SerializeField]
    Sprite StartOff;

    public Text LevelNumber;
    public Text Score;
    public Image [] Stars;


    public void SetData(LevelData levelData) 
    {
        LevelNumber.text = "Level " + levelData.LevelNumber;
        Score.text = (levelData.ScoreEarned == -1) ? "NOT PLAYED" : levelData.ScoreEarned.ToString();
        for (int i = 0; i < levelData.NumberOfStarsEarned-1; i++)
        {
            Stars[i].sprite = StartOn;
        }
    }
	
}
