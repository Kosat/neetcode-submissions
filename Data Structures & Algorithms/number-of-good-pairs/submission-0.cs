public class Solution {

    record GoodPair (int Count, int Pairs);

    public int NumIdenticalPairs(int[] nums) {
        Dictionary<int, GoodPair> dic = [];

        for (int i = 0; i < nums.Length; i++) {
            int n = nums[i];
            if (dic.ContainsKey(n)) {
                if (dic[n].Count == 1) {
                    // now we have one pair
                   dic[n] = new GoodPair(dic[n].Count + 1, 1);
                } else {
                    var curGoodPair = dic[n];
                    dic[n] = new GoodPair(curGoodPair.Count + 1, curGoodPair.Pairs + curGoodPair.Count); 
                }
            } else {
                dic[n] = new GoodPair(1, 0);  // first number alone has 0 pairs
            }
        }

       

        return dic.Values.ToList().Sum(x=>x.Pairs);
    }
}