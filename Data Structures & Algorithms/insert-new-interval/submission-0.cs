public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        // Example 1: Input: intervals = [[1,3],[4,6]], newInterval = [2,5] Output: [[1,6]]
        // Example 2: Input: intervals = [[1,2],[3,5],[9,10]], newInterval = [6,7] Output: [[1,2],[3,5],[6,7],[9,10]]

        // Implementation Plan:
        // LeetCode pattern: Intervals
        // Complexity: O(n) time, O(n) extra space for result and O(1) - with excluding result by convention
        // where n - length of existing intervals to merge into

        List<int[]> result = [];

        // The interval being built. Use locals, so you never mutate the caller's newInterval.
        int start = newInterval[0];
        int end = newInterval[1];
        bool placed = false;

        foreach (int[] interval in intervals)
        {
            if (end < interval[0] /* ? interval is entirely BEFORE the built interval */)
            {
                if (!placed)
                {
                    result.Add([start, end]);
                    placed = true;
                }
                result.Add(interval);
            }
            else if (start > interval[1] /* ? interval is entirely AFTER the built interval */)
            {
                // ? placed already? If not, add the built interval first, once. Then add interval.
                result.Add(interval);
            }
            else
            {
                // ? overlap: grow start and end. Add nothing yet.
                start = Math.Min(start, interval[0]);
                end = Math.Max(end, interval[1]);
            }
        }

        // ? still pending?
        if (!placed)
        {
            result.Add([start, end]);
        }

        return [.. result];
    }
}
