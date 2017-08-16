using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethods
{
    class Methods
    {
        private static void swap(int[] a, int i, int j)
        {
            int prom = a[i];
            a[i] = a[j];
            a[j] = prom;
        }

        public static void QuickSort(int[] a, int low, int high)
        {
            if (high > low)
            {
                int pivot = Partition(a, low, high);
                QuickSort(a, low, pivot - 1);
                QuickSort(a, pivot + 1, high);
            }
        }

        private static int Partition(int[] a, int low, int high)
        {
            int pivot_index = ((high - low) / 2) + low;
            int wall = low;
            int pivot = a[pivot_index];
            swap(a, pivot_index, high);

            for (int i = low; i < high; i++)
            {
                if (a[i] <= pivot)
                {
                    swap(a, wall, i);
                    wall++;
                }
            }

            swap(a, wall, high);
            return wall;
        }
    }
}
