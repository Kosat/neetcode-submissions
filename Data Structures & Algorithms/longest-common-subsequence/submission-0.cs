public class Solution {
    private const int NO_CALC = -1;
    public int LongestCommonSubsequence(string text1, string text2)
    {
        // Example 1: Input: text1 = "cat", text2 = "crabt" Output: 3
        // Example 2: Input: text1 = "abcd", text2 = "abcd" Output: 4
        // Example 3: Input: text1 = "abcd", text2 = "efgh" Output: 0

        // Implementation Plan:
        // LeetCode pattern: Dynamic Programming
        int[,] memo = new int[text1.Length, text2.Length];

        for (int i = 0; i < text1.Length; i++)
            for (int k = 0; k < text2.Length; k++)
                memo[i, k] = NO_CALC;

        return Bf_memoized(text1, text2, 0, 0, memo);
        // return Bf(text1, text2, 0, 0);
    }

    // O(n*m) time, O(n*m) extra space for memo.
    private int Bf_memoized(string text1, string text2, int p1, int p2, int[,] memo)
    {
        // Recursive Brute Force approach - traverse the decision tree
        // Use p1 pointer containing char index within text1 string, moving LTR
        // Use p2 pointer containing char index within text2 string, moving LTR
        // If text1[p1] == text2[p2] then add LCS+1 and move both p1+1 and p2+1
        // If text1[p1] != text2[p2] then add LCS+0 and
        //  - do recursive call with p1+1
        //  - do recursive call with p2+1
        //  Find the MAX between the return values from recursive calls for text1[p1] != text2[p2]
        // Base case p1 == text1.Length OR p2 == text2.Length , return 0

        // Base case
        if (p1 == text1.Length || p2 == text2.Length)
        {
            return 0;
        }

        if (memo[p1, p2] != NO_CALC)
        {
            return memo[p1, p2];
        }

        if (text1[p1] == text2[p2])
        {
            // Case 1 - chars match

            memo[p1, p2] = 1 + Bf_memoized(text1, text2, p1 + 1, p2 + 1, memo);
            return memo[p1, p2];
        }
        else
        {
            // Case 2 - chars mismatch
            memo[p1, p2] = Math.Max(
                Bf_memoized(text1, text2, p1 + 1, p2, memo),
                Bf_memoized(text1, text2, p1, p2 + 1, memo)
            );

            return memo[p1, p2];
        }
    }
}
