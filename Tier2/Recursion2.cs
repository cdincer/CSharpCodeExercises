using System;
using System.Collections.Generic;
namespace Tier2
{
    public class Recursion2
    {
        #region Divide and Conquer
        #region Sort an Array
        /*
         Sort an Array

        Given an array of integers nums, sort the array in ascending order and return it.
        You must solve the problem without using any built-in functions in O(nlog(n)) time complexity and with the smallest space complexity possible.
        */
        //Bottom-up merge sort taken from wikipedia
        /*
        Example C-like code using indices for bottom-up merge sort algorithm 
        which treats the list as an array of n sublists(called runs in this example) of size 1, 
        and iteratively merges sub-lists back and forth between two buffers: 
        */
        // array A[] has the items to sort; array B[] is a work array,n is the item arrays length
        void BottomUpMergeSort(int[] A, int[] B, int n)
        {
            // Each 1-element run in A is already "sorted".
            // Make successively longer sorted runs of length 2, 4, 8, 16... until the whole array is sorted.
            for (int width = 1; width < n; width = 2 * width)
            {
                // Array A is full of runs of length width.
                for (int i = 0; i < n; i = i + 2 * width)
                {
                    // Merge two runs: A[i:i+width-1] and A[i+width:i+2*width-1] to B[]
                    // or copy A[i:n-1] to B[] ( if (i+width >= n) )
                    BottomUpMerge(A, i, Math.Min(i + width, n), Math.Min(i + 2 * width, n), B);
                }
                // Now work array B is full of runs of length 2*width.
                // Copy array B to array A for the next iteration.
                // A more efficient implementation would swap the roles of A and B.
                CopyArray(B, A, n);
                // Now array A is full of runs of length 2*width.
            }
        }

        //  Left run is A[iLeft :iRight-1].
        // Right run is A[iRight:iEnd-1  ].
        void BottomUpMerge(int[] A, int iLeft, int iRight, int iEnd, int[] B)
        {
            int i = iLeft;
            int j = iRight;
            // While there are elements in the left or right runs...
            for (int k = iLeft; k < iEnd; k++)
            {
                // If left run head exists and is <= existing right run head.
                if (i < iRight && (j >= iEnd || A[i] <= A[j]))
                {
                    B[k] = A[i];
                    i = i + 1;
                }
                else
                {
                    B[k] = A[j];
                    j = j + 1;
                }
            }
        }

        void CopyArray(int[] B, int[] A, int n)
        {
            for (int i = 0; i < n; i++)
                A[i] = B[i];
        }
        #endregion

        #endregion
    }
}