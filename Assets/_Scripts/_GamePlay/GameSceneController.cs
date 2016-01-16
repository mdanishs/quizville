using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameSceneController : MonoBehaviour {

    public GameObject Popup;
    
    GameScenePopup _popupController;
    
    void Awake()
    {
        QuestionsScreenController.LevelCompleted += OnLevelComplete;
    }

   void Start () {

        _popupController = Popup.GetComponent<GameScenePopup>();
        LevelData level = GameController.Instance.LevelToPlay;
        StartCoroutine(ShowLevelObjective(level.Objective));
	}

    private void OnLevelComplete(bool clearedLevel, int stars)
    {
        GameController.Instance.IsGamePaused = false;
        if (clearedLevel)
        {
            Popup.SetActive(true);
            AudioManager.Instance.PlaySound(AudioManager.SFX.LEVEL_CLEARED);
            _popupController.ShowPopupForLevelComplete(stars);

            //increment level
            LevelData currentLevel = GameController.Instance.LevelToPlay;
            currentLevel.NumberOfStarsEarned = stars;
            Chapter currentChapter = GameController.Instance.ChapterToPlay;

            if (currentLevel.LevelNumber < currentChapter.Levels.Count)
            {
                LevelData levelData = currentChapter.Levels[currentLevel.LevelNumber];
                levelData.LevelState = LevelData.LEVEL_STATE.UNLOCKED;
                GameController.Instance.LevelToPlay = levelData;
            }
        }
        else
        {
            Popup.SetActive(true);
            _popupController.ShowPopupForLevelFailed();
            AudioManager.Instance.PlaySound(AudioManager.SFX.LEVEL_FAILED);
        }
    }

    IEnumerator ShowLevelObjective(string objective)
    {
        Popup.SetActive(true);
        yield return new WaitForEndOfFrame();
        _popupController.ShowPopupForLevelStart(objective);
    }

    void OnDestroy()
    {
        QuestionsScreenController.LevelCompleted -= OnLevelComplete;
    }
}
