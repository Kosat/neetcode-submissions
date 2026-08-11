public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {

        int i = m - 1;
        int k = n - 1;
        int tail = m + n - 1;

        while(k >= 0){
            Console.WriteLine ($"i={i} k={k} tail={tail}");
            //int n1 = nums1[i]; 
            //int n2 = nums2[k];

            if(i >= 0 && nums1[i] > nums2[k]) {
                nums1[tail]=nums1[i];
                i--;
            } else {
                nums1[tail]=nums2[k];
                k--;
            }
             tail--;
        }       

    }
}