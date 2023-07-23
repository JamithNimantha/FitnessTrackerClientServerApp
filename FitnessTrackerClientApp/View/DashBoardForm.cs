using FitnessTrackerApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FitnessTrackerApp.View
{
    public partial class DashBoardForm : UserControl
    {
        private readonly string _userName;
        public DashBoardForm(string UserName)
        {
            _userName = UserName;
            InitializeComponent();
            ShowChart();
        }

        private void ShowChart()
        {
            chart.Series.Clear();

            var weightEntries = WeightEntryService.Instance.FindWeightEntriesInAscByUserName(_userName);

            // If there two or more weight entries for same date then remove the older one

            for (int i = 0; i < weightEntries.Count - 1; i++)
            {
                if (weightEntries[i].Date.Date == weightEntries[i + 1].Date.Date)
                {
                    weightEntries.RemoveAt(i);
                    i--;
                }
            }

            // Select the last 20 weight entries
            int startIndex = Math.Max(weightEntries.Count - 20, 0);
            var last20WeightEntries = weightEntries.GetRange(startIndex, Math.Min(20, weightEntries.Count - startIndex));

            // Create a chart area
            var chartArea = new ChartArea();
            chartArea.AxisX.MajorGrid.Enabled = true;
            chartArea.AxisY.MajorGrid.Enabled = true;
            chartArea.AxisX.LabelStyle.Format = "MMM dd";
            chartArea.AxisY.Minimum = ((double)last20WeightEntries.Min(w => w.Weight)) - 2;


            // Set chart title
            var chartTitle = new Title();
            chartTitle.Text = "User Weight Chart";
            chartTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            chart.Titles.Add(chartTitle);

            // Set X-axis title
            chartArea.AxisX.Title = "Date";
            chartArea.AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);


            // Set Y-axis title
            chartArea.AxisY.Title = "Weight (kg)";
            chartArea.AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);


            chart.ChartAreas.Add(chartArea);

            // Create a series for weight data
            var weightSeries = new Series();
            weightSeries.ChartType = SeriesChartType.Line;
            weightSeries.Color = Color.DodgerBlue;
            weightSeries.BorderWidth = 2;

            // Set series name
            weightSeries.Name = "Weight";
            weightSeries.MarkerStyle = MarkerStyle.Circle;
            weightSeries.MarkerSize = 8;
            weightSeries.MarkerColor = Color.DodgerBlue;
            // Add data points to the weight series
            foreach (var weightEntry in last20WeightEntries)
            {
                weightSeries.Points.AddXY(weightEntry.Date, weightEntry.Weight);
            }

            // Add the weight series to the chart
            chart.Series.Add(weightSeries);

        }

        private void chart_Click(object sender, EventArgs e)
        {

        }
    }
}
