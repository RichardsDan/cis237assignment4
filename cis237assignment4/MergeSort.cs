// Daniel Richards
// CIS 237
// 11/3/2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    public class MergeSort
    {
        private MergeSort()
        {

        }

        // Stably merge a[low .. mid] with a[mid+1 ..high] using aux[low .. high]
        private static void Merge(IComparable[] a, IComparable[] aux, int low, int mid, int high)
        {
            // Copy to aux[]
            for (int k = low; k <= high; k++)
            {
                aux[k] = a[k];
            }

            // Merge back to a[]
            int i = low, j = mid + 1;

            // Compares each sorted half of the array and combines them together into one sorted array
            for (int k = low; k <= high; k++)
            {
                    if (i > mid)
                        a[k] = aux[j++];
                    else if (j > high)
                        a[k] = aux[i++];
                    else if (aux[j].CompareTo(aux[i]) < 0)
                        a[k] = aux[j++];
                    else
                        a[k] = aux[i++];
            }
        }

        /// <summary>
        /// Rearranges the array in ascending order
        /// </summary>
        /// <param name="a">The array to be sorted</param>
        public static void StartSort(IComparable[] a, int length)
        {
            IComparable[] aux = new IComparable[length];
            Sort(a, aux, 0, (length - 1));
        }

        // MergeSort a[low..high] using auxiliary array aux[low..high]
        private static void Sort(IComparable[] a, IComparable[] aux, int low, int high)
        {
            // Base case
            if (high <= low)
                return;

            // Splits current piece of array into two halves then calls recursive Sort method on each half, then merges them together
            int mid = low + (high - low) / 2;
            Sort(a, aux, low, mid);
            Sort(a, aux, mid + 1, high);
            Merge(a, aux, low, mid, high);
        }
    }
}
