using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListSimple LL = new LinkedListSimple();

            LL.CreateLinkListLoop();
            LL.CreateLinkList();
            LL.InsertBeg(5);
            LL.InsertBeg(15);
            LL.InsertBeg(16);

            LL.InsertEnd(14);
            LL.InsertEnd(25);
            LL.InsertEnd(6);
            LL.InsertEnd(7);
            LL.InsertEnd(8);


            //LL.InsertMiddle(7, 2);
            //LL.InsertMiddle(4, 1);
            //LL.InsertMiddle(8, 6);

            LL.TraverseLinkedList();

            //LL.DeleteBeg();
            //LL.DeleteMiddle(7);
            //LL.DeleteEnd();
            //LL.TraverseLinkedList();

            // LL.MiddleElement();
            // LL.SearchNthElement(4);

            //LL.MiddleElementNew();
            //LL.CountDataLL();
            //LL.DetectLoop();
            //LL.CountNodeLoop();
            //LL.CheckPallindrome();
            //LL.Removeduplicates();
            //LL.SwapNodes(2, 8);
            //LL.SwapNodesPairWise();
            //LL.CreateSortedLists();

            LL.QuickSortLL();
            LL.TraverseLinkedList();


            Console.ReadLine();

        }
    }
}
