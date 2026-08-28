public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        
        List<List<int>> result = [];
        Array.Sort(nums);
        SubsetsWithDupBacktracking(nums, 0, [], result);
        return result;
    }

    private static void SubsetsWithDupBacktracking(int[] nums, int i, IList<int> curSubset, List<List<int>> result)
    {
        // Base case - when reaching the leaf nodes in decision tree
        if (i == nums.Length)
        {
            result.Add([.. curSubset]);
            return;
        }

        // Backtracking choice #1 - including nums[i]
        curSubset.Add(nums[i]);
        SubsetsWithDupBacktracking(nums, i + 1, curSubset, result);
        curSubset.RemoveAt(curSubset.Count - 1);

        // Skip the duplicates in nums
        while (i + 1 < nums.Length && nums[i] == nums[i + 1])
        {
            i++;
        }

        // Backtracking choice #2 - not including nums[i]
        SubsetsWithDupBacktracking(nums, i + 1, curSubset, result);
    }
}
