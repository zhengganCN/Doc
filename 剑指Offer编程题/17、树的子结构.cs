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

class Solution
{
    public bool HasSubtree(TreeNode pRoot1, TreeNode pRoot2)
    {
        if (pRoot1==null||pRoot2==null)
        {
            return false;
        }
        else
        {
            PreorderTraversal(pRoot1, preorder1);
            PreorderTraversal(pRoot2, preorder2);

            if (preorder1.ToString().Contains(preorder2.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    StringBuilder preorder1 = new StringBuilder();
    StringBuilder preorder2 = new StringBuilder();
    //前序遍历
    public void PreorderTraversal(TreeNode treeNode,StringBuilder preorder)
    {
        if (treeNode==null)
        {
            return;
        }
        preorder.Append(treeNode.val);
        PreorderTraversal(treeNode.left,preorder);
        PreorderTraversal(treeNode.right,preorder);
        return;
    }
}