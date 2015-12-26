

public class Question {

    public enum QUESTION_LEVEL
    {
        BASIC=0,
        MEDIUM,
        HARD
    }

    public string Text { get; set; }
    public string Answer { get; set; }

    public Question(string question, string answer)
    {
        Text = question;
        Answer = answer;
    }

    public override string ToString()
    {
        return Text + ", " + Answer;
    }
}
