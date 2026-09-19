public class Solution {
    public bool IsInterleave(string s1, string s2, string s3)
    {
        // Example 1: Input: s1 = "aaaa", s2 = "bbbb", s3 = "aabbbbaa" Output: true
        // Example 2: Input: s1 = "", s2 = "", s3 = "" Output: true
        // Example 3: Input: s1 = "abc", s2 = "xyz", s3 = "abxzcy" Output: false

        if (s1.Length + s2.Length != s3.Length)
        {
            return false;
        }

        bool?[,] memo = new bool?[s1.Length + 1, s2.Length + 1];
        return Bf_memoized(s1, s2, s3, 0, 0, memo);
        // return Bf(s1, s2, s3, 0, 0);
    }


    // Complexity: O(s1Len * s2Len) time, O(s1Len * s2Len) extra space for memo
    private bool Bf_memoized(string s1, string s2, string s3, int ps1, int ps2, bool?[,] memo)
    {
        // My BF approach:
        // Iterate over s3 string's characters recursively (the cur s3 pointer equals to ps1+ps2)
        // Try to match this char to the cur chars in s1 or s2.
        // - if matches s1 current char only - move ps1 pointer forward
        // - if matches s2 current char only - move ps2 pointer forward
        // - if matches both s1 and s2 current chars - make two recursive calls for each of the matches
        // - if does not match any cur s1 nor s2 - return false from recursion.


        // Base case
        if (ps1 + ps2 == s3.Length) // +2 is b/c ps1 and ps2 are zero-based pointers
        {
            return true;
        }

        // Memo cache
        if (memo[ps1, ps2] != null)
        {
            return memo[ps1, ps2].Value;
        }

        int ps3 = ps1 + ps2;

        bool choice2 = false;
        bool choice3 = false;

        // Case 2 - ps1 char matches s3 i-th char (also covers the "both match" case,
        // since Case 3 below fires independently whenever s2's char matches too)
        if (ps1 < s1.Length && s3[ps3] == s1[ps1])
        {
            choice2 = Bf_memoized(s1, s2, s3, ps1 + 1, ps2, memo);
        }

        // Case 3 - ps2 char matches s3 i-th char
        if (ps2 < s2.Length && s3[ps3] == s2[ps2])
        {
            choice3 = Bf_memoized(s1, s2, s3, ps1, ps2 + 1, memo);
        }

        memo[ps1, ps2] = choice2 || choice3;
        return memo[ps1, ps2].Value;
    }
}
