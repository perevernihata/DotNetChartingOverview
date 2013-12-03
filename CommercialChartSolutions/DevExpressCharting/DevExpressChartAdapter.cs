using System;
using System.Drawing;
using ChartingCore;
using DevExpress.XtraCharts.Web;

namespace DevExpressCharting
{
    /// <summary>
    /// You can download trial Dev Express binaries from here: https://www.devexpress.com/Home/try.xml
    /// </summary>
    public class DevExpressChartAdapter: BaseChartAdapter
    {
        public DevExpressChartAdapter(ChartParameters parameters) : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            throw new NotImplementedException();
            var linechart = new WebChartControl();
            return null;
        }
    }
}
