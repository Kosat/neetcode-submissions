// My QuickSort - attempt 1. Following the guides
public class Solution {
    public int[] SortArray(int[] nums) {
         
         QuickSort(nums, 0, nums.Length-1);

         return nums;
    }

    private void QuickSort(int[] n, int low, int high) {
        if(low < high) {
            int pivotIdx = Partition(n, low, high);

            QuickSort(n, low, pivotIdx - 1); // recurse for left partition, excluding pivot element in the middle
            QuickSort(n, pivotIdx + 1, high); // recurse for right partition, excluding pivot element in the middle
        }
    }

    /*
        Partition array in-place. Left partion is strictly less than Pivot Element. Right is gt or eq than Pivot Element
    */
    private int Partition(int[] n, int low, int high) {
        int pivotVal = n[high]; // Choose the rightmost element as a Pivot Element

        int curIdx = low;
        int borderIdx = low - 1; // Index of the smaller element

        // Note that high is exclusive to exclude the pivot element
        for(; curIdx < high; curIdx++){
            if(n[curIdx] < pivotVal){
                borderIdx++;
                Swap(n, curIdx, borderIdx);
            } 
        }

        // swap pivot element with border idx NEXT element to the right 
        Swap(n, borderIdx + 1, high /*pivot*/);

        return borderIdx + 1;
    }

    /*
        Swap two elements of array
    */
    private void Swap(int[] n, int i1, int i2) {
        //KTODO
        (n[i1], n[i2]) = (n[i2], n[i1]); 

        //int tmp = n[i1];
        //n[i1] = n[i2];
        //n[i2] = tmp;
    }
}