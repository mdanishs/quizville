using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectController : MonoBehaviour {

    public int LevelsInRow;

    public Text StarsCount;

    public GameObject LevelIconsPanel;
    public GameObject LevelRowPrefab;
    public GameObject LevelIconPrefab;

    Chapter _chapterData;

	// Use this for initialization
	void Start ()
    {
        
        _chapterData = GameController.Instance.ChapterToPlay;

        StarsCount.text = _chapterData.TotalStarsEarned + "/" + _chapterData.Levels.Count * 3;

        int levelIndex = 0;

        for (int i = 0; i < _chapterData.Levels.Count/LevelsInRow; i++)
        {
            GameObject newRow = Instantiate(LevelRowPrefab);
            newRow.transform.SetParent(LevelIconsPanel.transform);
            newRow.GetComponent<RectTransform>().localScale = Vector3.one;

            for (int j = 0; j < LevelsInRow; j++)
            {
                GameObject newIcon = Instantiate(LevelIconPrefab);
                newIcon.transform.SetParent(newRow.transform);
                newIcon.GetComponent<RectTransform>().localScale = Vector3.one;

                LevelIconController controller = newIcon.GetComponent<LevelIconController>();

                LevelData levelData = _chapterData.Levels[levelIndex];
                controller.SetData(levelData);

                if (levelData.LevelState == LevelData.LEVEL_STATE.LOCKED && levelData.LevelNumber != 1)
                {
                    newIcon.GetComponent<Button>().interactable = false;
                    controller.LevelNumber.color = new Color(0, 0, 0, 0.5f);
                }
                levelIndex++;
            }
        }
	}

    public void OnBackClicked()
    {
        GameController.Instance.LoadScene(GameConstants.CHAPTER_SELECT_SCENE);
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
    }
	
}
