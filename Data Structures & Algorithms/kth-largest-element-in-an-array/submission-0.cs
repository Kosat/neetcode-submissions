public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int, int> maxHeap = new(Comparer<int>.Create((x, y) => y.CompareTo(x)));

        foreach (var n in nums)
        {
            maxHeap.Enqueue(n, n);
        }

        while (maxHeap.Count > 0 && k >= 0)
        {
            int n = maxHeap.Dequeue();

            k--;

            if (k == 0)
            {
                return n;
            }
        }

        return -1;
    }   
}
