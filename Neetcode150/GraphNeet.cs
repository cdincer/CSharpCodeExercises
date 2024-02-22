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
        //Run time difference between queue version and recursive is about 10%
        //Same memory usage.
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

        Dictionary<Node, Node> map = new Dictionary<Node, Node>();
        public Node CloneGraphNeet(Node node)
        {
            if (node == null) return null;
            if (!map.ContainsKey(node))
            {
                map.Add(node, new Node(node.val));
                foreach (var n in node.neighbors)
                {
                    map[node].neighbors.Add(CloneGraphNeet(n));
                }
            }

            return map[node];
        }
        #endregion
        #region  Max Area of Island
        /*
        You are given an m x n binary matrix grid. An island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) 
        You may assume all four edges of the grid are surrounded by water.
        The area of an island is the number of cells with a value 1 in the island.
        Return the maximum area of an island in grid. If there is no island, return 0.

        Example 1:
        Input: grid = [[0,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,1,1,0,1,0,0,0,0,0,0,0,0],[0,1,0,0,1,1,0,0,1,0,1,0,0],[0,1,0,0,1,1,0,0,1,1,1,0,0],[0,0,0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,0,0,0,0,0,0,1,1,0,0,0,0]]
        Output: 6
        Explanation: The answer is not 11, because the island must be connected 4-directionally.

        Example 2:
        Input: grid = [[0,0,0,0,0,0,0,0]]
        Output: 0

        Constraints:

            m == grid.length
            n == grid[i].length
            1 <= m, n <= 50
            grid[i][j] is either 0 or 1.

        Test Cases:
        [[1]] 613 / 728 testcases passed
        https://leetcode.com/problems/max-area-of-island/
        */
        public int MaxAreaOfIsland(int[][] grid)
        {
            int MaxArea = 0;
            int rl = grid.Length;
            int cl = grid[0].Length;
            Queue<(int, int)> myq = new();
            int[] dr = new int[] { 1, -1, 0, 0 };
            int[] dc = new int[] { 0, 0, 1, -1 };

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        myq.Enqueue((i, j));
                        int currA = 1;
                        grid[i][j] = 0;
                        while (myq.Count > 0)
                        {
                            (int tr, int tc) = myq.Dequeue();
                            for (int x = 0; x < 4; x++)
                            {
                                int cr = dr[x] + tr;
                                int cc = dc[x] + tc;

                                if (cr > -1 && cr < rl && cc > -1 && cc < cl && grid[cr][cc] == 1)
                                {
                                    Console.WriteLine("entered with " + cr + " with cc" + cc);
                                    currA++;
                                    grid[cr][cc] = 0;
                                    myq.Enqueue((cr, cc));
                                }
                            }
                        }
                        MaxArea = Math.Max(MaxArea, currA);
                    }
                }

            }

            return MaxArea;
        }
        #endregion
        #region Pacific Atlantic Water Flow
        /*
        There is an m x n rectangular island that borders both the Pacific Ocean and Atlantic Ocean. The Pacific Ocean touches the island's left and top edges, and the Atlantic Ocean touches the island's right and bottom edges.
        The island is partitioned into a grid of square cells. You are given an m x n integer matrix heights where heights[r][c] represents the height above sea level of the cell at coordinate (r, c).
        The island receives a lot of rain, and the rain water can flow to neighboring cells directly north, south, east, and west if the neighboring cell's height is less than or equal to the current cell's height. 
        Water can flow from any cell adjacent to an ocean into the ocean.
        Return a 2D list of grid coordinates result where result[i] = [ri, ci] denotes that rain water can flow from cell (ri, ci) to both the Pacific and Atlantic oceans.
        
        Example 1:
        Input: heights = [[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]
        Output: [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]
        Explanation: The following cells can flow to the Pacific and Atlantic oceans, as shown below:
        [0,4]: [0,4] -> Pacific Ocean 
            [0,4] -> Atlantic Ocean
        [1,3]: [1,3] -> [0,3] -> Pacific Ocean 
            [1,3] -> [1,4] -> Atlantic Ocean
        [1,4]: [1,4] -> [1,3] -> [0,3] -> Pacific Ocean 
            [1,4] -> Atlantic Ocean
        [2,2]: [2,2] -> [1,2] -> [0,2] -> Pacific Ocean 
            [2,2] -> [2,3] -> [2,4] -> Atlantic Ocean
        [3,0]: [3,0] -> Pacific Ocean 
            [3,0] -> [4,0] -> Atlantic Ocean
        [3,1]: [3,1] -> [3,0] -> Pacific Ocean 
            [3,1] -> [4,1] -> Atlantic Ocean
        [4,0]: [4,0] -> Pacific Ocean 
            [4,0] -> Atlantic Ocean
        Note that there are other possible paths for these cells to flow to the Pacific and Atlantic oceans.

        Example 2:
        Input: heights = [[1]]
        Output: [[0,0]]
        Explanation: The water can flow from the only cell to the Pacific and Atlantic oceans.

        Constraints:

            m == heights.length
            n == heights[r].length
            1 <= m, n <= 200
            0 <= heights[r][c] <= 105
        
        Test Cases:
        [[1,1],[1,1],[1,1]] 5 / 113 testcases passed

        https://leetcode.com/problems/pacific-atlantic-water-flow/
        */
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            int rl = heights.Length;
            int cl = heights[0].Length;
            bool[,] pacf = new bool[rl, cl];
            bool[,] atla = new bool[rl, cl];
            List<IList<int>> results = new();
            //top and bottom same loop one at the begin = 0 and the end  = rl-1 
            for (int i = 0; i < heights[0].Length; i++)
            {
                searcher(0, i, heights, pacf, heights[0][i]);
                searcher(rl - 1, i, heights, atla, heights[rl - 1][i]);
            }

            for (int i = 0; i < heights.Length; i++)
            {
                searcher(i, 0, heights, pacf, heights[i][0]);
                searcher(i, cl - 1, heights, atla, heights[i][cl - 1]);
            }

            for (int i = 0; i < heights.Length; i++)
            {
                for (int j = 0; j < heights[0].Length; j++)
                {
                    if (pacf[i, j] && atla[i, j])
                    {
                        results.Add(new List<int> { i, j });
                    }
                }
            }

            void searcher(int row, int col, int[][] heights, bool[,] visited, int prev)
            {
                if (row < 0 || col < 0 || row >= rl || col >= cl || visited[row, col] == true || heights[row][col] < prev)
                    return;

                visited[row, col] = true;

                searcher(row + 1, col, heights, visited, heights[row][col]);
                searcher(row - 1, col, heights, visited, heights[row][col]);
                searcher(row, col + 1, heights, visited, heights[row][col]);
                searcher(row, col - 1, heights, visited, heights[row][col]);
            }
            return results;
        }
        #endregion
        #region Surrounded Regions
        /*
        Given an m x n matrix board containing 'X' and 'O', capture all regions that are 4-directionally surrounded by 'X'.
        A region is captured by flipping all 'O's into 'X's in that surrounded region.

        

        Example 1:
        Input: board = [["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]
        Output: [["X","X","X","X"],["X","X","X","X"],["X","X","X","X"],["X","O","X","X"]]
        Explanation: Notice that an 'O' should not be flipped if:
        - It is on the border, or
        - It is adjacent to an 'O' that should not be flipped.
        The bottom 'O' is on the border, so it is not flipped.
        The other three 'O' form a surrounded region, so they are flipped.

        Example 2:
        Input: board = [["X"]]
        Output: [["X"]]

        Constraints:
            m == board.length
            n == board[i].length
            1 <= m, n <= 200
            board[i][j] is 'X' or 'O'.

        */
        public void Solve(char[][] board)
        {
            int rl = board.Length;
            int cl = board[0].Length;

            for (int i = 0; i < rl; i++)
            {
                if (board[i][0] == 'O' || board[i][cl - 1] == 'O')
                {
                    searcher(i, 0, board);
                    searcher(i, cl - 1, board);
                }
            }

            for (int i = 0; i < cl; i++)
            {
                if (board[0][i] == 'O' || board[rl - 1][i] == 'O')
                {
                    searcher(0, i, board);
                    searcher(rl - 1, i, board);
                }
            }


            void searcher(int r, int c, char[][] board)
            {
                if (r < 0 || r >= rl || c < 0 || c >= cl)
                    return;

                if (board[r][c] == 'X' || board[r][c] == 'T')
                    return;

                board[r][c] = 'T';
                searcher(r + 1, c, board);
                searcher(r - 1, c, board);
                searcher(r, c + 1, board);
                searcher(r, c - 1, board);
            }

            for (int i = 0; i < rl; i++)
            {
                for (int j = 0; j < cl; j++)
                {
                    if (board[i][j] == 'O')
                        board[i][j] = 'X';
                }
            }

            for (int i = 0; i < rl; i++)
            {
                for (int j = 0; j < cl; j++)
                {
                    if (board[i][j] == 'T')
                        board[i][j] = 'O';
                }
            }
        }
        public void SolveNeet(char[][] board)
        {
            var n = board.Length;

            if (n == 0) return;
            var m = board[0].Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i == 0 || j == 0 || i == n - 1 || j == m - 1) && board[i][j] == 'O')
                    {
                        CaptureDfs(board, i, j);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (board[i][j] == 'O')
                    {
                        board[i][j] = 'X';
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (board[i][j] == 'T')
                    {
                        board[i][j] = 'O';
                    }
                }
            }
        }

        private void CaptureDfs(char[][] board, int x, int y)
        {
            var n = board.Length;
            var m = board[0].Length;

            if (x >= n || x < 0 || y >= m || y < 0)
            {
                return;
            }

            if (board[x][y] == 'T' || board[x][y] == 'X') return;

            board[x][y] = 'T';
            CaptureDfs(board, x + 1, y);
            CaptureDfs(board, x - 1, y);
            CaptureDfs(board, x, y + 1);
            CaptureDfs(board, x, y - 1);

        }
        #endregion
        #region Rotting Oranges
        /*
        grid = [[0]] 304 / 306 testcases passed
        */
        public int OrangesRotting(int[][] grid)
        {
            int[] dr = { 0, 0, -1, 1 };
            int[] dc = { 1, -1, 0, 0 };
            int fresh = 0;
            int time = 0;
            if (grid == null || grid[0].Length == 0)
                return 0;

            Queue<(int i, int j)> myq = new();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                        fresh++;
                    else if (grid[i][j] == 2)
                        myq.Enqueue((i, j));
                }
            }

            if (fresh == 0)
                return 0;

            while (myq.Count > 0)
            {

                time++;
                int qsize = myq.Count;
                for (int y = 0; y < qsize; y++)
                {
                    (int tr, int tc) = myq.Dequeue();
                    for (int x = 0; x < 4; x++)
                    {
                        int er = dr[x] + tr;
                        int ec = dc[x] + tc;

                        if (er >= 0 && er < grid.Length && ec >= 0 && ec < grid[0].Length && grid[er][ec] == 1)
                        {
                            grid[er][ec] = 2;
                            myq.Enqueue((er, ec));
                            fresh--;
                        }
                    }
                }

            }

            return fresh == 0 ? time - 1 : -1;
        }
        #endregion
        #region Course Schedule
        /*
        There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] 
        indicates that you must take course bi first if you want to take course ai.
        For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.

        Return true if you can finish all courses. Otherwise, return false.

        Example 1:
        Input: numCourses = 2, prerequisites = [[1,0]]
        Output: true
        Explanation: There are a total of 2 courses to take. 
        To take course 1 you should have finished course 0. So it is possible.

        Example 2:
        Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
        Output: false
        Explanation: There are a total of 2 courses to take. 
        To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.

        Constraints:

            1 <= numCourses <= 2000
            0 <= prerequisites.length <= 5000
            prerequisites[i].length == 2
            0 <= ai, bi < numCourses
            All the pairs prerequisites[i] are unique.

        https://leetcode.com/problems/course-schedule/
        Test Cases:
        numCourses = 5
        prerequisites = [[1,4],[2,4],[3,1],[3,2]]
        numCourses = 8   46 / 52 testcases passed
        prerequisites = [[1,0],[2,6],[1,7],[6,4],[7,0],[0,5]]
        numCourses = 100 48 / 52 testcases passed
        prerequisites = [[1,0],[2,0],[2,1],[3,1],[3,2],[4,2],[4,3],[5,3],[5,4],[6,4],[6,5],
        [7,5],[7,6],[8,6],[8,7],[9,7],[9,8],[10,8],[10,9],[11,9],[11,10],[12,10],[12,11],
        [13,11],[13,12],[14,12],[14,13],[15,13],[15,14],[16,14],[16,15],[17,15],[17,16],
        [18,16],[18,17],[19,17],[19,18],[20,18],[20,19],[21,19],[21,20],[22,20],[22,21],
        [23,21],[23,22],[24,22],[24,23],[25,23],[25,24],[26,24],[26,25],[27,25],[27,26],
        [28,26],[28,27],[29,27],[29,28],[30,28],[30,29],[31,29],[31,30],[32,30],[32,31],
        [33,31],[33,32],[34,32],[34,33],[35,33],[35,34],[36,34],[36,35],[37,35],[37,36],
        [38,36],[38,37],[39,37],[39,38],[40,38],[40,39],[41,39],[41,40],[42,40],[42,41],
        [43,41],[43,42],[44,42],[44,43],[45,43],[45,44],[46,44],[46,45],[47,45],[47,46],
        [48,46],[48,47],[49,47],[49,48],[50,48],[50,49],[51,49],[51,50],[52,50],[52,51],
        [53,51],[53,52],[54,52],[54,53],[55,53],[55,54],[56,54],[56,55],[57,55],[57,56],
        [58,56],[58,57],[59,57],[59,58],[60,58],[60,59],[61,59],[61,60],[62,60],[62,61],
        [63,61],[63,62],[64,62],[64,63],[65,63],[65,64],[66,64],[66,65],[67,65],[67,66],
        [68,66],[68,67],[69,67],[69,68],[70,68],[70,69],[71,69],[71,70],[72,70],[72,71],
        [73,71],[73,72],[74,72],[74,73],[75,73],[75,74],[76,74],[76,75],[77,75],[77,76],
        [78,76],[78,77],[79,77],[79,78],[80,78],[80,79],[81,79],[81,80],[82,80],[82,81],
        [83,81],[83,82],[84,82],[84,83],[85,83],[85,84],[86,84],[86,85],[87,85],[87,86],
        [88,86],[88,87],[89,87],[89,88],[90,88],[90,89],[91,89],[91,90],[92,90],[92,91],
        [93,91],[93,92],[94,92],[94,93],[95,93],[95,94],[96,94],[96,95],[97,95],[97,96],[98,96],[98,97],[99,97]]
        */
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> mdict = new();

            for (int i = 0; i < numCourses; i++)
            {
                mdict[i] = new List<int>();
            }

            for (int i = 0; i < prerequisites.Length; i++)
            {
                int ToTake = prerequisites[i][0];
                int ToDepend = prerequisites[i][1];

                mdict[ToTake].Add(ToDepend);
            }
            HashSet<int> visited = new();
            foreach (var item in mdict)
            {
                if (!dfs(mdict, visited, item.Key))
                    return false;
            }
            return true;

            bool dfs(Dictionary<int, List<int>> preq, HashSet<int> vis, int curs)
            {
                if (vis.Contains(curs))
                    return false;

                if (preq[curs] == new List<int>())
                    return true;

                vis.Add(curs);
                foreach (var elo in preq[curs])
                {
                    if (!dfs(preq, vis, elo))
                        return false;
                }
                vis.Remove(curs);
                preq[curs] = new List<int>();

                return true;
            }
        }
        #endregion
        #region Course Schedule II
        /*
        There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] 
        indicates that you must take course bi first if you want to take course ai.For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
        Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them. If it is impossible to finish all courses, return an empty array.

        Example 1:
        Input: numCourses = 2, prerequisites = [[1,0]]
        Output: [0,1]
        Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1].

        Example 2:
        Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
        Output: [0,2,1,3]
        Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0.
        So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].

        Example 3:
        Input: numCourses = 1, prerequisites = []
        Output: [0]

        Constraints:

            1 <= numCourses <= 2000
            0 <= prerequisites.length <= numCourses * (numCourses - 1)
            prerequisites[i].length == 2
            0 <= ai, bi < numCourses
            ai != bi
            All the pairs [ai, bi] are distinct.

        Test Cases:
        numCourses = 2 43 / 45 testcases passed
        prerequisites = []
        https://leetcode.com/problems/course-schedule-ii/
        */
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {

            Dictionary<int, List<int>> mdict = new();
            HashSet<int> visited = new();
            HashSet<int> cycle = new();
            List<int> results = new();

            for (int i = 0; i < numCourses; i++)
            {
                mdict[i] = new List<int>();
            }

            for (int i = 0; i < prerequisites.Length; i++)
            {
                int ToTake = prerequisites[i][0];
                int ToDepend = prerequisites[i][1];

                mdict[ToTake].Add(ToDepend);
            }


            foreach (var item in mdict)
            {
                if (!dfs(mdict, visited, cycle, item.Key))
                    return new int[0];
            }
            bool dfs(Dictionary<int, List<int>> preq, HashSet<int> vis, HashSet<int> cycle, int curs)
            {
                if (vis.Contains(curs))
                    return false;

                if (preq[curs] == new List<int>())
                    return true;

                if (cycle.Contains(curs))
                    return true;

                vis.Add(curs);
                cycle.Add(curs);

                foreach (var elo in preq[curs])
                {
                    if (!dfs(preq, vis, cycle, elo))
                        return false;
                }
                vis.Remove(curs);
                results.Add(curs);
                preq[curs] = new List<int>();
                return true;
            }

            return results.ToArray();
        }
        #endregion
    }
}