using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelSelectController : MonoBehaviour {

    public GameObject ScrollRect;
    public GameObject Content;
    public GameObject ChapterPrefab;

	void Start () {
        
        List<Chapter> chapters = ChapterDataProvider.Instance.GetAll();

        foreach (Chapter chapter in chapters)
        {
            GameObject newObject = Instantiate(ChapterPrefab);
            newObject.transform.SetParent(Content.transform);
            newObject.GetComponent<RectTransform>().localScale = Vector3.one;
            newObject.GetComponent<ChapterIconController>().SetData(chapter);
        }

	}
	
	public void OnBackClicked()
    {
        GameController.Instance.LoadScene(GameConstants.MENU_SCENE);
    }

}
