public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        
        List<List<int>> result = [];
        CombinationSum(nums, target, 0, [], result);
        return result;
    }

    private static void CombinationSum(int[] nums, int target, int i, List<int> comb, List<List<int>> result)
    {
        var combSum = comb.Sum();
        // Base case - save the result
        if (combSum == target)
        {
            result.Add([.. comb]);
            return;
        }

        // Stop the recursion for this branch as there is no possibility of getting 
        // the expected target sum in this recursion branch
        if (combSum > target || i >= nums.Length)
        {
            return;
        }


        // Decision 1 - with i-th number (1 or more)
        int iCount = 1;
        while (iCount * nums[i] <= target)
        {
            for (int k = 0; k < iCount; k++)
            {
                comb.Add(nums[i]);
            }

            CombinationSum(nums, target, i + 1, comb, result);

            for (int k = 0; k < iCount; k++)
            {
                comb.RemoveAt(comb.Count - 1);
            }

            iCount++;
        }

        // Decision 2 - without i-th number
        CombinationSum(nums, target, i + 1, comb, result);
    }
}
