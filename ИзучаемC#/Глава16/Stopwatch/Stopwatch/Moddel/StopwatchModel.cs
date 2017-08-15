using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.Moddel
{
    class StopwatchModel
    {
        private DateTime? _started;
        private TimeSpan? _previousElapsedTime;

        public bool Running
        {
            get
            {
                return _started.HasValue;
            }
        }

        public TimeSpan? LapTime { get; private set; }

        public TimeSpan? Elapsed
        {
            get
            {
                if (_started.HasValue)
                {
                    if (_previousElapsedTime.HasValue)
                        return CalculateTimeElapsedSinceStarted() + _previousElapsedTime;
                    else
                        return CalculateTimeElapsedSinceStarted();
                }
                else
                    return _previousElapsedTime;
            }
        }

        private TimeSpan CalculateTimeElapsedSinceStarted()
        {
            return DateTime.Now - _started.Value;
        }

        public void Start()
        {
            _started = DateTime.Now;
            if (!_previousElapsedTime.HasValue)
                _previousElapsedTime = new TimeSpan(0);
        }

        public void Stop()
        {
            if (_started.HasValue)
                _previousElapsedTime += DateTime.Now - _started.Value;
            _started = null;
        }

        public StopwatchModel()
        {
            Reset();
        }

        public void Reset()
        {
            _previousElapsedTime = null;
            _started = null;
            LapTime = null;
            OnLapTimeUpdated(LapTime);
        }

        public void Lap()
        {
            LapTime = Elapsed;
            OnLapTimeUpdated(LapTime);
        }

        public event EventHandler<LapEventArgs> LapTimeUpdated;

        private void OnLapTimeUpdated(TimeSpan? lapTime)
        {
            EventHandler<LapEventArgs> lapTimeUpdated = LapTimeUpdated;

            if (lapTimeUpdated != null)
                lapTimeUpdated(this, new LapEventArgs(lapTime));
        }
    }
}
