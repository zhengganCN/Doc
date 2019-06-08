public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x)
    {
        val = x;
    }
}
private List<int> intList = new List<int>();
/// <summary>
/// 中序遍历
/// </summary>
/// <param name="treeNode"></param>
public void InorderTraversal(TreeNode treeNode)
{
    if (treeNode!=null)
    {
        return;
    }
    else
    {
        InorderTraversal(treeNode.left);
        intList.Add(treeNode.val);
        InorderTraversal(treeNode.right);
    }
} 