using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExtensions
{
    public static class HumanExtensions
    {
        public static bool IsDistressCall(this string s)
        {
            if (s.Contains("help me"))
                return true;
            else
                return false;
        }
    }
}
