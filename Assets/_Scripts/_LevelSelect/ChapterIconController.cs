using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChapterIconController : MonoBehaviour {

    [HideInInspector]
    public Chapter ChapterData;
    public Text Name;
    public Text LevelsCount;
    public Text StarsCount;
    
    public void SetData(Chapter chapterData)
    {
        ChapterData = chapterData;
        Name.text = ChapterData.ChapterName;
        LevelsCount.text = chapterData.ClearedLevels.ToString();
        StarsCount.text = chapterData.TotalStarsEarned + "/" + chapterData.Levels.Count * 3;
    }

    public void OnChapterClicked()
    {
        GameController.Instance.ChapterToPlay = ChapterData;
        GameController.Instance.LoadScene(GameConstants.LEVEL_SELECT_SCENE);
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }

}
