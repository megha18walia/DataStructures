using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Rotation
{
    public class TestRotation
    {
        public int ReturnRotation(int[] Arr)
        {
            int pivot = -1;
            ReturnPivot(Arr, ref pivot, 0, Arr.Length - 1);
            return Arr.Length - pivot;
        }

        private void ReturnPivot(int[] Arr, ref int pivot, int start, int end)
        {
            if(end - start > 1)
            {
                int mid = (start + end) / 2;
                if(Arr[mid] > Arr[mid+1])
                {
                    pivot = mid + 1;
                }
                else if(Arr[mid-1] > Arr[mid])
                {
                    pivot = mid;
                }
                else
                {
                    ReturnPivot(Arr, ref pivot, 0, mid);
                    ReturnPivot(Arr, ref pivot, mid + 1, end);
                }
            }
            else
            {
                return;
            }
        }
    }
}
