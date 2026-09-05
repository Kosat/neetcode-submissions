public class Solution {
    public bool WordBreak(string s, List<string> wordDict) {
        
        return WordBreak(s, 0, wordDict, []);
    }

    private bool WordBreak(string s, int i, List<string> wordDict, Dictionary<string, bool> memoization)
    {
        if (i == s.Length)
        {
            return true;
        }

        if (memoization.TryGetValue(s, out bool memoResult))
        {
            return memoResult;
        }

        while (i < s.Length)
        {
            if (FindWord(s[..(i + 1)], wordDict))
            {
                if (WordBreak(s[(i + 1)..], 0, wordDict, memoization))
                {
                    memoization[s[(i + 1)..]] = true;
                    return true;
                }
                else
                {
                    memoization[s[(i + 1)..]] = false;
                }
            }
            i++;
        }

        return false;
    }

    private bool FindWord(string word, List<string> wordDict)
    {
        foreach (string w in wordDict)
        {
            // wordDict contains unique words
            if (w == word)
            {
                return true;
            }
        }

        return false;
    }
}
