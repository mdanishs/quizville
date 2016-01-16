using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChapterSelectController : MonoBehaviour {

    public GameObject ScrollRect;
    public GameObject Content;
    public GameObject ChapterPrefab;
    public GameObject ComingSoon;

    void Start () {
        
        List<Chapter> chapters = ChapterDataProvider.Instance.GetAll();

        foreach (Chapter chapter in chapters)
        {
            GameObject newObject = Instantiate(ChapterPrefab);
            newObject.transform.SetParent(Content.transform);
            newObject.GetComponent<RectTransform>().localScale = Vector3.one;
            newObject.GetComponent<ChapterIconController>().SetData(chapter);
        }

        GameObject comingSoonObj = Instantiate(ComingSoon);
        comingSoonObj.transform.SetParent(Content.transform);
        comingSoonObj.GetComponent<RectTransform>().localScale = Vector3.one;

    }
	
	public void OnBackClicked()
    {
        GameController.Instance.LoadScene(GameConstants.MENU_SCENE);
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }

}
