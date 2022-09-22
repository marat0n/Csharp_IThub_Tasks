namespace CatWorld;

public sealed record Weight
{
    public ushort Grams;

    public byte Kilos
    {
        get => (byte)(Grams / 1000);
        set => Grams = (ushort)(value * 1000);
    }

    public Weight(ushort grams)
    {
        Grams = grams;
    }
}

