/*
题目描述
定义栈的数据结构，请在该类型中实现一个能够得到栈中所含最小元素的min函数
（时间复杂度应为O（1））。
*/
using System.Collections.Generic;
using System.Linq;
class Solution
{
    List<int> nodeList = new List<int>();
    public void push(int node)
    {
        nodeList.Add(node);
    }
    public void pop()
    {
        nodeList.RemoveAt(nodeList.Count - 1);
    }
    public int top()
    {
        return nodeList[nodeList.Count-1];
    }
    public int min()
    {
        return nodeList.Min();
    }
}