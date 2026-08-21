/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        if(head == null)
        {
            return null;
        }

        // First pass is to create a copy Linked List and populating the mappings between origNode->copyNode
        // At this pass `random` properties are not being set!
        Dictionary<Node/*orig*/, Node/*copy*/> nodesOrigToCopyMapping = [];
        Node copyHeadDummy = new(0);
        Node copyCur = copyHeadDummy;
        Node origCur = head;
        while(origCur != null)
        {
            copyCur.next = new Node(origCur.val);
            nodesOrigToCopyMapping[origCur] = copyCur.next;
            copyCur = copyCur.next;
            origCur = origCur.next;
        }

        // Second pass to set `random` property only. At this point we do have all the refferences in `nodesOrigToCopyMapping` dict, thus no problem of referencing not-yet-proccessed nodes
        copyCur = copyHeadDummy.next;
        origCur = head;
        while(origCur != null)
        {
            copyCur.random = origCur.random != null ? nodesOrigToCopyMapping[origCur.random] : null;

            origCur = origCur.next;
            copyCur = copyCur.next;
        }

        return copyHeadDummy.next;
    }
}
