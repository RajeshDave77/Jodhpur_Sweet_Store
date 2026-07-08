namespace EdgePackaging
{
    partial class frmPayment1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment1));
            this.label35 = new System.Windows.Forms.Label();
            this.txtbillno = new System.Windows.Forms.TextBox();
            this.dtinvoice = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbparty = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbseries = new System.Windows.Forms.ComboBox();
            this.txtRecAmt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.cmAll = new System.Windows.Forms.ComboBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnExcel = new DevComponents.DotNetBar.ButtonX();
            this.dgvSearchGrid = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtGridTotal = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.cmbPartySearch = new System.Windows.Forms.ComboBox();
            this.txtinvsearch = new System.Windows.Forms.TextBox();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.chkdate = new System.Windows.Forms.CheckBox();
            this.btnsearch = new DevComponents.DotNetBar.ButtonX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.dttodate = new System.Windows.Forms.DateTimePicker();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.dtfromdate = new System.Windows.Forms.DateTimePicker();
            this.btnclosedgv = new System.Windows.Forms.Button();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.chkSMS = new System.Windows.Forms.CheckBox();
            this.optPayment = new System.Windows.Forms.RadioButton();
            this.optReceipt = new System.Windows.Forms.RadioButton();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.btnOpen = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSave_Print = new DevComponents.DotNetBar.ButtonX();
            this.lblBal = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProductPlus = new System.Windows.Forms.Button();
            this.groupPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label35.Location = new System.Drawing.Point(12, 9);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(193, 25);
            this.label35.TabIndex = 96;
            this.label35.Text = "Petty Cash Detail";
            // 
            // txtbillno
            // 
            this.txtbillno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbillno.Enabled = false;
            this.txtbillno.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbillno.Location = new System.Drawing.Point(123, 113);
            this.txtbillno.Name = "txtbillno";
            this.txtbillno.Size = new System.Drawing.Size(103, 25);
            this.txtbillno.TabIndex = 100;
            // 
            // dtinvoice
            // 
            this.dtinvoice.CustomFormat = "dd/MM/yyyy";
            this.dtinvoice.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtinvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtinvoice.Location = new System.Drawing.Point(292, 113);
            this.dtinvoice.Name = "dtinvoice";
            this.dtinvoice.Size = new System.Drawing.Size(138, 25);
            this.dtinvoice.TabIndex = 0;
            this.dtinvoice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtinvoice_KeyPress);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(289, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 19);
            this.label12.TabIndex = 99;
            this.label12.Text = "Date";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(119, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 17);
            this.label14.TabIndex = 98;
            this.label14.Text = "Voucher No.";
            // 
            // cmbparty
            // 
            this.cmbparty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbparty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbparty.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbparty.FormattingEnabled = true;
            this.cmbparty.Location = new System.Drawing.Point(123, 173);
            this.cmbparty.Name = "cmbparty";
            this.cmbparty.Size = new System.Drawing.Size(307, 25);
            this.cmbparty.TabIndex = 2;
            this.cmbparty.TextChanged += new System.EventHandler(this.cmbparty_TextChanged);
            this.cmbparty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbparty_KeyDown);
            this.cmbparty.Validating += new System.ComponentModel.CancelEventHandler(this.cmbparty_Validating);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(121, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 18);
            this.label11.TabIndex = 102;
            this.label11.Text = "Supplier *";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(477, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 22);
            this.label8.TabIndex = 104;
            this.label8.Text = "Pay Mode *";
            // 
            // cmbseries
            // 
            this.cmbseries.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbseries.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbseries.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbseries.FormattingEnabled = true;
            this.cmbseries.Location = new System.Drawing.Point(480, 112);
            this.cmbseries.Name = "cmbseries";
            this.cmbseries.Size = new System.Drawing.Size(167, 25);
            this.cmbseries.TabIndex = 1;
            this.cmbseries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbseries_KeyDown);
            this.cmbseries.Validating += new System.ComponentModel.CancelEventHandler(this.cmbseries_Validating);
            // 
            // txtRecAmt
            // 
            this.txtRecAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecAmt.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecAmt.Location = new System.Drawing.Point(122, 236);
            this.txtRecAmt.MaxLength = 20;
            this.txtRecAmt.Name = "txtRecAmt";
            this.txtRecAmt.Size = new System.Drawing.Size(115, 25);
            this.txtRecAmt.TabIndex = 3;
            this.txtRecAmt.TextChanged += new System.EventHandler(this.txtRecAmt_TextChanged);
            this.txtRecAmt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRecAmt_KeyDown);
            this.txtRecAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRecAmt_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(119, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 120;
            this.label4.Text = "Amount *";
            // 
            // txtNarration
            // 
            this.txtNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNarration.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(251, 236);
            this.txtNarration.MaxLength = 300;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(396, 25);
            this.txtNarration.TabIndex = 4;
            this.txtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNarration_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(248, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 17);
            this.label9.TabIndex = 129;
            this.label9.Text = "Narration";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.ForeColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 1);
            this.panel1.TabIndex = 136;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.ButtonFace;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.button1);
            this.groupPanel3.Controls.Add(this.cmAll);
            this.groupPanel3.Controls.Add(this.labelX1);
            this.groupPanel3.Controls.Add(this.btnExcel);
            this.groupPanel3.Controls.Add(this.dgvSearchGrid);
            this.groupPanel3.Controls.Add(this.txtGridTotal);
            this.groupPanel3.Controls.Add(this.label33);
            this.groupPanel3.Controls.Add(this.cmbPartySearch);
            this.groupPanel3.Controls.Add(this.txtinvsearch);
            this.groupPanel3.Controls.Add(this.labelX15);
            this.groupPanel3.Controls.Add(this.chkdate);
            this.groupPanel3.Controls.Add(this.btnsearch);
            this.groupPanel3.Controls.Add(this.labelX14);
            this.groupPanel3.Controls.Add(this.dttodate);
            this.groupPanel3.Controls.Add(this.labelX13);
            this.groupPanel3.Controls.Add(this.dtfromdate);
            this.groupPanel3.Controls.Add(this.btnclosedgv);
            this.groupPanel3.Controls.Add(this.labelX5);
            this.groupPanel3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel3.Location = new System.Drawing.Point(12, 9);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(769, 361);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel3.TabIndex = 140;
            this.groupPanel3.Text = "Petty Cash Detail";
            this.groupPanel3.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(175, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 28);
            this.button1.TabIndex = 147;
            this.button1.Text = "View Summary";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmAll
            // 
            this.cmAll.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmAll.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmAll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmAll.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmAll.FormattingEnabled = true;
            this.cmAll.Items.AddRange(new object[] {
            "All",
            "Receipt",
            "Payment"});
            this.cmAll.Location = new System.Drawing.Point(607, -6);
            this.cmAll.Name = "cmAll";
            this.cmAll.Size = new System.Drawing.Size(114, 25);
            this.cmAll.TabIndex = 146;
            this.cmAll.Visible = false;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(572, -6);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(33, 17);
            this.labelX1.TabIndex = 145;
            this.labelX1.Text = "Type";
            this.labelX1.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExcel.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnExcel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnExcel.Location = new System.Drawing.Point(13, 296);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(138, 29);
            this.btnExcel.TabIndex = 144;
            this.btnExcel.Text = "Export in Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // dgvSearchGrid
            // 
            this.dgvSearchGrid.AllowUserToAddRows = false;
            this.dgvSearchGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSearchGrid.ColumnHeadersHeight = 30;
            this.dgvSearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.dataGridViewImageColumn1,
            this.dataGridViewImageColumn2,
            this.Column7});
            this.dgvSearchGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvSearchGrid.EnableHeadersVisualStyles = false;
            this.dgvSearchGrid.Location = new System.Drawing.Point(3, 57);
            this.dgvSearchGrid.Name = "dgvSearchGrid";
            this.dgvSearchGrid.RowHeadersWidth = 52;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSearchGrid.Size = new System.Drawing.Size(757, 232);
            this.dgvSearchGrid.TabIndex = 143;
            this.dgvSearchGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchGrid_CellClick);
            // 
            // Select
            // 
            this.Select.FalseValue = "false";
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.TrueValue = "true";
            this.Select.Visible = false;
            this.Select.Width = 45;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Edit";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 45;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Delete";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Print";
            this.Column7.Image = ((System.Drawing.Image)(resources.GetObject("Column7.Image")));
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column7.Width = 50;
            // 
            // txtGridTotal
            // 
            this.txtGridTotal.Enabled = false;
            this.txtGridTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGridTotal.ForeColor = System.Drawing.Color.Black;
            this.txtGridTotal.Location = new System.Drawing.Point(468, 295);
            this.txtGridTotal.Name = "txtGridTotal";
            this.txtGridTotal.Size = new System.Drawing.Size(166, 26);
            this.txtGridTotal.TabIndex = 142;
            this.txtGridTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(410, 301);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(43, 16);
            this.label33.TabIndex = 141;
            this.label33.Text = "Total:";
            // 
            // cmbPartySearch
            // 
            this.cmbPartySearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPartySearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPartySearch.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPartySearch.FormattingEnabled = true;
            this.cmbPartySearch.Location = new System.Drawing.Point(343, 25);
            this.cmbPartySearch.Name = "cmbPartySearch";
            this.cmbPartySearch.Size = new System.Drawing.Size(233, 25);
            this.cmbPartySearch.TabIndex = 139;
            this.cmbPartySearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPartySearch_KeyDown);
            this.cmbPartySearch.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPartySearch_Validating);
            // 
            // txtinvsearch
            // 
            this.txtinvsearch.Location = new System.Drawing.Point(246, 26);
            this.txtinvsearch.MinimumSize = new System.Drawing.Size(4, 25);
            this.txtinvsearch.Name = "txtinvsearch";
            this.txtinvsearch.Size = new System.Drawing.Size(91, 23);
            this.txtinvsearch.TabIndex = 138;
            this.txtinvsearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtinvsearch_KeyPress);
            // 
            // labelX15
            // 
            this.labelX15.AutoSize = true;
            this.labelX15.BackColor = System.Drawing.Color.Transparent;
            this.labelX15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX15.Location = new System.Drawing.Point(246, 3);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(75, 17);
            this.labelX15.TabIndex = 137;
            this.labelX15.Text = "Voucher No";
            // 
            // chkdate
            // 
            this.chkdate.AutoSize = true;
            this.chkdate.Location = new System.Drawing.Point(146, -6);
            this.chkdate.Name = "chkdate";
            this.chkdate.Size = new System.Drawing.Size(15, 14);
            this.chkdate.TabIndex = 136;
            this.chkdate.UseVisualStyleBackColor = true;
            this.chkdate.Visible = false;
            this.chkdate.Click += new System.EventHandler(this.chkdate_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnsearch.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnsearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnsearch.Location = new System.Drawing.Point(643, 23);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(78, 25);
            this.btnsearch.TabIndex = 135;
            this.btnsearch.Text = "Search";
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // labelX14
            // 
            this.labelX14.BackColor = System.Drawing.Color.Transparent;
            this.labelX14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX14.Location = new System.Drawing.Point(129, -1);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(89, 23);
            this.labelX14.TabIndex = 134;
            this.labelX14.Text = "To Date";
            // 
            // dttodate
            // 
            this.dttodate.CalendarFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dttodate.CustomFormat = "dd/MM/yyyy";
            this.dttodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttodate.Location = new System.Drawing.Point(129, 26);
            this.dttodate.MinimumSize = new System.Drawing.Size(4, 25);
            this.dttodate.Name = "dttodate";
            this.dttodate.Size = new System.Drawing.Size(110, 25);
            this.dttodate.TabIndex = 133;
            this.dttodate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dttodate_KeyPress);
            // 
            // labelX13
            // 
            this.labelX13.AutoSize = true;
            this.labelX13.BackColor = System.Drawing.Color.Transparent;
            this.labelX13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX13.Location = new System.Drawing.Point(3, 2);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(67, 17);
            this.labelX13.TabIndex = 132;
            this.labelX13.Text = "From Date";
            // 
            // dtfromdate
            // 
            this.dtfromdate.CalendarFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtfromdate.CalendarForeColor = System.Drawing.Color.Silver;
            this.dtfromdate.CalendarMonthBackground = System.Drawing.Color.Maroon;
            this.dtfromdate.CustomFormat = "dd/MM/yyyy";
            this.dtfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfromdate.Location = new System.Drawing.Point(3, 26);
            this.dtfromdate.MinimumSize = new System.Drawing.Size(4, 25);
            this.dtfromdate.Name = "dtfromdate";
            this.dtfromdate.Size = new System.Drawing.Size(118, 25);
            this.dtfromdate.TabIndex = 131;
            this.dtfromdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtfromdate_KeyPress);
            // 
            // btnclosedgv
            // 
            this.btnclosedgv.BackgroundImage = global::EdgePackaging.Properties.Resources.close_delete_32;
            this.btnclosedgv.Location = new System.Drawing.Point(727, 2);
            this.btnclosedgv.Name = "btnclosedgv";
            this.btnclosedgv.Size = new System.Drawing.Size(33, 34);
            this.btnclosedgv.TabIndex = 128;
            this.btnclosedgv.UseVisualStyleBackColor = true;
            this.btnclosedgv.Click += new System.EventHandler(this.btnclosedgv_Click);
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            this.labelX5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(343, 3);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(119, 17);
            this.labelX5.TabIndex = 126;
            this.labelX5.Text = "Supplier/Expenses";
            // 
            // chkSMS
            // 
            this.chkSMS.AutoSize = true;
            this.chkSMS.BackColor = System.Drawing.Color.Transparent;
            this.chkSMS.Checked = true;
            this.chkSMS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSMS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSMS.Location = new System.Drawing.Point(206, 9);
            this.chkSMS.Name = "chkSMS";
            this.chkSMS.Size = new System.Drawing.Size(90, 20);
            this.chkSMS.TabIndex = 141;
            this.chkSMS.Text = "Send SMS";
            this.chkSMS.UseVisualStyleBackColor = false;
            this.chkSMS.Visible = false;
            // 
            // optPayment
            // 
            this.optPayment.AutoSize = true;
            this.optPayment.Checked = true;
            this.optPayment.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPayment.Location = new System.Drawing.Point(366, 44);
            this.optPayment.Name = "optPayment";
            this.optPayment.Size = new System.Drawing.Size(127, 22);
            this.optPayment.TabIndex = 148;
            this.optPayment.TabStop = true;
            this.optPayment.Text = "Payment Entry";
            this.optPayment.UseVisualStyleBackColor = true;
            this.optPayment.Visible = false;
            // 
            // optReceipt
            // 
            this.optReceipt.AutoSize = true;
            this.optReceipt.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optReceipt.Location = new System.Drawing.Point(214, 44);
            this.optReceipt.Name = "optReceipt";
            this.optReceipt.Size = new System.Drawing.Size(122, 22);
            this.optReceipt.TabIndex = 147;
            this.optReceipt.Text = "Receipt Entry";
            this.optReceipt.UseVisualStyleBackColor = true;
            this.optReceipt.Visible = false;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "Print";
            this.dataGridViewImageColumn3.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn3.Image")));
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn3.Visible = false;
            this.dataGridViewImageColumn3.Width = 50;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnSave.Location = new System.Drawing.Point(195, 310);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 48);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save && &Print";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnReset.Location = new System.Drawing.Point(485, 309);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(108, 48);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "&Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOpen.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnOpen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOpen.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnOpen.Location = new System.Drawing.Point(370, 309);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(102, 48);
            this.btnOpen.TabIndex = 7;
            this.btnOpen.Text = "&View";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnClose.Location = new System.Drawing.Point(616, 309);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 48);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave_Print
            // 
            this.btnSave_Print.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave_Print.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave_Print.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave_Print.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave_Print.Image = ((System.Drawing.Image)(resources.GetObject("btnSave_Print.Image")));
            this.btnSave_Print.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnSave_Print.Location = new System.Drawing.Point(62, 310);
            this.btnSave_Print.Name = "btnSave_Print";
            this.btnSave_Print.Size = new System.Drawing.Size(117, 48);
            this.btnSave_Print.TabIndex = 5;
            this.btnSave_Print.Text = "&Save";
            this.btnSave_Print.Click += new System.EventHandler(this.btnSave_Print_Click);
            // 
            // lblBal
            // 
            this.lblBal.AutoSize = true;
            this.lblBal.BackColor = System.Drawing.Color.Transparent;
            this.lblBal.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBal.ForeColor = System.Drawing.Color.Red;
            this.lblBal.Location = new System.Drawing.Point(221, 154);
            this.lblBal.Name = "lblBal";
            this.lblBal.Size = new System.Drawing.Size(0, 16);
            this.lblBal.TabIndex = 149;
            // 
            // txtMobile
            // 
            this.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobile.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile.Location = new System.Drawing.Point(480, 174);
            this.txtMobile.MaxLength = 20;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(167, 25);
            this.txtMobile.TabIndex = 150;
            this.txtMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobile_KeyDown);
            this.txtMobile.Validating += new System.ComponentModel.CancelEventHandler(this.txtMobile_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(477, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 151;
            this.label1.Text = "Mobile";
            // 
            // btnProductPlus
            // 
            this.btnProductPlus.BackColor = System.Drawing.Color.DeepPink;
            this.btnProductPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductPlus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductPlus.ForeColor = System.Drawing.Color.White;
            this.btnProductPlus.Location = new System.Drawing.Point(394, 143);
            this.btnProductPlus.Name = "btnProductPlus";
            this.btnProductPlus.Size = new System.Drawing.Size(36, 27);
            this.btnProductPlus.TabIndex = 187;
            this.btnProductPlus.Text = "+";
            this.btnProductPlus.UseVisualStyleBackColor = false;
            this.btnProductPlus.Visible = false;
            this.btnProductPlus.Click += new System.EventHandler(this.btnProductPlus_Click);
            // 
            // frmPayment1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 374);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.btnProductPlus);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBal);
            this.Controls.Add(this.optPayment);
            this.Controls.Add(this.optReceipt);
            this.Controls.Add(this.chkSMS);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave_Print);
            this.Controls.Add(this.txtNarration);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRecAmt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbseries);
            this.Controls.Add(this.cmbparty);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtbillno);
            this.Controls.Add(this.dtinvoice);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label35);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmPayment1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Petty Cash Detail";
            this.Load += new System.EventHandler(this.frmPayment1_Load);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtbillno;
        private System.Windows.Forms.DateTimePicker dtinvoice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbparty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbseries;
        private System.Windows.Forms.TextBox txtRecAmt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnOpen;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnSave_Print;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.ComboBox cmbPartySearch;
        private System.Windows.Forms.TextBox txtinvsearch;
        private DevComponents.DotNetBar.LabelX labelX15;
        private System.Windows.Forms.CheckBox chkdate;
        private DevComponents.DotNetBar.ButtonX btnsearch;
        private DevComponents.DotNetBar.LabelX labelX14;
        private System.Windows.Forms.DateTimePicker dttodate;
        private DevComponents.DotNetBar.LabelX labelX13;
        private System.Windows.Forms.DateTimePicker dtfromdate;
        private System.Windows.Forms.Button btnclosedgv;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.TextBox txtGridTotal;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.DataGridView dgvSearchGrid;
        private DevComponents.DotNetBar.ButtonX btnExcel;
        private System.Windows.Forms.CheckBox chkSMS;
        private System.Windows.Forms.RadioButton optPayment;
        private System.Windows.Forms.RadioButton optReceipt;
        private System.Windows.Forms.ComboBox cmAll;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn Column7;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.Label lblBal;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProductPlus;
        private System.Windows.Forms.Button button1;
    }
}