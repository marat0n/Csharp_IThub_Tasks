namespace System;

public struct UInt128
{
    private UInt64 _left;
    private UInt64 _right;

    public static UInt128 MinValue => new (0x0000_0000_0000_0000, 0);
    public static UInt128 MaxValue => new (0xFFFF_FFFF_FFFF_FFFF, 0xFFFF_FFFF_FFFF_FFFF);

    public UInt128()
    {
        _left = 0;
        _right = 0;
    }

    public UInt128(UInt64 l)
    {
        _left = 0;
        _right = l;
    }

    public UInt128(UInt64 l1, UInt64 l2)
    {
        var maxv = UInt64.MaxValue;
        var diff = maxv - l1;
        
        if (diff < l2)
        {
            _left = l2 - diff;
            _right = maxv;
        }
        else
        {
            _left = 0;
            _right = l1+l2;
        }
    }

    public static UInt128 operator +(UInt128 ll1, UInt128 ll2)
    {
        return ll1 - ~ll2 - 1;
    }

    public static UInt128 operator ~(UInt128 value)
    {
        value._left = ~value._left;
        value._right = ~value._right;
        return value;
    }

    public static UInt128 operator -(UInt128 ll1, UInt128 ll2)
    {
        ulong lower = ll1._right - ll2._right;
        ulong borrow = (lower > ll1._right) ? 1UL : 0UL;

        ulong upper = ll1._left - ll2._left - borrow;
        return new UInt128(upper, lower);
    }

    public byte[] GetBytes()
    {
        var result = new byte[16];
        BitConverter.GetBytes(_left).CopyTo(result, 0);
        BitConverter.GetBytes(_right).CopyTo(result, 8);
        return result;
    }

    public static implicit operator UInt128(UInt64 impLong) => new (impLong);
}
