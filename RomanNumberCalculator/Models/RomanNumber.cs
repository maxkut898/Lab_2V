using System;
using System.Collections.Generic;
using System.Text;

public class RomanNumber : ICloneable, IComparable
{
    private protected string Roman_Number = "";
    private protected ushort decimalNumber;
    //Конструктор получает число n, которое должен представлять объект класса
    public RomanNumber(ushort n)
    {
        if (n <= 0 || n >= 4000)
        {
            throw new RomanNumberException("Некорректное десятичное число");
        }
        decimalNumber = n;
    }
    //Сложение римских чисел
    public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.decimalNumber + n2.decimalNumber > 3999)
        {
            throw new RomanNumberException("Некорректные входные данные");
        }
        return new RomanNumber((ushort)(n1.decimalNumber + n2.decimalNumber));
    }
    //Вычитание римских чисел
    public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.decimalNumber - n2.decimalNumber <= 0)
        {
            throw new RomanNumberException("Некорректные входные данные");
        }

        return new RomanNumber((ushort)(n1.decimalNumber - n2.decimalNumber));
    }
    //Умножение римских чисел
    public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.decimalNumber * n2.decimalNumber > 3999)
        {
            throw new RomanNumberException("Некорректные входные данные");
        }
        return new RomanNumber((ushort)(n1.decimalNumber * n2.decimalNumber));
    }
    //Целочисленное деление римских чисел
    public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.decimalNumber / n2.decimalNumber <= 0)
        {
            throw new RomanNumberException("Некорректные входные данные");
        }

        return new RomanNumber((ushort)(n1.decimalNumber / n2.decimalNumber));
    }
    //Возвращает строковое представление римского числа
    public override string ToString()
    {
        if (Roman_Number == "")
        {
            ushort n = decimalNumber;
            string[] romanSymbols = new string[] { "M", "D", "C", "L", "X", "V", "I" };

            //численное текущего значение римского символа
            ushort romanSymbolValue = 1000;

            for (int i = 0; i < romanSymbols.Length; i += 2)
            {
                //берём старшую цифру числа
                int digit = n / romanSymbolValue;

                if (digit == 9)
                {
                    Roman_Number += romanSymbols[i] + romanSymbols[i - 2];
                    digit = 0;
                }
                if (digit >= 5)
                {
                    Roman_Number += romanSymbols[i - 1];
                    digit -= 5;
                }
                if (digit == 4)
                {
                    Roman_Number += romanSymbols[i] + romanSymbols[i - 1];
                    digit = 0;
                }
                for (int j = 0; j < digit; j++)
                {
                    Roman_Number += romanSymbols[i];
                }

                //обрубаем старшую цифру числа
                n %= romanSymbolValue;

                //уменьшаем численное значение символа в 10 раз
                romanSymbolValue /= 10;
            }
        }
        return Roman_Number;
    }

    public object Clone()
    {
        return new RomanNumber(decimalNumber);
    }

    public int CompareTo(object? o)
    {
        if (o is RomanNumber number)
        {
            return number.decimalNumber - decimalNumber;
        }
        throw new RomanNumberException("Некорректное значение параметра");
    }
}