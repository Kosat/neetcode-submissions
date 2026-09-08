public class Solution {
    public int CountSubstrings(string s) {
        
        return Helper_DP_Top_Down(s);
    }

    // DP Top-Down solution
    private int Helper_DP_Top_Down(string s)
    {
        int n = s.Length;

        int count = 0;

        var memoization = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int k = 0; k < n; k++)
                memoization[i, k] = -1;

        // Check every substring within s
        for (int l = n - 1; l >= 0; l--) // every possible start (high→low so inner ranges resolve first)
        {
            for (int r = l; r < n; r++) // every possible end  → substring s[l..r]
            {
                int l1 = l, r1 = r;
                bool isPalindrome = false;
                bool isMemoization = false;
                while (l1 <= r1)
                {
                    if (memoization[l1, r1] != -1) // inner range already resolved
                    {
                        isMemoization = true;
                        isPalindrome = memoization[l1, r1] == 1;
                        break;
                    }

                    if (s[l1] != s[r1])
                    {
                        break; // mismatch → not a palindrome
                    }
                    l1++;
                    r1--;
                }

                if (!isMemoization)
                {
                    isPalindrome = l1 >= r1; // walked fully to the middle
                }

                memoization[l, r] = isPalindrome ? 1 : 0; // cache this range for larger ones
                if (isPalindrome)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
