using System;
using System.Linq;
using System.Collections.Generic;

public class C
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).Select(x => x-1).ToArray();

        for(int i = 0; i < n; i++)
        {
            bool[] isvisited = new bool[n]; //そのマスを訪れたかどうか
            int start = 0;  //繰り返し開始マス
            int initlen = 0; //繰り返しに突入するまでの長さ
            int looplen = 0; //繰り返し部分の長さ

            int current = i;
            while (true)
            {
                if(isvisited[current])
                {
                    start = current;
                    break;
                }
                isvisited[current] = true;
                current = a[current];
            }

            bool isstart = false;
            current = i;
            while (true)
            {
                //Console.WriteLine(current);
                if(current == start && isstart == false)
                {
                    //Console.WriteLine("start");
                    isstart = true;
                }else if(current == start && isstart == true)
                {
                    looplen++;
                    break;
                }else if(!isstart) initlen++;
                if(isstart) looplen++;
                current = a[current];
            }

            //10^100 mod looplen
            int powermod = 1;
            for(int j = 0; j < 100; j++)
            {
                powermod =  powermod * 10 % looplen % looplen;
            }

            int ans = ( powermod - (initlen % looplen) ) % looplen;

            current = start;
            for(int j = 0; j < ans; j++)
            {
                current = a[current];
            }

            Console.Write(current + 1);
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}
