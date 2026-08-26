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
    public List<List<int>> LevelOrder(TreeNode root) {
        
        List<List<int>> result = new List<List<int>>();
        
        if(root == null) {
            return result;
        }


        Queue<TreeNode> queue = [];
        queue.Enqueue(root);

        int level = 0;
        // BFS traversal
        while(queue.Count > 0) {
            
            int curLevelSize = queue.Count;

            //Console.WriteLine(curLevelSize);

            // Traverse all the queie items from the previous round. 
            // 1 round = 1 level
            // This is necessary to set the bounds between levels
            List<int> curLevelList = new List<int>(curLevelSize);
            while(curLevelSize-- > 0) {
                TreeNode cur = queue.Dequeue();

                if(cur.left != null) {
                    queue.Enqueue(cur.left);
                }
                if(cur.right != null) {
                    queue.Enqueue(cur.right);
                }
                curLevelList.Add(cur.val);
            }

            result.Add(curLevelList);
        }

        return result;
    }
}
