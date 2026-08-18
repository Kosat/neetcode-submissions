public class Solution {
    public int CharacterReplacement(string s, int k) {
        // Example 1: Input: s = "XYYX", k = 2 Output: 4
        // Example 2: Input: s = "AAABABB", k = 1 Output: 5

        if(string.IsNullOrEmpty(s)) return 0;
        if(s.Length == 1) return 1;

        int l = 0, r = 1;

        int result = 0;

        int[] freq = new int[26];
        freq[s[l]-'A'] = 1; 
        //int curMajorityLetter = s[l];
        int curMajorityLetterFreq = 1;

        while (r < s.Length)
        {
            // Check if by moving R we have changed the Majority Letter
            freq[s[r]-'A']++;
            if(freq[s[r]-'A'] > curMajorityLetterFreq)
            {
                //curMajorityLetter = s[r];
                curMajorityLetterFreq = freq[s[r]-'A'];
            }

            int slidingWindowLen = r - l + 1;

            if (slidingWindowLen - (curMajorityLetterFreq + k) > 0) // the count of non-majority letters overtook the majority+k_allowed_replacements
            {
                // Imperative is broken, reposition l to regain imperative
                freq[s[l]-'A']--;
                l++;
                slidingWindowLen--;
            }

            result = Math.Max(slidingWindowLen, result);

            r++;
        }

        return result;
    }
}
