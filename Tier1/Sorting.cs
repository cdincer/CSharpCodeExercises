using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpCodeExercises.Tier1
{
    //https://leetcode.com/explore/learn/card/sorting/693/introduction/ 
    public class Sorting
    {
        #region Comparison Based Sort
        #region Sort Colors -- Selection Sort
        /*Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.

        We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.

        You must solve this problem without using the library's sort function.
       
        Example 1:

        Input: nums = [2,0,2,1,1,0]
        Output: [0,0,1,1,2,2]

        Example 2:

        Input: nums = [2,0,1]
        Output: [0,1,2]

         

        Constraints:

            n == nums.length
            1 <= n <= 300
            nums[i] is either 0, 1, or 2.

         

        Follow up: Could you come up with a one-pass algorithm using only constant extra space?

        https://leetcode.com/problems/sort-colors/solutions/
        */
        public void SortColors(int[] nums)
        {
            // Mutates nums so that it is sorted via selecting the minimum element and
            // swapping it with the corresponding index
            int min_index;
            for (int i = 0; i < nums.Length; i++)
            {
                min_index = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[min_index])
                    {
                        min_index = j;
                    }
                }
                // Swap current index with minimum element in rest of list
                int temp = nums[min_index];
                nums[min_index] = nums[i];
                nums[i] = temp;
            }
        }
        #endregion
        #region Height Checker -- Bubble Sort
        /*
        A school is trying to take an annual photo of all the students. The students are asked to stand in a single file line in non-decreasing order by height. Let this ordering be represented by the integer array expected where expected[i] is the expected height of the ith student in line.

        You are given an integer array heights representing the current order that the students are standing in. Each heights[i] is the height of the ith student in line (0-indexed).

        Return the number of indices where heights[i] != expected[i].
     
        Example 1:

        Input: heights = [1,1,4,2,1,3]
        Output: 3
        Explanation: 
        heights:  [1,1,4,2,1,3]
        expected: [1,1,1,2,3,4]
        Indices 2, 4, and 5 do not match.

        Example 2:

        Input: heights = [5,1,2,3,4]
        Output: 5
        Explanation:
        heights:  [5,1,2,3,4]
        expected: [1,2,3,4,5]
        All indices do not match.

        Example 3:

        Input: heights = [1,2,3,4,5]
        Output: 0
        Explanation:
        heights:  [1,2,3,4,5]
        expected: [1,2,3,4,5]
        All indices match.

        Constraints:

            1 <= heights.length <= 100
            1 <= heights[i] <= 100


         https://leetcode.com/problems/height-checker/description/
        */
        //Made this way because of sorting card/question.
        public int HeightChecker(int[] heights)
        {

            int counter = 0;
            bool swapped = true;
            int[] heights2 = new int[heights.Length];
            Array.Copy(heights, heights2, heights.Length);
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < heights.Length - 1; i++)
                {
                    if (heights[i] > heights[i + 1])
                    {
                        int temp = heights[i + 1];
                        heights[i + 1] = heights[i];
                        heights[i] = temp;
                        swapped = true;
                    }
                }
            }

            for (int i = 0; i < heights.Length; i++)
            {
                if (heights[i] != heights2[i])
                {
                    counter++;
                }
            }

            return counter;
        }
        #endregion
        #region Insertion Sort List -- Insertion Sort
        /*
        Given the head of a singly linked list, sort the list using insertion sort, and return the sorted list's head.

        The steps of the insertion sort algorithm:

            Insertion sort iterates, consuming one input element each repetition and growing a sorted output list.
            At each iteration, insertion sort removes one element from the input data, finds the location it belongs within the sorted list and inserts it there.
            It repeats until no input elements remain.

        The following is a graphical example of the insertion sort algorithm. The partially sorted list (black) initially contains only the first element in the list. One element (red) is removed from the input data and inserted in-place into the sorted list with each iteration.

         
        Example 1:

        Input: head = [4,2,1,3]
        Output: [1,2,3,4]

        Example 2:

        Input: head = [-1,5,3,4,0]
        Output: [-1,0,3,4,5]

         //4,2,1,3 For Testing with classes above.(Code below cannot be used with C# standard LinkedList)
        head = new ListNode(4, new ListNode(2, new ListNode(1, new ListNode(3))));

        Constraints:

            The number of nodes in the list is in the range [1, 5000].
            -5000 <= Node.val <= 5000


        https://leetcode.com/problems/insertion-sort-list/solutions/
        */
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
        public ListNode InsertionSortList(ListNode head)
        {

            ListNode dummy = new ListNode();
            ListNode curr = head;

            while (curr != null)
            {
                // At each iteration, we insert an element into the resulting list.
                ListNode prev = dummy;

                // find the position to insert the current node
                while (prev.next != null && prev.next.val <= curr.val)
                {
                    prev = prev.next;
                }

                ListNode next = curr.next;
                // insert the current node to the new list
                curr.next = prev.next;
                prev.next = curr;

                // moving on to the next iteration
                curr = next;
            }

            return dummy.next;

        }
        #endregion
        #region Sort an Array -- Heap Sort
        /*
        Given an array of integers nums, sort the array in ascending order and return it.

        You must solve the problem without using any built-in functions in O(nlog(n)) time complexity and with the smallest space complexity possible.

         

        Example 1:

        Input: nums = [5,2,3,1]
        Output: [1,2,3,5]
        Explanation: After sorting the array, the positions of some numbers are not changed (for example, 2 and 3), while the positions of other numbers are changed (for example, 1 and 5).

        Example 2:

        Input: nums = [5,1,1,2,0,0]
        Output: [0,0,1,1,2,5]
        Explanation: Note that the values of nums are not necessairly unique.

         

        Constraints:

            1 <= nums.length <= 5 * 104
            -5 * 104 <= nums[i] <= 5 * 104
        https://leetcode.com/problems/sort-an-array/
        */
        public int[] SortArray(int[] arr)
        {
            // Mutates elements in lst by utilizing the heap data structure
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                maxHeapify(arr, arr.Length, i);
            }

            for (int i = arr.Length - 1; i > 0; i--)
            {
                // swap last element with first element
                int temp = arr[i];
                arr[i] = arr[0];
                arr[0] = temp;
                // note that we reduce the heap size by 1 every iteration
                maxHeapify(arr, i, 0);
            }
            return arr;
        }

        private void maxHeapify(int[] arr, int heapSize, int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int largest = index;
            if (left < heapSize && arr[left] > arr[largest])
            {
                largest = left;
            }
            if (right < heapSize && arr[right] > arr[largest])
            {
                largest = right;
            }
            if (largest != index)
            {
                int temp = arr[index];
                arr[index] = arr[largest];
                arr[largest] = temp;
                maxHeapify(arr, heapSize, largest);
            }
        }
        #endregion
        #endregion
    }
}