public class Solution {
    public bool IsHappy(int n) {
        var GetSumOfDigitSquares = (int n) =>
        {
            int sum = 0;
            while (n > 0)
            {
                int digit = n % 10;
                n /= 10;
                sum += digit * digit;
            }
            return sum;
        };

        HashSet<int> cache = [];

        while (true) 
        {
            int sum = GetSumOfDigitSquares(n);
            if (sum == 1)
            {
                return true;
            }

            // Cycle detection
            // Repeat the above step until the number equals 1, or it loops infinitely in a cycle which does not include 1.
            if(cache.Contains(sum))
            {
                return false;
            }

            n = sum;
            cache.Add(n);
        }

        return false;
    }
}
