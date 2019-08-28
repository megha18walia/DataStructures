using System;
using System.Collections;
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

        // Input : [50,60,70,80,90]
        // Index : [3,0,1,4,2]
        public int[] ReturnInputArray(int[] Ar, int[] index)
        {
            int currValue = Ar[0];
            int currIndex = index[0];
            int nextValue;
            int nextIndex;
            for (int i = 0; i < Ar.Length; i++)
            {
              while(i != index[i])
                {
                    nextIndex = index[currIndex];
                    nextValue = Ar[currIndex];
                    Ar[currIndex] = currValue;
                    index[currIndex] = currIndex;
                    currValue = nextValue;
                    currIndex = nextIndex;
                    i = currIndex;
                }
             }
            return Ar;
        }

        //Rearrangement of an array to form a biggest number
        public string PrintLargeNumber(int[] Ar)
        {
            List<StringSup> lstStr = Ar.ToList().ConvertAll((int i) => new StringSup { Info = i.ToString() });
            QuickSortString(lstStr, 0, lstStr.Count - 1);
            return string.Join("", lstStr);


        }

        private void QuickSortString(List<StringSup> lstStr , int begin, int end)
        {
            if(begin >= end)
            {
                return;
            }
            StringSup pivot = lstStr[end];
            int current = begin;
            for (int i = begin; i < end; i++)
            {
                if (lstStr[i].CompareTo(pivot) == 1)
                {
                    string temp = lstStr[i].ToString();
                    lstStr[i].Info = lstStr[current].Info;
                    lstStr[current].Info = temp;
                    current++;
                }
            }

            string tem = lstStr[end].Info;
            lstStr[end].Info = lstStr[current].Info;
            lstStr[current].Info = tem;

            QuickSortString(lstStr, 0, current - 1);
                QuickSortString(lstStr, current + 1, end);
            
        }

        //Rearrangements of Array 
        //Input : [1,3,0,2]     Ar[Ar[i]] = i
        //Output : [2, 0, 3,1]

        public int[] ReArrangeIndex(int[] Ar)
        {
            for(int i = 0; i< Ar.Length; i++)
            {
                int pos = i;
                int temp = Ar[i];

                while(Ar[temp] != pos)
                {
                    int nextVal = Ar[temp];
                    int nextPos = temp;

                    Ar[temp] = pos;
                    i = pos;
                    temp = nextVal;
                    pos = nextPos;
                    
                }
                
            }

            return Ar;

        }

        //Array : [1,2,3,4,5,6,7,8]
        // Output : [1,3,2,5,4,7,6,8]
        //Even index : Small, Odd Index : large

        public int[] ArrayArrange(int[] Ar)
        {
            for(int i = 0; i< Ar.Length - 1; i++)
            {
                if(i%2 == 0 && Ar[i] > Ar[i+1])
                {
                    int temp = Ar[i];
                    Ar[i] = Ar[i + 1];
                    Ar[i + 1] = temp;
                }

                if(i %2 != 0 && Ar[i] < Ar[i+1])
                {
                    int temp = Ar[i];
                    Ar[i] = Ar[i + 1];
                    Ar[i + 1] = temp;
                }
            }

            return Ar;
        }

        // array : [1,2,3,-4, -5, 6, -7, 8]
        //Output : [1, -4, 2, -5, 3, -7,6 ,8]
        //+ve : even -ve : odd

        public int[] RearrangePosNegArray(int[] Ar)
        {
            int positive = 0;
            int negative = 0;

            for(int i = 0; i< Ar.Length; i++)
            {
                if(i % 2 == 0 && Ar[i] < 0)
                {
                    positive = i + 1 > positive ? i+1 : positive;
                    while (positive < Ar.Length && Ar[positive] < 0)
                        positive = positive + 2;

                    if (positive < Ar.Length)
                    {
                        int temp = Ar[i];
                        Ar[i] = Ar[positive];
                        Ar[positive] = temp;
                    }
                }

                if(i %2 == 1 && Ar[i] > 0)
                {
                    negative = i + 1 > negative ? i + 1 : negative;
                    while (negative < Ar.Length && Ar[negative] > 0)
                        negative = negative + 2;

                    if (negative < Ar.Length)
                    {
                        int temp = Ar[i];
                        Ar[i] = Ar[negative];
                        Ar[negative] = temp;
                    }
                }
            }
            return Ar;
        }

        //Array : [2,3,5,8,9,1,3]
        //Output : [6, 10. 24,45, 8, 27, 3]
        // Ar[i] = Ar[i - 1] * Ar[i + 1]

        public int[] ArrangeMultiples(int[] Ar)
        {
            int beg = 1;
            int end = 1;
            int temp = 1;

            for(int i = 0; i< Ar.Length; i++)
            {
                if(i == Ar.Length - 1 )
                {
                    end = Ar[i];
                    beg = temp;
                }
                else if(i == 0)
                {
                    beg = Ar[i];
                    end = Ar[i + 1];
                }
                else
                {
                    beg = temp;
                    end = Ar[i + 1];
                }


                int arrVal = Ar[i];
                Ar[i] =    beg * end;
                temp = arrVal;

            }
            return Ar;
        }

        //Array : [1,2,3,4,5]
        //Shuffle an Array

        public int[] ShuffleArray(int[] Ar)
        {
            for(int i = 0; i< Ar.Length; i++)
            {
                Random r = new Random();
                int index = r.Next(0, Ar.Length - 1 - i);
                int temp = Ar[index];
                Ar[index] = Ar[Ar.Length - 1 - i];
                Ar[Ar.Length - 1 - i] = temp;
            }
            return Ar;
        }

        // Input : [1,9,13,10,5,12,19,11]
        // Output : [1,9,13] [1,10,11] [1, 12 , 19]..... print only 1 sequence
        public void SequenceSortedArrayThree(int[] Ar)
        {
            int[] smaller = new int[Ar.Length];
            int[] larger = new int[Ar.Length];
            int min = 0;
            int max = Ar.Length - 1;
            smaller[0] = -1;
            larger[Ar.Length - 1] = -1;

            for(int i = 1; i< Ar.Length; i++)
            {
                if(Ar[i]< Ar[min] )
                {
                    min = i;
                    smaller[i] = -1;
                }
                else
                {
                    smaller[i] = min; 
                }
            }

            for(int i = Ar.Length - 2; i>=0; i--)
            {
                if(Ar[i] > Ar[max])
                {
                    larger[i] = -1;
                    max = i;
                }
                else
                {
                    larger[i] = max;
                }
            }

            for(int i = 0; i< Ar.Length; i++)
            {
                if(smaller[i] != -1 && larger[i] != -1)
                {
                    Console.WriteLine(Ar[smaller[i]] + " " + Ar[i] + " " + Ar[larger[i]]);
                }
            }

        }

        //Input : [1,0,1,1,1,0,0]
        //Output : Maximum sub array - [0,1,1,1,0,0]
        public string SubArrayLength(int [] Ar)
        {
            for(int i = 0; i< Ar.Length; i++)
            {
                Ar[i] = Ar[i] == 0 ? -1 : Ar[i];
            }

            Dictionary<int, int> sum = new Dictionary<int, int>();
            int sumInfo = 0;
            int len = 0;
            int index = 0;

            for (int i = 0; i< Ar.Length; i++)
            {
                sumInfo += Ar[i];
                if(sum.ContainsKey(sumInfo))
                {
                    if(len < i - sum[sumInfo])
                    {
                        len = i - sum[sumInfo];
                        index = i;
                    }
                }
                else
                {
                    sum[sumInfo] = i;
                }  
            }

            int begIndex = index - len + 1;
            return "Length of Array : " + len + " : (" + begIndex + " , " + index + ")";


        }

        //Input : [1,2,3,-6,-4,0,2,9]
        //Output : Maximum Product of a sub array is : 144 

        public void MaxProdSubArray(int[] Ar)
        {
            int max = 1;
            int min = 1;
            int prod = 1;

            for(int i = 0; i< Ar.Length; i++)
            {
                if(Ar[i] > 0)
                {
                    max = max * Ar[i];
                    min = min * Ar[i];
                    min = min > 0 ? 1 : min;
                }

                if(Ar[i] == 0)
                {
                    min = 1;
                    max = 1;
                }

                if(Ar[i] < 0)
                {
                    int temp = max;
                    max = min * Ar[i];
                    min = temp * Ar[i];
                    max = max > 0 ? max : 1;
                }

                prod = max > prod ? max : prod;
            }

            Console.WriteLine("Max Product is : " + prod);
        }

        //Input : [16,5,17,4,3,2,5,1]
        //Output : [17,17,5,5,5,5,1,-1]
        //Replace the current element with the next max element
        public int[] ReturnReplaceArray(int[] Ar)
        {
            int currMax = -1;
            int nextMax = Ar[Ar.Length - 1];

            for(int i = Ar.Length - 1; i >= 0; i--)
            {
                if (Ar[i] > nextMax)
                    nextMax = Ar[i];
                Ar[i] = currMax;
                currMax = nextMax;
            }

            return Ar;
        }


    }

    class StringSup : IComparable
    {
        
        public string Info { get; set; }

        public int CompareTo(object obj)
        {
            StringSup ss = (StringSup)obj;
            string X = this.Info + ss.Info;
            string Y = ss.Info + this.Info;

            int XX = Convert.ToInt32(X);
            int YY = Convert.ToInt32(Y);

            return XX > YY ? 1 : -1;
        }

        public override string ToString()
        {
            return Info;

        }
    }
}
