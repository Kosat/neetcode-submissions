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

            if(prev.Count > 0) {
                var prevHeighInStack = prev.Peek();

                if (curBarHeight > prevHeighInStack.Height) {
                    // curBarHeight > prevHeigh
                    // Do not unwind stack. Just add the current bar to the stack.
                } else if (curBarHeight < prevHeighInStack.Height) {
                    // curBarHeight < prevHeigh
                    // Unwind the stack until we find a bar that is lower than the current bar.
                    while (prev.Count > 0 && prev.Peek().Height > curBarHeight) {
                        var popped = prev.Pop();
                        minIdxPopped = popped.LeftmostIndexThisHeightCanReach;
                        int area = popped.Height * (i - popped.LeftmostIndexThisHeightCanReach);
                        maxArea = Math.Max(maxArea, area);
                    }
                }  else {
                    // curBarHeight == prevHeigh
                    // Do not add it to the stack because it is the same height as the previous bar. Just continue to the next bar.
                    continue;
                }
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