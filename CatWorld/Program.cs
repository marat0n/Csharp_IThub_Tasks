using SomeTasks;

Cat cat = new("Chris Hemsworth");

cat.Feed(700);
Console.WriteLine(cat.WellFedPercent);
cat.Pee();

Console.WriteLine(cat.Equals(cat.DeepCopy()));
