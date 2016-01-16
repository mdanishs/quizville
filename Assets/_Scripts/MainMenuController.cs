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
        
        SetSoundButtonText();
    }

    public void OnPlayClicked()
    {
        GameController.Instance.LoadScene(GameConstants.CHAPTER_SELECT_SCENE);
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }

    public void OnSoundButtonClicked()
    {
        AudioManager.Instance.IsMute = !AudioManager.Instance.IsMute;
        SetSoundButtonText();
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }

    public void OnInfoClicked()
    {
        StartCoroutine(ShowInfoPopup());
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }

    public void OnQuitGameClicked()
    {
        Application.Quit();
    }

    void SetSoundButtonText()
    {
        if (AudioManager.Instance.IsMute)
            TxtSoundButton.text = "SOUNDS | OFF";
        else
            TxtSoundButton.text = "SOUNDS | ON";
    }
    
    IEnumerator ShowInfoPopup()
    {
        InfoPopup.gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        InfoPopup.ShowPopup();

    }
	
}
