using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class LinkedListNode
    {
        public bool IsHead;
        public bool IsTail;
        public object Data;
        public LinkedListNode? Next;
        public LinkedListNode? Previous;

        public LinkedListNode(object data)
        {
            Data = data;
            Next = null;
            Previous = null;
            IsHead = false;
            IsTail = false;
        }

        public void InsertFirst(LinkedListNode linkedList, object data)
        {
            LinkedListNode newNode = new LinkedListNode(data);
            newNode.Next = linkedList;
            newNode.IsHead = true;
        }
    }
}
