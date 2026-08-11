public class Solution {
    public bool hasDuplicate(int[] nums) {
        var s = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++) {
            if (!s.Add(nums[i])) {
                return true;
            }
        }
        return false;
    }
}