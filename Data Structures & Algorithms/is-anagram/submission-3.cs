public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length){
            return false;
        }

        var charsFreq = new byte[26];
        for(int i = 0; i <s.Length; i++){
            charsFreq[s[i] - 'a']++; 
            charsFreq[t[i] - 'a']--; 
        }

        foreach(var cf in charsFreq){
            if(cf != 0) return false;
        }

        return true;
    }
}
