using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;

public class LevelDataProvider {

    private static LevelDataProvider _instance;
    private List<LevelConfig> _allLevels;

    public static LevelDataProvider Instance
    {
        get
        {
            if (_instance == null)
                _instance = new LevelDataProvider();
            return _instance;
        }
    }

    public int TotalLevels;

    private LevelDataProvider()
    {
        TextAsset levels = Resources.Load(GameConstants.LEVELS_FILE) as TextAsset;
        JSONNode allLevels = JSON.Parse(levels.text);
        _allLevels = new List<LevelConfig>();

        foreach(JSONNode level in allLevels.Children)
        {
            LevelConfig config = new LevelConfig(
                level["LevelNumber"].AsInt,
                level["NoQuestions"].AsInt,
                level["NoMistakes"].AsInt,
                level["Time"].AsFloat,
                (Question.QUESTION_LEVEL)level["Difficulty"].AsInt);
            _allLevels.Add(config);
        }
        TotalLevels = _allLevels.Count;
    }

    public List<LevelConfig> GetAllLevels()
    {
        return _allLevels;
    }

    public LevelConfig GetLevel(int levelNumber)
    {
        try
        {
            return _allLevels[levelNumber - 1];
        }
        catch (System.IndexOutOfRangeException)
        {

            return null;
        }
    }
	
}
