using System;

namespace FreeChartTools.Charting
{
    public interface IChartFactory
    {
        IChartAdapter GenerateChart(ChartParameters parameters);
        string ChartTypeName { get; }
        Guid Id { get; }
    }
}