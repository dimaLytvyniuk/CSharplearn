using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Polinom polinom = new Polinom(3);

            polinom[0] = -3;
            polinom[1] = 4;
            polinom[2] = -4;
            polinom[3] = 5;

            Polinom polinom1 = new Polinom(3);

            polinom1[0] = -3;
            polinom1[1] = 4;
            polinom1[2] = -4;
            polinom1[3] = 5;

            Console.WriteLine(polinom);
            Console.WriteLine(polinom > polinom1);
            Console.WriteLine(polinom + polinom1);
            Console.WriteLine(polinom != polinom1);
        }
    }
}
