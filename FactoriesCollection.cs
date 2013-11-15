using System.Collections.ObjectModel;
using FreeChartTools.Charting;
using FreeChartTools.Charting.GoogleSharpCharting;
using FreeChartTools.Charting.MsCharting;
using FreeChartTools.Charting.NPlotCharting;
using FreeChartTools.Charting.OxyPlotCharting;
using FreeChartTools.Charting.WebCharting;
using FreeChartTools.Charting.ZedGraph;

namespace FreeChartTools
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
            Add(new GoogleSharpChartFactory());
            Add(new ZedGraphChartFactory());
            Add(new OxyPlotChartFactory());
        }
    }
}