namespace StudentsTable
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colFirstName = new DataGridViewTextBoxColumn();
            colLastName = new DataGridViewTextBoxColumn();
            colDateOfBirth = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            // Use per-column autosizing modes so individual columns can be fixed or fill
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(830, 450);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // define columns
            // Id column
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ІД";
            colId.Name = "colId";
            colId.Width = 80;
            colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colId.ReadOnly = true;
            // FirstName column
            colFirstName.DataPropertyName = "FirstName";
            colFirstName.HeaderText = "Ім'я";
            colFirstName.Name = "colFirstName";
            colFirstName.Width = 200;
            colFirstName.MinimumWidth = 200;
            colFirstName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colFirstName.ReadOnly = true;
            // LastName column (fills remaining space)
            colLastName.DataPropertyName = "LastName";
            colLastName.HeaderText = "Прізвище";
            colLastName.Name = "colLastName";
            colLastName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLastName.ReadOnly = true;
            // DateOfBirth column
            colDateOfBirth.DataPropertyName = "DateOfBirth";
            colDateOfBirth.HeaderText = "Дата народження";
            colDateOfBirth.Name = "colDateOfBirth";
            colDateOfBirth.Width = 150;
            colDateOfBirth.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colDateOfBirth.ReadOnly = true;
            colDateOfBirth.DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" };
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colId, colFirstName, colLastName, colDateOfBirth });
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 450);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colFirstName;
        private DataGridViewTextBoxColumn colLastName;
        private DataGridViewTextBoxColumn colDateOfBirth;
    }
}
