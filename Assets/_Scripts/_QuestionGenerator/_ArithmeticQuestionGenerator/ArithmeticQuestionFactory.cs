using System.Collections.Generic;

public class ArithmeticQuestionFactory: IQuestionFactory {

    //private static ArithmeticQuestionFactory _instance;

    //public static ArithmeticQuestionFactory Instance
    //{
    //    get
    //    {
    //        if(_instance == null)
    //            _instance = new ArithmeticQuestionFactory();

    //        return _instance;
    //    }
    //}

    //private ArithmeticQuestionFactory()
    //{
        
    //}

    public IQuestionGenerator GetGenerator(Question.QUESTION_LEVEL level)
    {
        switch (level)
        {
            case Question.QUESTION_LEVEL.BASIC:
                return new ArithmeticBasicQuestionGenerator();
            case Question.QUESTION_LEVEL.MEDIUM:
                return new ArithmeticMediumQuestionGenerator();
            case Question.QUESTION_LEVEL.HARD:
                return new ArithmeticHardQuestionGenerator();
            default:
                break;
        }
        
        return null;
    }


    

}
