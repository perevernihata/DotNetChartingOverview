using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using GoogleChartSharp;

namespace ChartTests.Charting.GoogleSharpCharting
{
    public class GoogleSharpAdapter: BaseChartAdapter
    {
        public GoogleSharpAdapter(ChartParameters parameters) : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            var chart = new LineChart(400, 300);
            chart.SetData(Parameters.SeriaData.Select(t => t.Value).ToArray());
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(chart.GetUrl());            
            return new Bitmap(new MemoryStream(imageBytes));
        }
    }
}