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
    *Выбрать из массива элемент, называемый опорным. Это может быть любой из элементов массива. 
    От выбора опорного элемента не зависит корректность алгоритма, но в отдельных случаях может сильно зависеть его эффективность.
    *Сравнить все остальные элементы с опорным и переставить их в массиве так, чтобы разбить массив на три непрерывных отрезка, 
    следующие друг за другом: «меньшие опорного», «равные» и «большие».
    *Для отрезков «меньших» и «больших» значений выполнить рекурсивно ту же последовательность операций, если длина отрезка больше единицы.
    *Лучший случай: O(nlog{2}n) Среднее: O(nlogn) The worst: O(n^2)
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
    Сортировка подсчётом(Черпачная) (англ. Counting sort) — алгоритм сортировки, в котором используется диапазон чисел сортируемого массива 
    для подсчёта совпадающих элементов. Применение сортировки подсчётом целесообразно лишь тогда, когда сортируемые числа имеют (или их можно отобразить в)
     диапазон возможных значений, который достаточно мал по сравнению с сортируемым множеством, например, миллион натуральных чисел меньших 1000.
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