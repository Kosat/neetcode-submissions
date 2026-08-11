public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int/*complement */,int/*idx*/> seen = [];

        for(int i=0; i<nums.Length; i++){
            int n = nums[i];
            int complement  = target-n;
            if(seen.TryGetValue(n, out int complementIdx)){
                return [complementIdx, i];
            } else {
                seen[complement] = i;
            }
        }

        return [];
    }
}
