# C#自定义比较器

## 实现

``` C#
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
        }
    }
    public class ListNodeCompare : IComparer<ListNode>
    {
        public int Compare(ListNode x, ListNode y)
        {
            if (x==null)
            {
                if (y==null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y==null)
                {
                    return 1;
                }
                else
                {
                    if (x.val==y.val)
                    {
                        return 0;
                    }
                    return x.val >= y.val ? 1 : -1;
                }
            }
        }
    }
    static void Main(string[] args)
    {
        List<ListNode> nodes = new List<ListNode>();
        nodes.Sort(new ListNodeCompare());
    }
```
