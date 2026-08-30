public class Solution {
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        
        Array.Sort(candidates);
        List<List<int>> result = [];
        CombinationSum2Helper(candidates, target, 0, [], 0, result);
        return result;
    }

    private static void CombinationSum2Helper(int[] candidates, int target, int i, List<int> combo, int comboSum, List<List<int>> result)
    {
        // Base case: a valid combination is found
        if (comboSum == target)
        {
            result.Add([.. combo]);
            return;
        }

        // Prune: out of bounds, or the sum already exceeds the target
        if (i >= candidates.Length || comboSum > target)
        {
            return;
        }

        // Choice 1 - include candidates[i]
        combo.Add(candidates[i]);
        comboSum += candidates[i];
        CombinationSum2Helper(candidates, target, i + 1, combo, comboSum, result);
        combo.RemoveAt(combo.Count - 1);
        comboSum -= candidates[i];

        // Choice 2 - exclude candidates[i].
        // Skip all consecutive duplicates so the same combination is never generated twice.
        // (A single combination may still repeat a value, e.g. [2,2,4], because the input
        // contains two 2s — but no two combinations may be identical.)
        while (i + 1 < candidates.Length && candidates[i] == candidates[i + 1])
        {
            i++;
        }

        CombinationSum2Helper(candidates, target, i + 1, combo, comboSum, result);
    }
}
