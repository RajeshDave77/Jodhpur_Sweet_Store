namespace EdgePackaging
{
    partial class frmOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOP));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label35 = new System.Windows.Forms.Label();
            this.txtbillno = new System.Windows.Forms.TextBox();
            this.dtinvoice = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRecAmt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.btnOpen = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSave_Print = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnExcel = new DevComponents.DotNetBar.ButtonX();
            this.dgvSearchGrid = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtGridTotal = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.chkdate = new System.Windows.Forms.CheckBox();
            this.btnsearch = new DevComponents.DotNetBar.ButtonX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.dttodate = new System.Windows.Forms.DateTimePicker();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.dtfromdate = new System.Windows.Forms.DateTimePicker();
            this.btnclosedgv = new System.Windows.Forms.Button();
            this.txtAmt2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmt3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGridTotal1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGridTotal2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.label35.Location = new System.Drawing.Point(12, 2);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(177, 25);
            this.label35.TabIndex = 96;
            this.label35.Text = "Daily Sale Entry";
            // 
            // txtbillno
            // 
            this.txtbillno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbillno.Enabled = false;
            this.txtbillno.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbillno.Location = new System.Drawing.Point(58, 68);
            this.txtbillno.Name = "txtbillno";
            this.txtbillno.Size = new System.Drawing.Size(103, 25);
            this.txtbillno.TabIndex = 100;
            // 
            // dtinvoice
            // 
            this.dtinvoice.CustomFormat = "dd/MM/yyyy";
            this.dtinvoice.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtinvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtinvoice.Location = new System.Drawing.Point(186, 68);
            this.dtinvoice.Name = "dtinvoice";
            this.dtinvoice.Size = new System.Drawing.Size(138, 25);
            this.dtinvoice.TabIndex = 0;
            this.dtinvoice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtinvoice_KeyPress);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(183, 46);
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
            this.label14.Location = new System.Drawing.Point(54, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 17);
            this.label14.TabIndex = 98;
            this.label14.Text = "Entry No.";
            // 
            // txtRecAmt
            // 
            this.txtRecAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecAmt.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecAmt.Location = new System.Drawing.Point(58, 127);
            this.txtRecAmt.MaxLength = 20;
            this.txtRecAmt.Name = "txtRecAmt";
            this.txtRecAmt.Size = new System.Drawing.Size(117, 25);
            this.txtRecAmt.TabIndex = 1;
            this.txtRecAmt.TextChanged += new System.EventHandler(this.txtRecAmt_TextChanged);
            this.txtRecAmt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRecAmt_KeyDown);
            this.txtRecAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRecAmt_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(60, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 120;
            this.label4.Text = "Cash Amount";
            // 
            // txtNarration
            // 
            this.txtNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNarration.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(57, 190);
            this.txtNarration.MaxLength = 300;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(446, 25);
            this.txtNarration.TabIndex = 4;
            this.txtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNarration_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(55, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 17);
            this.label9.TabIndex = 129;
            this.label9.Text = "Narration";
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnReset.Location = new System.Drawing.Point(304, 244);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(108, 48);
            this.btnReset.TabIndex = 7;
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
            this.btnOpen.Location = new System.Drawing.Point(173, 244);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(102, 48);
            this.btnOpen.TabIndex = 6;
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
            this.btnClose.Location = new System.Drawing.Point(433, 244);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 48);
            this.btnClose.TabIndex = 8;
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
            this.btnSave_Print.Location = new System.Drawing.Point(32, 244);
            this.btnSave_Print.Name = "btnSave_Print";
            this.btnSave_Print.Size = new System.Drawing.Size(117, 48);
            this.btnSave_Print.TabIndex = 5;
            this.btnSave_Print.Text = "&Save";
            this.btnSave_Print.Click += new System.EventHandler(this.btnSave_Print_Click);
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
            this.groupPanel3.Controls.Add(this.txtGridTotal2);
            this.groupPanel3.Controls.Add(this.label5);
            this.groupPanel3.Controls.Add(this.txtGridTotal1);
            this.groupPanel3.Controls.Add(this.label3);
            this.groupPanel3.Controls.Add(this.btnExcel);
            this.groupPanel3.Controls.Add(this.dgvSearchGrid);
            this.groupPanel3.Controls.Add(this.txtGridTotal);
            this.groupPanel3.Controls.Add(this.label33);
            this.groupPanel3.Controls.Add(this.chkdate);
            this.groupPanel3.Controls.Add(this.btnsearch);
            this.groupPanel3.Controls.Add(this.labelX14);
            this.groupPanel3.Controls.Add(this.dttodate);
            this.groupPanel3.Controls.Add(this.labelX13);
            this.groupPanel3.Controls.Add(this.dtfromdate);
            this.groupPanel3.Controls.Add(this.btnclosedgv);
            this.groupPanel3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel3.Location = new System.Drawing.Point(12, 2);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(543, 370);
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
            this.groupPanel3.Text = "Daily Sale Entry Detail";
            this.groupPanel3.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExcel.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnExcel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnExcel.Location = new System.Drawing.Point(10, 265);
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
            this.dgvSearchGrid.Location = new System.Drawing.Point(5, 57);
            this.dgvSearchGrid.Name = "dgvSearchGrid";
            this.dgvSearchGrid.RowHeadersWidth = 52;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSearchGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSearchGrid.Size = new System.Drawing.Size(522, 202);
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
            this.Column7.Visible = false;
            this.Column7.Width = 50;
            // 
            // txtGridTotal
            // 
            this.txtGridTotal.BackColor = System.Drawing.Color.White;
            this.txtGridTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGridTotal.Enabled = false;
            this.txtGridTotal.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGridTotal.ForeColor = System.Drawing.Color.Black;
            this.txtGridTotal.Location = new System.Drawing.Point(269, 265);
            this.txtGridTotal.Name = "txtGridTotal";
            this.txtGridTotal.Size = new System.Drawing.Size(159, 25);
            this.txtGridTotal.TabIndex = 142;
            this.txtGridTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(178, 268);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(82, 16);
            this.label33.TabIndex = 141;
            this.label33.Text = "Total Cash :";
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
            this.btnsearch.Location = new System.Drawing.Point(269, 25);
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
            this.labelX14.Location = new System.Drawing.Point(136, -1);
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
            this.dttodate.Location = new System.Drawing.Point(136, 26);
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
            this.labelX13.Location = new System.Drawing.Point(10, 2);
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
            this.dtfromdate.Location = new System.Drawing.Point(10, 26);
            this.dtfromdate.MinimumSize = new System.Drawing.Size(4, 25);
            this.dtfromdate.Name = "dtfromdate";
            this.dtfromdate.Size = new System.Drawing.Size(118, 25);
            this.dtfromdate.TabIndex = 131;
            this.dtfromdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtfromdate_KeyPress);
            // 
            // btnclosedgv
            // 
            this.btnclosedgv.BackgroundImage = global::EdgePackaging.Properties.Resources.close_delete_32;
            this.btnclosedgv.Location = new System.Drawing.Point(494, -1);
            this.btnclosedgv.Name = "btnclosedgv";
            this.btnclosedgv.Size = new System.Drawing.Size(33, 34);
            this.btnclosedgv.TabIndex = 128;
            this.btnclosedgv.UseVisualStyleBackColor = true;
            this.btnclosedgv.Click += new System.EventHandler(this.btnclosedgv_Click);
            // 
            // txtAmt2
            // 
            this.txtAmt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmt2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmt2.Location = new System.Drawing.Point(186, 127);
            this.txtAmt2.MaxLength = 20;
            this.txtAmt2.Name = "txtAmt2";
            this.txtAmt2.Size = new System.Drawing.Size(117, 25);
            this.txtAmt2.TabIndex = 2;
            this.txtAmt2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmt2_KeyDown);
            this.txtAmt2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmt2_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 142;
            this.label1.Text = "COD Amount";
            // 
            // txtAmt3
            // 
            this.txtAmt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmt3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmt3.Location = new System.Drawing.Point(319, 127);
            this.txtAmt3.MaxLength = 20;
            this.txtAmt3.Name = "txtAmt3";
            this.txtAmt3.Size = new System.Drawing.Size(117, 25);
            this.txtAmt3.TabIndex = 3;
            this.txtAmt3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmt3_KeyDown);
            this.txtAmt3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmt3_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(321, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 144;
            this.label2.Text = "UPI Amount";
            // 
            // txtGridTotal1
            // 
            this.txtGridTotal1.BackColor = System.Drawing.Color.White;
            this.txtGridTotal1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGridTotal1.Enabled = false;
            this.txtGridTotal1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGridTotal1.ForeColor = System.Drawing.Color.Black;
            this.txtGridTotal1.Location = new System.Drawing.Point(269, 293);
            this.txtGridTotal1.Name = "txtGridTotal1";
            this.txtGridTotal1.Size = new System.Drawing.Size(159, 25);
            this.txtGridTotal1.TabIndex = 146;
            this.txtGridTotal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(178, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 145;
            this.label3.Text = "Total COD :";
            // 
            // txtGridTotal2
            // 
            this.txtGridTotal2.BackColor = System.Drawing.Color.White;
            this.txtGridTotal2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGridTotal2.Enabled = false;
            this.txtGridTotal2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGridTotal2.ForeColor = System.Drawing.Color.Black;
            this.txtGridTotal2.Location = new System.Drawing.Point(269, 321);
            this.txtGridTotal2.Name = "txtGridTotal2";
            this.txtGridTotal2.Size = new System.Drawing.Size(159, 25);
            this.txtGridTotal2.TabIndex = 148;
            this.txtGridTotal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(178, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 147;
            this.label5.Text = "Total UPI :";
            // 
            // frmOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 371);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.txtAmt3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAmt2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave_Print);
            this.Controls.Add(this.txtNarration);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRecAmt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbillno);
            this.Controls.Add(this.dtinvoice);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label35);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmOP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Sale Entry";
            this.Load += new System.EventHandler(this.frmOP_Load);
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
        private System.Windows.Forms.TextBox txtRecAmt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnOpen;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnSave_Print;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.CheckBox chkdate;
        private DevComponents.DotNetBar.ButtonX btnsearch;
        private DevComponents.DotNetBar.LabelX labelX14;
        private System.Windows.Forms.DateTimePicker dttodate;
        private DevComponents.DotNetBar.LabelX labelX13;
        private System.Windows.Forms.DateTimePicker dtfromdate;
        private System.Windows.Forms.Button btnclosedgv;
        private System.Windows.Forms.TextBox txtGridTotal;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.DataGridView dgvSearchGrid;
        private DevComponents.DotNetBar.ButtonX btnExcel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn Column7;
        private System.Windows.Forms.TextBox txtAmt2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmt3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGridTotal2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGridTotal1;
        private System.Windows.Forms.Label label3;
    }
}