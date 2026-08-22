public class Solution {
    public int FindDuplicate(int[] nums) {
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
