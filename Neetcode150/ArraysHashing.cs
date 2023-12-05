using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Neetcode150
{
    public class ArraysHashing
    {
        #region Contains Duplicate
        /*
        Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
        
        Example 1:
        Input: nums = [1,2,3,1]
        Output: true

        Example 2:
        Input: nums = [1,2,3,4]
        Output: false

        Example 3:
        Input: nums = [1,1,1,3,3,4,3,2,4,2]
        Output: true

        Constraints:
        1 <= nums.length <= 105
        -109 <= nums[i] <= 109

        https://leetcode.com/problems/contains-duplicate/
        */
        public bool ContainsDuplicate(int[] nums)
        {
            Dictionary<int, int> mtracker = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!mtracker.ContainsKey(nums[i]))
                {
                    mtracker.Add(nums[i], 1);
                }
                else if (mtracker[nums[i]] == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsDuplicateNeet(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();

            foreach (int x in nums)
            {
                if (set.Contains(x)) return true;
                set.Add(x);
            }
            return false;
        }
        #endregion
        #region Valid Anagram
        /*
        Given two strings s and t, return true if t is an anagram of s, and false otherwise.
        An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

        Example 1:
        Input: s = "anagram", t = "nagaram"
        Output: true

        Example 2:
        Input: s = "rat", t = "car"
        Output: false

        Constraints:
            1 <= s.length, t.length <= 5 * 104
            s and t consist of lowercase English letters.

        Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?
        https://leetcode.com/problems/valid-anagram/
        */
        public bool IsAnagram(string s, string t)
        {
            Dictionary<char, int> sDict = new();
            Dictionary<char, int> tDict = new();

            if (s.Length != t.Length)
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (!sDict.ContainsKey(s[i]))
                {
                    sDict.Add(s[i], 1);
                }
                else
                {
                    sDict[s[i]]++;
                }

                if (!tDict.ContainsKey(t[i]))
                {
                    tDict.Add(t[i], 1);
                }
                else
                {
                    tDict[t[i]]++;
                }
            }

            foreach (KeyValuePair<char, int> letter in sDict)
            {

                if (!tDict.ContainsKey(letter.Key))
                {
                    return false;
                }

                if (letter.Value != tDict[letter.Key])
                    return false;
            }
            return true;
        }

        public bool IsAnagramNeet(string s, string t)
        {
            if (s.Length != t.Length) return false;
            if (s == t) return true;

            Dictionary<char, int> sCounts = new Dictionary<char, int>();
            Dictionary<char, int> tCounts = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                sCounts[s[i]] = 1 + (sCounts.ContainsKey(s[i]) ? sCounts[s[i]] : 0);
                tCounts[t[i]] = 1 + (tCounts.ContainsKey(t[i]) ? tCounts[t[i]] : 0);
            }

            foreach (char c in sCounts.Keys)
            {
                int tCount = tCounts.ContainsKey(c) ? tCounts[c] : 0;
                if (sCounts[c] != tCount) return false;
            }
            return true;
        }
        #endregion
        #region Two Sum
        /*
        Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        You may assume that each input would have exactly one solution, and you may not use the same element twice.
        You can return the answer in any order.

        Example 1:
        Input: nums = [2,7,11,15], target = 9
        Output: [0,1]
        Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

        Example 2:
        Input: nums = [3,2,4], target = 6
        Output: [1,2]

        Example 3:
        Input: nums = [3,3], target = 6
        Output: [0,1]

        Constraints:
        2 <= nums.length <= 104
        -109 <= nums[i] <= 109
        -109 <= target <= 109
        Only one valid answer exists.

        Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
        */
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> tracker = new();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!tracker.ContainsKey(nums[i]))
                    tracker.Add(nums[i], i);

                if (tracker.ContainsKey(target - nums[i]) && tracker[target - nums[i]] != i)
                    return new int[] { tracker[target - nums[i]], i };
            }

            return new int[0];
        }
        public int[] TwoSumNeet(int[] nums, int target)
        {
            Dictionary<int, int> indices = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];
                if (indices.ContainsKey(diff))
                {
                    return new int[] { indices[diff], i };
                }
                indices[nums[i]] = i;
            }
            return null;
        }
        #endregion
        #region Group Anagrams
        /*
        Given an array of strings strs, group the anagrams together. You can return the answer in any order.
        An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

        Example 1:

        Input: strs = ["eat","tea","tan","ate","nat","bat"]
        Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

        Example 2:

        Input: strs = [""]
        Output: [[""]]

        Example 3:

        Input: strs = ["a"]
        Output: [["a"]]

        

        Constraints:

            1 <= strs.length <= 104
            0 <= strs[i].length <= 100
            strs[i] consists of lowercase English letters.


        https://leetcode.com/problems/group-anagrams/
        */
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> sorted = new();
            for (int i = 0; i < strs.Length; i++)
            {

                char[] CurrentArray = strs[i].ToCharArray();
                Array.Sort(CurrentArray);
                if (!sorted.ContainsKey(new string(CurrentArray)))
                {
                    sorted.Add(new string(CurrentArray), new List<string> { strs[i] });
                }
                else
                {
                    sorted[new string(CurrentArray)].Add(strs[i]);
                }

            }
            List<IList<string>> toR = new();
            foreach (KeyValuePair<string, List<string>> element in sorted)
            {
                toR.Add(element.Value);
            }
            return toR;
        }
        //
        public IList<IList<string>> GroupAnagramsNeet(string[] strs)
        {
            var groups = new Dictionary<string, IList<string>>();

            foreach (string s in strs)
            {
                char[] hash = new char[26];
                foreach (char c in s)
                {
                    hash[c - 'a']++;
                }

                string key = new string(hash);
                if (!groups.ContainsKey(key))
                {
                    groups[key] = new List<string>();
                }
                groups[key].Add(s);
            }
            return groups.Values.ToImmutableList();
        }
        #endregion
    }
}