using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        #region Query Kth Smallest Trimmed Number -- Radix Sort

        /*
        You are given a 0-indexed array of strings nums, where each string is of equal length and consists of only digits.

        You are also given a 0-indexed 2D integer array queries where queries[i] = [ki, trimi]. For each queries[i], you need to:

            Trim each number in nums to its rightmost trimi digits.
            Determine the index of the kith smallest trimmed number in nums. If two trimmed numbers are equal, the number with the lower index is considered to be smaller.
            Reset each number in nums to its original length.

        Return an array answer of the same length as queries, where answer[i] is the answer to the ith query.

        Note:

        To trim to the rightmost x digits means to keep removing the leftmost digit, until only x digits remain.
        Strings in nums may contain leading zeros.            

        Example 1:

        Input: nums = ["102","473","251","814"], queries = [[1,1],[2,3],[4,2],[1,2]]
        Output: [2,2,1,0]
        Explanation:
        1. After trimming to the last digit, nums = ["2","3","1","4"]. The smallest number is 1 at index 2.
        2. Trimmed to the last 3 digits, nums is unchanged. The 2nd smallest number is 251 at index 2.
        3. Trimmed to the last 2 digits, nums = ["02","73","51","14"]. The 4th smallest number is 73.
        4. Trimmed to the last 2 digits, the smallest number is 2 at index 0.
        Note that the trimmed number "02" is evaluated as 2.

        Example 2:

        Input: nums = ["24","37","96","04"], queries = [[2,1],[2,2]]
        Output: [3,0]
        Explanation:
        1. Trimmed to the last digit, nums = ["4","7","6","4"]. The 2nd smallest number is 4 at index 3.
        There are two occurrences of 4, but the one at index 0 is considered smaller than the one at index 3.
        2. Trimmed to the last 2 digits, nums is unchanged. The 2nd smallest number is 24.

         

        Constraints:

            1 <= nums.length <= 100
            1 <= nums[i].length <= 100
            nums[i] consists of only digits.
            All nums[i].length are equal.
            1 <= queries.length <= 100
            queries[i].length == 2
            1 <= ki <= nums.length
            1 <= trimi <= nums[i].length
        C# Test Case:
        SmallestTrimmedNumbers(new string[] { "102","473","251","814" },new int[][] { new int[]{1,1},new int[]{2,3},new int[]{4,2},new int[]{1,2}});
        SmallestTrimmedNumbers(new string[] { "24", "37", "96", "04" }, new int[][] { new int[] { 2, 1 }, new int[] { 2, 2 } });
        SmallestTrimmedNumbers(new string[] { "325240361872", "440618160237", "785744447413", "820980201297", "470082520306", "874146483840", "425300857082", "088636787077", "813218016629", "459000328006", "188683382600" },
        new int[][] { new int[] { 6, 7 }, new int[] { 1, 8 }, new int[] { 11, 10 }, new int[] { 4, 8 }, new int[] { 11, 6 }, new int[] { 1, 1 }, new int[] { 3, 1 }, new int[] { 11, 10 } });
                
        https://leetcode.com/problems/query-kth-smallest-trimmed-number/description/

        Failed Case 1:
        ["64333639502","65953866768","17845691654","87148775908","58954177897","70439926174","48059986638","47548857440","18418180516","06364956881","01866627626","36824890579","14672385151","71207752868"]
        [[9,4],[6,1],[3,8],[12,9],[11,4],[4,9],[2,7],[10,3],[13,1],[13,1],[6,1],[5,10]]
        Failed Case 2:
        ["325240361872","440618160237","785744447413","820980201297","470082520306","874146483840","425300857082","088636787077","813218016629","459000328006","188683382600"]
        [[6,7],[4,4],[1,8],[11,10],[4,8],[11,6],[1,1],[3,1],[11,10]]
        Failed Case 3:
        ["1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111","1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111"]
        [[1,1],[2,2],[3,3],[4,4],[5,5],[6,6],[7,7],[8,8],[9,9],[10,10],[11,11],[12,12],[13,13],[14,14],[15,15],[16,16],[17,17],[18,18],[19,19],[20,20],[21,21],[22,22],[23,23],[24,24],[25,25],[26,26],[27,27],[28,28],[29,29],[30,30],[31,31],[32,32],[33,33],[34,34],[35,35],[36,36],[37,37],[38,38],[39,39],[40,40],[41,41],[42,42],[43,43],[44,44],[45,45],[46,46],[47,47],[48,48],[49,49],[50,50],[51,51],[52,52],[53,53],[54,54],[55,55],[56,56],[57,57],[58,58],[59,59],[60,60],[61,61],[62,62],[63,63],[64,64],[65,65],[66,66],[67,67],[68,68],[69,69],[70,70],[71,71],[72,72],[73,73],[74,74],[75,75],[76,76],[77,77],[78,78],[79,79],[80,80],[81,81],[82,82],[83,83],[84,84],[85,85],[86,86],[87,87],[88,88],[89,89],[90,90],[91,91],[92,92],[93,93],[94,94],[95,95],[96,96],[97,97],[98,98],[99,99],[100,100]]
        */


        //Begin
        public int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
        {
            //Radix sort
            int[] result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                result[i] = RadixSort(nums, queries[i][1], queries[i][0]);
            }

            return result;
        }

        //Middle
        private int RadixSort(string[] nums, int trim, int k)
        {
            string[] sorted = new string[nums.Length];
            nums.CopyTo(sorted, 0);

            int[] origIndices = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                origIndices[i] = i;
            }


            for (int i = 1; i <= trim; i++)
            {
                sorted = RadixSortPrivate(sorted, i, origIndices);
            }

            return origIndices[k - 1];
        }

        //End Processing
        private string[] RadixSortPrivate(string[] nums, int rightIndex, int[] origIndices)
        {
            int[] counts = new int[10];
            int offset = nums[0].Length - rightIndex;

            //Create counts
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i][offset] - '0';
                ++counts[val];
            }

            //Update counts with starting indices
            int startingIndex = 0;
            for (int i = 0; i < 10; i++)
            {
                int thisCount = counts[i];
                counts[i] = startingIndex;
                startingIndex += thisCount;
            }

            //Use started indices to create sorted array
            string[] sortedArray = new string[nums.Length];
            int[] sortedIndices = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i][offset] - '0';
                sortedArray[counts[val]] = nums[i];
                sortedIndices[counts[val]] = origIndices[i];
                ++counts[val];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                origIndices[i] = sortedIndices[i];
            }

            return sortedArray;
        }

        #endregion
        #region Maximum Gap -- Radix Sort
        /*
         Maximum Gap

        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.

        You must write an algorithm that runs in linear time and uses linear extra space.    

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.

        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.   

        Constraints:

            1 <= nums.length <= 105
            0 <= nums[i] <= 109

        https://leetcode.com/problems/maximum-gap/description/
        */
        #endregion

        int NUM_DIGITS = 10;

        public void countingSort(int[] arr, int placeVal)
        {
            // Sorts an array of integers where minimum value is 0 and maximum value is K
            int K = 10000;//Hardcoded because of our problem.
            int[] counts = new int[K];

            foreach (int elem in arr)
            {
                int current = elem / placeVal;
                counts[current % NUM_DIGITS] += 1;
            }

            // we now overwrite our original counts with the starting index
            // of each digit in our group of digits
            int startingIndex = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                int count = counts[i];
                counts[i] = startingIndex;
                startingIndex += count;
            }

            int[] sortedArray = new int[arr.Length];
            foreach (int elem in arr)
            {
                int current = elem / placeVal;
                sortedArray[counts[current % NUM_DIGITS]] = elem;
                // since we have placed an item in index mCounts[current % NUM_DIGITS],
                // we need to increment mCounts[current % NUM_DIGITS] index by 1 so the
                // next duplicate digit is placed in appropriate index
                counts[current % NUM_DIGITS] += 1;
            }

            // common practice to copy over sorted list into original arr
            // it's fine to just return the sortedArray at this point as well
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = sortedArray[i];
            }
        }

        public void radixSort(int[] arr)
        {
            int maxElem = int.MinValue;
            foreach (int elem in arr)
            {
                if (elem > maxElem)
                {
                    maxElem = elem;
                }
            }

            int placeVal = 1;
            while (maxElem / placeVal > 0)
            {
                countingSort(arr, placeVal);
                placeVal *= 10;
            }
        }

        #endregion
    }
}