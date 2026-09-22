public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        // Example 1: Input: points = [[0,2],[2,2]], k = 1 Output: [[0,2]]
        // Example 2: Input: points = [[0,2],[2,0],[2,2]], k = 2 Output: [[0,2],[2,0]]

        // Implementation Plan:
        // Use C# PriorityQueue as a MIN heap to sort points by their closeness to the origin
        // Add all the points together with their Euclidean distances to the origin into the MIN heap
        // Then Dequeue k top points from the MIN heap and return them as a result

        // LeetCode pattern: Heap / Priority Queue
        // Complexity: O(n * log n) time, O(n) extra space, where n is the number of points
        // Underlying collection: PriorityQueue<>

        PriorityQueue<int[], double> minHeap = new();

        foreach (int[] point in points)
        {
            int x = point[0];
            int y = point[1];
            double dist = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            minHeap.Enqueue(point, dist);
        }

        int[][] result = new int[k][];

        while (k > 0)
        {
            int[] p = minHeap.Dequeue();
            result[k - 1] = p;
            k--;
        }

        return result;
    }
}
