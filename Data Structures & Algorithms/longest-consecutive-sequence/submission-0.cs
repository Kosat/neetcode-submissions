public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        // Example 1: Input: nums = [2,20,4,10,3,4,5] Output: 4
        // Example 2: Input: nums = [0,3,2,5,4,6,1,1] Output: 7

        // Implementation Plan:
        // - Use HashSet to iterate over consecutive sequences
        // - Use prev==0 predicate to detect the begiining of the sequences
        // - Iterrate second pass over the HashSet rather than the nums array to avoid checking duplicates
        // LeetCode pattern: Arrays & Hashes
        // O(n) time, O(n) extra space for the HashSet
        // NOTE: The while loop looks quadratic because it sits inside the foreach.
        // It isn't, because only a run's start walks, so each value is stepped over by exactly one walk.
        // The total work is a constant number of lookups per value.
        // Underlying collection: HashSet<int>

        // Pass 1 - fill-in the HashSet
        HashSet<int> numsPresent = [.. nums];

        // Pass 2 - find the beginnings of the sequences and iterate over them to
        // counting the length of the sequence using numsPresent
        int maxSeqLength = 0;
        foreach (var num in numsPresent)
        {
            // is the beginngin of a sequence?
            if (!numsPresent.Contains(num - 1))
            {
                int curSequence = num;
                int curSequenceLen = 0;
                
                while (numsPresent.Contains(curSequence))
                {
                    curSequence += 1;
                    curSequenceLen++;
                }

                maxSeqLength = Math.Max(curSequenceLen, maxSeqLength);
            }
        }

        return maxSeqLength;
    }
}
