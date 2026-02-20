using System;
using System.Linq;
using System.Collections.Generic;
public class SegmentTree
{
    private long[] data;
    private int leafnum;
    private Func<long, long, long> f;
    private long id;
    private int size;
    public SegmentTree(long[] a, Func<long, long, long> f, long id = 0)
    {
        this.f = f;
        this.id = id;

        this.leafnum = 1;
        while (leafnum < a.Length)
        {
            this.leafnum *= 2;
        }

        this.size = leafnum * 2;
        this.data = new long[size];
        for (int i = 0; i < size; i++) this.data[i] = this.id;
        for (int i = 0; i < a.Length; i++)
        {
            this.data[leafnum + i] = a[i];
        }

        for (int i = leafnum - 1; i >= 1; i--)
        {
            this.data[i] = f(this.data[i * 2], this.data[i * 2 + 1]);
        }
    }

    public void Update(int k, long x)
    {
        int idx = leafnum + k;
        this.data[idx] = x;

        while (idx > 0)
        {
            if (idx % 2 == 0)
            {
                this.data[idx/2] = f(this.data[idx ], this.data[idx + 1]);
            }
            else
            {
                this.data[idx / 2] = f(this.data[idx], this.data[idx - 1]);
            }
            idx /= 2;
        }
    }

    ///return result about [l,r)
    public long Query(int left, int right)
    {
        int l = leafnum + left;
        int r = leafnum + right;
        long result = this.id;

        while (l < r)
        {
            if (l % 2 == 1)
            {
                result = f(result, this.data[l]);
                l++;
            }
            if (r % 2 == 1)
            {
                result = f(result, this.data[r - 1]);
                r--;
            }
            l /= 2;
            r /= 2;
        }

        return result;
    }

    public void print()
    {
        int idx = 1;
        int sidx = 0;
        for(int i = 1; i <= this.data.Length; i++)
        {
            Console.Write($"{this.data[i]} ");
            sidx++;
            if(sidx == idx)
            {
                Console.WriteLine();
                idx = idx * 2 + 1;
            }
        }
    }
}