using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using ChartingCore;
using GoogleChartSharp;

namespace FreeChartTools.FreeCharting.GoogleSharpCharting
{
    /// <summary>
    /// Apache License 2.0
    /// Official link - https://code.google.com/p/googlechartsharp/
    /// </summary>
    public class GoogleSharpAdapter : BaseChartAdapter
    {
        public GoogleSharpAdapter(ChartParameters parameters)
            : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            var chart = new LineChart(Parameters.ChartWidth, Parameters.ChartHeight);
            chart.SetData(Parameters.SeriaData.Select(t => new float[]{t.Key, t.Value}).ToList());
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(chart.GetUrl());
            return new Bitmap(new MemoryStream(imageBytes));
        }
    }
}