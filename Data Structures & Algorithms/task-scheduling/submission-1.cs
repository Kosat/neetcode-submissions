// https://neetcode.io/problems/task-scheduling/question?list=neetcode150
// https://www.designgurus.io/course-play/grokking-the-coding-interview/doc/solution-problem-challenge-2-scheduling-tasks

public class Solution
{
    public int LeastInterval(char[] tasks, int n)
    {
        // Example 1: Input: tasks = ["X","X","Y","Y"], n = 2 Output: 5
        // Example 2: Input: tasks = ["A","A","A","B","C"], n = 3 Output: 9

        // Implementation Plan:
        // - Count each task's frequency (Dictionary<char,int>).
        // - Max-heap by remaining count picks the next task to run (PriorityQueue<char,int>).
        // - After running, if count remains, task goes into a cooldown queue until eligible again (Queue<(char,int)>).
        // - Loop cycle-by-cycle until both the heap and the cooldown queue are empty.

        // LeetCode pattern: Heap / Priority Queue
        // Complexity: O(m) time, O(1) extra space , where m = tasks.Length
        //             Total loop iterations bounded by O(m) given the problem's constant cap on n,
        //             and all three collections bounded by the fixed 26-letter alphabet rather
        //             than by m.
        // Underlying collection:
        // - PriorityQueue<char, int/*cycle number when it is allowed to be resumed*/>
        // - Queue<(char name, int eligibleAtCycle)> for cooldown
        // - Dictionary<char, int> - for tasks frequency tracking

        Dictionary<char, int> taskCounts = [];

        foreach (var task in tasks)
        {
            if (taskCounts.TryGetValue(task, out int value))
            {
                taskCounts[task] = ++value;
            }
            else
            {
                taskCounts[task] = 1;
            }
        }

        PriorityQueue<char, int> nextMostCountTaskMaxHeap = new(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        foreach (var task in taskCounts)
        {
            nextMostCountTaskMaxHeap.Enqueue(task.Key, task.Value);
        }

        Queue<(char name, int eligibleAtCycle)> cooldownPool = [];


        // CPU cycles loop
        int cycle = 0;

        while (nextMostCountTaskMaxHeap.Count > 0 || cooldownPool.Count > 0)
        {
            // Fold any task whose cooldown has expired back into the heap so it
            // competes on remaining count against everything else eligible this cycle,
            // rather than only running once the heap happens to drain completely.
            while (cooldownPool.Count > 0 && cooldownPool.Peek().eligibleAtCycle <= cycle)
            {
                var (name, _) = cooldownPool.Dequeue();
                nextMostCountTaskMaxHeap.Enqueue(name, taskCounts[name]);
            }

            if (nextMostCountTaskMaxHeap.Count > 0)
            {
                var curTaskName = nextMostCountTaskMaxHeap.Dequeue();
                taskCounts[curTaskName]--;
                if (taskCounts[curTaskName] > 0)
                {
                    cooldownPool.Enqueue((curTaskName, cycle + n + 1));
                }
            }

            cycle++;
        }

        // Return the minimum number of CPU cycles required to complete all tasks.
        return cycle;
    }
}
