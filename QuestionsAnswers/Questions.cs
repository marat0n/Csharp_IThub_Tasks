namespace QuestionsAnswers;

public class Questions
{
    public List<Question> QuestionsList { get; set; }

    public Questions(List<Question>? questionsList = null)
    {
        QuestionsList = questionsList ?? new();
    }
}
