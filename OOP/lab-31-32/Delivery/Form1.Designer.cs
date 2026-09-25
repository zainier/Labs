namespace Delivery
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
            components = new System.ComponentModel.Container();

            grpParcel = new GroupBox();
            lblWeight = new Label();
            numWeight = new NumericUpDown();
            lblLength = new Label();
            numLength = new NumericUpDown();
            lblWidth = new Label();
            numWidth = new NumericUpDown();
            lblHeight = new Label();
            numHeight = new NumericUpDown();
            lblFormula = new Label();

            grpMethod = new GroupBox();
            cmbDelivery = new ComboBox();

            btnCalculate = new Button();
            btnClear = new Button();

            grpResult = new GroupBox();
            lblActualCaption = new Label();
            lblActualValue = new Label();
            lblVolumeCaption = new Label();
            lblVolumeValue = new Label();
            lblChargeCaption = new Label();
            lblChargeValue = new Label();
            lblMethodCaption = new Label();
            lblMethodValue = new Label();
            pnlCost = new Panel();
            lblCostTitle = new Label();
            lblCostValue = new Label();

            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();

            grpParcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).BeginInit();
            grpMethod.SuspendLayout();
            grpResult.SuspendLayout();
            pnlCost.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();

            grpParcel.Controls.Add(lblWeight);
            grpParcel.Controls.Add(numWeight);
            grpParcel.Controls.Add(lblLength);
            grpParcel.Controls.Add(numLength);
            grpParcel.Controls.Add(lblWidth);
            grpParcel.Controls.Add(numWidth);
            grpParcel.Controls.Add(lblHeight);
            grpParcel.Controls.Add(numHeight);
            grpParcel.Controls.Add(lblFormula);
            grpParcel.Location = new Point(16, 16);
            grpParcel.Name = "grpParcel";
            grpParcel.Size = new Size(420, 250);
            grpParcel.TabIndex = 0;
            grpParcel.TabStop = false;
            grpParcel.Text = "Параметри посилки";

            lblWeight.AutoSize = true;
            lblWeight.Location = new Point(24, 44);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(60, 20);
            lblWeight.TabIndex = 0;
            lblWeight.Text = "Вага, кг";

            numWeight.DecimalPlaces = 2;
            numWeight.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numWeight.Location = new Point(180, 40);
            numWeight.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numWeight.Name = "numWeight";
            numWeight.Size = new Size(210, 27);
            numWeight.TabIndex = 1;

            lblLength.AutoSize = true;
            lblLength.Location = new Point(24, 84);
            lblLength.Name = "lblLength";
            lblLength.Size = new Size(90, 20);
            lblLength.TabIndex = 2;
            lblLength.Text = "Довжина, см";

            numLength.DecimalPlaces = 1;
            numLength.Location = new Point(180, 80);
            numLength.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numLength.Name = "numLength";
            numLength.Size = new Size(210, 27);
            numLength.TabIndex = 3;

            lblWidth.AutoSize = true;
            lblWidth.Location = new Point(24, 124);
            lblWidth.Name = "lblWidth";
            lblWidth.Size = new Size(80, 20);
            lblWidth.TabIndex = 4;
            lblWidth.Text = "Ширина, см";

            numWidth.DecimalPlaces = 1;
            numWidth.Location = new Point(180, 120);
            numWidth.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numWidth.Name = "numWidth";
            numWidth.Size = new Size(210, 27);
            numWidth.TabIndex = 5;

            lblHeight.AutoSize = true;
            lblHeight.Location = new Point(24, 164);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(75, 20);
            lblHeight.TabIndex = 6;
            lblHeight.Text = "Висота, см";

            numHeight.DecimalPlaces = 1;
            numHeight.Location = new Point(180, 160);
            numHeight.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numHeight.Name = "numHeight";
            numHeight.Size = new Size(210, 27);
            numHeight.TabIndex = 7;

            lblFormula.AutoSize = true;
            lblFormula.ForeColor = SystemColors.GrayText;
            lblFormula.Location = new Point(24, 210);
            lblFormula.Name = "lblFormula";
            lblFormula.Size = new Size(260, 20);
            lblFormula.TabIndex = 8;
            lblFormula.Text = "Об'ємна вага = (Д × Ш × В) / 4000";

            grpMethod.Controls.Add(cmbDelivery);
            grpMethod.Location = new Point(16, 278);
            grpMethod.Name = "grpMethod";
            grpMethod.Size = new Size(420, 90);
            grpMethod.TabIndex = 1;
            grpMethod.TabStop = false;
            grpMethod.Text = "Спосіб доставки";

            cmbDelivery.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDelivery.Location = new Point(24, 38);
            cmbDelivery.Name = "cmbDelivery";
            cmbDelivery.Size = new Size(366, 28);
            cmbDelivery.TabIndex = 0;

            btnCalculate.BackColor = Color.FromArgb(0, 120, 215);
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCalculate.ForeColor = Color.White;
            btnCalculate.Location = new Point(16, 384);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(200, 48);
            btnCalculate.TabIndex = 2;
            btnCalculate.Text = "Розрахувати";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += btnCalculate_Click;

            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10F);
            btnClear.Location = new Point(236, 384);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(200, 48);
            btnClear.TabIndex = 3;
            btnClear.Text = "Очистити";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;

            grpResult.Controls.Add(lblActualCaption);
            grpResult.Controls.Add(lblActualValue);
            grpResult.Controls.Add(lblVolumeCaption);
            grpResult.Controls.Add(lblVolumeValue);
            grpResult.Controls.Add(lblChargeCaption);
            grpResult.Controls.Add(lblChargeValue);
            grpResult.Controls.Add(lblMethodCaption);
            grpResult.Controls.Add(lblMethodValue);
            grpResult.Controls.Add(pnlCost);
            grpResult.Location = new Point(452, 16);
            grpResult.Name = "grpResult";
            grpResult.Size = new Size(440, 416);
            grpResult.TabIndex = 4;
            grpResult.TabStop = false;
            grpResult.Text = "Результат";

            lblActualCaption.AutoSize = true;
            lblActualCaption.Location = new Point(24, 48);
            lblActualCaption.Name = "lblActualCaption";
            lblActualCaption.Size = new Size(110, 20);
            lblActualCaption.TabIndex = 0;
            lblActualCaption.Text = "Фактична вага:";

            lblActualValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblActualValue.Location = new Point(230, 46);
            lblActualValue.Name = "lblActualValue";
            lblActualValue.Size = new Size(190, 24);
            lblActualValue.TabIndex = 1;
            lblActualValue.Text = "—";

            lblVolumeCaption.AutoSize = true;
            lblVolumeCaption.Location = new Point(24, 96);
            lblVolumeCaption.Name = "lblVolumeCaption";
            lblVolumeCaption.Size = new Size(100, 20);
            lblVolumeCaption.TabIndex = 2;
            lblVolumeCaption.Text = "Об'ємна вага:";

            lblVolumeValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVolumeValue.Location = new Point(230, 94);
            lblVolumeValue.Name = "lblVolumeValue";
            lblVolumeValue.Size = new Size(190, 24);
            lblVolumeValue.TabIndex = 3;
            lblVolumeValue.Text = "—";

            lblChargeCaption.AutoSize = true;
            lblChargeCaption.Location = new Point(24, 144);
            lblChargeCaption.Name = "lblChargeCaption";
            lblChargeCaption.Size = new Size(140, 20);
            lblChargeCaption.TabIndex = 4;
            lblChargeCaption.Text = "Розрахункова вага:";

            lblChargeValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblChargeValue.Location = new Point(230, 142);
            lblChargeValue.Name = "lblChargeValue";
            lblChargeValue.Size = new Size(190, 24);
            lblChargeValue.TabIndex = 5;
            lblChargeValue.Text = "—";

            lblMethodCaption.AutoSize = true;
            lblMethodCaption.Location = new Point(24, 192);
            lblMethodCaption.Name = "lblMethodCaption";
            lblMethodCaption.Size = new Size(120, 20);
            lblMethodCaption.TabIndex = 6;
            lblMethodCaption.Text = "Спосіб доставки:";

            lblMethodValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMethodValue.Location = new Point(180, 190);
            lblMethodValue.Name = "lblMethodValue";
            lblMethodValue.Size = new Size(240, 48);
            lblMethodValue.TabIndex = 7;
            lblMethodValue.Text = "—";

            pnlCost.BackColor = Color.FromArgb(235, 244, 253);
            pnlCost.BorderStyle = BorderStyle.FixedSingle;
            pnlCost.Controls.Add(lblCostTitle);
            pnlCost.Controls.Add(lblCostValue);
            pnlCost.Location = new Point(24, 256);
            pnlCost.Name = "pnlCost";
            pnlCost.Size = new Size(396, 140);
            pnlCost.TabIndex = 8;

            lblCostTitle.Dock = DockStyle.Top;
            lblCostTitle.Font = new Font("Segoe UI", 14F);
            lblCostTitle.ForeColor = Color.FromArgb(0, 120, 215);
            lblCostTitle.Location = new Point(0, 0);
            lblCostTitle.Name = "lblCostTitle";
            lblCostTitle.Size = new Size(394, 44);
            lblCostTitle.TabIndex = 0;
            lblCostTitle.Text = "Вартість доставки";
            lblCostTitle.TextAlign = ContentAlignment.MiddleCenter;

            lblCostValue.Dock = DockStyle.Fill;
            lblCostValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblCostValue.ForeColor = Color.FromArgb(0, 120, 215);
            lblCostValue.Location = new Point(0, 44);
            lblCostValue.Name = "lblCostValue";
            lblCostValue.Size = new Size(394, 94);
            lblCostValue.TabIndex = 1;
            lblCostValue.Text = "—";
            lblCostValue.TextAlign = ContentAlignment.MiddleCenter;

            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip.Location = new Point(0, 448);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(908, 26);
            statusStrip.TabIndex = 5;

            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(160, 20);
            lblStatus.Text = "Готово до розрахунку";

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(908, 474);
            Controls.Add(grpParcel);
            Controls.Add(grpMethod);
            Controls.Add(btnCalculate);
            Controls.Add(btnClear);
            Controls.Add(grpResult);
            Controls.Add(statusStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Розрахунок вартості доставки";

            grpParcel.ResumeLayout(false);
            grpParcel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).EndInit();
            grpMethod.ResumeLayout(false);
            grpResult.ResumeLayout(false);
            grpResult.PerformLayout();
            pnlCost.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpParcel;
        private Label lblWeight;
        private NumericUpDown numWeight;
        private Label lblLength;
        private NumericUpDown numLength;
        private Label lblWidth;
        private NumericUpDown numWidth;
        private Label lblHeight;
        private NumericUpDown numHeight;
        private Label lblFormula;
        private GroupBox grpMethod;
        private ComboBox cmbDelivery;
        private Button btnCalculate;
        private Button btnClear;
        private GroupBox grpResult;
        private Label lblActualCaption;
        private Label lblActualValue;
        private Label lblVolumeCaption;
        private Label lblVolumeValue;
        private Label lblChargeCaption;
        private Label lblChargeValue;
        private Label lblMethodCaption;
        private Label lblMethodValue;
        private Panel pnlCost;
        private Label lblCostTitle;
        private Label lblCostValue;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
    }
}
