namespace FitnessTrackerApp.View
{
    partial class ReportForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.datePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.datePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.lbltotalCaloriesBurnt = new System.Windows.Forms.Label();
            this.lbltotalCaloriesGained = new System.Windows.Forms.Label();
            this.lblAverageWeight = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Workouts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheatMeals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaloriesBurned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaloriesGained = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // datePickerStartDate
            // 
            this.datePickerStartDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.datePickerStartDate.CustomFormat = "yyyy-MM-dd";
            this.datePickerStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerStartDate.Location = new System.Drawing.Point(168, 39);
            this.datePickerStartDate.Name = "datePickerStartDate";
            this.datePickerStartDate.Size = new System.Drawing.Size(132, 30);
            this.datePickerStartDate.TabIndex = 47;
            this.datePickerStartDate.Value = new System.DateTime(2023, 7, 11, 3, 19, 57, 0);
            this.datePickerStartDate.ValueChanged += new System.EventHandler(this.datePickerWeightEntryDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(54, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 23);
            this.label3.TabIndex = 46;
            this.label3.Text = "Start Date:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // datePickerEndDate
            // 
            this.datePickerEndDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.datePickerEndDate.CustomFormat = "yyyy-MM-dd";
            this.datePickerEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerEndDate.Location = new System.Drawing.Point(440, 39);
            this.datePickerEndDate.Name = "datePickerEndDate";
            this.datePickerEndDate.Size = new System.Drawing.Size(132, 30);
            this.datePickerEndDate.TabIndex = 49;
            this.datePickerEndDate.Value = new System.DateTime(2023, 7, 11, 3, 19, 57, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(326, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 23);
            this.label1.TabIndex = 48;
            this.label1.Text = "End Date:";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(870, 35);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(162, 34);
            this.btnClear.TabIndex = 60;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.Blue;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(662, 35);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(162, 34);
            this.btnGenerate.TabIndex = 59;
            this.btnGenerate.TabStop = false;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Workouts,
            this.CheatMeals,
            this.CaloriesBurned,
            this.CaloriesGained,
            this.Weight});
            this.dataGridView.Location = new System.Drawing.Point(26, 222);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1048, 363);
            this.dataGridView.TabIndex = 61;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Green;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(912, 592);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(162, 34);
            this.btnExport.TabIndex = 62;
            this.btnExport.TabStop = false;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lbltotalCaloriesBurnt
            // 
            this.lbltotalCaloriesBurnt.AutoSize = true;
            this.lbltotalCaloriesBurnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalCaloriesBurnt.Location = new System.Drawing.Point(30, 136);
            this.lbltotalCaloriesBurnt.Name = "lbltotalCaloriesBurnt";
            this.lbltotalCaloriesBurnt.Size = new System.Drawing.Size(247, 25);
            this.lbltotalCaloriesBurnt.TabIndex = 63;
            this.lbltotalCaloriesBurnt.Text = "Total Calories Burned :  ";
            // 
            // lbltotalCaloriesGained
            // 
            this.lbltotalCaloriesGained.AutoSize = true;
            this.lbltotalCaloriesGained.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalCaloriesGained.Location = new System.Drawing.Point(391, 136);
            this.lbltotalCaloriesGained.Name = "lbltotalCaloriesGained";
            this.lbltotalCaloriesGained.Size = new System.Drawing.Size(247, 25);
            this.lbltotalCaloriesGained.TabIndex = 64;
            this.lbltotalCaloriesGained.Text = "Total Calories Gained :  ";
            this.lbltotalCaloriesGained.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblAverageWeight
            // 
            this.lblAverageWeight.AutoSize = true;
            this.lblAverageWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageWeight.Location = new System.Drawing.Point(753, 136);
            this.lblAverageWeight.Name = "lblAverageWeight";
            this.lblAverageWeight.Size = new System.Drawing.Size(245, 25);
            this.lblAverageWeight.TabIndex = 65;
            this.lblAverageWeight.Text = "Average Weight (KG) :  ";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 125;
            // 
            // Workouts
            // 
            this.Workouts.HeaderText = "Total Workouts";
            this.Workouts.MinimumWidth = 6;
            this.Workouts.Name = "Workouts";
            this.Workouts.ReadOnly = true;
            this.Workouts.Width = 125;
            // 
            // CheatMeals
            // 
            this.CheatMeals.HeaderText = "Total CheatMeals";
            this.CheatMeals.MinimumWidth = 6;
            this.CheatMeals.Name = "CheatMeals";
            this.CheatMeals.ReadOnly = true;
            this.CheatMeals.Width = 125;
            // 
            // CaloriesBurned
            // 
            this.CaloriesBurned.HeaderText = "Calories Burned";
            this.CaloriesBurned.MinimumWidth = 6;
            this.CaloriesBurned.Name = "CaloriesBurned";
            this.CaloriesBurned.ReadOnly = true;
            this.CaloriesBurned.Width = 125;
            // 
            // CaloriesGained
            // 
            this.CaloriesGained.HeaderText = "Calories Gained";
            this.CaloriesGained.MinimumWidth = 6;
            this.CaloriesGained.Name = "CaloriesGained";
            this.CaloriesGained.ReadOnly = true;
            this.CaloriesGained.Width = 125;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Average Weight (KG)";
            this.Weight.MinimumWidth = 6;
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            this.Weight.Width = 125;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAverageWeight);
            this.Controls.Add(this.lbltotalCaloriesGained);
            this.Controls.Add(this.lbltotalCaloriesBurnt);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.datePickerEndDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datePickerStartDate);
            this.Controls.Add(this.label3);
            this.Name = "ReportForm";
            this.Size = new System.Drawing.Size(1096, 631);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePickerStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datePickerEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lbltotalCaloriesBurnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Workouts;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheatMeals;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaloriesBurned;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaloriesGained;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.Label lbltotalCaloriesGained;
        private System.Windows.Forms.Label lblAverageWeight;
    }
}
