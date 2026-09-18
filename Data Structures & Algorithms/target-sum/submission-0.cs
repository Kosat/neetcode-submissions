public class Solution {

    private const int NO_CALC = int.MinValue;

    public int FindTargetSumWays(int[] nums, int target)
    {
        // Example 1: Input: nums = [2,2,2], target = 2 Output: 3

        //return Dfs_bf(nums, target, 0, 0);
        int n = nums.Length;
        int totalSum = nums.Sum();
        int[,] memo = new int[n, 2 * totalSum + 1];
        for (int i = 0; i < n; i++)
            for (int k = 0; k < 2 * totalSum + 1; k++)
                memo[i, k] = NO_CALC;

        return Dfs_bf_memoized(nums, target, 0, 0, memo, totalSum);
    }

    // Complexity: O(n^2) time, O(n^2) extra space for recursion callstack
    private int Dfs_bf_memoized(int[] nums, int target, int i, int curSum, int[,] memo, int totalSum)
    {
        int n = nums.Length;

        // Base case - processed all the nums
        if (i == n)
        {
            return curSum == target ? 1 : 0;
        }

        if (memo[i, totalSum + curSum] != NO_CALC)
        {
            return memo[i, totalSum + curSum];
        }

        // Case 1 - add i-th item
        int case1 = Dfs_bf_memoized(nums, target, i + 1, curSum + nums[i], memo, totalSum);

        // Case 2 - subtract i-th item
        int case2 = Dfs_bf_memoized(nums, target, i + 1, curSum - nums[i], memo, totalSum);

        // Return the number of different ways that you can build the expression such that the total sum equals target.
        memo[i, totalSum + curSum] = case1 + case2;
        return memo[i, totalSum + curSum];
    }
}
