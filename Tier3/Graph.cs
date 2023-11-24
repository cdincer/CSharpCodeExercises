using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCodeExercises.Tier3
{
    //https://leetcode.com/explore/learn/card/graph/
    //There is 3 non-premium questions and a handful of lessons to go with them.
    //Rest of the chapters/questions are behind premium subscription.
    public class Graph
    {
        //Graph visualization tool for leetcode specific ones.
        //https://graph-visualizer-with-ts.netlify.app/
        #region Disjoint Set
        #region Number Of Provinces
        /*
        There are n cities. Some of them are connected, while some are not. If city a is connected directly with city b, and city b is connected directly with city c, then city a is connected indirectly with city c.
        A province is a group of directly or indirectly connected cities and no other cities outside of the group.
        You are given an n x n matrix isConnected where isConnected[i][j] = 1 if the ith city and the jth city are directly connected, and isConnected[i][j] = 0 otherwise.
        Return the total number of provinces.

        Example 1:
        Input: isConnected = [[1,1,0],[1,1,0],[0,0,1]]
        Output: 2

        Example 2:
        Input: isConnected = [[1,0,0],[0,1,0],[0,0,1]]
        Output: 3

        Constraints:

            1 <= n <= 200
            n == isConnected.length
            n == isConnected[i].length
            isConnected[i][j] is 1 or 0.
            isConnected[i][i] == 1
            isConnected[i][j] == isConnected[j][i]

        https://leetcode.com/problems/number-of-provinces/description/
        Extra Testcase:
        [[1,0,0,1],[0,1,1,0],[0,1,1,1],[1,0,1,1]] Expected : 1
        */
        //Solution: https://leetcode.com/explore/featured/card/graph/618/disjoint-set/3843/ ?
        public void dfs(int node, int[][] isConnected, bool[] visit)
        {
            visit[node] = true;
            for (int i = 0; i < isConnected.Length; i++)
            {
                if (isConnected[node][i] == 1 && !visit[i])
                {
                    dfs(i, isConnected, visit);
                }
            }
        }

        public int FindCircleNum(int[][] isConnected)
        {
            int n = isConnected.Length;
            int numberOfComponents = 0;
            bool[] visit = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (!visit[i])
                {
                    numberOfComponents++;
                    dfs(i, isConnected, visit);
                }
            }

            return numberOfComponents;
        }


        #endregion
        #region Smallest String With Swaps
        /*
        You are given a string s, and an array of pairs of indices in the string pairs where pairs[i] = [a, b] indicates 2 indices(0-indexed) of the string.
        You can swap the characters at any pair of indices in the given pairs any number of times.
        Return the lexicographically smallest string that s can be changed to after using the swaps.

        Example 1:
        Input: s = "dcab", pairs = [[0,3],[1,2]]
        Output: "bacd"
        Explaination: 
        Swap s[0] and s[3], s = "bcad"
        Swap s[1] and s[2], s = "bacd"

        Example 2:
        Input: s = "dcab", pairs = [[0,3],[1,2],[0,2]]
        Output: "abcd"
        Explaination: 
        Swap s[0] and s[3], s = "bcad"
        Swap s[0] and s[2], s = "acbd"
        Swap s[1] and s[2], s = "abcd"

        Example 3:
        Input: s = "cba", pairs = [[0,1],[1,2]]
        Output: "abc"
        Explaination: 
        Swap s[0] and s[1], s = "bca"
        Swap s[1] and s[2], s = "bac"
        Swap s[0] and s[1], s = "abc"

        Constraints:

            1 <= s.length <= 10^5
            0 <= pairs.length <= 10^5
            0 <= pairs[i][0], pairs[i][1] < s.length
            s only contains lower case English letters.


        https://leetcode.com/problems/smallest-string-with-swaps/description/
        Additional Test Cases:
        "udyyek"
        [[3,3],[3,0],[5,1],[3,1],[3,4],[3,5]]
        "qdwyt"
        [[2,3],[3,2],[0,1],[4,0],[3,2]]
        "dcab"
        []
        "pwqlmqm"
        [[5,3],[3,0],[5,1],[1,1],[1,5],[3,0],[0,2]]
        "fqtvkfkt"
        [[2,4],[5,7],[1,0],[0,0],[4,7],[0,3],[4,1],[1,3]]
        "otilzqqoj"
        [[2,3],[7,3],[3,8],[1,7],[1,0],[0,4],[0,6],[3,4],[2,5]]
        "zbxxxdgmbz"
        [[1,0],[7,1],[9,1],[3,0],[7,1],[0,4],[6,5],[2,6],[6,4],[6,0]]
        "vbjjxgdfnru"
        [[8,6],[3,4],[5,2],[5,5],[3,5],[7,10],[6,0],[10,0],[7,1],[4,8],[6,2]]
        "tklkxyizmlqf"
        [[2,10],[3,5],[8,11],[1,2],[10,6],[4,1],[1,10],[5,8],[8,3],[10,4],[7,3],[10,11]]
        #region C# List Examples
        List<IList<int>> pairs1 = new();
        pairs1.Add(new List<int>() { 0, 3 });
        pairs1.Add(new List<int>() { 1, 2 });
        pairs1.Add(new List<int>() { 0, 2 });
        string stringSorted1 = "dcab";
        List<IList<int>> pairs2 = new();
        pairs2.Add(new List<int>() { 8, 6 });
        pairs2.Add(new List<int>() { 3, 4 });
        pairs2.Add(new List<int>() { 5, 2 });
        pairs2.Add(new List<int>() { 5, 5 });
        pairs2.Add(new List<int>() { 3, 5 });
        pairs2.Add(new List<int>() { 7, 10 });
        pairs2.Add(new List<int>() { 6, 0 });
        pairs2.Add(new List<int>() { 10, 0 });
        pairs2.Add(new List<int>() { 7, 1 });
        pairs2.Add(new List<int>() { 4, 8 });
        pairs2.Add(new List<int>() { 6, 2 });
        string stringSorted2 = "vbjjxgdfnru";
        #endregion
        */

        public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            var parentMap = new Dictionary<int, int>();
            foreach (var pair in pairs)
                Union(parentMap, pair[0], pair[1]);

            var map = new Dictionary<int, List<KeyValuePair<char, int>>>();
            for (int i = 0; i < s.Length; i++)
            {
                var parent = Find(parentMap, i);
                if (!map.ContainsKey(parent))
                    map[parent] = new List<KeyValuePair<char, int>>();

                map[parent].Add(new KeyValuePair<char, int>(s[i], i));
            }

            char[] result = new char[s.Length];
            foreach (var list in map.Values)
            {
                var charArray = list.Select(x => x.Key).ToArray();
                var indexArray = list.Select(x => x.Value).ToArray();
                Array.Sort(charArray);

                for (int i = 0; i < indexArray.Length; i++)
                    result[indexArray[i]] = charArray[i];
            }

            return new String(result);
        }

        private void Union(Dictionary<int, int> parentMap, int x, int y)
        {
            int parent1 = Find(parentMap, x), parent2 = Find(parentMap, y);
            if (parent1 != parent2)
                parentMap[parent1] = parent2;
        }

        private int Find(Dictionary<int, int> parentMap, int num)
        {
            if (!parentMap.ContainsKey(num)) parentMap[num] = num;
            if (parentMap[num] != num)
                parentMap[num] = Find(parentMap, parentMap[num]);
            return parentMap[num];
        }
        #endregion
        #region Evaluate Division
        /* 
        You are given an array of variable pairs equations and an array of real numbers values, 
        where equations[i] = [Ai, Bi] and values[i] represent the equation Ai / Bi = values[i]. 
        Each Ai or Bi is a string that represents a single variable.
        You are also given some queries, where queries[j] = [Cj, Dj] represents the jth query where you must find the answer for Cj / Dj = ?.
        Return the answers to all queries. If a single answer cannot be determined, return -1.0.
        Note: The input is always valid. You may assume that evaluating the queries will not result in division by zero and that there is no contradiction.
        Note: The variables that do not occur in the list of equations are undefined, so the answer cannot be determined for them.

        Example 1:
        Input: 
        equations = [["a","b"],["b","c"]], 
        values = [2.0,3.0], 
        queries = [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]
        Output: [6.00000,0.50000,-1.00000,1.00000,-1.00000]
        Explanation: 
        Given: a / b = 2.0, b / c = 3.0
        queries are: a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ? 
        return: [6.0, 0.5, -1.0, 1.0, -1.0 ]
        note: x is undefined => -1.0

        Example 2:
        Input: 
        equations = [["a","b"],["b","c"],["bc","cd"]], 
        values = [1.5,2.5,5.0], 
        queries = [["a","c"],["c","b"],["bc","cd"],["cd","bc"]]
        Output: [3.75000,0.40000,5.00000,0.20000]

        Example 3:
        Input: 
        equations = [["a","b"]], 
        values = [0.5],
        queries = [["a","b"],["b","a"],["a","c"],["x","y"]]
        Output: [0.50000,2.00000,-1.00000,-1.00000]

        https://leetcode.com/problems/evaluate-division/
        */
        /* 
        C# Test Case Prep 1st Scenario:
        List<IList<string>> equations = new();
        equations.Add(new List<string>() {"a","b"});
        equations.Add(new List<string>() {"b","c" });
        double[] values = new [] {2.0,3.0};
        List<IList<string>> queries = new();
        queries.Add(new List<string>() {"a","c" });
        queries.Add(new List<string>() {"b","a" });
        queries.Add(new List<string>() {"a","e" });
        queries.Add(new List<string>() {"a","a" });
        queries.Add(new List<string>() {"x","x" });
        */
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            double[] results = new double[queries.Count];
            Dictionary<string, List<Tuple<string, double>>> dict = new Dictionary<string, List<Tuple<string, double>>>();
            HashSet<string> pairs = new HashSet<string>();

            for (int i = 0; i < equations.Count; i++)
            {
                if (!dict.ContainsKey(equations[i][0]))
                    dict.Add(equations[i][0], new List<Tuple<string, double>>());

                dict[equations[i][0]].Add(new Tuple<string, double>(equations[i][1], values[i]));

                if (!dict.ContainsKey(equations[i][1]))
                    dict.Add(equations[i][1], new List<Tuple<string, double>>());

                dict[equations[i][1]].Add(new Tuple<string, double>(equations[i][0], 1 / values[i]));

                if (!pairs.Contains(equations[i][0]))
                    pairs.Add(equations[i][0]);

                if (!pairs.Contains(equations[i][1]))
                    pairs.Add(equations[i][1]);
            }

            for (int i = 0; i < queries.Count; i++)
                if (pairs.Contains(queries[i][0]) && pairs.Contains(queries[i][1]))
                    results[i] = DFS(dict, new HashSet<string>(), queries[i][0], queries[i][1], 1);
                else
                    results[i] = -1.0;

            return results;
        }

        private double DFS(Dictionary<string, List<Tuple<string, double>>> dict, HashSet<string> visited, string cur, string e, double val)
        {
            if (cur == e)
                return val;

            if (dict.ContainsKey(cur))
                foreach (var item in dict[cur])
                    if (!visited.Contains(item.Item1))
                    {
                        visited.Add(item.Item1);

                        double res = DFS(dict, visited, item.Item1, e, val * item.Item2);

                        if (res != -1.0)
                            return res;
                    }

            return -1.0;
        }
        #endregion
        #endregion

    }
}