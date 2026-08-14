public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;

        if(n == 1) {
            return nums;
        }

        //Console.WriteLine(string.Join(',', nums));

        int[] output = new int[n];

        int[] ltr = new int[n];
        int[] rtl = new int[n];

        // Fill left to right array
        ltr[0] = 1;

        for(int i = 1; i < n; i++) {
            ltr[i] = nums[i - 1] * ltr[i - 1];
        }

        //Console.WriteLine(string.Join(',', ltr));

        // Fill right to left array
        rtl[n-1] = 1;

        for(int i = n-2; i >= 0; i--) {
            rtl[i] = nums[i + 1] * rtl[i + 1];
        }

        //Console.WriteLine(string.Join(',', rtl));

        // multiply each elemen from ltr by corresponding element in rtl
        // and write te result into output array
        for(int i = 0; i < n; i++) {
            output[i] = ltr[i] * rtl[i];
        }

        return output;
    }
}
