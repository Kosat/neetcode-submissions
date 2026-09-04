public class Solution {
    public int[] CountBits(int n) {
        

        List<int> bitsCount = [];
        for (int i = 0; i <= n; i++)
        {
            bitsCount.Add(CountBitsForOneNumber(i));
        }

        return bitsCount.ToArray();
    }

    private int CountBitsForOneNumber(int n)
    {
        int bitsCount = 0;
        int mask = 1;

        for(int i = 0; i < 32; i++)
        {
            if((n & mask) == mask)
            {
                bitsCount++;
            }
            mask <<= 1;
        }

        return bitsCount;
    }
}
