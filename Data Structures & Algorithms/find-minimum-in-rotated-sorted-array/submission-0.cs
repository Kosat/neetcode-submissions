public class Solution {
    public int FindMin(int[] nums) {
        // 1,  2,3,4  ,5,6  orig
        // 3,  4,5,6],[1,2  right from the m
        // 6],[1,2,3  ,4,5  left  from the m
        // 4,  5,6,1   2,3  equals     the m
        int l = 0, r = nums.Length - 1;
        
        int minCandidate = int.MaxValue;

        while(l <= r) {
            int m = l + (r-l)/2;

            // look for the edge
            // This case is the case with no rotation r=0 times
            if(nums[l] <= nums[m] && nums[m] <= nums[r]) {
                minCandidate = nums[l];
                break;
            } 

            // edge is at the middle or to the left from it, so m must be kept
            if(nums[m] < nums[r]) {
                r = m;
            } else {
                 // edge is to the right from the middle, so m can be dropped
                l = m + 1;
            }
        }

        return minCandidate;
    }
}