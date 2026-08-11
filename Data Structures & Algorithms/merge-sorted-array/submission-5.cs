// My second attempt without using int.MinValue guard that I used in the first attempt.
public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        
        int i = m - 1; // nums1
        int k = n - 1; // nums2
        int j = m + n - 1; // empty space in nums1
        while (i >= 0 && k >= 0) {
            if(nums1[i] >= nums2[k]) {
                nums1[j] = nums1[i];
                i--;
            } else {
                nums1[j] = nums2[k];
                k--;
            }
            j--;
        }

        // remaining nums1 
        while (i >= 0) {
            nums1[j] = nums1[i];
            i--;
            j--;
        }

        // remaining nums2
        while (k >= 0) {
            nums1[j] = nums2[k];
            k--;
            j--;
        }
    }
}