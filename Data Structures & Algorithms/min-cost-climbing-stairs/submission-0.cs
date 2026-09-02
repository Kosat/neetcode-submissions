public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        // 2 <= cost.length <= 100
        int stairs = cost.Length;

        int[] dp = new int[stairs + 1];

        // "You may choose to start at the index 0 or the index 1 floor."
        // You don't pay to stand on a floor — you pay cost[i] when you step off it.
        dp[0] = 0;
        dp[1] = 0;

        for (int i = 2; i <= stairs; i++)
        {
            dp[i] = Math.Min(cost[i - 1] + dp[i - 1], cost[i - 2] + dp[i - 2]);
        }

        return dp[stairs];
    }
}
