using System;

class Program
{
    static void Main()
    {
        RomanNumber a = new RomanNumber(10);
        RomanNumber b = new RomanNumber(2222);
        RomanNumber c = new RomanNumber(5);
        RomanNumber d = new RomanNumber(600);
        RomanNumber e = new RomanNumber(162);

        Console.WriteLine("A = 10 = X: " + a.ToString());
        Console.WriteLine("B = 2222 = MMCCXXII: " + b.ToString());
        Console.WriteLine("C = 5 = V: " + c.ToString());
        Console.WriteLine("D = 600 = V : " + d.ToString());
        Console.WriteLine("");

        Console.WriteLine("B + C = 2227 = MMCCXXVII: " + RomanNumber.Add(b, c).ToString());
        Console.WriteLine("B - C = 2217 = MMCCXVII: " + RomanNumber.Sub(b, c).ToString());
        Console.WriteLine("D * C = 3000 = MMM: " + RomanNumber.Mul(d, c).ToString());
        Console.WriteLine("D / C = 120 = CXX: " + RomanNumber.Div(d, c).ToString());
        Console.WriteLine("");

        Console.WriteLine("Сортировка");
        RomanNumber[] numbers = { a, b, c, d };
        Array.Sort(numbers);
        foreach (RomanNumber number in numbers)
        {
            Console.WriteLine(number.ToString());
        }
        Console.WriteLine("");

        Console.WriteLine("Копирование");
        var f = (RomanNumber)c.Clone();
        Console.WriteLine(f.ToString());
    }
}
