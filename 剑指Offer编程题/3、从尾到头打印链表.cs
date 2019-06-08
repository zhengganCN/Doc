public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        val = x;
    }
}
class Solution
{
    // 返回从尾到头的列表值序列
    public List<int> printListFromTailToHead(ListNode listNode)
    {
        List<int> intArray = new List<int>();
        if (listNode==null)
        {
            return intArray;
        }
        intArray.Add(listNode.val);
        while (true)
        {
            if (listNode.next != null)
            {
                intArray.Add(listNode.next.val);
            }
            else
            {
                break;
            }
            listNode = listNode.next;
        }
        intArray.Reverse();
        return intArray;
    }
}