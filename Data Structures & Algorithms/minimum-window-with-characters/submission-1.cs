public class Solution {
    public string MinWindow(string s, string t) {
        // Example 1: Input: s = "OUZOD YXAZ V", t = "XYZ" Output: "YXAZ"
        // Example 2: Input: s = "xyz", t = "xyz" Output: "xyz"
        // Example 3: Input: s = "x", t = "xy" Output: ""

        // Both s and t can contain duplicate characters.
        if (s.Length < t.Length)
        {
            return string.Empty;
        }

        Dictionary<char, int> needCounts = [];

        foreach (char c in t)
            needCounts[c] = needCounts.GetValueOrDefault(c) + 1;

        int need = needCounts.Count;   // distinct chars in t
        int have = 0;                  // distinct chars currently satisfied

        int minSubarrayL = -1, minSubarrayR = -1;
        int l = 0, r = 0;

        while (r < s.Length)
        {
            if (needCounts.TryGetValue(s[r], out int countR))
            {
                needCounts[s[r]] = --countR;
                if (countR == 0) have++;   // this char just became satisfied
            }

            while (have == need) //(charCountsOfT.Values.All(c => c <= 0))
            {
                int curWindowLen = r - l + 1; 
                // Record the current valid window, then try to shrink it by moving 'l' right.
                if (minSubarrayL == -1 || curWindowLen < minSubarrayR - minSubarrayL + 1) {
                    minSubarrayL = l;
                    minSubarrayR = r;
                }
                
                if (needCounts.TryGetValue(s[l], out int countL))
                {
                    needCounts[s[l]] = ++countL;
                    if (countL == 1) have--;   // this char just became unsatisfied
                }
                l++;
            }

            r++;
        }

        //return the shortest substring of s
        return minSubarrayL != -1 ? s[minSubarrayL..(minSubarrayR+1)] : string.Empty;
        
    }
}
