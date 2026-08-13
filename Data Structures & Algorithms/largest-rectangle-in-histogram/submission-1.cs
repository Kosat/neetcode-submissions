public class Solution {
    private record AreaRec
    {
        public int LeftmostIndexThisHeightCanReach; 
        public int Height;
    }
    
    public int LargestRectangleArea(int[] heights) {
        if (heights.Length == 1) {
            return heights[0];
        }

        Stack<AreaRec> prev = [];
        int maxArea = 0;

        for (int i = 0; i < heights.Length; i++) {
            int curBarHeight = heights[i];
            int minIdxPopped = -1;

            if (prev.Count > 0 && curBarHeight < prev.Peek().Height) {
                // curBarHeight < prevHeigh
                // Unwind the stack until we find a bar that is lower than the current bar.
                while (prev.Count > 0 && prev.Peek().Height > curBarHeight) {
                    var popped = prev.Pop();
                    minIdxPopped = popped.LeftmostIndexThisHeightCanReach;
                    int area = popped.Height * (i - popped.LeftmostIndexThisHeightCanReach);
                    maxArea = Math.Max(maxArea, area);
                }
            }  

            // If the current bar is the same height as the previous bar, we skip it to avoid duplicates.
            if(prev.Count > 0 && curBarHeight == prev.Peek().Height) {
                continue;
            }

            if (curBarHeight != 0) {
                // separate case to catch the case when on single bar area is the answer
                //maxArea = Math.Max(maxArea, curBarHeight);
                prev.Push(new AreaRec {
                    LeftmostIndexThisHeightCanReach = minIdxPopped == -1 ? i : minIdxPopped, 
                    Height = curBarHeight 
                });
            }
        }

        // Unwind the stack to calculate the area for the remaining bars in the stack.
        while (prev.Count > 0) {
            var popped = prev.Pop();
            int area = popped.Height * (heights.Length - popped.LeftmostIndexThisHeightCanReach);
            maxArea = Math.Max(maxArea, area);
        }

        return maxArea;
    }
}
