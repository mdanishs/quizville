using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenuController : MonoBehaviour {

    public Text TxtSoundButton;
    public GameObject FTUEBox;
    public GameObject ProgressBox;
    public Slider ProgressBar;
    public InfoPopupController InfoPopup;

    void Start()
    {
        if (GameController.Instance.IsFTUE)
        {
            FTUEBox.SetActive(true);
        }
        else
        {
            ProgressBox.SetActive(true);
            ProgressBar.value = GameController.Instance.LevelToPlay.LevelNumber;
        }

        SetSoundButtonText();

        AudioManager.Instance.AdjustBackgroundVolume(1f);
    }

    public void OnPlayButtonClicked()
    {
        GameController.Instance.LoadScene(GameConstants.GAME_PLAY_SCENE);
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }

    public void OnSoundButtonClicked()
    {
        AudioManager.Instance.IsMute = !AudioManager.Instance.IsMute;
        SetSoundButtonText();
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }

    void SetSoundButtonText()
    {
        if (AudioManager.Instance.IsMute)
            TxtSoundButton.text = "SOUNDS | OFF";
        else
            TxtSoundButton.text = "SOUNDS | ON";
    }

    public void OnInfoClicked()
    {
        StartCoroutine(ShowInfoPopup());
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }

    IEnumerator ShowInfoPopup()
    {
        InfoPopup.gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        InfoPopup.ShowPopup();

    }
	
}
