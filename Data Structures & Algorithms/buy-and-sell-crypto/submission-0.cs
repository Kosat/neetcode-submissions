public class Solution {
    public int MaxProfit(int[] prices)
    {
        // Example 1: Input: prices = [10,1,5,6,7,1] Output: 6
        // Example 2: Input: prices = [10,8,7,5,2] Output: 0

        int maxProfit = 0;
        int minPriceSoFar = int.MaxValue;

        foreach (var price in prices)
        {
            // The best day to buy the stock
            minPriceSoFar = Math.Min(minPriceSoFar, price); // 1|+inf->10

            // Current profit if the stock being sold at this date, after being purchased at minPriceSoFar price
            int curProfit = price - minPriceSoFar; // 1|0
            maxProfit = Math.Max(maxProfit, curProfit); // 1|min(0,0)=0
        }

        return maxProfit;
    }
}