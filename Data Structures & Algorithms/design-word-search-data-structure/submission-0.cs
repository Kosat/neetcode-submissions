public class WordDictionary {

    private const char WILD_CARD_CHR = '.';

    private class TreeNode
    {
        public Dictionary<char, TreeNode> Children { get; set; } = [];
        public bool IsWord { get; set; }
    }

    private readonly TreeNode _root;

    public WordDictionary()
    {
        // Example 1: Input: ["WordDictionary","addWord","addWord","addWord","search","search","search","search"] [[],["day"],["bay"],["may"],["say"],["day"],[".ay"],["b.."]] Output: [null, null, null, null, false, true, true, true]
        // LeetCode pattern: Trie
        _root = new TreeNode();
    }

    // O(n) time, O(n) extra space
    public void AddWord(string word)
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

    // O(n) time, O(n) extra space for recursion stack
    public bool Search(string word)
    {
        // Returns true if there is any string in the data structure that matches word or false otherwise.
        // word may contain dots '.' where dots can be matched with any letter.

        // word in search consist of '.' or lowercase English letters.

        return SearchFrom(word, 0, _root);
    }

    private bool SearchFrom(string word, int i, TreeNode node)
    {
        // Base case
        if (i == word.Length)
        {
            return node.IsWord;
        }

        char c = word[i];

        if (c != WILD_CARD_CHR)
        {
            if (node.Children.TryGetValue(c, out var child))
            {
                return SearchFrom(word, i + 1, child);
            }
            else
            {
                return false;
            }
        }
        else
        {
            foreach (var child in node.Children)
            {
                if (SearchFrom(word, i + 1, child.Value))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
