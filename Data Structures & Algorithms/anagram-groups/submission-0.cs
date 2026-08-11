public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        if (strs.Length == 1){
            return [[strs[0]]];
        }

        List<List<string>> result = [[strs[0]]];

        for (int i=1; i<strs.Length; i++){

            string curAnnogram = strs[i];
            bool found = false;

            foreach(List<string> grp in result){
                if(IsAnagram(grp[0], curAnnogram)){
                    grp.Add(curAnnogram);
                    found = true;
                    break; // stop scanning once matched, and exit before we'd otherwise mutate result
                }
            }

            if (!found) {
                result.Add([curAnnogram]); // only added after the foreach is done, never during it
            }
        }

        return result;
    }

    private static bool IsAnagram(string s, string t) {
        if(s.Length != t.Length){
            return false;
        }

        var charsFreq = new byte[26];
        for(int i = 0; i <s.Length; i++){
            charsFreq[s[i] - 'a']++;
            charsFreq[t[i] - 'a']--;
        }

        foreach(var cf in charsFreq){
            if (cf != 0) return false;
        }

        return true;
    }
}