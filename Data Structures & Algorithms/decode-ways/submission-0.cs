public class Solution {
    public int NumDecodings(string s) {
        int[] memo = new int[s.Length + 1];
        Array.Fill(memo, -1);
        return Helper_DP_Top_Down(s, 0, memo);
    }

    // DP Top-Down solution
    // O(n) time, O(n) extra space for memo DP cache
    private int Helper_DP_Top_Down(string s, int i, int[] memo)
    {
        int n = s.Length;

        // Base case: one full decode completed
        if (i == n)
        {
            return 1;
        }

        // Guard against singular zeros and leading zeros in 2-digit case
        if (s[i] == '0')
        {
            return 0; // no character maps to '0'
        }

        if (memo[i] != -1)
        {
            return memo[i];
        }

        // If we reached this point that meands the left-side digits could be successfully parsed
        // So we can branch out into the further 1- and 2- digit cases

        // Case 1: one digit
        int result = memo[i + 1] = Helper_DP_Top_Down(s, i + 1, memo);

        // Case 2: two digits
        if (i + 1 < n)
        {
            int digit1 = s[i] - '0';
            int digit2 = s[i + 1] - '0';
            int twoDigits = 10 * digit1 + digit2;

            if (0 < twoDigits && twoDigits <= 26)
            {
                memo[i + 2] = Helper_DP_Top_Down(s, i + 2, memo);
                result += memo[i + 2];
            }
        }

        // result contains the number of ways to decode the entire string,
        // equals the number of good leaves int the decision tree
        return result;
    }
}
