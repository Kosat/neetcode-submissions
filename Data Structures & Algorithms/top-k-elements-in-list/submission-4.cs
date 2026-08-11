// I made a mistake by introducing an aux class and placing it as values into both Dic and Queue and then updating Freqency in that class. But it did not work b/c PriorityQueue does not dynaimcally updates itsef.
// KIMPORTANT: This problem can also be solved with using extra List<int>[] instead of PriorityQueue
//             Create a list of groups freq, where freq[i] will store all numbers that appear exactly i times.
public class Solution {
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
