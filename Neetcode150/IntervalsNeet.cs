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
        */
        #endregion
    }
}
