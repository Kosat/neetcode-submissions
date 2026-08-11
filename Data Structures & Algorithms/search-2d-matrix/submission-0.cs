public class Solution {

    private int _rowN;
    private int _colN;

    public bool SearchMatrix(int[][] matrix, int target) 
        => BinarySearch(matrix, target);


    private bool BinarySearch(int[][] matrix, int target){
        _rowN = matrix.Length;       // number of rows
        _colN = matrix[0].Length;    // number of columns

        Console.WriteLine($"rowN={_rowN}, colN={_colN} ");
        
        int i=0, j = _colN*_rowN-1;

        while (i<=j){
            int med = i + (j-i)/2;
            if(GetMatrixVal(matrix, med) ==  target){
                return true;
            } else if (GetMatrixVal(matrix, med) > target) {
                j = med -1;
            } else {
                i = med + 1;
            }
        }

        return false;

    }

    private int GetMatrixVal(int[][] matrix, int linearIdx){
        int curRowIdx = linearIdx / _colN;   // divide by COLUMN count
        int curColIdx = linearIdx % _colN;   // remainder = column index
        return matrix[curRowIdx][curColIdx];
    }
}
