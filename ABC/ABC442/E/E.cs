using System;
using System.Linq;
using System.Collections.Generic;

public class E
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] grid = new int[n,n]; //1が黒 0が白
        for(int i = 0; i < n; i++)
        {
            string s = Console.ReadLine();
            for(int j = 0; j < n; j++)
            {
                if(s[j]=='#') grid[i,j] = 1;
                else grid[i,j]=0;
            }
        }

        int ans = 0;
        //縦に見る
        for(int i = 0; i < n; i++)
        {
            bool[] dp = new bool[n]; //dp[i]→i列目以降は単調か
            dp[n-1] = true;
            for(int j = n - 2; j >= 0; j--)
            {
                if(dp[j+1] && grid[j,i] == grid[j+1,i]) dp[j] = true;
                else dp[j] = false;
            }

            int cw = 0;
            int cb = 0;

            //白に変える場合
            for(int j = 0; j < n - 1; j++)
            {
                if(grid[j,i] == 1 && dp[j+1] == false)
                {
                    cw++;
                }
            }

            //黒が変える場合
            for(int j = 0; j < n; j++)
            {
                if (grid[j, i] == 0)
                {
                    cb++;
                }
            }
        }

        Console.WriteLine(ans);
    }
}
