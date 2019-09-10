using System;
using System.IO;

namespace SimpleExamples
{
    public class StaticUsageDemo
    {
        public static void DoDemo()
        {
            Print(null); // FileNotFoundException
        }
        
        static void Print(object o)
        {
            Console.WriteLine("Object");
        }

        static void Print(Exception e)
        {
            Console.WriteLine("Exception");
        }
        
        static void Print(FileNotFoundException e)
        {
            Console.WriteLine("FileNotFoundException");
        }
    }
}