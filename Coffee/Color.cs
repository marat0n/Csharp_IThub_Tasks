namespace Coffee;

public sealed class Color
{
    private readonly byte[] Value;

    public Color(byte r, byte g, byte b)
    {
        Value = new byte[] { r, g, b };
    }

    public Color()
    {
        Value = new byte[3];
    }

    public byte R
    {
        get => Value[0];
        set => Value[0] = value;
    }

    public byte G
    {
        get => Value[1];
        set => Value[1] = value;
    }

    public byte B
    {
        get => Value[2];
        set => Value[2] = value;
    }
}