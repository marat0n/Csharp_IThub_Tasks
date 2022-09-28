namespace Coffee;

public class Volume
{
    public uint MiliLiters;

    public decimal Liters
    {
        get => MiliLiters / 1000m;
        set => MiliLiters = (ushort)(value / 1000);
    }

    public Volume(uint miliLiters)
    {
        MiliLiters = miliLiters;
    }

    public Volume(decimal liters)
    {
        Liters = liters;
    }

    public static readonly Volume Empty = new (0);
}