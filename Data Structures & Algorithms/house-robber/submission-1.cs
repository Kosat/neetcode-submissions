public class Solution {
    public int Rob(int[] nums)
        => RobHelper(nums);

    private int RobHelper(int[] nums)
    {
        int n = nums.Length;

        if (n == 0) return 0;
        if (n == 1) return nums[0];

        int[] dp = new int[n + 2];
        dp[0] = 0;
        dp[1] = nums[0];

        for (int i = 2; i <= n; i++)
        {
            dp[i] = Math.Max(0 + dp[i - 1], nums[i - 1] + dp[i - 2]);
        }

        return dp[n];
    }
}
