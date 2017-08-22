using System;

namespace SortMethod
{
    class Methods
    {
        private static void swap(int[] a, int i, int j)
        {
            int prom = a[i];
            a[i] = a[j];
            a[j] = prom;
        }

/*
    *������� �� ������� �������, ���������� �������. ��� ����� ���� ����� �� ��������� �������. 
    �� ������ �������� �������� �� ������� ������������ ���������, �� � ��������� ������� ����� ������ �������� ��� �������������.
    *�������� ��� ��������� �������� � ������� � ����������� �� � ������� ���, ����� ������� ������ �� ��� ����������� �������, 
    ��������� ���� �� ������: �������� ��������, ������� � ��������.
    *��� �������� ��������� � ��������� �������� ��������� ���������� �� �� ������������������ ��������, ���� ����� ������� ������ �������.
    *������ ������: O(nlog{2}n) �������: O(nlogn) The worst: O(n^2)
 */
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

/*
    ���������� ���������(���������) (����. Counting sort) � �������� ����������, � ������� ������������ �������� ����� ������������ ������� 
    ��� �������� ����������� ���������. ���������� ���������� ��������� ������������� ���� �����, ����� ����������� ����� ����� (��� �� ����� ���������� �)
     �������� ��������� ��������, ������� ���������� ��� �� ��������� � ����������� ����������, ��������, ������� ����������� ����� ������� 1000.
*/
        public static void CountingSort(int[] a, int k)
        {
            int n = a.Length;
            int[] C = new int[k + 1];
            
            for (int i = 0; i < n; i++)
                C[a[i]]++;

            for (int i = 0, l = 0; i <= k; i++)
            {
                for (int j = 0; j < C[i]; j++)
                {
                    a[l] = i;
                    l++;
                }
            }
        }
    }
}