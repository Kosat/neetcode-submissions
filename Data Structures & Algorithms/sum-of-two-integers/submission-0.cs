public class Solution {
    public int GetSum(int a, int b) {
        
        int sum = 0;
        int i = 0;
        int carry = 0;
        while (i < 32)
        {
            int curA = a & 1;
            int curB = b & 1;

            sum |= (curA ^ curB ^ carry) << i;

            if ((curA ^ curB ^ carry) == 0 && !(curA == 0 && curB == 0 && carry == 0) || (curA == 1 && curB == 1 && carry == 1))
            {
                carry = 1;
            }
            else
            {
                carry = 0;
            }

            a >>= 1;
            b >>= 1;
            i++;
        }

        return sum;
    }
}
