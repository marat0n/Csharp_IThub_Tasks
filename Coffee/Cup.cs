namespace Coffee;

public sealed class Cup
{
    public MugCover? Cover;

    public Drink? Drink { get; private set; }

    public Color Color { get; init; }

    public Volume CupVolume { get; init; }

    public Volume DrinkVolume {
        get => Drink?.Volume ?? Volume.Empty;
        private set
        {
            if (Drink is not null)
                Drink.Volume = value;
        }
    }

    public string? OwnerName { get; private set; }

    public Cup(MugCover? cover = null, Drink? drink = null, Color? color = null, Volume? volume = null, string? owner = null)
    {
        Cover = cover;
        Drink = drink;
        Color = color ?? Colors.White;
        CupVolume = volume ?? new Volume(0.3m);
        OwnerName = owner;
    }

    public void PourDrink(Drink drink)
    {
        if (Drink is null || DrinkVolume == Volume.Empty)
            Drink = drink;
    }
}
