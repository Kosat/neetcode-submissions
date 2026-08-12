public class Solution {
    private static char SEPARATOR = '|';

    public string Encode(IList<string> strs) {
        // write metadata
        var encoddedData = new StringBuilder($"{strs.Count()}{SEPARATOR}");
        foreach (string s in strs) {
            encoddedData.Append($"{s.Length}{SEPARATOR}");
        }

        // write the raw data
        foreach (string s in strs) {
            encoddedData.Append(s);
        }

        Console.WriteLine(encoddedData.ToString());
        return encoddedData.ToString();
    }

    public List<string> Decode(string s) {
        int idx = 0;

        // Read the encodded strings count
        int strListCount;
        var metaSb = new StringBuilder();
        while (s[idx] != SEPARATOR) {
            metaSb.Append(s[idx]);
            idx++;
        }
        strListCount = int.Parse(metaSb.ToString());
        idx++;  // move to the next char after the separator

        // Edge case for completely empty encodded list 
        if(strListCount == 0) {
            return [];
        }

        // Read the lenghes of each encodded strings from the metadata
        List<int> strSizes = [];
        for (int k = 0; k < strListCount; k++) {
            metaSb = new StringBuilder();
            while (s[idx] != SEPARATOR) {
                metaSb.Append(s[idx]);
                idx++;
            }
            strSizes.Add(int.Parse(metaSb.ToString()));
            idx++;  // move to the next char after the separator
        }

        // Read the srings data at last
        List<string> decodedStrings = [];
        int i = 0;
        int curStringNumber = 0;
        var oneStringData = new StringBuilder();
        while (idx + i < s.Length || strSizes[curStringNumber] == 0) {
            Console.Write($"idx={idx},i={i} ");
            if(strSizes[curStringNumber] == 0) {
                // process as empty string. Decode as ""
                decodedStrings.Add("");
                if(curStringNumber == strSizes.Count() - 1) {
                    // we have finished the last string exit
                    break;
                }
                curStringNumber++;
            }
            else {
                oneStringData.Append(s[idx + i]);
                if(i == strSizes[curStringNumber] - 1) { 
                    decodedStrings.Add(oneStringData.ToString());
                    oneStringData = new StringBuilder();
                    if(curStringNumber == strSizes.Count() - 1) {
                        // we have finished the last string exit
                        break;
                    }
                    curStringNumber++;
                    idx = idx + i + 1;
                    i = -1;
                }
                i++;
            }
        }

        return decodedStrings;
    }
}
