public class Solution {
    public int MySqrt(int x) {
        if (x == 0 || x == 1){
            return x;
        }        

        long l = 1;
        long r = x;

        while(l <= r) {
            
            long m = l + (r - l)/2;
            long square = m*m;
            
            if(square == x) {
                return (int)m;
            } else if(square < x) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }

        return (int)r;
    }
}