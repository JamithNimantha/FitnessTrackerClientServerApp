using FitnessTrackerClientApp.Service;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FitnessTrackerClientApp.DTO;

namespace FitnessTrackerClientApp.View
{
    public partial class CheatMealForm : UserControl
    {
        private readonly string _userName;
        private bool IsUpdate = false;
        private string _GUID;
        public CheatMealForm(string UserName)
        {
            _userName = UserName;
            InitializeComponent();
            Clear();
        }

        private void Clear()
        {
            var latestWeightEntry = WeightEntryService.Instance.FindLatestWeightEntryForUser(_userName);
            txtWeight.Text = latestWeightEntry.Weight.ToString();
            datePickerWeightEntryDate.Value = DateTime.Now;
            txtMealName.Text = "";
            txtColories.Text = Convert.ToDecimal("0.00").ToString();
            LoadTable();
            ChangeSaveUpdateButton();

        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            if (IsUpdate)
            {
                UpdateCheatMealEntry();
            }
            else
            {
                SaveCheatMealEntry();
            }
        }

        private void SaveCheatMealEntry()
        {
           if (string.IsNullOrEmpty(txtMealName.Text))
            {
                MessageBox.Show("Please Enter Meal Name!");
                return;
            }

            if (string.IsNullOrEmpty(txtColories.Text))
            {
                MessageBox.Show("Please Enter Calories Gained!");
                return;
            }

            if (string.IsNullOrEmpty(txtWeight.Text))
            {
                MessageBox.Show("Please Enter Weight!");
                return;
            }

            if (Convert.ToDecimal(txtColories.Text) <= 0)
            {
                MessageBox.Show("Please Enter Valid Calories Gained!");
                return;
            }

            if (Convert.ToDecimal(txtWeight.Text) <= 0)
            {
                MessageBox.Show("Please Enter Valid Weight!");
                return;
            }

            if (datePickerWeightEntryDate.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Please Enter Valid Date!");
                return;
            }

            var WeightEntry = new WeightEntryDTO();
            WeightEntry.UserName = _userName;
            WeightEntry.Weight = Convert.ToDecimal(txtWeight.Text);
            WeightEntry.Date = datePickerWeightEntryDate.Value;
            

            var CheatMealEntry = new CheatMealEntryDTO()
            {
                UserName = _userName,
                MealName = txtMealName.Text,
                Calories = Convert.ToDecimal(txtColories.Text),
                Date = datePickerWeightEntryDate.Value,
                WeightEntry = WeightEntry
                
            };

            try
            {
                CheatMealService.Instance.AddCheatMealEntry(CheatMealEntry);
                MessageBox.Show("Cheat Meal Entry Added Successfully!");
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateCheatMealEntry()
        {
            if (string.IsNullOrEmpty(txtMealName.Text))
            {
                MessageBox.Show("Please Enter Meal Name!");
                return;
            }

            if (string.IsNullOrEmpty(txtColories.Text))
            {
                MessageBox.Show("Please Enter Calories Gained!");
                return;
            }

            if (string.IsNullOrEmpty(txtWeight.Text))
            {
                MessageBox.Show("Please Enter Weight!");
                return;
            }

            if (Convert.ToDecimal(txtColories.Text) <= 0)
            {
                MessageBox.Show("Please Enter Valid Calories Gained!");
                return;
            }

            if (Convert.ToDecimal(txtWeight.Text) <= 0)
            {
                MessageBox.Show("Please Enter Valid Weight!");
                return;
            }

            if (datePickerWeightEntryDate.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Please Enter Valid Date!");
                return;
            }

            var Meal = CheatMealService.Instance.GetCheatMealEntryByGUID(_GUID);
            Meal.MealName = txtMealName.Text;
            Meal.Calories = Convert.ToDecimal(txtColories.Text);
            Meal.Date = datePickerWeightEntryDate.Value;

            Meal.WeightEntry.Date = datePickerWeightEntryDate.Value;
            Meal.WeightEntry.UserName = _userName;
            Meal.WeightEntry.Weight = Convert.ToDecimal(txtWeight.Text);

            try
            {
                CheatMealService.Instance.UpdateCheatMealEntry(Meal);
                MessageBox.Show("Workout Entry Updated Successfully!");
                this.IsUpdate = false;
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
            txtMealName.Text = selectedRow.Cells["MealName"].Value.ToString();
            txtWeight.Text = selectedRow.Cells["weight"].Value.ToString();
            txtColories.Text = selectedRow.Cells["Calories"].Value.ToString();
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
                CheatMealService.Instance.DeleteCheatMealEntryByGUID(GUID);
                dataGridView.Rows.Remove(row);
            });
            MessageBox.Show("Cheat Meal Entry Deleted Successfully!");
        }

        public void LoadTable()
        {
            dataGridView.Rows.Clear();
            var Entries = CheatMealService.Instance.FindCheatMealEntriesInDescByUserName(_userName);
            Entries.ForEach(CheatMeal =>
            {
                dataGridView.Rows.Add(CheatMeal.MealName, CheatMeal.Calories, CheatMeal.WeightEntry.Weight, CheatMeal.Date, CheatMeal.CheatMealEntryId);
            });

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
    }
}
