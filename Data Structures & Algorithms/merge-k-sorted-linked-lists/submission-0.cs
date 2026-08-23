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
    public ListNode MergeKLists(ListNode[] lists) {
         ListNode resultDummy = new();

        int n = lists.Length; // the count of the lists

        if(n == 0)
        {
            return resultDummy.next;
        }
        
        ListNode[] curPtrs = new ListNode[n]; // iteration counter per list 

        // Init all the ptrs to point to the heads of the lists
        for(int i = 0; i < n; i++)
        {
            ListNode head = lists[i];
            curPtrs[i] = head;
        }

        int k = 0; // iterator over lists 0..n-1 inclusive

        PriorityQueue<int,int> nodesChunk = new(); // chunk of nodes processed in one iteration for each of the 0..n-1 lists
        ListNode resultDummyCur = resultDummy;
        int nonNullPtrsCount = 0;

        while(true)
        {
            ListNode curPtr = curPtrs[k];
            if(curPtr != null)
            {
                nodesChunk.Enqueue(curPtr.val, curPtr.val);
                curPtrs[k] = curPtr.next;
                nonNullPtrsCount++;
            }

            // Break the loop condition — when all ptrs are null we reached the end of all the lists
            if(k == n - 1)
            {
                if(nonNullPtrsCount == 0)
                {
                    break;
                }
                else 
                {
                    // Restart the round robin iterator
                    k = 0;
                    nonNullPtrsCount = 0;
                }
            }
            else
            {
               // Increment the round robin iterator
               k++; 
            }
        }

        // Copy nodes from the Priority Queue into the final Linked List
        while(nodesChunk.Count > 0)
        {
            resultDummyCur.next = new(nodesChunk.Dequeue());
            resultDummyCur = resultDummyCur.next;
        }

        return resultDummy.next;
    }
}
