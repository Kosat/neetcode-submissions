public class Solution {
    public int MaxArea(int[] heights) {
        int maxArea = 0;

        int l = 0, r = heights.Length - 1;

        while(l < r) {
            int lh = heights[l];
            int rh = heights[r];
            int area = (r - l) * Math.Min(lh, rh);

            if(lh < rh) {
                l++;
            } else if(lh > rh) {
                r--;
            } else if(lh == rh)
            {
                // OPTIMIZATION. Algorithm works correctly without it
                l++;
                r--;
            }


            maxArea = Math.Max(area, maxArea);
        }

        return maxArea;
    }
}
