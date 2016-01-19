
using System;

public class BodmasQuestionFactory : IQuestionFactory {

    private static BodmasQuestionFactory _instance;

    
    public IQuestionGenerator GetGenerator(Question.QUESTION_LEVEL difficultyLevel)
    {
        switch (difficultyLevel)
        {
            case Question.QUESTION_LEVEL.BASIC:
                return new BasicBodmasQuestionGenerator();
            case Question.QUESTION_LEVEL.MEDIUM:
                return new MediumBodmasQuestionGenerator();
            case Question.QUESTION_LEVEL.HARD:
                return new HardBodmasQuestionGenerator();
            default:
                return null;
        }
    }
    
}
