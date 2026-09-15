public class Solution {
    public bool CanPartition(int[] nums) {
        
        int total = nums.Sum();

        if (total % 2 == 1)
        {
            return false;
        }

        int n = nums.Length;
        bool?[,] memo = new bool?[n + 1, total / 2 + 1];

        // return Dfs_bf(nums, 0, total / 2);
        return Dfs_bf_top_down_memoized(nums, 0, total / 2, memo);
    }

    // BF improved - DFS recursive + Top-down memoization
    // Complexity: O(n*total) time, O(n*total) extra space - for memo
    private bool Dfs_bf_top_down_memoized(int[] nums, int i, int remainder, bool?[,] memo)
    {
        int n = nums.Length;

        // Base case - reached the correct sum (aka remainder = 0)
        if (i == n)
        {
            return remainder == 0;
        }

        if (remainder < 0) { return false; }


        if (memo[i, remainder] != null)
        {
            return memo[i, remainder].Value;
        }

        // Case 1 - take i-th into first partition
        bool take = Dfs_bf_top_down_memoized(nums, i + 1, remainder - nums[i], memo);


        // Case 2 - skip i-th from first partition
        bool skip = Dfs_bf_top_down_memoized(nums, i + 1, remainder, memo);

        memo[i, remainder] = take || skip;

        return memo[i, remainder].Value;
    }
}
