using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScenePopup : BasePopupController {

    public GameObject ContinueButton, QuitButton;
    public GameObject YesButton, NoButton;

    /**** Stars Panel ****/
    public GameObject StarsPanel;
    public GameObject Star1, Star2, Star3;

    public static event System.Action ContinueClicked;

    void Start()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        QuitButton.SetActive(false);

        RectTransform canvasTransform = ParentCanvas.GetComponent<RectTransform>();
        Overlay.GetComponent<RectTransform>().sizeDelta = new Vector2(canvasTransform.rect.width, canvasTransform.rect.height*1.25f);

        Overlay.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    public void ShowPopupForLevelStart(string description)
    {
        ContinueButton.SetActive(true);
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        Description.gameObject.SetActive(true);
        StarsPanel.SetActive(false);

        Heading.text = "OBJECTIVE";
        Description.text = description;
        ShowPopup();
    }

    public void ShowPopupForLevelFailed()
    {
        YesButton.SetActive(true);
        NoButton.SetActive(true);
        ContinueButton.SetActive(false);
        Description.gameObject.SetActive(true);
        StarsPanel.SetActive(false);

        Heading.text = "LEVEL FAILED";
        Description.text = "\"Practice makes a man perfect\". Do you want to retry?";
        ShowPopup();
    }

    public void ShowPopupForLevelComplete(int numberOfStars)
    {
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        ContinueButton.SetActive(true);
        QuitButton.SetActive(true);
        Description.gameObject.SetActive(false);
        StarsPanel.SetActive(true);

        Heading.text = "LEVEL COMPLETE";
        ShowPopup();
        StartCoroutine(ShowStars(numberOfStars));
    }

    IEnumerator ShowStars(int starsCount)
    {
        yield return new WaitForSeconds(1f);

        if (starsCount >= 1)
        {
            Star1.SetActive(true);
            AudioManager.Instance.PlaySound(AudioManager.SFX.STAR);
            yield return new WaitForSeconds(0.5f);
        }

        if (starsCount >= 2)
        {
            Star2.SetActive(true);
            AudioManager.Instance.PlaySound(AudioManager.SFX.STAR);
            yield return new WaitForSeconds(0.5f);
        }

        if (starsCount >= 3)
        {
            Star3.SetActive(true);
            AudioManager.Instance.PlaySound(AudioManager.SFX.STAR);
        }

    }

    public void OnContinueClicked()
    {
        HidePopup();
        StartCoroutine(DeActivate(1f, () => { if (ContinueClicked != null) ContinueClicked(); }));
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
        
        StarsPanel.SetActive(false);
        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
    }

    public void OnQuitButtonClicked()
    {
        HidePopup();
        StartCoroutine(DeActivate(1f, () => { GameController.Instance.LoadScene(GameConstants.LEVEL_SELECT_SCENE); }));
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
        StartCoroutine(DeActivate(1f, () => { GameController.Instance.LoadScene(GameConstants.CHAPTER_SELECT_SCENE); }));
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }
}
