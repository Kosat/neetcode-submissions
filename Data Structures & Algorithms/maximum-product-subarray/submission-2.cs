public class Solution {
    public int MaxProduct(int[] nums) {
        
        return Kaidane(nums);
    }

    private int Kaidane(int[] nums)
    {
        int n = nums.Length;

        int maxGlobal = int.MinValue;

        int minCur = 1;
        int maxCur = 1;

        for (int i = 0; i < n; i++)
        {
            int cur = nums[i];

            if (cur == 0)
            {
                minCur = 1;
                maxCur = 1;
                maxGlobal = Math.Max(0, maxGlobal);
                continue;
            }

            int minCurTmp = minCur;
            minCur = Math.Min(cur, Math.Min(maxCur * cur, minCur * cur));
            maxCur = Math.Max(cur, Math.Max(maxCur * cur, minCurTmp * cur));

            maxGlobal = Math.Max(maxCur, maxGlobal);
        }

        return maxGlobal;
    }
}
