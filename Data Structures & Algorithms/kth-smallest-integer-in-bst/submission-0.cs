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
    public int KthSmallest(TreeNode root, int k) {
        return Dfs(root, k).kthSmallestNode.val;
    }

    private static (TreeNode kthSmallestNode, int kReturn) Dfs(TreeNode n, int k)
    {
        // Base case 
        if(n == null) 
            return (null, k); 

        var (kthSmallestNodeL, kLeft) = Dfs(n.left, k);
        if( kthSmallestNodeL != null)
            return (kthSmallestNodeL, kLeft);

        kLeft--;

        if(kLeft == 0)
            return (n, kLeft);
        
        var (kthSmallestNodeR, kRight) = Dfs(n.right, kLeft);
        if( kthSmallestNodeR != null)
            return (kthSmallestNodeR, kRight);

        return (null, kRight);
    }
}
