namespace PostService.App;

partial class PostingList
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
        DataGridViewCellStyle selectionStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle numberStyleWeight = new DataGridViewCellStyle();
        DataGridViewCellStyle numberStyleValue = new DataGridViewCellStyle();
        DataGridViewCellStyle numberStylePrice = new DataGridViewCellStyle();
        lblTitle = new Label();
        btnCreate = new Button();
        btnEdit = new Button();
        btnDelete = new Button();
        gridPostings = new DataGridView();
        colId = new DataGridViewTextBoxColumn();
        colFrom = new DataGridViewTextBoxColumn();
        colTo = new DataGridViewTextBoxColumn();
        colContent = new DataGridViewTextBoxColumn();
        colDeliveryType = new DataGridViewTextBoxColumn();
        colWeight = new DataGridViewTextBoxColumn();
        colValue = new DataGridViewTextBoxColumn();
        colPrice = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)gridPostings).BeginInit();
        SuspendLayout();
        //
        // lblTitle
        //
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.Location = new Point(20, 16);
        lblTitle.Name = "lblTitle";
        lblTitle.Text = "Список поштових відправлень";
        //
        // btnCreate
        //
        btnCreate.BackColor = Color.FromArgb(37, 99, 235);
        btnCreate.FlatAppearance.BorderSize = 0;
        btnCreate.FlatStyle = FlatStyle.Flat;
        btnCreate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCreate.ForeColor = Color.White;
        btnCreate.Location = new Point(20, 58);
        btnCreate.Name = "btnCreate";
        btnCreate.Size = new Size(190, 34);
        btnCreate.TabIndex = 0;
        btnCreate.Text = "+ Нове відправлення";
        btnCreate.UseVisualStyleBackColor = false;
        btnCreate.Click += btnCreate_Click;
        //
        // btnEdit
        //
        btnEdit.Location = new Point(220, 58);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(120, 34);
        btnEdit.TabIndex = 1;
        btnEdit.Text = "Редагувати";
        btnEdit.UseVisualStyleBackColor = true;
        btnEdit.Click += btnEdit_Click;
        //
        // btnDelete
        //
        btnDelete.BackColor = Color.FromArgb(220, 38, 38);
        btnDelete.FlatAppearance.BorderSize = 0;
        btnDelete.FlatStyle = FlatStyle.Flat;
        btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnDelete.ForeColor = Color.White;
        btnDelete.Location = new Point(350, 58);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(120, 34);
        btnDelete.TabIndex = 2;
        btnDelete.Text = "Видалити";
        btnDelete.UseVisualStyleBackColor = false;
        btnDelete.Click += btnDelete_Click;
        //
        // gridPostings
        //
        gridPostings.AllowUserToAddRows = false;
        gridPostings.AllowUserToDeleteRows = false;
        gridPostings.AllowUserToResizeRows = false;
        gridPostings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        gridPostings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        gridPostings.BackgroundColor = Color.White;
        gridPostings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridPostings.Columns.AddRange(new DataGridViewColumn[]
        {
            colId, colFrom, colTo, colContent, colDeliveryType, colWeight, colValue, colPrice
        });
        selectionStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
        selectionStyle.SelectionForeColor = Color.Black;
        gridPostings.DefaultCellStyle = selectionStyle;
        gridPostings.Location = new Point(20, 104);
        gridPostings.MultiSelect = false;
        gridPostings.Name = "gridPostings";
        gridPostings.ReadOnly = true;
        gridPostings.RowHeadersVisible = false;
        gridPostings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridPostings.Size = new Size(940, 436);
        gridPostings.TabIndex = 3;
        gridPostings.CellFormatting += gridPostings_CellFormatting;
        //
        // colId
        //
        colId.DataPropertyName = "Id";
        colId.HeaderText = "Id";
        colId.Name = "colId";
        colId.ReadOnly = true;
        colId.Visible = false;
        //
        // colFrom
        //
        colFrom.DataPropertyName = "From";
        colFrom.HeaderText = "Відправник";
        colFrom.Name = "colFrom";
        colFrom.ReadOnly = true;
        //
        // colTo
        //
        colTo.DataPropertyName = "To";
        colTo.HeaderText = "Отримувач";
        colTo.Name = "colTo";
        colTo.ReadOnly = true;
        //
        // colContent
        //
        colContent.DataPropertyName = "Content";
        colContent.HeaderText = "Вміст";
        colContent.Name = "colContent";
        colContent.ReadOnly = true;
        //
        // colDeliveryType
        //
        colDeliveryType.DataPropertyName = "DeliveryType";
        colDeliveryType.HeaderText = "Тип доставки";
        colDeliveryType.Name = "colDeliveryType";
        colDeliveryType.ReadOnly = true;
        //
        // colWeight
        //
        colWeight.DataPropertyName = "Weight";
        numberStyleWeight.Alignment = DataGridViewContentAlignment.MiddleRight;
        colWeight.DefaultCellStyle = numberStyleWeight;
        colWeight.HeaderText = "Вага, кг";
        colWeight.Name = "colWeight";
        colWeight.ReadOnly = true;
        //
        // colValue
        //
        colValue.DataPropertyName = "Value";
        numberStyleValue.Alignment = DataGridViewContentAlignment.MiddleRight;
        colValue.DefaultCellStyle = numberStyleValue;
        colValue.HeaderText = "Цінність";
        colValue.Name = "colValue";
        colValue.ReadOnly = true;
        //
        // colPrice
        //
        colPrice.DataPropertyName = "Price";
        numberStylePrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        colPrice.DefaultCellStyle = numberStylePrice;
        colPrice.HeaderText = "Вартість";
        colPrice.Name = "colPrice";
        colPrice.ReadOnly = true;
        //
        // PostingList
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(980, 560);
        Controls.Add(gridPostings);
        Controls.Add(btnDelete);
        Controls.Add(btnEdit);
        Controls.Add(btnCreate);
        Controls.Add(lblTitle);
        MinimumSize = new Size(700, 400);
        Name = "PostingList";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Облік поштових відправлень";
        Load += PostingList_Load;
        ((System.ComponentModel.ISupportInitialize)gridPostings).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitle;
    private Button btnCreate;
    private Button btnEdit;
    private Button btnDelete;
    private DataGridView gridPostings;
    private DataGridViewTextBoxColumn colId;
    private DataGridViewTextBoxColumn colFrom;
    private DataGridViewTextBoxColumn colTo;
    private DataGridViewTextBoxColumn colContent;
    private DataGridViewTextBoxColumn colDeliveryType;
    private DataGridViewTextBoxColumn colWeight;
    private DataGridViewTextBoxColumn colValue;
    private DataGridViewTextBoxColumn colPrice;
}
