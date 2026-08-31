public class Solution {
    public List<List<int>> Permute(int[] nums) {
        
        List<List<int>> result = [];
        bool[] used = new bool[nums.Length];
        Backtracking(nums, [], used, result);
        return result;
    }

    private void Backtracking(int[] nums, List<int> current, bool[] used, List<List<int>> result)
    {
        // Backtracking recursion base case
        if (current.Count == nums.Length)
        {
            result.Add([.. current]);
            return;
        }

        for (int k = 0; k < nums.Length; k++)
        {
            if (used[k]) continue;

            current.Add(nums[k]);
            used[k] = true;

            Backtracking(nums, current, used, result);

            current.RemoveAt(current.Count - 1);
            used[k] = false;
        }

    }
}
