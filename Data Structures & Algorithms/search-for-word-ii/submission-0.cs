public class Solution
{

    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool IsWord = false;

        public void AddWord(string word)
        {
            TrieNode cur = this;
            foreach (char c in word)
            {
                if (!cur.Children.ContainsKey(c))
                {
                    cur.Children[c] = new TrieNode();
                }
                cur = cur.Children[c];
            }
            cur.IsWord = true;
        }
    }

    private bool[,] visit;
    private HashSet<string> res = new();

    public List<string> FindWords(char[][] board, string[] words)
    {
        // Example 1: Input: board = [["a","b","c","d"],["s","a","a","t"],["a","c","k","e"],["a","c","d","n"]], words = ["bat","cat","back","backend","stack"] Output: ["cat","back","backend"]
        // Example 2: Input: board = [["x","o"],["x","o"]], words = ["xoxo"] Output: []


        // LeetCode pattern: Trie + Backtracking

        TrieNode root = new();
        foreach (string word in words)
        {
            root.AddWord(word);
        }

        int rows = board.Length;
        int cols = board[0].Length;

        visit = new bool[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Dfs(board, r, c, root, "");
            }
        }

        return res.ToList();
    }

    // Complexity: O(n*m*3^t) time, O(m*n) extra space . Where t - is the max length of the word
    public void Dfs(char[][] board, int r, int c, TrieNode node, string word)
    {
        int rows = board.Length;
        int cols = board[0].Length;

        // Check bounds
        if (r < 0 || r >= rows)
        {
            // Cannot continue with this path on the board
            return;
        }
        if (c < 0 || c >= cols)
        {
            // Cannot continue with this path on the board
            return;
        }
        if (visit[r, c])
        {
            return;
        }


        char curChar = board[r][c];

        if (node.Children.TryGetValue(curChar, out var next))
        {
            node = next;
            word += curChar;
        }
        else
        {
            // Cannot continue with this path on the board
            return;
        }

        visit[r, c] = true;

        // Check if word matches
        if (node.IsWord)
        {
            res.Add(word);
        }


        // Recursion cases - check the adjacent chars

        Dfs(board, r + 1, c, node, word);
        Dfs(board, r - 1, c, node, word);
        Dfs(board, r, c + 1, node, word);
        Dfs(board, r, c - 1, node, word);

        visit[r, c] = false;
    }
}
