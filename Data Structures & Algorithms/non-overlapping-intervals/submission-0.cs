public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        // Example 1: Input: intervals = [[1,2],[2,4],[1,4]] Output: 1
        // Example 2: Input: intervals = [[1,2],[2,4]] Output: 0


        // LeetCode pattern: Intervals, greedy
        // Implementation Plan:
        /*
         - Sort the intervals by their start values in ascending order.
         - Remember the end of the last kept interval; the first interval is kept.
         - For each next interval: if it starts at or after that end, keep it and remember its end.
         - Otherwise it overlaps: count one removal, and keep whichever ends earlier (remember that end).
         - Return the removal count.
        */
        // Complexity: O(n*log(n)) time, O(1) extra space - corret acceptable ans
        // KNOTE: Going deeper, Space: O(log n), because Array.Sort is introsort and its recursion stack grows with log n.
        // Underlying collection: None

        // Note: Intervals are non-overlapping even if they have a common point.
        // For example, [1, 3] and [2, 4] are overlapping, but [1, 2] and [2, 3] are non-overlapping.

        // Sort intervals by start value ASC in-place
        Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));

        // - Remember the end of the last kept interval; the first interval is kept.
        int prevEnd = int.MinValue;

        int intervalsToRemoveCount = 0;

        foreach (var interval in intervals)
        {
            int start = interval[0];
            int end = interval[1];

            if (start < prevEnd)
            {
                // Overlap detected, mark prev or cur interval for removal (whichever has bigger end value)
                intervalsToRemoveCount++;
                prevEnd = Math.Min(end, prevEnd);
            }
            else
            {
                prevEnd = end;
            }
        }

        return intervalsToRemoveCount;
    }
}
