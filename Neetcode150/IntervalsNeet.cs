using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Neetcode150
{
    public class IntervalsNeet
    {
        #region Insert Interval
        /*
        You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi] represent the start and the end of the ith interval and intervals is sorted in ascending order by starti. You are also given an interval newInterval = [start, end] that represents the start and end of another interval.
        Insert newInterval into intervals such that intervals is still sorted in ascending order by starti and intervals still does not have any overlapping intervals (merge overlapping intervals if necessary).
        Return intervals after the insertion.
        Note that you don't need to modify intervals in-place. You can make a new array and return it.

        Example 1:
        Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
        Output: [[1,5],[6,9]]

        Example 2:
        Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
        Output: [[1,2],[3,10],[12,16]]
        Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].

        Constraints:

            0 <= intervals.length <= 104
            intervals[i].length == 2
            0 <= starti <= endi <= 105
            intervals is sorted by starti in ascending order.
            newInterval.length == 2
            0 <= start <= end <= 105

        https://leetcode.com/problems/insert-interval/
        Extra Test Cases: 54 / 157 testcases passed
        intervals = []
        newInterval = [5,7]
        */
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var result = new List<int[]>();

            for (var i = 0; i < intervals.Length; i++)
            {
                if (newInterval[1] < intervals[i][0])
                {
                    result.Add(newInterval);
                    result.AddRange(
                        intervals.AsEnumerable().Skip(i).ToArray());

                    return result.ToArray();
                }
                else if (newInterval[0] > intervals[i][1])
                {
                    result.Add(intervals[i]);
                }
                else
                {
                    newInterval[0] = Math.Min(intervals[i][0], newInterval[0]);
                    newInterval[1] = Math.Max(intervals[i][1], newInterval[1]);
                }
            }

            result.Add(newInterval);

            return result.ToArray();
        }
        #endregion Insert Interval
        #region Merge Intervals
        /*
        Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.

        Example 1:
        Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
        Output: [[1,6],[8,10],[15,18]]
        Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].

        Example 2:
        Input: intervals = [[1,4],[4,5]]
        Output: [[1,5]]
        Explanation: Intervals [1,4] and [4,5] are considered overlapping.

        Constraints:

            1 <= intervals.length <= 104
            intervals[i].length == 2
            0 <= starti <= endi <= 104


        C# Test Cases:
        # 1st Example:
        int[][] twoDArray = new int[][]
            {
            new int[] {1,3},
            new int[] {2,6},
            new int[] {8,10},
            new int[] {15,18},
            };
        https://leetcode.com/problems/merge-intervals/
        Extra Test Cases:
        [[1,3]] 13 / 170 testcases passed
        */
        //Simplified version of the neetcode one.
        public int[][] Merge(int[][] intervals)
        {
            List<int[]> result = new();
            Array.Sort(intervals, (a, b) => a[0] - b[0]);
            var lastInterval = intervals[0];//Track the large overlapping end
            result.Add(lastInterval);
            for (int i = 1; i < intervals.Length; i++)
            {
                if (lastInterval[1] >= intervals[i][0])
                {
                    lastInterval[1] = Math.Max(intervals[i][1], lastInterval[1]);
                }
                else
                {
                    lastInterval = intervals[i];
                    result.Add(lastInterval);
                }
            }

            return result.ToArray();
        }
        //Keeping this here for reference belongs to neetcode
        public int[][] MergeNeetCode(int[][] intervals)
        {

            var sortedInterval = intervals.Clone() as int[][];
            Array.Sort(sortedInterval, (a, b) => a[0] - b[0]);

            var mergedInterval = new List<int[]>();
            var lastInterval = sortedInterval[0];
            mergedInterval.Add(lastInterval);

            for (var i = 1; i < sortedInterval.Length; i++)
            {
                var current = sortedInterval[i];
                var lastIntervalEnd = lastInterval[1];
                var nextIntervalEnd = current[1];
                var nextIntervalStart = current[0];

                if (lastIntervalEnd >= nextIntervalStart)
                    lastInterval[1] = Math.Max(nextIntervalEnd, lastIntervalEnd);
                else
                {
                    lastInterval = current;
                    mergedInterval.Add(lastInterval);
                    //lastInterval = current;
                }
            }

            return mergedInterval.ToArray();
        }
        #endregion Merge Intervals
        #region Non-overlapping Intervals
        /*
        https://leetcode.com/problems/non-overlapping-intervals/
        Extra Test Cases:
        [[1,100],[11,22],[1,11],[2,12]]
        */
        //Neetcode solution
        public int EraseOverlapIntervals(int[][] intervals)
        {
            List<int[]> result = new();
            int counter = 0;
            Array.Sort(intervals, (a, b) => a[0] - b[0]);
            int prevEnd = intervals[0][1];

            for (int i = 1; i < intervals.Length; i++)
            {
                if (prevEnd > intervals[i][0])
                {
                    prevEnd = Math.Min(prevEnd, intervals[i][1]);
                    counter++;
                }
                else
                {
                    prevEnd = intervals[i][1];
                }
            }

            return counter;
        }
        //Alternative solution with a different array sorting comparer
        public int EraseOverlapIntervals2(int[][] intervals)
        {
            Array.Sort(intervals, (x, y) =>
            {
                if (x[0] == y[0])
                {
                    return 0;
                }
                return x[0] > y[0] ? 1 : -1;
            });

            int del = 0, left = 0, n = intervals.Length; ;
            for (int right = 1; right < n; ++right)
            {
                if (intervals[right][0] < intervals[left][1])
                {
                    if (intervals[left][1] > intervals[right][1])
                    { // if first interval sorted by start ends later than the second
                        left = right;
                    }
                    del++;
                }
                else
                {
                    left = right;
                }
            }
            return del;
        }
        #endregion
        #region Meeting Rooms
        /*
        Given an array of meeting time interval objects consisting of start and end times [[start_1,end_1],[start_2,end_2],...] (start_i < end_i), determine if a person could add all meetings to their schedule without any conflicts.
        
        Example 1:
        Input: intervals = [(0,30),(5,10),(15,20)]
        Output: false
        Explanation:

            (0,30) and (5,10) will conflict
            (0,30) and (15,20) will conflict

        Example 2:
        Input: intervals = [(5,8),(9,15)]
        Output: true
        Note:
            (0,8),(8,10) is not considered a conflict at 8
        Constraints:

            0 <= intervals.length <= 500
            0 <= intervals[i].start < intervals[i].end <= 1,000,000

        */
        public class Interval
        {
            public int start, end;
            public Interval(int start, int end)
            {
                this.start = start;
                this.end = end;
            }
        }

        public bool CanAttendMeetings(List<Interval> intervals)
        {
            Interval[] arri = intervals.ToArray();

            if (arri.Length == 1 || arri.Length == 0)
                return true;

            Array.Sort(arri, (a, b) => a.start - b.start);
            int prevEnd = arri[0].end;

            for (int i = 1; i < arri.Length; i++)
            {
                if (prevEnd > arri[i].start)
                    return false;
                else
                    prevEnd = arri[i].end;
            }

            return true;
        }
        #endregion
        #region Meeting Rooms II
        /*
        Given an array of meeting time interval objects consisting of start and end times [[start_1,end_1],[start_2,end_2],...] (start_i < end_i), find the minimum number of days required to schedule all meetings without any conflicts.

        Example 1:
        Input: intervals = [(0,40),(5,10),(15,20)]
        Output: 2
        Explanation:
        day1: (0,40)
        day2: (5,10),(15,20)

        Example 2:
        Input: intervals = [(4,9)]
        Output: 1
        Note:
            (0,8),(8,10) is not considered a conflict at 8

        Constraints:

            0 <= intervals.length <= 500
            0 <= intervals[i].start < intervals[i].end <= 1,000,000
            Extra Test Cases:
            [] 6 / 22 cases passed
            [(0,10),(1,3),(2,6),(5,8),(7,12),(11,15),(13,18),(16,20),(19,25),(24,30)] 10 / 22 cases passed
            [(0,10),(10,20),(20,30),(30,40),(40,50),(50,60),(60,70),(70,80),(80,90),(90,100),(0,100),(10,90),(20,80),(30,70),(40,60)] 19 / 22 cases passed
            C# Test Cases:
            List<IntervalsNeet.Interval> times = new()
            {
            new IntervalsNeet.Interval(0,10),
            new IntervalsNeet.Interval(10,20) ,
            new IntervalsNeet.Interval(20,30),
            new IntervalsNeet.Interval(30,40),
            new IntervalsNeet.Interval(40,50),
            new IntervalsNeet.Interval(50,60),                   
            new IntervalsNeet.Interval(60,70),
            new IntervalsNeet.Interval(70,80),
            new IntervalsNeet.Interval(80,90),
            new IntervalsNeet.Interval(90,100),
            new IntervalsNeet.Interval(0,100),
            new IntervalsNeet.Interval(10,90),
            new IntervalsNeet.Interval(20,80),
            new IntervalsNeet.Interval(30,70),
            new IntervalsNeet.Interval(40,60)
            };
            List<IntervalsNeet.Interval> times2 = new()
            {
            new IntervalsNeet.Interval(0,10),
            new IntervalsNeet.Interval(1,3) ,
            new IntervalsNeet.Interval(2,6),
            new IntervalsNeet.Interval(5,8),
            new IntervalsNeet.Interval(7,12),
            new IntervalsNeet.Interval(11,15),                   
            new IntervalsNeet.Interval(16,20),
            new IntervalsNeet.Interval(19,25),
            new IntervalsNeet.Interval(24,30)
            };
        */
        /**
        * Definition of Interval:
        * public class Interval {
        *     public int start, end;
        *     public Interval(int start, int end) {
        *         this.start = start;
        *         this.end = end;
        *     }
        * }
        */
        public int MinMeetingRooms(List<Interval> intervals)
        {
            if (intervals == null || intervals.Count == 0)
            {
                return 0;
            }

            int result = 0;
            List<int> start = new List<int>(), end = new List<int>();

            foreach (Interval interval in intervals)
            {
                start.Add(interval.start);
                end.Add(interval.end);
            }

            start.Sort();
            end.Sort();

            for (int s = 0, e = 0; s < start.Count; s++)
            {
                if (start[s] < end[e])
                {
                    result++;
                }
                else
                {
                    e++;
                }
            }
            return result;
        }
        #endregion
        #region Minimum Interval to Include Each Query
        /*
        https://leetcode.com/problems/minimum-interval-to-include-each-query/
        */
         public int[] MinInterval(int[][] intervals, int[] queries)
    {

        var q = queries.Length;
        var indexDict = new int[q][];
        var index = 0;
        foreach (var query in queries)
        {
            indexDict[index] = new int[2] { query, index };
            index++;
        }
        Array.Sort(indexDict, (a, b) => a[0] - b[0]);
        Array.Sort(intervals, (a, b) => a[0] - b[0]);

        var pq = new PriorityQueue<int[], int>();
        var result = new int[queries.Length];

        index = 0;
        foreach (var query in indexDict)
        {
            var resultIndex = query;
            var calResult = -1;

            while (index < intervals.Length && intervals[index][0] <= resultIndex[0])
            {
                var curr = intervals[index];
                pq.Enqueue(new int[2] { curr[1] - curr[0] + 1, curr[1] }, curr[1] - curr[0] + 1);
                index++;
            }

            while (pq.Count > 0 && pq.Peek()[1] < resultIndex[0])
            {
                pq.Dequeue();
            }
            calResult = pq.Count > 0 ? pq.Peek()[0] : -1;
            result[resultIndex[1]] = calResult;
        }

        return result;

    }
        #endregion
    }
}
