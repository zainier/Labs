namespace PostService.App;

partial class PostingEditForm
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
        lblHeading = new Label();
        errorProvider = new ErrorProvider(components);
        lblFrom = new Label();
        txtFrom = new TextBox();
        lblFromError = new Label();
        lblTo = new Label();
        txtTo = new TextBox();
        lblToError = new Label();
        lblContent = new Label();
        txtContent = new TextBox();
        lblContentError = new Label();
        lblDeliveryType = new Label();
        cmbDeliveryType = new ComboBox();
        lblDeliveryTypeError = new Label();
        lblWeight = new Label();
        txtWeight = new TextBox();
        lblWeightError = new Label();
        lblValue = new Label();
        txtValue = new TextBox();
        lblValueError = new Label();
        lblWidth = new Label();
        txtWidth = new TextBox();
        lblWidthError = new Label();
        lblHeight = new Label();
        txtHeight = new TextBox();
        lblHeightError = new Label();
        lblDepth = new Label();
        txtDepth = new TextBox();
        lblDepthError = new Label();
        lblPrice = new Label();
        txtPrice = new TextBox();
        lblPriceHint = new Label();
        btnSave = new Button();
        btnCancel = new Button();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();
        //
        // lblFrom
        //
        lblFrom.AutoSize = true;
        lblFrom.Location = new Point(20, 56);
        lblFrom.Name = "lblFrom";
        lblFrom.Text = "Відправник *";
        //
        // txtFrom
        //
        txtFrom.Location = new Point(20, 75);
        txtFrom.Name = "txtFrom";
        txtFrom.Size = new Size(340, 23);
        txtFrom.TabIndex = 4;
        //
        // lblFromError
        //
        lblFromError.ForeColor = Color.FromArgb(220, 38, 38);
        lblFromError.Location = new Point(388, 75);
        lblFromError.Name = "lblFromError";
        lblFromError.Size = new Size(360, 23);
        lblFromError.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lblTo
        //
        lblTo.AutoSize = true;
        lblTo.Location = new Point(20, 108);
        lblTo.Name = "lblTo";
        lblTo.Text = "Отримувач *";
        //
        // txtTo
        //
        txtTo.Location = new Point(20, 127);
        txtTo.Name = "txtTo";
        txtTo.Size = new Size(340, 23);
        txtTo.TabIndex = 5;
        //
        // lblToError
        //
        lblToError.ForeColor = Color.FromArgb(220, 38, 38);
        lblToError.Location = new Point(388, 127);
        lblToError.Name = "lblToError";
        lblToError.Size = new Size(360, 23);
        lblToError.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lblContent
        //
        lblContent.AutoSize = true;
        lblContent.Location = new Point(20, 160);
        lblContent.Name = "lblContent";
        lblContent.Text = "Вміст *";
        //
        // txtContent
        //
        txtContent.Location = new Point(20, 179);
        txtContent.Name = "txtContent";
        txtContent.Size = new Size(340, 23);
        txtContent.TabIndex = 6;
        //
        // lblContentError
        //
        lblContentError.ForeColor = Color.FromArgb(220, 38, 38);
        lblContentError.Location = new Point(388, 179);
        lblContentError.Name = "lblContentError";
        lblContentError.Size = new Size(360, 23);
        lblContentError.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lblDeliveryType
        //
        lblDeliveryType.AutoSize = true;
        lblDeliveryType.Location = new Point(20, 212);
        lblDeliveryType.Name = "lblDeliveryType";
        lblDeliveryType.Text = "Тип доставки *";
        //
        // cmbDeliveryType
        //
        cmbDeliveryType.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbDeliveryType.Location = new Point(20, 231);
        cmbDeliveryType.Name = "cmbDeliveryType";
        cmbDeliveryType.Size = new Size(340, 23);
        cmbDeliveryType.TabIndex = 7;
        //
        // lblDeliveryTypeError
        //
        lblDeliveryTypeError.ForeColor = Color.FromArgb(220, 38, 38);
        lblDeliveryTypeError.Location = new Point(388, 231);
        lblDeliveryTypeError.Name = "lblDeliveryTypeError";
        lblDeliveryTypeError.Size = new Size(360, 23);
        lblDeliveryTypeError.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lblWeight
        //
        lblWeight.AutoSize = true;
        lblWeight.Location = new Point(20, 264);
        lblWeight.Name = "lblWeight";
        lblWeight.Text = "Вага, кг *";
        //
        // txtWeight
        //
        txtWeight.Location = new Point(20, 283);
        txtWeight.Name = "txtWeight";
        txtWeight.Size = new Size(340, 23);
        txtWeight.TabIndex = 8;
        //
        // lblWeightError
        //
        lblWeightError.ForeColor = Color.FromArgb(220, 38, 38);
        lblWeightError.Location = new Point(388, 283);
        lblWeightError.Name = "lblWeightError";
        lblWeightError.Size = new Size(360, 23);
        lblWeightError.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lblValue
        //
        lblValue.AutoSize = true;
        lblValue.Location = new Point(20, 316);
        lblValue.Name = "lblValue";
        lblValue.Text = "Оголошена цінність, грн";
        //
        // txtValue
        //
        txtValue.Location = new Point(20, 335);
        txtValue.Name = "txtValue";
        txtValue.Size = new Size(340, 23);
        txtValue.TabIndex = 9;
        //
        // lblValueError
        //
        lblValueError.ForeColor = Color.FromArgb(220, 38, 38);
        lblValueError.Location = new Point(388, 335);
        lblValueError.Name = "lblValueError";
        lblValueError.Size = new Size(360, 23);
        lblValueError.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lblWidth
        //
        lblWidth.AutoSize = true;
        lblWidth.Location = new Point(20, 368);
        lblWidth.Name = "lblWidth";
        lblWidth.Text = "Ширина, см *";
        //
        // txtWidth
        //
        txtWidth.Location = new Point(20, 387);
        txtWidth.Name = "txtWidth";
        txtWidth.Size = new Size(340, 23);
        txtWidth.TabIndex = 10;
        //
        // lblWidthError
        //
        lblWidthError.ForeColor = Color.FromArgb(220, 38, 38);
        lblWidthError.Location = new Point(388, 387);
        lblWidthError.Name = "lblWidthError";
        lblWidthError.Size = new Size(360, 23);
        lblWidthError.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lblHeight
        //
        lblHeight.AutoSize = true;
        lblHeight.Location = new Point(20, 420);
        lblHeight.Name = "lblHeight";
        lblHeight.Text = "Висота, см *";
        //
        // txtHeight
        //
        txtHeight.Location = new Point(20, 439);
        txtHeight.Name = "txtHeight";
        txtHeight.Size = new Size(340, 23);
        txtHeight.TabIndex = 11;
        //
        // lblHeightError
        //
        lblHeightError.ForeColor = Color.FromArgb(220, 38, 38);
        lblHeightError.Location = new Point(388, 439);
        lblHeightError.Name = "lblHeightError";
        lblHeightError.Size = new Size(360, 23);
        lblHeightError.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lblDepth
        //
        lblDepth.AutoSize = true;
        lblDepth.Location = new Point(20, 472);
        lblDepth.Name = "lblDepth";
        lblDepth.Text = "Глибина, см *";
        //
        // txtDepth
        //
        txtDepth.Location = new Point(20, 491);
        txtDepth.Name = "txtDepth";
        txtDepth.Size = new Size(340, 23);
        txtDepth.TabIndex = 12;
        //
        // lblDepthError
        //
        lblDepthError.ForeColor = Color.FromArgb(220, 38, 38);
        lblDepthError.Location = new Point(388, 491);
        lblDepthError.Name = "lblDepthError";
        lblDepthError.Size = new Size(360, 23);
        lblDepthError.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lblPrice
        //
        lblPrice.AutoSize = true;
        lblPrice.Location = new Point(20, 524);
        lblPrice.Name = "lblPrice";
        lblPrice.Text = "Вартість, грн";
        //
        // txtPrice
        //
        txtPrice.ReadOnly = true;
        txtPrice.TabStop = false;
        txtPrice.Location = new Point(20, 543);
        txtPrice.Name = "txtPrice";
        txtPrice.Size = new Size(340, 23);
        //
        // lblPriceHint
        //
        lblPriceHint.AutoSize = true;
        lblPriceHint.ForeColor = Color.FromArgb(107, 114, 128);
        lblPriceHint.Location = new Point(20, 572);
        lblPriceHint.Name = "lblPriceHint";
        lblPriceHint.Text = "Вартість обчислюється автоматично за вагою і типом доставки.";
        //
        // btnSave
        //
        btnSave.BackColor = Color.FromArgb(37, 99, 235);
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(20, 604);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(110, 34);
        btnSave.TabIndex = 13;
        btnSave.Text = "Зберегти";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += btnSave_Click;
        //
        // btnCancel
        //
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(140, 604);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(110, 34);
        btnCancel.TabIndex = 14;
        btnCancel.Text = "Скасувати";
        btnCancel.UseVisualStyleBackColor = true;
        //
        // lblHeading
        //
        lblHeading.AutoSize = true;
        lblHeading.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblHeading.Location = new Point(20, 14);
        lblHeading.Name = "lblHeading";
        lblHeading.Text = "Нове відправлення";
        //
        // errorProvider
        //
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.ContainerControl = this;
        //
        // PostingEditForm
        //
        AcceptButton = btnSave;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        CancelButton = btnCancel;
        ClientSize = new Size(760, 656);
        Controls.Add(lblFrom);
        Controls.Add(txtFrom);
        Controls.Add(lblFromError);
        Controls.Add(lblTo);
        Controls.Add(txtTo);
        Controls.Add(lblToError);
        Controls.Add(lblContent);
        Controls.Add(txtContent);
        Controls.Add(lblContentError);
        Controls.Add(lblDeliveryType);
        Controls.Add(cmbDeliveryType);
        Controls.Add(lblDeliveryTypeError);
        Controls.Add(lblWeight);
        Controls.Add(txtWeight);
        Controls.Add(lblWeightError);
        Controls.Add(lblValue);
        Controls.Add(txtValue);
        Controls.Add(lblValueError);
        Controls.Add(lblWidth);
        Controls.Add(txtWidth);
        Controls.Add(lblWidthError);
        Controls.Add(lblHeight);
        Controls.Add(txtHeight);
        Controls.Add(lblHeightError);
        Controls.Add(lblDepth);
        Controls.Add(txtDepth);
        Controls.Add(lblDepthError);
        Controls.Add(lblPrice);
        Controls.Add(txtPrice);
        Controls.Add(lblPriceHint);
        Controls.Add(btnSave);
        Controls.Add(btnCancel);
        Controls.Add(lblHeading);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "PostingEditForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Нове відправлення";
        Load += PostingEditForm_Load;
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblHeading;
    private ErrorProvider errorProvider;
    private Label lblFrom;
    private TextBox txtFrom;
    private Label lblFromError;
    private Label lblTo;
    private TextBox txtTo;
    private Label lblToError;
    private Label lblContent;
    private TextBox txtContent;
    private Label lblContentError;
    private Label lblDeliveryType;
    private ComboBox cmbDeliveryType;
    private Label lblDeliveryTypeError;
    private Label lblWeight;
    private TextBox txtWeight;
    private Label lblWeightError;
    private Label lblValue;
    private TextBox txtValue;
    private Label lblValueError;
    private Label lblWidth;
    private TextBox txtWidth;
    private Label lblWidthError;
    private Label lblHeight;
    private TextBox txtHeight;
    private Label lblHeightError;
    private Label lblDepth;
    private TextBox txtDepth;
    private Label lblDepthError;
    private Label lblPrice;
    private TextBox txtPrice;
    private Label lblPriceHint;
    private Button btnSave;
    private Button btnCancel;
}
