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

    int _maxSum = int.MinValue;

    public int MaxPathSum(TreeNode root) {

        MaxPathSumDfs(root);
        return _maxSum;
    }

    private int MaxPathSumDfs(TreeNode root)
    {
        // Base case
        if (root == null)
            return 0;

        var leftMaxOrZero = Math.Max(MaxPathSumDfs(root.left), 0);
        var rightMaxOrZero = Math.Max(MaxPathSumDfs(root.right), 0);

        _maxSum = Math.Max(root.val + leftMaxOrZero + rightMaxOrZero, _maxSum);
        //_maxSum = Math.Max(Math.Max(leftMaxOrZero, rightMaxOrZero), _maxSum);

        return Math.Max(root.val + leftMaxOrZero, root.val + rightMaxOrZero);
    }
}
