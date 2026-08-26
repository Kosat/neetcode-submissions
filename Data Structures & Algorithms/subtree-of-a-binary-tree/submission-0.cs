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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        // Implementation Plan:
        // - Traverse over `root` tree using DFS,
        // - While traversing, check if cur node's value == subRoot.value
        // - If all the remaining nodes match return true, otherwise false.
        // - I expect value == subRoot.value may happend multiple times, assuming that input trees may contain duplicate values within a single tree.
        // - Implement aux method for comparing two trees IsTreesEqual().
        // LeetCode pattern: DFS recursive
        // Complexity: O(n*m) time considering no duplicate values in nodes, O(n+m) extra space for the recursion call stack
        // Underlying collection: None
        if(root == null && subRoot == null)
        {
            return true;
        }

        if(subRoot == null)
        {
            return true;
        }

        return Dfs(root, subRoot);
    }

    private bool Dfs(TreeNode root, TreeNode subRoot)
    {
        if(root == null)
        {
            return false;
        }

        bool result = false;

        if(root.val == subRoot.val)
        {
            result |= IsTreesEqual(root, subRoot);
        }

        result |= Dfs(root.left, subRoot);
        result |= Dfs(root.right, subRoot);

        return result;
    }

    private bool IsTreesEqual(TreeNode a, TreeNode b) {
        if(a == null && b == null)
        {
            return true;
        } else if (a == null && b != null)
        {
            return false;
        } else if(a != null && b == null)
        {
            return false;
        }

        return a.val == b.val && IsTreesEqual(a.left, b.left) && IsTreesEqual(a.right, b.right);
    }
}
