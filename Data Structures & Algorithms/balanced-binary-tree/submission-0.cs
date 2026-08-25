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
    public bool IsBalanced(TreeNode root) {
        // Example 1: Input: root = [1,2,3,null,null,4] Output: true
        // Example 2: Input: root = [1,2,3,null,null,4,null,5] Output: false
        // Example 3: Input: root = [] Output: true

        // Implementation Plan:
        // - Implement recursive Dfs 
        // - for each recursion step calculate height by incrementing max(left, right) + 1
        // - for each recursion step compare leftBalanced && rightBalanced && abs(leftHeight - rightHeight) <= 1 , otherwise return false - for tree being non-balanced
        // - Use aux Dfs() method returning (bool/*isBalanced*/,int/*height*/)
        // LeetCode pattern: DFS recursive 
        // Complexity: O(n) time - b/c visiting all the nodes, O(n) extra space for recursive stack
        // Underlying collection: None
        
        return Dfs(root).IsBalanced;
    }

    private (bool IsBalanced, int Height) Dfs(TreeNode n)
    {
        if(n == null)
        {
            return (true, 0);
        } 

        var (balLeft, heightLeft) = Dfs(n.left);
        var (balRight, heightRight) = Dfs(n.right);
        
        bool curIsBalanced = balLeft && balRight && Math.Abs(heightLeft - heightRight) <= 1;
        int curHeight = 1 + Math.Max(heightLeft, heightRight);
        
        return (curIsBalanced, curHeight);
    }
}