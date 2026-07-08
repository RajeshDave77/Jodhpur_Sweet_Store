namespace EdgePackaging
{
    partial class frmUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlCommonDetails = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.txtnamesearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Name = new DevComponents.DotNetBar.LabelX();
            this.dgvUserMasterDetails = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.pnlBasicInformation = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cmbcompany = new System.Windows.Forms.ComboBox();
            this.txtMob = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtname = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtpassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtusername = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.lblRatePer = new DevComponents.DotNetBar.LabelX();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCommonDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserMasterDetails)).BeginInit();
            this.pnlBasicInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCommonDetails
            // 
            this.pnlCommonDetails.CanvasColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlCommonDetails.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlCommonDetails.Controls.Add(this.buttonX1);
            this.pnlCommonDetails.Controls.Add(this.txtnamesearch);
            this.pnlCommonDetails.Controls.Add(this.Name);
            this.pnlCommonDetails.Controls.Add(this.dgvUserMasterDetails);
            this.pnlCommonDetails.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCommonDetails.Location = new System.Drawing.Point(6, 226);
            this.pnlCommonDetails.Name = "pnlCommonDetails";
            this.pnlCommonDetails.Size = new System.Drawing.Size(662, 327);
            // 
            // 
            // 
            this.pnlCommonDetails.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlCommonDetails.Style.BackColorGradientAngle = 90;
            this.pnlCommonDetails.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlCommonDetails.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlCommonDetails.Style.BorderBottomWidth = 1;
            this.pnlCommonDetails.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlCommonDetails.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlCommonDetails.Style.BorderLeftWidth = 1;
            this.pnlCommonDetails.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlCommonDetails.Style.BorderRightWidth = 1;
            this.pnlCommonDetails.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlCommonDetails.Style.BorderTopWidth = 1;
            this.pnlCommonDetails.Style.CornerDiameter = 4;
            this.pnlCommonDetails.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlCommonDetails.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.pnlCommonDetails.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlCommonDetails.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.pnlCommonDetails.TabIndex = 0;
            this.pnlCommonDetails.Text = "User Details";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Image = ((System.Drawing.Image)(resources.GetObject("buttonX1.Image")));
            this.buttonX1.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.buttonX1.Location = new System.Drawing.Point(394, 1);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(100, 34);
            this.buttonX1.TabIndex = 61;
            this.buttonX1.Text = "Delete";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // txtnamesearch
            // 
            // 
            // 
            // 
            this.txtnamesearch.Border.Class = "TextBoxBorder";
            this.txtnamesearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnamesearch.Location = new System.Drawing.Point(144, 9);
            this.txtnamesearch.Name = "txtnamesearch";
            this.txtnamesearch.Size = new System.Drawing.Size(184, 26);
            this.txtnamesearch.TabIndex = 59;
            this.txtnamesearch.TextChanged += new System.EventHandler(this.txtnamesearch_TextChanged);
            this.txtnamesearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnamesearch_KeyDown);
            // 
            // Name
            // 
            this.Name.BackColor = System.Drawing.Color.Transparent;
            this.Name.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name.Location = new System.Drawing.Point(7, 9);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(105, 20);
            this.Name.TabIndex = 60;
            this.Name.Text = "Name";
            // 
            // dgvUserMasterDetails
            // 
            this.dgvUserMasterDetails.AllowUserToAddRows = false;
            this.dgvUserMasterDetails.AllowUserToDeleteRows = false;
            this.dgvUserMasterDetails.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvUserMasterDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUserMasterDetails.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserMasterDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvUserMasterDetails.Location = new System.Drawing.Point(7, 51);
            this.dgvUserMasterDetails.Name = "dgvUserMasterDetails";
            this.dgvUserMasterDetails.RowHeadersVisible = false;
            this.dgvUserMasterDetails.Size = new System.Drawing.Size(633, 246);
            this.dgvUserMasterDetails.TabIndex = 0;
            this.dgvUserMasterDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserMasterDetails_CellClick);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(334, 197);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(132, 16);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlBasicInformation
            // 
            this.pnlBasicInformation.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBasicInformation.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlBasicInformation.Controls.Add(this.btnDelete);
            this.pnlBasicInformation.Controls.Add(this.labelX3);
            this.pnlBasicInformation.Controls.Add(this.cmbcompany);
            this.pnlBasicInformation.Controls.Add(this.txtMob);
            this.pnlBasicInformation.Controls.Add(this.labelX1);
            this.pnlBasicInformation.Controls.Add(this.txtname);
            this.pnlBasicInformation.Controls.Add(this.labelX2);
            this.pnlBasicInformation.Controls.Add(this.txtpassword);
            this.pnlBasicInformation.Controls.Add(this.txtusername);
            this.pnlBasicInformation.Controls.Add(this.labelX4);
            this.pnlBasicInformation.Controls.Add(this.btnClose);
            this.pnlBasicInformation.Controls.Add(this.btnReset);
            this.pnlBasicInformation.Controls.Add(this.btnSave);
            this.pnlBasicInformation.Controls.Add(this.lblRatePer);
            this.pnlBasicInformation.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBasicInformation.Location = new System.Drawing.Point(6, 25);
            this.pnlBasicInformation.Name = "pnlBasicInformation";
            this.pnlBasicInformation.Size = new System.Drawing.Size(662, 195);
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
            this.pnlBasicInformation.Text = "User Master";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(7, 114);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(128, 24);
            this.labelX3.TabIndex = 60;
            this.labelX3.Text = "P. S. Location";
            // 
            // cmbcompany
            // 
            this.cmbcompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbcompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbcompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcompany.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.FormattingEnabled = true;
            this.cmbcompany.Location = new System.Drawing.Point(4, 138);
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.Size = new System.Drawing.Size(324, 25);
            this.cmbcompany.TabIndex = 59;
            this.cmbcompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbcompany_KeyDown);
            // 
            // txtMob
            // 
            // 
            // 
            // 
            this.txtMob.Border.Class = "TextBoxBorder";
            this.txtMob.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMob.Location = new System.Drawing.Point(271, 86);
            this.txtMob.Name = "txtMob";
            this.txtMob.Size = new System.Drawing.Size(195, 25);
            this.txtMob.TabIndex = 3;
            this.txtMob.TextChanged += new System.EventHandler(this.txtMob_TextChanged);
            this.txtMob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMob_KeyDown);
            this.txtMob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMob_KeyPress);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(271, 62);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(136, 20);
            this.labelX1.TabIndex = 58;
            this.labelX1.Text = "Mobile No.";
            this.labelX1.Click += new System.EventHandler(this.labelX1_Click);
            // 
            // txtname
            // 
            // 
            // 
            // 
            this.txtname.Border.Class = "TextBoxBorder";
            this.txtname.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.Location = new System.Drawing.Point(3, 86);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(241, 25);
            this.txtname.TabIndex = 2;
            this.txtname.TextChanged += new System.EventHandler(this.txtname_TextChanged);
            this.txtname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtname_KeyDown);
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(4, 65);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 15);
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = "Name";
            // 
            // txtpassword
            // 
            // 
            // 
            // 
            this.txtpassword.Border.Class = "TextBoxBorder";
            this.txtpassword.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(271, 35);
            this.txtpassword.MaxLength = 20;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(195, 25);
            this.txtpassword.TabIndex = 1;
            this.txtpassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpassword_KeyDown);
            // 
            // txtusername
            // 
            // 
            // 
            // 
            this.txtusername.Border.Class = "TextBoxBorder";
            this.txtusername.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusername.Location = new System.Drawing.Point(4, 35);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(240, 25);
            this.txtusername.TabIndex = 0;
            this.txtusername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtusername_KeyDown);
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(4, 12);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(132, 15);
            this.labelX4.TabIndex = 56;
            this.labelX4.Text = "User Name";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnClose.Location = new System.Drawing.Point(540, 107);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 46);
            this.btnClose.TabIndex = 6;
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
            this.btnReset.Location = new System.Drawing.Point(540, 54);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 47);
            this.btnReset.TabIndex = 5;
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
            this.btnSave.Location = new System.Drawing.Point(540, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 45);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblRatePer
            // 
            this.lblRatePer.BackColor = System.Drawing.Color.Transparent;
            this.lblRatePer.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRatePer.Location = new System.Drawing.Point(271, 12);
            this.lblRatePer.Name = "lblRatePer";
            this.lblRatePer.Size = new System.Drawing.Size(142, 15);
            this.lblRatePer.TabIndex = 52;
            this.lblRatePer.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Master";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 558);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlCommonDetails);
            this.Controls.Add(this.pnlBasicInformation);
            this.KeyPreview = true;
            this.MaximizeBox = false;
           
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Master";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUser_KeyDown);
            this.pnlCommonDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserMasterDetails)).EndInit();
            this.pnlBasicInformation.ResumeLayout(false);
            this.pnlBasicInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel pnlCommonDetails;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvUserMasterDetails;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlBasicInformation;
        private DevComponents.DotNetBar.Controls.TextBoxX txtpassword;
        private DevComponents.DotNetBar.Controls.TextBoxX txtusername;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.TextBoxX txtname;
        private DevComponents.DotNetBar.LabelX lblRatePer;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMob;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.ComboBox cmbcompany;
        private DevComponents.DotNetBar.Controls.TextBoxX txtnamesearch;
        private DevComponents.DotNetBar.LabelX Name;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Label label1;
    }
}