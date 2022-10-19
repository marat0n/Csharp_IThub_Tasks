namespace QuestionsAnswers;

public class Answer
{
    public int ID { get; set; }
    public string AnswerText { get; set; }

    public Answer(int id = 0, string? answerText = null)
    {
        ID = id;
        AnswerText = answerText ?? string.Empty;
    }

    public override string ToString() => AnswerText;
}