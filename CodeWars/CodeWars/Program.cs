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
            Console.WriteLine(factors(7775460));
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
    }
}
