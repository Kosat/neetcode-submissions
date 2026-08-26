/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        // Start at root, descend iteratively using BST property (no path storage needed).
        TreeNode cur = root;

        while (cur != null)
        {
            int curVal = cur.val;
            // If both p.val and q.val are less than cur.val, go left.
            if (p.val < curVal && q.val < curVal)
            {
                cur = cur.left;
            }
            // - If both p.val and q.val are greater than cur.val, go right.
            else if (p.val > curVal && q.val > curVal)
            {
                cur = cur.right;
            }
            // - Otherwise (p and q are on different sides, or cur equals p or q), cur is the LCA: return it.
            else
            {
                break;
            }
        }

        return cur; 
    }
}
