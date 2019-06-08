/*
题目描述
输入一个整数，输出该数二进制表示中1的个数。其中负数用补码表示。
*/
using System;
using System.Linq;
using System.Text;
class Solution
{
    public int NumberOf1(int n)
    {
        var bitString= Convert.ToString(n,2);
        if (n >= 0)
        {
            return bitString.Count(s => s == '1');
        }
        else
        {

            return bitString.Count(s => s == '1');
        }
    }
}