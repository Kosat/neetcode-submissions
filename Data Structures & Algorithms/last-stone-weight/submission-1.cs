public class Solution
{
    public int LastStoneWeight(int[] stones)
    {
        // Example 1: Input: stones = [2,3,6,2,4] Output: 1
        // Example 2: Input: stones = [1,2] Output: 1

        // Implementation Plan:
        // LeetCode pattern: Heap / Priority Queue
        // Complexity: O(n*log n) time, O(n) extra space
        // Underlying collection: PriorityQueue<int, int>

        PriorityQueue<int, int> maxHeap = new(Comparer<int>.Create((x, y) => y.CompareTo(x)));

        foreach (var s in stones)
        {
            maxHeap.Enqueue(s, s);
        }

        while (maxHeap.Count > 1)
        {
            var heaviest = maxHeap.Dequeue();
            var secondHeaviest = maxHeap.Dequeue();

            if (heaviest != secondHeaviest)
            {
                int stonesDiff = heaviest - secondHeaviest;
                maxHeap.Enqueue(stonesDiff, stonesDiff);
            }
        }

        if (maxHeap.Count == 1)
        {
            return maxHeap.Dequeue();
        }

        return 0;
    }
}
