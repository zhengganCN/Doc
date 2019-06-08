class Solution
{
    public bool Find(int target, int[][] array)
    {
        if (array==null|array.Length==0|array[0].Length==0)
        {
            return false;
        }
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i][0] <= target && array[i][array[i].Length - 1] >= target)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] == target)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}