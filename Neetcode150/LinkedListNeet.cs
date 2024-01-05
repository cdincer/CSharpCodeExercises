namespace Neetcode150
{
    public class LinkedListNeet
    {


        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        #region Reverse Linked List
        /*
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

        https://leetcode.com/problems/reverse-linked-list/
        */
        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null, curr = head;

            while (curr != null)
            {
                var temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }
            return prev;
        }
        #endregion
        #region Merge Two Sorted Lists 
        /*
        You are given the heads of two sorted linked lists list1 and list2.
        Merge the two lists into one sorted list. 
        The list should be made by splicing together the nodes of the first two lists.
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
        */
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var dummy = new ListNode();
            var tail = dummy;
            
            while (list1 is not null && list2 is not null)
            {
                if (list1.val < list2.val)
                {
                    tail.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    tail.next = list2;
                    list2 = list2.next;
                }
                tail = tail.next;
            }

            if (list1 is not null)
                tail.next = list1;
            else if (list2 is not null)
                tail.next = list2;

            return dummy.next;
        }
        #endregion
        #region Reorder List
        /*
        You are given the head of a singly linked-list. The list can be represented as:

        L0 → L1 → … → Ln - 1 → Ln

        Reorder the list to be on the following form:

        L0 → Ln → L1 → Ln - 1 → L2 → Ln - 2 → …

        You may not modify the values in the list's nodes. Only nodes themselves may be changed.

        Example 1:
        Input: head = [1,2,3,4]
        Output: [1,4,2,3]

        Example 2:
        Input: head = [1,2,3,4,5]
        Output: [1,5,2,4,3]

        Constraints:

            The number of nodes in the list is in the range [1, 5 * 104].
            1 <= Node.val <= 1000

        https://leetcode.com/problems/reorder-list/
        */

        //Code is literally copy pasted from a java solution without a single change and it works out of the box.
        //Runtime: 74ms Beats 95.56% of users with C# Memory:45.81MB Beats 15.12%of users with C#
        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null)
                return;

            // step 1. cut the list to two halves
            // prev will be the tail of 1st half
            // slow will be the head of 2nd half
            ListNode prev = null, slow = head, fast = head, l1 = head;

            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            prev.next = null;

            // step 2. reverse the 2nd half
            ListNode l2 = reverse(slow);

            // step 3. merge the two halves
            merge(l1, l2);
        }

        ListNode reverse(ListNode head)
        {
            ListNode prev = null, curr = head, next = null;

            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }

        void merge(ListNode l1, ListNode l2)
        {
            while (l1 != null)
            {
                ListNode n1 = l1.next, n2 = l2.next;
                l1.next = l2;

                if (n1 == null)
                    break;

                l2.next = n1;
                l1 = n1;
                l2 = n2;
            }
        }
        #endregion
    }
}