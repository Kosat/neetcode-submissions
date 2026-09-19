public class Solution {
    public int[] PlusOne(int[] digits) {
        // Example 1: Input: digits = [1,2,3,4] Output: [1,2,3,5]
        // Example 2: Input: digits = [9,9,9] Output: [1,0,0,0]

        // Implementation Plan:
        // LeetCode pattern: Math
        // O(n) time, O(1) extra space
        // Underlying collection: None

        int n = digits.Length;

        int carry = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            int cur = digits[i];

            if (cur + carry == 10)
            {
                digits[i] = 0;
                carry = 1;
            }
            else
            {
                digits[i] = cur + carry;
                carry = 0;
            }
        }

        if (carry == 0)
        {
            return digits;
        }
        else
        {
            int[] result = new int[n + 1];
            result[0] = 1;
            return result;
        }  
    }
}
