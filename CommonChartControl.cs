using System.Globalization;
using System.Web.UI;
using ChartTests.Charting;

namespace ChartTests
{
    public class CommonChartControl: Control
    {
        private readonly IChartFactory _factory;
        private readonly int _dataPointsCount;
        private readonly int _maxValue;
        public const string ChartTypeParamName = "chartType";
        public const string AddressSaltParamName = "addressSalt";
        public const string DataPointsCountParamName = "dataPointsCount";
        public const string MaxValueParamName = "maxValue";
        public CommonChartControl(IChartFactory factory, int dataPointsCount, int maxValue)
        {
            _factory = factory;
            _dataPointsCount = dataPointsCount;
            _maxValue = maxValue;
        }

        private static string AddParamToHandler(string url, string paramName, string paramValue)
        {
            return string.Format("{0}&{1}={2}", url, paramName, paramValue);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            var handlerUrl = "/ChartHandler.ashx?";
            handlerUrl = AddParamToHandler(handlerUrl, ChartTypeParamName, _factory.Id.ToString());
            handlerUrl = AddParamToHandler(handlerUrl, AddressSaltParamName, GetHashCode().ToString(CultureInfo.InvariantCulture));
            handlerUrl = AddParamToHandler(handlerUrl, DataPointsCountParamName, _dataPointsCount.ToString(CultureInfo.InvariantCulture));
            handlerUrl = AddParamToHandler(handlerUrl, MaxValueParamName, _maxValue.ToString(CultureInfo.InvariantCulture));            
            writer.Write("<img src='{0}' />", handlerUrl);
            base.Render(writer);
        }
    }
}