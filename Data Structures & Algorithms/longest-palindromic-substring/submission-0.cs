public class Solution {
    public string LongestPalindrome(string s) {
        string result = string.Empty;

        int n = s.Length;

        // Odd middle point case
        int m = 0; // the middle pointer
        int l, r; // left and right pointers

        for (; m < n; m++)
        {
            l = r = m;
            while (l >= 0 && r <= n - 1 && s[l] == s[r])
            {
                int curPalindromeLen = r - l + 1;
                if (curPalindromeLen > result.Length)
                {
                    result = s[l..(r + 1)];
                }

                l--;
                r++;
            }
        }


        // Even middle point case
        l = 0;
        m = 1;
        r = 1;

        for (; m < n; m++)
        {
            l = m - 1;
            r = m;
            while (l >= 0 && r <= n - 1 && s[l] == s[r])
            {
                int curPalindromeLen = r - l + 1;
                if (curPalindromeLen > result.Length)
                {
                    result = s[l..(r + 1)];
                }

                l--;
                r++;
            }
        }


        return result;
    }
}
