public class Solution {
    public int Rob(int[] nums) {
        
        return RobHelper(nums, 0, new int[nums.Length + 1]);
    }

    // This is top-down memoization solution
    private int RobHelper(int[] nums, int i, int[] dp)
    {
        // You cannot rob two adjacent houses
        // Return the maximum amount of money

        // Base case
        if (i >= nums.Length)
        {
            return 0;
        }

        if (dp[i] != 0)
        {
            return dp[i];
        }

        // Choose to rob i-th house and skip the next one
        int case1 = nums[i] + RobHelper(nums, i + 2, dp);
        // Choose NOT to rob i-th house and try the next one
        int case2 = 0 + RobHelper(nums, i + 1, dp);

        return dp[i] = Math.Max(case1, case2);
    }
}
