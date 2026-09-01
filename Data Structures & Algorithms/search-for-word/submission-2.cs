public class Solution {

private record struct Coord(int C, int R) { }

    public bool Exist(char[][] board, string word)
    {

        bool result = false;

        int cols = board[0].Length;
        int rows = board.Length;

        HashSet<Coord> cur = new();

        // Traverse board
        for (int c = 0; c < cols; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                var coord = new Coord(c, r);
                cur.Add(coord);
                Backtrack(board, word, cur, coord, ref result);
                cur.Remove(coord);

                if (result)
                {
                    goto Done;
                }
            }
        }

        Done:
        return result;
    }

    private void Backtrack(char[][] board, string word, HashSet<Coord> cur, Coord coord, ref bool result)
    {
        // The rightmost pending character has to match to the corresponding i-th character in the word
        if (cur.Count >= 1 && word[cur.Count - 1] != board[coord.R][coord.C])
        {
            return;
        }

        // Base case for recursion - all the characters match, thus the whole word was found on the board
        if (word.Length == cur.Count)
        {
            result = true;
            return;
        }


        // Check neighbours left, right, bottom, top considering the board bounds
        TryVisit(board, word, cur, new Coord(coord.C - 1, coord.R), ref result);
        TryVisit(board, word, cur, new Coord(coord.C + 1, coord.R), ref result);
        TryVisit(board, word, cur, new Coord(coord.C, coord.R - 1), ref result);
        TryVisit(board, word, cur, new Coord(coord.C, coord.R + 1), ref result);
    }

    void TryVisit(char[][] board, string word, HashSet<Coord> cur, Coord coord, ref bool result)
    {
        int cols = board[0].Length;
        int rows = board.Length;

        if (coord.C < 0 || coord.C >= cols)
            return;

        if (coord.R < 0 || coord.R >= rows)
            return;

        if (cur.Contains(coord))
            return;

        cur.Add(coord);
        Backtrack(board, word, cur, coord, ref result);
        cur.Remove(coord);

    }
}
