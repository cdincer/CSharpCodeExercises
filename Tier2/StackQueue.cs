using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Tier2.BinaryTree;

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

            Adding for perspective(August 24,2023) Even with O(n) runtime 
            Runtime:88 ms Beats 99.90% Memory: 51.7 MB Beats: 25.61%
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
                                if (newX > -1
                                 && newX < grid.Length
                                 && newY > -1
                                 && newY < grid[0].Length
                                 && grid[newX][newY] != 'N'
                                 && grid[newX][newY] != '0')
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
        Test Cases For Easy Copy/Paste
        ["0201","0101","0102","1212","2002"]
        "0202"
        ["8888"]
        "0009"
        ["8887","8889","8878","8898","8788","8988","7888","9888"]
        "8888"
        ["0000"]
        "8888"
        
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
        #region Perfect Squares
        /*
        Given an integer n, return the least number of perfect square numbers that sum to n.
        A perfect square is an integer that is the square of an integer; in other words, it is the product of some integer with itself. For example, 1, 4, 9, and 16 are perfect squares while 3 and 11 are not.

        Example 1:

        Input: n = 12
        Output: 3
        Explanation: 12 = 4 + 4 + 4.

        Example 2:

        Input: n = 13
        Output: 2
        Explanation: 13 = 4 + 9.

        Constraints:

            1 <= n <= 10^4

        https://leetcode.com/problems/perfect-squares/
        */
        public int NumSquares(int n)
        {
            var squareNumbers = new List<int>();
            for (int i = 1; i * i <= n; i++)
                squareNumbers.Add(i * i);

            var q = new Queue<int>();
            q.Enqueue(n);

            int level = 0;
            while (q.Count > 0)
            {
                level++;
                var nq = new Queue<int>();
                while (q.Count > 0)
                {
                    int rem = q.Dequeue();
                    foreach (int square in squareNumbers)
                    {
                        if (rem == square)
                            return level;
                        else if (rem < square)
                            break;
                        else
                            nq.Enqueue(rem - square);
                    }
                }
                q = nq;
            }

            return level;
        }
        #endregion
        #endregion
        #region Stack: Last-in-first-out Data Structure
        #region Min Stack
        /*
        Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

        Implement the MinStack class:

            MinStack() initializes the stack object.
            void push(int val) pushes the element val onto the stack.
            void pop() removes the element on the top of the stack.
            int top() gets the top element of the stack.
            int getMin() retrieves the minimum element in the stack.

        !!!You must implement a solution with O(1) time complexity for each function.!!!     

        Example 1:

        Input
        ["MinStack","push","push","push","getMin","pop","top","getMin"]
        [[],[-2],[0],[-3],[],[],[],[]]

        Output
        [null,null,null,null,-3,null,0,-2]

        Explanation
        MinStack minStack = new MinStack();
        minStack.push(-2);
        minStack.push(0);
        minStack.push(-3);
        minStack.getMin(); // return -3
        minStack.pop();
        minStack.top();    // return 0
        minStack.getMin(); // return -2

        Constraints:

            -231 <= val <= 231 - 1
            Methods pop, top and getMin operations will always be called on non-empty stacks.
            At most 3 * 104 calls will be made to push, pop, top, and getMin.

        https://leetcode.com/problems/min-stack/

        Explanation:
            
        Initialize 2 stacks a normal stack and a stack to track a minimum value.
        On Push(), if minimumStack is not empty, check the top min value and if it is greater or equal to the new coming in, then push new value as new min on top of the minimumstack and then push value to original stack.
        On Pop(), get the popped value if it is equal to the top of minimumStack then pop from both.
        On Top(), Peek the top value from the stack.
        On GetMin(), peek the top value from minimumStack.

        Complexity
        Time complexity: O(1)
        Space complexity: O(n)

        Runtime values at 2023-08-25
        Runtime : 106ms Beats 96.63%of users with C# Memory:50.86MB Beats 77.20%of users with C#
        */
        public class MinStack
        {
            Stack<int> stack = null;
            Stack<int> minimumStack = null;
            public MinStack()
            {
                stack = new Stack<int>();
                minimumStack = new Stack<int>();
            }

            public void Push(int val)
            {
                if (minimumStack.Count > 0)
                {
                    int minimumValue = minimumStack.Peek();
                    if (minimumValue >= val)
                    {
                        minimumStack.Push(val);
                    }
                }
                else
                {
                    minimumStack.Push(val);
                }
                stack.Push(val);
            }

            public void Pop()
            {
                int val = 0;
                val = stack.Pop();
                if (minimumStack.Count > 0 && val == minimumStack.Peek())
                {
                    minimumStack.Pop();
                }
            }

            public int Top()
            {
                return stack.Peek();
            }

            public int GetMin()
            {
                return minimumStack.Peek();
            }
        }
        #endregion
        #region Valid Parentheses
        /*
        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

        An input string is valid if:

            Open brackets must be closed by the same type of brackets.
            Open brackets must be closed in the correct order.
            Every close bracket has a corresponding open bracket of the same type.

        Example 1:

        Input: s = "()"
        Output: true

        Example 2:

        Input: s = "()[]{}"
        Output: true

        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

            1 <= s.length <= 104
            s consists of parentheses only '()[]{}'.

        https://leetcode.com/problems/valid-parentheses/
        Test Cases:
         "]"
        "){"
        "()[]{}"
        "(]"
        */
        //No official solution it's behind paywall.
        public bool IsValid1(string s)
        {
            Stack<char> items = new Stack<char>();

            if (s.Length == 1 || s.Length == 0)
                return false;

            for (int i = 0; i < s.Length; i++)
            {
                char TobeUsed = 'a';
                switch (s[i])
                {
                    case '[':
                        items.Push(']');
                        break;
                    case '(':
                        items.Push(')');
                        break;
                    case '{':
                        items.Push('}');
                        break;
                    case ']':
                        if (items.Count > 0)
                            TobeUsed = items.Pop();
                        else
                            return false;

                        if (TobeUsed != s[i])
                            return false;
                        break;
                    case ')':
                        if (items.Count > 0)
                            TobeUsed = items.Pop();
                        else
                            return false;

                        if (TobeUsed != s[i])
                            return false;
                        break;
                    case '}':
                        if (items.Count > 0)
                            TobeUsed = items.Pop();
                        else
                            return false;

                        if (TobeUsed != s[i])
                            return false;
                        break;
                    default:
                        break;
                }
            }

            if (items.Count > 0)
                return false;

            return true;
        }
        //Faster cleaner option
        public bool IsValid2(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> dict = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
        };

            foreach (var c in s)
            {
                if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count > 0 && dict[stack.Peek()] != c || stack.Count == 0)
                    {
                        return false;
                    }

                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }

            return stack.Count == 0;
        }
        #endregion
        #region Daily Temperatures
        /*
        Given an array of integers temperatures represents the daily temperatures, return an array answer such that answer[i] is the number of days you have to wait after the ith day to get a warmer temperature. 
        If there is no future day for which this is possible, keep answer[i] == 0 instead.

        Example 1:

        Input: temperatures = [73,74,75,71,69,72,76,73]
        Output: [1,1,4,2,1,1,0,0]

        Example 2:

        Input: temperatures = [30,40,50,60]
        Output: [1,1,1,0]

        Example 3:

        Input: temperatures = [30,60,90]
        Output: [1,1,0]

        Constraints:

            1 <= temperatures.length <= 105
            30 <= temperatures[i] <= 100

        https://leetcode.com/problems/daily-temperatures/
        */
        public int[] DailyTemperatures(int[] T)
        {
            if (T == null || T.Length == 0)
                return new int[] { };

            Stack<int[]> stack = new Stack<int[]>();
            int[] result = new int[T.Length];

            for (int i = 0; i < T.Length; i++)
            {
                while (stack.Count > 0 && stack.Peek()[0] < T[i])
                {
                    result[stack.Peek()[1]] = i - stack.Peek()[1];
                    stack.Pop();
                }

                stack.Push(new int[] { T[i], i });
            }

            return result;
        }
        #endregion
        #region Evaluate Reverse Polish Notation
        /*
        You are given an array of strings tokens that represents an arithmetic expression in a Reverse Polish Notation.
        Evaluate the expression. Return an integer that represents the value of the expression.
        Note that:

            The valid operators are '+', '-', '*', and '/'.
            Each operand may be an integer or another expression.
            The division between two integers always truncates toward zero.
            There will not be any division by zero.
            The input represents a valid arithmetic expression in a reverse polish notation.
            The answer and all the intermediate calculations can be represented in a 32-bit integer.

        Example 1:

        Input: tokens = ["2","1","+","3","*"]
        Output: 9
        Explanation: ((2 + 1) * 3) = 9

        Example 2:

        Input: tokens = ["4","13","5","/","+"]
        Output: 6
        Explanation: (4 + (13 / 5)) = 6

        Example 3:

        Input: tokens = ["10","6","9","3","+","-11","*","/","*","17","+","5","+"]
        Output: 22
        Explanation: ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
        = ((10 * (6 / (12 * -11))) + 17) + 5
        = ((10 * (6 / -132)) + 17) + 5
        = ((10 * 0) + 17) + 5
        = (0 + 17) + 5
        = 17 + 5
        = 22

        

        Constraints:

            1 <= tokens.length <= 104
            tokens[i] is either an operator: "+", "-", "*", or "/", or an integer in the range [-200, 200].
        
        Test Cases:
        ["2","1","+","3","*"]
        ["4","13","5","/","+"]
        ["10","6","9","3","+","-11","*","/","*","17","+","5","+"]
        ["2"]
        */

        //Custom solution below:
        /*
        Stats on 2023-08-30
        Runtime: 82 ms Beats 77.99% Memory: 40.4 MB Beats:73.48%
        */
        public int EvalRPN(string[] tokens)
        {
            Stack<int> items = new Stack<int>();
            int Result = 0;
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "+" || tokens[i] == "-" || tokens[i] == "*" || tokens[i] == "/")
                {

                    int B = 0;
                    int A = 0;
                    if (items.Count > 1)
                    {
                        B = items.Pop();
                        A = items.Pop();//Result
                    }
                    else
                    {
                        B = items.Pop();
                        A = Result;
                    }


                    switch (tokens[i])
                    {
                        case "+":
                            Result = A + B;
                            break;
                        case "-":
                            Result = A - B;
                            break;
                        case "*":
                            Result = A * B;
                            break;
                        case "/":
                            Result = A / B;
                            break;
                        default:
                            break;
                    }
                    items.Push(Result);
                }
                else
                {
                    items.Push(int.Parse(tokens[i]));
                }
            }

            return items.Pop();
        }
        #endregion
        #endregion
        #region Stack and DFS
        /*
        Depth-First Search template for Stack. It was offered as a solution for the upcoming problems.
        https://leetcode.com/explore/learn/card/queue-stack/232/practical-application-stack/1384/
        */
        #region Number Of Islands (Stack Version)
        /*
        Number of Islands Stack Version
        Like the previous ones the official solution is behind a paywall.
        As a result,I had to look through submissions. Not a single promising one.
        Some of them looked like the Queue version solution. So I just mine to Stack.
        A bit slower but still works. At best it's stat was like below:
        For 2023-08-31 
        Runtime: 107 ms Beats: 80.28% Memory: 52.3 MB Beats: 23.13%
        */
        public int NumIslandsStack(char[][] grid)
        {
            int[] dx = new int[] { 1, -1, 0, 0 };
            int[] dy = new int[] { 0, 0, 1, -1 };
            int NumOfIslands = -1;
            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        NumOfIslands++;
                        Stack<int[]> visited = new Stack<int[]>();
                        visited.Push(new int[] { i, j });

                        grid[i][j] = 'N';

                        while (visited.Count > 0)
                        {
                            int[] current = visited.Pop();
                            for (int k = 0; k < 4; k++)
                            {
                                int newX = current[0] + dx[k];
                                int newY = current[1] + dy[k];
                                if (newX > -1
                                   && newX < grid.Length
                                   && newY > -1
                                   && newY < grid[0].Length
                                   && grid[newX][newY] == '1')
                                {
                                    visited.Push(new int[] { newX, newY });
                                    grid[newX][newY] = 'N';
                                }
                            }
                        }

                    }

                }

            return NumOfIslands + 1;
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
        For simplicity, each node's value is the same as the node's index (1-indexed). 
        For example, the first node with val == 1, the second node with val == 2, and so on. 
        The graph is represented in the test case using an adjacency list.
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

        C# Only Test Case Equal to First Graph shown on page:
        Node nodeOne = new Node(1);Node nodeTwo = new Node(2);
        Node nodeThree = new Node(3);Node nodeFour = new Node(4);
        nodeOne.neighbors.Add(nodeTwo);nodeOne.neighbors.Add(nodeFour);
        nodeTwo.neighbors.Add(nodeOne);nodeTwo.neighbors.Add(nodeThree);
        nodeThree.neighbors.Add(nodeTwo);nodeThree.neighbors.Add(nodeFour);
        nodeFour.neighbors.Add(nodeOne);nodeFour.neighbors.Add(nodeThree);

        https://leetcode.com/problems/clone-graph/
        */

        //Same as others official solution hidden behind a paywall
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
        public Node CloneGraph(Node node)
        {
            if (node == null)
                return null;
            var resut = new Node
            {
                val = node.val,
                neighbors = node.neighbors == null ? null : new List<Node>(node.neighbors.Count)
            };

            var map = new Dictionary<Node, Node>(); //Maintain a list to not work on duplicated items 
                                                    //and use their neighbours.
            var stack = new Stack<Node>();
            stack.Push(node);
            map.Add(node, resut);

            while (stack.Count > 0)
            {
                var item = stack.Pop();
                var clone = map[item]; // Match original and the brand new one.
                if (item.neighbors != null)
                    foreach (var child in item.neighbors)
                    {
                        if (!map.TryGetValue(child, out var cc))
                        {
                            cc = new Node
                            {
                                val = child.val,
                                neighbors = child.neighbors == null ? null : new List<Node>(child.neighbors.Count)
                            };
                            //Keep inserting here to only put unique ones in Stack and maintain our unique list in dictionary.
                            map.Add(child, cc); //Add the originals and the brand new ones for processing.
                            stack.Push(child); //Push the originals here and to use them next.
                        }
                        clone.neighbors.Add(cc); // Fill up the neighbors here using the stack original ones.
                    }
            }

            return resut;
        }
        #endregion
        #region Target Sum
        /*
        You are given an integer array nums and an integer target.

        You want to build an expression out of nums by adding one of the symbols '+' and '-' before each integer in nums and then concatenate all the integers.

            For example, if nums = [2, 1], you can add a '+' before 2 and a '-' before 1 and concatenate them to build the expression "+2-1".

        Return the number of different expressions that you can build, which evaluates to target.

        Example 1:

        Input: nums = [1,1,1,1,1], target = 3
        Output: 5
        Explanation: There are 5 ways to assign symbols to make the sum of nums be target 3.
        -1 + 1 + 1 + 1 + 1 = 3
        +1 - 1 + 1 + 1 + 1 = 3
        +1 + 1 - 1 + 1 + 1 = 3
        +1 + 1 + 1 - 1 + 1 = 3
        +1 + 1 + 1 + 1 - 1 = 3

        Example 2:

        Input: nums = [1], target = 1
        Output: 1

        Constraints:

            1 <= nums.length <= 20
            0 <= nums[i] <= 1000
            0 <= sum(nums[i]) <= 1000
            -1000 <= target <= 1000

        https://leetcode.com/problems/target-sum/description/
        */
        /*Where is the stack for this solution ? Here is their explanation from card for DFS Template 1 in stack section.
        "It seems like we don't have to use any stacks when we implement DFS recursively. But actually, we are using the implicit stack provided by the system, also known as the Call Stack."
        **Source: https://leetcode.com/explore/learn/card/queue-stack/232/practical-application-stack/1384/
        As a result another card without official solution using stack or any official solution at all.
        */
        public int FindTargetSumWays(int[] nums, int S)
        {
            int count = 0;
            Dfs(0, 0);
            return count;

            void Dfs(int currSum, int index)
            {
                if (index == nums.Length)
                {
                    if (currSum == S)
                        count++;
                    return;
                }
                Dfs(currSum + nums[index], index + 1);
                Dfs(currSum - nums[index], index + 1);
            }
        }
        #endregion
        #region Binary Tree Inorder Traversal
        /*
        Given the root of a binary tree, return the inorder traversal of its nodes' values.

        Example 1:

        Input: root = [1,null,2,3]
        Output: [1,3,2]

        Example 2:

        Input: root = []
        Output: []

        Example 3:

        Input: root = [1]
        Output: [1]

        Constraints:

            The number of nodes in the tree is in the range [0, 100].
            -100 <= Node.val <= 100

        Follow up: Recursive solution is trivial, could you do it iteratively?
        https://leetcode.com/problems/binary-tree-inorder-traversal/description/
        */
        //Copy pasted the answer from BinaryTree one, this is how it was done there too.
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> res = new();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode curr = root;
            while (curr != null || stack.Count != 0)
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }
                curr = stack.Pop();
                res.Add(curr.val);
                curr = curr.right;
            }
            return res;
        }
        #endregion

        #endregion
        #region Conclusion
        #region Implement Queue using Stacks
        /*
        Implement a first in first out (FIFO) queue using only two stacks. The implemented queue should support all the functions of a normal queue (push, peek, pop, and empty).

        Implement the MyQueue class:

            void push(int x) Pushes element x to the back of the queue.
            int pop() Removes the element from the front of the queue and returns it.
            int peek() Returns the element at the front of the queue.
            boolean empty() Returns true if the queue is empty, false otherwise.

        Notes:

            You must use only standard operations of a stack, which means only push to top, peek/pop from top, size, and is empty operations are valid.
            Depending on your language, the stack may not be supported natively. You may simulate a stack using a list or deque (double-ended queue) as long as you use only a stack's standard operations.

        Example 1:

        Input
        ["MyQueue", "push", "push", "peek", "pop", "empty"]
        [[], [1], [2], [], [], []]
        Output
        [null, null, null, 1, 1, false]

        Explanation
        MyQueue myQueue = new MyQueue();
        myQueue.push(1); // queue is: [1]
        myQueue.push(2); // queue is: [1, 2] (leftmost is front of the queue)
        myQueue.peek(); // return 1
        myQueue.pop(); // return 1, queue is [2]
        myQueue.empty(); // return false

        Constraints:

            1 <= x <= 9
            At most 100 calls will be made to push, pop, peek, and empty.
            All the calls to pop and peek are valid.

        Follow-up: Can you implement the queue such that each operation is amortized O(1) time complexity? In other words, performing n operations will take overall O(n) time even if one of those operations may take longer.
        https://leetcode.com/problems/implement-queue-using-stacks/description/
        
        Test cases for easy copy/paste:
        ["MyQueue", "push", "push", "peek", "pop", "empty"]
        [[], [1], [2], [], [], []]
        ["MyQueue","push","pop","empty"]
        [[],[1],[],[]]
        ["MyQueue","push","pop","push","peek"]
        [[],[1],[],[2],[]]
        */
        //Custom solution below, crappiest push I have ever written even with the stats are like below. 
        //It appears this is nearly equal to first editorial solution.
        //C# Runtime: 96 ms Beats: 87.76% Memory:40.4 MB Beats: 92.95%

        public class MyQueue
        {
            public int front { get; set; }
            public Stack<int> stack1 { get; set; }
            public Stack<int> stack2 { get; set; }
            public MyQueue()
            {
                stack1 = new Stack<int>();
                stack2 = new Stack<int>();
            }

            public void Push(int x)
            {
                if (stack2.Count == 0)
                {
                    front = x;
                }
                stack2.Push(x);
            }
            public int Pop()
            {
                int newFront = 0;
                int oldFront = front;

                while (stack2.Count > 0)
                {
                    int ItemTobeInserted = stack2.Peek();
                    if (front != ItemTobeInserted)
                    {
                        stack1.Push(stack2.Pop());
                    }
                    else
                    {
                        stack2.Pop();
                    }
                }

                if (stack1.Count > 0)
                    newFront = stack1.Peek();

                while (stack1.Count > 0)
                {
                    int ItemTobeInserted = stack1.Peek();

                    if (front != ItemTobeInserted)
                    {
                        stack2.Push(stack1.Pop());
                    }
                    else
                    {
                        stack1.Pop();
                    }

                }

                stack1.Clear();
                front = newFront;
                return oldFront;
            }

            public int Peek()
            {
                return front;
            }

            public bool Empty()
            {
                if (stack2.Count == 0)
                    return true;

                return false;
            }
        }
        #endregion
        #region Implement Stack using Queues
        /*
        Implement a last-in-first-out (LIFO) stack using only two queues. The implemented stack should support all the functions of a normal stack (push, top, pop, and empty).

        Implement the MyStack class:

            void push(int x) Pushes element x to the top of the stack.
            int pop() Removes the element on the top of the stack and returns it.
            int top() Returns the element on the top of the stack.
            boolean empty() Returns true if the stack is empty, false otherwise.

        Notes:

            You must use only standard operations of a queue, which means that only push to back, peek/pop from front, size and is empty operations are valid.
            Depending on your language, the queue may not be supported natively. You may simulate a queue using a list or deque (double-ended queue) as long as you use only a queue's standard operations.

        Example 1:

        Input
        ["MyStack", "push", "push", "top", "pop", "empty"]
        [[], [1], [2], [], [], []]
        Output
        [null, null, null, 2, 2, false]

        Explanation
        MyStack myStack = new MyStack();
        myStack.push(1);
        myStack.push(2);
        myStack.top(); // return 2
        myStack.pop(); // return 2
        myStack.empty(); // return False

        

        Constraints:

            1 <= x <= 9
            At most 100 calls will be made to push, pop, top, and empty.
            All the calls to pop and top are valid.

        

        Follow-up: Can you implement the stack using only one queue?
        https://leetcode.com/problems/implement-stack-using-queues/description/
        Extra test case:
        ["MyStack","push","push","pop","top"]
        [[],[1],[2],[],[]]
        */
        //Custom solution below goes between 94-105 ms for best time stats are below.
        //Runtime:94 ms Beats: 88.85% Memory:40.9 MB Beats:13.89%
        public class MyStack
        {
            public Queue<int> queue1 { get; set; }
            public Queue<int> queue2 { get; set; }
            public int realtop { get; set; }

            public MyStack()
            {
                queue1 = new Queue<int>();
                queue2 = new Queue<int>();
                realtop = 0;
            }

            public void Push(int x)
            {
                realtop = x;
                queue1.Enqueue(x);
            }

            public int Pop()
            {
                int backuptop = 0;
                while (queue1.Count > 0)
                {
                    int deQueued = queue1.Dequeue();
                    if (deQueued != realtop)
                        queue2.Enqueue(deQueued);
                }

                while (queue2.Count > 0)
                {
                    if (queue2.Count == 1)
                    {
                        backuptop = queue2.Peek();
                    }
                    int deQueued = queue2.Dequeue();
                    if (deQueued != realtop)
                        queue1.Enqueue(deQueued);
                }
                int oldrealtop = realtop;
                realtop = backuptop;
                return oldrealtop;
            }

            public int Top()
            {
                return realtop;
            }

            public bool Empty()
            {
                if (queue1.Count == 0)
                    return true;

                return false;
            }
        }
        #endregion
        #region  Decode String
        /*
        Given an encoded string, return its decoded string.
        The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times. Note that k is guaranteed to be a positive integer.
        You may assume that the input string is always valid; there are no extra white spaces, square brackets are well-formed, etc. 
        Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k. 
        For example, there will not be input like 3a or 2[4].
        The test cases are generated so that the length of the output will never exceed 105.

        Example 1:
        Input: s = "3[a]2[bc]"
        Output: "aaabcbc"

        Example 2:
        Input: s = "3[a2[c]]"
        Output: "accaccacc"

        Example 3:
        Input: s = "2[abc]3[cd]ef"
        Output: "abcabccdcdcdef"

        Constraints:

            1 <= s.length <= 30
            s consists of lowercase English letters, digits, and square brackets '[]'.
            s is guaranteed to be a valid input.
            All the integers in s are in the range [1, 300].
            https://leetcode.com/problems/decode-string/
        */

        public string DecodeString(string s)
        {
            var repeat = 0;
            var sb = new StringBuilder(s.Length);
            var st = new Stack<(int start, int repeat)>();

            foreach (var c in s)
            {
                if (c == '[')
                {
                    st.Push((sb.Length, repeat));
                    repeat = 0;
                }
                else if (c == ']')
                {
                    var (start, times) = st.Pop();

                    for (var length = sb.Length - start; times > 1; times--)
                    {
                        sb.Append(sb, start, length);
                    }
                }
                else if (Char.IsDigit(c))
                {
                    repeat = 10 * repeat + (c - '0');
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
        public string DecodeStringWIP(string s)
        {
            Stack<string> temporary = new();
            List<string> filteredOut = new();
            StringBuilder appender = new();

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]) || char.IsLetter(s[i]))
                {
                    string toPush = "";
                    if (temporary.Count > 0)
                    {
                        toPush = temporary.Pop();
                    }
                    toPush += s[i];
                    temporary.Push(toPush);
                }
                else if (s[i] == ']')
                {
                    while (temporary.Count > 0)
                    {
                        appender.Append(temporary.Pop());
                    }
                    Console.WriteLine(appender.ToString());
                    filteredOut.Add(appender.ToString());
                    appender.Clear();
                }
            }



            return "";
        }
        #endregion

        #endregion

        #endregion
    }
}