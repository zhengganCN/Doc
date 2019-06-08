/*
题目描述
一只青蛙一次可以跳上1级台阶，也可以跳上2级。
求该青蛙跳上一个n级的台阶总共有多少种跳法
（先后次序不同算不同的结果）。
*/
class Solution
{
    public int jumpFloor(int number)
    {
        int x1 = 0;//F(n-2)
        int x2 = 1;//F(n-1)
        int num = 0;//F(n)=F(n-2)+F(n-1)
        if (number == 0)
        {
            return 0;
        }
        else if (number == 1)
        {
            return 1;
        }
        else
        {
            int temp = 0;
            for (int i = 1; i <= number; i++)
            {
                num = x1 + x2;
                temp = x1;
                x1 = x2;
                x2 = num;
            }
            return num;
        }
    }
}