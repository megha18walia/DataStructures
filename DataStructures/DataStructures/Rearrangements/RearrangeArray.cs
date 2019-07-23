using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Rearrangements
{
    public class RearrangeArray
    {
        //using place Ar[i] at correct position i.e Ar[i] = i
        public int[] ReArrangeArray(int[] Ar)
        {
            int len = Ar.Length;
            int y;
            int x;

            for(int i = 0; i< len; i++)
            {
                if (Ar[i] != i && Ar[i] != -1)
                {
                    x = Ar[i];

                    while (Ar[x] != x && Ar[x] != -1)
                    {
                        y = Ar[x];
                        Ar[x] = x;
                        x = y;
                    }

                    Ar[x] = x;

                    if (Ar[i] != i)
                        Ar[i] = -1;
                }
            }
            return Ar;
        }

        //using swap Ar[i] with Ar[Ar[i]]
        public int[] ReArrangeSwapArray(int[] Ar)
        {
            for(int i = 0; i< Ar.Length;)
            {
                if(Ar[i] != -1 && Ar[i] != i)
                {
                    int temp = Ar[Ar[i]];
                    Ar[Ar[i]] = Ar[i];
                    Ar[i] = temp;
                }
                else
                {
                    i++;
                }
            }
            return Ar;
        }

        //Original Array [1,2,3,4]
        //Output Array [2,3,1,4]
        //Even Positions : greater than previous positions and vice versa

        public int[] ArrangedArray(int[] Arr)
        {
            QuickSort(Arr, 0, Arr.Length - 1);

            int[] resArr = new int[Arr.Length];
            int res = Arr.Length - 1;

            int len = Arr.Length / 2;

            if (Arr.Length % 2 != 0)
                len++;

            int i1 = 0;
            int j1 = 1;
            for (int i = 0; i< len; i++)
            {
                if (i1 < Arr.Length)
                {
                    resArr[i1] = Arr[len - 1 - i];
                    i1 = i1 + 2;
                }

                if (j1 < Arr.Length)
                {
                    resArr[j1] = Arr[len + i];
                    j1 = j1 + 2;
                }
                
            }

            return resArr;
        }

        private void QuickSort(int[] Arr, int begin, int end)
        {
            if (end - begin >= 1)
            {
                int curr = begin;
                int pivot = end;

                for (int i = begin; i<= end-1; i++ )
                {
                    if(Arr[pivot] > Arr[i])
                    {
                        int temp = Arr[curr];
                        Arr[curr] = Arr[i];
                        Arr[i] = temp;
                        curr++;
                    }
                }

                int temp1 = Arr[pivot];
                Arr[pivot] = Arr[curr];
                Arr[curr] = temp1;

                QuickSort(Arr, begin, curr - 1);
                QuickSort(Arr, curr + 1, end);

            }
            else
                return;
        }

        //arrange positive and negative numbers alternatively
        public int[] ReArrangeArrayPositiveNegative(int[] Ar)
        {
            int pivot = 0;
            int curr = 0;

            for(int i =0; i< Ar.Length; i++)
            {
                if(Ar[i] < pivot)
                {
                    int temp = Ar[curr];
                    Ar[curr] = Ar[i];
                    Ar[i] = temp;
                    curr++;
                }
            }

            if(Ar.Length / 2 <= curr)
            {
                for(int i = 0; i< Ar.Length; i = i+2)
                {
                    if (i + 1 < Ar.Length)
                    {
                        Swap(Ar, i + 1, curr);
                        curr++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < Ar.Length; i = i + 2)
                {
                    if (i < Ar.Length)
                    {
                        Swap(Ar, i, curr);
                        curr++;
                    }
                }
            }
            return Ar;

        }

        private void Swap(int[] Arr, int i, int j)
        {
            int temp = Arr[i];
            Arr[i] = Arr[j];
            Arr[j] = temp;
        }

        //Arrange positive and negative numbers without sorting
        public int[] ArrangeNumbersWithoutSorting(int[] Arr)
        {
            for(int i = 0; i< Arr.Length; i++)
            {
                if(i % 2 == 0 && Arr[i] > 0)
                {
                    int j = i + 1;
                    while (j < Arr.Length && Arr[j] > 0 )
                    {
                        j++;
                    }

                    if (j < Arr.Length)
                    {
                        int temp = Arr[j];
                        for (int k = i; k < j; k++)
                            Arr[k + 1] = Arr[k];

                        Arr[i] = temp;
                    }
                }

                if (i % 2 != 0 && Arr[i] < 0)
                {
                    int j = i + 1;
                    while (j < Arr.Length && Arr[j] < 0 )
                    {
                        j++;
                    }

                    if (j < Arr.Length)
                    {
                        int temp = Arr[j];
                        for (int k = i; k <= j; k++)
                            Arr[k + 1] = Arr[k];

                        Arr[i] = temp;
                    }
                }
            }

            return Arr;
        }

        //Print All the zeros at the end - swapping
        public int[] PrintZeroEnd(int[] Ar)
        {
            int len = Ar.Length;
            int end = len - 1;

            for(int i = 0; i< len; i++)
            {
                if(Ar[i] == 0)
                {
                    while (Ar[end] == 0 && end > i)
                        end--;

                    Ar[i] = Ar[end];
                    Ar[end] = 0;

                }
            }

            return Ar;
        }

        //print all zeros in the end
        public int[] PrintZeroRotationEnd(int[] Ar)
        {
            for(int i = 0; i< Ar.Length;)
            {
                if(Ar[i] == 0)
                {
                    int j = i;
                    while (j < Ar.Length && Ar[j] == 0  )
                        j++;

                    if (j < Ar.Length)
                    {
                        Ar[i] = Ar[j];
                        Ar[j] = 0;
                        i = i+1 ;
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    i++;
                }
            }

            return Ar;
        }

        //Input : [1,5,3,9,2,6],  k = 5
        //How many swaps are required to make elements less than k altogether

        public int ReturnSwapsForGroup(int[] Ar, int k)
        {
            int Wnd = 0;
            for(int i = 0; i< Ar.Length; i++)
            {
                Wnd = Ar[i] <= k ? Wnd + 1 : Wnd;
            }

            int bad = 0;
            int min = Ar.Length;
            int j = 0;
            int l = 0;
            while(l < Ar.Length && j < Wnd)
            {
                if (Ar[l] > k)
                    bad++;

                j++;
                l++;
                if(j == Wnd)
                {
                    if (min > bad)
                        min = bad;
                    bad = 0;
                    j = 0;
                }
            }
            return min;
        }

        // Input : [2,2,4,0,0 ,8,9,0]
        // Output : step 1:  [4, 0 ,4,0,0,8,9,0]
        //          step 2:  [4,4,8,9,0,0,0,0]

        public int[] ShiftAndDoubleArray(int[] Ar)
        {
            for(int i = 0; i< Ar.Length - 2; i++)
            {
                if (Ar[i] == Ar[i + 1])
                {
                    Ar[i] = 2 * Ar[i];
                    Ar[i + 1] = 0;
                }
            }

            for(int i = 0; i< Ar.Length; i++)
            {
                int j = 0;
                if(Ar[i] == 0)
                {
                    j = i;
                    while (j < Ar.Length && Ar[j] == 0)
                        j++;

                    if (j == Ar.Length)
                        break;

                    Ar[i] = Ar[j];
                    Ar[j] = 0;
                }
            }

            return Ar;
        }






    }
}
