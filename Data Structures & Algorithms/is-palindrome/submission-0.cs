public class Solution {
    public bool IsPalindrome(string s) {
        
        int n = s.Length;
        if (n == 0)
        {
            return true;
        }

        int l = 0, r = n - 1;

        while (l <= r)
        {
            if (!IsAlphaNum(s[l]))
            {
                l++;
                continue;
            }
            if (!IsAlphaNum(s[r]))
            {
                r--;
                continue;
            }

            if (char.ToLower(s[l]) != char.ToLower(s[r]))
            {
                return false;
            }

            l++;
            r--;
        }

        return true;
    }

    private bool IsAlphaNum(char ch)
    {
        bool isDigit = '0' <= ch && ch <= '9';
        bool isCapitalLetter = 'A' <= ch && ch <= 'Z';
        bool isSmallLetter = 'a' <= ch && ch <= 'z';

        return isDigit || isCapitalLetter || isSmallLetter;
    }
}