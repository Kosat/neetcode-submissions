// Testing the code stylistics
public class Solution {
    public int[] SortArray(int[] nums)
        => MergeSort(nums, 0, nums.Length - 1);
    

    private int[] MergeSort(int[] n, int l, int r) {
        if (l == r) {
            return n;
        }

        int m = l + (r - l) / 2;

        MergeSort(n, l, m);
        MergeSort(n, m + 1, r);

        MergeTwoArrays(n, l, m, r);

        return n;
    }

    // In-pace merging, zipping 2 arrays. 1 array is to the left from 'm', and the second array is
    // to the right from 'm'.
    private void MergeTwoArrays(int[] n, int l, int m, int r) {
        int[] left = n[l..(m + 1)];
        int[] right = n[(m + 1)..(r + 1)];

        int i = l, j = 0, k = 0;

        while (j < left.Length && k < right.Length) {
            if (left[j] < right[k]) {
                n[i] = left[j++];
            } else {
                n[i] = right[k++];
            }
            i++;
        }

        // process the remaing left array elements
        while (j < left.Length) {
            n[i] = left[j++];
            i++;
        }

        // process the remaing right array elements
        while (k < right.Length) {
            n[i] = right[k++];
            i++;
        }
    }
}