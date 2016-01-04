using UnityEngine;

public class LevelData {

    private int LevelID
    {
        get
        {
            return int.Parse((ChapterNumber + "" + LevelNumber));
        }
    }

    public int ChapterNumber;
    public int LevelNumber;
    public int NumberOfQuestions;
    public int NumberOfMistakes;
    public float TimeLimit;
    public Question.QUESTION_LEVEL DifficultyLevel;
    public string Objective { get { return CreateLevelObjectiveString(); } }

    public int ScoreEarned
    {
        get
        {
            string key = GameConstants.LEVEL_SCORE_KEY + LevelID;
            if (PlayerPrefs.HasKey(key))
                return PlayerPrefs.GetInt(key);
            return -1;
        }
        set
        {
            if (value >= 0)
                PlayerPrefs.SetInt(GameConstants.LEVEL_SCORE_KEY + LevelID, value);
        }
    }

    public int NumberOfStarsEarned
    {
        get
        {
            string key = GameConstants.LEVEL_STAR_KEY + LevelID;
            if (PlayerPrefs.HasKey(key))
                return PlayerPrefs.GetInt(key);
            return -1;
        }
        set
        {
            if (value >= 0)
                PlayerPrefs.SetInt(GameConstants.LEVEL_STAR_KEY + LevelID, value);
        }
    }

    public LevelData(int chapterNumber, int levelNumber, int numberOfQuestions, int numberOfMistakes,
        float timeLimit, Question.QUESTION_LEVEL difficulty)
    {
        ChapterNumber = chapterNumber;
        LevelNumber = levelNumber;
        NumberOfQuestions = numberOfQuestions;
        NumberOfMistakes = numberOfMistakes;
        TimeLimit = timeLimit;
        DifficultyLevel = difficulty;

    }

    private string CreateLevelObjectiveString()
    {
        string objective = "";

        objective += ("Solve " + NumberOfQuestions + " questions");
        objective += (NumberOfMistakes == 0) ? (" consecutvely ") : (" with only " + NumberOfMistakes + " mistakes allowed") ;
        objective += (TimeLimit > 0) ? (" in " + TimeLimit + ( (TimeLimit == 1) ? " minute." : " minutes.") ) : "." ;

        return objective;
    }

}
