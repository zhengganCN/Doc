/*
题目描述
输入一个整数数组，实现一个函数来调整该数组中数字的顺序，
使得所有的奇数位于数组的前半部分，所有的偶数位于数组的后半部分，
并保证奇数和奇数，偶数和偶数之间的相对位置不变。
*/
using System;
using System.Collections.Generic;
class Solution
{
    public int[] reOrderArray(int[] array)
    {
        int[] result;
        List<int> head = new List<int>();
        List<int> back = new List<int>();
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i]%2!=0)
            {
                head.Add(array[i]);
            }
            else
            {
                back.Add(array[i]);
            } 
        }
        head.AddRange(back);
        result = head.ToArray();
        return result;
    }
}