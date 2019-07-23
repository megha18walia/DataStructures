using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Rotation
{
    public class SortedRotatedArray
    {
        //Search the Sorted rotated Array 
        //Complexity : O(log n)
        public int SearchSortedRotated(int[] Arr, int element)
        {
            int pos = -1;
            SearchArray(Arr, ref pos, element);
            return pos;
        }

        private void SearchArray(int[] Arr, ref int pos, int element)
        {
            int piv = -1;

            // Search for the Pivot
            getPivot(Arr, 0, Arr.Length - 1, ref piv);

            // After Searching pivot , search for the element
            if (Arr[0] > element)
            {
                GetElementPosition(Arr, piv, Arr.Length - 1, element, ref pos);
            }
            else
            {
                GetElementPosition(Arr, 0, piv - 1, element, ref pos);
            }

        }

        private void getPivot(int[] Arr, int low, int high, ref int pivot)
        {

            if (high - low == 1)
            {
                if (Arr[high] < Arr[low])
                    pivot = low + 1;
                return;
            }
            int mid = (low + high) / 2;

            if (Arr[mid] > Arr[mid - 1] && Arr[mid] > Arr[mid + 1])
            {
                pivot = mid + 1;
            }

            if (Arr[mid - 1] > Arr[mid] && Arr[mid] < Arr[mid + 1])
            {
                pivot = mid;
            }

            getPivot(Arr, 0, mid, ref pivot);
            getPivot(Arr, mid, high, ref pivot);


        }

        private void GetElementPosition(int[] Arr, int low, int high, int element, ref int pos)
        {

            if (high - low == 1)
            {
                if (Arr[low] == element)
                    pos = low;
                if (Arr[high] == element)
                    pos = high;
                return;
            }

            int mid = (low + high) / 2;
            if (Arr[mid] == element)
                pos = mid;

            if (Arr[mid] < element)
            {
                low = mid;
            }
            else
            {
                high = mid;
            }

            GetElementPosition(Arr, low, high, element, ref pos);
        }

        //Find Sum Pairs
        public int FindSumPairSortedRotated(int[] Arr, int sum)
        {
            int pivot = -1;
            getPivot(Arr, 0, Arr.Length - 1, ref pivot);

            return FindSumPair(Arr, pivot - 1, pivot, sum);
        }

        private int FindSumPair(int[] Arr, int high, int low, int sum)
        {
            int count = 0;

            while (low != high)
            {
                int S = Arr[high] + Arr[low];
                if (S < sum)
                    low = low + 1;
                else if (S > sum)
                    high = high - 1;
                else
                {
                    Console.WriteLine("Sum Pair - > - " + Arr[low] + " , " + Arr[high]);
                    count++;
                    high = high - 1;
                }

                if (low >= Arr.Length)
                    low = 0;

                if (high < 0)
                    high = Arr.Length - 1;
            }
            return count;

        }

        //Find the maximum rotated Array Sum (i*Arr[i]  => i = index on the element
        // Complexity : O(n)
        public int maxSum(int[] arr)
        {
            int currSum = 0;
            int max = 0;
            int arrSum = 0;

            for(int i = 0; i< arr.Length; i++)
            {
                arrSum = arrSum + arr[i];
                currSum = currSum + arr[i] * i;
            }

            max = currSum;

            for(int j = 1; j< arr.Length; j++)
            {
                currSum = currSum - arrSum + arr.Length * arr[j - 1];
                if (currSum > max)
                    max = currSum;

                Console.WriteLine("Rotated Array : " + currSum);
            }
            return max;
        }
    }
}
