using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPE1700ICAs8
{
    class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            Node List = null;
            for (int i = 0; i < 10; i++)
            {
                LinkedList.Append(ref List, generator.Next(0, 10));
            }
            Console.WriteLine("linked list before sorting\n");
            RecursiveP(List);
            Console.WriteLine("\n\n linked list after sorting");
            List = insertNode(List);
            RecursiveP(List);
            Console.ReadKey();
        }

        // insertion sort method
        public static Node insertNode(Node Node)
        {
            if (Node == null)
                return null;

            // Make the first node the start of the sorted list.
            Node sortedList = Node;
            Node = Node.Next;
            sortedList.Next = null;

            while (Node != null)
            {
                // Advance the nodes.
                Node current = Node;
                Node = Node.Next;

                // Find where current belongs.
                if (current.Value < sortedList.Value)
                {
                    // Current is new sorted head.
                    current.Next = sortedList;
                    sortedList = current;
                }
                else
                {
                    // Search list for correct position of current.
                    Node search = sortedList;
                    while (search.Next != null && current.Value > search.Next.Value)
                        search = search.Next;

                    // current goes after search.
                    current.Next = search.Next;
                    search.Next = current;
                }
            }
            Node = sortedList;
            return Node;
        }
        static public void RecursiveP(Node H)
        {
            if (H == null)
            {
                Console.WriteLine();
                return;
            }

            Console.Write(H.Value + " ");

            //Head of the remainder of the list is just the next one after this one.
            RecursiveP(H.Next);

        }
        public static class LinkedList
        {
            public static void Append(ref Node H, int Value)
            {

                if (H != null)
                {
                    Node current = H;
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }

                    current.Next = new Node();
                    current.Next.Value = Value;
                }
                else
                {
                    H = new Node();
                    H.Value = Value;
                }
            }


            public static void PrintRecursive(Node H)
            {
                if (H == null)
                {
                    Console.WriteLine();
                    return;
                }

                Console.Write("{0} ", H.Value);
                PrintRecursive(H.Next);
            }

            public static void Reverse(ref Node H)
            {
                if (H == null) return;

                Node prev = null, current = H, next = null;

                while (current.Next != null)
                {
                    next = current.Next;
                    current.Next = prev;
                    prev = current;
                    current = next;
                }

                current.Next = prev;
                H = current;
            }


        }

        
    }
}
