public class Solution {
    public int Rob(int[] nums) {
        
        int n = nums.Length;
        int[] seen = new int[n + 1];
        Array.Fill(seen, NOT_CALCULATED);
        return Math.Max(
            nums[0] + Dfs_BruteForce(nums, 0 + 2, [.. seen], [nums.Length - 1]),
                  0 + Dfs_BruteForce(nums, 0 + 1, [.. seen], [0])
        );
    }

    private const int NOT_CALCULATED = -1;

    private int Dfs_BruteForce(int[] nums, int i, int[] seen, int[] exclude)
    {
        // Base case
        if (i >= nums.Length || i == exclude[0])
        {
            return 0;
        }

        // Cache check
        if (seen[i] != NOT_CALCULATED)
        {
            return seen[i];
        }

        // Case 1 - rob the i-th house and skip the i+1
        int case1 = nums[i] + Dfs_BruteForce(nums, i + 2, seen, exclude);
        // Case 2 - skip the i-th house and procceed to the next one
        int case2 = 0 + Dfs_BruteForce(nums, i + 1, seen, exclude);

        return seen[i] = Math.Max(case1, case2);
    }
}
