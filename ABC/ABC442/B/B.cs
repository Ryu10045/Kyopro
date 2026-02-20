using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Principal;

public class B
{
    public static void Main()
    {
        int q = int.Parse(Console.ReadLine());
        int[] a = new int[q];
        for(int i = 0; i < q; i++)
        {
            a[i] = int.Parse(Console.ReadLine());
        }
        int vol = 0;
        bool isplay = false;

        for(int i = 0; i < q; i++)
        {
            if(a[i]==1) vol++;
            else if(a[i]==2 && vol >=1) vol--;
            else if(a[i]==3) isplay = !isplay;

            if(vol>=3 && isplay) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}
