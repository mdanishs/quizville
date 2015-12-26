using System.Collections.Generic;

public class QuestionFactory {

    private static QuestionFactory _instance;

    public static QuestionFactory Instance
    {
        get
        {
            if(_instance == null)
                _instance = new QuestionFactory();

            return _instance;
        }
    }

    private QuestionFactory()
    {
        
    }

    public IQuestionGenerator GetGenerator(Question.QUESTION_LEVEL level)
    {
        switch (level)
        {
            case Question.QUESTION_LEVEL.BASIC:
                return new BasicQuestionGenerator();
            case Question.QUESTION_LEVEL.MEDIUM:
                break;
            case Question.QUESTION_LEVEL.HARD:
                break;
            default:
                break;
        }
        
        return null;
    }


    

}
