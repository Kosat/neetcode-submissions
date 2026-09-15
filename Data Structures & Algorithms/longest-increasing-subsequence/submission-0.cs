public class Solution {

    private const int NoPreviousElement = -1;
    private const int NotComputed = int.MinValue;

    public int LengthOfLIS(int[] nums) {
        
        int n = nums.Length;
        int[,] memo = new int[n + 1, n + 1]; // Note +1 is to create space for -1 index
        for (int i = 0; i <= n; i++)
        {
            for (int k = 0; k <= n; k++)
            {
                memo[i, k] = NotComputed;
            }
        }
        return Dfs_DF_Memoization(nums, 0, NoPreviousElement, memo);
    }

    // DFS with Top-Down memoization
    // Complexity: O(n^2) time, O(n^2) for memo
    public int Dfs_DF_Memoization(int[] nums, int i, int lastIncludedIdx, int[,] memo)
    {
        // Base case - reached the end of the nums array
        if (i == nums.Length)
        {
            return 0;
        }

        if (memo[i + 1, lastIncludedIdx + 1] != NotComputed)
        {
            return memo[i + 1, lastIncludedIdx + 1];
        }

        // Choice 1: include i-th
        int maxLen1 = NotComputed;
        if (lastIncludedIdx == NoPreviousElement || nums[i] > nums[lastIncludedIdx])
        {
            maxLen1 = 1 + Dfs_DF_Memoization(nums, i + 1, i, memo);
        }

        // Choice 2: exclude i-th
        int maxLen2 = 0 + Dfs_DF_Memoization(nums, i + 1, lastIncludedIdx, memo);


        // Return the MAX length of subsequence
        memo[i + 1, lastIncludedIdx + 1] = Math.Max(maxLen1, maxLen2);
        return memo[i + 1, lastIncludedIdx + 1];
    }
}
