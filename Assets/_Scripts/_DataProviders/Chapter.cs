using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Chapter  {

    public int ChapterNumber { get; set; }
    public string ChapterName { get; set; }
    public List<LevelData> Levels = null;

    public int ClearedLevels
    {
        get
        {
            return Levels.Where(level => level.LevelState == LevelData.LEVEL_STATE.UNLOCKED).DefaultIfEmpty().Count()-1;
        }
    }

    public int TotalStarsEarned
    {
        get
        {
            int sum = 0;
            foreach (LevelData data in Levels)
            {
                sum += (data.NumberOfStarsEarned == -1 ) ? 0  : data.NumberOfStarsEarned;
            }
            return sum;
        }
    }

    public Chapter()
    {
    }

}
