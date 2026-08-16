public class Solution {
    public int Search(int[] nums, int target) {
        
        // Check n = 1 or 2
        int l = 0, r = nums.Length - 1;

        while(l <= r) {
            // 3,4,5,6 ,1,2  t=1
            // 3,5,6, 0,1,2  t=4
            int m = l + (r - l)/2;

            // we found the target
            if(nums[m] == target) {
                return m;
            }

            // The entire array is properly sorted. Apply standard Binary Search. 
            /*if(nums[l] < nums[r]) { 
                // standard Binary Search
                if(nums[m] < target) {
                    l = m + 1;
                } else {
                    r = m - 1;
                }
            } else { //nums[l] > nums[r]*/ 
                // Left is the sorted one 
                if(nums[l] <= nums[m]) // 3,5,   [6], 0,1,2 | t=4
                {
                    if(nums[m] > target && nums[l] <= target)
                    {
                        r = m - 1;
                    } else
                    {
                        // Procceed with the right one (unsorted) assuming that the target might be there
                        l = m + 1;
                    }
                } else // Right is the sorted one  // 3,5,6, [0] ,1,2 | t=4
                {
                    if(nums[m] < target && nums[r] >= target)
                    {
                        l = m + 1;
                    } else
                    {
                        // Procceed with the left one (unsorted) assuming that the target might be there
                        r = m - 1;
                    }
                }
            //}
        }

        return -1;
    }
}