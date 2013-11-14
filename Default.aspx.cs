using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace ChartTests
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            foreach (var factory in FactoriesCollection.Instance)
                dblFactories.Items.Add(new ListItem(factory.ChartTypeName, factory.Id.ToString()));
        }

        protected void BtnClick(object sender, EventArgs e)
        {
            var factory = FactoriesCollection.Instance.SingleOrDefault(f => f.Id == new Guid(dblFactories.SelectedValue));
            if (factory == null)
                return;
            int maxValue;
            int dataPointCount;
            if (!Int32.TryParse(tbMaxValue.Text, out maxValue) || !Int32.TryParse(tbDataPointsCount.Text, out dataPointCount))
                return;
            for (var i = 0; i < int.Parse(tbChartsCount.Text); i++)
            {
                chartPanel.Controls.Add(new CommonChartControl(factory, dataPointCount, maxValue));
            }
        }
    }
}
