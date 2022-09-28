namespace Coffee;

public abstract class Drink
{
    public string Name { get; private set; } = string.Empty;

    public Volume Volume { get; set; }

    public Drink(string name, Volume? volume = null)
    {
        Name = name;
        Volume = volume ?? new Volume(0.3m);
    }
}