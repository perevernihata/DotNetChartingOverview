using System.Collections.Generic;
using System.Collections.ObjectModel;
using FreeChartTools.Charting;
using Spring.Context.Support;

namespace FreeChartTools
{
    public class FactoriesCollection : Collection<IChartFactory>
    {
        private static FactoriesCollection _instance;
        public static FactoriesCollection Instance
        {
            get
            {
                return _instance ?? (_instance = (FactoriesCollection) ContextRegistry.GetContext().GetObject("CurrentFactoriesCollection"));
            }
        }

        public FactoriesCollection(IList<IChartFactory> list):base(list)
        {
            
        }
    }
}