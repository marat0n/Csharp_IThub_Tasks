namespace QuestionsAnswers;

public class Question
{
    public int ID { get; set; }
    public string QuestionText { get; set; }
    public int CorrectAnswerID { get; set; }
    public List<Answer> Answers { get; set; }

    public Question(int id = 0, string? questionText = null, List<Answer>? answers = null)
    {
        ID = id;
        QuestionText = questionText ?? string.Empty;
        Answers = answers ?? new();
    }

    public override string ToString()
    {
        var result = QuestionText;
        foreach (var answer in Answers)
        {
            result += $"\n{answer.ID}>\t{answer}";
        }

        return result;
    }
}
