public class Solution {
    public List<List<string>> SolveNQueens(int n) {
        
        List<List<string>> result = [];

        // Init empty board of n*n square size
        List<string> board = [];
        for (int i = 0; i < n; i++)
        {
            StringBuilder row = new();
            for (int k = 0; k < n; k++)
            {
                row.Append('.');
            }
            board.Add(row.ToString());
        }

        Backtrack(n, board, 0, result);
        return result;
    }

    private void Backtrack(int n, List<string> board, int row, List<List<string>> result)
    {

        // Check invariant

        // Base case for backtracking recursion
        if (row == n)
        {
            List<string> boardResult = [];
            foreach (string r in board)
            {
                StringBuilder resultRow = new();
                foreach (char cell in r)
                    resultRow.Append(cell == 'Q' ? 'Q' : '.');
                boardResult.Add(resultRow.ToString());
            }
            result.Add(boardResult);
            return;
        }

        // Place one queen in the current row
        for (int c = 0; c < n; c++)
        {
            // Mark all the horizontal, vertical and diagonal board cells to be under attack
            if (!TryAddQueenToTheBoard(row, c, board))
            {
                continue;
            }

            Backtrack(n, board, row + 1, result);
            RemoveQueenFromTheBoard(row, c, board);
        }

    }

    private bool TryAddQueenToTheBoard(int row, int col, List<string> board)
    {
        // The cell is under attack if it already holds an attack digit
        if (board[row][col] != '.')
        {
            return false;
        }

        SetCell(board, row, col, 'Q');
        int n = board.Count;

        // Mark the whole row and column as attacked
        for (int i = 0; i < n; i++)
        {
            if (i != col) MarkAttacked(board, row, i);
            if (i != row) MarkAttacked(board, i, col);
        }

        // Mark both diagonals as attacked
        for (int d = 1; d < n; d++)
        {
            if (row + d < n && col + d < n) MarkAttacked(board, row + d, col + d);
            if (row + d < n && col - d >= 0) MarkAttacked(board, row + d, col - d);
            if (row - d >= 0 && col + d < n) MarkAttacked(board, row - d, col + d);
            if (row - d >= 0 && col - d >= 0) MarkAttacked(board, row - d, col - d);
        }

        return true;
    }

    private void RemoveQueenFromTheBoard(int row, int col, List<string> board)
    {
        SetCell(board, row, col, '.');
        int n = board.Count;

        // Unmark the whole row and column
        for (int i = 0; i < n; i++)
        {
            if (i != col) UnmarkAttacked(board, row, i);
            if (i != row) UnmarkAttacked(board, i, col);
        }

        // Unmark both diagonals
        for (int d = 1; d < n; d++)
        {
            if (row + d < n && col + d < n) UnmarkAttacked(board, row + d, col + d);
            if (row + d < n && col - d >= 0) UnmarkAttacked(board, row + d, col - d);
            if (row - d >= 0 && col + d < n) UnmarkAttacked(board, row - d, col + d);
            if (row - d >= 0 && col - d >= 0) UnmarkAttacked(board, row - d, col - d);
        }
    }

    private void MarkAttacked(List<string> board, int r, int c)
    {
        char cell = board[r][c];
        if (cell == '.')
            SetCell(board, r, c, '1');
        else
            SetCell(board, r, c, (char)(cell + 1));
    }

    private void UnmarkAttacked(List<string> board, int r, int c)
    {
        char cell = board[r][c];
        if (cell == '1')
            SetCell(board, r, c, '.');
        else
            SetCell(board, r, c, (char)(cell - 1));
    }

    private void SetCell(List<string> board, int r, int c, char value)
    {
        char[] chars = board[r].ToCharArray();
        chars[c] = value;
        board[r] = new string(chars);
    }
}
