using FitnessTrackerClientApp.DTO;
using FitnessTrackerClientApp.Service;
using FitnessTrackerClientApp.Utility;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FitnessTrackerClientApp.View
{
    public partial class WorkoutForm : UserControl
    {
        private readonly string _userName;
        private bool IsUpdate = false;
        private string _GUID;
        public WorkoutForm(String UserName)
        {
            _userName = UserName;
            InitializeComponent();
            Clear();
        }

        public void Clear()
        {
            var latestWeightEntry = WeightEntryService.Instance.FindLatestWeightEntryForUser(_userName);
            txtWeight.Text = latestWeightEntry.Weight.ToString();
            datePickerWeightEntryDate.Value = DateTime.Now;
            txtWorkoutName.Text = "";
            txtColoriesBurnt.Text = Convert.ToDecimal("0.00").ToString();
            LoadTable();
            ChangeSaveUpdateButton();
            cmbIntensity.DataSource = Util.GetIntensityTypes();

        }

        public void ChangeSaveUpdateButton()
        {
            if (IsUpdate)
            {
                btnAddEntry.Text = "Update";
                btnAddEntry.BackColor = Color.Green;
            }
            else
            {
                btnAddEntry.Text = "Save";
                btnAddEntry.BackColor = Color.Blue;
            }
        }

        public void LoadTable()
        {
            dataGridView.Rows.Clear();
            var WorkoutEntries = WorkoutService.Instance.FindWorkoutsInDescByUserName(_userName);
            WorkoutEntries.ForEach(Workout =>
            {
                dataGridView.Rows.Add(Workout.WorkoutName, Workout.Intensity, Workout.CaloriesBurned, Workout.WeightEntry.Weight, Workout.Date, Workout.WorkoutEntryId);
            });

        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            if (IsUpdate)
            {
                UpdateWorkoutEntry();
            }
            else
            {
                SaveWorkEntry();
            }
        }

        private void UpdateWorkoutEntry()
        {
            if (string.IsNullOrEmpty(txtWorkoutName.Text.Trim()))
            {
                MessageBox.Show("Please Enter Workout Name!");
                return;
            }

            if (string.IsNullOrEmpty(txtColoriesBurnt.Text))
            {
                MessageBox.Show("Please Enter Calories Burned!");
                return;
            }

            if (string.IsNullOrEmpty(txtWeight.Text))
            {
                MessageBox.Show("Please Enter Weight!");
                return;
            }

            if (string.IsNullOrEmpty(cmbIntensity.Text))
            {
                MessageBox.Show("Please Select Intensity!");
                return;
            }

            if (datePickerWeightEntryDate.Value > DateTime.Now)
            {
                MessageBox.Show("Please Select Valid Date!");
                return;
            }

            var WorkoutEntry = WorkoutService.Instance.GetWorkoutByGUID(_GUID);
            WorkoutEntry.WorkoutName = txtWorkoutName.Text;
            WorkoutEntry.CaloriesBurned = Convert.ToDecimal(txtColoriesBurnt.Text);
            WorkoutEntry.Date = datePickerWeightEntryDate.Value;
            WorkoutEntry.Intensity = cmbIntensity.Text;

            WorkoutEntry.WeightEntry.Date = datePickerWeightEntryDate.Value;
            WorkoutEntry.WeightEntry.UserName = _userName;
            WorkoutEntry.WeightEntry.Weight = Convert.ToDecimal(txtWeight.Text);

            try
            {
                WorkoutService.Instance.UpdateWorkout(WorkoutEntry);
                MessageBox.Show("Workout Entry Updated Successfully!");
                this.IsUpdate = false;
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveWorkEntry()
        {

            if (string.IsNullOrEmpty(txtWorkoutName.Text))
            {
                MessageBox.Show("Please Enter Workout Name!");
                return;
            }

            if (string.IsNullOrEmpty(txtColoriesBurnt.Text))
            {
                MessageBox.Show("Please Enter Calories Burned!");
                return;
            }

            if (string.IsNullOrEmpty(txtWeight.Text))
            {
                MessageBox.Show("Please Enter Weight!");
                return;
            }

            if (string.IsNullOrEmpty(cmbIntensity.Text))
            {
                MessageBox.Show("Please Select Intensity!");
                return;
            }

            if (datePickerWeightEntryDate.Value > DateTime.Now)
            {
                MessageBox.Show("Please Select Valid Date!");
                return;
            }

            var WorkoutEntry = new WorkoutEntryDTO();
            WorkoutEntry.WorkoutName = txtWorkoutName.Text;
            WorkoutEntry.CaloriesBurned = Convert.ToDecimal(txtColoriesBurnt.Text);
            WorkoutEntry.Date = datePickerWeightEntryDate.Value;
            WorkoutEntry.Intensity = cmbIntensity.Text;
            WorkoutEntry.UserName = _userName;

            var WeightEntry = new WeightEntryDTO();
            WeightEntry.Date = datePickerWeightEntryDate.Value;
            WeightEntry.UserName = _userName;
            WeightEntry.Weight = Convert.ToDecimal(txtWeight.Text);
            WorkoutEntry.WeightEntry = WeightEntry;

            try
            {
                WorkoutService.Instance.AddWorkout(WorkoutEntry);
                MessageBox.Show("Workout Entry Saved Successfully!");
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Please Select a Row!");
                return;
            }

            var selectedRow = selectedRows[0];
            this._GUID = selectedRow.Cells["GUID"].Value.ToString();
            txtWorkoutName.Text = selectedRow.Cells["WorkOutName"].Value.ToString();
            txtWeight.Text = selectedRow.Cells["weight"].Value.ToString();
            txtColoriesBurnt.Text = selectedRow.Cells["CaloriesBurnt"].Value.ToString();
            cmbIntensity.SelectedItem = selectedRow.Cells["Intensity"].Value.ToString();
            datePickerWeightEntryDate.Value = Convert.ToDateTime(selectedRow.Cells["Date"].Value.ToString());
            this.IsUpdate = true;
            ChangeSaveUpdateButton();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Please Select a Row!");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            dataGridView.SelectedRows.Cast<DataGridViewRow>().ToList().ForEach(row =>
            {
                var GUID = row.Cells["GUID"].Value.ToString();
                WorkoutService.Instance.DeleteWorkoutByGUID(GUID);
                dataGridView.Rows.Remove(row);
            });
            MessageBox.Show("Weight Entry Deleted Successfully!");
        }

        private void WorkoutForm_Load(object sender, EventArgs e)
        {

        }
    }
}
