using System;
using System.Collections.Generic;

public class Prostokąt
{
    private double bokA;
    private double bokB;
    private static readonly double pierwiastekZDwóch = Math.Sqrt(2);
    private static readonly Dictionary<char, decimal> wysokośćArkusza0 = new Dictionary<char, decimal>
    {
        ['A'] = 1189,
        ['B'] = 1414,
        ['C'] = 1297
    };

    public Prostokąt(double bokA, double bokB)
    {
        BokA = bokA;
        BokB = bokB;
    }

    public double BokA
    {
        get => bokA;
        set
        {
            if (double.IsNaN(value) || value < 0)
                throw new ArgumentException("Bok A musi być skończoną, nieujemną liczbą.");
            bokA = value;
        }
    }

    public double BokB
    {
        get => bokB;
        set
        {
            if (double.IsNaN(value) || value < 0)
                throw new ArgumentException("Bok B musi być skończoną, nieujemną liczbą.");
            bokB = value;
        }
    }

    public static Prostokąt ArkuszPapieru(string format)
    {
        char seria = format[0];
        if (!wysokośćArkusza0.ContainsKey(seria))
            throw new ArgumentException("Nieprawidłowa seria arkusza.");

        byte i = byte.Parse(format.Substring(1));
        decimal wysokość = wysokośćArkusza0[seria];
        double wysokośćMM = (double)wysokość / Math.Pow(pierwiastekZDwóch, i);
        double szerokośćMM = wysokośćMM / pierwiastekZDwóch;

        return new Prostokąt(wysokośćMM, szerokośćMM);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Prostokąt arkuszA0 = Prostokąt.ArkuszPapieru("A0");
            Console.WriteLine(arkuszA0);

            Prostokąt arkuszA1 = Prostokąt.ArkuszPapieru("A1");
            Console.WriteLine(arkuszA1);

            Prostokąt arkuszB2 = Prostokąt.ArkuszPapieru("B2");
            Console.WriteLine(arkuszB2);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
    }
}