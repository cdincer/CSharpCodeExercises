using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCodeExercises.Tier2
{
    public class StackQueue
    {
        //https://leetcode.com/explore/learn/card/queue-stack/
        #region Queue: First-in-first-out Data Structure
        #region Queue - Implementation


        #region Design Circular Queue
        /*
        Design your implementation of the circular queue. The circular queue is a linear data structure in which the operations are performed based on FIFO (First In First Out) principle, and the last position is connected back to the first position to make a circle. It is also called "Ring Buffer".

        One of the benefits of the circular queue is that we can make use of the spaces in front of the queue. In a normal queue, once the queue becomes full, we cannot insert the next element even if there is a space in front of the queue. But using the circular queue, we can use the space to store new values.

        Implement the MyCircularQueue class:

            MyCircularQueue(k) Initializes the object with the size of the queue to be k.
            int Front() Gets the front item from the queue. If the queue is empty, return -1.
            int Rear() Gets the last item from the queue. If the queue is empty, return -1.
            boolean enQueue(int value) Inserts an element into the circular queue. Return true if the operation is successful.
            boolean deQueue() Deletes an element from the circular queue. Return true if the operation is successful.
            boolean isEmpty() Checks whether the circular queue is empty or not.
            boolean isFull() Checks whether the circular queue is full or not.

        You must solve the problem without using the built-in queue data structure in your programming language. 

        

        Example 1:

        Input
        ["MyCircularQueue", "enQueue", "enQueue", "enQueue", "enQueue", "Rear", "isFull", "deQueue", "enQueue", "Rear"]
        [[3], [1], [2], [3], [4], [], [], [], [4], []]
        Output
        [null, true, true, true, false, 3, true, true, true, 4]

        Explanation
        MyCircularQueue myCircularQueue = new MyCircularQueue(3);
        myCircularQueue.enQueue(1); // return True
        myCircularQueue.enQueue(2); // return True
        myCircularQueue.enQueue(3); // return True
        myCircularQueue.enQueue(4); // return False
        myCircularQueue.Rear();     // return 3
        myCircularQueue.isFull();   // return True
        myCircularQueue.deQueue();  // return True
        myCircularQueue.enQueue(4); // return True
        myCircularQueue.Rear();     // return 4

        Extra Test Case:
        ["MyCircularQueue","enQueue","Rear","Rear","deQueue","enQueue","Rear","deQueue","Front","deQueue","deQueue","deQueue"]
        [[6],[6],[],[],[],[5],[],[],[],[],[],[]]
        ["MyCircularQueue","enQueue","enQueue","deQueue","enQueue","deQueue","enQueue","deQueue","enQueue","deQueue", "Front"]
        [[2],[1],[2],[],[3],[],[3],[],[3],[],[]]
        ["MyCircularQueue","enQueue","enQueue","Front","enQueue","deQueue","enQueue","enQueue","Rear","isEmpty","Front","deQueue"]
        [[2],[8],[8],[],[4],[],[1],[1],[],[],[],[]]
        ["MyCircularQueue","enQueue","enQueue","enQueue","enQueue","Front","isFull","deQueue","enQueue","Front"]
        [[1],[1],[2],[3],[4],[],[],[],[4],[]]
         https://leetcode.com/problems/design-circular-queue/description/
        */
        public class MyCircularQueue
        {
            int[] q;
            int front = 0;
            int rear = -1;
            int count = 0;

            public MyCircularQueue(int k)
            {
                q = new int[k];
            }

            public bool EnQueue(int value)
            {
                if (IsFull()) return false;
                count++;
                rear = (rear + 1) % q.Length;
                q[rear] = value;
                return true;
            }

            public bool DeQueue()
            {
                if (IsEmpty()) return false;
                count--;
                front = (front + 1) % q.Length;
                return true;
            }

            public int Front() => IsEmpty() ? -1 : q[front];

            public int Rear() => IsEmpty() ? -1 : q[rear];

            public bool IsEmpty() => count == 0;

            public bool IsFull() => count == q.Length;
        }

        #endregion

        #endregion
        #region Queue and BFS
        #region Number Of Islands
        /*
        Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.

        An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
        You may assume all four edges of the grid are all surrounded by water. 
        No diagonal connections ! That's why second one is 3 islands.

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
        //Templates in the link below which is in java supposed to solve this problem.
        //https://leetcode.com/explore/learn/card/queue-stack/231/practical-application-queue/1372/

        //Like many questions in Stack/Queue card many solutions are hidden by paywall.
        //This and many others will be from random sources.
        /* C# Test Cases:
            char[][] grid1 = new char[][]
            {
             new char[]{'1','1','1','1','0'},
             new char[]{'1','1','0','1','0'},
             new char[]{'1','1','0','0','0'},
             new char[]{'0','0','0','0','0'},
            };
        */
        public int NumIslands(char[][] grid)
        {
            int result = 0;
            int[] dx = new int[] { 1, -1, 0, 0 },
                  dy = new int[] { 0, 0, 1, -1 };

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[0].Length; j++)
                    if (grid[i][j] == '1')
                    {
                        result++;

                        Queue<int[]> queue = new Queue<int[]>();

                        queue.Enqueue(new int[] { i, j });
                        grid[i][j] = 'N';

                        while (queue.Count > 0)
                        {
                            int[] cur = queue.Dequeue();

                            for (int k = 0; k < 4; k++)
                            {
                                int newX = cur[0] + dx[k],
                                    newY = cur[1] + dy[k];
                                Console.WriteLine("Moved to with newX" + newX + " Moved to with newY " + newY);
                                if (newX > -1 && newX < grid.Length && newY > -1 && newY < grid[0].Length && grid[newX][newY] != 'N' && grid[newX][newY] != '0')
                                {
                                    queue.Enqueue(new int[] { newX, newY });
                                    grid[newX][newY] = 'N';
                                }
                            }
                        }
                    }

            return result;
        }

        #endregion
        #region Open the Lock
        /*
        You have a lock in front of you with 4 circular wheels. Each wheel has 10 slots: '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'. 
        The wheels can rotate freely and wrap around: for example we can turn '9' to be '0', or '0' to be '9'. Each move consists of turning one wheel one slot.

        The lock initially starts at '0000', a string representing the state of the 4 wheels.

        You are given a list of deadends dead ends, meaning if the lock displays any of these codes, the wheels of the lock will stop turning and you will be unable to open it.

        Given a target representing the value of the wheels that will unlock the lock, return the minimum total number of turns required to open the lock, or -1 if it is impossible.

        Example 1:

        Input: deadends = ["0201","0101","0102","1212","2002"], target = "0202"
        Output: 6
        Explanation: 
        A sequence of valid moves would be "0000" -> "1000" -> "1100" -> "1200" -> "1201" -> "1202" -> "0202".
        Note that a sequence like "0000" -> "0001" -> "0002" -> "0102" -> "0202" would be invalid,
        because the wheels of the lock become stuck after the display becomes the dead end "0102".

        Example 2:

        Input: deadends = ["8888"], target = "0009"
        Output: 1
        Explanation: We can turn the last wheel in reverse to move from "0000" -> "0009".

        Example 3:

        Input: deadends = ["8887","8889","8878","8898","8788","8988","7888","9888"], target = "8888"
        Output: -1
        Explanation: We cannot reach the target without getting stuck.

        Constraints:

            1 <= deadends.length <= 500
            deadends[i].length == 4
            target.length == 4
            target will not be in the list deadends.
            target and deadends[i] consist of digits only.

        https://leetcode.com/problems/open-the-lock/

        Hint:
        We can think of this problem as a shortest path problem on a graph: there are `10000` nodes (strings `'0000'` to `'9999'`), 
        and there is an edge between two nodes if they differ in one digit, 
        that digit differs by 1 (wrapping around, so `'0'` and `'9'` differ by 1), and if *both* nodes are not in `deadends`.
        */
        public int OpenLock(string[] deadends, string target)
        {
            //model the lock number as a graph problem;
            //use BFS to find the shortest path to the target;
            //while check the new combinations in the deadend list or not;
            HashSet<string> deadlist = new HashSet<string>();
            HashSet<string> visited = new HashSet<string>();
            foreach (string dead in deadends)
                deadlist.Add(dead);

            if (deadlist.Contains("0000"))
                return -1;

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("0000");
            visited.Add("0000");
            int rounds = 0;
            while (queue.Any())
            {
                for (int k = queue.Count; k > 0; k--)
                {
                    string node = queue.Dequeue();
                    if (node == target)
                        return rounds;


                    //each char can increase 1 or decrease 1;
                    //if 0 decrease 1 it will become 9;
                    //if 9 increase 1 it will become 0;
                    for (int i = 0; i < 4; i++)
                    {
                        char[] arr = node.ToCharArray();
                        char t = arr[i];
                        int num = t - '0' + 1;
                        if (num > 9)
                            num = 0;
                        arr[i] = (char)(num + '0');

                        string lockcomb = new string(arr);
                        if (!deadlist.Contains(lockcomb) && !visited.Contains(lockcomb))
                        {
                            queue.Enqueue(lockcomb);
                            visited.Add(lockcomb);
                        }
                        num = t - '0' - 1;
                        if (num < 0)
                            num = 9;
                        arr[i] = (char)(num + '0');
                        lockcomb = new string(arr);
                        if (!deadlist.Contains(lockcomb) && !visited.Contains(lockcomb))
                        {
                            queue.Enqueue(lockcomb);
                            visited.Add(lockcomb);
                        }
                    }


                }
                rounds++;

            }

            return -1;
        }
        #endregion
        #endregion
        #endregion
    }
}