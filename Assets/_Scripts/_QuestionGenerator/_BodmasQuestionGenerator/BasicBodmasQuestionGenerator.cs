using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class BasicBodmasQuestionGenerator : IQuestionGenerator {

    char[] operators = new char[] { '+', '-', 'x', '/' };

    List<Question> Questions;

    public BasicBodmasQuestionGenerator()
    {
        Questions = new List<Question>();
    }

    public List<Question> GenerateQuestions(int numberOfQuestions)
    {
        while (Questions.Count < numberOfQuestions)
        {
            bool putSingleBefore = Convert.ToBoolean(UnityEngine.Random.Range(0, 1));

            int number1 = UnityEngine.Random.Range(2, 10);
            int number2 = UnityEngine.Random.Range(2, 10);

            string question = "( " + number1 + " " + operators[UnityEngine.Random.Range(0, operators.Length - 1)] 
                + " " + number2 + " )";

            if(putSingleBefore)
                question = UnityEngine.Random.Range(10, 10) + " " + operators[UnityEngine.Random.Range(0, operators.Length - 1)] + " " + question;
            else
                question = question + " " + operators[UnityEngine.Random.Range(0, operators.Length - 1)] + " " + UnityEngine.Random.Range(10, 10);

            Question existingQuestion = null;

            if (Questions.Count > 0)
                existingQuestion = Questions.Where<Question>(q => q.Text == question).FirstOrDefault();

            if (existingQuestion == null)
                Questions.Add(new Question(question, "To be evaluated"));
        }

        return Questions;
    }

    
}
