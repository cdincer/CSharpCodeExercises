using System;
using System.Collections.Generic;

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
        https://leetcode.com/problems/design-hashmap/description/
        */
        ///WIP - Solution
        public class MyHashMap
        {
            int[] data;
            public MyHashMap()
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
        #endregion
        #endregion
    }
}