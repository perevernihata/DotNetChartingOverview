using System;

namespace ChartingCore
{
    public enum SolutionType
    {
        Free,
        Commercial,
        Any
    }

    public interface IChartFactory
    {
        IChartAdapter GenerateChart(ChartParameters parameters);
        string ChartTypeName { get; }
        string DownloadLink { get; }
        SolutionType SolutionType { get; }
        Guid Id { get; }
    }
}