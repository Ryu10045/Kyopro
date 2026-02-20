using System;
using System.Linq;
using System.Collections.Generic;

public class B
{
    public static void Main()
    {
        int[] inp = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = inp[0];
        int k = inp[1];

        int ans = 0;
        int sum = 0;
        while(sum < k)
        {
            sum += n;
            n++;
            ans++;
        }

        Console.WriteLine(ans-1);
    }
}
