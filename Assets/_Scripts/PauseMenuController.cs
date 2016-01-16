using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuController : MonoBehaviour {

    public Text SoundText;

    public void OnResumeClicked()
    {
        GameController.Instance.IsGamePaused = false;
        this.gameObject.SetActive(false);
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }

    public void OnMusicClicked()
    {
        AudioManager.Instance.IsMute = !AudioManager.Instance.IsMute;

        SoundText.text = (AudioManager.Instance.IsMute) ? "Sounds | OFF" : "Sounds | ON";
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }

    public void OnRestartClicked()
    {
        GameController.Instance.LoadScene(GameConstants.GAME_PLAY_SCENE);
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }

    public void OnQuitGameClicked()
    {
        GameController.Instance.LoadScene(GameConstants.LEVEL_SELECT_SCENE);
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }
    
}
