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
        private Dictionary<string, IList<string>> adj;
        private IList<string> res = new List<string>();

        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            adj = new Dictionary<string, IList<string>>();
            var sortedTickets = tickets.OrderByDescending(t => t[1]).ToList();
            foreach (var ticket in sortedTickets)
            {
                if (!adj.ContainsKey(ticket[0]))
                {
                    if (!adj.ContainsKey(ticket[0]))
                        adj[ticket[0]] = new List<string>();
                }
                adj[ticket[0]].Add(ticket[1]);
            }

            Dfs("JFK");


            return res.Reverse().ToList();
        }


        private void Dfs(string src)
        {
            while (adj.ContainsKey(src) && adj[src].Count > 0)
            {
                var dst = adj[src][adj[src].Count - 1];
                adj[src].RemoveAt(adj[src].Count - 1);
                Dfs(dst);
            }
            res.Add(src);
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
            int n = points.Length, node = 0;
            int[] dist = new int[n];
            bool[] visit = new bool[n];
            Array.Fill(dist, 100000000);
            int edges = 0, res = 0;

            while (edges < n - 1)
            {
                visit[node] = true;
                int nextNode = -1;
                for (int i = 0; i < n; i++)
                {
                    if (visit[i]) continue;
                    int curDist = Math.Abs(points[i][0] - points[node][0]) +
                                   Math.Abs(points[i][1] - points[node][1]);
                    dist[i] = Math.Min(dist[i], curDist);
                    if (nextNode == -1 || dist[i] < dist[nextNode])
                    {
                        nextNode = i;
                    }
                }
                res += dist[nextNode];
                node = nextNode;
                edges++;
            }
            return res;
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
        [[1,2,1],[2,3,2]] n = 3 k = 1 Expected: 3 8/53 testcases
        [[1,2,1],[2,3,2],[1,3,4]] n = 3 k = 1 Expected: 3 13 / 53 testcases
        [[1,2,1],[2,1,3]] n = 2 k = 2 Expected: 3
        [[1,2,1],[2,3,7],[1,3,4],[2,1,2]] n = 4 k = 1 Expected: -1 50/53 testcases
        https://leetcode.com/problems/network-delay-time
        */

        ///Modified solution of Neetcode so it has a similar adjancency list and 
        ///dequeuing pattern.
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            HashSet<int> visited = new();
            PriorityQueue<(int, int), int> pq = new();//cost //target node // Priority which based on cost
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

                        int overallCost = result + current.Item1;
                        pq.Enqueue((overallCost, current.Item2), overallCost);
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
        int rl = 0;
        int cl = 0;
        //Neetcode's Runtime on Dec 11, 2024 06:10 7ms Beats 98.98%
        //Neetcode's memory on  Dec 11, 2024 06:10 42.33MB Beats 96.26%

        //My refactored Runtime on Dec 11, 2024 06:10 8ms Beats 98.98%
        //My refactored memory on  Dec 11, 2024 06:10 42.98MB Beats 83.18%


        public int SwimInWater(int[][] grid)
        {
            rl = grid.Length;
            cl = grid[0].Length;
            bool[,] visit = new bool[rl, cl];

            int minH = grid[0][0], maxH = grid[0][0];

            for (int rt = 0; rt < rl; rt++)
            {
                minH = Math.Min(minH, grid[rt].Min());
                maxH = Math.Max(maxH, grid[rt].Max());
            }

            int l = minH, r = maxH;

            while (l < r)
            {
                int m = (l + r) >> 1;

                if (dfs(grid, visit, 0, 0, m))
                    r = m;
                else
                    l = m + 1;

                visit = new bool[rl, cl];
            }

            return l;
        }

        private bool dfs(int[][] grid, bool[,] visit, int row, int col, int time)
        {
            if (0 > row || 0 > col || row >= rl || col >= cl || visit[row, col] || grid[row][col] > time)
                return false;

            if (row == rl - 1 && col == cl - 1) return true;

            visit[row, col] = true;

            return
            dfs(grid, visit, row + 1, col, time) ||
            dfs(grid, visit, row - 1, col, time) ||
            dfs(grid, visit, row, col + 1, time) ||
            dfs(grid, visit, row, col - 1, time);
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
        There are n cities connected by some number of flights. You are given an array flights where flights[i] = [fromi, to i, price i] 
        indicates that there is a flight from city fromi to city to i with cost price i.
        You are also given three integers src, dst, and k, return the cheapest price from src to dst with at most k stops. If there is no such route, return -1.

        Example 1
        Input: n = 4, flights = [[0,1,100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]], src = 0, dst = 3, k = 1
        Output: 700
        Explanation:
        The graph is shown above.
        The optimal path with at most 1 stop from city 0 to 3 is marked in red and has cost 100 + 600 = 700.
        Note that the path through cities [0,1,2,3] is cheaper but is invalid because it uses 2 stops.

        Example 2:
        Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k = 1
        Output: 200
        Explanation:
        The graph is shown above.
        The optimal path with at most 1 stop from city 0 to 2 is marked in red and has cost 100 + 100 = 200.

        Example 3:
        Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k = 0
        Output: 500
        Explanation:
        The graph is shown above.
        The optimal path with no stops from city 0 to 2 is marked in red and has cost 500.

        Constraints:

            1 <= n <= 100
            0 <= flights.length <= (n * (n - 1) / 2)
            flights[i].length == 3
            0 <= fromi, toi < n
            fromi != toi
            1 <= pricei <= 104
            There will not be any multiple flights between two cities.
            0 <= src, dst, k < n
            src != dst

        https://leetcode.com/problems/cheapest-flights-within-k-stops/
        Extra Test Cases:
        52 / 56 testcases passed
        n = 7 flights = [[0,3,7],[4,5,3],[6,4,8],[2,0,10],[6,5,6],[1,2,2],[2,5,9],[2,6,8],[3,6,3],[4,0,10],[4,6,8],[5,2,6],[1,4,3],[4,1,6],[0,5,10],[3,1,5],[4,3,1],[5,4,10],[0,1,6]]        
        src = 2 dst = 4 k = 1 Expected = 16
        -----
        C# Sample Test Case:
        
            int[][] grid2 = new int[][]
            {
                new int[] {0,1,100},
                new int[] {1,2,100},
                new int[] {2,0,100},
                new int[] {1,3,600},
                new int[] {2,3,200}
             };

             
            int[][] grid3 = new int[][]
            {
                new int[] {0,1,100},
                new int[] {1,2,100},
                new int[] {0,2,500}
             };
          .FindCheapestPrice(4,grid2,0,3,1);
        */
        //Shortest Path Algorithm Solution.
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {

            int[] prices = new int[n];
            Array.Fill(prices, int.MaxValue);
            prices[src] = 0;

            List<int[]>[] adj = new List<int[]>[n];

            for (int i = 0; i < n; i++)
                adj[i] = new List<int[]>();

            foreach (var flight in flights)
                adj[flight[0]].Add(new int[] { flight[1], flight[2] });

            var q = new Queue<(int cst, int node, int stops)>();
            q.Enqueue((0, src, 0));

            while (q.Count > 0)
            {
                var (cst, node, stops) = q.Dequeue();

                if (stops > k) continue;

                foreach (var neighbor in adj[node])
                {
                    int nei = neighbor[0];
                    int neiCost = neighbor[1];
                    int nextCost = cst + neiCost;

                    if (nextCost < prices[nei])
                    {
                        prices[nei] = nextCost;
                        q.Enqueue((nextCost, nei, stops + 1));
                    }

                }
            }

            return prices[dst] == int.MaxValue ? -1 : prices[dst];
        }
        #endregion
   
    }
}
