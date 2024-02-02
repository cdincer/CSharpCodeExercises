using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Neetcode150
{
    public class HeapPriorityQueueNeet
    {
        #region Kth Largest Element in a Stream
        /*
        Design a class to find the kth largest element in a stream. Note that it is the kth largest element in the sorted order, not the kth distinct element.
        Implement KthLargest class:

        KthLargest(int k, int[] nums) Initializes the object with the integer k and the stream of integers nums.
        int add(int val) Appends the integer val to the stream and returns the element representing the kth largest element in the stream.

        Example 1:
        Input
        ["KthLargest", "add", "add", "add", "add", "add"]
        [[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]
        Output
        [null, 4, 5, 5, 8, 8]

        Explanation
        KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);
        kthLargest.add(3);   // return 4
        kthLargest.add(5);   // return 5
        kthLargest.add(10);  // return 5
        kthLargest.add(9);   // return 8
        kthLargest.add(4);   // return 8

        Constraints:

        1 <= k <= 104
        0 <= nums.length <= 104
        -104 <= nums[i] <= 104
        -104 <= val <= 104
        At most 104 calls will be made to add.
        It is guaranteed that there will be at least k elements in the array when you search for the kth element.

        https://leetcode.com/problems/kth-largest-element-in-a-stream/
        */

        public class KthLargest
        {
            PriorityQueue<int, int> data = new PriorityQueue<int, int>();
            int k;

            public KthLargest(int k, int[] nums)
            {
                this.k = k;
                foreach (var num in nums)
                    Add(num);
            }

            public int Add(int val)
            {
                data.Enqueue(val, val);

                if (data.Count > k)
                    data.Dequeue();

                return data.Peek();
            }
        }
        #endregion
        #region Last Stone Weight
        /*
        You are given an array of integers stones where stones[i] is the weight of the ith stone.
        We are playing a game with the stones. On each turn, we choose the heaviest two stones and smash them together. Suppose the heaviest two stones have weights x and y with x <= y. The result of this smash is:

            If x == y, both stones are destroyed, and
            If x != y, the stone of weight x is destroyed, and the stone of weight y has new weight y - x.

        At the end of the game, there is at most one stone left.
        Return the weight of the last remaining stone. If there are no stones left, return 0.

        Example 1:
        Input: stones = [2,7,4,1,8,1]
        Output: 1
        Explanation: 
        We combine 7 and 8 to get 1 so the array converts to [2,4,1,1,1] then,
        we combine 2 and 4 to get 2 so the array converts to [2,1,1,1] then,
        we combine 2 and 1 to get 1 so the array converts to [1,1,1] then,
        we combine 1 and 1 to get 0 so the array converts to [1] then that's the value of the last stone.

        Example 2:
        Input: stones = [1]
        Output: 1

        Constraints:

        1 <= stones.length <= 30
        1 <= stones[i] <= 1000

        https://leetcode.com/problems/last-stone-weight/
        */

        public int LastStoneWeight(int[] stones)
        {
            PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

            foreach (int stone in stones)
            {
                maxHeap.Enqueue(stone, -stone);
            }

            int stoneOne;
            int stoneTwo;

            while (maxHeap.Count > 1)
            {
                stoneOne = maxHeap.Dequeue();
                stoneTwo = maxHeap.Dequeue();
                if (stoneOne > stoneTwo)
                    maxHeap.Enqueue(stoneOne - stoneTwo, -(stoneOne - stoneTwo));
            }

            if (maxHeap.Count == 0)
                return 0;
            return maxHeap.Dequeue();
        }

        #endregion
        #region K Closest Points to Origin
        /*
        
        Extra Test Cases: 
        [[-95,76],[17,7],[-55,-58],[53,20],[-69,-8],[-57,87],[-2,-42],[-10,-87],[-36,-57],[97,-39],[97,49]] 63 / 87 testcases passed
        */
        public int[][] KClosest(int[][] points, int k)
        {
            var items = points.Select(point =>
            {
                long x = point[0];
                long y = point[1];

                return (point, x * x + y * y);
            });

            int[][] result = new int[k][];
            // T: O(n)
            PriorityQueue<int[], long> queue = new(items);

            // T: O(k log(n))
            for (int i = 0; i < k; i++)
            {
                result[i] = queue.Dequeue();
            }

            return result;
        }
        #endregion
        #region Kth Largest Element in an array
        /*
        https://leetcode.com/problems/kth-largest-element-in-an-array/
        */

        public int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int, int> queue = new PriorityQueue<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (queue.Count < k)
                    queue.Enqueue(nums[i], nums[i]);
                else
                {
                    if (nums[i] <= queue.Peek()) continue;

                    queue.Dequeue();
                    queue.Enqueue(nums[i], nums[i]);
                }
            }
            return queue.Dequeue();
        }

        public int FindKthLargest2(int[] nums, int k)
        {
            PriorityQueue<int, int> items = new();

            for (int i = 0; i < nums.Length; i++)
            {
                if (items.Count < k)
                    items.Enqueue(nums[i], nums[i]);
                else if (items.Count == k)
                {
                    items.Dequeue();
                    items.Enqueue(nums[i], nums[i]);
                }
            }
            // while(items.Count > k)
            // {
            //     items.Dequeue();
            // }

            return items.Dequeue();
        }

        #endregion
        #region Task Scheduler
        /*
        Given a characters array tasks, representing the tasks a CPU needs to do, where each letter represents a different task. Tasks could be done in any order. Each task is done in one unit of time. 
        For each unit of time, the CPU could complete either one task or just be idle.
        However, there is a non-negative integer n that represents the cooldown period between two same tasks (the same letter in the array), 
        that is that there must be at least n units of time between any two same tasks.
        Return the least number of units of times that the CPU will take to finish all the given tasks.

        Example 1:
        Input: tasks = ["A","A","A","B","B","B"], n = 2
        Output: 8
        Explanation: 
        A -> B -> idle -> A -> B -> idle -> A -> B
        There is at least 2 units of time between any two same tasks.

        Example 2:
        Input: tasks = ["A","A","A","B","B","B"], n = 0
        Output: 6
        Explanation: On this case any permutation of size 6 would work since n = 0.
        ["A","A","A","B","B","B"]
        ["A","B","A","B","A","B"]
        ["B","B","B","A","A","A"]
        ...
        And so on.

        Example 3:
        Input: tasks = ["A","A","A","A","A","A","B","C","D","E","F","G"], n = 2
        Output: 16
        Explanation: 
        One possible solution is
        A -> B -> C -> A -> D -> E -> A -> F -> G -> A -> idle -> idle -> A -> idle -> idle -> A

        Constraints:

            1 <= task.length <= 104
            tasks[i] is upper-case English letter.
            The integer n is in the range [0, 100].

        https://leetcode.com/problems/task-scheduler/
        */
        public int LeastInterval(char[] tasks, int n)
        {
            Dictionary<char, int> freq = new();
            PriorityQueue<int, int> heap = new PriorityQueue<int, int>();

            foreach (char c in tasks)
            {
                freq.TryAdd(c, 0);
                freq[c]++;
            }

            foreach (char key in freq.Keys)
            {
                heap.Enqueue(freq[key], -freq[key]);
            }

            int time = 0;
            Queue<(int freq, int availableAt)> queue = new();

            while (heap.Count > 0 || queue.Count > 0)
            {
                time++;

                if (heap.Count > 0)
                {
                    int node = heap.Dequeue();

                    if (node - 1 != 0)
                    {
                        queue.Enqueue((node - 1, time + n));
                    }
                }

                if (queue.Count > 0)
                {
                    if (queue.Peek().availableAt == time)
                    {
                        var curr = queue.Dequeue();
                        heap.Enqueue(curr.freq, -curr.freq);
                    }
                }
            }

            return time;
        }
        #endregion
        #region Design Twitter
        /*
        ["Twitter","postTweet","getNewsFeed","follow","getNewsFeed","unfollow","getNewsFeed"]  1 / 16 testcases passed
        [[],[1,1],[1],[2,1],[2],[2,1],[2]]
        ["Twitter","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","postTweet","getNewsFeed","follow","getNewsFeed","unfollow","getNewsFeed"] 14 / 16 testcases passed
        [[],[1,5],[2,3],[1,101],[2,13],[2,10],[1,2],[1,94],[2,505],[1,333],[2,22],[1,11],[1,205],[2,203],[1,201],[2,213],[1,200],[2,202],[1,204],[2,208],[2,233],[1,222],[2,211],[1],[1,2],[1],[1,2],[1]]
        */

        #endregion
    }
}