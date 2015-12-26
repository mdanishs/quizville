using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScenePopup : BasePopupController {

    public GameObject ContinueButton, QuitButton;
    public GameObject YesButton, NoButton;

    public static event System.Action ContinueClicked;

    void Start()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        QuitButton.SetActive(false);

        RectTransform canvasTransform = ParentCanvas.GetComponent<RectTransform>();
        Overlay.GetComponent<RectTransform>().sizeDelta = new Vector2(canvasTransform.rect.width, canvasTransform.rect.height*1.25f);

        Overlay.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    public void ShowPopupForLevelStart()
    {
        ContinueButton.SetActive(true);
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        Heading.text = "OBJECTIVE";
        Description.text = GameController.Instance.LevelToPlay.Objective;
        ShowPopup();
    }

    public void ShowPopupForLevelFailed()
    {

        YesButton.SetActive(true);
        NoButton.SetActive(true);
        ContinueButton.SetActive(false);
        Heading.text = "LEVEL FAILED";
        Description.text = "\"Practice makes a man perfect\". Do you want to retry?";
        ShowPopup();
    }

    public void ShowPopupForLevelComplete()
    {
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        ContinueButton.SetActive(true);
        QuitButton.SetActive(true);

        Heading.text = "CONGRATULATIONS";
        Description.text = "Wohoo! Good Job. Continue to the next level?";
        ShowPopup();
    }

    public void OnContinueClicked()
    {
        HidePopup();
        StartCoroutine(DeActivate(1f, () => { if (ContinueClicked != null) ContinueClicked(); }));
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }

    public void OnQuitButtonClicked()
    {
        HidePopup();
        StartCoroutine(DeActivate(1f, () => { GameController.Instance.LoadScene(GameConstants.MENU_SCENE); }));
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }

    public void OnYesClicked()
    {
        HidePopup();
        GameController.Instance.IsGamePaused = true;
        StartCoroutine(DeActivate(1f, () => { GameController.Instance.LoadScene(GameConstants.GAME_PLAY_SCENE); }));
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }

    public void OnNoClicked()
    {
        HidePopup();
        StartCoroutine(DeActivate(1f, () => { GameController.Instance.LoadScene(GameConstants.MENU_SCENE); }));
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }
}
