public class Solution {
    public bool WordBreak(string s, List<string> wordDict)
    {
        // Example 1: Input: s = "neetcode", wordDict = ["neet","code"] Output: true
        // Example 2: Input: s = "applepenapple", wordDict = ["apple","pen","ape"] Output: true
        // Example 3: Input: s = "catsincars", wordDict = ["cats","cat","sin","in","car"] Output: false

        // Implementation Plan:
        // LeetCode pattern: DP

        bool?[] memo = new bool?[s.Length + 1];
        return Bf_memoized(s, wordDict, 0, memo);
    }


    // Complexity: O(n*m*t*n) time in case of using s[i..] , O(n) extra space for memo
    // Complexity: O(n*m*t) time in case of using .AsSpan(i), O(n) extra space for memo
    private bool Bf_memoized(string s, List<string> wordBreak, int i, bool?[] memo)
    {
        // Base case
        if (i == s.Length)
        {
            return true;
        }

        if (memo[i] != null)
        {
            return memo[i].Value;
        }


        // Case 1: Check if i-th substring matches any/some words in the list
        foreach (string w in wordBreak)
        {
            // You are allowed to reuse words in the dictionary an unlimited number of times. You may assume all dictionary words are unique.
            // if (s[i..].StartsWith(w)) // KNOTE: Important s[i..] - copies the siffix of the strign wihch cost another O(n)
            // if (s.Substring(i).StartsWith(w)) // KNOTE: Important s.Substring(i) - also copies the siffix of the strign wihch cost another O(n)
            if (s.AsSpan(i).StartsWith(w))  // KNOTE: Important s.AsSpan(i) - DO NOT copy the siffix of the string and DO NOT COST extra O(n)
            {
                if (Bf_memoized(s, wordBreak, i + w.Length, memo))
                {
                    memo[i] = true;
                    return memo[i].Value;
                }
            }
        }

        // return true if s can be segmented into a space-separated sequence of dictionary words
        memo[i] = false;
        return memo[i].Value;
    }
}
