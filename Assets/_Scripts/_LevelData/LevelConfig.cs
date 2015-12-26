
public class LevelConfig {

    public int LevelNumber;
    public int NumberOfQuestions;
    public int NumberOfMistakes;
    public float TimeLimit;
    public Question.QUESTION_LEVEL DifficultyLevel;
    public string Objective { get { return CreateLevelObjectiveString(); } }

    public LevelConfig(int levelNumber, int numberOfQuestions, int numberOfMistakes,
        float timeLimit, Question.QUESTION_LEVEL difficulty)
    {
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
