public class Solution {

    public int[] TwoSum(int[] nums, int target) {
        var arr = new Dictionary<int,int>();
        for(int i=0; i<nums.Length; i++){
            
            var delta = target-nums[i];
            
            if(arr.TryGetValue(nums[i], out int deltaIdx)){
                return new int[] {deltaIdx, i};
            } else {
                arr[delta]=i;
            }
        }
        return null;
    }
}
