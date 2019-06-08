/*
题目描述
输入一个链表，输出该链表中倒数第k个结点。
*/
using System;
using System.Collections.Generic;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode (int x)
    {
        val = x;
    }
}
class Solution
{
    public ListNode FindKthToTail(ListNode head, int k)
    {
        if (head==null)
        {
            return null;
        }
        List<ListNode> nodeList = new List<ListNode>();

        nodeList.Add(head);
        while (head.next!=null)
        {
            head = head.next;
            nodeList.Add(head);
        }
        if (nodeList.Count<k||k==0)
        {
            return null;
        }
        return nodeList[nodeList.Count - k];
    }
}