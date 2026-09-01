public class Solution {  
    public List<string> GenerateParenthesis(int n) {

        List<string> result = [];
        Backtrack(n, 0, [], 0, 0, result);
        return result;
    }

    private void Backtrack(int n, int i, List<char> cur, int openingCount, int closingCount, List<string> result)
    {
        // Recursion base case
        if (i == n * 2)
        {
            result.Add(new string(cur.ToArray()));
            return;
        }

        // Prune recursion branches when there is more closing brackets, which already breaks imperatives
        // and whatever other brackets will be added won't fix the imperative that any open bracket needs to be closed
        if (closingCount > openingCount)
        {
            return;
        }

        // Decision 1:  include (
        if (openingCount < n) // This if prunes the branches that are opening more parentheses that can be closed
        {
            cur.Add('(');
            Backtrack(n, i + 1, cur, openingCount + 1, closingCount, result);
            cur.RemoveAt(cur.Count - 1);
        }

        // Decision 2:  include )
        cur.Add(')');
        Backtrack(n, i + 1, cur, openingCount, closingCount + 1, result);
        cur.RemoveAt(cur.Count - 1);
    }
}
