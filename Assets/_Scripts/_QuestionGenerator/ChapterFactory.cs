using UnityEngine;
using System.Collections;

public class ChapterFactory  {

    private static ChapterFactory _instance;
    public static ChapterFactory Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ChapterFactory();
            return _instance;
        }
    }

    private ChapterFactory()
    {

    }

    public IQuestionFactory GetQuestionGeneratorForChapter(GameConstants.CHAPTERS chapter)
    {


        switch (chapter)
        {
            case GameConstants.CHAPTERS.ARITHMETIC:
                return (IQuestionFactory) new ArithmeticQuestionFactory();
            case GameConstants.CHAPTERS.BODMAS:
                return (IQuestionFactory) new BodmasQuestionFactory();
            default:
                return null;
        }

    }
	
}
