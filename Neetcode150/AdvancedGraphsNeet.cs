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
        Extra Test Case:
        [[3,2],[0,1]] Output: 3 30 / 43 testcases passed
        */
        #endregion
        #region Alien Dictionary
        /*
        Extra Test Case:
        words=["wrt","wrf","er","ett","rftt","te"] Expected Output: wertf
        */
        #endregion
    }
}
