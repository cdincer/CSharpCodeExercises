using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neetcode150
{
    public class BacktrackingNeet
    {
        #region Subsets
        /*
        Given an integer array nums of unique elements, return all possible subsets
        (the power set).

        The solution set must not contain duplicate subsets. Return the solution in any order.

        Example 1:
        Input: nums = [1,2,3]
        Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

        Example 2:
        Input: nums = [0]
        Output: [[],[0]]

        Constraints:

            1 <= nums.length <= 10
            -10 <= nums[i] <= 10
            All the numbers of nums are unique.
            
        https://leetcode.com/problems/subsets/
        */
        List<IList<int>> keeper = new();
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<int> keep = new();
            repeater(0, nums, keep);
            return keeper;
        }

        public List<int> repeater(int index, int[] nums, List<int> keep)
        {
            for (int i = index; i < nums.Length; i++)
            {
                keep.Add(nums[i]);
                repeater(i + 1, nums, keep);
                keep.Remove(nums[i]);
            }

            keeper.Add(new List<int>(keep));

            return keep;
        }
        ///////////////////////
        private List<int> subset = new List<int>();
        private List<IList<int>> result = new List<IList<int>>();
        private void backtrackNeet(int i, int[] nums)
        {
            if (i >= nums.Length)
            {
                result.Add(new List<int>(subset));
                return;
            }
            subset.Add(nums[i]);
            backtrackNeet(i + 1, nums);
            subset.Remove(nums[i]);
            backtrackNeet(i + 1, nums);

        }
        public IList<IList<int>> SubsetsNeet(int[] nums)
        {
            backtrackNeet(0, nums);
            return result;
        }



        #endregion
        #region Combination Sum
        /*
        Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.
        The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the
        frequency of at least one of the chosen numbers is different.

        The test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.

        Example 1:
        Input: candidates = [2,3,6,7], target = 7
        Output: [[2,2,3],[7]]
        Explanation:
        2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
        7 is a candidate, and 7 = 7.
        These are the only two combinations.

        Example 2:
        Input: candidates = [2,3,5], target = 8
        Output: [[2,2,2,2],[2,3,3],[3,5]]

        Example 3:
        Input: candidates = [2], target = 1
        Output: []

        Constraints:

            1 <= candidates.length <= 30
            2 <= candidates[i] <= 40
            All elements of candidates are distinct.
            1 <= target <= 40

        https://leetcode.com/problems/combination-sum/
        */
        IList<IList<int>> result2 = new List<IList<int>>();
        public void backtrack(int index, List<int> path, int total, int[] candidates, int target)
        {
            if (total == target)
            {
                result2.Add(path.ToList());
                return;
            }

            if (total > target || index >= candidates.Length) return;

            path.Add(candidates[index]);
            backtrack(index,
                      path,
                      total + candidates[index],
                      candidates,
                      target);

            path.Remove(path.Last());

            backtrack(index + 1,
                      path,
                      total,
                      candidates,
                      target);

        }
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            backtrack(0, new List<int>(), 0, candidates, target);
            return result2;
        }
        #endregion
        #region Permutations
        /*
        Given an array nums of distinct integers, return all the possible permutations. 
        You can return the answer in any order.

        Example 1:
        Input: nums = [1,2,3]
        Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

        Example 2:
        Input: nums = [0,1]
        Output: [[0,1],[1,0]]

        Example 3:
        Input: nums = [1]
        Output: [[1]]

        Constraints:

            1 <= nums.length <= 6
            -10 <= nums[i] <= 10
            All the integers of nums are unique.


        https://leetcode.com/problems/permutations/
        */
        //First solution fits the backtracking template above.
        public List<IList<int>> keeper2 = new();
        public IList<IList<int>> Permute(int[] nums)
        {
            List<int> keep = new();
            permutor(keep, nums);
            return keeper2;
        }
        public void permutor(List<int> keep, int[] nums)
        {
            if (keep.Count == nums.Length)
            {
                keeper2.Add(new List<int>(keep));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (keep.Contains(nums[i])) continue;
                keep.Add(nums[i]);
                permutor(keep, nums);
                keep.Remove(nums[i]);
            }
        }

        public IList<IList<int>> PermuteNeet(int[] nums)
        {
            var result = new List<IList<int>>();
            PermuteRecurse(result, nums, 0);
            return result;
        }

        private void PermuteRecurse(List<IList<int>> res, int[] arr, int start)
        {
            if (start == arr.Length)
            {
                var list = arr.Select(t => (t)).ToList();
                res.Add(list);
                return;
            }

            for (var i = start; i < arr.Length; i++)
            {
                (arr[start], arr[i]) = (arr[i], arr[start]);
                PermuteRecurse(res, arr, start + 1);
                (arr[start], arr[i]) = (arr[i], arr[start]);
            }
        }
        #endregion

    }
}