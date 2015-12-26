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
        StartCoroutine(ShowLevelObjective());
	}

    private void OnLevelComplete(bool clearedLevel)
    {
        GameController.Instance.IsGamePaused = false;
        if (clearedLevel)
        {
            Popup.SetActive(true);
            AudioManager.Instance.PlaySound(AudioManager.SFX.LEVEL_CLEARED);
            _popupController.ShowPopupForLevelComplete();
            GameController.Instance.IncrementGameLevel();
            
        }
        else
        {
            Popup.SetActive(true);
            _popupController.ShowPopupForLevelFailed();
            AudioManager.Instance.PlaySound(AudioManager.SFX.LEVEL_FAILED);
        }
    }

    IEnumerator ShowLevelObjective()
    {
        Popup.SetActive(true);
        yield return new WaitForEndOfFrame();
        _popupController.ShowPopupForLevelStart();
    }

    void OnDestroy()
    {
        QuestionsScreenController.LevelCompleted -= OnLevelComplete;
    }
}
