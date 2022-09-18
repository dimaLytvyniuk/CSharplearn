using System;

namespace Algorithms.List
{
    public class ListNode 
    { 
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public void PrintList()
        {
            var head = this;
            while (head != null)
            {
                Console.Write($"{head.val}, ");
                head = head.next;
            }
            Console.WriteLine();
        }
    }
}
