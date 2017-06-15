using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Polinom : IComparable
    {
        uint n;
        int[] koef;

        public Polinom()
        {
            n = 0;
            koef = new int[1];
        }

        public Polinom(uint n)
        {
            this.n = n;
            koef = new int[n + 1];
        }

        public uint N
        {
            get { return n; }
        }

        public int this[int index]
        {
            get
            {
                return koef[index];
            }

            set
            {
                koef[index] = value;
            }
        }

        public static Polinom operator +(Polinom p1, Polinom p2)
        {
            uint len = p1.N > p2.N ? p2.N : p1.N;

            Polinom p = new Polinom(len);

            for (int i = 0; i <= len; i++)
                p[i] = p1[i] + p2[i];

            return p;
        }

        public static bool operator <(Polinom p1, Polinom p2)
        {
            if (p1.CompareTo(p2) == -1)
                return true;
            else
                return false;
        }

        public static bool operator >(Polinom p1, Polinom p2)
        {
            uint len1 = p1.N;
            uint len2 = p2.N;

            if (len1 > len2)
                return true;
            else if (len1 < len2)
                return false;

            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i <= len1; i++)
            {
                sum1 += p1[i];
                sum2 += p2[i];
            }

            return sum1 > sum2;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Polinom p = (Polinom)obj;

                if (this.N != p.N)
                    return false;

                for (int i = 0; i <= this.N; i++)
                {
                    if (this[i] != p[i])
                        return false;
                }

                return true;
            }
        }

        public static bool operator ==(Polinom p1, Polinom p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Polinom p1, Polinom p2)
        {
            return !p1.Equals(p2);
        }

        public override string ToString()
        {
            string result = "";

            for (int i = (int)this.N; i > 0; i--)
            {
                result += koef[i] + "x" + i;
                if (koef[i - 1] >= 0)
                    result += "+";
            }

            result += koef[0];

            return result;
        }

        public int CompareTo(object obj)
        {
            Polinom p = (Polinom)obj;

            if (this.N > p.N)
                return 1;
            else if (this.N < p.N)
                return -1;

            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i <= p.N; i++)
            {
                sum2 += p[i];
                sum1 += this[i];
            }

            if (sum1 == sum2)
                return 0;
            else if (sum1 > sum2)
                return 1;
            else
                return -1;
        }
    }
}
