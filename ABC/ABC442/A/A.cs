using System;
using System.Linq;
using System.Collections.Generic;

public class A
{
    public static void Main()
    {
        string S = Console.ReadLine();
        int ans = 0;
        foreach(var i in S)
        {
            if(i=='i' || i == 'j')
            {
                ans++;
            }
        }
        Console.WriteLine(ans);
    }
}
