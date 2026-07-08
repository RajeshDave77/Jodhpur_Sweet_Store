namespace EdgePackaging
{
    partial class frmHeadMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHeadMaster));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBasicInformation = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmbParentHead = new System.Windows.Forms.ComboBox();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.pnlHeadDetails = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.txtNameSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgvHeadMasterDetails = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.pnlBasicInformation.SuspendLayout();
            this.pnlHeadDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeadMasterDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBasicInformation
            // 
            this.pnlBasicInformation.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBasicInformation.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlBasicInformation.Controls.Add(this.cmbParentHead);
            this.pnlBasicInformation.Controls.Add(this.btnClose);
            this.pnlBasicInformation.Controls.Add(this.btnReset);
            this.pnlBasicInformation.Controls.Add(this.btnSave);
            this.pnlBasicInformation.Controls.Add(this.txtName);
            this.pnlBasicInformation.Controls.Add(this.labelX3);
            this.pnlBasicInformation.Controls.Add(this.labelX2);
            this.pnlBasicInformation.Location = new System.Drawing.Point(2, 5);
            this.pnlBasicInformation.Name = "pnlBasicInformation";
            this.pnlBasicInformation.Size = new System.Drawing.Size(766, 69);
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
            this.pnlBasicInformation.Text = "Account Head Master";
            this.pnlBasicInformation.Click += new System.EventHandler(this.pnlBasicInformation_Click);
            // 
            // cmbParentHead
            // 
            this.cmbParentHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParentHead.FormattingEnabled = true;
            this.cmbParentHead.Location = new System.Drawing.Point(210, 19);
            this.cmbParentHead.Name = "cmbParentHead";
            this.cmbParentHead.Size = new System.Drawing.Size(223, 24);
            this.cmbParentHead.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnClose.Location = new System.Drawing.Point(651, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 4;
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
            this.btnReset.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnReset.Location = new System.Drawing.Point(545, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 30);
            this.btnReset.TabIndex = 3;
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
            this.btnSave.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnSave.Location = new System.Drawing.Point(439, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(3, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 25);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(209, 2);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(136, 17);
            this.labelX3.TabIndex = 52;
            this.labelX3.Text = "Parent Head *";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(3, 2);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(112, 18);
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = "Head Name *";
            // 
            // pnlHeadDetails
            // 
            this.pnlHeadDetails.CanvasColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlHeadDetails.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlHeadDetails.Controls.Add(this.btnDelete);
            this.pnlHeadDetails.Controls.Add(this.labelX17);
            this.pnlHeadDetails.Controls.Add(this.txtNameSearch);
            this.pnlHeadDetails.Controls.Add(this.dgvHeadMasterDetails);
            this.pnlHeadDetails.Location = new System.Drawing.Point(0, 78);
            this.pnlHeadDetails.Name = "pnlHeadDetails";
            this.pnlHeadDetails.Size = new System.Drawing.Size(768, 438);
            // 
            // 
            // 
            this.pnlHeadDetails.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlHeadDetails.Style.BackColorGradientAngle = 90;
            this.pnlHeadDetails.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlHeadDetails.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlHeadDetails.Style.BorderBottomWidth = 1;
            this.pnlHeadDetails.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlHeadDetails.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlHeadDetails.Style.BorderLeftWidth = 1;
            this.pnlHeadDetails.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlHeadDetails.Style.BorderRightWidth = 1;
            this.pnlHeadDetails.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlHeadDetails.Style.BorderTopWidth = 1;
            this.pnlHeadDetails.Style.CornerDiameter = 4;
            this.pnlHeadDetails.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlHeadDetails.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.pnlHeadDetails.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlHeadDetails.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.pnlHeadDetails.TabIndex = 1;
            this.pnlHeadDetails.Text = "Account Head Details";
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(612, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 26);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // labelX17
            // 
            this.labelX17.BackColor = System.Drawing.Color.Transparent;
            this.labelX17.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX17.Location = new System.Drawing.Point(7, 3);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(49, 21);
            this.labelX17.TabIndex = 24;
            this.labelX17.Text = "Name";
            this.labelX17.Visible = false;
            // 
            // txtNameSearch
            // 
            // 
            // 
            // 
            this.txtNameSearch.Border.Class = "TextBoxBorder";
            this.txtNameSearch.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSearch.Location = new System.Drawing.Point(61, 5);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(194, 25);
            this.txtNameSearch.TabIndex = 0;
            this.txtNameSearch.Visible = false;
            this.txtNameSearch.TextChanged += new System.EventHandler(this.txtNameSearch_TextChanged);
            // 
            // dgvHeadMasterDetails
            // 
            this.dgvHeadMasterDetails.AllowUserToAddRows = false;
            this.dgvHeadMasterDetails.AllowUserToDeleteRows = false;
            this.dgvHeadMasterDetails.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvHeadMasterDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHeadMasterDetails.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHeadMasterDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvHeadMasterDetails.Location = new System.Drawing.Point(3, 66);
            this.dgvHeadMasterDetails.Name = "dgvHeadMasterDetails";
            this.dgvHeadMasterDetails.ReadOnly = true;
            this.dgvHeadMasterDetails.RowHeadersVisible = false;
            this.dgvHeadMasterDetails.Size = new System.Drawing.Size(756, 347);
            this.dgvHeadMasterDetails.TabIndex = 0;
            this.dgvHeadMasterDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHeadMasterDetails_CellClick);
            this.dgvHeadMasterDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHeadMasterDetails_CellContentClick);
            // 
            // frmHeadMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 524);
            this.Controls.Add(this.pnlHeadDetails);
            this.Controls.Add(this.pnlBasicInformation);
            this.KeyPreview = true;
            this.Name = "frmHeadMaster";
            this.Text = "Head Master";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHeadMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHeadMaster_KeyDown);
            this.pnlBasicInformation.ResumeLayout(false);
            this.pnlHeadDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeadMasterDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel pnlBasicInformation;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlHeadDetails;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvHeadMasterDetails;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.LabelX labelX17;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNameSearch;
        private System.Windows.Forms.ComboBox cmbParentHead;
    }
}