public class Solution {

    private record Interval (int Start, int End);

    public int[][] Merge(int[][] intervals) {
        
        if(intervals.Length == 0)
        {
            return new int[0][]; // empty array
        }
        
        List<Interval> intervalsList = [];

        foreach(int[] interval in intervals)
        {
            intervalsList.Add(new(interval[0], interval[1]));
        }

        intervalsList.Sort((x,y)=>x.Start.CompareTo(y.Start));

        List<int[]> resultList = [];

        Interval prev = intervalsList[0];
        
        for(int i = 1; i < intervalsList.Count; i++)
        {
            
            Interval cur = intervalsList[i];

            if(prev.End >= cur.Start)
            {
                // Overlap detected - merge cur with prev
                prev = new (prev.Start, Math.Max(prev.End, cur.End));
            }
            else
            {
                // No overlap detected - save prev in the result
                resultList.Add(new int[2] { prev.Start, prev.End});
                prev = cur;
            }
        }

        resultList.Add(new int[2] { prev.Start, prev.End});


        // Convert from List<Interval> into int[][] 
        int[][] result = new int[resultList.Count][];

        int k = 0;
        foreach(int[] interval in resultList)
        {
            result[k] = interval;
            k++;
        }

        return result;
    }
}
