public class LRUCache {

    private readonly Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> _cacheDic;
    private readonly LinkedList<KeyValuePair<int, int>> _cacheLL;

    private readonly int _capacity;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cacheDic = new(capacity);
        _cacheLL = new();
    }

    public int Get(int key)
    {
        // Ensure that get and put each run in O(1) average time complexity.
        // If _cacheDic does NOT contain the key, return -1.
        if (!_cacheDic.TryGetValue(key, out var node)) return -1;
        
        _cacheLL.Remove(node); // O(1) - yes b/c doubly linked list
        _cacheLL.AddLast(node);

        // Read the Value out of that node's KeyValuePair and return it.
        return node.Value.Value;
        

    }

    public void Put(int key, int value)
    {
        // Ensure that get and put each run in O(1) average time complexity.
        // If _cacheDic contains the key:
        if(_cacheDic.TryGetValue(key, out var node))
        {
            // Update the value in Dic
            node.Value = new(key, value);

             //   Then mark it most-recently-used: Remove(node) from _cacheLL and AddLast(node).
             _cacheLL.Remove(node); // O(1) - yes b/c doubly linked list
             _cacheLL.AddLast(node);
        } 
        else
        {
            // If it does NOT contain the key:
            if(_cacheDic.Count == _capacity)
            {
                //   If Count == _capacity, evict the least-recently-used item:
                var oldLLNode = _cacheLL.First; 
                _cacheLL.RemoveFirst();
                _cacheDic.Remove(oldLLNode.Value.Key);
            }

            // Then Add(key, newNode) to _cacheDic and AddLast(newNode) to _cacheLL.
            var newNode = new LinkedListNode<KeyValuePair<int, int>>(new(key, value));
            _cacheDic.Add(key, newNode);
            _cacheLL.AddLast(newNode);
        }
    }
}
