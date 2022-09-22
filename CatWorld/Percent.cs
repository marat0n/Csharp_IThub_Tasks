using System.Collections.ObjectModel;

namespace CatWorld;

public sealed record Percent
{
    private byte _value;
    public byte Value
    {
        get => _value;
        set
        {
            _value = value > 100 ? (byte)100 : value;
            OnSet?.Invoke(this);
        }
    }

    public Percent(byte percent = 0)
    {
        Value = percent;
    }

    public bool TryIncreaseBy(byte value)
    {
        if (_value + value > 100)
        {
            return false;
        }
        else
        {
            _value += value;
            return true;
        }
    }

    public void СarefullyDecreaseBy(byte value)
    {
        if (_value < value) Value = 0;
        else Value -= value;
    }

    public event Action<Percent>? OnSet;

    public static Percent operator -(Percent percent, byte value)
    {
        percent.Value -= value;
        return percent;
    }

    public static Percent operator +(Percent percent, byte value)
    {
        percent.Value += value;
        return percent;
    }

    public static bool operator ==(Percent percent, byte value) =>
        percent.Value == value;

    public static bool operator !=(Percent percent, byte value) =>
        percent.Value != value;

    public override string ToString() => _value.ToString();
}
