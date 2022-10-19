using System.Text.Json;

namespace QuestionsAnswers;

public class JsonParser
{
    public List<Question> Parse(string json) =>
        JsonSerializer.Deserialize<Questions>(json)!.QuestionsList;
}
