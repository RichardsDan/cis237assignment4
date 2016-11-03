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
    interface IGenericLinkedList<T>
    {
        T RemoveFromFront();

        bool IsEmpty { get; }

        int Size { get; }
    }
}
