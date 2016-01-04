using UnityEngine;
using System.Collections.Generic;

public class Chapter  {

    public int ChapterNumber { get; set; }
    public string ChapterName { get; set; }
    public List<LevelData> Levels = null;

    public int LastClearedLevel
    {
        get
        {
            if (PlayerPrefs.HasKey(GameConstants.LAST_CLEARED_LEVEL + ChapterNumber))
                return PlayerPrefs.GetInt(GameConstants.LAST_CLEARED_LEVEL + ChapterNumber);
            else
                return -1;
        }
    }

    public Chapter()
    {
    }

}
