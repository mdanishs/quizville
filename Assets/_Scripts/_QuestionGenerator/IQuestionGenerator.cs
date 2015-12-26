using System.Collections.Generic;

public interface IQuestionGenerator
{
    List<Question> GenerateQuestions(int numberOfQuestions);
}