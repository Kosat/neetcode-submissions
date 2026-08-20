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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode resultDummy = new ListNode();
        ListNode resultTail = resultDummy;

        ListNode l1Ptr = list1, l2Ptr = list2;

        while (l1Ptr != null && l2Ptr != null) 
        {
           ListNode curMinPtr;
            if(l1Ptr.val <= l2Ptr.val)
            {
                curMinPtr = l1Ptr;
                l1Ptr = l1Ptr.next;
            }
            else 
            {
                curMinPtr = l2Ptr;
                l2Ptr = l2Ptr.next;
            }

            resultTail.next = curMinPtr;
            resultTail = resultTail.next;

        }

        while (l1Ptr != null) 
        {
            resultTail.next = l1Ptr;
            resultTail = resultTail.next;
            l1Ptr = l1Ptr.next;

        }

        while (l2Ptr != null) 
        {
            resultTail.next = l2Ptr;
            resultTail = resultTail.next;
            l2Ptr = l2Ptr.next;
        }

        return resultDummy.next;
    }
}