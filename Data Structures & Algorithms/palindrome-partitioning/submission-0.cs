public class Solution {
    public List<List<string>> Partition(string s) {
        
        List<List<string>> result = [];
        Backtrack(s, 0, [], result);
        return result;
    }

    private void Backtrack(string s, int i, List<string> curPartition, List<List<string>> result)
    {
        // Base case for backtracking
        if (i == s.Length)
        {
            result.Add([.. curPartition]);
            return;
        }

        for (int k = i; k < s.Length; k++)
        {
            string curSubstringSoFar = s[i..(k + 1)];
            if (IsPalindrome(curSubstringSoFar))
            {
                curPartition.Add(curSubstringSoFar);
                Backtrack(s, k + 1, curPartition, result);
                curPartition.RemoveAt(curPartition.Count - 1);
            }
        }
    }

    private bool IsPalindrome(string s)
    {
        if (s.Length == 0)
        {
            return false;
        }

        int l = 0, r = s.Length - 1;

        while (l <= r)
        {
            if (s[l] != s[r])
            {
                return false;
            }

            l++;
            r--;
        }

        return true;
    }
}
