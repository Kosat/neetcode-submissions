public class Solution
{
    PriorityQueue<int, int> _maxHeap = new(Comparer<int>.Create((x, y) => y.CompareTo(x)));

    public int LastStoneWeight(int[] stones)
    {
        // Example 1: Input: stones = [2,3,6,2,4] Output: 1
        // Example 2: Input: stones = [1,2] Output: 1

        // Implementation Plan:
        // LeetCode pattern: Heap / Priority Queue
        // Complexity: O(n*log n) time, O(n) extra space
        // Underlying collection: PriorityQueue<int, int>

        foreach (var s in stones)
        {
            _maxHeap.Enqueue(s, s);
        }

        while (_maxHeap.Count > 1)
        {
            var stone1 = _maxHeap.Dequeue();
            var stone2 = _maxHeap.Dequeue();

            if (stone1 == stone2)
            {
                // Do nothing
            }
            else
            {
                int stonesDiff = stone1 - stone2;
                _maxHeap.Enqueue(stonesDiff, stonesDiff);
            }
        }

        if (_maxHeap.Count == 1)
        {
            return _maxHeap.Dequeue();
        }

        return 0;
    }
}