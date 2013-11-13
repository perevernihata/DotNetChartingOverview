using System;

namespace ChartTests.Charting
{
    public interface IChartFactory
    {
        IChartWrapper GenerateChart(ChartParameters parameters);
        string ChartTypeName { get; }
        Guid Id { get; }
    }
}