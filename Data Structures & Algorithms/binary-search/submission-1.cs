public class Solution {
    public int Search(int[] nums, int target) {
        int n = nums.Length;

        int i = 0, j = n-1;

        while (i<=j) {
            int mid = i + (j-i)/2;
            if(nums[mid]==target){
                return mid;
            } else if (target < nums[mid]){
                j=mid-1;
            } else {
                i= mid+1;
            }
        }

        return -1;
    }
}
