namespace Algorithms.List
{
    public class AddTwoNumbersProblem
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var sum = 0;
            ListNode dummyHead = new ListNode(0);
            ListNode tail = dummyHead;
            
            while (l1 != null || l2 != null || sum != 0)
            {
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                var newNode = new ListNode(sum % 10);
                sum = sum / 10;

                tail.next = newNode;
                tail = newNode;
            }

            return dummyHead.next;
        }
        
        public static int CalculateList(ListNode list) 
        {
            var tenPow = 1;
            var sum = 0;
        
            while(list != null) 
            {
                if (list.val != 0)
                {
                    sum += list.val * tenPow;
                }
            
                tenPow *= 10;
                list = list.next;
            }
        
            return sum;
        }
    
        public static ListNode CreateList(int number)
        {
            var listNode = new ListNode(number % 10);
            ListNode tail = listNode;
            number = number / 10;
        
            while(number != 0)
            {
                var newNode = new ListNode(number % 10);
                tail.next = newNode;
                tail = newNode;
            
                number = number / 10;
            }
        
            return listNode;
        }

        public static void MakeExample()
        {
            var first = CreateList(343);

        }
    }
}
