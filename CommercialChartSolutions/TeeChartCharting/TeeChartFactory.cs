using System;
using ChartingCore;

namespace TeeChartCharting
{
    public class TeeChartFactory: BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new TeeChartAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "Tee charts"; }
        }
    }
}
