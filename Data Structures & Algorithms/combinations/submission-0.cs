public class Solution {
    public List<List<int>> Combine(int n, int k) {
        

        List<List<int>> result = [];
        CombineHelper(n, k, 1, [], result);
        return result;
    }

    private static void CombineHelper(int n, int k, int num, List<int> curComb, List<List<int>> result)
    {
        // Base case - save the result. Save the copy of array. 
        if (curComb.Count == k)
        {
            result.Add([.. curComb]);
            return;
        }

        if (num > n)
        {
            return;
        }

        // Decision 1 - with num included
        curComb.Add(num);
        CombineHelper(n, k, num + 1, curComb, result);
        curComb.RemoveAt(curComb.Count - 1);

        // Decision 2 - without num included
        CombineHelper(n, k, num + 1, curComb, result);
    }
}