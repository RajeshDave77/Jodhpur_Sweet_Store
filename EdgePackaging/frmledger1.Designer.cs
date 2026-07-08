namespace EdgePackaging
{
    partial class frmledger1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmledger1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlOperations = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnOpen = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.pnlBasicInformation = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.txtadd2 = new System.Windows.Forms.TextBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtadd1 = new System.Windows.Forms.TextBox();
            this.labelX24 = new DevComponents.DotNetBar.LabelX();
            this.labelX23 = new DevComponents.DotNetBar.LabelX();
            this.txtname = new System.Windows.Forms.TextBox();
            this.labelX21 = new DevComponents.DotNetBar.LabelX();
            this.txtmobile = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cmbstate = new System.Windows.Forms.ComboBox();
            this.dtdoa = new System.Windows.Forms.MaskedTextBox();
            this.dtdob = new System.Windows.Forms.MaskedTextBox();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtgstno = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.pnlLedgerDetails = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.txtNameSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnLedgerDetailsClose = new DevComponents.DotNetBar.ButtonX();
            this.dgvLedgerMasterDetails = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.openfileDiaImage = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlOperations.SuspendLayout();
            this.pnlBasicInformation.SuspendLayout();
            this.pnlLedgerDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedgerMasterDetails)).BeginInit();
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
            this.pnlOperations.Location = new System.Drawing.Point(12, 253);
            this.pnlOperations.Name = "pnlOperations";
            this.pnlOperations.Size = new System.Drawing.Size(753, 83);
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
            this.pnlOperations.TabIndex = 2;
            // 
            // btnOpen
            // 
            this.btnOpen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOpen.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnOpen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOpen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnOpen.Location = new System.Drawing.Point(264, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(105, 53);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "&Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnClose.Location = new System.Drawing.Point(510, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 53);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnReset.Location = new System.Drawing.Point(392, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(99, 53);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "&Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnSave.Location = new System.Drawing.Point(142, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 53);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlBasicInformation
            // 
            this.pnlBasicInformation.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBasicInformation.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlBasicInformation.Controls.Add(this.labelX6);
            this.pnlBasicInformation.Controls.Add(this.cmbCompany);
            this.pnlBasicInformation.Controls.Add(this.cmbtype);
            this.pnlBasicInformation.Controls.Add(this.txtadd2);
            this.pnlBasicInformation.Controls.Add(this.labelX1);
            this.pnlBasicInformation.Controls.Add(this.txtadd1);
            this.pnlBasicInformation.Controls.Add(this.labelX24);
            this.pnlBasicInformation.Controls.Add(this.labelX23);
            this.pnlBasicInformation.Controls.Add(this.txtname);
            this.pnlBasicInformation.Controls.Add(this.labelX21);
            this.pnlBasicInformation.Controls.Add(this.txtmobile);
            this.pnlBasicInformation.Controls.Add(this.labelX5);
            this.pnlBasicInformation.Controls.Add(this.labelX2);
            this.pnlBasicInformation.Controls.Add(this.cmbstate);
            this.pnlBasicInformation.Location = new System.Drawing.Point(11, 30);
            this.pnlBasicInformation.Name = "pnlBasicInformation";
            this.pnlBasicInformation.Size = new System.Drawing.Size(754, 220);
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
            this.pnlBasicInformation.Text = "Basic Information";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            this.labelX6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.Location = new System.Drawing.Point(149, 118);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(89, 24);
            this.labelX6.TabIndex = 76;
            this.labelX6.Text = "Company";
            // 
            // cmbCompany
            // 
            this.cmbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(281, 121);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(266, 26);
            this.cmbCompany.TabIndex = 2;
            this.cmbCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCompany_KeyDown);
            // 
            // cmbtype
            // 
            this.cmbtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtype.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Location = new System.Drawing.Point(563, 54);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(188, 26);
            this.cmbtype.TabIndex = 3;
            this.cmbtype.Visible = false;
            this.cmbtype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbtype_KeyDown);
            // 
            // txtadd2
            // 
            this.txtadd2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtadd2.Location = new System.Drawing.Point(522, 155);
            this.txtadd2.Name = "txtadd2";
            this.txtadd2.Size = new System.Drawing.Size(198, 26);
            this.txtadd2.TabIndex = 3;
            this.txtadd2.Visible = false;
            this.txtadd2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtadd2_KeyDown);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(408, 155);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(89, 24);
            this.labelX1.TabIndex = 73;
            this.labelX1.Text = "Address2";
            this.labelX1.Visible = false;
            // 
            // txtadd1
            // 
            this.txtadd1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtadd1.Location = new System.Drawing.Point(522, 123);
            this.txtadd1.Name = "txtadd1";
            this.txtadd1.Size = new System.Drawing.Size(198, 26);
            this.txtadd1.TabIndex = 2;
            this.txtadd1.Visible = false;
            this.txtadd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtadd1_KeyDown);
            // 
            // labelX24
            // 
            this.labelX24.AutoSize = true;
            this.labelX24.BackColor = System.Drawing.Color.Transparent;
            this.labelX24.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX24.Location = new System.Drawing.Point(407, 123);
            this.labelX24.Name = "labelX24";
            this.labelX24.Size = new System.Drawing.Size(89, 24);
            this.labelX24.TabIndex = 71;
            this.labelX24.Text = "Address1";
            this.labelX24.Visible = false;
            // 
            // labelX23
            // 
            this.labelX23.AutoSize = true;
            this.labelX23.BackColor = System.Drawing.Color.Transparent;
            this.labelX23.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX23.Location = new System.Drawing.Point(585, 18);
            this.labelX23.Name = "labelX23";
            this.labelX23.Size = new System.Drawing.Size(47, 24);
            this.labelX23.TabIndex = 70;
            this.labelX23.Text = "Type";
            this.labelX23.Visible = false;
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.Location = new System.Drawing.Point(281, 16);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(266, 26);
            this.txtname.TabIndex = 0;
            this.txtname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtname_KeyDown);
            // 
            // labelX21
            // 
            this.labelX21.AutoSize = true;
            this.labelX21.BackColor = System.Drawing.Color.Transparent;
            this.labelX21.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX21.Location = new System.Drawing.Point(388, 172);
            this.labelX21.Name = "labelX21";
            this.labelX21.Size = new System.Drawing.Size(49, 24);
            this.labelX21.TabIndex = 61;
            this.labelX21.Text = "State";
            this.labelX21.Visible = false;
            // 
            // txtmobile
            // 
            // 
            // 
            // 
            this.txtmobile.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtmobile.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtmobile.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtmobile.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtmobile.Border.Class = "TextBoxBorder";
            this.txtmobile.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmobile.Location = new System.Drawing.Point(281, 69);
            this.txtmobile.Name = "txtmobile";
            this.txtmobile.Size = new System.Drawing.Size(198, 26);
            this.txtmobile.TabIndex = 1;
            this.txtmobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmobile_KeyDown);
            this.txtmobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmobile_KeyPress);
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            this.labelX5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(149, 67);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(109, 24);
            this.labelX5.TabIndex = 29;
            this.labelX5.Text = "Contact No.";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(149, 16);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(67, 24);
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = "Name *";
            // 
            // cmbstate
            // 
            this.cmbstate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbstate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbstate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbstate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbstate.FormattingEnabled = true;
            this.cmbstate.Location = new System.Drawing.Point(431, 173);
            this.cmbstate.Name = "cmbstate";
            this.cmbstate.Size = new System.Drawing.Size(201, 26);
            this.cmbstate.TabIndex = 4;
            this.cmbstate.Visible = false;
            this.cmbstate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbstate_KeyDown);
            // 
            // dtdoa
            // 
            this.dtdoa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtdoa.Location = new System.Drawing.Point(203, 224);
            this.dtdoa.Mask = "00/00/0000";
            this.dtdoa.Name = "dtdoa";
            this.dtdoa.Size = new System.Drawing.Size(118, 26);
            this.dtdoa.TabIndex = 80;
            this.dtdoa.ValidatingType = typeof(System.DateTime);
            this.dtdoa.Visible = false;
            this.dtdoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtdoa_KeyDown);
            this.dtdoa.Leave += new System.EventHandler(this.dtdoa_Leave);
            // 
            // dtdob
            // 
            this.dtdob.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtdob.Location = new System.Drawing.Point(471, 221);
            this.dtdob.Mask = "00/00/0000";
            this.dtdob.Name = "dtdob";
            this.dtdob.Size = new System.Drawing.Size(118, 26);
            this.dtdob.TabIndex = 79;
            this.dtdob.ValidatingType = typeof(System.DateTime);
            this.dtdob.Visible = false;
            this.dtdob.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.dtdob_TypeValidationCompleted);
            this.dtdob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtdob_KeyDown);
            this.dtdob.Leave += new System.EventHandler(this.dtdob_Leave);
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(12, 223);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(185, 24);
            this.labelX4.TabIndex = 78;
            this.labelX4.Text = "Date Of Anniversary";
            this.labelX4.Visible = false;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(341, 223);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(120, 24);
            this.labelX3.TabIndex = 76;
            this.labelX3.Text = "Date Of Birth";
            this.labelX3.Visible = false;
            // 
            // txtgstno
            // 
            // 
            // 
            // 
            this.txtgstno.Border.Class = "TextBoxBorder";
            this.txtgstno.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgstno.Location = new System.Drawing.Point(444, 7);
            this.txtgstno.Name = "txtgstno";
            this.txtgstno.Size = new System.Drawing.Size(202, 26);
            this.txtgstno.TabIndex = 10;
            this.txtgstno.Visible = false;
            this.txtgstno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtgstno_KeyDown);
            // 
            // labelX14
            // 
            this.labelX14.AutoSize = true;
            this.labelX14.BackColor = System.Drawing.Color.Transparent;
            this.labelX14.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX14.Location = new System.Drawing.Point(330, 9);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(77, 24);
            this.labelX14.TabIndex = 40;
            this.labelX14.Text = "GST No.";
            this.labelX14.Visible = false;
            // 
            // pnlLedgerDetails
            // 
            this.pnlLedgerDetails.CanvasColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlLedgerDetails.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlLedgerDetails.Controls.Add(this.buttonX1);
            this.pnlLedgerDetails.Controls.Add(this.btnDelete);
            this.pnlLedgerDetails.Controls.Add(this.labelX17);
            this.pnlLedgerDetails.Controls.Add(this.txtNameSearch);
            this.pnlLedgerDetails.Controls.Add(this.btnLedgerDetailsClose);
            this.pnlLedgerDetails.Controls.Add(this.dgvLedgerMasterDetails);
            this.pnlLedgerDetails.Location = new System.Drawing.Point(11, 9);
            this.pnlLedgerDetails.Name = "pnlLedgerDetails";
            this.pnlLedgerDetails.Size = new System.Drawing.Size(754, 392);
            // 
            // 
            // 
            this.pnlLedgerDetails.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlLedgerDetails.Style.BackColorGradientAngle = 90;
            this.pnlLedgerDetails.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlLedgerDetails.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlLedgerDetails.Style.BorderBottomWidth = 1;
            this.pnlLedgerDetails.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlLedgerDetails.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlLedgerDetails.Style.BorderLeftWidth = 1;
            this.pnlLedgerDetails.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlLedgerDetails.Style.BorderRightWidth = 1;
            this.pnlLedgerDetails.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlLedgerDetails.Style.BorderTopWidth = 1;
            this.pnlLedgerDetails.Style.CornerDiameter = 4;
            this.pnlLedgerDetails.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlLedgerDetails.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.pnlLedgerDetails.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlLedgerDetails.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.pnlLedgerDetails.TabIndex = 2;
            this.pnlLedgerDetails.Text = "Ledger Details";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Image = global::EdgePackaging.Properties.Resources.close_delete_32;
            this.buttonX1.Location = new System.Drawing.Point(716, 3);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(29, 23);
            this.buttonX1.TabIndex = 31;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(449, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 29);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // labelX17
            // 
            this.labelX17.BackColor = System.Drawing.Color.Transparent;
            this.labelX17.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX17.Location = new System.Drawing.Point(5, -3);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(58, 41);
            this.labelX17.TabIndex = 30;
            this.labelX17.Text = "Name";
            // 
            // txtNameSearch
            // 
            // 
            // 
            // 
            this.txtNameSearch.Border.Class = "TextBoxBorder";
            this.txtNameSearch.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSearch.Location = new System.Drawing.Point(69, 3);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(251, 29);
            this.txtNameSearch.TabIndex = 28;
            this.txtNameSearch.TextChanged += new System.EventHandler(this.txtNameSearch_TextChanged);
            // 
            // btnLedgerDetailsClose
            // 
            this.btnLedgerDetailsClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLedgerDetailsClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLedgerDetailsClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLedgerDetailsClose.ForeColor = System.Drawing.Color.Red;
            this.btnLedgerDetailsClose.Location = new System.Drawing.Point(901, 1);
            this.btnLedgerDetailsClose.Name = "btnLedgerDetailsClose";
            this.btnLedgerDetailsClose.Size = new System.Drawing.Size(36, 25);
            this.btnLedgerDetailsClose.TabIndex = 16;
            this.btnLedgerDetailsClose.Text = "X";
            this.btnLedgerDetailsClose.Click += new System.EventHandler(this.btnLedgerDetailsClose_Click);
            // 
            // dgvLedgerMasterDetails
            // 
            this.dgvLedgerMasterDetails.AllowUserToAddRows = false;
            this.dgvLedgerMasterDetails.AllowUserToDeleteRows = false;
            this.dgvLedgerMasterDetails.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLedgerMasterDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLedgerMasterDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLedgerMasterDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvLedgerMasterDetails.Location = new System.Drawing.Point(0, 42);
            this.dgvLedgerMasterDetails.Name = "dgvLedgerMasterDetails";
            this.dgvLedgerMasterDetails.RowHeadersVisible = false;
            this.dgvLedgerMasterDetails.Size = new System.Drawing.Size(742, 321);
            this.dgvLedgerMasterDetails.TabIndex = 15;
            this.dgvLedgerMasterDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLedgerMasterDetails_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 18);
            this.label1.TabIndex = 81;
            this.label1.Text = "Ledger Master";
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
            // frmledger1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 402);
            this.Controls.Add(this.pnlLedgerDetails);
            this.Controls.Add(this.pnlBasicInformation);
            this.Controls.Add(this.dtdoa);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.dtdob);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlOperations);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txtgstno);
            this.Controls.Add(this.labelX14);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmledger1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ledger Master";
            this.Load += new System.EventHandler(this.frmledger1_Load);
            this.pnlOperations.ResumeLayout(false);
            this.pnlBasicInformation.ResumeLayout(false);
            this.pnlBasicInformation.PerformLayout();
            this.pnlLedgerDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedgerMasterDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel pnlOperations;
        private DevComponents.DotNetBar.ButtonX btnOpen;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlBasicInformation;
        private DevComponents.DotNetBar.Controls.TextBoxX txtgstno;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.Controls.TextBoxX txtmobile;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlLedgerDetails;
        private DevComponents.DotNetBar.ButtonX btnLedgerDetailsClose;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvLedgerMasterDetails;
        private System.Windows.Forms.OpenFileDialog openfileDiaImage;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.LabelX labelX17;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNameSearch;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private DevComponents.DotNetBar.LabelX labelX21;
        private System.Windows.Forms.ComboBox cmbstate;
        private System.Windows.Forms.TextBox txtname;
        private DevComponents.DotNetBar.LabelX labelX23;
        private DevComponents.DotNetBar.LabelX labelX24;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.TextBox txtadd2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.TextBox txtadd1;
        private System.Windows.Forms.ComboBox cmbtype;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.MaskedTextBox dtdoa;
        private System.Windows.Forms.MaskedTextBox dtdob;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.ComboBox cmbCompany;
    }
}