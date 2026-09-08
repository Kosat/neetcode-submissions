public class Solution {
    public int CountSubstrings(string s) {
        
        return Helper_2_pointers_expand_v02(s);
    }


    // 2 Pointer optimal solution
    // With tidied up code to remove repeting code
    private int Helper_2_pointers_expand_v02(string s)
    {
        int n = s.Length;

        int l, r;
        int count = 0;

        var expand = (int l, int r) =>
        {
            while (l >= 0 && r < n && s[l] == s[r])
            {
                count++;
                l--;
                r++;
            }
        };

        // Iterate over each s' char LTR and try to expand substrings around it as a middle point
        for (int m = 0; m < n; m++)
        {
            // Odd case
            expand(m, m);
            // Even case
            expand(m - 1, m);

        }

        return count;
    }
}
