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
        https://leetcode.com/problems/merge-intervals/
        */
        #endregion Merge Intervals
    }
}
