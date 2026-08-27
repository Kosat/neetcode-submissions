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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        // Preorder
        // cur
        // Left subtree
        // Right subtree

        // InOrder
        // Left subtree
        // cur
        // Right subtree

        if (preorder.Length == 0) {
            return null;
        }

        TreeNode curRoot = new(preorder[0]);

        // Find the curRoot idx in inorder
        // NOTE: All the node values are unique
        // int curRootInOrderIdx = -1;
        // while (++curRootInOrderIdx < inorder.Length) {
        //     if (curRoot.val == inorder[curRootInOrderIdx]) {
        //         break;
        //     }
        // }
        int curRootInOrderIdx = 0;
        for (; curRootInOrderIdx < inorder.Length; curRootInOrderIdx++)
        {
            if (curRoot.val == inorder[curRootInOrderIdx]) {
                break;
            }
        }

        // Process the left & right subtrees
        int countOfLeftSubTreeNodes = curRootInOrderIdx;
        int countOfRightSubTreeNodes = inorder.Length - curRootInOrderIdx - 1;
        // NOTE: Skipping/excluding the leftmost item in preorder[0] and the curRootInOrderIdx-th item in inorder[curRootInOrderIdx]
        if (countOfLeftSubTreeNodes > 0)
            curRoot.left = BuildTree(preorder[1..(curRootInOrderIdx+1)], inorder[0..curRootInOrderIdx] );
        if (countOfRightSubTreeNodes > 0)
            curRoot.right = BuildTree(preorder[(curRootInOrderIdx+1)..], inorder[(curRootInOrderIdx+1)..] );
        
        return curRoot;
    }

    
}
