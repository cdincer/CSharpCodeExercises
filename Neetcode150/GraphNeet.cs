using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neetcode150
{
    public class GraphNeet
    {
        #region Number of Islands
        /*
        Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
        An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

        Example 1:
        Input: grid = [
        ["1","1","1","1","0"],
        ["1","1","0","1","0"],
        ["1","1","0","0","0"],
        ["0","0","0","0","0"]
        ]
        Output: 1

        Example 2:
        Input: grid = [
        ["1","1","0","0","0"],
        ["1","1","0","0","0"],
        ["0","0","1","0","0"],
        ["0","0","0","1","1"]
        ]
        Output: 3

        Constraints:
            m == grid.length
            n == grid[i].length
            1 <= m, n <= 300
            grid[i][j] is '0' or '1'.

        https://leetcode.com/problems/number-of-islands/
        */
        public int NumIslands(char[][] grid)
        {
            int[] dc = new int[] { 0, 0, -1, 1 };
            int[] dr = new int[] { -1, 1, 0, 0 };
            int n = grid.Length;
            int m = grid[0].Length;
            bool[,] visited = new bool[n, m];
            Queue<(int, int)> myq = new();
            int result = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1' && visited[i, j] == false)
                    {
                        result++;
                        visited[i, j] = true;
                        myq.Enqueue((i, j));

                        while (myq.Count > 0)
                        {
                            (int cr, int cc) = myq.Dequeue();
                            for (int x = 0; x < 4; x++)
                            {
                                int tr = cr + dr[x];
                                int tc = cc + dc[x];

                                if (tr >= 0 && tr < grid.Length && tc >= 0 && tc < grid[i].Length && grid[tr][tc] == '1' && visited[tr, tc] == false)
                                {
                                    visited[tr, tc] = true;
                                    myq.Enqueue((tr, tc));
                                }
                            }
                        }

                    }
                }
            }
            return result;
        }
        #endregion
        #region Clone Graph
        /*
        Given a reference of a node in a connected undirected graph.
        Return a deep copy (clone) of the graph.
        Each node in the graph contains a value (int) and a list (List[Node]) of its neighbors.

        class Node {
            public int val;
            public List<Node> neighbors;
        }

        Test case format:
        For simplicity, each node's value is the same as the node's index (1-indexed). For example, the first node with val == 1, the second node with val == 2, and so on. The graph is represented in the test case using an adjacency list.
        An adjacency list is a collection of unordered lists used to represent a finite graph. Each list describes the set of neighbors of a node in the graph.
        The given node will always be the first node with val = 1. You must return the copy of the given node as a reference to the cloned graph.

        Example 1:
        Input: adjList = [[2,4],[1,3],[2,4],[1,3]]
        Output: [[2,4],[1,3],[2,4],[1,3]]
        Explanation: There are 4 nodes in the graph.
        1st node (val = 1)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
        2nd node (val = 2)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).
        3rd node (val = 3)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
        4th node (val = 4)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).

        Example 2:
        Input: adjList = [[]]
        Output: [[]]
        Explanation: Note that the input contains one empty list. The graph consists of only one node with val = 1 and it does not have any neighbors.

        Example 3:
        Input: adjList = []
        Output: []
        Explanation: This an empty graph, it does not have any nodes.

        Constraints:

            The number of nodes in the graph is in the range [0, 100].
            1 <= Node.val <= 100
            Node.val is unique for each node.
            There are no repeated edges and no self-loops in the graph.
            The Graph is connected and all nodes can be visited starting from the given node.

        */
        #region Required Node Class
               public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }
        #endregion
        public Node CloneGraph(Node node)
        {
            if (node == null)
                return null;

            Node myNode = new Node()
            {
                val = node.val,
                neighbors = node.neighbors == null ? null : new List<Node>(node.neighbors.Count)
            };
            Stack<Node> mys = new();
            mys.Push(node);
            var mdict = new Dictionary<Node, Node>();
            mdict.Add(node, myNode);
            while (mys.Count > 0)
            {
                var clone = mys.Pop();
                Node tobe = mdict[clone];
                if (clone.neighbors != null && clone.neighbors.Count > 0)
                {
                    foreach (var child in clone.neighbors)
                    {
                        if (!mdict.TryGetValue(child, out var temp))
                        {
                            temp = new Node()
                            {
                                val = child.val,
                                neighbors = child.neighbors == null ? null : new List<Node>(child.neighbors.Count)
                            };
                            mys.Push(child);
                            mdict.Add(child, temp);
                        }
                        tobe.neighbors.Add(temp);
                    }
                }
            }
            return myNode;
        }
        #endregion
    }
}