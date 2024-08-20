using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Neetcode150
{
    public class AdvancedGraphsNeet
    {
        #region Reconstruct Itinerary
        /*
        You are given a list of airline tickets where tickets[i] = [fromi, toi] represent the departure and the arrival airports of one flight. Reconstruct the itinerary in order and return it.
        All of the tickets belong to a man who departs from "JFK", thus, the itinerary must begin with "JFK". If there are multiple valid itineraries, you should return the itinerary that has the smallest lexical order when read as a single string.
        For example, the itinerary ["JFK", "LGA"] has a smaller lexical order than ["JFK", "LGB"].
        You may assume all tickets form at least one valid itinerary. You must use all the tickets once and only once.

        Example 1:
        Input: tickets = [["MUC","LHR"],["JFK","MUC"],["SFO","SJC"],["LHR","SFO"]]
        Output: ["JFK","MUC","LHR","SFO","SJC"]

        Example 2:
        Input: tickets = [["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]]
        Output: ["JFK","ATL","JFK","SFO","ATL","SFO"]
        Explanation: Another possible reconstruction is ["JFK","SFO","ATL","JFK","ATL","SFO"] but it is larger in lexical order.

        Constraints:

            1 <= tickets.length <= 300
            tickets[i].length == 2
            fromi.length == 3
            toi.length == 3
            fromi and toi consist of uppercase English letters.
            fromi != toi

        Extra Test Cases:
        [["MUC","LHR"],["JFK","MUC"],["SFO","SJC"],["LHR","SFO"]] Output: ["JFK","MUC","LHR","SFO","SJC"]
        [["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]] Output: ["JFK","ATL","JFK","SFO","ATL","SFO"]
        [["JFK","KUL"],["JFK","NRT"],["NRT","JFK"]] Output: ["JFK","NRT","JFK","KUL"] REALLY IMPORTANT
        https://leetcode.com/problems/reconstruct-itinerary/
        */
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            Dictionary<string, List<string>> map = new();

            foreach (var ticket in tickets)
            {
                if (!map.TryGetValue(ticket[0], out List<string> adj))
                {
                    adj = new List<string>();
                    map.Add(ticket[0], adj);
                }

                adj.Add(ticket[1]);
            }

            foreach (List<string> adj in map.Values)
            {
                adj.Sort((a, b) => string.Compare(b, a));
            }

            Stack<string> res = new();
            Travel(map, "JFK", res);
            return res.ToList();

        }

        public void Travel(Dictionary<string, List<string>> itin, string src, Stack<string> ans)
        {
            if (itin.TryGetValue(src, out List<string> adj))
            {
                while (adj.Count > 0)
                {
                    string dest = adj.Last();
                    adj.RemoveAt(adj.Count - 1);
                    Travel(itin, dest, ans);
                }
            }

            ans.Push(src);
        }
        #endregion
        #region Min Cost to Connect All Points
        /*
        You are given an array points representing integer coordinates of some points on a 2D-plane, where points[i] = [xi, yi].
        The cost of connecting two points [xi, yi] and [xj, yj] is the manhattan distance between them: |xi - xj| + |yi - yj|, where |val| denotes the absolute value of val.
        Return the minimum cost to make all points connected. All points are connected if there is exactly one simple path between any two points.

        Example 1:
        Input: points = [[0,0],[2,2],[3,10],[5,2],[7,0]]
        Output: 20
        Explanation: 

        We can connect the points as shown above to get the minimum cost of 20.
        Notice that there is a unique path between every pair of points.

        Example 2:
        Input: points = [[3,12],[-2,5],[-4,1]]
        Output: 18

        Constraints:

            1 <= points.length <= 1000
            -106 <= xi, yi <= 106
            All pairs (xi, yi) are distinct.

        Extra Test Cases:
        [[0,0]] Output : 0 4 / 72 testcases passed
        [[-14,-14],[-18,5],[18,-10],[18,18],[10,-2]] Output : 102
        https://leetcode.com/problems/min-cost-to-connect-all-points/
        */
        public int MinCostConnectPoints(int[][] points)
        {
            int result = 0;
            HashSet<int> visited = new();//source node //cost //target node
            PriorityQueue<(int, int), int> pq = new();
            Dictionary<int, List<(int, int)>> dict = new();

            for (int i = 0; i < points.Length; i++)
            {
                int mx = points[i][0];
                int my = points[i][1];
                dict.Add(i, new List<(int, int)>());
                for (int j = 0; j < points.Length; j++)
                {
                    if (i == j) continue;

                    int dist = Math.Abs(mx - points[j][0]) + Math.Abs(my - points[j][1]);
                    dict[i].Add((dist, j));
                }
            }

            pq.Enqueue((0, 0), 0);

            while (pq.Count > 0)
            {
                (int cost, int node) = pq.Dequeue();

                if (visited.Contains(node)) continue;

                visited.Add(node);
                result += cost;

                if (dict.TryGetValue(node, out List<(int, int)> clist))
                {
                    foreach (var item in clist)
                    {
                        if (!visited.Contains(item.Item2))
                            pq.Enqueue((item.Item1, item.Item2), item.Item1);
                    }
                }
            }

            return result;
        }

        #endregion
        #region Network Delay Time
        /*
        You are given a network of n nodes, labeled from 1 to n. You are also given times, a list of travel times as directed edges times[i] = (ui, vi, wi), where ui is the source node, vi is the target node, 
        and wi is the time it takes for a signal to travel from source to target.
        We will send a signal from a given node k. Return the minimum time it takes for all the n nodes to receive the signal. If it is impossible for all the n nodes to receive the signal, return -1.

        Example 1:
        Input: times = [[2,1,1],[2,3,1],[3,4,1]], n = 4, k = 2
        Output: 2

        Example 2:
        Input: times = [[1,2,1]], n = 2, k = 1
        Output: 1

        Example 3:
        Input: times = [[1,2,1]], n = 2, k = 2
        Output: -1

        Constraints:

            1 <= k <= n <= 100
            1 <= times.length <= 6000
            times[i].length == 3
            1 <= ui, vi <= n
            ui != vi
            0 <= wi <= 100
            All the pairs (ui, vi) are unique. (i.e., no multiple edges.)

        Extra Test Cases:
        [[1,2,1],[2,3,2]] n = 3 k = 1 Output: 3 8/53 testcases
        [[1,2,1],[2,3,2],[1,3,4]] n = 3 k = 1 Output: 3 13 / 53 testcases
        [[1,2,1],[2,1,3]] n = 2 k = 2 Output: 3
        [[1,2,1],[2,3,7],[1,3,4],[2,1,2]] Output: 50/53 testcases
        https://leetcode.com/problems/network-delay-time
        */

        ///Modified solution of Neetcode so it has a similar adjancency list and 
        ///dequeuing pattern.
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            HashSet<int> visited = new();
            PriorityQueue<(int, int), int> pq = new();
            Dictionary<int, List<(int, int)>> dict = new();//cost //target node
            foreach (var time in times)
            {
                dict.TryAdd(time[0], new List<(int, int)>());

                dict[time[0]].Add((time[2], time[1]));
            }
            int result = 0;
            pq.Enqueue((0, k), 0);

            while (pq.Count > 0)
            {
                (int cost, int node) = pq.Dequeue();

                if (visited.Contains(node)) continue;

                visited.Add(node);
                result = Math.Max(result, cost);
                if (dict.TryGetValue(node, out var clist))
                {
                    foreach (var current in clist)
                    {
                        if (visited.Contains(current.Item2)) continue;

                        int we = result + current.Item1;
                        pq.Enqueue((we, current.Item2), we);
                    }
                }
            }

            if (visited.Count == n)
                return result;

            return -1;
        }
        #endregion
        #region Rising Water
        /*
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only 
        if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).

        Example 1:
        Input: grid = [[0,2],[1,3]]
        Output: 3
        Explanation:
        At time 0, you are in grid location (0, 0).
        You cannot go anywhere else because 4-directionally adjacent neighbors have a higher elevation than t = 0.
        You cannot reach point (1, 1) until time 3.
        When the depth of water is 3, we can swim anywhere inside the grid.

        Example 2:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.

        Constraints:

            n == grid.length
            n == grid[i].length
            1 <= n <= 50
            0 <= grid[i][j] < n2
            Each value grid[i][j] is unique.

        Extra Test Case:
        [[3,2],[0,1]] Output: 3 30 / 43 testcases passed
        https://leetcode.com/problems/swim-in-rising-water
        */
        public int SwimInWater(int[][] grid)
        {
            HashSet<(int, int)> visited = new();
            PriorityQueue<(int, int), int> pq = new(); // x,y cost
            int result = 0;
            pq.Enqueue((0, 0), grid[0][0]);

            while (pq.Count > 0)
            {
                pq.TryDequeue(out var node, out int cost);

                if (visited.Contains(node)) continue;

                visited.Add(node);
                result = Math.Max(result, cost);

                int r = node.Item1;
                int c = node.Item2;

                if (r == grid.Length - 1 && c == grid[0].Length - 1)
                    return result;

                travel(pq, visited, grid, r + 1, c);
                travel(pq, visited, grid, r - 1, c);
                travel(pq, visited, grid, r, c + 1);
                travel(pq, visited, grid, r, c - 1);

            }

            return -1;
        }

        public void travel(PriorityQueue<(int, int), int> pq, HashSet<(int, int)> visited, int[][] grid, int r, int c)
        {
            if (r >= grid.Length || 0 > r) return;
            if (c >= grid[0].Length || 0 > c) return;
            if (visited.Contains((r, c))) return;

            pq.Enqueue((r, c), grid[r][c]);
        }
        #endregion
        #region Foreign/Alien Dictionary (Two names on Neetcode - different one in roadmap another one in question page)
        /*
        Premium Question on Leetcode / Neetcode.io  https://neetcode.io/problems/foreign-dictionary
        There is a foreign language which uses the latin alphabet, but the order among letters is not "a", "b", "c" ... "z" as in English.
        You receive a list of non-empty strings words from the dictionary, where the words are sorted lexicographically based on the rules of this new language.
        Derive the order of letters in this language. If the order is invalid, return an empty string. If there are multiple valid order of letters, return any of them.
        A string a is lexicographically smaller than a string b if either of the following is true:

            The first letter where they differ is smaller in a than in b.
            There is no index i such that a[i] != b[i] and a.length < b.length.

        Example 1:
        Input: ["z","o"]
        Output: "zo"
        Explanation:
        From "z" and "o", we know 'z' < 'o', so return "zo".

        Example 2:
        Input: ["hrn","hrf","er","enn","rfnn"]
        Output: "hernf"
        Explanation:

            from "hrn" and "hrf", we know 'n' < 'f'
            from "hrf" and "er", we know 'h' < 'e'
            from "er" and "enn", we know get 'r' < 'n'
            from "enn" and "rfnn" we know 'e'<'r'
            so one possibile solution is "hernf"

        Constraints:

            The input words will contain characters only from lowercase 'a' to 'z'.
            1 <= words.length <= 100
            1 <= words[i].length <= 100

        Extra Test Case:
        words=["wrt","wrf","er","ett","rftt","te"] Expected Output: wertf
        words=["abc","bcd","cde"] Expected Output: edabc Passed test cases: 2 / 24 
        words=["wrtkj","wrt"]. Expected output:"" Passed test cases: 4 / 24
        https://leetcode.com/problems/alien-dictionary/
        */
        public string foreignDictionary(string[] words)
        {
            Dictionary<char, HashSet<char>> dict = new();

            foreach (string word in words) //Create a hashset for every letter because some of them might not be linked to anything.
            {
                foreach (var c in word)
                {
                    dict.TryAdd(c, new HashSet<char>());
                }
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                string w1 = words[i];
                string w2 = words[i + 1];
                int minLength = Math.Min(w1.Length, w2.Length);

                if (w1.Length > w2.Length && w1.Substring(0, minLength) == w2.Substring(0, minLength))
                    return "";

                for (int y = 0; y < minLength; y++)
                {
                    if (w1[y] != w2[y])
                    {
                        dict[w1[y]].Add(w2[y]);
                        break;
                    }
                }
            }
            List<char> result = new();
            Dictionary<char, bool> visited = new();
            bool travel(char c)
            {
                if (visited.ContainsKey(c))
                    return visited[c];

                visited.TryAdd(c, true);
                foreach (var item in dict[c])
                {
                    if (travel(item))
                        return true;
                }

                visited[c] = false;
                result.Add(c);

                return visited[c];
            }
            //Dictionary insert order is preserved, 
            //this can be verified through MoveNext() in Dictionary.cs
            //As a result of this foreach loop below goes through our letters and their links
            //through the insert order(correct order that is asked by this question)
            foreach (var item in dict.Keys) 
            {
                if (travel(item))
                    return "";
            }


            result.Reverse();
            return string.Join("", result);
        }
        #endregion
        #region Cheapest Flights Within K Stops
        /*
        https://leetcode.com/problems/cheapest-flights-within-k-stops/
        Extra Test Cases:
        52 / 56 testcases passed
        n = 7 flights = [[0,3,7],[4,5,3],[6,4,8],[2,0,10],[6,5,6],[1,2,2],[2,5,9],[2,6,8],[3,6,3],[4,0,10],[4,6,8],[5,2,6],[1,4,3],[4,1,6],[0,5,10],[3,1,5],[4,3,1],[5,4,10],[0,1,6]]        
        dst = 4 k = 1 Expected = 16
        -----
        */
        #endregion
   
    }
}
