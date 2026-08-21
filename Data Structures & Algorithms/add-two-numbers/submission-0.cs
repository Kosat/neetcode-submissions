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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode resultDummy = new (); 
        int carry = 0;

        ListNode curL1 = l1;
        ListNode curL2 = l2;
        ListNode curResult = resultDummy;

        while(curL1 != null || curL2 != null)
        {
            int curSum = (curL1 != null ? curL1.val : 0 ) + (curL2 != null ? curL2.val : 0 ) + carry;
            
            carry = curSum / 10;

            curResult.next = new ListNode(curSum % 10);

            curL1 = curL1?.next;
            curL2 = curL2?.next;
            curResult = curResult.next;
        }

        // Handle the remaining `carry`
        if(carry != 0)
        {
            curResult.next = new ListNode(carry);
        }

        return resultDummy.next; 
    }
}
