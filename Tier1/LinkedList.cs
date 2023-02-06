using System;
using System.Collections.Generic;

namespace Tier1
{
    public class LinkedList
    {
        //Card: https://leetcode.com/explore/learn/card/linked-list/209/singly-linked-list/1287/
        //1- Add Operation - singly linked list:https://leetcode.com/explore/learn/card/linked-list/209/singly-linked-list/1288/
        //2- Delete Operation - singly linked list:https://leetcode.com/explore/learn/card/linked-list/209/singly-linked-list/1289/ 
        #region Singly Linked List
        #region Design Linked List
        /*
        https://leetcode.com/problems/design-linked-list/


        Design your implementation of the linked list. You can choose to use a singly or doubly linked list.
        A node in a singly linked list should have two attributes: val and next. val is the value of the current node, and next is a pointer/reference to the next node.
        If you want to use the doubly linked list, you will need one more attribute prev to indicate the previous node in the linked list. Assume all nodes in the linked list are 0-indexed.

        Implement the MyLinkedList class:

        MyLinkedList() Initializes the MyLinkedList object.
        int get(int index) -- Get the value of the indexth node in the linked list. If the index is invalid, return -1.
        void addAtHead(int val) -- Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list.
        void addAtTail(int val) -- Append a node of value val as the last element of the linked list.
        void addAtIndex(int index, int val) --  Add a node of value val before the indexth node in the linked list. If index equals the length of the linked list, the node will be appended to the end of the linked list. If index is greater than the length, the node will not be inserted.
        void deleteAtIndex(int index) -- Delete the indexth node in the linked list, if the index is valid.

    
        Example 1:

        Input
        ["MyLinkedList", "addAtHead", "addAtTail", "addAtIndex", "get", "deleteAtIndex", "get"]
        [[], [1], [3], [1, 2], [1], [1], [1]]
        Output
        [null, null, null, null, 2, null, 3]

        Explanation
        MyLinkedList myLinkedList = new MyLinkedList();
        myLinkedList.addAtHead(1);
        myLinkedList.addAtTail(3);
        myLinkedList.addAtIndex(1, 2);    // linked list becomes 1->2->3
        myLinkedList.get(1);              // return 2
        myLinkedList.deleteAtIndex(1);    // now the linked list is 1->3
        myLinkedList.get(1);              // return 3

        

        Constraints:

        0 <= index, val <= 1000
        Please do not use the built-in LinkedList library.
        At most 2000 calls will be made to get, addAtHead, addAtTail, addAtIndex and deleteAtIndex.
    */
        public class MyLinkedList
        {
            private Node head;
            int count = 0;

            public int Get(int index)
            {
                var node = GetNode(index);
                return node == null ? -1 : node.val;
            }

            public Node GetNode(int index)
            {
                if (index >= count)
                    return null;
                var curr = head;
                for (int i = 0; i < index; i++)
                    curr = curr.next;

                return curr;
            }

            public void AddAtHead(int val)
            {
                var newNode = new Node(val);
                newNode.next = head;
                head = newNode;
                count++;
            }

            public void AddAtTail(int val)
            {
                if (head == null)
                {
                    AddAtHead(val);
                    return;
                }

                var node = GetNode(count - 1);
                node.next = new Node(val);
                count++;
            }

            public void AddAtIndex(int index, int val)
            {
                if (index > count)
                    return;
                if (index == 0)
                {
                    AddAtHead(val);
                    return;
                }
                var node = GetNode(index - 1);
                var newNode = new Node(val);
                newNode.next = node.next;
                node.next = newNode;
                count++;
            }

            public void DeleteAtIndex(int index)
            {
                if (count == 0)
                    return;

                if (index < count && index >= 0)
                {
                    if (index == 0)
                        head = head.next;
                    else
                    {
                        var node = GetNode(index - 1);
                        node.next = node.next.next;
                    }

                    count--;
                }
            }
        }
        public class Node
        {
            public int val;
            public Node next;
            public Node(int n)
            {
                val = n;
            }
        }
        #endregion
        #endregion
        #region Two Pointer Technique
        //https://leetcode.com/explore/learn/card/linked-list/214/two-pointer-technique/1212/
        #region Linked List Cycle
        /*
        Explanation for solution below:
        It is a safe choice to move the slow pointer one step at a time while moving the fast pointer two steps at a time. 
        For each iteration, the fast pointer will move one extra step. 
        If the length of the cycle is M, after M iterations, the fast pointer will definitely move one more cycle and catch up with the slow pointer.

        */
        //Same one in the card: https://leetcode.com/problems/linked-list-cycle/


        /*
        Given head, the head of a linked list, determine if the linked list has a cycle in it.

        There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. 
        Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.

        Return true if there is a cycle in the linked list. Otherwise, return false.

        

        Example 1:

        Input: head = [3,2,0,-4], pos = 1
        Output: true
        Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).

        Example 2:

        Input: head = [1,2], pos = 0
        Output: true
        Explanation: There is a cycle in the linked list, where the tail connects to the 0th node.

        Example 3:

        Input: head = [1], pos = -1
        Output: false
        Explanation: There is no cycle in the linked list.

        

        Constraints:

            The number of the nodes in the list is in the range [0, 104].
            -105 <= Node.val <= 105
            pos is -1 or a valid index in the linked-list.

        

        Follow up: Can you solve it using O(1) (i.e. constant) memory?

        */

        /**
        * Definition for singly-linked list.
        * public class ListNode {
        *     public int val;
        *     public ListNode next;
        *     public ListNode(int x) {
        *         val = x;
        *         next = null;
        *     }
        * }
        */
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int n)
            {
                val = n;
                next = null;
            }
        }
        public bool HasCycle(ListNode head)
        {
            if (head == null)
                return false;

            ListNode fast = head;
            ListNode slow = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (fast == slow)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region Linked List Cycle II
        /*
        https://leetcode.com/problems/linked-list-cycle-ii/
        Given the head of a linked list, return the node where the cycle begins. If there is no cycle, return null.

        There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to (0-indexed). It is -1 if there is no cycle. Note that pos is not passed as a parameter.

        Do not modify the linked list.

        

        Example 1:

        Input: head = [3,2,0,-4], pos = 1
        Output: tail connects to node index 1
        Explanation: There is a cycle in the linked list, where tail connects to the second node.

        Example 2:

        Input: head = [1,2], pos = 0
        Output: tail connects to node index 0
        Explanation: There is a cycle in the linked list, where tail connects to the first node.

        Example 3:

        Input: head = [1], pos = -1
        Output: no cycle
        Explanation: There is no cycle in the linked list.

        

        Constraints:

            The number of the nodes in the list is in the range [0, 104].
            -105 <= Node.val <= 105
            pos is -1 or a valid index in the linked-list.

        

        Follow up: Can you solve it using O(1) (i.e. constant) memory?
        Solution below: Runtime: 81 ms Memory Usage: 41.5 MB
        */
        public ListNode DetectCycle(ListNode head)
        {
            var set = new HashSet<ListNode>();
            for (ListNode i = head; i != null && i.next != null; i = i.next)
            {
                if (!set.Contains(i))
                    set.Add(i);
                else
                    return i;
            }
            return null;
        }
        #endregion
        #endregion
    }
}