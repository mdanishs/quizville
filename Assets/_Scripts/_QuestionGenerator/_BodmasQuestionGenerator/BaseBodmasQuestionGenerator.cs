using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class BaseBodmasQuestionGenerator : IQuestionGenerator {

    public char[] operators = new char[] { '-', '+', 'x' };

    public abstract List<Question> GenerateQuestions(int numberOfQuestions);

    /// <summary>
    /// Generates the answer using shunting-yard algorithm for infix expression
    /// </summary>
    /// <param name="question">The bodmas question in a single string</param>
    /// <returns>The evaluated answer as string</returns>
    public virtual string GenerateAnswer(string question)
    {
        Stack<string> operatorStack = new Stack<string>();
        Stack<string> operandStack = new Stack<string>();

        int currentIndex = 0;

        while(currentIndex < question.Length)
        {
            if (question[currentIndex] == '(')
            {
                operatorStack.Push(question[currentIndex].ToString());
            }
            else if (char.IsNumber(question[currentIndex]))
            {
                string number = "";
                while (currentIndex < question.Length && char.IsNumber(question[currentIndex]))
                {
                    number += question[currentIndex];
                    currentIndex++;
                }
                operandStack.Push(number);
                continue;
            }
            else if(question[currentIndex] == ')')
            {
                string op = operatorStack.Pop();
                while(op != "(")
                {
                    int num2 = int.Parse(operandStack.Pop());
                    int num1 = int.Parse(operandStack.Pop());
                    operandStack.Push(EvaluateOperator(num1, num2, op).ToString());
                    op = operatorStack.Pop();
                }
            }
            else if (Array.Exists<char>(operators, op => op == question[currentIndex]))
            {
                if (operatorStack.Count > 0)
                {
                    while (Array.IndexOf<char>(operators, question[currentIndex]) < Array.IndexOf<char>(operators, char.Parse(operatorStack.Peek())))
                    {
                        string op = operatorStack.Pop();
                        int num1 = int.Parse(operandStack.Pop());
                        int num2 = int.Parse(operandStack.Pop());
                        operandStack.Push(EvaluateOperator(num1, num2, op).ToString());
                    }
                    operatorStack.Push(question[currentIndex].ToString());
                }
                else
                    operatorStack.Push(question[currentIndex].ToString());
            }
            currentIndex++;
        }

        while (operatorStack.Count > 0)
        {
            string op = operatorStack.Pop();
            int num2 = int.Parse(operandStack.Pop());
            int num1= int.Parse(operandStack.Pop());
            operandStack.Push(EvaluateOperator(num1, num2, op).ToString());
        }

        return operandStack.Pop();
    }

    int EvaluateOperator(int num1, int num2, string op)
    {
        switch (op)
        {
            case "+":
                return num1 + num2;
            case "-":
                return num1 - num2;
            case "/":
                return num1 / num2;
            case "x":
                return num1 * num2;
            
        }
        return 0;
    }
}
