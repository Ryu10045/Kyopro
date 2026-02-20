using System;
using System.Linq;
using System.Collections.Generic;

public class C
{
    public static void Main()
    {
        int[] inp = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = inp[0];
        int t = inp[1];

        if (n == 0)
        {
            Console.WriteLine(t);
            return;
        }

        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int ans = a[0];
        int nextopen = a[0]+100;
        for(int i = 1; i < n; i++)
        {
            if(a[i] < nextopen) continue;
            ans += a[i] - nextopen;
            nextopen = a[i] + 100;
        }
        if(nextopen < t)
        {
            ans += t - nextopen;
        }

        Console.WriteLine(ans);
    }
}
