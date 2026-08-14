// https://neetcode.io/problems/trapping-rain-water/question

public class Solution {
    public int Trap(int[] height) {
        
        int n = height.Length;
        int maxArea = 0;

        
        if(n < 3) { 
            return maxArea;
        }
        

        int l = 0, r = 1;

        // Fast-forward to the right skipping the completely empty tiles
        while (height[l] == 0 && r < n) {
            l++;
            r++;
        }

        // Left to right pass
        int curArea = 0;
        while (r < n) {
            int lh = height[l];
            int rh = height[r];

            if (lh <= rh) {
                // Finish curArea calculation
                maxArea += curArea;
                curArea = 0;
                l = r;
                r++;
            } else { // lh > rh 
                // Accumulate curArea
                curArea += lh - rh;
                r++;
            }
        }

       // Right to left pass 
        curArea = 0;
        l = n-2; r = n-1;
        while (l >= 0) {
            int lh = height[l];
            int rh = height[r];

            if (rh < lh) {
                // Finish curArea calculation
                maxArea += curArea;
                curArea = 0;
                r = l;
                l--;
            } else { // rh > lh 
                // Accumulate curArea
                curArea += rh - lh;
                l--;
            }
        }


        return maxArea;
    }
}