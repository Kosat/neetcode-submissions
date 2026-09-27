public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        
        int ROWS = image.Length;
        int COLS = image[0].Length;
        
        int colorOld = image[sr][sc];

        bool[][] visited = new bool[ROWS][];
        for (int i = 0; i < ROWS; i++) {
            visited[i] = new bool[COLS];
        }

        return Dfs(image, sr, sc, color, colorOld, visited);
    }

    private int[][] Dfs(int[][] image, int sr, int sc, int colorNew, int colorOld, bool[][] visited) {
        int ROWS = image.Length;
        int COLS = image[0].Length;

        // Base cases
        if (Math.Min(sr, sc) < 0
            || sr == ROWS || sc == COLS 
            || visited[sr][sc]
            || image[sr][sc] != colorOld
            )
        {
            return image;
        }

        // Change the colour of the cur cell
        image[sr][sc] = colorNew;

        // Visit L R T B adjacent cells
        visited[sr][sc] = true;
        Dfs(image, sr - 1, sc    , colorNew, colorOld, visited);
        Dfs(image, sr    , sc - 1, colorNew, colorOld, visited);
        Dfs(image, sr + 1, sc    , colorNew, colorOld, visited);
        Dfs(image, sr,     sc + 1, colorNew, colorOld, visited);

        return image;
    }
}