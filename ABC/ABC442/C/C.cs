using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Principal;

public class C
{
    public static void Main()
    {
        int[] inp = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = inp[0];
        int m = inp[1];
        var graph = new List<int>[n];
        for(int i=0;i<n;i++) graph[i] = new List<int>();
        for(int i = 0; i < m; i++)
        {
            inp = Console.ReadLine().Split().Select(int.Parse).ToArray();
            graph[inp[0]-1].Add(inp[1]-1);
            graph[inp[1]-1].Add(inp[0]-1);
        }

        for(int i = 0; i < n; i++)
        {
            int num = n - graph[i].Count() - 1;
            //Console.WriteLine($"{nCk(num, 3)} ");
            Console.Write($"{nCk(num, 3)} ");
        }
        Console.WriteLine();
    }
    public static long nCk(long n, long k)
    {
        if (n < k) return 0;
        if (n == k) return 1;

        long x = 1;
        for (long i = 0; i < k; i++)
        {
            x = x * (n - i) / (i + 1);
        }
        return x;
    }
}
