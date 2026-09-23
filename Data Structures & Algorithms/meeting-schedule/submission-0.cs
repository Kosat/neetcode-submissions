/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public bool CanAttendMeetings(List<Interval> intervals) {
        if (intervals.Count == 0)
        {
            return true;
        }

        // Sort intervals by their start date in ASC order
        intervals.Sort((x, y) => x.start.CompareTo(y.start));

        for (int i = 1; i < intervals.Count; i++)
        {
            var prev = intervals[i - 1];
            var cur = intervals[i];

            if (!(prev.end <= cur.start))
            {
                // Overlap detected between intervals - return immediately
                return false;
            }
        }

        // Checked all the intervals - no overlaps found
        return true;
    }
}
