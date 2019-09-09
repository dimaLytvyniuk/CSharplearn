using System;

namespace SimpleExamples
{
    public class TestTasks
    {
        public static void DoDemo()
        {
            NullCheck();
        }

        public static void NullCheck()
        {
            string value = null;
            string result;
            result = "The value is " + value ?? "null" + "!";
            Console.WriteLine(result);
        }
    }
}
