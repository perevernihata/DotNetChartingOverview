using System.Web.UI;
using Telerik.Web.UI;

namespace ChartTests.SpecificChartFactories
{
    public class TelerikChartFactory : BaseChartFactory
    {
        public override Control DoGenerateChartConrol()
        {
            return new RadChartWrapper(MaxValue, DataPointsCount);
        }

        public override string ChartName
        {
            get { return "Telerik Charts"; }
        }
    }
}