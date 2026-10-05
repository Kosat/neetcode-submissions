public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        // Example 1: Input: piles = [1,4,3,2], h = 9 Output: 2
        // Example 2: Input: piles = [25,10,23,4], h = 4 Output: 25

        // LeetCode pattern: Binary Search
        // Complexity: O(n*log(m)) time where m is pile's MAX value and n is the number of piles, O(1) extra space
        // Underlying collection: None

        int l = 1, r = piles.Max();

        while (l < r) {
            int m = l + (r - l) / 2;

            if (IsCanEat(m)) {
                r = m;
            } else {
                l = m + 1;
            }
        }

        return l;

        bool IsCanEat(int k) {
            int time = 0;
            for (int i = 0; i < piles.Length; i++) {
                time += (piles[i] / k) + ((piles[i] % k) > 0 ? 1 : 0);

                if (time > h)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
