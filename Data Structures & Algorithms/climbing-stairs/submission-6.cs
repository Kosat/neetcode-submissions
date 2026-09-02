public class Solution {
    public int ClimbStairs(int n) {     
        
        //return ClimbStairsHelper(n, 0, []);
        return ClimbStairsHelper(n);
    }

    // DP bottom-up approach
    private int ClimbStairsHelper(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        if (n == 2) return 2;

        int dp_prev_prev = 1;
        int dp_prev = 2;
        int cur = -1;

        for (int i = 3; i <= n; i++)
        {
            cur = dp_prev_prev + dp_prev;

            (dp_prev_prev, dp_prev) = (dp_prev, cur);
            // int temp = dp_prev;
            // dp_prev = cur;
            // dp_prev_prev = temp;
        }

        return cur;
    }

    // DP bottom-up approach 
    private int ClimbStairsHelper_v02(int n)
    {
        
        int[] cache = new int[(n + 1 < 3) ? 4 : n + 1];
        cache[0] = 0;
        cache[1] = 1;
        cache[2] = 2;

        for (int i = 3; i <= n; i++)
        {
            cache[i] = cache[i - 1] + cache[i - 2];
        }

        return cache[n];
    }

    // Recursive approach with memoization
    private int ClimbStairsHelper_v01(int n, int stepsSoFar, Dictionary<int, int> cache)
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
                ClimbStairsHelper_v01(n, stepsSoFar + 1, cache)
                + ClimbStairsHelper_v01(n, stepsSoFar + 2, cache);

            cache[stepsSoFar] = resultComputed;
            
            return resultComputed;
        }
    }
}
