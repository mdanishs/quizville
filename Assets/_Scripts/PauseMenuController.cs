using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuController : MonoBehaviour {

    public Text SoundText;

    public void OnResumeClicked()
    {
        GameController.Instance.IsGamePaused = false;
        this.gameObject.SetActive(false);
    }

    public void OnMusicClicked()
    {
        AudioManager.Instance.IsMute = !AudioManager.Instance.IsMute;

        SoundText.text = (AudioManager.Instance.IsMute) ? "Sounds | OFF" : "Sounds | ON";
    }

    public void OnRestartClicked()
    {
        GameController.Instance.LoadScene(GameConstants.GAME_PLAY_SCENE);
    }

    public void OnQuitGameClicked()
    {
        GameController.Instance.LoadScene(GameConstants.MENU_SCENE);
    }
    
}
