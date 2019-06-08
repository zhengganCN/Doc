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
   public ListNode ReverseList(ListNode pHead)
    {
        if (pHead == null)
        {
            return null;
        }
        else if (pHead.next == null)
        {
            return pHead;
        }
        else
        {
            List<ListNode> nodes = new List<ListNode>();
            nodes.Add(pHead);
            while (pHead.next!=null)
            {
                nodes.Add(pHead.next);
                pHead = pHead.next;
            }
            ListNode head = new ListNode(0);
            nodes[0].next = null;
            for (int i = nodes.Count-1; i >0; i--)
            {
                Conv(nodes[i], nodes[i - 1]);
            }
            return nodes[nodes.Count - 1];
        }
        
    }
    public ListNode Conv(ListNode head,ListNode next)
    {
        head.next = next;
        return head;
    }
}