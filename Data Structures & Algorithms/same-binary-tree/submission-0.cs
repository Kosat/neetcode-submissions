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
#nullable enable
public class Solution {
    public bool IsSameTree(TreeNode p, TreeNode q) {
        Queue<TreeNode?> pQueue = new ();
        Queue<TreeNode?> qQueue = new ();

        // BST implementation
        pQueue.Enqueue(p);
        qQueue.Enqueue(q);

        while(pQueue.Count > 0 && qQueue.Count > 0) {

            int curLevelSizeP = pQueue.Count;
            int curLevelSizeQ = qQueue.Count;

            if(curLevelSizeP != curLevelSizeQ) {
                return false;
            }

            while(curLevelSizeP-- > 0) {
                TreeNode? curP = pQueue.Dequeue();
                TreeNode? curQ = qQueue.Dequeue();
                
                if (curP == null && curQ == null) continue;
                if (curP == null || curQ == null) return false;
                if (curP.val != curQ.val) return false;

                pQueue.Enqueue(curP.left);
                pQueue.Enqueue(curP.right);
                qQueue.Enqueue(curQ.left);
                qQueue.Enqueue(curQ.right);
            }
        }

        return true;

    }
}
