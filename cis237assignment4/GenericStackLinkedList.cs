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
    class GenericStackLinkedList<T> : GenericLinkedList<T>
    {
        //public GenericStackLinkedList() : base()
        //{

        //}

        public void AddToFront(T GenericData)
        {
            Node oldHead = _head;

            _head = new Node();

            _head.Data = GenericData;

            _head.Next = oldHead;

            _size++;

            if (_size == 1)
            {
                _tail = _head;
            }
        }
    }
}
