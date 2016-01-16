using UnityEngine;

public class LevelData {

    public enum LEVEL_STATE
    {
        LOCKED=0,
        UNLOCKED
    }
    
    public int ChapterNumber;
    public int LevelNumber;
    public int NumberOfQuestions;
    public int NumberOfMistakes;
    public float TimeLimit;
    public Question.QUESTION_LEVEL DifficultyLevel;
    public string Objective { get { return CreateLevelObjectiveString(); } }

    private string LevelID
    {
        get
        {
            return (ChapterNumber + "" + LevelNumber);
        }
    }

    public LEVEL_STATE LevelState
    {
        get
        {
            string key = GameConstants.LEVEL_STATE_KEY + LevelID;
            if (PlayerPrefs.HasKey(key))
                return (LEVEL_STATE)PlayerPrefs.GetInt(key);
            return LEVEL_STATE.LOCKED;
        }

        set
        {
            PlayerPrefs.SetInt(GameConstants.LEVEL_STATE_KEY + LevelID, (int)value);
            PlayerPrefs.Save();
        }
    }

    public int NumberOfStarsEarned
    {
        get
        {
            string key = GameConstants.LEVEL_STAR_KEY + LevelID;
            Debug.Log(key);
            if (PlayerPrefs.HasKey(key))
                return PlayerPrefs.GetInt(key);
            return -1;
        }
        set
        {
            if (value >= 0)
            {
                PlayerPrefs.SetInt(GameConstants.LEVEL_STAR_KEY + LevelID, value);
                PlayerPrefs.Save();
            }
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

        //special case for level 1
        if (levelNumber == 1 && LevelState == LEVEL_STATE.LOCKED)
            LevelState = LEVEL_STATE.UNLOCKED;

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
