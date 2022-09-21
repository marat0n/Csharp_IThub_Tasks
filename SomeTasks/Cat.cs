namespace SomeTasks;

public sealed class Cat
{
    public static int Count { get; private set; }

    public readonly string Name;

    public CatColor Color { get; private set; }

    public Weight Weight { get; private set; }

    private byte _meowedInARow;
    public byte MeowedInARow
    {
        get => _meowedInARow;
        private set
        {
            _meowedInARow = value;
            if (_meowedInARow > 100) IsAlive = false;
        }
    }

    public const byte EyesCount = 2;

    public readonly Weight FoodWeightStandard = new(1000);

    public int TotalFoodEaten { get; private set; }

    private bool _isAlive;
    public bool IsAlive
    {
        get => _isAlive;
        private set
        {
            if (!value)
            {
                _isAlive = value;
                if (!_isAlive)
                    Console.WriteLine($"Cat {Name} died.......");
                Count--;
            }
        }
    }

    public bool HasTail;

    public Percent WellFedPercent { get; private set; }

    public Cat(
        string name,
        ushort weightAsGrams = 5000,
        bool isAlive = true,
        bool hasTail = true,
        CatColor color = CatColor.Orange
    ) {
        Name           = name;
        Weight         = new Weight(weightAsGrams);
        HasTail        = hasTail;
        _isAlive       = isAlive;
        WellFedPercent = new(1);
        Color          = color;

        WellFedPercent.OnSet += (percent) => _ = percent == 0 ? IsAlive = false:
                                                                IsAlive = true;

        Count++;
        Console.WriteLine($"New cat created with weight {Weight}!");
    }

    ~Cat() => Count--;

    public void Feed(ushort foodWeight)
    {
        var grams = FoodWeightStandard.Grams;

        if (_isAlive)
        {
            if (foodWeight > FoodWeightStandard.Grams)
            {
                WellFedPercent.Value = 100;
                IsAlive = false;
                Weight.Grams += foodWeight;
            }
            else if (WellFedPercent.TryIncreaseBy((byte)((decimal)foodWeight / grams * 100)))
            {
                Console.WriteLine($"Cat {Name} fed <3");
                Weight.Grams += foodWeight;
                TotalFoodEaten += foodWeight;
                MeowedInARow = 0;
            }
            else IsAlive = false;
        }
    }

    public void Pee()
    {
        Weight.Grams -= 200;
        WellFedPercent.СarefullyDecreaseBy(15);
        Console.WriteLine(WellFedPercent);
    }

    public void Meow()
    {
        if (_isAlive)
        {
            Console.WriteLine($"Cat {Name} meowed :3");
            MeowedInARow++;
        }
    }

    public Cat DeepCopy() => (Cat)MemberwiseClone();

    public override bool Equals(object? obj)
    {
        if (obj is Cat cat)
        {
            return
                IsAlive        == cat.IsAlive &&
                Weight         == cat.Weight &&
                WellFedPercent == cat.WellFedPercent &&
                Color          == cat.Color &&
                TotalFoodEaten == cat.TotalFoodEaten &&
                HasTail        == cat.HasTail &&
                MeowedInARow   == cat.MeowedInARow;
        }
        return false;
    }

    public override int GetHashCode() => base.GetHashCode();
}
