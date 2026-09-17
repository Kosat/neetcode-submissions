public class Solution {
    
    private const int NO_CALC = -1;

    public int MaxProfit(int[] prices)
    {
        // Example 1: Input: prices = [1,3,4,0,4] Output: 6
        // Example 2: Input: prices = [1] Output: 0

        // LeetCode pattern: DP

        int n = prices.Length;
        int[,] memo = new int[n, n + 1];
        for (int i = 0; i < n; i++)
            for (int k = 0; k < n + 1; k++)
                memo[i, k] = NO_CALC;

        return Dfs_bf_memo(prices, 0, -1, memo);
        // return Dfs_bf(prices, 0, -1);
    }

    // Complexity: O(n^2) time, O(n^2) extra space for memo
    private int Dfs_bf_memo(int[] prices, int i, int lastPurchaseDayIdx, int[,] memo)
    {
        // Base case - all prices are done
        if (i >= prices.Length)
        {
            return 0;
        }

        int choice1 = 0;
        int choice2 = 0;
        int choice3 = 0;

        if (memo[i, lastPurchaseDayIdx + 1] != NO_CALC)
        {
            return memo[i, lastPurchaseDayIdx + 1];
        }

        if (lastPurchaseDayIdx != -1)
        {
            // Case 2 - Sell
            int profit = prices[i] - prices[lastPurchaseDayIdx];
            choice2 = profit + Dfs_bf_memo(prices, i + 2, -1, memo);
        }

        if (lastPurchaseDayIdx == -1)
        {
            // Case 1 - Buy
            choice1 = Dfs_bf_memo(prices, i + 1, i, memo);
        }


        // Case 3 - Skip Buying or Selling on this day
        choice3 = Dfs_bf_memo(prices, i + 1, lastPurchaseDayIdx, memo);

        memo[i, lastPurchaseDayIdx + 1] = Math.Max(choice1, Math.Max(choice2, choice3));
        return memo[i, lastPurchaseDayIdx + 1];
    }
}
