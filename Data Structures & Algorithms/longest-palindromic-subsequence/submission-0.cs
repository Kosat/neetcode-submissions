public class Solution {
    public int LongestPalindromeSubseq(string s) {
        int n = s.Length;

        int[,] memoization = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int k = 0; k < n; k++)
                memoization[i, k] = -1;

        return HelperDFS_TopDown(s, 0, s.Length - 1, memoization);
    }

    // DP Top-Dowm memoization
    private int HelperDFS_TopDown(string s, int l, int r, int[,] memoization)
    {
        // Base case
        if (l == r) return 1; // odd
        if (r - l == 1) return s[l] == s[r] ? 2 : 1; // even

        if (memoization[l, r] != -1)
            return memoization[l, r];

        int result;

        if (s[l] == s[r])
        {
            result = 2 + HelperDFS_TopDown(s, l + 1, r - 1, memoization); // Both l,r chars are equal, procced with the internal substring
        }
        else
        {
            int result1 = HelperDFS_TopDown(s, l + 1, r, memoization); // try with skipping left-most char
            int result2 = HelperDFS_TopDown(s, l, r - 1, memoization); // try with skipping right-most char

            result = Math.Max(result1, result2);
        }

        return memoization[l, r] = result;
    }
}