using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Rotation
{
    public class BasicRotation
    {
        //Create a temporary array
        //Time Complexiety : O(Len)
        //Space Complexiety : O(n)
        public int[] RotateArray(int[] Arr, int n)
        {
            int len = Arr.Length;
            int[] temp = new int[n];
            int k = 0;
            for (int j = len-n; j< len; j++)
            {
                temp[k] = Arr[j];
                k++;
            }

            int k1 = len - 1;
            for(int i = len-n-1; i>=0; i--)
            {
                Arr[k1] = Arr[i];
                k1--;
            }

            for(int i = 0; i< n;i++)
            {
                Arr[i] = temp[i];
            }
            return Arr;

        }

        //Create a Rotation One By One
        //Complexiety : O(len * n)
        public int[] RotateArrayOneByOne(int[] Arr, int n)
        {
            int len = Arr.Length;

            for(int i = 0; i< n; i++)
            {
                int temp = Arr[len - n + i];
                int j;
                for( j = i+len-n-1; j >=i; j--)
                {
                    Arr[j + 1] = Arr[j];
                }
                Arr[j+1] = temp;
            }
            return Arr;
        }

        //A Rotation array besed on GCD
        //Complexiety : O(n)
        public int[] RotateGCDArray(int[] Arr, int n)
        {
            int len = Arr.Length;
            int fact = gcd(len, n);
            
            for (int i = 0; i < fact; i++)
            {
                int j = i;
                int k;
                int temp = Arr[i];
                while(true)
                {
                    k = j + n;
                    if (k >= len)
                        k = k - len;
                    if (k == i)
                        break;

                    Arr[j] = Arr[k];
                    j = k;

                }

                Arr[j] = temp;

            }
            return Arr;
        }

        public int gcd(int a, int b)
        {
            while(a != b)
            {
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            }
            return a;
        }

        //Rotation by Reversal Algorithm
        //Complexiety : O(n)
        public int[] RotateByReverse(int[] Arr, int n)
        {
            int len = Arr.Length;
            Reverse(Arr, 0, n - 1);
            Reverse(Arr, n, len - 1);
            Reverse(Arr, 0, len - 1);

            return Arr;

        }

        //Reverse the array
        public void Reverse(int[] Arr, int begin, int end)
        {
            int mid = (begin + end) / 2;

            for (int i = begin, j = end; i <= mid; i++)
            {
                int temp = Arr[i];
                Arr[i] = Arr[j];
                Arr[j] = temp;
                j--;
            }
        }

        //Find Quick Rotations
        public void PrintRotations(int[] Arr, int n)
        {
            int count = 0;
            int start = 0;
            start = start + n;
            while (count != Arr.Length)
            {
                
                if(start > Arr.Length - 1)
                {
                    start = 0;
                }

                Console.Write(Arr[start] + " ");
                start++;
                count++;
            }

        }
        
        //Find the number of Rotations with teh maximum hamming distance
        // 1 2 3 4 5 5 5 6 7
        //Maximim hamming distance will be 7 , rotation will be 2
        public int RotationWithMaxHammingDist(int[] Arr)
        {
            int len = Arr.Length;
            int maxhmm = 0;
            int rotation = 0;
            int[] tempArr = new int[2*len];
            for(int i = 0, j = len; i < len && j < 2*len; i++, j++)
            {
                tempArr[i] = Arr[i];
                tempArr[j] = Arr[i];
            }

            for(int i = 0; i< len; i++)
            {
                int hamm = 0;
                for(int j = i; j< len+i; j++)
                {
                    if(tempArr[j] != tempArr[j+1])
                    {
                        hamm++;
                        continue;
                    }

                    if(maxhmm < hamm)
                    {
                        maxhmm = hamm;
                        rotation = i;
                    }
                    hamm = 0;
                    
                }
            }
            return rotation;
        }

        //Query 1x : Right rotate by x times
        //Query 2y : Left rotate by y times
        //Query 3xy : Sum from x to y

        public void PrintSum(int[] Arr)
        {
            //+ve : Right, -ve : Left
            int netRotation = 0;
            int rotation = 0;
            int[] preSum = new int[Arr.Length];
            for(int i = 0; i< Arr.Length; i++)
            {
                for(int j = 0; j<= i; j++)
                {
                    preSum[i] += Arr[j];
                    
                }
                Console.Write(preSum[i] + " ");
            }
            Console.WriteLine();

            LeftRotate(1, ref rotation, Arr);
            netRotation += rotation;
            RightRotate(4, ref rotation, Arr);
            netRotation += rotation;
            PrintSum(preSum, netRotation, 1, 4);
            
        }

        private void LeftRotate(int n, ref int rotation, int [] Arr)
        {
            n = n % Arr.Length;
            n = n * -1;
            rotation = n;
        }

        private void RightRotate(int n, ref int rotation, int[] Arr)
        {
            n = n % Arr.Length;
            rotation = n;
        }

        private void PrintSum(int[] PreSum, int netRotation, int begin, int end)
        {
            int len = PreSum.Length;

            int range = end - begin;

            int first = len - netRotation;

            begin = first + begin;
            begin = begin % len;

            int last = begin + range;
            last = last % len;
            int sum = 0;
            if (begin == 0)
            {
                sum = PreSum[last];
            }
            else
            {
                if (last < begin)
                {
                    int num = begin + range - len;
                    sum = PreSum[len-1] - PreSum[begin - num] + PreSum[last];
                }
                else
                {
                    sum = PreSum[last] - PreSum[(begin - 1) % len];
                }
            }
            Console.WriteLine("Sum of Rotated array is : " + sum);
        }

        //calculate the elemnt at a given index after rotations
        public int ReturnPosition(int[] arr, int index)
        {
            int[,] rotations = new int[4, 2] { { 0, 4 }, { 3, 6 }, { 1, 3 }, { 4, 7 } };
            return getRotationPosition(arr, rotations, index);   
        }
        private int getRotationPosition(int[] Arr, int[ , ]  Rotations, int index)
        {
            int len = Rotations.GetUpperBound(0) - Rotations.GetLowerBound(0);

            for(int i = len; i >= 0; i--)
            {
                int left = Rotations[i, 0];
                int right = Rotations[i, 1];

                if(left <= index && right >= index)
                {
                    if (index == left)
                        index = right;
                    else
                        index--;
                }
            }
            return Arr[index];

        }

        

    }
}