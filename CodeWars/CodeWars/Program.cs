using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] result = nbMonths(2000, 8000, 1000, 1.5);
            Console.WriteLine(result[0] + " " + result[1]);
        }

        public static String factors(int lst)
        {
            Dictionary<int, int> factors = new Dictionary<int, int>();
            String result = "";
            int num;

            while ((num = NextPrime(lst)) != lst)
            {
                if (factors.ContainsKey(num))
                    factors[num]++;
                else
                    factors[num] = 1;

                lst /= num;
            }

            if (factors.ContainsKey(num))
                factors[num]++;
            else
                factors[num] = 1;

            foreach (int keys in factors.Keys)
            {
                if (factors[keys] > 1)
                    result += $"({keys}**{factors[keys]})";
                else
                    result += $"({keys})";
            }

            return result;

        }

        public static int NextPrime(int number)
        {
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                    return i;
            }

            return number;
        }

        public static int[] nbMonths(int startPriceOld, int startPriceNew, int savingperMonth, double percentLossByMonth)
        {
            if (startPriceOld > startPriceNew)
                return new int[] { 0, (startPriceOld - startPriceNew) };
            if (startPriceOld == startPriceNew)
                return new int[] { 0, 0 };

            int month = 0;
            double savedMoney = 0;
            double priceOld = startPriceOld;
            double priceNew = startPriceNew;
            while ((savedMoney + priceOld) < priceNew)
            {
                month++;
                savedMoney += savingperMonth;
                priceOld -= priceOld * percentLossByMonth;
                priceNew -= priceNew * percentLossByMonth;
                percentLossByMonth += month % 2 == 0 ? 0.5 : 0;
            }

            return new int[] { month, (int)((savedMoney + priceOld) - priceNew) };
        }
    }
}
