// https://neetcode.io/problems/permutation-string/question?list=neetcode150

public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        // Example 1: Input: s1 = "abc", s2 = "lecabee" Output: true
        // Example 2: Input: s1 = "abc", s2 = "lecaabee" Output: false
        // Example 2: Input: s1 = "a", s2 = "lecaabee" Output: true
        // 1 <= s1.length, s2.length <= 10000

        // Edge case when s1 cannot possibly be a substring of s2
        if(s2.Length < s1.Length)
        {
            return false;
        }

        // Sliding Window approach.
        Dictionary<char, int> s1Freq = [];

        // Fill-in the characters frequencies once for s1
        foreach(char c in s1)
        {
            if(s1Freq.ContainsKey(c))
            {
                s1Freq[c]++;
            }
            else
            {
                s1Freq[c] = 1;
            }
        }

        int l = 0, r = 0;

        // Start with a 1-char-long sliding window and then expand it up to the length of the s1
        while (r < s2.Length)
        {
            int windowLen = r - l + 1;
            char rChar = s2[r];

            // Char enters the window: reduce its deficit.
            if(s1Freq.ContainsKey(rChar))
            {
                s1Freq[rChar]--;
            }

            // The window is a permutation of s1 if every deficit is exactly 0.
            if(s1Freq.Values.All(v => v == 0))
            {
                return true;
            }

            // Expand window until it reaches the length of s1 string.
            // Once expanded to s1 length, slide the whole window LTR by one char, until r reaches the end of s2.
            if(windowLen == s1.Length)
            {
                char lChar = s2[l];
                // Char leaves the window: restore its deficit.
                if(s1Freq.ContainsKey(lChar))
                {
                    s1Freq[lChar]++;
                }
                // The sliding window length should not exceed s1 length, therefor move l pointer +1 to catch up with r
                // maintaing the sliding window length imperative
                l++;
            }

            r++;
        }

        return false;
    }
}