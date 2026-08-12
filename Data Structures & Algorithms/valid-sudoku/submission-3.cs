public class Solution {
    public bool IsValidSudoku(char[][] board) {
        int n = board.Length; // rows
        int m = board[0].Length; // columns
        
        var isDupFunc = (char ch, HashSet<char> dups) => {
                if (char.IsDigit(ch)) {
                    if(!dups.Add(ch)) {
                        return false;
                    }
                }
                return true;
        };

        // rows
        for(int i = 0; i < n; i++) {
            HashSet<char> dups = [];
            // columns
            for(int k = 0; k < m; k++) {
                char ch = board[i][k];
                if(!isDupFunc(ch, dups)) {
                    return false;
                }
            }
        }

        // columns
        for(int i = 0; i < m; i++) {
            HashSet<char> dups = [];
            // rows
            for(int k = 0; k < n; k++) {

                char ch = board[k][i];
                if (char.IsDigit(ch)) {
                    if(!dups.Add(ch)) {
                        return false;
                    }
                }
            }
        }

        // 3x3 boxes
        for(int i = 0; i < m; i+=3) {
            // rows
            for(int k = 0; k < n; k+=3) {
                // below is one quadrant check
                HashSet<char> dups = [];
                foreach (int s1 in Enumerable.Range(0,3)) {
                    foreach (int s2 in Enumerable.Range(0,3)) {
                        char ch = board[i+s1][k+s2];
                        if (char.IsDigit(ch)) {
                            if(!dups.Add(ch)) {
                                return false;
                            }
                        }
                    }
                }
            }
        }

        return true;
    }


}
