public class Solution {
    public int MySqrt(int x) {
        if (x == 0 || x == 1){
            return x;
        }        

        int l = 1;
        int r = x;
        int res = 0;

        while(l <= r) {
            
            int m = l + (r - l)/2;
            long square = (long)m*m;
            
            if(square == x) {
                return m;
            } else if(square < x) {
                l = m + 1;
                res = m;
            } else {
                r = m - 1;
            }
        }

        return res;
    }
}