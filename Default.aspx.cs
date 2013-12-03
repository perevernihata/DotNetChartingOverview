using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ChartingCore;

namespace FreeChartTools
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            foreach (var factory in FactoriesCollection.Instance)
                dblFactories.Items.Add(new ListItem(factory.ChartTypeName, factory.Id.ToString()));
        }

        protected void BtnClick(object sender, EventArgs e)
        {
            rpCheckAllResults.Visible = false;
            DoProcessIteration();
        }

        private IChartFactory CurrentFactory
        {
            get { return FactoriesCollection.Instance.SingleOrDefault(f => f.Id == new Guid(dblFactories.SelectedValue)); }
        }

        private int CurrentIteration
        {
            get { return int.Parse(ViewState["currentIteration"].ToString()); }
            set { ViewState["currentIteration"] = value; }
        }

        private List<ChartPerformanceInfo> Statistic
        {
            get
            {
                if ((List<ChartPerformanceInfo>)ViewState["statistic"] == null)
                {
                    ViewState["statistic"] = new List<ChartPerformanceInfo>();
                }
                return (List<ChartPerformanceInfo>)ViewState["statistic"];
            }
            set { ViewState["statistic"] = value; }
        }

        private TimeSpan SolutionStartTime
        {
            get { return TimeSpan.Parse(ViewState["summaryTime"].ToString()); }
            set { ViewState["summaryTime"] = value; }
        }

        protected void BtnCompareAllClick(object sender, EventArgs e)
        {
            RefillStatistic();
            rpCheckAllResults.Visible = true;
            dblFactories.Enabled = false;
            btnCompareAll.Enabled = false;
            btnCheck.Enabled = false;
            hdIterate.Value = true.ToString();
            dblFactories.SelectedIndex = 0;
            SolutionStartTime = TimeSpan.FromTicks(DateTime.Now.Ticks);
            CurrentIteration = 0;
            IterateChart();
        }

        private void RefillStatistic()
        {
            Statistic.Clear();
            foreach (var factory in FactoriesCollection.Instance)
            {
                Statistic.Add(new ChartPerformanceInfo
                    {
                        FactoryId = factory.Id,
                        Iterations = 0,
                        Time = 0
                    });
            }
        }

        private void DoProcessIteration()
        {
            chartPanel.Controls.Clear();
            var factory = CurrentFactory;
            if (factory == null)
                return;
            int maxValue;
            int dataPointCount;
            int chartWidth;
            int chartHeight;
            if (!Int32.TryParse(tbMaxValue.Text, out maxValue) || !Int32.TryParse(tbDataPointsCount.Text, out dataPointCount))
                return;
            if (!Int32.TryParse(tbWidth.Text, out chartWidth) || !Int32.TryParse(tbHeight.Text, out chartHeight))
                return;
            for (var i = 0; i < int.Parse(tbChartsCount.Text); i++)
            {
                chartPanel.Controls.Add(new CommonChartControl(factory, dataPointCount, maxValue, chartWidth, chartHeight));
            }
        }

        public void IterateChart()
        {
            CurrentIteration++;
            DoProcessIteration();
            var currentStatistic = Statistic.Single(s => s.FactoryId == CurrentFactory.Id);
            currentStatistic.Iterations = CurrentIteration;
            currentStatistic.Time = TimeSpan.FromTicks(DateTime.Now.Ticks - SolutionStartTime.Ticks).TotalSeconds;
            if (CurrentIteration >= int.Parse(tbIterationsCount.Text))
            {
                Statistic = Statistic.OrderBy(info => info.Average).ToList();
                SolutionStartTime = TimeSpan.FromTicks(DateTime.Now.Ticks);
                CurrentIteration = 0;
                if (dblFactories.SelectedIndex == dblFactories.Items.Count - 1)
                {
                    hdIterate.Value = false.ToString();
                    btnCompareAll.Enabled = true;
                    dblFactories.Enabled = true;
                    btnCheck.Enabled = true;
                }
                else
                    dblFactories.SelectedIndex++;
            }
            rpCheckAllResults.DataSource = Statistic;
            rpCheckAllResults.DataBind();
        }

        protected void BtnIterateHiddenClick(object sender, EventArgs e)
        {
            IterateChart();
        }

        [Serializable]
        class ChartPerformanceInfo
        {
            public Guid FactoryId { get; set; }
            public string FactoryName { get { return FactoriesCollection.Instance.Single(f => f.Id == FactoryId).ChartTypeName; } }
            public double Time { get; set; }
            public int Iterations { get; set; }
            public double Average { get { return Iterations == 0 ? 0 : Time / Iterations; } }
        }
    }
}
