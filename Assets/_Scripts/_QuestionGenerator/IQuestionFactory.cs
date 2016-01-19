using System.Collections;

public interface IQuestionFactory {

    IQuestionGenerator GetGenerator(Question.QUESTION_LEVEL difficultyLevel);

}
