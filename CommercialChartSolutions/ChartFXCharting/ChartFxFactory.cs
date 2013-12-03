
using ChartingCore;

namespace ChartFXCharting
{
    /// <summary>
    /// You can download trial Chart FX binaries from here: http://www.softwarefx.com/sfxnetproducts/cfxlitefornet/
    /// </summary>
    public class ChartFxFactory: BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new ChartFxAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "Chart FX"; }
        }
    }
}