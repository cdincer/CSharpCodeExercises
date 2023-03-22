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
        #region Intersection of Two Linked Lists
        //https://leetcode.com/explore/learn/card/linked-list/214/two-pointer-technique/1215/
        /*
        Given the heads of two singly linked-lists headA and headB, return the node at which the two lists intersect. If the two linked lists have no intersection at all, return null.

        For example, the following two linked lists begin to intersect at node c1:

        The test cases are generated such that there are no cycles anywhere in the entire linked structure.

        Note that the linked lists must retain their original structure after the function returns.

        Custom Judge:

        The inputs to the judge are given as follows (your program is not given these inputs):

            intersectVal - The value of the node where the intersection occurs. This is 0 if there is no intersected node.
            listA - The first linked list.
            listB - The second linked list.
            skipA - The number of nodes to skip ahead in listA (starting from the head) to get to the intersected node.
            skipB - The number of nodes to skip ahead in listB (starting from the head) to get to the intersected node.

        The judge will then create the linked structure based on these inputs and pass the two heads, headA and headB to your program. If you correctly return the intersected node, then your solution will be accepted.

        

        Example 1:

        Input: intersectVal = 8, listA = [4,1,8,4,5], listB = [5,6,1,8,4,5], skipA = 2, skipB = 3
        Output: Intersected at '8'
        Explanation: The intersected node's value is 8 (note that this must not be 0 if the two lists intersect).
        From the head of A, it reads as [4,1,8,4,5]. From the head of B, it reads as [5,6,1,8,4,5]. There are 2 nodes before the intersected node in A; There are 3 nodes before the intersected node in B.
        - Note that the intersected node's value is not 1 because the nodes with value 1 in A and B (2nd node in A and 3rd node in B) are different node references. In other words, they point to two different locations in memory, while the nodes with value 8 in A and B (3rd node in A and 4th node in B) point to the same location in memory.

        Example 2:

        Input: intersectVal = 2, listA = [1,9,1,2,4], listB = [3,2,4], skipA = 3, skipB = 1
        Output: Intersected at '2'
        Explanation: The intersected node's value is 2 (note that this must not be 0 if the two lists intersect).
        From the head of A, it reads as [1,9,1,2,4]. From the head of B, it reads as [3,2,4]. There are 3 nodes before the intersected node in A; There are 1 node before the intersected node in B.

        Example 3:

        Input: intersectVal = 0, listA = [2,6,4], listB = [1,5], skipA = 3, skipB = 2
        Output: No intersection
        Explanation: From the head of A, it reads as [2,6,4]. From the head of B, it reads as [1,5]. Since the two lists do not intersect, intersectVal must be 0, while skipA and skipB can be arbitrary values.
        Explanation: The two lists do not intersect, so return null.

        https://leetcode.com/problems/intersection-of-two-linked-lists/
        */
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode a = headA,
                  b = headB;

            while (a != b)
            {
                a = a == null ? headB : a.next;
                b = b == null ? headA : b.next;
            }

            return a;


        }
        #endregion
        #region Remove Nth Node From End of List
        /*
        Given the head of a linked list, remove the nth node from the end of the list and return its head.
     
        Example 1:

        Input: head = [1,2,3,4,5], n = 2
        Output: [1,2,3,5]

        Example 2:

        Input: head = [1], n = 1
        Output: []

        Example 3:

        Input: head = [1,2], n = 1
        Output: [1]

        

        Constraints:

            The number of nodes in the list is sz.
            1 <= sz <= 30
            0 <= Node.val <= 100
            1 <= n <= sz

        

        Follow up: Could you do this in one pass?
        Hint 1: Maintain two pointers and update one with a delay of n steps.
        Problem: https://leetcode.com/problems/remove-nth-node-from-end-of-list/submissions/895474293/
        */
        /*
        [1]
        1
        [1,2]
        2
        */
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var left = head;
            var right = head;

            while (right != null)
            {
                right = right.next;
                if (n-- < 0) left = left.next;
            }

            if (n == 0) head = head.next;
            else left.next = left.next.next;

            return head;
        }
        #endregion
        #endregion
        #region Classic Problems
        #region Reverse Linked List
        /*https://leetcode.com/problems/reverse-linked-list/
        Given the head of a singly linked list, reverse the list, and return the reversed list.

        Example 1:

        Input: head = [1,2,3,4,5]
        Output: [5,4,3,2,1]

        Example 2:

        Input: head = [1,2]
        Output: [2,1]

        Example 3:

        Input: head = []
        Output: [] 

        Constraints:

            The number of nodes in the list is the range [0, 5000].
            -5000 <= Node.val <= 5000


        Follow up: A linked list can be reversed either iteratively or recursively. Could you implement both?
        Solution below is inspired by Recursion1 card,Swapchar solution.
        Test Cases For Visual Studio:
        ListNode2 head = new ListNode2(1, new ListNode2(2, new ListNode2(3, new ListNode2(4,new ListNode2(5)))));
        */
        public class ListNode2
        {
            public int val;
            public ListNode2 next;
            public ListNode2(int val = 0, ListNode2 next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public ListNode2 ReverseList(ListNode2 head)
        {
            return reverseListInt(head, null);
        }

        private ListNode2 reverseListInt(ListNode2 head, ListNode2 newHead)
        {
            if (head == null)
                return newHead;
            ListNode2 next = head.next;
            head.next = newHead;
            return reverseListInt(next, head);
        }
        #endregion
        #region Remove Linked List Elements
        /*
        Given the head of a linked list and an integer val, remove all the nodes of the linked list that has Node.val == val, and return the new head.
       
        Example 1:

        Input: head = [1,2,6,3,4,5,6], val = 6
        Output: [1,2,3,4,5]

        Example 2:

        Input: head = [], val = 1
        Output: []

        Example 3:

        Input: head = [7,7,7,7], val = 7
        Output: []

        

        Constraints:

            The number of nodes in the list is in the range [0, 104].
            1 <= Node.val <= 50
            0 <= val <= 50


        https://leetcode.com/problems/remove-linked-list-elements/
        */
        public ListNode2 RemoveElements(ListNode2 head, int val)
        {

            ListNode2 dummy = new ListNode2(), node = dummy;

            while (head != null)
            {
                if (head.val != val)
                {
                    dummy.next = head;
                    dummy = dummy.next;
                }
                else if (head.val == val && head.next == null)//last node needs to be deleted if head.val == val
                    dummy.next = null;
                head = head.next;
            }

            return node.next;
        }
        #endregion
        #region Odd-Even Linked List
        /*
        Given the head of a singly linked list, group all the nodes with odd indices together followed by the nodes with even indices, and return the reordered list.

        The first node is considered odd, and the second node is even, and so on.

        Note that the relative order inside both the even and odd groups should remain as it was in the input.

        You must solve the problem in O(1) extra space complexity and O(n) time complexity.

                

        Example 1:

        Input: head = [1,2,3,4,5]
        Output: [1,3,5,2,4]

        Example 2:

        Input: head = [2,1,3,5,6,4,7]
        Output: [2,3,6,7,1,5,4]

        

        Constraints:

        The number of nodes in the linked list is in the range [0, 104].
        -106 <= Node.val <= 106


        https://leetcode.com/problems/odd-even-linked-list/description/
        */
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null) return null;
            ListNode odd = head;
            ListNode even = head.next;
            ListNode evenHead = head.next;
            // `even != null` rules out the list of only 1 node
            // `even.next != null` rules out the list of only 2 nodes
            while (even != null && even.next != null)
            {
                // Put odd to the odd list
                odd.next = odd.next.next;

                // Put even to the even list
                even.next = even.next.next;

                // Move the pointer to the next odd/even
                odd = odd.next;
                even = even.next;
            }
            odd.next = evenHead;
            return head;
        }
        #endregion
        #region Palindrome Linked List
        /*
        Given the head of a singly linked list, return true if it is a
        palindrome
        or false otherwise.

        

        Example 1:

        Input: head = [1,2,2,1]
        Output: true

        Example 2:

        Input: head = [1,2]
        Output: false

        

        Constraints:

            The number of nodes in the list is in the range [1, 105].
            0 <= Node.val <= 9

        Performance for code below(My solution)
        Runtime: 239 ms Beats 85.63% -- Memory:61.6 MB Beats 48.44%
        Follow up: Could you do it in O(n) time and O(1) space?
        https://leetcode.com/problems/palindrome-linked-list/description/
        */
        public bool IsPalindrome(ListNode head)
        {
            List<int> Items = new List<int>();
            while (head != null)
            {
                Items.Add(head.val);
                head = head.next;
            }
            int front = 0;
            int back = Items.Count - 1;
            while (front < back)
            {
                if (Items[front] != Items[back])
                    return false;

                front++;
                back--;
            }
            return true;
        }
        #endregion
        #endregion
        #region Conclusion
        #region Merge Two Sorted Lists
        /*
        You are given the heads of two sorted linked lists list1 and list2.

        Merge the two lists in a one sorted list. The list should be made by splicing together the nodes of the first two lists.

        Return the head of the merged linked list.

        Example 1:

        Input: list1 = [1,2,4], list2 = [1,3,4]
        Output: [1,1,2,3,4,4]

        Example 2:

        Input: list1 = [], list2 = []
        Output: []

        Example 3:

        Input: list1 = [], list2 = [0]
        Output: [0]

        

        Constraints:

            The number of nodes in both lists is in the range [0, 50].
            -100 <= Node.val <= 100
            Both list1 and list2 are sorted in non-decreasing order.


        https://leetcode.com/problems/merge-two-sorted-lists/description/

        Runtime:76 ms Beats 97.78%
        Memory:39.6 MB Beats 68.56%
        */
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {

            if (list1 == null) return list2;
            else if (list2 == null) return list1;

            ListNode dummy = new ListNode(0);
            ListNode current = dummy;
            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }
                current = current.next;
            }
            current.next = list1 == null ? list2 : list1;
            return dummy.next;

        }
        #endregion
        #region Add Two Numbers
        /*
        You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

        You may assume the two numbers do not contain any leading zero, except the number 0 itself.

        

        Example 1:

        Input: l1 = [2,4,3], l2 = [5,6,4]
        Output: [7,0,8]
        Explanation: 342 + 465 = 807.

        Example 2:

        Input: l1 = [0], l2 = [0]
        Output: [0]

        Example 3:

        Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
        Output: [8,9,9,9,0,0,0,1]

        

        Constraints:

            The number of nodes in each linked list is in the range [1, 100].
            0 <= Node.val <= 9
            It is guaranteed that the list represents a number that does not have leading zeros.


        https://leetcode.com/problems/add-two-numbers/description/
        */
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode DummyHead = new ListNode(0);
            ListNode Current = DummyHead;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                int L1val = (l1 != null) ? l1.val : 0;
                int L2val = (l2 != null) ? l2.val : 0;

                int sum = carry + L1val + L2val;
                carry = sum / 10;
                Current.next = new ListNode(sum % 10);
                Current = Current.next;

                if (l1 != null)
                    l1 = l1.next;

                if (l2 != null)
                    l2 = l2.next;
            }

            return DummyHead.next;
        }
        #endregion
        #endregion
    }
}