using System;

namespace SimpleExamples
{
    public static class DynamicExamples
    {
        public static void DoDemo()
        {
            /**
            dynamic smth = 124;
            string newVal = smth;// Will be exception
            **/

            dynamic smth = 123;
            long newVal = smth;// Works
            
            Console.WriteLine(newVal);

            smth = "string";// Works
            string strVal = smth;
            Console.WriteLine(strVal);
        }
    }
}
