using System;
using System.Linq;
using System.Collections.Generic;

public class D
{
    public static void Main()
    { 
        int[] inp = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = inp[0];
        int q = inp[1];
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long[] d = new long[n+1];
        d[0] = 0;
        for(int i = 0; i < n; i++)
        {
            d[i+1] = d[i] + a[i];
        }

        var li = new List<long>();

        for(int i = 0; i < q; i++)
        {
            inp = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int ins = inp[0];

            if(ins == 1)
            {
                int x = inp[1] - 1;
                d[x+1] = d[x+1] - a[x] + a[x+1];
                //d[x+2] = d[x+2] - a[x+1] + a[x];
                int tmp = a[x];
                a[x] = a[x+1];
                a[x+1] = tmp;
                
            }
            else
            {
                int l = inp[1] - 1;
                int r = inp[2] - 1;
                li.Add(d[r+1] - d[l]);
                
            }
        }

        foreach(var i in li) Console.WriteLine(i);
    }
}
