using System;
using System.Collections.Generic;
using System.Collections.Immutable;

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
    }

}