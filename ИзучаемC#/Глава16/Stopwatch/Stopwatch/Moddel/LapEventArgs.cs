using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.Moddel
{
    class LapEventArgs : EventArgs
    {
        public TimeSpan? LapTime { get; private set; }

        public LapEventArgs(TimeSpan? lapTime)
        {
            LapTime = lapTime;
        }
    }
}
