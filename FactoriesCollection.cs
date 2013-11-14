using System.Collections.ObjectModel;
using ChartTests.Charting;
using ChartTests.Charting.MsCharting;
using ChartTests.Charting.NPlotCharting;
using ChartTests.Charting.WebCharting;

namespace ChartTests
{
    public class FactoriesCollection : Collection<IChartFactory>
    {
        private static FactoriesCollection _instance;
        public static FactoriesCollection Instance
        {
            get { return _instance ?? (_instance = new FactoriesCollection()); }
        }
        private FactoriesCollection()
        {
            Add(new MicrosoftChartFactory());
            Add(new WebChartControlFactory());
            Add(new NPlotChartFactory());
        }
    }
}