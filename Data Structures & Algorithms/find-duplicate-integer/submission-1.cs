public class Solution {

    public int FindDuplicate(int[] nums) {
        int slow = 0, fast = 0;
        slow = nums[slow];
        fast = nums[nums[fast]];

        while(slow != fast)
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        }

        // Phase 2: Find the cycle entrance (the duplicate).
        // Reset slow to the head of the list (index 0).
        // Moving both one step at a time, they meet again at the cycle entrance.
        slow = 0;

        while(slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }

    // Naive O(n) extra space solution
    public int FindDuplicate_naive(int[] nums) {
        int n = nums.Length;
        int[] arr = new int[n]; // O(n) space solution

        foreach(int num in nums) 
        {
            if(arr[num] == 1)
            {
                return num;
            }
            else
            {
                arr[num] = 1;
            }
        }

        return -1;
    }
}
