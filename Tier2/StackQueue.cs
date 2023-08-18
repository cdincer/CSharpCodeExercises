using System.Collections.Generic;

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
        //Template below which is in java supposed to solve this proble.
        /**
        * Return the length of the shortest path between root and target node.
        */
        // int BFS(Node root, Node target) {
        //     Queue<Node> queue;  // store all nodes which are waiting to be processed
        //     int step = 0;       // number of steps neeeded from root to current node
        //     // initialize
        //     add root to queue;
        //     // BFS
        //     while (queue is not empty) {
        //         // iterate the nodes which are already in the queue
        //         int size = queue.size();
        //         for (int i = 0; i < size; ++i) {
        //             Node cur = the first node in queue;
        //             return step if cur is target;
        //             for (Node next : the neighbors of cur) {
        //                 add next to queue;
        //             }
        //             remove the first node from queue;
        //         }
        //         step = step + 1;
        //     }
        //     return -1;          // there is no path from root to target
        // }
        #endregion
        #endregion
        #endregion
    }
}