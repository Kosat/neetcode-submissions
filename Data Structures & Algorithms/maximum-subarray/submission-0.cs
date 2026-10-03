public class Solution {
    public int MaxSubArray(int[] nums)
    {
        // Example 1: Input: nums = [2,-3,4,-2,2,1,-1,4] Output: 8
        // Example 2: Input: nums = [-1] Output: -1

        // LeetCode pattern: Greedy / Kadane's algo
        // Complexity: O(n) time, O(1) extra space
        // Underlying collection: None


        int globalMaxSum = int.MinValue;
        int curMaxSum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            int cur = nums[i];
            // Choose either to extend the current array or start a new one
            // and save the current max sum as global.
            curMaxSum = Math.Max(cur, curMaxSum + cur);
            globalMaxSum = Math.Max(curMaxSum, globalMaxSum);
        }

        return globalMaxSum;
    }
}
