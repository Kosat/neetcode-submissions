public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        // Example 1: Input: nums = [1,2,1,0,4,2,6], k = 3 Output: [2,2,4,4,6]

        // Input: nums = [1,2,1,0,4,2,6], k = 3
        // Output: [2,2,4,4,6]
        // Explanation:
        // Window position            Max
        // ---------------           -----
        // [1  2  1] 0  4  2  6        2
        //  1 [2  1  0] 4  2  6        2
        //  1  2 [1  0  4] 2  6        4
        //  1  2  1 [0  4  2] 6        4
        //  1  2  1  0 [4  2  6]       6
        
        List<int> res = [];

        LinkedList<int> deque = new(); // stores indexes from nums array in monotonically strictly decreasing order. Leftmost is the MAX value. I.e. 10,9,5,..,1
        // Window position            Max   Deque (idx)   Deque (vals)
        // ---------------           -----  -----------   ------------
        // [1  2  1] 0  4  2  6        2     [1,2]         [2,1]
        //  1 [2  1  0] 4  2  6        2     [1,2,3]       [2,1,0]
        //  1  2 [1  0  4] 2  6        4     [4]           [4]
        //  1  2  1 [0  4  2] 6        4     [4,5]         [4,2]
        //  1  2  1  0 [4  2  6]       6     [6]           [6]
        int l = 0, r = 0;

        while (r < nums.Length)
        {
            // Before pushing r, pop from the back any index whose value is <= nums[r].
            // Those elements are to the left of r and smaller-or-equal, so for every
            // future window that contains r they can never be the max — dead weight.
            while (deque.Count > 0 && nums[deque.Last.Value] <= nums[r])
            {
                deque.RemoveLast();
            }
            deque.AddLast(r);

            if( (r - l + 1) == k)
            {
                // Drop any front index that has fallen out of the window (before reading the max)
                while (deque.Count > 0 && deque.First.Value < l)
                {
                    deque.RemoveFirst();
                }

                // The front is now the max of the current window
                res.Add(nums[deque.First.Value]);

                // Slide the window +1 to right
                l++;
            }

            r++;
        }
        
        return [.. res];
    }
}
