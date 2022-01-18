using SimpleStopwatch.Interface;
using System.Diagnostics;

namespace SimpleStopwatch
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopWatch;

        private List<string> laps;

        public Chronometer()
        {
            this.stopWatch = new Stopwatch();
            this.laps = new List<string>();
        }

        public string GetTime => this.stopWatch.Elapsed.ToString(@"mm\:ss\.ffff");

        public IReadOnlyList<string> Laps => this.laps.AsReadOnly();

        public string Lap()
        {
            string result = GetTime;
            this.laps.Add(result);
            return result;
        }

        public void Reset()
        {
            this.stopWatch.Reset();
            this.laps.Clear();
        }

        public void Start()
        {
            this.stopWatch.Start();
        }

        public void Stop()
        {
            this.stopWatch?.Stop();
        }
    }
}
