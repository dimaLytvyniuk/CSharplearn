using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Dynamic : ICloneable
    {
        uint n;
        int[] mass;

        public Dynamic()
        {
            n = 0;
            mass = new int[1];
        }

        public Dynamic(uint n)
        {
            this.n = n;
            mass = new int[n + 1];
        }

        public uint N
        {
            get { return n; }
        }

        public int this[int index]
        {
            get
            {
                return mass[index];
            }

            set
            {
                mass[index] = value;
            }
        }

        public void ChangeSize(uint newN)
        {
            int[] newMass = new int[newN];

            for (int i = 0; i < newN; i++)
                newMass[i] = mass[i];

            mass = newMass; 
        }

        public object Clone()
        {
            Dynamic d = new Dynamic(this.N);

            for (int i = 0; i < this.N; i++)
                d[i] = this[i];

            return d; 
        }

        public static Dynamic operator *(Dynamic d1, Dynamic d2)
        {
            uint len = d1.N > d2.N ? d2.N : d1.N;

            Dynamic d = new Dynamic(len);

            for (int i = 0; i < len; i++)
                d[i] = d1[i] * d2[i];


            return d;
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
                Dynamic d = (Dynamic)obj;

                if (this.N != d.N)
                    return false;

                for (int i = 0; i <= this.N; i++)
                {
                    if (this[i] != d[i])
                        return false;
                }

                return true;
            }
        }

        public static bool operator ==(Dynamic d1, Dynamic d2)
        {
            return d1.Equals(d2);
        }

        public static bool operator !=(Dynamic d1, Dynamic d2)
        {
            return !d1.Equals(d2);
        }

        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < this.N; i++)
                str += this[i] + " ";

            return str;
        }
    }
}
