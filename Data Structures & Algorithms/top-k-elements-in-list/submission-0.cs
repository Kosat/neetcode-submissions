public class Solution {
    private class FrequentElement {
        public int Value;
        public int Frequency;
    }
    
    public int[] TopKFrequent(int[] nums, int k) {
        var counts = new Dictionary<int, int>();

        foreach (int n in nums)
        {
            if (counts.ContainsKey(n))
                counts[n]++;
            else
                counts[n] = 1;
        }

        var priorityQueue = new PriorityQueue<int, int>(
            Comparer<int>.Create((a, b) => b.CompareTo(a))
        );
        
        foreach (var entry in counts)
        {
            // Higher frequency should have higher priority.
            priorityQueue.Enqueue(entry.Key, entry.Value);
        }

        var result = new int[k];

        for (int i = 0; i < k; i++)
        {
            result[i] = priorityQueue.Dequeue();
        }

        return result.ToArray();
    }
}
