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

    // The same as v01 but more concise
    public int MaxDepth(TreeNode root) {
        if(root == null) return 0;

        if(root.left == null && root.right == null) {
            return 1;
        }

        return Math.Max(MaxDepth(root.left) + 1, MaxDepth(root.right) + 1);
    }

    public int MaxDepth_v01(TreeNode root) {
        if(root == null) return 0;

        if(root.left == null && root.right == null) {
            return 1;
        }

        int maxDepthLeft = 0;
        int maxDepthRight = 0;

        if(root.left != null) {
            maxDepthLeft = 1 + MaxDepth(root.left);
        }

        if(root.right != null) {
            maxDepthRight = 1 + MaxDepth(root.right);
        }

        return Math.Max(maxDepthLeft, maxDepthRight);
    }

}
