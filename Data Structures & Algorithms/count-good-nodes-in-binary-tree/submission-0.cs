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
    public int GoodNodes(TreeNode root) {
        return Dfs(root, root.val);
    }

    private static int Dfs(TreeNode n, int maxValSoFar)
    {
        // Base case for recursion
        if (n == null) return 0;

        int goodNodes = 0;

        if (n.val >= maxValSoFar)
        {
            goodNodes++;
        }

        maxValSoFar = Math.Max(n.val, maxValSoFar);

        goodNodes += Dfs(n.left, maxValSoFar);
        goodNodes += Dfs(n.right, maxValSoFar);

        return goodNodes;
    }
}
