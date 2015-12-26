using UnityEngine;
using System.Collections;

public class InfoPopupController : BasePopupController {

	void Start()
    {
        GetComponent<CanvasGroup>().alpha = 0;

        RectTransform canvasTransform = ParentCanvas.GetComponent<RectTransform>();
        Overlay.GetComponent<RectTransform>().sizeDelta = new Vector2(canvasTransform.rect.width, canvasTransform.rect.height * 1.25f);

        Overlay.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    public void OnContinueClicked()
    {
        HidePopup();
        StartCoroutine( DeActivate(1f, null));
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }
}
