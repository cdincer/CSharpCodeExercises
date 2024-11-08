using System;
using System.Collections.Generic;

namespace Exercises.Leetcode.StackRelated
{
    public class StackLeetCode
    {
        #region Baseball Game
        /*
        You are keeping the scores for a baseball game with strange rules. At the beginning of the game, you start with an empty record.
        You are given a list of strings operations, where operations[i] is the ith operation you must apply to the record and is one of the following:

            An integer x.
                Record a new score of x.
            '+'.
                Record a new score that is the sum of the previous two scores.
            'D'.
                Record a new score that is the double of the previous score.
            'C'.
                Invalidate the previous score, removing it from the record.

        Return the sum of all the scores on the record after applying all the operations.
        The test cases are generated such that the answer and all intermediate calculations fit in a 32-bit integer and that all operations are valid.

        Example 1:
        Input: ops = ["5","2","C","D","+"]
        Output: 30
        Explanation:
        "5" - Add 5 to the record, record is now [5].
        "2" - Add 2 to the record, record is now [5, 2].
        "C" - Invalidate and remove the previous score, record is now [5].
        "D" - Add 2 * 5 = 10 to the record, record is now [5, 10].
        "+" - Add 5 + 10 = 15 to the record, record is now [5, 10, 15].
        The total sum is 5 + 10 + 15 = 30.

        Example 2:
        Input: ops = ["5","-2","4","C","D","9","+","+"]
        Output: 27
        Explanation:
        "5" - Add 5 to the record, record is now [5].
        "-2" - Add -2 to the record, record is now [5, -2].
        "4" - Add 4 to the record, record is now [5, -2, 4].
        "C" - Invalidate and remove the previous score, record is now [5, -2].
        "D" - Add 2 * -2 = -4 to the record, record is now [5, -2, -4].
        "9" - Add 9 to the record, record is now [5, -2, -4, 9].
        "+" - Add -4 + 9 = 5 to the record, record is now [5, -2, -4, 9, 5].
        "+" - Add 9 + 5 = 14 to the record, record is now [5, -2, -4, 9, 5, 14].
        The total sum is 5 + -2 + -4 + 9 + 5 + 14 = 27.

        Example 3:
        Input: ops = ["1","C"]
        Output: 0
        Explanation:
        "1" - Add 1 to the record, record is now [1].
        "C" - Invalidate and remove the previous score, record is now [].
        Since the record is empty, the total sum is 0.

        Constraints:

            1 <= operations.length <= 1000
            operations[i] is "C", "D", "+", or a string representing an integer in the range [-3 * 104, 3 * 104].
            For operation "+", there will always be at least two previous scores on the record.
            For operations "C" and "D", there will always be at least one previous score on the record.

        https://leetcode.com/problems/baseball-game/description/
        */
        public int CalPoints(string[] operations)
        {
            Stack<int> scoreSetter = new Stack<int>();

            for (int i = 0; i < operations.Length; i++)
            {
                string prepro = operations[i];
                if (int.TryParse(prepro, out int myNumber))
                {
                    scoreSetter.Push(myNumber);
                }
                else if (char.TryParse(prepro, out char result))
                {
                    switch (result)
                    {
                        case 'C':
                            scoreSetter.Pop();
                            break;
                        case 'D':
                            int sc = scoreSetter.Peek();
                            sc = sc * 2;
                            scoreSetter.Push(sc);
                            break;
                        case '+':
                            int tbr = scoreSetter.Pop();
                            int ptr = scoreSetter.Peek();
                            scoreSetter.Push(tbr);
                            scoreSetter.Push(tbr + ptr);
                            break;
                        default:
                            Console.WriteLine("default");
                            break;
                    }
                }
            }
            int actualResult = 0;
            while (scoreSetter.Count > 0)
            {
                actualResult = actualResult + scoreSetter.Pop();
            }

            return actualResult;
        }
        #endregion
        #region Maximum Width Ramp
        /*
        A ramp in an integer array nums is a pair (i, j) for which i < j and nums[i] <= nums[j]. 
        The width of such a ramp is j - i. Given an integer array nums, return the maximum width of a ramp in nums. 
        If there is no ramp in nums, return 0.

        Example 1:
        Input: nums = [6,0,8,2,1,5]
        Output: 4
        Explanation: The maximum width ramp is achieved at (i, j) = (1, 5): nums[1] = 0 and nums[5] = 5.

        Example 2:
        Input: nums = [9,8,1,0,1,9,4,0,4,1]
        Output: 7
        Explanation: The maximum width ramp is achieved at (i, j) = (2, 9): nums[2] = 1 and nums[9] = 1.

        Constraints:

            2 <= nums.length <= 5 * 104
            0 <= nums[i] <= 5 * 104

        Extra Test Cases:
        nums = [2,2,1] Expected: 1 73 / 101 testcases passed
        nums = [1,0] Expected: 0 68 / 101 testcases passed
        nums = [4,2,3,1] Expected: 1 65 / 101 testcases passed
        https://leetcode.com/problems/maximum-width-ramp/
        */
        public int MaxWidthRamp(int[] nums)
        {
            Stack<int> mstack = new();
            int res = 0, n = nums.Length;
            for (int i = 0; i < n; ++i)
            {
                if (mstack.Count == 0 || nums[mstack.Peek()] > nums[i])
                    mstack.Push(i);
            }
              
            for (int i = n - 1; i > res; --i)
            {
                while (mstack.Count != 0 && nums[mstack.Peek()] <= nums[i])
                    res = Math.Max(res, i - mstack.Pop());
            }

            return res;
        }
        #endregion

    }
}