using System;

namespace SimpleExamples
{
    public static class TupleExamples
    {
        public static void DoDemo()
        {
            var tuple = ("fist", 14);
            Console.WriteLine(tuple.Item1);

            var tuple2 = (first: "first", second: 2);
            Console.WriteLine(tuple2.first);
            Console.WriteLine(tuple2.second);
            
        }
    }
}