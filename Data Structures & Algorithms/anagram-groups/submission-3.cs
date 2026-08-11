public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        if (strs.Length == 1){
            return [[strs[0]]];
        }

        Dictionary<string/*hash*/,List<string>> result = [];

        for (int i=0; i<strs.Length; i++){

            string curAnnogram = strs[i];
            string curAnnogramHash = GetAnagramHash(curAnnogram);

            if(result.TryGetValue(curAnnogramHash, out var listOfAnagrams)){
                listOfAnagrams.Add(curAnnogram);
            } else {
                result[curAnnogramHash] = [curAnnogram];
            }

        }

        return result.Values.ToList();
    }

    private static string GetAnagramHash(string s) {
        if(string.IsNullOrEmpty(s)){
            return "";
        }

        var charsFreq = new byte[26];
        for(int i = 0; i <s.Length; i++){
            charsFreq[s[i] - 'a']++;
        }

        StringBuilder sb = new();
        foreach(byte b in charsFreq){
            sb.Append(b);
            sb.Append('.');
        }

        //Console.WriteLine($"hash for {s} is {sb.ToString()}");

        return sb.ToString();
    }

}