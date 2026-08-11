public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {

        int i = m-1;
        int k = n-1;
        int tail = m+n-1;

        while(tail>=0){
            Console.WriteLine ($"i={i} k={k} tail={tail}");
            int n1 = i < 0 ? int.MinValue: nums1[i]; 
            int n2 = k < 0 ? int.MinValue: nums2[k];

            if(n1>=n2) {
                nums1[tail]=n1;
                i--;
            } else {
                nums1[tail]=n2;
                k--;
            }
             tail--;
        }       

    }
}