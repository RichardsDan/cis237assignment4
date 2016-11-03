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
    class GenericQueueLinkedList<T> : GenericLinkedList<T>
    {
        public GenericQueueLinkedList() : base()
        {

        }

        public void AddToBack(T genericData)
        {
            Node oldTail = _tail;

            _tail = new Node();

            _tail.Data = genericData;

            _tail.Next = null;

            if (IsEmpty)
            {
                _head = _tail;
            }
            else
            {
                oldTail.Next = _tail;
            }

            _size++;
        }
    }
}
