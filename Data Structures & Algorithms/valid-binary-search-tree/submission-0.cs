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
    public bool IsValidBST(TreeNode root) {
        return Dfs(root, long.MinValue, long.MaxValue);
    }

    private static bool Dfs(TreeNode n, long minSoFar, long maxSoFar) {
        // Recursion base case
        if (n == null) return true;

        //ALTERNATIVE: if (minSoFar >= n.val || n.val >= maxSoFar)
        if (!(minSoFar < n.val && n.val < maxSoFar))
            return false;
       
        bool result = true;

        result &= Dfs(n.left, minSoFar, n.val);
        result &= Dfs(n.right, n.val, maxSoFar);

        return result;
    }
}
