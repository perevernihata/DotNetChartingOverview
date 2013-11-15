using System.Globalization;
using System.Web.UI;
using FreeChartTools.Charting;

namespace FreeChartTools
{
    public class CommonChartControl: Control
    {
        private readonly IChartFactory _factory;
        private readonly int _dataPointsCount;
        private readonly int _maxValue;
        private readonly int _width;
        private readonly int _height;
        public const string ChartTypeParamName = "chartType";
        public const string AddressSaltParamName = "addressSalt";
        public const string DataPointsCountParamName = "dataPointsCount";
        public const string MaxValueParamName = "maxValue";
        public const string ChartWidthParamName = "ChartWidth";
        public const string ChartHeightParamName = "ChartHeight";
        public CommonChartControl(IChartFactory factory, int dataPointsCount, int maxValue, int width, int height)
        {
            _factory = factory;
            _dataPointsCount = dataPointsCount;
            _maxValue = maxValue;
            _width = width;
            _height = height;
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
            handlerUrl = AddParamToHandler(handlerUrl, ChartWidthParamName, _width.ToString(CultureInfo.InvariantCulture));
            handlerUrl = AddParamToHandler(handlerUrl, ChartHeightParamName, _height.ToString(CultureInfo.InvariantCulture));            
            writer.Write("<img src='{0}' />", handlerUrl);
            base.Render(writer);
        }
    }
}