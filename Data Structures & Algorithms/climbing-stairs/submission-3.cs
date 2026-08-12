public class Solution {
    public int ClimbStairs(int n) {
        // int variants = 0;

        //variants += Climb_v1(n, 1);
        //variants += Climb_v1(n, 2);

        // Add memoization
        int[] cache = new int[46];

        return Climb_v2(n, cache);
    }

    private int Climb_v2(int n, int[] cache) {

        if(n>0 && cache[n]!=0) {
            return cache[n];
        }

        if (n == 0) {
            return 1;
        }

        if (n < 0) {
            return 0;
        }

        int result = Climb_v2(n - 1, cache) + Climb_v2(n - 2, cache);
        
        cache[n] = result;

        return result;
    }

    private int Climb_v1(int n, int step) {
        int remainder = n - step;

        if (remainder == 0) {
            return 1;
        }

        if (remainder < 0) {
            return 0;
        }

        return Climb_v1(remainder, 1) + Climb_v1(remainder, 2);
    }
}
