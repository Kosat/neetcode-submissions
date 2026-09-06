public class Solution {
    public uint ReverseBits(uint n) {
        uint result = 0;

        int idx = 31;
        while(n > 0)
        {
            if((n & 1) == 1)
            {
                result |= (1u << idx);
            }

            n >>= 1;
            idx--;
        }

        return result;
    }
}
