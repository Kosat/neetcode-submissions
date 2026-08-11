public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int i = 0, k = numbers.Length - 1;

        while(i < k) {
            int sum = numbers[i] + numbers[k];

            if(sum == target) {
                return [i + 1, k + 1];
            } else if(sum > target) {
                k--;
            } else {
                i++;
            }
        }

        return [];
    }
}
