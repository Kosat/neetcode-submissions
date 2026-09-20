public class Solution
{

    // KNOTE: Alot of AI help need to do it again.
    public string Multiply(string num1, string num2)
    {
        // Example 1: Input: num1 = "3", num2 = "4" Output: "12"
        // Example 2: Input: num1 = "111", num2 = "222" Output: "24642"

        // Implementation Plan:
        // LeetCode pattern: Math
        // Complexity: O(m*n) time, O(m + n) extra space for `int[] result`
        // Underlying collection: int[num1.Length + num2.Length]

        int[] result = new int[num1.Length + num2.Length];

        for (int i = num1.Length - 1; i >= 0; i--)
        {
            int resultIdx = num1.Length - 1 - i;   // row offset: ones digit of num1 -> position 0
            int carry = 0;
            int n1 = num1[i] - '0';

            for (int k = num2.Length - 1; k >= 0; k--)
            {
                int n2 = num2[k] - '0';

                int sum = result[resultIdx] + n1 * n2 + carry;
                result[resultIdx] = sum % 10;
                carry = sum / 10;
                resultIdx++;
            }

            // Flush the carry - AI written
            while (carry > 0)
            {
                int total = result[resultIdx] + carry;
                result[resultIdx] = total % 10;
                carry = total / 10;
                resultIdx++;
            }
        }


        Array.Reverse(result);

        // Convert List<int> to String
        char[] chars = new char[result.Length];
        for (int i = 0; i < result.Length; i++) chars[i] = (char)('0' + result[i]);
        string resultStr = new string(chars).TrimStart('0');

        return resultStr == "" ? "0" : resultStr;
    }
}