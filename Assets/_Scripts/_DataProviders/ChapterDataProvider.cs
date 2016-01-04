using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;

public class ChapterDataProvider : IDataProvider<Chapter> {

    private static ChapterDataProvider _instance;
    private List<Chapter> _allChapters;

    public static ChapterDataProvider Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ChapterDataProvider();
            return _instance;
        }
    }

    private ChapterDataProvider()
    {
        TextAsset levelsFile = Resources.Load(GameConstants.LEVELS_FILE) as TextAsset;
        JSONNode allChapters = JSON.Parse(levelsFile.text);
        _allChapters = new List<Chapter>();

        foreach(JSONNode chapter in allChapters.Children)
        {
            Chapter newChapter = new Chapter();
            newChapter.ChapterName = chapter["ChapterName"];
            
            List<LevelData> levels = new List<LevelData>();

            foreach(JSONNode level in chapter["Levels"].Children)
            {
                LevelData config = new LevelData(
                    newChapter.ChapterNumber,
                    level["LevelNumber"].AsInt,
                    level["NoQuestions"].AsInt,
                    level["NoMistakes"].AsInt,
                    level["Time"].AsFloat,
                    (Question.QUESTION_LEVEL)level["Difficulty"].AsInt);
                levels.Add(config);
            }
            newChapter.Levels = levels;
            _allChapters.Add(newChapter);
        }

    }

    public List<Chapter> GetAll()
    {
        return _allChapters;
    }

    public Chapter GetOne(int chapterNumber)
    {
        try
        {
            return _allChapters[chapterNumber - 1];
        }
        catch (System.IndexOutOfRangeException)
        {
            return null;
        }
    }
	

    public static LevelData GetLevelToPlayForChapter(Chapter chapter)
    {
        Chapter currentChapter = chapter;
        return (currentChapter.LastClearedLevel == -1) ? currentChapter.Levels[0] : currentChapter.Levels[currentChapter.LastClearedLevel];
    }
}
