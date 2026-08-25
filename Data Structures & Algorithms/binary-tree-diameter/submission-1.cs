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
    public int DiameterOfBinaryTree(TreeNode root) {
        // Example 1: Input: root = [1,null,2,3,4,5] Output: 3
        // Example 2: Input: root = [1,2,3] Output: 2

        // Implement recursive DFS for each node return tuple of 
        // - Max of underlying lengths of left and right subtrees
        // - And Max diameter that equal max(leftHeight + rightHeight, leftDiameter, rightDiameter)
        // O(n) time, O(n) extra space
        // Underlying collection: None
        var result = Dfs(root);
        return result.Diameter;
    }

    public (int Height, int Diameter) Dfs(TreeNode n)
    {
        if(n == null) return (0, 0);

        var (lHeight, lDiameter) = Dfs(n.left);
        var (rHeight, rDiameter) = Dfs(n.right);

        var height = 1 + Math.Max(lHeight, rHeight);
        var childDiameter = Math.Max(lDiameter, rDiameter);
        var diameter = Math.Max(lHeight + rHeight, childDiameter);
        return (height, diameter);
    }
}
