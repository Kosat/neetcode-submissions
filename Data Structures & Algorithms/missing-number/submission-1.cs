public class Solution {
    public int MissingNumber(int[] nums) {

        long sum1 = 0;
        long sum2 = 0;

        for(int i = 0; i < nums.Length; i++) {
            sum1 += i;
            sum2 += nums[i];
        }

        sum1 += nums.Length;

        return (int)(sum1 - sum2);
    }
}
