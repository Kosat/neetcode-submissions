public class Solution {
    private const int NO_CALC = -1;

    public int MaxCoins(int[] nums)
    {
        // Example 1: Input: nums = [4,2,3,7] Output: 143

        List<int> newNums = [1, .. nums, 1];
        int n = newNums.Count;
        // return Dfs(newNums);

        int[,] memo = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                memo[i, j] = NO_CALC;

        return Dfs_memoized(newNums, 0, n - 1, memo);
    }

    // DF Top-down
    public int Dfs_memoized(List<int> nums, int l, int r, int[,] memo)
    {
        // Base case - the empty window
        if (r - l <= 1)
        {
            return 0;
        }

        // Memo check
        if (memo[l, r] != NO_CALC)
        {
            return memo[l, r];
        }

        // Iterate over l..r window and burst at each position within this window
        int maxProfit = 0;
        for (int k = l + 1; k <= r - 1; k++)
        {
            int profitLeft = Dfs_memoized(nums, l, k, memo);
            int profitK = nums[l] * nums[k] * nums[r];
            int profitRight = Dfs_memoized(nums, k, r, memo);
            maxProfit = Math.Max(profitLeft + profitK + profitRight, maxProfit);
        }

        return memo[l, r] = maxProfit;
    }
}
