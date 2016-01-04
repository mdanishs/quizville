using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChapterIconController : MonoBehaviour {

    [HideInInspector]
    public Chapter ChapterData;
    public Text Name;
    public ScrollRect ScoreScrollRect;
    public GameObject ScoreContent;
    public GameObject LevelListItemPrefab;


    public void SetData(Chapter chapterData)
    {
        ChapterData = chapterData;
        Name.text = ChapterData.ChapterName;
        foreach (LevelData level in ChapterData.Levels)
        {
            GameObject newListItem = Instantiate(LevelListItemPrefab);
            newListItem.transform.SetParent(ScoreContent.transform);
            newListItem.GetComponent<RectTransform>().localScale = Vector3.one;
            newListItem.GetComponent<LevelListItemController>().SetData(level);
        }
    }

    public void OnChapterClicked()
    {
        GameController.Instance.ChapterToPlay = ChapterData;
        GameController.Instance.LoadScene(GameConstants.GAME_PLAY_SCENE);
    }

}
