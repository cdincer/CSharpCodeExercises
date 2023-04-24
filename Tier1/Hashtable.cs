using System;
using System.Collections.Generic;
using System.Linq;

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
        #endregion
        #endregion
    }
}