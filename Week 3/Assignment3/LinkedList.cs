using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class LinkedList
    {
        LinkedListNode? head;
        int count = 0;

        public LinkedList()
        {
            head = null;
        }

        public LinkedListNode GetHead()
        {
            return head;
        }

        public void AddNodeToFront(object data)
        {
            LinkedListNode node = new LinkedListNode(data);
            node.Next = head;
            node.Previous = null;

            if(head != null) 
            {
                head.Previous = node;
                head.IsHead = false;
            }

            if(count == 1)
            {
                head.IsTail = true;
            }

            head = node;
            head.IsHead = true;

            count++;
        }

        public void AddNodeToEnd(object data)
        {
            LinkedListNode node = new LinkedListNode(data);
            if(head == null)
            {
                node.Previous = null;
                head = node;
                node.IsHead = true;
                return;
            }

            if(head.Next == null)
            {
                node.Previous = head;
                head.Next = node;
            }
            else
            {
                LinkedListNode tail = GetTail();
                tail.Next = node;
                tail.IsTail = false;
                node.Previous = tail;
            }
            
            node.IsTail = true;
            count++;
        }
        
        internal LinkedListNode GetTail()
        {
            LinkedListNode runner = head;
            while (runner.Next != null)
            {
                runner = runner.Next;
            }

            return runner;
        }

        public void PrintList()
        {
            LinkedListNode? runner = head;
            while (runner != null)
            {
                Console.WriteLine(runner.Data);
                runner = runner.Next;
            }
        }
    }
}
