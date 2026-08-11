public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var dic = new Dictionary<int/*complement */,int/*idx*/>();

        for(int i=0; i<nums.Length; i++){
            int n = nums[i];
            int complement  = target-n;
            if(dic.TryGetValue(n, out int complementIdx)){
                return [complementIdx, i];
            } else {
                dic[complement] = i;
            }
        }

        return [];
    }
}
