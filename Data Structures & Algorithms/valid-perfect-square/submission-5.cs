// My second implementation on the next day with Binary Search
public class Solution {
    public bool IsPerfectSquare(int num) {
        
        if(num == 0 || num == 1){
            return true;
        }

        long l = 1;
        //long r = num; // unoptimized
        long r = num/2 + 1; // optimized

        while(l <= r) { 

            long m = l + (r - l)/2;
            long mSquare = m*m;

            if(mSquare == num) 
            {
                return true;
            } 
            else if( mSquare < num) 
            {
                l = m + 1L;
            } 
            else {
                r = m - 1L;
            }
        }

        return false;
    }
}