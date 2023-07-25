namespace FitnessTrackerClientApp.View
{
    partial class WorkoutForm
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.WorkOutName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intensity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaloriesBurnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWeight = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.datePickerWeightEntryDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddEntry = new System.Windows.Forms.Button();
            this.cmbIntensity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWorkOutName = new System.Windows.Forms.Label();
            this.txtWorkoutName = new System.Windows.Forms.TextBox();
            this.txtColoriesBurnt = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColoriesBurnt)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(880, 293);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(162, 34);
            this.btnDelete.TabIndex = 51;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.btnUpdate.BackColor = System.Drawing.Color.Green;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(880, 233);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(162, 34);
            this.btnUpdate.TabIndex = 50;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "Edit";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(880, 136);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(162, 34);
            this.btnClear.TabIndex = 49;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkOutName,
            this.Intensity,
            this.CaloriesBurnt,
            this.weight,
            this.Date,
            this.GUID});
            this.dataGridView.Location = new System.Drawing.Point(86, 233);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(717, 363);
            this.dataGridView.TabIndex = 48;
            // 
            // WorkOutName
            // 
            this.WorkOutName.HeaderText = "Workout Name";
            this.WorkOutName.MinimumWidth = 6;
            this.WorkOutName.Name = "WorkOutName";
            this.WorkOutName.ReadOnly = true;
            this.WorkOutName.Width = 125;
            // 
            // Intensity
            // 
            this.Intensity.HeaderText = "Intensity";
            this.Intensity.MinimumWidth = 6;
            this.Intensity.Name = "Intensity";
            this.Intensity.ReadOnly = true;
            this.Intensity.Width = 125;
            // 
            // CaloriesBurnt
            // 
            this.CaloriesBurnt.HeaderText = "Calories Burnt";
            this.CaloriesBurnt.MinimumWidth = 6;
            this.CaloriesBurnt.Name = "CaloriesBurnt";
            this.CaloriesBurnt.ReadOnly = true;
            this.CaloriesBurnt.Width = 125;
            // 
            // weight
            // 
            this.weight.HeaderText = "Weight (KG)";
            this.weight.MinimumWidth = 6;
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            this.weight.Width = 125;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date Time";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 200;
            // 
            // GUID
            // 
            this.GUID.HeaderText = "GUID";
            this.GUID.MinimumWidth = 6;
            this.GUID.Name = "GUID";
            this.GUID.ReadOnly = true;
            this.GUID.Visible = false;
            this.GUID.Width = 125;
            // 
            // txtWeight
            // 
            this.txtWeight.DecimalPlaces = 2;
            this.txtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Location = new System.Drawing.Point(770, 19);
            this.txtWeight.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(272, 30);
            this.txtWeight.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(515, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(248, 23);
            this.label6.TabIndex = 46;
            this.label6.Text = "Weight(KG) After Workout:";
            // 
            // datePickerWeightEntryDate
            // 
            this.datePickerWeightEntryDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.datePickerWeightEntryDate.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.datePickerWeightEntryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerWeightEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerWeightEntryDate.Location = new System.Drawing.Point(770, 68);
            this.datePickerWeightEntryDate.Name = "datePickerWeightEntryDate";
            this.datePickerWeightEntryDate.Size = new System.Drawing.Size(272, 30);
            this.datePickerWeightEntryDate.TabIndex = 45;
            this.datePickerWeightEntryDate.Value = new System.DateTime(2023, 7, 11, 3, 19, 57, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(625, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 23);
            this.label3.TabIndex = 44;
            this.label3.Text = "Date and Time:";
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.BackColor = System.Drawing.Color.Blue;
            this.btnAddEntry.FlatAppearance.BorderSize = 0;
            this.btnAddEntry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddEntry.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEntry.ForeColor = System.Drawing.Color.White;
            this.btnAddEntry.Location = new System.Drawing.Point(672, 136);
            this.btnAddEntry.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(162, 34);
            this.btnAddEntry.TabIndex = 43;
            this.btnAddEntry.TabStop = false;
            this.btnAddEntry.Text = "Save";
            this.btnAddEntry.UseVisualStyleBackColor = false;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // cmbIntensity
            // 
            this.cmbIntensity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIntensity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIntensity.FormattingEnabled = true;
            this.cmbIntensity.Location = new System.Drawing.Point(201, 70);
            this.cmbIntensity.Name = "cmbIntensity";
            this.cmbIntensity.Size = new System.Drawing.Size(272, 33);
            this.cmbIntensity.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(101, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 23);
            this.label1.TabIndex = 55;
            this.label1.Text = "Intensity:";
            // 
            // lblWorkOutName
            // 
            this.lblWorkOutName.AutoSize = true;
            this.lblWorkOutName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkOutName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWorkOutName.Location = new System.Drawing.Point(36, 22);
            this.lblWorkOutName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWorkOutName.Name = "lblWorkOutName";
            this.lblWorkOutName.Size = new System.Drawing.Size(147, 23);
            this.lblWorkOutName.TabIndex = 54;
            this.lblWorkOutName.Text = "Workout Name:";
            // 
            // txtWorkoutName
            // 
            this.txtWorkoutName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkoutName.Location = new System.Drawing.Point(201, 18);
            this.txtWorkoutName.Margin = new System.Windows.Forms.Padding(4);
            this.txtWorkoutName.Name = "txtWorkoutName";
            this.txtWorkoutName.Size = new System.Drawing.Size(272, 30);
            this.txtWorkoutName.TabIndex = 53;
            // 
            // txtColoriesBurnt
            // 
            this.txtColoriesBurnt.DecimalPlaces = 2;
            this.txtColoriesBurnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColoriesBurnt.Location = new System.Drawing.Point(201, 133);
            this.txtColoriesBurnt.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtColoriesBurnt.Name = "txtColoriesBurnt";
            this.txtColoriesBurnt.Size = new System.Drawing.Size(272, 30);
            this.txtColoriesBurnt.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(44, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 23);
            this.label2.TabIndex = 57;
            this.label2.Text = "Calories Burnt :";
            // 
            // WorkoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtColoriesBurnt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbIntensity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblWorkOutName);
            this.Controls.Add(this.txtWorkoutName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.datePickerWeightEntryDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddEntry);
            this.Name = "WorkoutForm";
            this.Size = new System.Drawing.Size(1096, 631);
            this.Load += new System.EventHandler(this.WorkoutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColoriesBurnt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.NumericUpDown txtWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker datePickerWeightEntryDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddEntry;
        private System.Windows.Forms.ComboBox cmbIntensity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWorkOutName;
        private System.Windows.Forms.TextBox txtWorkoutName;
        private System.Windows.Forms.NumericUpDown txtColoriesBurnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkOutName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Intensity;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaloriesBurnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn GUID;
    }
}
