public class Solution {
    public int CoinChange(int[] coins, int amount) {
        
        int[] memo = new int[amount + 1];
        Array.Fill(memo, int.MaxValue);
        return Helper_DP_Top_Down(coins, amount, memo);
    }

    // DP Top-Down with memoization
    // Time:  O(n*amount)
    // Space: O(amount) - recursion stack; each call subtracts >= 1, so depth <= amount
    public int Helper_DP_Top_Down(int[] coins, int amount, int[] memo)
    {
        int n = coins.Length;

        // Base case
        if (amount == 0)
        {
            return 0;
        }

        // This recursion branch did not led to the valid result. Disregard it.
        if (amount < 0)
        {
            return -1;
        }

        if (memo[amount] != int.MaxValue) // Cache hit
        {
            return memo[amount];
        }

        int minCount = -1;
        // Simply try every coin denomination available in the count of 1 at this level of recursion
        for (int i = 0; i < n; i++)
        {
            int curCoinValue = coins[i];
            int amountRemainder = amount - curCoinValue;
            int curCoinsCount = Helper_DP_Top_Down(coins, amountRemainder, memo);
            if (curCoinsCount != -1)
            {
                minCount = Math.Min(minCount == -1 ? int.MaxValue : minCount, 1 + curCoinsCount);
            }
        }

        memo[amount] = minCount;
        return minCount;
    }
}
