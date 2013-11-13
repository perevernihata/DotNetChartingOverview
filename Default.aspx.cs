using System;
using System.Linq;
using System.Web.UI.WebControls;
using ChartTests.Charting;
using System.Collections.Generic;

namespace ChartTests
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (dblFactories.Items.Count != 0) return;
            foreach (var factory in FactoriesCollection.Instance)
                dblFactories.Items.Add(new ListItem(factory.ChartTypeName, factory.Id.ToString()));
        }

        private IChartFactory GetCurrentFactory()
        {
            return FactoriesCollection.Instance.SingleOrDefault(f => f.Id == new Guid(dblFactories.SelectedValue));
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            ltrTimeSpan.Text = string.Format("Generating {0} charts each with {1} points takes ", tbChartsCount.Text, tbDataPointsCount.Text);
            base.OnPreRenderComplete(e);
        }

        protected void BtnClick(object sender, EventArgs e)
        {
            var factory = GetCurrentFactory();
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
