// See https://aka.ms/new-console-template for more information

UInt128 max = UInt128.MaxValue;

//foreach (var b in max.GetBytes())
//{
//    Console.WriteLine($"{Convert.ToString(b, 2).PadLeft(8, '0')}");
//}

var u11 = new UInt128(2);
var u01 = new UInt128(1);
var a = u11 + u01;

foreach (var b in u11.GetBytes())
{
    Console.WriteLine($"{Convert.ToString(b, 2).PadLeft(8, '0')}");
}

Console.WriteLine("\n______________________\n");

foreach (var b in u01.GetBytes())
{
    Console.WriteLine($"{Convert.ToString(b, 2).PadLeft(8, '0')}");
}

Console.WriteLine("\n______________________\n");

foreach (var b in a.GetBytes())
{
    Console.WriteLine($"{Convert.ToString(b, 2).PadLeft(8, '0')}");
}