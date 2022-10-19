using QuestionsAnswers;

string questionsJson = File.ReadAllText(@"D:\sample_questions.json");

var questions = new JsonParser().Parse(questionsJson);

var questionsNumber = questions.Count;
var correctAnswersNumber = 0;
foreach (var question in questions)
{
    Console.WriteLine(question);

    Console.Write("Your answer is: ");
    var answer = int.Parse(Console.ReadLine()!);

    if (answer == question.CorrectAnswerID)
    {
        correctAnswersNumber++;

        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Correct!");
        Console.ForegroundColor = oldColor;
    }
    else
    {
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Wrong! Real answer is {question.CorrectAnswerID}.");
        Console.ForegroundColor = oldColor;
    }

    Console.WriteLine("___________________\n");
}

Console.WriteLine($"Percent of correct answers: {((decimal)correctAnswersNumber / questionsNumber * 100):G29}%");
