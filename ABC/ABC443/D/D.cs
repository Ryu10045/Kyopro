using System;
using System.Linq;
using System.Collections.Generic;

public class D
{
    public static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        for(int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine());
            int[] r = Console.ReadLine().Split().Select(int.Parse).ToArray();
            solve(n, r);
        }
    }

    public static void solve(int n, int[] r)
    {
        int ans = 0;
        int ans2 = 0;
        var l = new List<int>[n];
        int[] rr = new int[r.Length];
        for(int i=0;i<r.Length;i++) rr[i] = r[i];
        for(int i=0;i<n;i++) l[i] = new List<int>();
        for(int i=0;i<n;i++)
        {
            l[r[i] - 1].Add(i);
        }
        
        for(int i = 0; i < n; i++)
        {
            //Console.WriteLine($"i={i}");
            for(int k=0;k<l[i].Count;k++)
            {
                //Console.WriteLine(l[2][0]);
                int j = l[i][k];
                if(j == 0 || j == n - 1) continue;
                //Console.WriteLine(r[j-1] - r[j]);
                if(r[j-1] - r[j] > 1)
                {
                    //Console.WriteLine($"{j}, {r[j-1] - r[j] - 1}");
                    ans += r[j-1] - r[j] - 1;
                    l[r[j-1]-1].Remove(j-1);
                    l[r[j]].Add(j-1);
                    r[j-1] = r[j]+1;
                }
                if(r[j+1] - r[j] > 1)
                {
                    //Console.WriteLine($"{j}, {r[j+1] - r[j] - 1}");
                    ans += r[j+1] - r[j] - 1;
                    l[r[j+1]-1].Remove(j+1);
                    l[r[j]].Add(j+1);
                    r[j+1] = r[j]+1;
                }
            }
        }

        bool next = false;
        for(int i = 0; i < n - 1; i++)
        {
            if(Math.Abs(r[i]-r[i+1]) > 1)
            {
                next = true;
            }
        }

        if(next){
        for(int i=0;i<n;i++) l[i] = new List<int>();
        for(int i=0;i<n;i++)
        {
            l[rr[i] - 1].Add(i);
        }
        for(int i = n-1; i >= 0; i--)
        {
            //Console.WriteLine($"i={i}");
            for(int k=0;k<l[i].Count;k++)
            {
                //Console.WriteLine(l[2][0]);
                int j = l[i][k];
                if(j == 0 || j == n - 1) continue;
                //Console.WriteLine(rr[j-1] - rr[j]);
                if(rr[j] - rr[j-1] > 1)
                {
                    //Console.WriteLine($"j={j}");
                    //Console.WriteLine($"{j}, {rr[j] - rr[j-1] - 1}");
                    //Console.WriteLine(rr[j]-1);
                    ans2 += rr[j] - rr[j-1] - 1;
                    l[rr[j]-1].Remove(j);
                    l[rr[j-1]].Add(j);
                    rr[j] = rr[j-1]-1;
                }
                if(rr[j] - rr[j+1] > 1)
                {
                    //Console.WriteLine($"{j}, {rr[j] - rr[j+1] - 1}");
                    ans2 += rr[j] - rr[j+1] - 1;
                    l[rr[j]-1].Remove(j);
                    l[rr[j+1]].Add(j);
                    rr[j] = rr[j+1]-1;
                }
            }
        }
        }
        
        if(next) Console.WriteLine(ans2);
        else  Console.WriteLine(ans);
       
    }
}
