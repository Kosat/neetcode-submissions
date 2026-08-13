// My Solution that was fixed by Opus and works. But structurally wrong for using one while loop. - need to go with nested loops.
public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        // keep in mind the [0,0,0] case

        List<List<int>> results = [];

        Array.Sort(nums);

        int l = 0, m = l + 1, r = nums.Length - 1;
        while (m < r) {
            int sum = nums[l] + nums[m] + nums[r];

            if (sum == 0) {
                // found the result
                results.Add([nums[l], nums[m], nums[r]]);

                // both ends have to move: holding either one fixed can only
                // overshoot or undershoot zero from here
                m++;
                r--;

                // nums[m] alone identifies the triplet (nums[r] is forced by it),
                // so stepping over repeats of nums[m] is what kills duplicates
                while (m < r && nums[m] == nums[m - 1]) m++;
            } else if (sum > 0) {
                // with the current value of r, moving m closer to r only makes
                // the sum bigger, so shrink the span from the right instead
                r--;
            } else {  // sum < 0
                // mirror case: only a larger left value can close the gap
                m++;
            }

            if (m >= r) {
                // the m..r span is exhausted for this l, continue to the next l
                l++;

                // a value may anchor a triplet only the first time it appears;
                // comparing backwards still allows l, m, r to be three equal values
                while (l < nums.Length && nums[l] == nums[l - 1]) l++;

                // r goes back to the far end: everything it walked past is
                // available again now that l holds a larger value
                m = l + 1;
                r = nums.Length - 1;
            }
        }

        return results;
    }
}
