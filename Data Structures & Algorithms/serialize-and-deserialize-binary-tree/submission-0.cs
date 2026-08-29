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

public class Codec {

    // Encodes a tree to a single string.
   public string Serialize(TreeNode root)
    {
        if (root == null)
        {
            return "";
        }

        // BFS
        StringBuilder result = new();
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            int curLevelCount = queue.Count;
            StringBuilder levelBuffer = new();
            int numberOfNonNullNodes = 0;
            while (curLevelCount-- > 0)
            {
                var cur = queue.Dequeue();

                if (cur == null)
                {
                    levelBuffer.Append("null,");
                }
                else
                {
                    levelBuffer.Append($"{cur.val},");
                    queue.Enqueue(cur.left);
                    queue.Enqueue(cur.right);
                    numberOfNonNullNodes++;
                }
            }
            if (numberOfNonNullNodes == 0)
            {
                break;
            }
            result.Append(levelBuffer);
        }

        if (result.Length > 0)
        {
            result.Length--;
        }
        return result.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data)
    {
        if (data == "")
        {
            return null;
        }

        // Step 1:
        // Parse string into the list of TreeNode objects without establishinh parent-child relation links yet.
        List<TreeNode> deserealizedTree = [];

        var tokens = data.Split(',');
        foreach (string token in tokens)
        {
            if (string.IsNullOrEmpty(token) || token == "null")
            {
                deserealizedTree.Add(null);
            }
            else
            {
                TreeNode n = new(int.Parse(token));
                deserealizedTree.Add(n);
            }
        }


        // Step 2:
        TreeNode root = deserealizedTree[0];

        Queue<TreeNode> queue = [];
        queue.Enqueue(root);
        int i = 1;
        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();

            node.left = i < deserealizedTree.Count ? deserealizedTree[i] : null;
            if (node.left != null) queue.Enqueue(node.left);
            i++;

            node.right = i < deserealizedTree.Count ? deserealizedTree[i] : null;
            if (node.right != null) queue.Enqueue(node.right);
            i++;
        }

        return root;
    }
}
