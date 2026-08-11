public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> accum = [];

        int val1, val2;

        foreach(var t in tokens){
            switch(t) {
                case "+":
                    val1 = accum.Pop();
                    val2 = accum.Pop();
                    accum.Push(val1 + val2);
                    break;
                case "-":
                    val1 = accum.Pop();
                    val2 = accum.Pop();
                    accum.Push(val2 - val1);
                    break;
                case "*":
                    val1 = accum.Pop();
                    val2 = accum.Pop();
                    accum.Push(val1 * val2);
                    break;
                case "/":
                    val1 = accum.Pop();
                    val2 = accum.Pop();
                    accum.Push(val2 / val1);
                    break;
                default:
                    accum.Push(int.Parse(t));
                    break;
            }
        }

        return accum.Pop();
    }
}
