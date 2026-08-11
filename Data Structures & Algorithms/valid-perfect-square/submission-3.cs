// My second implementation on the next day with Binary Search
public class Solution {
    public bool IsPerfectSquare(int num) {
        
        if(num == 0 || num == 1){
            return true;
        }

        long l = 1;
        long r = num;

        while(l <= r) { 

            long m = l + (r - l)/2;

            if(m*m == num) {
                return true;
            } else if( m*m < num) {
                l = m + 1L;
            } else {
                r = m - 1L;
            }
        }

        return false;
    }
}