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
    public List<int> RightSideView(TreeNode root) {
        if (root == null) return [];

        List<int> result = [];
        Queue<TreeNode> queue = new ();

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int curLevelCount = queue.Count;
            while (curLevelCount > 0) {
                var cur = queue.Dequeue();
                // The last node in the queue - the rightmost node in the level
                if(curLevelCount == 1)
                {
                    result.Add(cur.val);
                }

                if(cur.left != null) queue.Enqueue(cur.left);
                if(cur.right != null) queue.Enqueue(cur.right);
                
                curLevelCount--;
            }
        }

        return result;
    }
}
