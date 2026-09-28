public class Solution
{
    public int NumIslands(char[][] grid)
    {
        // Example 1: Input: grid = [["0","1","1","1","0"],["0","1","0","1","0"],["1","1","0","0","0"],["0","0","0","0","0"]] Output: 1
        // Example 2: Input: grid = [["1","1","0","0","1"],["1","1","0","0","1"],["0","0","1","0","0"],["0","0","0","1","1"]] Output: 4

        // LeetCode pattern: Graphs

        int ROWS = grid.Length;
        int COLS = grid[0].Length;
        bool[][] visited = new bool[ROWS][];
        for (int i = 0; i < ROWS; i++)
        {
            visited[i] = new bool[COLS];
        }

        int islandsCount = 0;
        for (int r = 0; r < ROWS; r++)
        {
            for (int c = 0; c < COLS; c++)
            {
                islandsCount += Dfs(grid, r, c, visited);
            }
        }

        return islandsCount;
    }

    // O(m*n) time, O(m*n) extra space
    private int Dfs(char[][] grid, int r, int c, bool[][] visited)
    {
        int ROWS = grid.Length;
        int COLS = grid[0].Length;

        // Base case
        if (Math.Min(r, c) < 0
        || r == ROWS || c == COLS
        || visited[r][c]
        || grid[r][c] == '0' // water
        )
        {
            return 0;
        }

        // Visit L R B T
        visited[r][c] = true;

        Dfs(grid, r - 1, c, visited);
        Dfs(grid, r + 1, c, visited);
        Dfs(grid, r, c - 1, visited);
        Dfs(grid, r, c + 1, visited);

        return 1;
    }
}
