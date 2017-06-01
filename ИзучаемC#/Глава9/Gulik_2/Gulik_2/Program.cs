using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Gulik_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder=@"F:\C\DIMA\C#\ИзучаемC#\Глава9\Gulik_2";
            StreamReader reader = new StreamReader(folder + @"\secret_plan.txt");
            StreamWriter writer = new StreamWriter(folder + @"\emailToCaptainAmazing.txt");

            writer.WriteLine("To: CaptainAmazing@objectiville.net");
            writer.WriteLine("From: Commissioner@objectiville.net");
            writer.WriteLine("Subject: Can you save the day ... again?");
            writer.WriteLine();
            writer.WriteLine("We've discovered the Swindler's plan: ");
            while(!reader.EndOfStream)
            {
                string lineFromThePlan = reader.ReadLine();

                writer.WriteLine("The plan ->" + lineFromThePlan);
            }
            writer.WriteLine();
            writer.WriteLine("Can you help us?");
            writer.Close();
            reader.Close();
        }
    }
}
