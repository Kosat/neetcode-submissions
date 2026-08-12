public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {

        int n = temperatures.Length;
        Stack<int/*idx*/> stk = new (n);
        int[] result = new int[n]; 
        
        for(int i = 0; i < n; i++) {

            int t = temperatures[i];
            
            while(stk.Count() > 0) {

                int stkIdx = stk.Peek();

                if(temperatures[stkIdx] < t) {
                    stk.Pop();
                    result[stkIdx] = i - stkIdx;
                } else {
                    break;
                }
            }
            // Important invariant here is that after the above while loop
            // 'i' will be the biggest element in the stack. Meaning temps[i] -> value.
            stk.Push(i);        
        }

        // Some elements may be still in the stack b/c they do not have values 
        // larger than any of their rightmost t-s. I.e. 40 or 28 in the end
        // In this case the result elements will be defaulted 0-s and never processed.
        return result;

    }
}
