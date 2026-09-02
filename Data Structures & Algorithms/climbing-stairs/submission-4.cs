public class Solution {
    public int ClimbStairs(int n) {     
        
        return ClimbStairsHelper(n, 0, []);

    }

    // Sub-optimal recursive approach
    private int ClimbStairsHelper(int n, int stepsSoFar, Dictionary<int, int> cache)
    {
        if (stepsSoFar == n)
        {
            return 1;
        }

        if (stepsSoFar > n)
        {
            return 0;
        }

        if (cache.TryGetValue(stepsSoFar, out int resultCached))
        {
            return resultCached;
        }
        else
        {
            int resultComputed =
                ClimbStairsHelper(n, stepsSoFar + 1, cache)
                + ClimbStairsHelper(n, stepsSoFar + 2, cache);

            cache[stepsSoFar] = resultComputed;
            
            return resultComputed;
        }
    }
}
