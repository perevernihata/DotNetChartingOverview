using System;

namespace ChartingCore
{
    public abstract class BaseChartFactory : IChartFactory
    {
        public abstract IChartAdapter DoGenerateChart(ChartParameters parameters);


        public virtual bool IsCommercialSolution { get; private set; }

        public Guid Id
        {
            get { return GetType().GUID; }
        }

        public IChartAdapter GenerateChart(ChartParameters parameters)
        {
            var adapter = DoGenerateChart(parameters);
            adapter.Owner = this;            
            IsCommercialSolution = true;
            return adapter;
        }

        public abstract string ChartTypeName { get; }
        public abstract string DownloadLink { get; }
    }
}