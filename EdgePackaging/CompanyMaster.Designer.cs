namespace EdgePackaging
{
    partial class frmCompanyMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompanyMaster));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlOperations = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnOpen = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.labelX61 = new DevComponents.DotNetBar.LabelX();
            this.txtGSTNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pnlBasicInformation = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtadd2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.txtAddress1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtadd3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pnlCompanyDetails = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.pnlCompanyDetailsClose = new DevComponents.DotNetBar.ButtonX();
            this.dgvCompanyDetails = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlOperations.SuspendLayout();
            this.pnlBasicInformation.SuspendLayout();
            this.pnlCompanyDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOperations
            // 
            this.pnlOperations.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlOperations.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlOperations.Controls.Add(this.btnOpen);
            this.pnlOperations.Controls.Add(this.btnClose);
            this.pnlOperations.Controls.Add(this.btnReset);
            this.pnlOperations.Controls.Add(this.btnSave);
            this.pnlOperations.Location = new System.Drawing.Point(12, 307);
            this.pnlOperations.Name = "pnlOperations";
            this.pnlOperations.Size = new System.Drawing.Size(816, 63);
            // 
            // 
            // 
            this.pnlOperations.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlOperations.Style.BackColorGradientAngle = 90;
            this.pnlOperations.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlOperations.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlOperations.Style.BorderBottomWidth = 1;
            this.pnlOperations.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlOperations.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlOperations.Style.BorderLeftWidth = 1;
            this.pnlOperations.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlOperations.Style.BorderRightWidth = 1;
            this.pnlOperations.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlOperations.Style.BorderTopWidth = 1;
            this.pnlOperations.Style.CornerDiameter = 4;
            this.pnlOperations.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlOperations.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.pnlOperations.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlOperations.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.pnlOperations.TabIndex = 28;
            // 
            // btnOpen
            // 
            this.btnOpen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOpen.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnOpen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOpen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Location = new System.Drawing.Point(220, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(143, 51);
            this.btnOpen.TabIndex = 7;
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(591, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(151, 51);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(407, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(140, 51);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(55, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 51);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelX61
            // 
            this.labelX61.BackColor = System.Drawing.Color.Transparent;
            this.labelX61.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX61.Location = new System.Drawing.Point(446, 20);
            this.labelX61.Name = "labelX61";
            this.labelX61.Size = new System.Drawing.Size(75, 16);
            this.labelX61.TabIndex = 19;
            this.labelX61.Text = "GST No.";
            // 
            // txtGSTNumber
            // 
            // 
            // 
            // 
            this.txtGSTNumber.Border.Class = "TextBoxBorder";
            this.txtGSTNumber.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGSTNumber.Location = new System.Drawing.Point(446, 40);
            this.txtGSTNumber.Name = "txtGSTNumber";
            this.txtGSTNumber.Size = new System.Drawing.Size(328, 25);
            this.txtGSTNumber.TabIndex = 1;
            this.txtGSTNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGSTNumber_KeyDown);
            // 
            // pnlBasicInformation
            // 
            this.pnlBasicInformation.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBasicInformation.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlBasicInformation.Controls.Add(this.labelX2);
            this.pnlBasicInformation.Controls.Add(this.txtadd2);
            this.pnlBasicInformation.Controls.Add(this.labelX3);
            this.pnlBasicInformation.Controls.Add(this.cmbState);
            this.pnlBasicInformation.Controls.Add(this.labelX61);
            this.pnlBasicInformation.Controls.Add(this.txtGSTNumber);
            this.pnlBasicInformation.Controls.Add(this.txtAddress1);
            this.pnlBasicInformation.Controls.Add(this.labelX5);
            this.pnlBasicInformation.Controls.Add(this.labelX8);
            this.pnlBasicInformation.Controls.Add(this.txtName);
            this.pnlBasicInformation.Controls.Add(this.labelX1);
            this.pnlBasicInformation.Controls.Add(this.txtadd3);
            this.pnlBasicInformation.Location = new System.Drawing.Point(18, 30);
            this.pnlBasicInformation.Name = "pnlBasicInformation";
            this.pnlBasicInformation.Size = new System.Drawing.Size(810, 267);
            // 
            // 
            // 
            this.pnlBasicInformation.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlBasicInformation.Style.BackColorGradientAngle = 90;
            this.pnlBasicInformation.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlBasicInformation.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlBasicInformation.Style.BorderBottomWidth = 1;
            this.pnlBasicInformation.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlBasicInformation.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlBasicInformation.Style.BorderLeftWidth = 1;
            this.pnlBasicInformation.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlBasicInformation.Style.BorderRightWidth = 1;
            this.pnlBasicInformation.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlBasicInformation.Style.BorderTopWidth = 1;
            this.pnlBasicInformation.Style.CornerDiameter = 4;
            this.pnlBasicInformation.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlBasicInformation.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.pnlBasicInformation.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlBasicInformation.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.pnlBasicInformation.TabIndex = 0;
            this.pnlBasicInformation.Text = "Company Detail";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(20, 150);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(128, 26);
            this.labelX2.TabIndex = 46;
            this.labelX2.Text = "Address3";
            // 
            // txtadd2
            // 
            // 
            // 
            // 
            this.txtadd2.Border.Class = "TextBoxBorder";
            this.txtadd2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtadd2.Location = new System.Drawing.Point(446, 105);
            this.txtadd2.Name = "txtadd2";
            this.txtadd2.Size = new System.Drawing.Size(328, 25);
            this.txtadd2.TabIndex = 3;
            this.txtadd2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtadd2_KeyDown);
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(446, 81);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(128, 24);
            this.labelX3.TabIndex = 44;
            this.labelX3.Text = "Address2";
            // 
            // cmbState
            // 
            this.cmbState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(446, 178);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(328, 25);
            this.cmbState.TabIndex = 5;
            this.cmbState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbState_KeyDown);
            // 
            // txtAddress1
            // 
            // 
            // 
            // 
            this.txtAddress1.Border.Class = "TextBoxBorder";
            this.txtAddress1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress1.Location = new System.Drawing.Point(20, 105);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(369, 25);
            this.txtAddress1.TabIndex = 2;
            this.txtAddress1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress1_KeyDown);
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            this.labelX5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(446, 150);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 22);
            this.labelX5.TabIndex = 29;
            this.labelX5.Text = "State";
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            this.labelX8.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX8.Location = new System.Drawing.Point(20, 84);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(128, 19);
            this.labelX8.TabIndex = 23;
            this.labelX8.Text = "Address1";
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(20, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(369, 25);
            this.txtName.TabIndex = 0;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(20, 20);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 16);
            this.labelX1.TabIndex = 11;
            this.labelX1.Text = "Name *";
            // 
            // txtadd3
            // 
            // 
            // 
            // 
            this.txtadd3.Border.Class = "TextBoxBorder";
            this.txtadd3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtadd3.Location = new System.Drawing.Point(20, 178);
            this.txtadd3.Name = "txtadd3";
            this.txtadd3.Size = new System.Drawing.Size(369, 25);
            this.txtadd3.TabIndex = 4;
            this.txtadd3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtadd3_KeyDown);
            // 
            // pnlCompanyDetails
            // 
            this.pnlCompanyDetails.CanvasColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlCompanyDetails.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlCompanyDetails.Controls.Add(this.txtNameSearch);
            this.pnlCompanyDetails.Controls.Add(this.buttonX1);
            this.pnlCompanyDetails.Controls.Add(this.btnDelete);
            this.pnlCompanyDetails.Controls.Add(this.labelX17);
            this.pnlCompanyDetails.Controls.Add(this.pnlCompanyDetailsClose);
            this.pnlCompanyDetails.Controls.Add(this.dgvCompanyDetails);
            this.pnlCompanyDetails.Location = new System.Drawing.Point(3, 391);
            this.pnlCompanyDetails.Name = "pnlCompanyDetails";
            this.pnlCompanyDetails.Size = new System.Drawing.Size(820, 368);
            // 
            // 
            // 
            this.pnlCompanyDetails.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlCompanyDetails.Style.BackColorGradientAngle = 90;
            this.pnlCompanyDetails.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlCompanyDetails.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlCompanyDetails.Style.BorderBottomWidth = 1;
            this.pnlCompanyDetails.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlCompanyDetails.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlCompanyDetails.Style.BorderLeftWidth = 1;
            this.pnlCompanyDetails.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlCompanyDetails.Style.BorderRightWidth = 1;
            this.pnlCompanyDetails.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlCompanyDetails.Style.BorderTopWidth = 1;
            this.pnlCompanyDetails.Style.CornerDiameter = 4;
            this.pnlCompanyDetails.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlCompanyDetails.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.pnlCompanyDetails.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlCompanyDetails.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.pnlCompanyDetails.TabIndex = 29;
            this.pnlCompanyDetails.Text = "Company Details";
            this.pnlCompanyDetails.Click += new System.EventHandler(this.pnlCompanyDetails_Click);
            // 
            // txtNameSearch
            // 
            this.txtNameSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSearch.Location = new System.Drawing.Point(82, 8);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(220, 27);
            this.txtNameSearch.TabIndex = 0;
            this.txtNameSearch.TextChanged += new System.EventHandler(this.txtNameSearch_TextChanged);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Image = global::EdgePackaging.Properties.Resources.close_delete_32;
            this.buttonX1.Location = new System.Drawing.Point(762, 3);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(49, 36);
            this.buttonX1.TabIndex = 22;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Location = new System.Drawing.Point(473, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 43);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // labelX17
            // 
            this.labelX17.BackColor = System.Drawing.Color.Transparent;
            this.labelX17.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX17.Location = new System.Drawing.Point(5, 6);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(71, 29);
            this.labelX17.TabIndex = 19;
            this.labelX17.Text = "Name";
            // 
            // pnlCompanyDetailsClose
            // 
            this.pnlCompanyDetailsClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.pnlCompanyDetailsClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.pnlCompanyDetailsClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCompanyDetailsClose.ForeColor = System.Drawing.Color.Red;
            this.pnlCompanyDetailsClose.Location = new System.Drawing.Point(1159, 0);
            this.pnlCompanyDetailsClose.Name = "pnlCompanyDetailsClose";
            this.pnlCompanyDetailsClose.Size = new System.Drawing.Size(15, 15);
            this.pnlCompanyDetailsClose.TabIndex = 16;
            this.pnlCompanyDetailsClose.Text = "X";
            this.pnlCompanyDetailsClose.Click += new System.EventHandler(this.pnlCompanyDetailsClose_Click);
            // 
            // dgvCompanyDetails
            // 
            this.dgvCompanyDetails.AllowUserToAddRows = false;
            this.dgvCompanyDetails.AllowUserToDeleteRows = false;
            this.dgvCompanyDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCompanyDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCompanyDetails.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCompanyDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompanyDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompanyDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCompanyDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvCompanyDetails.Location = new System.Drawing.Point(3, 47);
            this.dgvCompanyDetails.Name = "dgvCompanyDetails";
            this.dgvCompanyDetails.RowHeadersVisible = false;
            this.dgvCompanyDetails.Size = new System.Drawing.Size(799, 301);
            this.dgvCompanyDetails.TabIndex = 15;
            this.dgvCompanyDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompanyDetails_CellClick);
            this.dgvCompanyDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompanyDetails_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Edit";
            this.Column1.Image = ((System.Drawing.Image)(resources.GetObject("Column1.Image")));
            this.Column1.Name = "Column1";
            this.Column1.Width = 34;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Delete";
            this.Column2.Image = ((System.Drawing.Image)(resources.GetObject("Column2.Image")));
            this.Column2.Name = "Column2";
            this.Column2.Width = 49;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Select";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            this.Column3.Width = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Company Master";
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Edit";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "Edit";
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "Delete";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Text = "Delete";
            // 
            // frmCompanyMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 383);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlCompanyDetails);
            this.Controls.Add(this.pnlOperations);
            this.Controls.Add(this.pnlBasicInformation);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmCompanyMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Master";
            this.Load += new System.EventHandler(this.frmCompanyMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCompanyMaster_KeyDown);
            this.pnlOperations.ResumeLayout(false);
            this.pnlBasicInformation.ResumeLayout(false);
            this.pnlCompanyDetails.ResumeLayout(false);
            this.pnlCompanyDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel pnlOperations;
        private DevComponents.DotNetBar.ButtonX btnOpen;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.LabelX labelX61;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGSTNumber;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlBasicInformation;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAddress1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlCompanyDetails;
        private DevComponents.DotNetBar.ButtonX pnlCompanyDetailsClose;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvCompanyDetails;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.LabelX labelX17;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.ComboBox cmbState;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtadd2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtadd3;
        private System.Windows.Forms.TextBox txtNameSearch;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;

    }
}