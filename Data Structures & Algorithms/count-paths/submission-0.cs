public class Solution {
    public int UniquePaths(int m, int n) {
        
        int[,] memo = new int[m, n];
        return Dfs_bf_memo(m, n, 0, 0, memo);
    }

    // Top-Down memoized
    // Complexity: O(m*n) time, O(n*m) extra space for memo collection
    private int Dfs_bf_memo(int m, int n, int r, int c, int[,] memo)
    {
        // Base cases - reached the opposite corner
        if (c == n - 1 && r == m - 1)
        {
            return 1;
        }

        // Base case - cannot move outside the board bounds
        if (c >= n || r >= m)
        {
            return 0;
        }

        if (memo[r, c] != 0)
        {
            return memo[r, c];
        }

        // Choice 1: move bottom
        int choice1 = Dfs_bf_memo(m, n, r + 1, c, memo);

        // Choice 2: move right
        int choice2 = Dfs_bf_memo(m, n, r, c + 1, memo);

        memo[r, c] = choice1 + choice2;
        return memo[r, c];
    }
}
