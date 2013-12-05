using System;

namespace ChartingCore
{
    public abstract class BaseChartFactory : IChartFactory
    {
        public abstract IChartAdapter DoGenerateChart(ChartParameters parameters);


        public virtual SolutionType SolutionType { get; private set; }

        public Guid Id
        {
            get { return GetType().GUID; }
        }

        protected BaseChartFactory()
        {
            SolutionType = SolutionType.Commercial;
        }

        public IChartAdapter GenerateChart(ChartParameters parameters)
        {
            var adapter = DoGenerateChart(parameters);
            adapter.Owner = this;
            return adapter;
        }

        public abstract string ChartTypeName { get; }
        public abstract string DownloadLink { get; }
    }
}