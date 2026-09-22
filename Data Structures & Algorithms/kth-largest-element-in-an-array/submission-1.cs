public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int, int> minHeap = new();

        foreach (var n in nums)
        {
            minHeap.Enqueue(n, n);
            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }

        if (minHeap.Count > 0)
        {
            return minHeap.Dequeue();
        }

        return -1;
    }
}
