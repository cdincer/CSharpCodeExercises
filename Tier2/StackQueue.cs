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
         https://leetcode.com/problems/design-circular-queue/description/
        */
        public class MyCircularQueue
        {

            private int[] data { get; set; }
            // a pointer to indicate the start position
            private int head;
            private int tail;
            private int itemCount;

            public MyCircularQueue(int k)
            {
                data = new int[k];
                head = 0;
                tail = 0;
                itemCount = 0;
            }

            public bool EnQueue(int value)
            {
                if (itemCount == data.Length)
                {
                    return false;
                }
                else if (tail == data.Length)
                {
                    tail = 0;
                }

                data[tail] = value;
                tail++;
                itemCount++;


                return true;
            }

            public bool DeQueue()
            {
                if (itemCount <= 0)
                {
                    return false;
                }
                head++;
                itemCount--;
                return true;
            }

            public int Front()
            {
                return data[head];
            }

            public int Rear()
            {
                return data[tail - 1];
            }

            public bool IsEmpty()
            {

                if (itemCount == 0)
                    return true;

                return false;
            }

            public bool IsFull()
            {
                if (itemCount == data.Length)
                    return true;

                return false;
            }
        }
        #endregion

        #endregion
        #endregion
    }
}