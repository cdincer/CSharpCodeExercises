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
         [[-14,-14],[-18,5],[18,-10],[18,18],[10,-2]]
        */
        public int MinCostConnectPoints(int[][] points)
        {
            Dictionary<int, List<(int, int)>> dict = new();
            for (int i = 0; i < points.Length; i++)
            {
                int xmain = points[i][0];
                int ymain = points[i][1];
                dict.TryAdd(i, new List<(int, int)>());
                for (int y = 0; y < points.Length; y++)
                {
                    if (points[y][0] == xmain && points[y][1] == ymain)
                        continue;
                    int res = Math.Abs(xmain - points[y][0]) + Math.Abs(ymain - points[y][1]);
                    dict[i].Add((res, y));
                }
            }
            PriorityQueue<(int, int), int> minHeap = new();
            int result = 0; minHeap.Enqueue((0, 0), 0);
            HashSet<int> visited = new();
            while (minHeap.Count > 0)
            {
                var (cost, node) = minHeap.Dequeue();

                if (!visited.Contains(node))
                {
                    result += cost;
                    visited.Add(node);
                    var adjlist = dict[node];
                    for (int i = 0; i < adjlist.Count; i++)
                    {
                        if (!visited.Contains(adjlist[i].Item2))
                        {
                            minHeap.Enqueue((adjlist[i].Item1, adjlist[i].Item2), adjlist[i].Item1);
                        }
                    }
                }
            }
            return result;
        }

        #endregion

    }
}
