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
private List<int> intList=new List<int>();
//前序遍历
public void PreorderTraversal(TreeNode treeNode)
{
    if (treeNode==null)
    {
        return;
    }
    intList.Add(treeNode.val);
    PreorderTraversal(treeNode.left,preorder);
    PreorderTraversal(treeNode.right,preorder);
    return;
}