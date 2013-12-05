using System;

namespace ChartingCore
{
    public interface IChartFactory
    {
        IChartAdapter GenerateChart(ChartParameters parameters);
        string ChartTypeName { get; }
        string DownloadLink { get; }
        Guid Id { get; }
    }
}