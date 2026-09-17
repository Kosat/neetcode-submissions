public class Solution {
   private const int NO_CALC = -1;

    public int Change(int amount, int[] coins)
    {
        // Example 1: Input: amount = 4, coins = [1,2,3] Output: 4
        // Example 2: Input: amount = 7, coins = [2,4] Output: 0

        // Implementation Plan:
        // LeetCode pattern: DP

        int n = coins.Length;
        int[,] memo = new int[n, amount + 1];
        for (int i = 0; i < n; i++)
            for (int k = 0; k < amount + 1; k++)
                memo[i, k] = NO_CALC;

        return Dfs_bf_memoized(amount, coins, 0, 0, memo);
    }

    // Complexity: O(n^2) time, O(n^2) extra space for memoization
    private int Dfs_bf_memoized(int amount, int[] coins, int i, int curAmount, int[,] memo)
    {
        // Base case
        if (curAmount == amount)
        {
            return 1;
        }

        if (curAmount > amount || i == coins.Length)
        {
            return 0;
        }

        if (memo[i, curAmount] != NO_CALC)
        {
            return memo[i, curAmount];
        }

        // Choice 1: Add 0.. coins
        int curCoinValue = coins[i];

        int curCombinations = 0;
        int amountTemp = curAmount;
        int k = 0;
        while (amountTemp <= amount)
        {
            amountTemp = curAmount + curCoinValue * k;
            curCombinations += Dfs_bf_memoized(amount, coins, i + 1, amountTemp, memo);
            k++;
        }

        // Return the number of distinct combinations that total up to amount.
        // If it's impossible to make up the amount, return 0.
        memo[i, curAmount] = curCombinations;
        return memo[i, curAmount];
    }
}
