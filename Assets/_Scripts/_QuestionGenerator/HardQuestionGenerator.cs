using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class HardQuestionGenerator : IQuestionGenerator {

    char[] operations = new char[] { 'x', '/' };

    public List<Question> GenerateQuestions(int numberOfQuestions)
    {
        List<Question> questions = new List<Question>();

        int questionsCount = 0;
        while (questionsCount != numberOfQuestions)
        {
            int number1 = Random.Range(10, 1000);
            int number2 = Random.Range(-100, 100);
            char operation = operations[Random.Range(0, operations.Length - 1)];

            string strQuestion = "Solve " + number1 + " " + operation + " " + number2 + ".";

            Question existingQuestion = null;
            if (questions.Count > 0)
            {
                existingQuestion = questions.Where<Question>(q => q.Text == strQuestion).FirstOrDefault();
            }

            if (existingQuestion == null)
            {
                Question question = new Question(strQuestion, GetAnswer(number1, number2, operation));
                questions.Add(question);
                questionsCount++;
            }
        }

        return questions;
    }

    string GetAnswer(int number1, int number2, char operation)
    {
        float answer = 0;
        if (operation == '+')
        {
            answer = number1 + number2;
        }
        else if (operation == '-')
        {
            answer = number1 - number2;
        }
        else if (operation == '/')
        {
            answer = (float)number1 / number2;
        }
        else if (operation == 'x')
        {
            answer = number1 * number2;
        }

        return answer.ToString();
    }
}
