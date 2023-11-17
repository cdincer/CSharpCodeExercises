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
        #endregion

    }
}