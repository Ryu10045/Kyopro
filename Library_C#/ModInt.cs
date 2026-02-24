using System;
using System.Linq;
using System.Collections.Generic;

public class Hello
{
    // public static void Main()
    // {
    //     long[] inp = Console.ReadLine().Split().Select(long.Parse).ToArray();
    //     ModInt n = new ModInt(inp[0], 1000000007);
    //     ModInt r = new ModInt(inp[1], 1000000007);

    //     Console.WriteLine(ModInt.Factorial(n) / (ModInt.Factorial(r) * ModInt.Factorial(n - r)));
    // }
}
public struct ModInt
{
    private long X { get; set; }
    public readonly int Mod { get; }


    public ModInt(long n, int mod)
    {
        this.X = ((n % mod) + mod) % mod;
        this.Mod = mod;
    }

    public static ModInt operator +(ModInt n, ModInt m)
    {
        if (n.Mod != m.Mod)
        {
            throw new Exception($"Trying to calculate using a different modulus: {n.Mod} {m.Mod}");
        }

        return new ModInt(n.X + m.X, n.Mod);
    }

    public static ModInt operator -(ModInt n, ModInt m)
    {
        if (n.Mod != m.Mod)
        {
            throw new Exception($"Trying to calculate using a different modulus: {n.Mod} {m.Mod}");
        }

        return new ModInt(n.X - m.X, n.Mod);
    }

    public static ModInt operator *(ModInt n, ModInt m)
    {
        if (n.Mod != m.Mod)
        {
            throw new Exception($"Trying to calculate using a different modulus: {n.Mod} {m.Mod}");
        }

        return new ModInt(n.X * m.X, n.Mod);
    }

    public static ModInt Pow(ModInt n, int e)
    {
        ModInt result = new ModInt(1, n.Mod);
        ModInt powBase = new ModInt(n.X, n.Mod);
        while (e > 0)
        {
            if ((e & 1) == 1) result *= powBase;
            powBase *= powBase;
            e >>= 1;
        }

        return result;
    }

    /// <summary>
    /// Calcurate a / b.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="m">Divisor. Only acceptable prime number.</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static ModInt operator /(ModInt n, ModInt m)
    {
        if (m.X == 0)
        {
            throw new Exception("Zero divided occures");
        }

        return n * ModInt.Pow(m, m.Mod - 2);
    }

    public static ModInt Factorial(ModInt n)
    {
        ModInt result = new ModInt(1, n.Mod);
        for (int i = 2; i <= n.X; i++)
        {
            result *= new ModInt(i, n.Mod);
        }
        return result;
    }

    public override string ToString() => X.ToString();
}