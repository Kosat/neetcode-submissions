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
// KNOTE 100% my solution. Only mistake was to not using temp variable(s).
public class Solution {

    public TreeNode InvertTree(TreeNode root) {
        if(root == null) {
            return null;
        }
        
        (root.left, root.right) = (root.right, root.left);

        InvertTree(root.left);
        InvertTree(root.right);

        return root;
    }

    public TreeNode InvertTree_v01(TreeNode root) {
        if(root == null) {
            return null;
        }
        
        var left = root.left;
        var right = root.right;

        root.right = InvertTree(left);
        root.left = InvertTree(right);

        return root;
    }
}
