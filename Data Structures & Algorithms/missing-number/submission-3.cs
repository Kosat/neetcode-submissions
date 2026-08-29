public class Solution {
    public int MissingNumber(int[] nums) {
        int res = 0; // nums.Length;
        
        for(int i = 0; i < nums.Length; i++) {
            res ^= i;
            res ^= nums[i];
        }

        res ^= nums.Length;

        return res;
    }
}
