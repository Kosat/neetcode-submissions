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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        
        ListNode leftPrev = null;
        ListNode left = null; // Delayed pointer that would be 'late' after left by n nodes. Both pointers however will be advincing at the same pace +1 node at time.
        ListNode right = head;
        int steps = 0;

        while (right != null)
        {
            // Advance both pointers
            right = right.next;
            if(left != null)
            {
                leftPrev = left;
                left = left.next;
            }

            if(steps == n - 1) 
            {
                left = head;
            }

            steps++;
        }

        // Remove the N-th node
        if(leftPrev != null)
        {
            leftPrev.next = left?.next;
        }
        else
        {
            // if we are removing the left-most element, adjust header node
            if (left != null)
            {
                head = left.next;
            }
        }

        return head;
    }
}
