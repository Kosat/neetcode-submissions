public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<string> stk = [];

        int val1, val2;
        string result;

        foreach(var t in tokens){
            switch(t) {
                case "+":
                    val1 = int.Parse(stk.Pop());
                    val2 = int.Parse(stk.Pop());
                    result = (val1 + val2).ToString();
                    stk.Push(result);
                    break;
                case "-":
                    val1 = int.Parse(stk.Pop());
                    val2 = int.Parse(stk.Pop());
                    result = (val2 - val1).ToString();
                    stk.Push(result);
                    break;
                case "*":
                    val1 = int.Parse(stk.Pop());
                    val2 = int.Parse(stk.Pop());
                    result = (val1 * val2).ToString();
                    stk.Push(result);
                    break;
                case "/":
                    val1 = int.Parse(stk.Pop());
                    val2 = int.Parse(stk.Pop());
                    result = (val2 / val1).ToString();
                    stk.Push(result);
                    break;
                default:
                    stk.Push(t);
                    break;
            }
        }

        return int.Parse(stk.Pop());
    }
}
