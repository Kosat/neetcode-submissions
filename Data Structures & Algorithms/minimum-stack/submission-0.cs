public class MinStack {
    // Example 1: Input: ["MinStack", "push", 1, "push", 2, "push", 0, "getMin", "pop", "top", "getMin"] Output: [null,null,null,null,0,null,2,1]

    // LeetCode pattern: Stack
    // Complexity: O(1) time for each/all the operations, O(n) extra space
    // Underlying collection: Stack x2

    readonly Stack<int> mainStack = [];
    readonly Stack<int> minStack = [];


    public MinStack()
    {

    }

    public void Push(int val)
    {
        var minValueSoFar = minStack.Count > 0 ? Math.Min(minStack.Peek(), val) : val;
        mainStack.Push(val);
        minStack.Push(minValueSoFar);
    }

    public void Pop()
    {
        mainStack.Pop();
        minStack.Pop();
    }

    public int Top()
    {
        return mainStack.Peek();
    }

    public int GetMin()
    {
        return minStack.Peek();
    }
}
