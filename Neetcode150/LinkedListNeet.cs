using System.Collections.Generic;
using System.Linq;

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
        Extra Test Case: 
        Head: [1] 2 / 12 testcases passed
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
                prev = slow;//Keep track of l1 head and its link to the main head.
                slow = slow.next;
                fast = fast.next.next;
            }

            prev.next = null;//Sever it so you don't have to go through it end up with a null or cycle.

            // step 2. reverse the 2nd half
            ListNode l2 = reverse(slow);

            // step 3. merge the two halves
            merge(l1, l2);
        }

        ListNode reverse(ListNode head)
        {
            ListNode prev = null, curr = head, next = null;//Temp storage place for next value.

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

        https://leetcode.com/problems/remove-nth-node-from-end-of-list/
        head = [1,2] n = 1 Output : 1 189 / 208 testcases passed
        head = [1,2] n = 2 Output : 2 190 / 208 testcases passed
        */
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var dummy = new ListNode(0, head);
            var left = dummy;
            var right = head;

            while (n > 0)
            {
                right = right.next;
                n--;
            }

            while (right != null)
            {
                left = left.next;
                right = right.next;
            }

            // delete
            left.next = left.next.next;
            return dummy.next;
        }
        #endregion
        #region Copy List with Random Pointer
        /*
        A linked list of length n is given such that each node contains an additional random pointer, which could point to any node in the list, or null.
        Construct a deep copy of the list. The deep copy should consist of exactly n brand new nodes, where each new node has its value set to the value of its corresponding original node. 
        Both the next and random pointer of the new nodes should point to new nodes in the copied list such that the pointers in the original list and copied list represent the same list state. 
        None of the pointers in the new list should point to nodes in the original list.

        For example, if there are two nodes X and Y in the original list, where X.random --> Y, then for the corresponding two nodes x and y in the copied list, x.random --> y.
        Return the head of the copied linked list.

        The linked list is represented in the input/output as a list of n nodes. Each node is represented as a pair of [val, random_index] where:

            val: an integer representing Node.val
            random_index: the index of the node (range from 0 to n-1) that the random pointer points to, or null if it does not point to any node.

        Your code will only be given the head of the original linked list.

        Example 1:
        Input: head = [[7,null],[13,0],[11,4],[10,2],[1,0]]
        Output: [[7,null],[13,0],[11,4],[10,2],[1,0]]

        Example 2:
        Input: head = [[1,1],[2,1]]
        Output: [[1,1],[2,1]]

        Example 3:
        Input: head = [[3,null],[3,0],[3,null]]
        Output: [[3,null],[3,0],[3,null]]

        Constraints:

            0 <= n <= 1000
            -104 <= Node.val <= 104
            Node.random is null or is pointing to some node in the linked list.


        https://leetcode.com/problems/copy-list-with-random-pointer/
        Extra Test Cases:
        [[-1,0]]
        []
        [[-1,null]]
        */
        public class RandomPointNode
        {
            public int val;
            public RandomPointNode next;
            public RandomPointNode random;

            public RandomPointNode(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }

        public RandomPointNode CopyRandomList(RandomPointNode head)
        {
            var map = new Dictionary<RandomPointNode, RandomPointNode>();
            if (head == null) return null;
            var copy = new RandomPointNode(head.val);

            map[head] = copy;
            var cur1 = head.next;
            var cur2 = copy;

            // first pass to create the nodes
            while (cur1 != null)
            {
                var next2 = new RandomPointNode(cur1.val);
                cur2.next = next2;
                //map the nodes
                map[cur1] = next2;
                cur1 = cur1.next;
                cur2 = cur2.next;
            }

            cur1 = head;
            cur2 = copy;

            // second pass to update the random pointers
            while (cur2 != null)
            {
                var random = cur1.random != null
                    ? map[cur1.random]
                    : null;

                cur2.random = random;
                cur1 = cur1.next;
                cur2 = cur2.next;


            }
            return copy;
        }
        #endregion
        #region Add Two Numbers
        /*
        You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. 
        Add the two numbers and return the sum as a linked list.
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

        https://leetcode.com/problems/add-two-numbers/
        */
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var sumList = new ListNode();
            var current = sumList;
            int carry = 0, sum = 0;

            while (l1 != null || l2 != null || carry == 1)
            {
                var v1 = l1 == null ? 0 : l1.val;
                var v2 = l2 == null ? 0 : l2.val;
                sum = v1 + v2 + carry;
                carry = sum > 9 ? 1 : 0;
                sum = sum % 10;
                current.next = new ListNode(sum);

                current = current.next;
                l1 = l1 == null ? null : l1.next;
                l2 = l2 == null ? null : l2.next;
            }

            return sumList.next;
        }
        #endregion
        #region Linked List Cycle
        /*
        Given head, the head of a linked list, determine if the linked list has a cycle in it.
        There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. 
        Note that pos is not passed as a parameter.
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

        [1,2]
        -1
        []
        -1
        [3,4,5]
        [-1]
        */
        public bool HasCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            if (head == null)
                return false;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (fast == slow)
                    return true;
            }

            return false;
        }
        #endregion
        #region Find the Duplicate Number
        /*
        Given an array of integers nums containing n + 1 integers where each integer is in the range [1, n] inclusive.
        There is only one repeated number in nums, return this repeated number.
        You must solve the problem without modifying the array nums and uses only constant extra space.

        Example 1:
        Input: nums = [1,3,4,2,2]
        Output: 2

        Example 2:
        Input: nums = [3,1,3,4,2]
        Output: 3

        Constraints:
            1 <= n <= 105
            nums.length == n + 1
            1 <= nums[i] <= n
            All the integers in nums appear only once except for precisely one integer which appears two or more times.

        

        Follow up:
            How can we prove that at least one duplicate number must exist in nums?
            Can you solve the problem in linear runtime complexity?
      
        https://leetcode.com/problems/find-the-duplicate-number/
        */
        public int FindDuplicate(int[] nums)
        {
            int slow = 0;
            int fast = 0;

            while (true)
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
                if (slow == fast)
                    break;
            }
            int slow2 = 0;

            while (true)
            {
                slow = nums[slow];
                slow2 = nums[slow2];

                if (slow == slow2)
                    return slow;
            }

            return 0;
        }
        #endregion
        #region LRU Cache
        /*
        Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.
        Implement the LRUCache class:

            LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
            int get(int key) Return the value of the key if the key exists, otherwise return -1.
            void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.

        The functions get and put must each run in O(1) average time complexity.

        Example 1:
        Input
        ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
        [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
        Output
        [null, null, null, 1, null, -1, null, -1, 3, 4]

        Explanation
        LRUCache lRUCache = new LRUCache(2);
        lRUCache.put(1, 1); // cache is {1=1}
        lRUCache.put(2, 2); // cache is {1=1, 2=2}
        lRUCache.get(1);    // return 1
        lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
        lRUCache.get(2);    // returns -1 (not found)
        lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        lRUCache.get(1);    // return -1 (not found)
        lRUCache.get(3);    // return 3
        lRUCache.get(4);    // return 4

        Constraints:

            1 <= capacity <= 3000
            0 <= key <= 104
            0 <= value <= 105
            At most 2 * 105 calls will be made to get and put.

        https://leetcode.com/problems/lru-cache/
        */
        /*
        Extra Test Cases:
        ["LRUCache","put","put","get","put","put","get"]
        [[2],[2,1],[2,2],[2],[1,1],[4,1],[2]]
        ["LRUCache","put","put","put","put","get","get"] 13 / 22 testcases passed
        [[2],[2,1],[1,1],[2,3],[4,1],[1],[2]]
        ["LRUCache","put","put","get","put","get","put","get","get","get"] 4 / 22 testcases passed
        [[2],[1,0],[2,2],[1],[3,3],[2],[4,4],[1],[3],[4]]
        ["LRUCache","put","put","get","put","put","get"] 7 / 22 testcases passed
        [[2],[2,1],[2,2],[2],[1,1],[4,1],[2]]
        ["LRUCache","put","put","put","put","get","get"] 13 / 22 testcases passed
        [[2],[2,1],[1,1],[2,3],[4,1],[1],[2]]
        */
        public class LRUCache
        {
            private Dictionary<int, LinkedListNode<(int key, int value)>> dict = new();
            private LinkedList<(int key, int value)> linkedList = new();

            private int cap;

            public LRUCache(int capacity)
            {
                cap = capacity;
            }

            public int Get(int key)
            {
                if (!dict.ContainsKey(key))
                {
                    return -1;
                }

                var node = dict[key];
                linkedList.Remove(node);
                linkedList.AddFirst(node);

                return node.Value.value;
            }

            public void Put(int key, int value)
            {
                if (!dict.ContainsKey(key) && dict.Count >= cap)//Clean up over capacity,
                {                                               //when there is no existing key.
                    var node = linkedList.Last;
                    dict.Remove(node.Value.key);
                    linkedList.Remove(node);
                }

                var existingNode = dict.GetValueOrDefault(key);
                if (existingNode != null)
                {
                    linkedList.Remove(existingNode);//Remove the node from linked list for updating its position
                }                                   //so it can be moved to a appropriate position for being recently used.

                linkedList.AddFirst((key, value));
                dict[key] = linkedList.First;
            }
        }
        #endregion
        #region Merge K Sorted Lists 
        /*
        You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
        Merge all the linked-lists into one sorted linked-list and return it.

        Example 1:
        Input: lists = [[1,4,5],[1,3,4],[2,6]]
        Output: [1,1,2,3,4,4,5,6]
        Explanation: The linked-lists are:
        [
        1->4->5,
        1->3->4,
        2->6
        ]
        merging them into one sorted list:
        1->1->2->3->4->4->5->6

        Example 2:
        Input: lists = []
        Output: []

        Example 3:
        Input: lists = [[]]
        Output: []

        Constraints:

            k == lists.length
            0 <= k <= 104
            0 <= lists[i].length <= 500
            -104 <= lists[i][j] <= 104
            lists[i] is sorted in ascending order.
            The sum of lists[i].length will not exceed 104.

        */
        public ListNode MergeKLists(ListNode[] lists)
        {
            Stack<ListNode> items = new Stack<ListNode>();

            for (int i = lists.Length - 1; i >= 0; i--)
            {
                items.Push(lists[i]);
            }

            if (items.Count == 0)
                return null;

            if (items.Count == 1)
                return lists[0];

            while (items.Count > 1)
            {
                ListNode temp1 = items.Pop();
                ListNode temp2 = null;
                if (items.Count != 0)
                {
                    temp2 = items.Pop();
                }
                else
                {
                    temp2 = null;
                }
                items.Push(merge2(temp1, temp2));
            }

            return items.Pop();
        }

        public ListNode merge2(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0, l1);
            ListNode copy = dummy;
            while (l1 != null && l2 != null)
            {
                if (l2.val >= l1.val)
                {
                    dummy.next = l1;
                    l1 = l1.next;
                }
                else if (l1.val >= l2.val)
                {
                    dummy.next = l2;
                    l2 = l2.next;
                }
                dummy = dummy.next;
            }

            if (l1 != null && l2 == null)
            {
                dummy.next = l1;
            }
            else if (l2 != null && l1 == null)
            {
                dummy.next = l2;
            }

            return copy.next;
        }
        
        public ListNode MergeKListsNeet(ListNode[] lists)
        {
            if (lists.Length == 0)
            {
                return null;
            }

            while (lists.Length > 1)
            {
                var mergedLists = new ListNode[(lists.Length + 1) / 2];
                for (int i = 0; i < lists.Length; i += 2)
                {
                    var l1 = lists[i];
                    var l2 = (i + 1 < lists.Length) ? lists[i + 1] : null;
                    mergedLists[i / 2] = (MergeListsNeet(l1, l2));
                }
                lists = mergedLists;
            }

            return lists[0];
        }

        public ListNode MergeListsNeet(ListNode l1, ListNode l2)
        {
            var sorted = new ListNode();
            var current = sorted;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }
                current = current.next;
            }

            if (l1 != null)
            {
                current.next = l1;
            }
            else
            {
                current.next = l2;
            }

            return sorted.next;
        }


        public ListNode MergeKListsCustom(ListNode[] lists)
        {
            List<ListNode> items = new();
            for (int i = 0; i < lists.Length; i++)
            {
                while (lists[i] != null)
                {
                    items.Add(lists[i]);
                    lists[i] = lists[i].next;
                }
            }
            items = items.OrderBy(x => x.val).ToList();

            ListNode begin = new ListNode();
            ListNode res = begin;
            foreach (var item in items)
            {
                begin.next = item;
                begin = begin.next;
            }

            return res.next;
        }
        #endregion
        #region Reverse Nodes in k-Group
        /*
        https://leetcode.com/problems/reverse-nodes-in-k-group/
        */
        /*Extra Test Cases:
        head = [1,2] 48 / 62 testcases passed
        k = 2
        */
        //        ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4,new ListNode(5)))));
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            var dummy = new ListNode(0, head);
            var groupPrev = dummy;
            var groupNext = dummy;

            while (true)
            {
                var kth = getKth(groupPrev, k);
                if (kth == null)
                    break;

                groupNext = kth.next;

                // reverse group
                var prev = kth.next;
                var curr = groupPrev.next;

                while (curr != groupNext)
                {
                    var temp = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = temp;
                }

                var tmp = groupPrev.next;
                groupPrev.next = kth;
                groupPrev = tmp;
            }

            return dummy.next;
        }

        private ListNode getKth(ListNode curr, int k)
        {
            while (curr != null && k > 0)
            {
                curr = curr.next;
                k -= 1;
            }

            return curr;
        }
        //Nearly same runtime as neetcodes at the time of writing (17.03.2024)
        //Memory consumption difference is about 5%
        public ListNode ReverseKGroupCustom(ListNode head, int k)
        {
            List<ListNode> car = new();
            ListNode curr = head;

            while (curr != null)
            {
                car.Add(curr);
                curr = curr.next;
            }

            List<ListNode> results = new();
            for (int i = 0; i < car.Count; i += k)
            {
                if (i < car.Count)
                {
                    var temp = groupReverse(car, i, k);
                    results.AddRange(temp);
                }
            }
            ListNode preres = new ListNode();
            ListNode postpro = preres;
            foreach (var item in results)
            {
                postpro.next = new ListNode(item.val);
                postpro = postpro.next;
            }

            return preres.next;
        }

        public List<ListNode> groupReverse(List<ListNode> resi, int cont, int range)
        {
            List<ListNode> items = new();

            if (cont + range <= resi.Count)
            {
                for (int i = cont; i < cont + range; i++)
                {
                    if (i < resi.Count)
                        items.Add(resi[i]);
                }
                items.Reverse();
            }
            else
            {
                for (int i = cont; i < cont + range; i++)
                {
                    if (i < resi.Count)
                        items.Add(resi[i]);
                }
            }

            return items;
        }
        
        
        
        #endregion

    }
}