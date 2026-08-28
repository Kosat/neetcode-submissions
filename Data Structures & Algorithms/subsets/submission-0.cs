public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> result = [];
        SubsetsBacktrack(nums, 0, [], result);
        return result;
    }

    private void SubsetsBacktrack(int[] nums, int i, List<int> curSubset, List<List<int>> result) {
        // Recursion base case
        if (i == nums.Length) {
            // At this point during the previous recursion step we have ALREADY processed the bottom leafs of the decision tree
            // Time to make the snapshot of the leaf's curSubset and record it into `result` list.
            // Clone array to prevent backtracking changes. B/c backtracking reuses curSubset between choice #1 and #2.
            result.Add(new List<int>(curSubset)); // Alternatively result.Add([.. curSubset]);
            return;
        }

        // The case of including nums[i]
        curSubset.Add(nums[i]);
        SubsetsBacktrack(nums, i + 1, curSubset, result);
        curSubset.RemoveAt(curSubset.Count - 1); // KNOTE: Pay attention that the element to remove is the rightmost in the subset list

        // The case of NOT including nums[i]
        SubsetsBacktrack(nums, i + 1, curSubset, result);
    }
}
