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
    public int MinMeetingRooms(List<Interval> intervals) {
        if (intervals.Count < 2)
        {
            return intervals.Count;
        }

        intervals.Sort((x, y) => x.start.CompareTo(y.start));

        PriorityQueue<Interval, int> pendingMeetingsMinHeap = new();
        int maxOverlappingMeetings = 0;

        pendingMeetingsMinHeap.Enqueue(intervals[0], intervals[0].end);

        for (int i = 1; i < intervals.Count; i++)
        {
            Interval cur = intervals[i];
            int curStart = cur.start;
            int curEnd = cur.end;

            // Note: (0,8),(8,10) is NOT considered a conflict at 8.
            while (pendingMeetingsMinHeap.Count > 0 &&
                (pendingMeetingsMinHeap.Peek().end <= curStart)
            )
            {
                pendingMeetingsMinHeap.Dequeue();
            }

            pendingMeetingsMinHeap.Enqueue(cur, cur.end);

            maxOverlappingMeetings = Math.Max(pendingMeetingsMinHeap.Count, maxOverlappingMeetings);
        }

        return maxOverlappingMeetings;
    }
}
