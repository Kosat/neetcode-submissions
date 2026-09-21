public class PrefixTree {

    private class TreeNode
    {
        public Dictionary<char, TreeNode> Children { get; set; } = [];
        public bool IsWord { get; set; }
    }

    private readonly TreeNode _root;

    public PrefixTree()
    {
        // Example 1: Input: ["Trie", "insert", "dog", "search", "dog", "search", "do", "startsWith", "do", "insert", "do", "search", "do"] Output: [null, null, true, false, true, null, true]
        // LeetCode pattern: Trie

        _root = new TreeNode();
    }

    // O(n) time, O(n) extra space , Where n - is the length of the word string
    public void Insert(string word)
    {
        TreeNode cur = _root;
        foreach (char c in word)
        {
            if (cur.Children.TryGetValue(c, out var node))
            {
                cur = node;
            }
            else
            {
                var curNew = new TreeNode();
                cur.Children.Add(c, curNew);
                cur = curNew;
            }
        }

        cur.IsWord = true;
    }

    // O(n) time, O(1) extra space , Where n - is the length of the word string
    public bool Search(string word)
    {
        TreeNode cur = _root;
        foreach (char c in word)
        {
            if (cur.Children.TryGetValue(c, out var node))
            {
                cur = node;
            }
            else
            {
                return false;
            }
        }

        return cur.IsWord;
    }

    // O(m) time, O(1) extra space , Where m - is the length of the prefix string
    public bool StartsWith(string prefix)
    {
        TreeNode cur = _root;
        foreach (char c in prefix)
        {
            if (cur.Children.TryGetValue(c, out var node))
            {
                cur = node;
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
