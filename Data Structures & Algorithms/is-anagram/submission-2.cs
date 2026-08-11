public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length){
            return false;
        }

        var chars = new byte[32];
        foreach(char c in s.ToCharArray()){
            chars[(int)c - (int)'a'] += 1; 
        }

        foreach(char c in t.ToCharArray()){
            chars[(int)c - (int)'a'] -= 1; 
        }

        foreach(var c in chars){
            if((byte)c != 0) return false;
        }

        return true;
    }
}
