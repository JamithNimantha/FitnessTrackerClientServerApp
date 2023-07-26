using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FitnessTrackerClientApp.Enumeration;
using FitnessTrackerClientApp.DTO;
using FitnessTrackerClientApp.Service;

namespace FitnessTrackerClientApp.View
{
    public partial class ReportForm : UserControl
    {
        private readonly string _userName;
        public ReportForm(string UserName)
        {
            _userName = UserName;
            InitializeComponent();
            Clear();
        }

        public void Clear()
        { 
            this.datePickerEndDate.MaxDate = DateTime.Today;
            this.datePickerEndDate.Value = DateTime.Today;
            this.datePickerStartDate.Value = DateTime.Today.Subtract(TimeSpan.FromDays(30));
            this.dataGridView.Rows.Clear();
            lbltotalCaloriesGained.Text = "Total Calories Gained : ";
            lbltotalCaloriesBurnt.Text = "Total Calories Burned : ";
            lblAverageWeight.Text = "Average Weight (KG) : ";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void datePickerWeightEntryDate_ValueChanged(object sender, EventArgs e)
        {
            this.datePickerEndDate.MinDate = this.datePickerStartDate.Value;
        }

        private void cmbIntensity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GenerateReport()
        {

            if (datePickerStartDate.Value.Date > datePickerEndDate.Value.Date)
            {
                MessageBox.Show("Start Date cannot be greater than End Date");
                return;
            }

            var entry = new ReportDataDTO
            {
                StartDate = datePickerStartDate.Value.Date,
                EndDate = datePickerEndDate.Value.Date
            };
            var startDate = datePickerStartDate.Value.Date;
            var endDate = datePickerEndDate.Value.Date;

            var client = new RestClient(RestClient.BaseUrl + RestClient.ReportUrl, RestClient.BearerToken);
            var record = client.PostData<ReportDataDTO>(entry);

            /*List<WorkoutEntry> workoutEntries = WorkoutService.Instance.FindWorkoutsInDescByUserName(_userName)
                .Where(w => w.Date >= startDate && w.Date <= endDate)
                .ToList();
            List<CheatMealEntry> cheatMealEntries = CheatMealService.Instance.FindCheatMealEntriesInDescByUserName(_userName)
                .Where(w => w.Date >= startDate && w.Date <= endDate)
                .ToList();

            List<WeightEntry> weightEntries = WeightEntryService.Instance.FindWeightEntriesInDescByUserName(_userName)
                .Where(w => w.Date >= startDate && w.Date <= endDate)
                .ToList();*/

           /* var totalCaloriesBurnt = workoutEntries.Sum(w => w.CaloriesBurned);
            var totalCaloriesGained = cheatMealEntries.Sum(c => c.Calories);
            // calculate the average weight to 2 decimal places
            var averageWeight = weightEntries.Average(w => w.Weight);
            // calculate the average calories burnt
            var averageCaloriesBurnt = workoutEntries.Average(w => w.CaloriesBurned);
            // calculate the average calories gained
            var averageCaloriesGained = cheatMealEntries.Average(c => c.Calories);*/

            lbltotalCaloriesBurnt.Text = $"Total Calories Burned : {Math.Round(record.TotolCaloriesBurned, 2)}";
            lbltotalCaloriesGained.Text = $"Total Calories Gained : {Math.Round(record.TotalCaloriesGained, 2)}";
            lblAverageWeight.Text = $"Average Weight : {Math.Round(record.AverageWeight, 2)} KG";

            /*var combinedList = record.ReportItemData
                .GroupBy(w => w.Date.Date)
                .Select(w => new
                {
                    Date = w.Key,
                    Workouts = workoutEntries.Where(c => c.Date.Date == w.Key).Count(),
                    CheatMeals = cheatMealEntries.Where(c => c.Date.Date == w.Key).Count(),
                    CaloriesBurnt = workoutEntries.Where(c => c.Date.Date == w.Key).Sum(c => c.CaloriesBurned),
                    CaloriesGained = cheatMealEntries.Where(c => c.Date.Date == w.Key).Sum(c => c.Calories),
                    AverageWeight = weightEntries.Where(c => c.Date.Date == w.Key).Average(c => c.Weight)
                })
                .ToList();*/


            this.dataGridView.Rows.Clear();
            foreach (var item in record.ReportItemData)
            {
                this.dataGridView.Rows.Add(item.Date.ToShortDateString(), item.Workouts,
                    item.CheatMeals, item.CaloriesBurned, item.CaloriesGained, Math.Round(item.AverageWeight, 2));
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // validate if there is any data to export
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("There is no data to export");
                return;
            }

            var sb = new StringBuilder();
            var headers = dataGridView.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }

            var fileName = "Report_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString());
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
