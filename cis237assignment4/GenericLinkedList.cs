// Daniel Richards
// CIS 237
// 11/1/2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    abstract class GenericLinkedList<T> : IGenericLinkedList<T>
    {
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        protected Node _head;
        protected Node _tail;
        protected int _size;

        public bool IsEmpty
        {
            get
            {
                return _head == null;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public GenericLinkedList()
        {
            _head = null;
            _tail = null;
            _size = 0;
        }

        public virtual T RemoveFromFront()
        {
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }

            T returnData = _head.Data;

            _head = _head.Next;

            _size--;

            if (IsEmpty)
            {
                _tail = null;
            }

            return returnData;
        }
    }
}
