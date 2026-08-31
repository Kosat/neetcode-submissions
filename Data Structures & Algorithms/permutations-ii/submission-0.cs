public class Solution {
    public List<List<int>> PermuteUnique(int[] nums) {
        Array.Sort(nums);
        List<List<int>> result = [];
        bool[] used = new bool[nums.Length];
        Backtracking(nums, [], used, result);
        return result;
    }

    private void Backtracking(int[] nums, List<int> current, bool[] used, List<List<int>> result) {
        // Backtracking recursion base case
        if (current.Count == nums.Length) {
            result.Add([..current]);
            return;
        }

        for (int k = 0; k < nums.Length; k++) {
            // Skip duplicates. Make sure you use at least one duplicate
            // In this logic you always use the last of the duplicates
            // if (k > 0 && nums[k] == nums[k - 1] && !used[k - 1]) continue;

            if (used[k]) continue;

            current.Add(nums[k]);
            used[k] = true;

            Backtracking(nums, current, used, result);

            current.RemoveAt(current.Count - 1);
            used[k] = false;

            // Skip the remaining duplicates for this branch level.
            // They were however used in the nested backtracking calls above.
            while (k + 1 < nums.Length && nums[k] == nums[k + 1]) k++;
        }
    }
}