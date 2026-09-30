public class Solution
{
    // Complexity: O(V + E) time, O(V + E) extra space
    // Underlying collection: Dictionary<int, List<int>> adjacencyList and HashSet<int> visited
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        // Example 1: Input: numCourses = 2, prerequisites = [[0,1]] Output: true
        // Example 2: Input: numCourses = 2, prerequisites = [[0,1],[1,0]] Output: false

        // LeetCode pattern: Graphs

        // Build the Adjecency List for each of the courses
        Dictionary<int, List<int>> adjacencyList = [];

        for (int i = 0; i < numCourses; i++)
        {
            adjacencyList[i] = [];
        }

        foreach (int[] dep in prerequisites)
        {
            var course = dep[0];
            var prereq = dep[1];
            adjacencyList[course].Add(prereq);
        }

        // Staring from each of the course, travers all its preprequisites
        // Detect whether there is loops or not

        HashSet<int> visited = [];

        for (int i = 0; i < numCourses; i++)
        {
            if (!Dfs(i))
            {
                return false;
            }
        }

        return true;

        // Nested function - to avoid passing alot of params
        bool Dfs(int curCourse)
        {
            if (visited.Contains(curCourse))
            {
                // Loop detected
                return false;
            }

            // Check if this course was previously traversed and verified to contain no circles
            // This is needed to bring Big-O time from O(2^V) to O(V + E)
            if (adjacencyList[curCourse].Count == 0)
            {
                return true;
            }

            visited.Add(curCourse);

            foreach (var pre in adjacencyList[curCourse])
            {
                if (!Dfs(pre))
                {
                    return false;
                }
            }

            // Backtracking
            visited.Remove(curCourse);

            // mark it done (e.g. empty its list), so it's never explored twice
            // This is needed to bring Big-O time from O(2^V) to O(V + E)
            adjacencyList[curCourse] = [];
            return true;
        }
    }
}
