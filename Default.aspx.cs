using System;
using System.Web.UI.WebControls;
using ChartTests.SpecificChartFactories;
using System.Collections.Generic;

namespace ChartTests
{
    public partial class _Default : System.Web.UI.Page
    {

        public Dictionary<Guid, IChartFactory> Factories = new Dictionary<Guid, IChartFactory>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Factories.Add(typeof(TelerikChartFactory).GUID, new TelerikChartFactory());
            Factories.Add(typeof(MicrosoftChartFactory).GUID, new MicrosoftChartFactory());
            Factories.Add(typeof(WebChartControlFactory).GUID, new WebChartControlFactory());
            
            Guid preselectedValue = Guid.Empty;
            if (dblFactories.SelectedIndex != -1)
                preselectedValue = new Guid(dblFactories.SelectedValue);
            dblFactories.Items.Clear();
            foreach (var factory in Factories)
            {
                dblFactories.Items.Add(new ListItem(((IChartFactory)factory.Value).ChartName, factory.Key.ToString()));
            }
            if (preselectedValue != Guid.Empty)
                dblFactories.SelectedValue = preselectedValue.ToString();
        }

        private IChartFactory GetCurrentFactory()
        {
            return Factories[new Guid(dblFactories.SelectedValue)];
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            ltrTimeSpan.Text = string.Format("Generating {0} charts each with {1} points takes ", tbChartsCount.Text, tbDataPointsCount.Text);
        
            base.OnPreRenderComplete(e);
        }

        protected void BtnClick(object sender, EventArgs e)
        {
            IChartFactory factory = GetCurrentFactory();
            for (var i = 0; i < int.Parse(tbChartsCount.Text); i++)
            {
                chartPanel.Controls.Add(factory.GenerateChartConrol(int.Parse(tbMaxValue.Text), int.Parse(tbDataPointsCount.Text)));
            }
        }
    }
}
