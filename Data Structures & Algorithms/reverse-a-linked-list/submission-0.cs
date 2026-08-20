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
    public ListNode ReverseList(ListNode head) {
        
        ListNode c = head;
        ListNode p = null;

        while (c != null) 
        {   
            ListNode cNextOld = c.next;
            if(p != null) 
            {
                c.next = p;
            }
            else 
            {
                c.next = null;
            }
            p = c;
            c = cNextOld;
        }

        return p;
    }
}
