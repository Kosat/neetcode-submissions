public class Solution {
    public int OrangesRotting(int[][] grid)
    {
        // Example 1: Input: grid = [[1,1,0],[0,1,1],[0,1,2]] Output: 4
        // Example 2: Input: grid = [[1,0,1],[0,2,0],[1,0,1]] Output: -1

        return Bfs(grid);
    }

    // LeetCode pattern: Graphs
    // Complexity: O(m*n) time (each cell is queued at most once), O(m*n) extra space (the queue)
    // Underlying collection: Queue
    private int Bfs(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        Queue<(int r, int c)> rottenFruits = [];

        const int Fresh = 1;
        const int Rotten = 2;

        int freshFruitsCount = 0;
        // Phase 1: queue all the initially rotten fruits and count the fresh ones
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == Rotten)
                {
                    rottenFruits.Enqueue((r, c));
                }
                else if (grid[r][c] == Fresh)
                {
                    freshFruitsCount++;
                }
            }
        }

        // Rot the fruit at (r, c) if it is inside the grid and fresh, and queue it to spread next minute.
        // Marking it rotten before it is queued means no cell is ever queued twice.
        void RotIfFresh(int r, int c)
        {
            if (r < 0 || r >= rows || c < 0 || c >= cols || grid[r][c] != Fresh)
            {
                return;
            }

            grid[r][c] = Rotten;
            freshFruitsCount--;
            rottenFruits.Enqueue((r, c));
        }

        // Phase 2: multi-source BFS, one pass per minute: last minute's rotten fruits rot their fresh neighbours
        int minutesElapsed = 0;
        while (rottenFruits.Count > 0 && freshFruitsCount > 0)
        {
            int size = rottenFruits.Count;
            for (int i = 0; i < size; i++)
            {
                var (r, c) = rottenFruits.Dequeue();

                RotIfFresh(r - 1, c);
                RotIfFresh(r + 1, c);
                RotIfFresh(r, c - 1);
                RotIfFresh(r, c + 1);
            }
            minutesElapsed++;
        }

        // Return the minimum number of minutes that must elapse until there are zero fresh fruits remaining.
        // If this state is impossible within the grid, return -1

        return freshFruitsCount == 0 ? minutesElapsed : -1;
    }
}
