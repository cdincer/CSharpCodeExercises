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
        #region Kth Largest Element in an Array -- Heap Sort
        /*
        Given an integer array nums and an integer k, return the kth largest element in the array.

        Note that it is the kth largest element in the sorted order, not the kth distinct element.

        You must solve it in O(n) time complexity.

         

        Example 1:

        Input: nums = [3,2,1,5,6,4], k = 2
        Output: 5

        Example 2:

        Input: nums = [3,2,3,1,2,4,5,5,6], k = 4
        Output: 4

         

        Constraints:

            1 <= k <= nums.length <= 105
            -104 <= nums[i] <= 104

        https://leetcode.com/problems/kth-largest-element-in-an-array/description/
        */
        public int FindKthLargest(int[] nums, int k)
        {
            int start = 0, end = nums.Length - 1, index = nums.Length - k;
            while (start < end)
            {
                int pivot = partion(nums, start, end);
                if (pivot < index) start = pivot + 1;
                else if (pivot > index) end = pivot - 1;
                else return nums[pivot];
            }
            return nums[start];
        }

        private int partion(int[] nums, int start, int end)
        {
            int pivot = start, temp;
            while (start <= end)
            {
                while (start <= end && nums[start] <= nums[pivot]) start++;
                while (start <= end && nums[end] > nums[pivot]) end--;
                if (start > end) break;
                temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
            }
            temp = nums[end];
            nums[end] = nums[pivot];
            nums[pivot] = temp;
            return end;
        }
        #endregion
        #endregion
        #region Non-comparison Based Sort
        #region Sort Colors -- Counting Sort
        /*
        Same as Sort Colors above,this time using counting sort .
        */
        public void SortColorsCounting(int[] nums)
        {

            // Sorts an array of integers (handles shifting of integers to range 0 to K)
            int shift = nums.Min();
            int K = nums.Max();
            int[] counts = new int[K + 1];
            foreach (int elem in nums)
            {
                counts[elem - shift] += 1;
            }
            // we now overwrite our original counts with the starting index
            // of each element in the final sorted array
            int startingIndex = 0;
            for (int i = 0; i < K + 1; i++)
            {
                int count = counts[i];
                counts[i] = startingIndex;
                startingIndex += count;
            }

            int[] sortedArray = new int[nums.Length];
            foreach (int elem in nums)
            {
                sortedArray[counts[elem - shift]] = elem;
                // since we have placed an item in index counts[elem], we need to
                // increment counts[elem] index by 1 so the next duplicate element
                // is placed in appropriate index
                counts[elem - shift] += 1;
            }

            // common practice to copy over sorted list into original arr
            // it's fine to just return the sortedArray at this point as well
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = sortedArray[i];
            }

        }
        #endregion
        #region Minimum Absolute Difference -- Counting Sort
        /*
        Given an array of distinct integers arr, find all pairs of elements with the minimum absolute difference of any two elements.

        Return a list of pairs in ascending order(with respect to pairs), each pair [a, b] follows

            a, b are from arr
            a < b
            b - a equals to the minimum absolute difference of any two elements in arr
         
        Example 1:

        Input: arr = [4,2,1,3]
        Output: [[1,2],[2,3],[3,4]]
        Explanation: The minimum absolute difference is 1. List all pairs with difference equal to 1 in ascending order.

        Example 2:

        Input: arr = [1,3,6,10,15]
        Output: [[1,3]]

        Example 3:

        Input: arr = [3,8,-10,23,19,-4,-14,27]
        Output: [[-14,-10],[19,23],[23,27]]

         

        Constraints:

            2 <= arr.length <= 105
            -106 <= arr[i] <= 106

        Test Case:
        Input:[40,11,26,27,-20] Expected:[[26,27]]

        https://leetcode.com/problems/minimum-absolute-difference/description/
        */
        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            List<IList<int>> result = new List<IList<int>>();
            int minDiff = int.MaxValue;
            Array.Sort(arr);
            for (int i = 0; i < arr.Length - 1; i++)
            {
                minDiff = Math.Min(minDiff, Math.Abs(arr[i] - arr[i + 1]));
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var diff = Math.Abs(arr[i] - arr[i + 1]);
                if (diff == minDiff)
                {
                    result.Add(new List<int>() { arr[i], arr[i + 1] });
                }
            }
            return result;
        }
        #endregion
        #endregion
    }
}