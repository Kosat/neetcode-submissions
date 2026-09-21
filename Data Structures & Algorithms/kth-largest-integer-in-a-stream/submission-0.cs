public class KthLargest {

    PriorityQueue<int,int> _max = new ();
    private int k;

    public KthLargest(int k, int[] nums) {
        
        this.k = k;

        foreach(int n in nums)
        {
            _max.Enqueue(n, n);
            if (_max.Count > k) {
                _max.Dequeue();
            }
        }
    }
    
    public int Add(int val) {
        _max.Enqueue(val, val);
        if (_max.Count > k) {
            _max.Dequeue();
        }
        return _max.Peek();
    }
}
