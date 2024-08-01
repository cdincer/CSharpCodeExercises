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

    }
}
