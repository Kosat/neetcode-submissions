/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution
{
    private Dictionary<Node, Node> visited = new();

    public Node CloneGraph(Node node)
    {
        // Example 1: Input: adjList = [[2],[1,3],[2]] Output: [[2],[1,3],[2]]
        // Example 2: Input: adjList = [[]] Output: [[]]
        // Example 3: Input: adjList = [] Output: []

        // LeetCode pattern: Graphs
        // Complexity: O(V + E) time, O(V + E) extra space for recursion call stack

        if (node == null)
        {
            return null;
        }

        if (visited.ContainsKey(node))
        {
            return visited[node];
        }

        Node clone = new(node.val);
        visited[node] = clone;

        foreach (var n in node.neighbors)
        {
            var nClone = CloneGraph(n);
            clone.neighbors.Add(nClone);
        }

        return clone;
    }
}