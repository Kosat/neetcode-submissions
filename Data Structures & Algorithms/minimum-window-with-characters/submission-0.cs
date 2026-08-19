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

        Dictionary<char, int> charCountsOfT = [];

        foreach (char c in t)
        {
            if(charCountsOfT.TryGetValue(c, out int value))
                charCountsOfT[c] = ++value;
            else 
                charCountsOfT[c] = 1;
        }

        int minSubarrayL = -1, minSubarrayR = -1;

        int l = 0, r = 0;

        while (r < s.Length)
        {
            if(charCountsOfT.TryGetValue(s[r], out int countR)) charCountsOfT[s[r]] = --countR; 

            while (charCountsOfT.Values.All(c => c <= 0))
            {
                int curWindowLen = r - l + 1; 
                // Record the current valid window, then try to shrink it by moving 'l' right.
                if (minSubarrayL == -1 || curWindowLen < minSubarrayR - minSubarrayL + 1) {
                    minSubarrayL = l;
                    minSubarrayR = r;
                }
                if(charCountsOfT.TryGetValue(s[l], out int countL)) charCountsOfT[s[l]] = ++countL; 
                l++;
            }

            r++;
        }

        //return the shortest substring of s
        return minSubarrayL != -1 ? s[minSubarrayL..(minSubarrayR+1)] : string.Empty;
        
    }
}