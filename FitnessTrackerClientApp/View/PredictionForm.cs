using FitnessTrackerClientApp.DTO;
using FitnessTrackerClientApp.Service;
using System;
using System.Windows.Forms;

namespace FitnessTrackerClientApp.View
{
    public partial class PredictionForm : UserControl
    {
        private readonly string _userName;
        public PredictionForm(string UserName)
        {
            InitializeComponent();
            _userName = UserName;
            Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbltotalCaloriesGained_Click(object sender, EventArgs e)
        {

        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
           
            DateTime futureDate = datePicker.Value.Date;

            var entry = new FitnessPredictionDTO();
            entry.Date = futureDate;

            var client = new RestClient(RestClient.BaseUrl + RestClient.FitnessPredictionUrl, RestClient.BearerToken);
            var record =  client.PostData<FitnessPredictionDTO>(entry);


            lblWeight.Text = "Predicted Weight: " + record.PredictedWeight.ToString("0.00") + " KG";
            lblStatus.Text = "Predicted Fitness Status : " + record.PredictedFitnessStatus;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        { 
            lblStatus.Text = "Predicted Fitness Status :";
            lblWeight.Text = "Predicted Weight (KG) :";
            datePicker.MinDate = DateTime.Today.Add(TimeSpan.FromDays(1));
            datePicker.Value = DateTime.Today.Add(TimeSpan.FromDays(1));

        }
    }
}
