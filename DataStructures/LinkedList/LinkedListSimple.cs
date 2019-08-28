using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedListSimple
    {
        Node head;

        // Create Linked List
        public void CreateLinkList()
        {
            Node first = new Node(1);
            Node second = new Node(2);
            Node third = new Node(3);
            this.head = first;
            first.next = second;
            second.next = third;
            third.next = null;
        }

        // Create Linked List
        public void CreateLinkListLoop()
        {
            Node first = new Node(1);
            Node second = new Node(2);
            Node third = new Node(3);
            Node fourth = new Node(4);
            Node fifth = new Node(5);
            this.head = first;
            first.next = second;
            second.next = third;
            third.next = fourth;
            fourth.next = fifth;
            fifth.next = second;

        }

        //Traverse Linked List
        public void TraverseLinkedList()
        {
            Node node = head;

            while (node != null)
            {
                Console.Write(node.data + " ");
                node = node.next;
            }
            Console.WriteLine("");

        }

        // Insert item at the beginning
        public void InsertBeg(int data)
        {
            Node newNode = new Node(data);
            newNode.next = null;

            if (head == null)
                head = newNode;
            else
            {
                newNode.next = head;
                head = newNode;

            }

        }

        // Insert item in the middle
        public void InsertMiddle(int data, int prev)
        {
            Node node = head;

            while (node.data != prev)
            {
                node = node.next;
            }

            if (node != null)
            {
                Node newNode = new Node(data);
                newNode.next = node.next;
                node.next = newNode;
            }
        }

        // Insert Item at the end
        public void InsertEnd(int data)
        {
            Node node = head;
            Node newNode = new Node(data);

            while (node.next != null)
                node = node.next;

            node.next = newNode;
        }

        //Delete Item from the beginning
        public void DeleteBeg()
        {
            Node temp = head;
            Console.WriteLine("Item Deleted : " + temp.data);
            head = temp.next;
            temp.next = null;
        }

        //Delete Item from the middle
        public void DeleteMiddle(int data)
        {
            Node temp = head;
            Node prev = null;
            while (temp.data != data)
            {
                prev = temp;
                temp = temp.next;
            }

            prev.next = temp.next;
            Console.WriteLine("Item Deleted : " + temp.data);
        }

        //Delete element from end
        public void DeleteEnd()
        {
            Node temp = head;
            Node prev = null;
            while (temp.next != null)
            {
                prev = temp;
                temp = temp.next;
            }
            prev.next = null;
            Console.WriteLine("Item Deleted : " + temp.data);
        }

        //Print the middle of the linked list
        public void MiddleElement()
        {
            Node temp = head;
            int count = 0;
            int middOdd = 0;
            int midEven = 0;


            while (temp != null)
            {
                temp = temp.next;
                count++;
            }

            if (count % 2 != 0)
            {
                int data = 0;
                Node node = head;
                middOdd = count / 2;
                while (data != middOdd)
                {
                    data++;
                    node = node.next;
                }
                Console.WriteLine("Middle Item is : " + node.data);
            }
            else
            {
                midEven = count / 2;
                int data = 0;
                Node node = head;
                Node prev = null;

                while (data != midEven)
                {
                    prev = node;
                    node = node.next;
                    data++;
                }

                Console.WriteLine("Two Middle Elements : " + prev.data + " , " + node.data);
            }



        }

        //Find the nth element from the end
        public void SearchNthElement(int n)
        {
            Node begin = head;
            Node refer = head;

            for (int i = 0; i < n - 1; i++)
            {
                refer = refer.next;
            }

            while (refer.next != null)
            {
                begin = begin.next;
                refer = refer.next;
            }

            Console.WriteLine($"{n}th element from the end is : " + begin.data);
        }

        //Find the middle element in the linked list
        public void MiddleElementNew()
        {
            Node first = head;
            Node second = head;

            while (second.next != null && second.next.next != null)
            {
                first = first.next;
                second = second.next.next;
            }

            Console.WriteLine("Middle element is " + first.data);
        }

        //Find the number of times a particular element occurs 
        public void CountDataLL()
        {
            Node node = head;
            int count = 0;
            int value = 1;

            CountElements(head, ref count, value);
            Console.WriteLine("Count of element is : " + count);

        }

        private void CountElements(Node node, ref int count, int value)
        {
            if (node == null)
                return;

            if (node.data == value)
                count++;

            CountElements(node.next, ref count, value);
        }

        //Detect a loop in Linked list
        public void DetectLoop()
        {
            Node start = head;
            Console.WriteLine("Loop Detected " + DetectLoop_Map(start));
            Console.WriteLine("Loop Detected " + DetectLoop_Floyd(start));
            Console.WriteLine("Loop Detected " + DetectLoop_TempNode(start));
        }
        private bool DetectLoop_Map(Node node)
        {
            bool flag = false;
            HashSet<Node> set = new HashSet<Node>();

            while (node.next != null)
            {

                if (set.Contains(node))
                {
                    flag = true;
                    return flag;
                }

                set.Add(node);
                node = node.next;
            }

            return flag;


        }

        private bool DetectLoop_Floyd(Node node)
        {
            Node first = node;
            Node second = node;

            while (second.next != null && second.next.next != null)
            {
                second = second.next.next;
                first = first.next;

                if (first == second)
                    return true;
            }
            return false;
        }

        private bool DetectLoop_TempNode(Node node)
        {
            Node temp = new Node(0);
            while (node != null)
            {
                if (node.next == temp)
                    return true;

                Node n = node.next;
                node.next = temp;
                node = n;
            }
            return false;
        }

        //Count nodes in the loop
        public void CountNodeLoop()
        {
            Node temp = head;
            CountNodesLoop(temp);
        }

        private void CountNodesLoop(Node node)
        {
            List<Node> set = new List<Node>();
            while (node != null)
            {
                if (set.Contains(node))
                {
                    int count = set.Count;
                    int i = set.IndexOf(node);
                    int loopLen = count - i;
                    Console.WriteLine("Loop Length : " + loopLen);
                    return;
                }
                else
                {
                    set.Add(node);
                }
                node = node.next;
            }

        }

        //Check if the linked List is Pallindrome
        public void CheckPallindrome()
        {
            Node start = head;
            Node temp = head;
            while (temp.next != null)
                temp = temp.next;

            Node end = temp;
            TestPallindrome(start, end);
        }

        private void TestPallindrome(Node start, Node end)
        {
            if (start.data == end.data)
            {
                if (start == end || start == null)
                {
                    Console.WriteLine("Pallindrome");
                    return;
                }
                start = start.next;
                Node temp = start;
                Node tempEnd = start;
                while (temp != end)
                {
                    tempEnd = temp;
                    temp = temp.next;
                }

                TestPallindrome(start, tempEnd);
            }
            else
            {
                Console.WriteLine("Not Pallindrome");
                return;
            }
        }

        //Remove Duplicates frm a sorted Linked List
        public void Removeduplicates()
        {
            Node temp = head;
            Node node = head;

            while (temp != null)
            {
                int data = temp.data;
                node = temp.next;

                while (node != null && node.data == data
 )
                    node = node.next;

                temp.next = node;
                temp = temp.next;

            }
        }

        //Swap Nodes without swapping data
        public void SwapNodes(int x, int y)
        {
            Node temp = head;
            Node prev = head;
            Node xPrev = head;
            Node yPrev = head;
            Node xNode = null;
            Node yNode = null;

            while (temp != null)
            {
                if (temp.data == x)
                {
                    if (temp == head)
                    {
                        xPrev = null;
                        xNode = head;
                    }
                    else
                    {
                        xPrev = prev;
                        xNode = temp;
                    }
                }

                if (temp.data == y)
                {
                    if (temp == head)
                    {
                        yPrev = null;
                        yNode = head;
                    }
                    else
                    {
                        yPrev = prev;
                        yNode = temp;

                    }
                }

                prev = temp;
                temp = temp.next;


            }

            if (xPrev == null)
            {
                Node nodeX = xNode.next;
                Node nodeY = yNode.next;
                head = yNode;
                yNode.next = nodeX;
                yPrev.next = xNode;
                xNode.next = nodeY;

            }
            else if (yPrev == null)
            {
                Node nodeX = xNode.next;
                Node nodeY = yNode.next;
                head = xNode;
                xNode.next = nodeY;
                xPrev.next = yNode;
                yNode.next = nodeX;
            }
            else
            {
                Node nodeX = xNode.next;
                Node nodeY = yNode.next;
                yPrev.next = xNode;
                xPrev.next = yNode;
                xNode.next = nodeY;

                yNode.next = nodeX;
            }




        }

        //Swap elements of a given Linked List pair wise
        public void SwapNodesPairWise()
        {
            Node temp = head;
            while (temp.next != null && temp.next.next != null)
            {
                Node node = temp.next;
                int tempdata = node.data;
                node.data = temp.data;
                temp.data = tempdata;
                temp = temp.next.next;
            }
        }

        //Intersection of two sorted linked list
        private void IntersectSortedList(Node start1, Node Start2)
        {
            LinkedListSimple objRes = new LinkedListSimple();

            while (start1 != null && Start2 != null)
            {
                if (start1 != null && Start2 != null && start1.data < Start2.data)
                {
                    start1 = start1.next;
                }

                if (start1 != null && Start2 != null && start1.data > Start2.data)
                {
                    Start2 = Start2.next;
                }

                if (start1 != null && Start2 != null && start1.data == Start2.data)
                {
                    Node n = new Node(start1.data);
                    if (objRes.head == null)
                    {
                        objRes.head = n;
                    }
                    else
                    {
                        Node temp = objRes.head;
                        while (temp.next != null)
                            temp = temp.next;

                        temp.next = n;
                    }

                    start1 = start1.next;
                    Start2 = Start2.next;

                }
            }

            objRes.TraverseLinkedList();
        }

        public void CreateSortedLists()
        {
            Node first = new Node(3);
            Node second = new Node(6);
            Node third = new Node(9);
            Node fourth = new Node(12);
            Node fifth = new Node(15);
            Node sixth = new Node(18);

            first.next = second;
            second.next = third;
            third.next = fourth;
            fourth.next = fifth;
            fifth.next = sixth;

            LinkedListSimple objFirst = new LinkedListSimple { head = first };
            objFirst.TraverseLinkedList();

            Node firstS = new Node(12);
            Node secondS = new Node(15);
            Node thirdS = new Node(18);


            firstS.next = secondS;
            secondS.next = thirdS;

            LinkedListSimple objSecond = new LinkedListSimple { head = firstS };
            objSecond.TraverseLinkedList();
            //IntersectSortedList(objFirst.head, objSecond.head);
            GetIntersectPoint(objFirst.head, objSecond.head);
        }

        /*  
       Create two linked lists  

       1st 3->6->9->15->30  
       2nd 10->15->30  

       15 is the intersection point  
       */

        //Hashing can be used or length of two lists can be found 
        public void GetIntersectPoint(Node start1, Node start2)
        {
            Node temp = start1;
            int count1 = 0;
            int count2 = 0;

            while (temp != null)
            {
                count1++;
                temp = temp.next;
            }

            temp = start2;

            while (temp != null)
            {
                count2++;
                temp = temp.next;
            }

            int resCount = count1 - count2;

            Node temp1 = start1;
            Node temp2 = start2;

            if (resCount > 0)
            {
                while (resCount != 0)
                {
                    temp1 = temp1.next;
                    resCount--;
                }
            }

            if (resCount < 0)
            {
                while (resCount != 0)
                {
                    temp2 = temp2.next;
                    resCount++;
                }
            }

            while (temp1.data != temp2.data)
            {
                temp1 = temp1.next;
                temp2 = temp2.next;
            }

            Console.WriteLine("Intersection point : " + temp1.data);





        }

        //Quick sort a linked List
        public void QuickSortLL()
        {
            Node tem = head;
            while (tem.next != null)
                tem = tem.next;

            QuickSort(head, tem);


        }
        private void QuickSort(Node start, Node end)
        {
            Node tempPrev = null;
            Node temp = start;
            Node currPrev = null;
            Node curr = start;

            Node pivot = end;

            if(start == end)
            {
                return;
            }

            while(temp != pivot)
            {
                if (temp.data < pivot.data)
                {
                    if (tempPrev != null)
                    {
                        if (currPrev == null)
                        {
                            Node n = temp.next;
                            Node n1 = curr.next;
                            tempPrev.next = curr;
                            curr.next = n;
                            temp.next = n1;
                            head = temp;
                        }
                        else
                        {
                            Node n = temp.next;
                            Node n1 = curr.next;
                            tempPrev.next = curr;
                            curr.next = n;
                            currPrev.next = temp;
                            temp.next = n1;
                        }
                    }

                    TraverseLinkedList();
                    currPrev = currPrev == null ? head : currPrev.next;
                    tempPrev = tempPrev == null ? head : tempPrev.next;
                    curr = currPrev.next;
                    temp = tempPrev.next;
                    
                }
                else
                {

                    tempPrev = temp;
                    temp = temp.next;
                }
            }

            
            if (currPrev == null)
            {
                Node n = pivot.next;
                Node n1 = curr.next;
                temp.next = curr;
                curr.next = n;
                pivot.next = n1;
                head = pivot;
            }
            else
            {
                Node n = pivot.next;
                Node n1 = curr.next;
                temp.next = curr;
                curr.next = n;
                currPrev.next = pivot;
                pivot.next = n1;
            }
            TraverseLinkedList();
            QuickSort(start, currPrev);
            QuickSort(pivot.next, end);


        }

        public class Node
        {
            public int data;
            public Node next;

            public Node(int data)
            {
                this.data = data;
                this.next = null;
            }

        }
    }
}
