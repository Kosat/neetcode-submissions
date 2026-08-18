public class Solution {
    public int LengthOfLongestSubstring(string s) {
        
        if(string.IsNullOrEmpty(s)) return 0;
        if(s.Length == 1) return 1;

        Dictionary<char, int> seenChars = [];
        int maxLenWithoutDuplicates = 0;
        int curMaxLen = 0;
        int l = 0, r = 0;

        while(r < s.Length) {
            char curChar = s[r];
            if(seenChars.TryGetValue(curChar, out int prevIdx)) {
                // every char from l..prevIdx is leaving the window as l jumps past it, so it's no longer "seen"
                for (int idx = l; idx <= prevIdx; idx++) {
                    seenChars.Remove(s[idx]);
                }
                l = prevIdx + 1; // shift left pointer to the next char after the found duplicate, so that l..r subarray would not have dups imperative
                curMaxLen = r - l + 1;
            } else {
                curMaxLen++;
            }
            seenChars[curChar] = r;
            maxLenWithoutDuplicates = Math.Max(maxLenWithoutDuplicates, curMaxLen);
            r++;
        }

        return maxLenWithoutDuplicates;
    }

}
