using DataStructures.Rearrangements;
using DataStructures.Rotation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rotation
            
            int[] input = { 16, 17, 4, 3, 5, 2 };
            int[] index = { 3, 0, 1, 4, 6,7, 8, 2 , 5};
            Console.WriteLine("Input Array is - ");
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i] + " ");
            }

            //Console.WriteLine("Input Index  is - ");
            //for (int i = 0; i < index.Length; i++)
            //{
            //    Console.Write(index[i] + " ");
            //}
            Console.WriteLine();
            //BasicRotation BR = new BasicRotation();
            ////int[] Res = BR.RotateArray(input, 2);
            //int[] Res = BR.RotateArrayOneByOne(input, 2);
            // int[] Res = BR.RotateGCDArray(input, 7);

            // int[] Res = BR.RotateByReverse(input, 7);
            //BR.PrintRotations(input, 3);
            //Console.WriteLine();
            //BR.PrintRotations(input, 5);
            //Console.WriteLine();
            //BR.PrintRotations(input, 7);

            //int rotations =  BR.RotationWithMaxHammingDist(input);
            //Console.WriteLine("Max Hamming distance Rotations : " + rotations);

            // BR.PrintSum(input);

            //Console.WriteLine(BR.ReturnPosition(input, 6));

            // SortedRotatedArray SR = new SortedRotatedArray();

            //int pos = SR.SearchSortedRotated(input, 12);
            // int pos = SR.FindSumPairSortedRotated(input, 15);
            // int pos = SR.maxSum(input);
            //Console.WriteLine(pos);

            //TestRotation TR = new TestRotation();
            //int pos = TR.ReturnRotation(input);
            //Console.WriteLine("Rotation Count " + pos);

            RearrangeArray Obj = new RearrangeArray();
            //int[] Res = Obj.ReArrangeArray(input);
            //int[] Res = Obj.ArrangedArray(input);
            //int[] Res = Obj.ReArrangeArrayPositiveNegative(input);
            //int[] Res = Obj.ArrangeNumbersWithoutSorting(input);
            //int[] Res = Obj.PrintZeroEnd(input);
            //int[] Res = Obj.PrintZeroRotationEnd(input);
            //int[] Res = Obj.ShiftAndDoubleArray(input);
            //int[] Res = Obj.ReturnInputArray(input, index);
            //Console.WriteLine( Obj.PrintLargeNumber(input));
            //int[] Res = Obj.ReArrangeIndex(input);
            //int[] Res = Obj.RearrangePosNegArray(input);
            //int[] Res = Obj.ArrangeMultiples(input);

            //int[] Res = Obj.ShuffleArray(input);
            int[] Res = Obj.ReturnReplaceArray(input);
            Console.WriteLine("Output Array is - ");
            for (int i = 0; i < Res.Length; i++)
            {
                Console.Write(Res[i] + " ");
            }
            //int k = 5;
            //Console.WriteLine($"For k = {k} , Number Of Swaps required is : {Obj.ReturnSwapsForGroup(input, k)}");
            //Obj.SequenceSortedArrayThree(input);
            //Console.WriteLine(Obj.SubArrayLength(input));
            //Obj.MaxProdSubArray(input);

            Console.ReadLine();



        }
    }
}
