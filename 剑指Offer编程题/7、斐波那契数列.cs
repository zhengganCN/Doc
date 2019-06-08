/*
题目描述
大家都知道斐波那契数列，现在要求输入一个整数n，
请你输出斐波那契数列的第n项（从0开始，第0项为0）。
n<=39
*/
class Solution
{
    public int Fibonacci(int n)
    {
        int x1 = 0;//F(n-2)
        int x2 = 1;//F(n-1)
        int num = 0;//F(n)=F(n-2)+F(n-1)
        if (n==0)
        {
            return 0;
        }
        else if (n==1)
        {
            return 1;
        }
        else
        {
            int temp = 0;
            for (int i = 2; i <= n; i++)
            {
                num = x1 + x2;
                temp = x1;
                x1 = x2;
                x2 = num ;
            }
            return num;
        }
    }
}