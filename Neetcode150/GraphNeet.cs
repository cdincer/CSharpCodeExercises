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
        #region Max Area of Island
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

        C# Sample Test Case 1:

        int[][] grid = new int[8][];
        grid[0] = new int[] {0,0,1,0,0,0,0,1,0,0,0,0,0};
        grid[1] = new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0};
        grid[2] = new int[] {0,1,1,0,1,0,0,0,0,0,0,0,0};
        grid[3] = new int[] {0,1,0,0,1,1,0,0,1,0,1,0,0};
        grid[4] = new int[] {0,1,0,0,1,1,0,0,1,1,1,0,0};
        grid[5] = new int[] {0,0,0,0,0,0,0,0,0,0,1,0,0};
        grid[6] = new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0};
        grid[7] = new int[] {0,0,0,0,0,0,0,1,1,0,0,0,0};

        */
        private static readonly int[][] directions2 = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0},
        new int[] {0, 1}, new int[] {0, -1}
    };

        public int MaxAreaOfIsland(int[][] grid)
        {
            int rl = grid.Length, cl = grid[0].Length;
            int area = 0;

            for (int r = 0; r < rl; r++)
            {
                for (int c = 0; c < cl; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        area = Math.Max(area, Dfs(grid, r, c));
                    }
                }
            }

            return area;
        }

        private int Dfs(int[][] grid, int r, int c)
        {
            if (r < 0 || c < 0 || r >= grid.Length ||
                c >= grid[0].Length || grid[r][c] == 0)
            {
                return 0;
            }

            grid[r][c] = 0;
            int res = 1;
            foreach (var dir in directions2)
            {
                res += Dfs(grid, r + dir[0], c + dir[1]);
            }
            return res;
        }

        int rl2 = 0;
        int cl2 = 0;

        int result = 0;
        public int MaxAreaOfIsland2(int[][] grid)
        {
            rl2 = grid.Length;
            cl2 = grid[0].Length;
            bool[,] visited = new bool[rl2, cl2];
            for (int r = 0; r < rl2; r++)
            {
                for (int c = 0; c < cl2; c++)
                {
                    if (grid[r][c] == 1 && !visited[r, c])
                    {
                        Dfs2(grid, r, c, visited, 0);
                    }
                }
            }


            return result;
        }

        public int Dfs2(int[][] grid, int r, int c, bool[,] visited, int current)
        {
            if (r >= rl2 || c >= cl2 || 0 > r || 0 > c || grid[r][c] == 0 || visited[r, c])
                return current;

            current++;

            visited[r, c] = true;

            current = Dfs2(grid, r + 1, c, visited, current);
            current = Dfs2(grid, r - 1, c, visited, current);
            current = Dfs2(grid, r, c + 1, visited, current);
            current = Dfs2(grid, r, c - 1, visited, current);

            result = Math.Max(current, result);

            return current;
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

        Extra Test Case:
        edges = [[2,3,4,14],[1,7,11],[1],[1,5,6,8],[4,9],[4],[2,10],[4,13],[5,12,16],[7],[2],[9,15],[8],[1],[12],[9]] 17 / 22 testcases passed
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
        #region Walls And Gates (sometimes can be named islandsAndTreasure)
        /*
        You are given a m×nm×n 2D grid initialized with these three possible values:
        -1 - A water cell that can not be traversed.
        0 - A treasure chest.
        INF - A land cell that can be traversed. We use the integer 2^31 - 1 = 2147483647 to represent INF.

        Fill each land cell with the distance to its nearest treasure chest.
         If a land cell cannot reach a treasure chest than the value should remain INF.
        Assume the grid can only be traversed up, down, left, or right.

        Example 1:
        Input: [
        [2147483647,-1,0,2147483647],
        [2147483647,2147483647,2147483647,-1],
        [2147483647,-1,2147483647,-1],
        [0,-1,2147483647,2147483647]
        ]

        Output: [
        [3,-1,0,1],
        [2,2,1,-1],
        [1,-1,2,-1],
        [0,-1,3,4]
        ]

        Example 2:
        Input: [
        [0,-1],
        [2147483647,2147483647]
        ]

        Output: [
        [0,-1],
        [1,2]
        ]

        Constraints:

            m == grid.length
            n == grid[i].length
            1 <= m, n <= 100
            grid[i][j] is one of {-1, 0, 2147483647}

            C# Sample Test Case:
            
        int[][] gridGraph = new int[][]
        {
        new int[] {2147483647,-1,0,2147483647},
        new int[] {2147483647,2147483647,2147483647,-1},
        new int[]  {2147483647,-1,2147483647,-1},
        new int[]  {0,-1,2147483647,2147483647}
        };
        
        https://neetcode.io/problems/islands-and-treasure
        */
        int[][] directions =
        {
            new int[] {1,0}, new int[] {-1,0},
            new int[] {0,1},new int[] {0,-1}
        };
        
        int INF = int.MaxValue;
        int rl = 0;
        int cl = 0;
        //2nd solution: Time complexity O((m * 2))^2
        public void islandsAndTreasureBfs(int[][] grid)
        {
            rl = grid.Length;
            cl = grid[0].Length;

            for (int r = 0; r < rl; r++)
            {
                for (int c = 0; c < cl; c++)
                {
                    if (grid[r][c] == INF)
                        grid[r][c] = bfs(grid, r, c);
                }
            }
        }


        public int bfs(int[][] grid, int r, int c)
        {
            Queue<(int, int)> que = new();
            que.Enqueue((r, c));
            bool[,] visit = new bool[rl, cl];
            visit[r, c] = true;
            int steps = 0;

            while (que.Count > 0)
            {
                int size = que.Count;
                for (int i = 0; i < size; i++)
                {
                    (int tr, int tc) = que.Dequeue();

                    if (grid[tr][tc] == 0) return steps;

                    foreach (int[] dir in directions)
                    {
                        int cr = tr + dir[0];
                        int cc = tc + dir[1];

                        if (cr >= 0 && cc >= 0 && rl > cr && cl > cc
                                   && !visit[cr, cc] && grid[cr][cc] != -1)
                        {
                            visit[cr, cc] = true;
                            que.Enqueue((cr, cc));
                        }
                    }
                }
                steps++;
            }
            return INF;
        }
        //3rd solution: Time complexity: O(m∗n) Memory Complexity: O(m∗n)
        public void islandsAndTreasureMultiSourceBfs(int[][] grid)
        {
            Queue<int[]> q = new Queue<int[]>();
            int rl = grid.Length;
            int cl = grid[0].Length;
            for (int i = 0; i < rl; i++)
            {
                for (int j = 0; j < cl; j++)
                {
                    if (grid[i][j] == 0) q.Enqueue(new int[] { i, j });
                }
            }

            if (q.Count == 0) return;

            int[][] dirs = 
            {
            new int[] { -1, 0 }, new int[] { 0, -1 },
            new int[] { 1, 0 }, new int[] { 0, 1 }
            };

            
            while (q.Count > 0)
            {
                int[] cur = q.Dequeue();
                int row = cur[0];
                int col = cur[1];
                foreach (int[] dir in dirs)
                {
                    int r = row + dir[0];
                    int c = col + dir[1];
                    if (r >= rl || c >= cl || r < 0 ||
                        c < 0 || grid[r][c] != int.MaxValue)
                    {
                        continue;
                    }
                    q.Enqueue(new int[] { r, c });

                    grid[r][c] = grid[row][col] + 1;
                }
            }
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
            for (int col = 0; col < heights[0].Length; col++)
            {
                searcher(0, col, heights, pacf, heights[0][col]);
                searcher(rl - 1, col, heights, atla, heights[rl - 1][col]);
            }

            for (int row = 0; row < heights.Length; row++)
            {
                searcher(row, 0, heights, pacf, heights[row][0]);
                searcher(row, cl - 1, heights, atla, heights[row][cl - 1]);
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

        Connect: A cell is connected to adjacent cells horizontally or vertically.
        Region: To form a region connect every 'O' cell.
        Surround: The region is surrounded with 'X' cells if you can connect the region with 'X' cells and none of the region cells are on the edge of the board.

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

            for (int r = 0; r < rl; r++)
            {
                if (board[r][0] == 'O' || board[r][cl - 1] == 'O')
                {
                    searcher(r, 0, board);
                    searcher(r, cl - 1, board);
                }
            }

            for (int c = 0; c < cl; c++)
            {
                if (board[0][c] == 'O' || board[rl - 1][c] == 'O')
                {
                    searcher(0, c, board);
                    searcher(rl - 1, c, board);
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

            for (int r = 0; r < rl; r++)
            {
                for (int c = 0; c < cl; c++)
                {
                    if (board[r][c] == 'O')
                        board[r][c] = 'X';
                    else if (board[r][c] == 'T')
                        board[r][c] = 'O';
                }
            }
        }
        public void SolveNeet(char[][] board)
        {
            int rl = board.Length;

            if (rl == 0) return;
            int cl = board[0].Length;

            for (int r = 0; r < rl; r++)
            {
                for (int c = 0; c < cl; c++)
                {
                    if ((r == 0 || c == 0 || r == rl - 1 || c == cl - 1) && board[r][c] == 'O')
                    {
                        CaptureDfs(board, r, c);
                    }
                }
            }

            for (int r = 0; r < rl; r++)
            {
                for (int c = 0; c < cl; c++)
                {
                    if (board[r][c] == 'O')
                    {
                        board[r][c] = 'X';
                    }
                }
            }

            for (int r = 0; r < rl; r++)
            {
                for (int c = 0; c < cl; c++)
                {
                    if (board[r][c] == 'T')
                    {
                        board[r][c] = 'O';
                    }
                }
            }
        }

        private void CaptureDfs(char[][] board, int r, int c)
        {
            int rl = board.Length;
            int cl = board[0].Length;

            if(r >= rl || c >= cl || 0 > r || 0 > c)
            {
                return;
            }

            if (board[r][c] == 'T' || board[r][c] == 'X') return;

            board[r][c] = 'T';
            CaptureDfs(board, r + 1, c);
            CaptureDfs(board, r - 1, c);
            CaptureDfs(board, r, c + 1);
            CaptureDfs(board, r, c - 1);

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
            Dictionary<int, List<int>> dict = new();

            for (int i = 0; i < numCourses; i++)
            {
                dict[i] = new List<int>();
            }

            for (int i = 0; i < prerequisites.Length; i++)
            {
                int toTake = prerequisites[i][0];
                int toDepend = prerequisites[i][1];

                dict[toTake].Add(toDepend);
            }
            HashSet<int> visited = new();
            foreach (var kvp in dict)
            {
                if (!dfs(dict, visited, kvp.Key))
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
                foreach (int elo in preq[curs])
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

                foreach (int elo in preq[curs])
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
        #region Redundant Connection
        /*
        In this problem, a tree is an undirected graph that is connected and has no cycles. You are given a graph that started as a tree with n nodes labeled from 1 to n, with one additional edge added. 
        The added edge has two different vertices chosen from 1 to n, and was not an edge that already existed. The graph is represented as an array edges of length n where edges[i] = [ai, bi] 
        indicates that there is an edge between nodes ai and bi in the graph. Return an edge that can be removed so that the resulting graph is a tree of n nodes. If there are multiple answers, return the answer that occurs last in the input.

        Example 1:
        Input: edges = [[1,2],[1,3],[2,3]]
        Output: [2,3]

        Example 2:
        Input: edges = [[1,2],[2,3],[3,4],[1,4],[1,5]]
        Output: [1,4]

        Constraints:

            n == edges.length
            3 <= n <= 1000
            edges[i].length == 2
            1 <= ai < bi <= edges.length
            ai != bi
            There are no repeated edges.
            The given graph is connected.

        Test Cases:
        [[20,24],[3,17],[17,20],[8,15],[14,17],[6,17],[15,23],[6,8],[15,19],[16,22],[7,9],[8,22],[2,4],[4,11],[22,25],[6,24],[13,19],[15,18],[1,9],[4,9],[4,19],[5,10],[4,21],[4,12],[5,6]]
        [[1,5],[1,4],[3,4],[2,3],[1,2]]
        [[2,3],[2,5],[1,5],[2,4],[1,4]]
        */
        public int[] FindRedundantConnection(int[][] edges)
        {
            int size = edges.Length;
            int[] roots = new int[size + 1];
            int[] ranks = new int[size + 1];

            for (int i = 0; i < size; i++)
            {
                roots[i] = i;
                ranks[i] = i;
            }

            foreach (var edge in edges)
            {
                if (!union(edge[0], edge[1]))
                    return new int[] { edge[0], edge[1] };
            }

            return new int[2];
            int find(int x)
            {
                if (x == roots[x])
                    return x;

                return roots[x] = find(roots[x]);
            }

            bool union(int x, int y)
            {
                int px = find(roots[x]);
                int py = find(roots[y]);

                if (px == py)
                    return false;

                if (ranks[px] > ranks[py])
                {
                    roots[py] = px;
                }
                else if (ranks[y] > ranks[x])
                {
                    roots[px] = py;
                }
                else
                {
                    roots[py] = px;
                    ranks[px]++;
                }

                return true;
            }
        }

        #endregion
        #region Word Ladder
        /*
        A transformation sequence from word beginWord to word endWord using a dictionary wordList is a sequence of words beginWord -> s1 -> s2 -> ... -> sk such that:
            Every adjacent pair of words differs by a single letter.
            Every si for 1 <= i <= k is in wordList. Note that beginWord does not need to be in wordList.
            sk == endWord

        Given two words, beginWord and endWord, and a dictionary wordList, return the number of words in the shortest transformation sequence from beginWord to endWord, or 0 if no such sequence exists.

        Example 1:
        Input: beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log","cog"]
        Output: 5
        Explanation: One shortest transformation sequence is "hit" -> "hot" -> "dot" -> "dog" -> cog", which is 5 words long.

        Example 2:
        Input: beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log"]
        Output: 0
        Explanation: The endWord "cog" is not in wordList, therefore there is no valid transformation sequence.

        Constraints:
            1 <= beginWord.length <= 10
            endWord.length == beginWord.length
            1 <= wordList.length <= 5000
            wordList[i].length == beginWord.length
            beginWord, endWord, and wordList[i] consist of lowercase English letters.
            beginWord != endWord
            All the words in wordList are unique.

        https://leetcode.com/problems/word-ladder/description/
        Test Cases:
        beginWord = "hot"
        endWord = "dog"
        wordList = ["hot","dog"] 48 / 51 testcases passed
        */
        //T: O(N^2*M) where N is the length of the word, M is total no. of words
        //S: O(N^2*M) where N is the length of the word, M is total no. of words
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord))
            {
                return 0;
            }

            Dictionary<string,HashSet<string>> nei = new ();

            if (!wordList.Contains(beginWord))
                wordList.Add(beginWord);

            foreach (string word in wordList)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    string pattern = word.Substring(0, j) + "*" + word.Substring(j + 1);
                    nei.TryAdd(pattern, new HashSet<string>());
                    nei[pattern].Add(word);
                }
            }

            HashSet<string> visited = new();
            visited.Add(beginWord);

            Queue<string> queue = new();
            queue.Enqueue(beginWord);

            int result = 1;

            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    string item = queue.Dequeue();
                    if (item == endWord)
                        return result;

                    for (int j = 0; j < item.Length; j++)
                    {
                        string pattern = item.Substring(0, j) + "*" + item.Substring(j + 1);
                        foreach (var neiWord in nei[pattern])
                        {
                            if (!visited.Contains(neiWord))
                            {
                                queue.Enqueue(neiWord);
                                visited.Add(neiWord);
                            }
                        }
                    }
                }
                result += 1;
            }

            return 0;
        }

        #endregion
        #region Graph Valid Tree
        /*
        Given n nodes labeled from 0 to n - 1 and a list of undirected edges (each edge is a pair of nodes),
         write a function to check whether these edges make up a valid tree.

        Example 1:
        Input:
        n = 5
        edges = [[0, 1], [0, 2], [0, 3], [1, 4]]

        Output:
        true

        Example 2:
        Input:
        n = 5
        edges = [[0, 1], [1, 2], [2, 3], [1, 3], [1, 4]]

        Output:
        false

        Note:
            You can assume that no duplicate edges will appear in edges. Since all edges are undirected, [0, 1] is the same as [1, 0] and thus will not appear together in edges.

        Constraints:

            1 <= n <= 100
            0 <= edges.length <= n * (n - 1) / 2


         https://neetcode.io/problems/valid-tree
        */
        public bool ValidTree(int n, int[][] edges)
        {
            if (edges.Length > n - 1)
            {
                return false;
            }

            List<List<int>> adj = new();

            for (int i = 0; i < n; i++)
            {
                adj.Add(new List<int>());
            }

            foreach (var edge in edges)
            {
                adj[edge[0]].Add(edge[1]);
                adj[edge[1]].Add(edge[0]);
            }

            HashSet<int> visit = new();

            if (!Dfs(0, -1, visit, adj))
            {
                return false;
            }

            return visit.Count == n;
        }

        private bool Dfs(int node, int parent, HashSet<int> visit,
        List<List<int>> adj)
        {
            if (visit.Contains(node))
                return false;

            visit.Add(node);

            foreach (var nei in adj[node])
            {
                if (nei == parent)
                {
                    continue;
                }

                if (!Dfs(nei, node, visit, adj))
                    return false;
            }

            return true;
        }
        #endregion
        #region Number of Connected Components in an Undirected Graph
        /*
        There is an undirected graph with n nodes. There is also an edges array, where edges[i] = [a, b]
         means that there is an edge between node a and node b in the graph.
        The nodes are numbered from 0 to n - 1.

        Return the total number of connected components in that graph.

        Example 1:
        Input:
        n=3
        edges=[[0,1], [0,2]]

        Output:
        1

        Example 2:
        Input:
        n=6
        edges=[[0,1], [1,2], [2,3], [4,5]]

        Output:
        2

        Constraints:
            1 <= n <= 100
            0 <= edges.length <= n * (n - 1) / 2

        */
        //https://neetcode.io/problems/count-connected-components        
    public int CountComponents(int n, int[][] edges)
        {
            Dictionary<int, List<int>> dict = new();

            for (int i = 0; i < n; i++)
            {
                dict.TryAdd(i, new List<int>());
            }

            for (int i = 0; i < edges.Length; i++)
            {
                int toSource = edges[i][0];
                int toDepend = edges[i][1];

                dict[toSource].Add(toDepend);
                dict[toDepend].Add(toSource);

            }

            HashSet<int> visited = new();
            int result = 0;
            foreach (var kvp in dict)
            {
                if (!visited.Contains(kvp.Key))
                {
                    travel(dict, visited, kvp.Key);
                    result++;
                }

            }

            return result;
        }

        public bool travel(Dictionary<int, List<int>> dict, HashSet<int> visited, int current)
        {
            if (visited.Contains(current))
                return false;

            visited.Add(current);

            foreach (int item in dict[current])
            {
                if (!visited.Contains(item))
                    travel(dict, visited, item);
            }
            
            return true;
        }
        #endregion
    }
}