/*
题目描述
我们可以用2*1的小矩形横着或者竖着去覆盖更大的矩形。
请问用n个2*1的小矩形无重叠地覆盖一个2*n的大矩形，总共有多少种方法？
*/
using System;
class Solution
{
    public int rectCover(int number)
    {
        int x = 1;
        int y = 2;
        if (number == 0){
            return 0;
        }
        if (number == 1)
        {
            return 1;
        }
        else if (number == 2)
        {
            return 2;
        }
        int temp = 0;
        for (int i = 2; i < number; i++)
        {
            temp = y;
            y = x + y;
            x = temp;
        }
        return y;
    }
}