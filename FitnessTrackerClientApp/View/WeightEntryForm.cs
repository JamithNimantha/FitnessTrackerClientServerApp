using FitnessTrackerApp.Model;
using FitnessTrackerApp.Service;
using System;
using System.Windows.Forms;

namespace FitnessTrackerApp.View
{
    public partial class WeightEntryForm : UserControl
    {
        private readonly string _userName;
        private bool IsUpdate = false;
        private string _GUID;
        public WeightEntryForm(String UserName)
        {
            _userName = UserName;
            InitializeComponent();
            Clear();
        }


        private void LoadTable()
        {
            dataGridViewWeightEntry.Rows.Clear();
            var list = WeightEntryService.Instance.FindWeightEntriesInDescByUserName(_userName);
            list.ForEach(x => 
            { 
                dataGridViewWeightEntry.Rows.Add(x.Weight, x.Date, x.GUID);
            });
        }

        private void DeleteRecord()
        {
            var selectedRows = dataGridViewWeightEntry.SelectedRows;
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

            var selectedRow = selectedRows[0];
            var guid = selectedRow.Cells[2].Value.ToString();
            bool existsInWorkout = WorkoutService.Instance.CheckIfWeightEntryExistsInWorkout(guid);
            if (existsInWorkout)
            {
                MessageBox.Show("This Weight Entry is used in a Workout. Please delete the Workout first!");
                return;
            }

            bool existsInCheatMeal = CheatMealService.Instance.CheckIfWeightEntryExistsInCheatMeal(guid);
            if (existsInCheatMeal)
            {
                MessageBox.Show("This Weight Entry is used in a Cheat Meal. Please delete the Cheat Meal first!");
                return;
            }
            
            WeightEntryService.Instance.DeleteEntry(guid);
            dataGridViewWeightEntry.Rows.Remove(selectedRow);
            MessageBox.Show("Weight Entry Deleted Successfully!");
        }

        private void UpdateRecord()
        {
            var selectedRows = dataGridViewWeightEntry.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Please Select a Row!");
                return;
            }

            var selectedRow = selectedRows[0];
            this._GUID = selectedRow.Cells[2].Value.ToString();
            txtWeight.Value = Convert.ToDecimal(selectedRow.Cells[0].Value);
            datePickerWeightEntryDate.Value = Convert.ToDateTime(selectedRow.Cells[1].Value);
            this.IsUpdate = true;
            ChangeSaveUpdateButton();

            
        }

        private void UpdateEntry()
        {
            var weight = Convert.ToDecimal(txtWeight.Text);
            var Date = datePickerWeightEntryDate.Value;

            if (weight <= 0)
            {
                MessageBox.Show("Please Enter Valid Weight!");
                return;
            }

            if (Date > DateTime.Now.Date)
            {
                MessageBox.Show("Please Enter Valid Date!");
                return;
            }

            var weightEntry = new WeightEntry();
            weightEntry.Weight = weight;
            weightEntry.Date = Date;
            weightEntry.UserName = _userName;
            weightEntry.GUID = this._GUID;

            WeightEntryService.Instance.UpdateEntry(weightEntry, this._GUID);
            MessageBox.Show("Weight Entry Updated Successfully!");
            this.IsUpdate = false;
            Clear();
        }

        private void ChangeSaveUpdateButton()
        {
            if (this.IsUpdate)
            {
                this.btnAddEntry.Text = "Update";
                this.btnAddEntry.BackColor = System.Drawing.Color.Green;
            } 
            else
            {
                this.btnAddEntry.Text = "Save";
                this.btnAddEntry.BackColor = System.Drawing.Color.Blue;
            }
            
        }


        private void SaveEntry()
        {
            var weight = Convert.ToDecimal(txtWeight.Text);
            var Date = datePickerWeightEntryDate.Value;

            if (weight <= 0)
            {
                MessageBox.Show("Please Enter Valid Weight!");
                return;
            }

            if (Date > DateTime.Now.Date)
            {
                MessageBox.Show("Please Enter Valid Date!");
                return;
            }

            var weightEntry = new WeightEntry();
            weightEntry.Weight = weight;
            weightEntry.Date = Date;
            weightEntry.UserName = _userName;

            WeightEntryService.Instance.AddEntry(weightEntry);

            MessageBox.Show("Weight Entry Added Successfully!");
            Clear();
        }



        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            if (this.IsUpdate)
            {
                UpdateEntry();
            }
            else
            {
                SaveEntry();
            }
            
        }

        private void Clear()
        {
            var latestWeightEntry = WeightEntryService.Instance.FindLatestWeightEntryForUser(_userName);
            txtWeight.Text = latestWeightEntry.Weight.ToString();
            datePickerWeightEntryDate.Value = DateTime.Now.Date;
            LoadTable();
            ChangeSaveUpdateButton();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

    }
}
