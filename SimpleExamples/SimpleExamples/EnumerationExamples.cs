using System;

namespace SimpleExamples
{
    public class EnumerationExamples
    {
        public static void DoDemo()
        {
            var fitnessDays = Days.Friday | Days.Monday;
            Console.WriteLine(fitnessDays);// Monday, Friday
            
            fitnessDays = fitnessDays ^ Days.Friday;// has only Monday
            Console.WriteLine(fitnessDays); // Monday
            fitnessDays |= Days.Wednesday;
            Console.WriteLine(fitnessDays);
            
            Console.WriteLine(fitnessDays & Days.Monday);// Monday
        }
    }
    
    [Flags]
    enum Days
    {
        None      = 0b_0000_0000, // 0
        Sunday    = 0b_0000_0001, // 1
        Monday    = 0b_0000_0010, // 2
        Tuesday   = 0b_0000_0100, // 4
        Wednesday = 0b_0000_1000, // 8
        Thursday  = 0b_0001_0000, // 16
        Friday    = 0b_0010_0000, // 32
        Saturday  = 0b_0100_0000  // 64 
    }
}
