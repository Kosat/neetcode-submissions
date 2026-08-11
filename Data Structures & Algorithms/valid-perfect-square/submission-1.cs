// My first NAIVE wrong solution.
public class Solution {
    public bool IsPerfectSquare(int num) {
        if(num == 0 || num == 1) {
            return true;
        }

        int upperBound = num/2 + 1; // optimization
        for (int i = 2; i <= upperBound; i++){
            if(i*i == num){
                return true;
            }
        }
     
        return false;
    }
}