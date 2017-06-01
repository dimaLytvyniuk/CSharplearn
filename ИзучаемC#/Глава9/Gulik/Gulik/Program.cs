using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Gulik
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(@"F:\C\DIMA\C#\ИзучаемC#\Глава9\Gulik\secret_plan.txt");
            sw.WriteLine("How I'll defeat Captain Amazing");
            sw.WriteLine("Another genius secret plan by the Swindler");
            sw.Write("I'll create an army of clones and ");
            sw.WriteLine("unleash them upon the citizens of Objectiville.");

            string location = "the mall";

            for(int i=0;i<=6;i++)
            {
                sw.WriteLine("Clone #{0} attacks {1}", i, location);

                if (location == "the mall")
                    location = "downtown";
                else
                    location = "the mall";
            }

            sw.Close();
        }
    }
}
