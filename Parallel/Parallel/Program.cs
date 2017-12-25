using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Parallel
{
    class Program
    {
        static Mutex mutexObj = new Mutex();

        static void Main(string[] args)
        {
            DisplayResultAsync();
            Console.ReadLine();
        }

        static async void DisplayResultAsync()
        {
            int num1 = 5;
            int num2 = 6;
            Task<int> t1 = FactorialAsync(num1);
            Task<int> t2 = FactorialAsync(num2);
            Task<int> t3 = Task.Run(() =>
            {
                int res = 1;
                for (int i = 1; i <= 9; i++)
                {
                    res += i * i;
                }
                return res;
            });

            await Task.WhenAll(new[] { t1, t2, t3 });

            Console.WriteLine("Факториал числа {0} равен {1}", num1, t1.Result);
            Console.WriteLine("Факториал числа {0} равен {1}", num2, t2.Result);
            Console.WriteLine("Сумма квадратов чисел равна {0}", t3.Result);
        }

        static Task<int> FactorialAsync(int x)
        {
            int result = 1;

            Console.WriteLine("Start factorial");
            return Task.Run(() =>
            {
                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                }
                Console.WriteLine("End factorial");
                return result;
            });
        }

        static void Display()
        {
            Console.WriteLine("Начало работы метода Display");

            Console.WriteLine("Завершение работы метода Display");
        }

        public static void Count(object x)
        {
            for (int i = 1; i < 90; i++)
            {
                int n = (int)x;

                mutexObj.WaitOne();
                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * n);
                mutexObj.ReleaseMutex();
            }
        }

        public static void TestParallelQuickSort()
        {
            int n = 100_000;
            int[] a = new int[n];
            int[] b = new int[n];
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                a[i] = random.Next(100000);
                b[i] = a[i];
            }

            Console.WriteLine();

            Stopwatch mergeWatch2 = new Stopwatch();
            mergeWatch2.Start();
            QuickSortParallel(b, 0, n - 1);
            mergeWatch2.Stop();
            TimeSpan ts2 = mergeWatch2.Elapsed;

            Stopwatch mergeWatch = new Stopwatch();
            mergeWatch.Start();
            QuickSort(a, 0, n - 1);
            mergeWatch.Stop();
            TimeSpan ts1 = mergeWatch.Elapsed;

            Console.WriteLine(String.Format("{0:00}", ts1.Seconds) + "секунд " + String.Format("{0:00}", ts1.Milliseconds) + " мідісекунд");
            Console.WriteLine(String.Format("{0:00}", ts2.Seconds) + "секунд " + String.Format("{0:00}", ts2.Milliseconds) + " мідісекунд");

            for (int i = 0; i < n - 1; i++)
            {
                if (a[i] > a[i + 1])
                    Console.WriteLine("Incorrect A");
                if (b[i] > b[i + 1])
                    Console.WriteLine("Incorrect B");
            }
        }

        public static void swap<T>(T[] a, int i, int j)
        {
            T prom = a[i];
            a[i] = a[j];
            a[j] = prom;
        }

        public static void QuickSort<T>(T[] a, int low, int high) where T : IComparable
        {
            if (high > low)
            {
                int pivot = Partition(a, low, high);
                QuickSort(a, low, pivot - 1);
                QuickSort(a, pivot + 1, high);
            }
        }

        public static void QuickSortParallel<T>(T[] a, int low, int high) where T : IComparable
        {
            if (high > low)
            {
                int pivot = Partition(a, low, high);

                if (high - low < 100)
                {
                    QuickSortParallel(a, low, pivot - 1);
                    QuickSortParallel(a, pivot + 1, high);
                }
                else
                {
                    System.Threading.Tasks.Parallel.Invoke(
                        () => QuickSortParallel(a, low, pivot - 1),
                        () => QuickSortParallel(a, pivot + 1, high));
                }
            }
        }

        private static int Partition<T>(T[] a, int low, int high) where T : IComparable
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
    }

    class Reader
    {
        // создаем семафор
        static Semaphore sem = new Semaphore(3, 3);
        Thread myThread;
        int count = 3;// счетчик чтения

        public Reader(int i)
        {
            myThread = new Thread(Read);
            myThread.Name = "Читатель " + i.ToString();
            myThread.Start();
        }

        public void Read()
        {
            while (count > 0)
            {
                sem.WaitOne();

                Console.WriteLine("{0} входит в библиотеку", Thread.CurrentThread.Name);

                Console.WriteLine("{0} читает", Thread.CurrentThread.Name);

                Console.WriteLine("{0} покидает библиотеку", Thread.CurrentThread.Name);

                sem.Release();

                count--;
            }
        }
    }
}
