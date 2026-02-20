using System;
using System.Linq;
using System.Collections.Generic;

public class B
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] s = new string[n];
        for(int i=0;i<n;i++) s[i] = Console.ReadLine();

        int len = s[0].Length;
        for(int i = 1; i < n; i++)
        {
            if(len < s[i].Length) len = s[i].Length;
        }

        for(int i = 0; i < n; i++)
        {
            int k = (len - s[i].Length)/2;
            for(int j=0;j<k;j++) Console.Write('.');
            Console.Write(s[i]);
            for(int j=0;j<k;j++) Console.Write('.');
             Console.WriteLine();

        }
    }
}
