public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        
        int ROWS = image.Length;
        int COLS = image[0].Length;
        
        int colorOld = image[sr][sc];
        if (colorOld == color) {
            return image;
        }
        return Dfs(image, sr, sc, color, colorOld);
    }

    private int[][] Dfs(int[][] image, int sr, int sc, int colorNew, int colorOld) {
        int ROWS = image.Length;
        int COLS = image[0].Length;

        // Base cases
        if (Math.Min(sr, sc) < 0
            || sr == ROWS || sc == COLS 
            || image[sr][sc] != colorOld
            )
        {
            return image;
        }

        // Change the colour of the cur cell
        image[sr][sc] = colorNew;

        // Visit L R T B adjacent cells
        //visited[sr][sc] = true;
        Dfs(image, sr - 1, sc    , colorNew, colorOld);
        Dfs(image, sr    , sc - 1, colorNew, colorOld);
        Dfs(image, sr + 1, sc    , colorNew, colorOld);
        Dfs(image, sr,     sc + 1, colorNew, colorOld);

        return image;
    }
}