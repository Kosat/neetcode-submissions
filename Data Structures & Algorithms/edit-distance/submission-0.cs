public class Solution {
    private const int NO_CALC = -1;

    public int MinDistance(string word1, string word2)
    {
        // Example 1: Input: word1 = "monkeys", word2 = "money" Output: 2
        // Example 2: Input: word1 = "neatcdee", word2 = "neetcode" Output: 3

        // LeetCode pattern: Dynamic Programming
        // Underlying collection:  int[,]

        int[,] memo = new int[word1.Length + 1, word2.Length + 1];

        for (int i = 0; i < word1.Length + 1; i++)
            for (int k = 0; k < word2.Length + 1; k++)
                memo[i, k] = NO_CALC;

        return Bf_memoized(word1, word2, 0, 0, memo);
    }

    // Complexity: O(word1.Length*word2.Length) time, O(word1.Length*word2.Length) extra space for memo collection
    private int Bf_memoized(string word1, string word2, int p1, int p2, int[,] memo)
    {
        // Implementation Plan:
        // BF recursive approach
        // Use char indexes p1 and p2 for each of the word strings
        // Move p1, p2 LTR
        // Case 1: If word1[p1] == word2[p2], call 0 + Bf(p1+1, p2+1)
        // Case 2: If word1[p1] != word2[p2],
        // - Insert word2[p2] char into word1[p1] position and call 1+bf(p1, p2+1)
        // - Delete char at p1 char and call 1+bf(p1+1, p2)
        // - Replace char at p1 to p2's char and call 1+bf(p1+1, p2)

        // Base case: p2 == word2.Length ==> return word1.Length - word2.Length assumming deleting extra chars from word 1
        // Base case: p1 == word1.Length ==> return word1.Length - word2.Length assumming inserting extra chars from word 1

        // Base case
        if (p2 == word2.Length)
        {
            // Delete the remaining chars from word1
            return word1.Length - p1;
        }

        if (p1 == word1.Length)
        {
            // Insert all the remaining missing chars into word1
            return word2.Length - p2;
        }

        if (memo[p1, p2] != NO_CALC)
        {
            return memo[p1, p2];
        }

        int case1 = int.MaxValue;
        int case2 = int.MaxValue;
        int case3 = int.MaxValue;
        int case4 = int.MaxValue;

        // Case 1: If word1[p1] == word2[p2], call 0 + Bf()
        if (word1[p1] == word2[p2])
        {
            case1 = 0 + Bf_memoized(word1, word2, p1 + 1, p2 + 1, memo);
        }
        else
        {
            // - Insert word2[p2] char into word1[p1] position and call 1+bf()
            case2 = 1 + Bf_memoized(word1, word2, p1, p2 + 1, memo);

            // - Delete char at p1 char and call 1+bf()
            case3 = 1 + Bf_memoized(word1, word2, p1 + 1, p2, memo);

            // - Replace char at p1 to p2's char and call 1+bf()
            case4 = 1 + Bf_memoized(word1, word2, p1 + 1, p2 + 1, memo);
        }

        memo[p1, p2] = Math.Min(case1, Math.Min(case2, Math.Min(case3, case4)));
        return memo[p1, p2];
    }
}
