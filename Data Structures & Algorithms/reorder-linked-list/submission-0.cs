/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public void ReorderList(ListNode head) {
        // Part 1: Use classical fast-slow-ptr algo to find the middle of the original linked list
        ListNode slow = head;
        ListNode fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        ListNode headOfMidPointer = slow.next; // The second half of the original list contains the n-k, n-k-1, .. n-3, n-2, n-1, n items 
        slow.next = null; // Cut the link between the two halves so the first half terminates on its own; without this cut the merged list would form a cycle

        // Part 2: Reverse the right part of the original array. 
        // Use the classical flip-next algo
        ListNode cur = headOfMidPointer;
        ListNode prev = null;
        while (cur != null)
        {
            var tmp = cur.next;
            cur.next = prev;
            prev = cur;
            cur = tmp;
        }
        ListNode headOfMidPointerReversed = prev;

        // Part 3: Merge headOfMidPointerReversed into the original left part of the l-list
        ListNode curLeft = head;
        ListNode curRight = headOfMidPointerReversed;

        while(curRight != null)
        {
            var tmpLeftNext = curLeft.next;
            var tmpRightNext = curRight.next;
            
            curLeft.next = curRight;
            curRight.next = tmpLeftNext;

            // advance pointers
            curLeft = tmpLeftNext;
            curRight = tmpRightNext;
        }
    }
}
