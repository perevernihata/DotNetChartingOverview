using System;

namespace ChartingCore
{
    public interface IChartFactory
    {
        IChartAdapter GenerateChart(ChartParameters parameters);
        string ChartTypeName { get; }
        string DownloadLink { get; }
        bool IsCommercialSolution { get; }
        Guid Id { get; }
    }
}