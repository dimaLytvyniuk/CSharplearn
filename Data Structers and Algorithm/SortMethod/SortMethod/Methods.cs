using System;

namespace SortMethod
{
/// <summary>Contains Sorting Methods</summary>
    public class Methods
    {
/// <summary>
/// swap - перестановка элементов 
/// </summary>
/// <param name="a">массив</param>
/// <param name="i">индекс первого элемента</param>
/// <param name="j">индекс второго элемета</param>
        private static void swap<T>(T[] a, int i, int j)
        {
            T prom = a[i];
            a[i] = a[j];
            a[j] = prom;
        }

/// <summary>Быстрая сотрировка</summary>
/// <remarks>
/// Выбрать из массива элемент, называемый опорным. Это может быть любой из элементов массива. 
/// От выбора опорного элемента не зависит корректность алгоритма, но в отдельных случаях может сильно зависеть его эффективность.
/// Сравнить все остальные элементы с опорным и переставить их в массиве так, чтобы разбить массив на три непрерывных отрезка, 
/// следующие друг за другом: «меньшие опорного», «равные» и «большие».
/// Для отрезков «меньших» и «больших» значений выполнить рекурсивно ту же последовательность операций, если длина отрезка больше единицы.
/// Лучший случай: O(nlog{2}n) Среднее: O(nlogn) The worst: O(n^2)
 /// </remarks>
/// <param name="a">Сортируемый массив</param>
/// <param name="low">Индекс начала отрезка</param>
/// <param name="high">Индекс конца отрезка</param>
        public static void QuickSort<T> (T[] a, int low, int high) where T: IComparable
        {
            if (high > low)
            {
                int pivot = Partition(a, low, high);
                QuickSort(a, low, pivot - 1);
                QuickSort(a, pivot + 1, high);
            }
        }

/// <summary>Используется для быстрой сортировки</summary>
/// <returns>позицию опорного елемента</returns>
/// <param name="a">Сортируемый массив</param>
/// <param name="low">Индекс начала отрезка</param>
/// <param name="high">Индекс конца отрезка</param>
        private static int Partition<T>(T[] a, int low, int high) where T: IComparable
        {
            int pivot_index = ((high - low) / 2) + low;
            int wall = low;
            T pivot = a[pivot_index];
            swap(a, pivot_index, high);

            for (int i = low; i < high; i++)
            {
                //if (a[i] <= pivot)
                if (pivot.CompareTo(a[i]) > 0)
                {
                    swap(a, wall, i);
                    wall++;
                }
            }

            swap(a, wall, high);
            return wall;
        }

/// <summary>Сотртировка подсчетом</summary>
/// <remarks>
/// Сортировка подсчётом(Черпачная) (англ. Counting sort) — алгоритм сортировки, в котором используется диапазон чисел сортируемого массива 
/// для подсчёта совпадающих элементов. Применение сортировки подсчётом целесообразно лишь тогда, когда сортируемые числа имеют (или их можно отобразить в)
/// диапазон возможных значений, который достаточно мал по сравнению с сортируемым множеством, например, миллион натуральных чисел меньших 1000.
/// </remarks>
/// <param name = "a">Сотрируемый массив.</param>
/// <param name = "k">Максимально допустимое число.</param>
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

/// <summary>Сортировка расческой</summary>
/// <remarks>
/// В «пузырьке», «шейкере» и «чёт-нечете» при переборе массива сравниваются соседние элементы. Основная идея «расчёски» в том, чтобы 
/// первоначально брать достаточно большое расстояние между сравниваемыми элементами и по мере упорядочивания массива сужать это расстояние вплоть до минимального. 
/// Таким образом, мы как бы причёсываем массив, постепенно разглаживая на всё более аккуратные пряди. Первоначальный разрыв между 
/// сравниваемыми элементами лучше брать с учётом специальной величины, называемой фактором уменьшения, оптимальное значение которой равно примерно 1,247. 
/// Сначала расстояние между элементами равно размеру массива, разделённого на фактор уменьшения (результат округляется до ближайшего целого). 
/// Затем, пройдя массив с этим шагом, необходимо поделить шаг на фактор уменьшения и пройти по списку вновь. 
/// Так продолжается до тех пор, пока разность индексов не достигнет единицы. В этом случае массив досортировывается обычным пузырьком.
/// Оптимальное значение фактора уменьшения 1,247... можно представить формулой в следующем виде ≈ ( 1 / ( 1-е^(-φ) ) ), где е - экспонента; φ - "золотое" число.
/// </remarks>
/// <param name="a">Сортируемый массив.</param>
        public static void CombSort<T> (T[] a) where T: IComparable
        {
            int gap = a.Length;
            bool swapped = true;
            double fact = 1.247330950103979;
            while (gap > 1 || swapped)
            {
                if (gap > 1)
                    gap = (int)(gap /  fact);
                
                int i = 0;
                swapped = false;
                while (i + gap < a.Length)
                {
                    if (a[i].CompareTo(a[i + gap]) > 0)
                    {
                        T temp = a[i];
                        a[i] = a[i + gap];
                        a[i + gap] = temp;
                        swapped = true;
                    }
                    i++;
                }
            }
        }
    }
}