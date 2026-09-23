public class Solution {
    // KNOTE: AI full refactoring of my v01 code
    public int[][] Merge(int[][] intervals)
    {
        // Example 1: Input: intervals = [[1,3],[1,5],[6,7]] Output: [[1,5],[6,7]]
        // Example 2: Input: intervals = [[1,2],[2,3]] Output: [[1,3]]

        // Implementation Plan:
        // LeetCode pattern: Intervals
        // Complexity: O(n*log(n)) time, O(n) extra space

        if (intervals.Length == 0)
        {
            return [];
            //return new int[0][]; // empty array
        }

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        List<int[]> merged = [intervals[0]];

        for (int i = 1; i < intervals.Length; i++)
        {
            int[] last = merged[^1];
            int[] next = intervals[i];

            if (last[1] >= next[0])
                last[1] = Math.Max(last[1], next[1]);   // overlap: extend the last merged interval
            else
                merged.Add(next);                       // gap: start a new one
        }

        //resultList.Add(prev);

        // return [.. resultList];
        return merged.ToArray();
    }
}
