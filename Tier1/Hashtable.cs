using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tier1
{   //https://leetcode.com/explore/learn/card/hash-table/
    public class Hashtable
    {
        #region Design a Hashtable
        #region Design a Hashset
        /*
        https://leetcode.com/problems/design-hashset/
        */
        public class MyHashSet
        {
            int size = (int)Math.Pow(10, 6) + 1;
            bool[] flag;
            public MyHashSet()
            {
                flag = new bool[size];
            }

            public void Add(int key)
            {
                flag[key] = true;
            }

            public void Remove(int key)
            {
                flag[key] = false;
            }

            public bool Contains(int key)
            {
                return flag[key];
            }
        }
        #endregion
        #region Design a Hashtable
        /*
        Design a HashMap without using any built-in hash table libraries.

        Implement the MyHashMap class:

            MyHashMap() initializes the object with an empty map.
            void put(int key, int value) inserts a (key, value) pair into the HashMap. If the key already exists in the map, update the corresponding value.
            int get(int key) returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key.
            void remove(key) removes the key and its corresponding value if the map contains the mapping for the key.

        

        Example 1:

        Input
        ["MyHashMap", "put", "put", "get", "get", "put", "get", "remove", "get"]
        [[], [1, 1], [2, 2], [1], [3], [2, 1], [2], [2], [2]]
        Output
        [null, null, null, 1, -1, null, 1, null, -1]

        Explanation
        MyHashMap myHashMap = new MyHashMap();
        myHashMap.put(1, 1); // The map is now [[1,1]]
        myHashMap.put(2, 2); // The map is now [[1,1], [2,2]]
        myHashMap.get(1);    // return 1, The map is now [[1,1], [2,2]]
        myHashMap.get(3);    // return -1 (i.e., not found), The map is now [[1,1], [2,2]]
        myHashMap.put(2, 1); // The map is now [[1,1], [2,1]] (i.e., update the existing value)
        myHashMap.get(2);    // return 1, The map is now [[1,1], [2,1]]
        myHashMap.remove(2); // remove the mapping for 2, The map is now [[1,1]]
        myHashMap.get(2);    // return -1 (i.e., not found), The map is now [[1,1]]

        

        Constraints:

            0 <= key, value <= 106
            At most 104 calls will be made to put, get, and remove.


        https://leetcode.com/problems/design-hashmap/description/
        */

        public class MyHashMapEasy
        {
            int[] data;
            public MyHashMapEasy()
            {
                data = new int[1000001];
                Array.Fill(data, -1);
            }
            public void Put(int key, int val)
            {
                data[key] = val;
            }
            public int Get(int key)
            {
                return data[key];
            }
            public void Remove(int key)
            {
                data[key] = -1;
            }
        }
        //https://leetcode.com/problems/design-hashmap/solutions/1097755/js-python-java-c-updated-hash-array-solutions-w-explanation/?orderBy=most_votes
        //Description
        public class ListNode
        {
            public int key, val;
            public ListNode next;
            public ListNode(int key, int val, ListNode next)
            {
                this.key = key;
                this.val = val;
                this.next = next;
            }
        }
        public class MyHashMap
        {
            int size = 19997;
            int mult = 12582917;
            ListNode[] data;
            public MyHashMap()
            {
                this.data = new ListNode[size];
            }
            private int hash(int key)
            {
                return (int)((long)key * mult % size);
            }
            public void put(int key, int val)
            {
                remove(key);
                int h = hash(key);
                ListNode node = new ListNode(key, val, data[h]);
                data[h] = node;
            }
            public int get(int key)
            {
                int h = hash(key);
                ListNode node = data[h];
                for (; node != null; node = node.next)
                    if (node.key == key) return node.val;
                return -1;
            }
            public void remove(int key)
            {
                int h = hash(key);
                ListNode node = data[h];
                if (node == null) return;
                if (node.key == key) data[h] = node.next;
                else for (; node.next != null; node = node.next)
                        if (node.next.key == key)
                        {
                            node.next = node.next.next;
                            return;
                        }
            }
        }
        #endregion
        #region Practical Application - Hash Set
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
        //Runtime: 191 ms Beats 92.95 % || Memory Usage: 51.1 MB Beats 99.04 %
        public bool ContainsDuplicate(int[] nums)
        {

            HashSet<int> mHash = new HashSet<int>();

            foreach (int number in nums)
            {
                if (mHash.Contains(number))
                {
                    return true;
                }
                else
                {
                    mHash.Add(number);
                }
            }
            mHash = null;
            GC.Collect();
            return false;
        }
        #endregion
        #region Single Number
        /*
        Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.

        You must implement a solution with a linear runtime complexity and use only constant extra space.

        

        Example 1:

        Input: nums = [2,2,1]
        Output: 1

        Example 2:

        Input: nums = [4,1,2,1,2]
        Output: 4

        Example 3:

        Input: nums = [1]
        Output: 1

        

        Constraints:

            1 <= nums.length <= 3 * 104
            -3 * 104 <= nums[i] <= 3 * 104
            Each element in the array appears twice except for one element which appears only once.

        Before GC.Collect();
        Runtime: 101 ms
        Memory Usage: 45.4 MB
        After GC.Collect();
        Runtime:104 ms Beats 71.46%
        Memory:39.7 MB Beats 99.71%
        https://leetcode.com/problems/single-number/description/
        */
        public int SingleNumber(int[] nums)
        {
            HashSet<int> counter = new HashSet<int>();
            foreach (int number in nums)
            {
                if (!counter.Contains(number))
                {
                    counter.Add(number);
                }
                else
                {
                    counter.Remove(number);
                }
            }
            return counter.First();
        }
        #endregion
        #region Intersection of Two Arrays
        /*
        Given two integer arrays nums1 and nums2, return an array of their intersection. Each element in the result must be unique and you may return the result in any order.

        Example 1:

        Input: nums1 = [1,2,2,1], nums2 = [2,2]
        Output: [2]

        Example 2:

        Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        Output: [9,4]
        Explanation: [4,9] is also accepted.

        

        Constraints:

            1 <= nums1.length, nums2.length <= 1000
            0 <= nums1[i], nums2[i] <= 1000

        https://leetcode.com/problems/intersection-of-two-arrays/description/
        */
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> dict = new();
            HashSet<int> resultDict = new();

            foreach (var num in nums1)
            {
                dict.Add(num);
            }

            foreach (var num in nums2)
            {
                if (dict.Contains(num))
                {
                    resultDict.Add(num);
                }
            }

            return resultDict.ToArray();
        }
        #endregion
        #region Happy Number
        /*
        Write an algorithm to determine if a number n is happy.

        A happy number is a number defined by the following process:

            Starting with any positive integer, replace the number by the sum of the squares of its digits.
            Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
            Those numbers for which this process ends in 1 are happy.

        Return true if n is a happy number, and false if not.
        Example 1:

        Input: n = 19
        Output: true
        Explanation:
        12 + 92 = 82
        82 + 22 = 68
        62 + 82 = 100
        12 + 02 + 02 = 1

        Example 2:

        Input: n = 2
        Output: false

        */
        public bool IsHappy(int n)
        {
            HashSet<int> items = new HashSet<int>();
            while (n > 0)
            {
                int tmp = 0;
                while (n > 0)
                {
                    int i = n % 10;
                    tmp += i * i;
                    n = n / 10;
                }
                if (tmp == 1)
                {
                    return true;
                }
                if (!items.Contains(tmp))
                {
                    items.Add(tmp);
                }
                else
                {
                    return false;
                }
                n = tmp;
            }
            return false;
        }
        #endregion
        #endregion
        #region Practical Application - Hash Map
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
        Test Case:
        nums =
        [1,1,1,1,1,4,1,1,1,1,1,7,1,1,1,1,1]
        target =
        11
        https://leetcode.com/problems/two-sum/description/
        */
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> seen = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                //if we've seen the matching number to our number
                if (seen.ContainsKey(target - nums[i]))
                {
                    //then return the matching numbers index and our own
                    return new int[] { seen[target - nums[i]], i };
                }
                //otherwise add our value to the dictionary and continue
                //if we've already seen this value we can ignore it since both indexes would be valid.
                if (!seen.ContainsKey(nums[i]))
                {
                    seen.Add(nums[i], i);
                }

            }
            //Since they state there is always a solution to the problem we should never actually hit this.
            return null;
        }
        #endregion
        #region Isomorphic Strings
        /*
        Given two strings s and t, determine if they are isomorphic.
        Two strings s and t are isomorphic if the characters in s can be replaced to get t.
        All occurrences of a character must be replaced with another character while preserving the order of characters. 
        No two characters may map to the same character, but a character may map to itself.

        Example 1:

        Input: s = "egg", t = "add"
        Output: true

        Example 2:

        Input: s = "foo", t = "bar"
        Output: false

        Example 3:

        Input: s = "paper", t = "title"
        Output: true

        Constraints:

            1 <= s.length <= 5 * 104
            t.length == s.length
            s and t consist of any valid ascii character.

        https://leetcode.com/problems/isomorphic-strings/description/
        My Solution below, I have no idea how I came up with this.
        Test Case:
        "badc"
        "baba"
        Output:false
        */
        public bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> items = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (items.ContainsKey(s[i]))
                {
                    KeyValuePair<char, char> aaa = new KeyValuePair<char, char>(s[i], t[i]);

                    if (!items.Contains(aaa))
                    {
                        return false;
                    }

                }
                else if (!items.ContainsKey(s[i]))
                {
                    items.Add(s[i], t[i]);
                }

            }
            items.Clear();
            for (int i = 0; i < t.Length; i++)
            {
                if (items.ContainsKey(t[i]))
                {
                    KeyValuePair<char, char> aaa = new KeyValuePair<char, char>(t[i], s[i]);

                    if (!items.Contains(aaa))
                    {
                        return false;
                    }

                }
                else if (!items.ContainsKey(t[i]))
                {
                    items.Add(t[i], s[i]);
                }

            }
            return true;
        }
        #endregion
        #region Minimum Index Sum of Two Lists
        /*
        Given two arrays of strings list1 and list2, find the common strings with the least index sum.
        A common string is a string that appeared in both list1 and list2.
        A common string with the least index sum is a common string such that if it appeared at list1[i] and list2[j] then i + j should be the minimum value among all the other common strings.
        Return all the common strings with the least index sum. Return the answer in any order.

        Example 1:

        Input: list1 = ["Shogun","Tapioca Express","Burger King","KFC"], list2 = ["Piatti","The Grill at Torrey Pines","Hungry Hunter Steakhouse","Shogun"]
        Output: ["Shogun"]
        Explanation: The only common string is "Shogun".

        Example 2:

        Input: list1 = ["Shogun","Tapioca Express","Burger King","KFC"], list2 = ["KFC","Shogun","Burger King"]
        Output: ["Shogun"]
        Explanation: The common string with the least index sum is "Shogun" with index sum = (0 + 1) = 1.

        Example 3:

        Input: list1 = ["happy","sad","good"], list2 = ["sad","happy","good"]
        Output: ["sad","happy"]
        Explanation: There are three common strings:
        "happy" with index sum = (0 + 1) = 1.
        "sad" with index sum = (1 + 0) = 1.
        "good" with index sum = (2 + 2) = 4.
        The strings with the least index sum are "sad" and "happy".


        Constraints:

        1 <= list1.length, list2.length <= 1000
        1 <= list1[i].length, list2[i].length <= 30
        list1[i] and list2[i] consist of spaces ' ' and English letters.
        All the strings of list1 are unique.
        All the strings of list2 are unique.
        There is at least a common string between list1 and list2.
        Leetcode Testcase:
        ["happy","sad","good"]
        ["sad","happy","good"]
        ["Shogun","Piatti","Tapioca Express","Burger King","KFC"]
        ["Piatti","The Grill at Torrey Pines","Hungry Hunter Steakhouse","Shogun"]
        https://leetcode.com/problems/minimum-index-sum-of-two-lists/description/
        */
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            int minimumSum = list1.Length + list2.Length;
            Dictionary<string, int> dict = new Dictionary<string, int>();
            List<string> answer = new List<string>();

            for (int i = 0; i < list2.Length; i++)
            {
                dict.Add(list2[i], i);
            }

            for (int i = 0; i < list1.Length; i++)
            {
                if (dict.ContainsKey(list1[i]))
                {
                    if (dict[list1[i]] + i < minimumSum)
                    {
                        answer.Clear();
                        minimumSum = dict[list1[i]] + i;
                        answer.Add(list1[i]);
                    }
                    else if (dict[list1[i]] + i == minimumSum)
                    {
                        answer.Add(list1[i]);
                    }
                }
            }
            return answer.ToArray();
        }
        #endregion
        #region First Unique Character in a String
        /*
        Given a string s, find the first non-repeating character in it and return its index. If it does not exist, return -1.

        Example 1:
        Input: s = "leetcode"
        Output: 0

        Example 2:
        Input: s = "loveleetcode"
        Output: 2

        Example 3:
        Input: s = "aabb"
        Output: -1

        Constraints:

            1 <= s.length <= 105
            s consists of only lowercase English letters.

        https://leetcode.com/problems/first-unique-character-in-a-string/description/
        Testcase:
        "aadadaad"
        */
        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> counter = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!counter.ContainsKey(s[i]))
                {
                    counter.Add(s[i], 1);
                }
                else
                {
                    int itemRecurrence = 0;
                    counter.TryGetValue(s[i], out itemRecurrence);
                    counter.Remove(s[i]);
                    counter.Add(s[i], itemRecurrence + 1);
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                int itemRecurrence = 0;
                counter.TryGetValue(s[i], out itemRecurrence);
                if (itemRecurrence == 1)
                    return i;

            }
            return -1;
        }
        #endregion
        #region Intersection of Two Arrays II
        /*
        Given two integer arrays nums1 and nums2, return an array of their intersection. Each element in the result must appear as many times as it shows in both arrays and you may return the result in any order.

        Example 1:

        Input: nums1 = [1,2,2,1], nums2 = [2,2]
        Output: [2,2]

        Example 2:

        Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        Output: [4,9]
        Explanation: [9,4] is also accepted.

        Constraints:

            1 <= nums1.length, nums2.length <= 1000
            0 <= nums1[i], nums2[i] <= 1000

        Follow up:

            What if the given array is already sorted? How would you optimize your algorithm?
            What if nums1's size is small compared to nums2's size? Which algorithm is better?
            What if elements of nums2 are stored on disk, and the memory is limited such that you cannot load all elements into the memory at once?


        https://leetcode.com/problems/intersection-of-two-arrays-ii/
        */
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> keeper = new Dictionary<int, int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                if (keeper.ContainsKey(nums1[i]))
                {
                    keeper[nums1[i]]++;
                }
                else
                {
                    keeper.Add(nums1[i], 1);
                }
            }
            List<int> result = new List<int>();

            for (int i = 0; i < nums2.Length; i++)
            {
                if (keeper.ContainsKey(nums2[i]))
                {
                    keeper[nums2[i]]--;
                    result.Add(nums2[i]);
                    if (keeper[nums2[i]] == 0)
                        keeper.Remove(nums2[i]);
                }
            }
            return result.ToArray();
        }
        #endregion
        #region Contains Duplicate II
        /*
        Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.

        Example 1:

        Input: nums = [1,2,3,1], k = 3
        Output: true

        Example 2:

        Input: nums = [1,0,1,1], k = 1
        Output: true

        Example 3:

        Input: nums = [1,2,3,1,2,3], k = 2
        Output: false

        Constraints:

            1 <= nums.length <= 105
            -109 <= nums[i] <= 109
            0 <= k <= 105
        My Solution Below:
        Runtime: 213 ms(beats 76%)
        Memory Usage: 59.8 MB(beats 15%)
        */
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, int> keeper = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (keeper.ContainsKey(nums[i]))
                {
                    int difference = Math.Abs(keeper.GetValueOrDefault(nums[i]) - i);
                    if (difference <= k)
                        return true;
                    else
                    {
                        keeper.Remove(nums[i]);
                        keeper.Add(nums[i], i);
                    }
                }
                else
                {
                    keeper.Add(nums[i], i);
                }
            }
            return false;
        }
        #endregion
        #region Loger Rate Limiter
        /*
        Locked behind Premium
        https://leetcode.com/problems/logger-rate-limiter/
        */
        #endregion
        #endregion
        #region Practical Application - Design the Key
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
        Extra test case:
        ["",""] Expected:[["",""]]
        */
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
            foreach (string str in strs)
            {
                char[] count = new char[26];
                foreach (char c in str)
                {
                    count[c - 'a']++;
                }
                var temp = new String(count);
                if (!groups.ContainsKey(temp))
                {
                    groups.Add(temp, new List<string>() { str });
                }
                else
                {
                    groups[temp].Add(str);
                }
            }
            IList<IList<string>> list = new List<IList<string>>();
            foreach (var item in groups.Values)
            {
                list.Add(item);
            }
            return list;
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
        public bool IsValidSudokuHashSet(char[][] board)
        {
            int counter = 0;
            HashSet<string> set = new HashSet<string>();
            for (int row = 0; row < board.Length; row++)
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] != '.' && !set.Add(board[row][col] + " in row " + row))
                        return false;
                    if (board[row][col] != '.' && !set.Add(board[row][col] + " in col " + col))
                        return false;
                    if (board[row][col] != '.' && !set.Add(board[row][col] + " in square " + row / 3 + " " + col / 3))
                        return false;
                    counter++;
                }

            return true;
        }
        #endregion
        #region Find Duplicate Subtrees
        /*
        Given the root of a binary tree, return all duplicate subtrees.
        For each kind of duplicate subtrees, you only need to return the root node of any one of them.
        Two trees are duplicate if they have the same structure with the same node values.

        Example 1:

        Input: root = [1,2,3,4,null,2,4,null,null,4]
        Output: [[2,4],[4]]

        Example 2:

        Input: root = [2,1,1]
        Output: [[1]]

        Example 3:

        Input: root = [2,2,2,3,null,3,null]
        Output: [[2,3],[3]]

        Constraints:

            The number of the nodes in the tree will be in the range [1, 5000]
            -200 <= Node.val <= 200


        https://leetcode.com/problems/find-duplicate-subtrees/description/
        */
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            IList<TreeNode> res = new List<TreeNode>();
            traverse(root, new Dictionary<string, int>(), new Dictionary<int, int>(), res);
            return res;
        }

        public int traverse(TreeNode node, Dictionary<string, int> triples, Dictionary<int, int> cnt, IList<TreeNode> res)
        {
            if (node == null) return 0;

            string triplet = traverse(node.left, triples, cnt, res) + "," + node.val + traverse(node.right, triples, cnt, res);

            if (!triples.ContainsKey(triplet)) triples[triplet] = triples.Count + 1;

            int id = triples[triplet];
            if (!cnt.ContainsKey(id)) cnt[id] = 0;
            cnt[id]++;
            if (cnt[id] == 2) res.Add(node);

            return id;
        }
        #endregion
        #endregion
        #region Conclusion
        #region  Jewels and Stones
        /*
        You're given strings jewels representing the types of stones that are jewels, and stones representing the stones you have. Each character in stones is a type of stone you have. You want to know how many of the stones you have are also jewels.

        Letters are case sensitive, so "a" is considered a different type of stone from "A".

        

        Example 1:

        Input: jewels = "aA", stones = "aAAbbbb"
        Output: 3

        Example 2:

        Input: jewels = "z", stones = "ZZ"
        Output: 0

        

        Constraints:

            1 <= jewels.length, stones.length <= 50
            jewels and stones consist of only English letters.
            All the characters of jewels are unique.


        https://leetcode.com/problems/jewels-and-stones/
        */
        public int NumJewelsInStones(string jewels, string stones)
        {

            Dictionary<char, int> keeper = new Dictionary<char, int>();

            for (int i = 0; i < jewels.Length; i++)
            {
                keeper.Add(jewels[i], 0);
            }

            for (int i = 0; i < stones.Length; i++)
            {
                if (keeper.ContainsKey(stones[i]))
                {
                    keeper[stones[i]]++;
                }
            }

            int total = 0;
            foreach (int result in keeper.Values)
            {
                total += result;
            }

            return total;
        }
        #endregion
        #region  Longest Substring Without Repeating Characters
        /*
        Given a string s, find the length of the longest substring without repeating characters.

        Example 1:

        Input: s = "abcabcbb"
        Output: 3
        Explanation: The answer is "abc", with the length of 3.

        Example 2:

        Input: s = "bbbbb"
        Output: 1
        Explanation: The answer is "b", with the length of 1.

        Example 3:

        Input: s = "pwwkew"
        Output: 3
        Explanation: The answer is "wke", with the length of 3.
        Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

        Constraints:

            0 <= s.length <= 5 * 104
            s consists of English letters, digits, symbols and spaces.

        Test Case:
        "aab"
        "dvdf"
        "pwwkew"
        "bbbbb"
        "abcabcbb"
        Solution below is literally sliding window with a hashmap twist. Official solution that can be found under : Approach 3: Sliding Window Optimized
        https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
        */
        public int LengthOfLongestSubstring(string s)
        {
            int n = s.Length, ans = 0;
            Dictionary<char, int> map = new Dictionary<char, int>(); // current index of character
                                                                     // try to extend the range [i, j]
            for (int j = 0, i = 0; j < n; j++)
            {
                if (map.ContainsKey(s[j]))
                {
                    i = Math.Max(map[s[j]], i);
                }
                ans = Math.Max(ans, j - i + 1);
                map[s[j]] = j + 1;
            }
            return ans;
        }
        #endregion

        #endregion
        #endregion
    }
}