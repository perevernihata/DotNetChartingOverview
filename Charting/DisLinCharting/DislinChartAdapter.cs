using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace FreeChartTools.Charting.DisLinCharting
{
    public class DislinChartAdapter: BaseChartAdapter
    {
        public DislinChartAdapter(ChartParameters parameters) : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            int n = Parameters.SeriaData.Count();
            var xray = new float[n];
            var yray = new float[n];

            int i = 0;
            int maxX = 0;
            int maxY = 0;
            foreach (var point in Parameters.SeriaData)
            {
                maxX = Math.Max(maxX, point.Key);
                maxY = Math.Max(maxY, point.Value);
                xray[i] = point.Key;
                yray[i] = point.Value;
                i++;
            }

            dislin.metafl("virt");
            dislin.winsiz(Parameters.ChartWidth, Parameters.ChartHeight);
            dislin.disini();

            dislin.sclmod("FULL");
            dislin.graf(0, maxX, 0, 100, 0, maxY, 0, 100);
            dislin.title();

            dislin.color("red");
            dislin.curve(xray, yray, n);

            dislin.color("fore");
            dislin.dash();
            var blob = new byte[300 * 400 * 3];
            dislin.rbfpng(blob, blob.Length);
            dislin.disfin();
            return new Bitmap(new MemoryStream(blob));
        }
    }
}