using System.Collections.Generic;
class Solution
{
    public Stack<int> inQueue=new Stack<int>();
    public Stack<int> outQueue=new Stack<int>();
    public void push(int node)
    {
        inQueue.Push(node);
    }
    public int pop()
    {
        int inLength = inQueue.Count;
        for (int i = 0; i < inLength; i++)
        {
            outQueue.Push(inQueue.Pop());
        }
        int outNum = outQueue.Pop();
        int outLength = outQueue.Count;
        for (int i = 0; i < outLength; i++)
        {
            inQueue.Push(outQueue.Pop());
        }
        return outNum;
    }
}