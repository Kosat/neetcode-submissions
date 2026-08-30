public class Solution {
    
    private readonly Dictionary<char, char[]> _digitToLetterMap = new()
    {
        { '2', new[] { 'a', 'b', 'c' } },
        { '3', new[] { 'd', 'e', 'f' } },
        { '4', new[] { 'g', 'h', 'i' } },
        { '5', new[] { 'j', 'k', 'l' } },
        { '6', new[] { 'm', 'n', 'o' } },
        { '7', new[] { 'p', 'q', 'r', 's' } },
        { '8', new[] { 't', 'u', 'v' } },
        { '9', new[] { 'w', 'x', 'y', 'z' } },
    };

    
    public List<string> LetterCombinations(string digits) {


        if (string.IsNullOrEmpty(digits))
        {
            return [];
        }

        List<string> result = [];
        LetterCombinationsHelper(digits, 0, [], result);
        return result;

    }

    private void LetterCombinationsHelper(string digits, int i, List<char> current, List<string> result)
    {
        // Recursion base case
        if (i == digits.Length)
        {
            result.Add(string.Join("", current));
            return;
        }

        // Try each letter for the i-th digit.
        // IMPORTANT: there is no "skip this digit" branch. Every combination must use
        // exactly one letter from each digit. My earlier mistake was adding a "without
        // the i-th digit" branch without reading the problem description carefully.
        foreach (char c in _digitToLetterMap[digits[i]])
        {
            current.Add(c);
            LetterCombinationsHelper(digits, i + 1, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}
