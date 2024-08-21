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
        #region Top K Frequent Elements
        /*
        Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.

        Example 1:
        Input: nums = [1,1,1,2,2,3], k = 2
        Output: [1,2]

        Example 2:
        Input: nums = [1], k = 1
        Output: [1]

        Constraints:
        1 <= nums.length <= 105
        -104 <= nums[i] <= 104
        k is in the range [1, the number of unique elements in the array].
        It is guaranteed that the answer is unique.

        Follow up: Your algorithm's time complexity must be better than O(n log n), where n is the array's size.

        https://leetcode.com/problems/top-k-frequent-elements/
        */
        //Neetcode Version because of priority queue. Good to have for reference.
        public int[] TopKFrequent(int[] nums, int k)
        {
            int[] arr = new int[k];
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }

            var pq = new PriorityQueue<int, int>();
            foreach (var key in dict.Keys)
            {
                pq.Enqueue(key, dict[key]);
                if (pq.Count > k) pq.Dequeue();
            }
            int topfreq = k;
            while (pq.Count > 0)
            {
                arr[--topfreq] = pq.Dequeue();
            }
            return arr;
        }
        #endregion
        #region String Encode And Decode
        /* Leetcode Premium Question
        Design an algorithm to encode a list of strings to a single string.
        The encoded string is then decoded back to the original list of strings.
        Please implement encode and decode

        Example 1:
        Input: ["neet","code","love","you"]
        Output:["neet","code","love","you"]

        Example 2:
        Input: ["we","say",":","yes"]
        Output: ["we","say",":","yes"]

        Constraints:

            0 <= strs.length < 100
            0 <= strs[i].length < 200
            strs[i] contains only UTF-8 characters.

        Extra Test Cases:
        Input:[] Expected output:[]
        Input:[""] Expected output:[""]
        https://neetcode.io/problems/string-encode-and-decode

        Hint:Just translate original string to a list and make that list into a string again.
        */
        #endregion
        #region Product of Array Except Self
        /*
        Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
        The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
        You must write an algorithm that runs in O(n) time and without using the division operation.

        Example 1:
        Input: nums = [1,2,3,4]
        Output: [24,12,8,6]

        Example 2:
        Input: nums = [-1,1,0,-3,3]
        Output: [0,0,9,0,0]

        

        Constraints:
            2 <= nums.length <= 105
            -30 <= nums[i] <= 30
            The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

        Follow up: Can you solve the problem in O(1) extra space complexity? (The output array does not count as extra space for space complexity analysis.)
        https://leetcode.com/problems/product-of-array-except-self/description/
        */
        //Neet code version for O(n) runtime and no division rule.
        public int[] ProductExceptSelf(int[] nums)
        {
            int prefix = 1, postfix = 1;
            int[] res = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                res[i] = prefix;
                prefix *= nums[i];
            }

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                res[i] *= postfix;
                postfix *= nums[i];
            }
            return res;
        }

        #endregion
        #region Valid Sudoku
        /*
        Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:

            Each row must contain the digits 1-9 without repetition.
            Each column must contain the digits 1-9 without repetition.
            Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.

        Note:
        A Sudoku board (partially filled) could be valid but is not necessarily solvable.
        Only the filled cells need to be validated according to the mentioned rules.

        Example 1:
        Input: board = 
        [["5","3",".",".","7",".",".",".","."]
        ,["6",".",".","1","9","5",".",".","."]
        ,[".","9","8",".",".",".",".","6","."]
        ,["8",".",".",".","6",".",".",".","3"]
        ,["4",".",".","8",".","3",".",".","1"]
        ,["7",".",".",".","2",".",".",".","6"]
        ,[".","6",".",".",".",".","2","8","."]
        ,[".",".",".","4","1","9",".",".","5"]
        ,[".",".",".",".","8",".",".","7","9"]]
        Output: true

        Example 2:
        Input: board = 
        [["8","3",".",".","7",".",".",".","."]
        ,["6",".",".","1","9","5",".",".","."]
        ,[".","9","8",".",".",".",".","6","."]
        ,["8",".",".",".","6",".",".",".","3"]
        ,["4",".",".","8",".","3",".",".","1"]
        ,["7",".",".",".","2",".",".",".","6"]
        ,[".","6",".",".",".",".","2","8","."]
        ,[".",".",".","4","1","9",".",".","5"]
        ,[".",".",".",".","8",".",".","7","9"]]

        Output: false
        Explanation: Same as Example 1, except with the 5 in the top left corner being modified to 8. Since there are two 8's in the top left 3x3 sub-box, it is invalid.

        Constraints:

            board.length == 9
            board[i].length == 9
            board[i][j] is a digit 1-9 or '.'.

        https://leetcode.com/problems/valid-sudoku/
        */
        //Neetcode version.
        public bool IsValidSudoku(char[][] board)
        {
            var rows = new Dictionary<int, HashSet<char>>();
            var cols = new Dictionary<int, HashSet<char>>();
            var squares = new Dictionary<(int, int), HashSet<char>>();

            for (var r = 0; r < 9; r++)
            {
                rows[r] = new HashSet<char>();
                for (var c = 0; c < 9; c++)
                {
                    if (!cols.ContainsKey(c)) cols[c] = new HashSet<char>();
                    if (!squares.ContainsKey((r / 3, c / 3)))
                        squares[(r / 3, c / 3)] = new HashSet<char>();

                    if (board[r][c] == '.') continue;


                    if (rows[r].Contains(board[r][c]) ||
                      cols[c].Contains(board[r][c]) ||
                      squares[(r / 3, c / 3)].Contains(board[r][c]))
                        return false;

                    rows[r].Add(board[r][c]);
                    cols[c].Add(board[r][c]);
                    squares[(r / 3, c / 3)].Add(board[r][c]);
                }
            }

            return true;
        }

        #endregion
        #region Longest Consecutive Sequence
        /*
        Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
        You must write an algorithm that runs in O(n) time.

        Example 1:
        Input: nums = [100,4,200,1,3,2]
        Output: 4
        Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.

        Example 2:
        Input: nums = [0,3,7,2,5,8,4,6,0,1]
        Output: 9

        Constraints:
        0 <= nums.length <= 105
        -109 <= nums[i] <= 109


        https://leetcode.com/problems/longest-consecutive-sequence/
        Extra Test Case:
        [0]
        [0,0]
        [1,2,0,1]
        []
        */

        //Best time 152 ms
        public int LongestConsecutive(int[] nums)
        {
            HashSet<int> keeper = new HashSet<int>();
            //Array.Sort(nums);

            if (nums.Length < 2)
                return nums.Length;

            for (int i = 0; i < nums.Length; i++)
            {
                keeper.Add(nums[i]);
            }

            int longestChain = 0;
            int currentChain = 1;
            foreach (var element in keeper)
            {
                int itemToLookFor = element - 1;
                if (keeper.Contains(itemToLookFor))
                {
                    currentChain++;
                }
                else
                {
                    longestChain = Math.Max(longestChain, currentChain);
                    currentChain = 1;
                }
            }
            longestChain = Math.Max(longestChain, currentChain);

            return longestChain;
        }
        //Best time 139 ms
        public int LongestConsecutiveNeet(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;

            var set = new HashSet<int>(nums);
            var longest = 0;
            foreach (var n in set)
            {
                if (!set.Contains(n - 1))
                {
                    var length = 0;
                    while (set.Contains(n + length))
                    {
                        length++;
                        longest = Math.Max(longest, length);
                    }
                }
            }

            return longest;
        }
        #endregion
    }
}