namespace StudentsTable
{
    partial class RegisterStudentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            firstNameLabel = new Label();
            firstNameTextBox = new TextBox();
            lastNameLabel = new Label();
            lastNameTextBox = new TextBox();
            dateOfBirthLabel = new Label();
            dateOfBirthDateTimePicker = new DateTimePicker();
            buttonsPanel = new FlowLayoutPanel();
            cancelButton = new Button();
            saveButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(firstNameLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(firstNameTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(lastNameLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(lastNameTextBox, 1, 1);
            tableLayoutPanel1.Controls.Add(dateOfBirthLabel, 0, 2);
            tableLayoutPanel1.Controls.Add(dateOfBirthDateTimePicker, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.Size = new Size(476, 105);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Dock = DockStyle.Fill;
            firstNameLabel.Location = new Point(3, 0);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(134, 32);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "Ім'я";
            firstNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            firstNameTextBox.Location = new Point(143, 4);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(330, 23);
            firstNameTextBox.TabIndex = 1;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Dock = DockStyle.Fill;
            lastNameLabel.Location = new Point(3, 32);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(134, 32);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Прізвище";
            lastNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lastNameTextBox.Location = new Point(143, 36);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(330, 23);
            lastNameTextBox.TabIndex = 3;
            // 
            // dateOfBirthLabel
            // 
            dateOfBirthLabel.AutoSize = true;
            dateOfBirthLabel.Dock = DockStyle.Fill;
            dateOfBirthLabel.Location = new Point(3, 64);
            dateOfBirthLabel.Name = "dateOfBirthLabel";
            dateOfBirthLabel.Size = new Size(134, 32);
            dateOfBirthLabel.TabIndex = 4;
            dateOfBirthLabel.Text = "Дата народження";
            dateOfBirthLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateOfBirthDateTimePicker
            // 
            dateOfBirthDateTimePicker.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dateOfBirthDateTimePicker.CustomFormat = "dd.MM.yyyy";
            dateOfBirthDateTimePicker.Format = DateTimePickerFormat.Custom;
            dateOfBirthDateTimePicker.Location = new Point(143, 68);
            dateOfBirthDateTimePicker.Name = "dateOfBirthDateTimePicker";
            dateOfBirthDateTimePicker.Size = new Size(330, 23);
            dateOfBirthDateTimePicker.TabIndex = 5;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(cancelButton);
            buttonsPanel.Controls.Add(saveButton);
            buttonsPanel.Dock = DockStyle.Bottom;
            buttonsPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonsPanel.Location = new Point(12, 117);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(476, 34);
            buttonsPanel.TabIndex = 1;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(383, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(90, 27);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "&Скасувати";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(287, 3);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(90, 27);
            saveButton.TabIndex = 0;
            saveButton.Text = "&Зберегти";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // RegisterStudentForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(500, 163);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(buttonsPanel);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = false;
            MaximumSize = new Size(10000, 202);
            MinimizeBox = false;
            MinimumSize = new Size(460, 202);
            Name = "RegisterStudentForm";
            Padding = new Padding(12);
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Зареєструвати студента";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label firstNameLabel;
        private TextBox firstNameTextBox;
        private Label lastNameLabel;
        private TextBox lastNameTextBox;
        private Label dateOfBirthLabel;
        private DateTimePicker dateOfBirthDateTimePicker;
        private FlowLayoutPanel buttonsPanel;
        private Button saveButton;
        private Button cancelButton;
    }
}
