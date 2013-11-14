using System.Collections.Generic;

namespace ChartTests.Charting
{
    public class ChartParameters
    {
        public IEnumerable<KeyValuePair<int, int>> SeriaData = new List<KeyValuePair<int, int>>();
        public int ChartWidth { get; set; }
        public int ChartHeight { get; set; }
    }
}