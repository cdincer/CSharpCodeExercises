using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neetcode150
{
    public class GreedyNeet
    {
        #region Maximum Subarray
        /*
        Given an integer array nums, find the subarray
        with the largest sum, and return its sum.

        Example 1:
        Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        Output: 6
        Explanation: The subarray [4,-1,2,1] has the largest sum 6.

        Example 2:
        Input: nums = [1]
        Output: 1
        Explanation: The subarray [1] has the largest sum 1.

        Example 3:
        Input: nums = [5,4,-1,7,8]
        Output: 23
        Explanation: The subarray [5,4,-1,7,8] has the largest sum 23.

        Constraints:

            1 <= nums.length <= 105
            -104 <= nums[i] <= 104

        Follow up: If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.

        https://leetcode.com/problems/maximum-subarray/
        Extra Test Cases:
        [-2,1] Expected =  1 172 / 210 testcases passed
        [-1] Expected = -1 195 / 210 testcases passed
        [-2,-1] Expected = -1 196 / 210 testcases passed
        */
        public int MaxSubArray(int[] nums)
        {
            int maxSub = nums[0];
            int curSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (curSum < 0)
                {
                    curSum = 0;
                }
                curSum += nums[i];
                maxSub = Math.Max(maxSub, curSum);
            }
            return maxSub;
        }
        #endregion
        #region Jump Game
        /*
        You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.
        Return true if you can reach the last index, or false otherwise.

        Example 1:
        Input: nums = [2,3,1,1,4]
        Output: true
        Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.

        Example 2:
        Input: nums = [3,2,1,0,4]
        Output: false
        Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.

        Constraints:

            1 <= nums.length <= 104
            0 <= nums[i] <= 105

        https://leetcode.com/problems/jump-game/
        */
        public bool CanJump(int[] nums)
        {
            int goal = nums.Length - 1;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i + nums[i] >= goal)
                    goal = i;
            }

            return goal == 0;
        }
        #endregion
        #region Jump Game II
        /*
        You are given a 0-indexed array of integers nums of length n. You are initially positioned at nums[0].

        Each element nums[i] represents the maximum length of a forward jump from index i. In other words, if you are at nums[i], you can jump to any nums[i + j] where:

            0 <= j <= nums[i] and
            i + j < n

        Return the minimum number of jumps to reach nums[n - 1]. The test cases are generated such that you can reach nums[n - 1].

        Example 1:
        Input: nums = [2,3,1,1,4]
        Output: 2
        Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.

        Example 2:
        Input: nums = [2,3,0,1,4]
        Output: 2

        Constraints:

            1 <= nums.length <= 104
            0 <= nums[i] <= 1000
            It's guaranteed that you can reach nums[n - 1].

        Extra Test Cases: 
        [2,1,1,5,2] Expected: 3 
        [2,1] Expected: 1 
        [1] Expected: 0 
        [2,1,2,1,0] Expected: 2 
        [3,4,3,2,5,4,3] 
        [4,1,1,3,1,1,1] 
        [10,9,8,7,6,5,4,3,2,1,1,0]
        [1,2,3] Expected: 2 32 / 110 testcases passed
        [1,2,1,1,1] Expected: 3 18 / 110 testcases passed
        https://leetcode.com/problems/jump-game-ii/
        */
        public int Jump(int[] nums)
        {
            int result = 0;
            int left = 0;
            int right = 0;
            
            while (right < nums.Length - 1)
            {
                int maxJump = 0;
                for (int i = left; i <= right; i++)
                {
                    maxJump = Math.Max(maxJump, i + nums[i]);
                }
                left = right + 1;
                right = maxJump;
                result++;
            }
            
            return result;
        }
        #endregion
        #region Gas Station
        /*
        There are n gas stations along a circular route, where the amount of gas at the ith station is gas[i].
        You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from the ith station to its next (i + 1)th station. 
        You begin the journey with an empty tank at one of the gas stations. Given two integer arrays gas and cost, 
        return the starting gas station's index if you can travel around the circuit once in the clockwise direction,
         otherwise return -1. If there exists a solution, it is guaranteed to be unique

        Example 1:
        Input: gas = [1,2,3,4,5], cost = [3,4,5,1,2]
        Output: 3
        Explanation:
        Start at station 3 (index 3) and fill up with 4 unit of gas. Your tank = 0 + 4 = 4
        Travel to station 4. Your tank = 4 - 1 + 5 = 8
        Travel to station 0. Your tank = 8 - 2 + 1 = 7
        Travel to station 1. Your tank = 7 - 3 + 2 = 6
        Travel to station 2. Your tank = 6 - 4 + 3 = 5
        Travel to station 3. The cost is 5. Your gas is just enough to travel back to station 3.
        Therefore, return 3 as the starting index.

        Example 2:
        Input: gas = [2,3,4], cost = [3,4,3]
        Output: -1
        Explanation:
        You can't start at station 0 or 1, as there is not enough gas to travel to the next station.
        Let's start at station 2 and fill up with 4 unit of gas. Your tank = 0 + 4 = 4
        Travel to station 0. Your tank = 4 - 3 + 2 = 3
        Travel to station 1. Your tank = 3 - 3 + 3 = 3
        You cannot travel back to station 2, as it requires 4 unit of gas but you only have 3.
        Therefore, you can't travel around the circuit once no matter where you start.

        Constraints:
            n == gas.length == cost.length
            1 <= n <= 105
            0 <= gas[i], cost[i] <= 104

        Extra Test Cases:
        gas=[2,0,0]
        cost=[0,1,0]
        gas = [1,2,3,4,5] cost = [3,4,5,1,2] Expected: 3 20 / 39 testcases passed
        gas =  [5,1,2,3,4] cost = [4,4,1,5,1] Expected: 4 26 / 39 testcases passed
        gas =  [3,1,1] cost = [1,2,2] Expected: 0  36 / 39 testcases passed
        https://leetcode.com/problems/gas-station/
        */
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int total = 0;
            int loc = 0;

            if (cost.Sum() > gas.Sum())
                return -1;

            for (int i = 0; i < gas.Length; i++)
            {
                total += gas[i] - cost[i];

                if (0 > total)
                {
                    loc = i + 1;
                    total = 0;
                }
            }

            return loc;
        }
        #endregion
        #region Hand Of Straights
        /*
        Alice has some number of cards and she wants to rearrange the cards into groups so that each group is of size groupSize, and consists of groupSize consecutive cards.
        Given an integer array hand where hand[i] is the value written on the ith card and an integer groupSize, return true if she can rearrange the cards, or false otherwise.

        Example 1:
        Input: hand = [1,2,3,6,2,3,4,7,8], groupSize = 3
        Output: true
        Explanation: Alice's hand can be rearranged as [1,2,3],[2,3,4],[6,7,8]

        Example 2:
        Input: hand = [1,2,3,4,5], groupSize = 4
        Output: false
        Explanation: Alice's hand can not be rearranged into groups of 4.

        Constraints:
            1 <= hand.length <= 104
            0 <= hand[i] <= 109
            1 <= groupSize <= hand.length

        Note: This question is the same as 1296: https://leetcode.com/problems/divide-array-in-sets-of-k-consecutive-numbers/

        Hand Of Straights 
        [2,3,4,5,6,7,8,9] 8 
        [8,8,9,7,7,7,6,7,10,6] 2 
        [1,1,2,2,3,3] 2 
        [8,10,12] 3 = false
        [66,75,4,37,92,87,68,65,58,100,97,42,19,66,73,1,5,44,30,29,76,31,12,35,26,93,9,36,90,16,86,15,4,9,13,98,10,14,18,90,89,3,10,65,24,31,43,25,54,55,54,81,10,80,31,12,15,14,59,27,64,93,32,26,69,79,13,32,29,24,27,91,92,82,37,101,100,61,74,30,91,62,36,92,28,23,4,63,55,3,11,11,101,22,34,25,2,75,43,72] 2 
        hand = [8,10,12] groupSize = 3 Expected: false 46 / 92 testcases passed
        hand = [8,8,9,7,7,7,6,7,10,6] groupSize = 2 Expected: true 82 / 92 testcases passed
        hand = [8,4,7,6,0,6,2,5,5,1] groupSize = 3 Expected: false 87 / 92 testcases passed
        hand = [5,5,4,3,2,1]  groupSize = 2 Expected: false 87 / 92 testcases passed
        https://leetcode.com/problems/hand-of-straights/
        */
      public bool IsNStraightHand(int[] hand, int groupSize) {
            Dictionary<int, int> count = new();

            if (hand.Length % groupSize != 0)
                return false;

            foreach (int num in hand)
            {
                count.TryAdd(num, 0);
                count[num]++;
            }

            foreach (int num in hand)
            {
                int start = num;
                while (count.ContainsKey(start - 1) && count[start - 1] > 0)
                {
                    start--;
                }

                while (start <= num)
                {
                    while (count.ContainsKey(start) && count[start] > 0)
                    {
                        for (int i = start; i < start + groupSize; i++)
                        {
                            if (!count.ContainsKey(i) || count[i] == 0)
                                return false;

                            count[i]--;
                        }
                    }
                    start++;
                }
            }

            return true;
        }
        #endregion
        #region Merge Triplets to Form Target Triplet
        /*
        A triplet is an array of three integers. You are given a 2D integer array triplets, where triplets[i] = [ai, bi, ci] describes the ith triplet. 
        You are also given an integer array target = [x, y, z] that describes the triplet you want to obtain.
        To obtain target, you may apply the following operation on triplets any number of times (possibly zero):
            Choose two indices (0-indexed) i and j (i != j) and update triplets[j] to become [max(ai, aj), max(bi, bj), max(ci, cj)].
            For example, if triplets[i] = [2, 5, 3] and triplets[j] = [1, 7, 5], triplets[j] will be updated to [max(2, 1), max(5, 7), max(3, 5)] = [2, 7, 5].
        Return true if it is possible to obtain the target triplet [x, y, z] as an element of triplets, or false otherwise.

        Example 1:
        Input: triplets = [[2,5,3],[1,8,4],[1,7,5]], target = [2,7,5]
        Output: true
        Explanation: Perform the following operations:
        - Choose the first and last triplets [[2,5,3],[1,8,4],[1,7,5]]. Update the last triplet to be [max(2,1), max(5,7), max(3,5)] = [2,7,5]. triplets = [[2,5,3],[1,8,4],[2,7,5]]
        The target triplet [2,7,5] is now an element of triplets.

        Example 2:
        Input: triplets = [[3,4,5],[4,5,6]], target = [3,2,5]
        Output: false
        Explanation: It is impossible to have [3,2,5] as an element because there is no 2 in any of the triplets.

        Example 3:
        Input: triplets = [[2,5,3],[2,3,4],[1,2,5],[5,2,3]], target = [5,5,5]
        Output: true
        Explanation: Perform the following operations:
        - Choose the first and third triplets [[2,5,3],[2,3,4],[1,2,5],[5,2,3]]. Update the third triplet to be [max(2,1), max(5,2), max(3,5)] = [2,5,5]. triplets = [[2,5,3],[2,3,4],[2,5,5],[5,2,3]].
        - Choose the third and fourth triplets [[2,5,3],[2,3,4],[2,5,5],[5,2,3]]. Update the fourth triplet to be [max(2,5), max(5,2), max(5,3)] = [5,5,5]. triplets = [[2,5,3],[2,3,4],[2,5,5],[5,5,5]].
        The target triplet [5,5,5] is now an element of triplets.

        Constraints:
            1 <= triplets.length <= 105
            triplets[i].length == target.length == 3
            1 <= ai, bi, ci, x, y, z <= 1000

            Extra Test Cases: 
            triplets = [[3,5,1],[10,5,7]] 45 / 62 testcases passed
            target =   [3,5,7]
            triplets = [[1,3,1]] 30 / 62 testcases passed
            target =   [1,3,1]
        */
        //T: O(N)
        public bool MergeTriplets(int[][] triplets, int[] target)
        {
            var hashSet = new HashSet<(int, int)>();

            foreach (var t in triplets)
            {
                if (t[0] > target[0] || t[1] > target[1] || t[2] > target[2])
                    continue;

                for (var i = 0; i < t.Length; i++)
                {
                    if (t[i] == target[i])
                        hashSet.Add((i, t[i]));
                }
            }

            return hashSet.Count == 3;
        }
        #endregion
        #region Partition Labels
        /*
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Note that the partition is done so that after concatenating all the parts in order, the resultant string should be s.
        Return a list of integers representing the size of these parts.

        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.

        Example 2:
        Input: s = "eccbbbbdec"
        Output: [10]

        Constraints:
            1 <= s.length <= 500
            s consists of lowercase English letters.
        
        Extra Test Cases:
        "qiejxqfnqceocmy" [13,1,1] 
        "abaccbdeffed" [6,6]
        https://leetcode.com/problems/partition-labels/description/
        */
        public IList<int> PartitionLabels(string s)
        {

            var chars = new int[26];
            for (var ch = 0; ch < s.Length; ch++)
            {
                chars[s[ch] - 'a'] = ch;
            }

            var result = new List<int>();
            var end = 0;
            var size = 0;
            for (var i = 0; i < s.Length; i++)
            {
                end = Math.Max(chars[s[i] - 'a'], end);
                size++;
                if (i == end)
                {
                    result.Add(size);
                    size = 0;
                }

            }

            return result;
        }

        #endregion
        #region Valid Parenthesis String
        /*
        Given a string s containing only three types of characters: '(', ')' and '*', return true if s is valid.
        The following rules define a valid string:

            Any left parenthesis '(' must have a corresponding right parenthesis ')'.
            Any right parenthesis ')' must have a corresponding left parenthesis '('.
            Left parenthesis '(' must go before the corresponding right parenthesis ')'.
            '*' could be treated as a single right parenthesis ')' or a single left parenthesis '(' or an empty string "".

        Example 1:
        Input: s = "()"
        Output: true

        Example 2:
        Input: s = "(*)"
        Output: true

        Example 3:
        Input: s = "(*))"
        Output: true

        Constraints:
            1 <= s.length <= 100
            s[i] is '(', ')' or '*'.

        "((**(((((" false 
        "()()" true
        "((" false 
        "(((((((((((((" false 
        "((((()(()()()()((((()()((())))))(())()())(((())())())))))))(((((()))))()))(()((()()))()()" true 62 / 83 testcases passed 
        "((((((()((((((*(((()())()()()(((()())))))))))(())(()))())((()()(((()((()(())(()**)()(())" false 61 / 83 testcases passed
       "(((((*(()((((*((**(((()()*)()()()*((((**)())*)*)))))))(())(()))())((*()()(((()((()*(())*(()**)()(())" false 55 / 83 testcases passed
        "" "((()*()((()" 
        "(()())()()*((()())()((()*()" 
        ")(()(*()())))())()))()()((()()))(*())*(" 
        ")))())))))))))(((()(((())(*)(((()))()((((()(((" 
        "()))))*)(()()*)))())()())()())*())))(*())))())))()(((" 
        "()())(())))()())())()(()))*)())(()()((())()((())))()*)((()))((()((())()"
        */
        public bool CheckValidString(string s)
        {
            int leftMin = 0;
            int leftMax = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    leftMin++;
                    leftMax++;
                }
                else if (s[i] == ')')
                {
                    leftMin--;
                    leftMax--;
                }
                else if (s[i] == '*')
                {
                    leftMin--;
                    leftMax++;
                }

                if (leftMin < 0)
                    leftMin = 0;

                if (leftMax < 0)
                    return false;

            }

            return leftMin == 0;
        }
        #endregion
    }

}