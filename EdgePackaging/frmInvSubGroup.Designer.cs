namespace EdgePackaging
{
    partial class frmInvSubGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvSubGroup));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeadDetails = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.txtNameSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgvHeadMasterDetails = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.pnlBasicInformation = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmbParentGroup = new System.Windows.Forms.ComboBox();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHeadDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeadMasterDetails)).BeginInit();
            this.pnlBasicInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeadDetails
            // 
            this.pnlHeadDetails.CanvasColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlHeadDetails.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlHeadDetails.Controls.Add(this.btnDelete);
            this.pnlHeadDetails.Controls.Add(this.labelX18);
            this.pnlHeadDetails.Controls.Add(this.labelX17);
            this.pnlHeadDetails.Controls.Add(this.txtNameSearch);
            this.pnlHeadDetails.Controls.Add(this.dgvHeadMasterDetails);
            this.pnlHeadDetails.Location = new System.Drawing.Point(5, 122);
            this.pnlHeadDetails.Name = "pnlHeadDetails";
            this.pnlHeadDetails.Size = new System.Drawing.Size(767, 408);
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
            this.pnlHeadDetails.Text = "Inentory Sub Group Details";
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(446, 1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 48);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // labelX18
            // 
            this.labelX18.BackColor = System.Drawing.Color.Transparent;
            this.labelX18.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX18.Location = new System.Drawing.Point(9, 3);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(93, 35);
            this.labelX18.TabIndex = 25;
            this.labelX18.Text = "Name";
            // 
            // labelX17
            // 
            this.labelX17.BackColor = System.Drawing.Color.Transparent;
            this.labelX17.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX17.Location = new System.Drawing.Point(7, -34);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(68, 54);
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
            this.txtNameSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSearch.Location = new System.Drawing.Point(110, 12);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(194, 26);
            this.txtNameSearch.TabIndex = 0;
            this.txtNameSearch.TextChanged += new System.EventHandler(this.txtNameSearch_TextChanged);
            // 
            // dgvHeadMasterDetails
            // 
            this.dgvHeadMasterDetails.AllowUserToAddRows = false;
            this.dgvHeadMasterDetails.AllowUserToDeleteRows = false;
            this.dgvHeadMasterDetails.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvHeadMasterDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHeadMasterDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHeadMasterDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvHeadMasterDetails.Location = new System.Drawing.Point(3, 64);
            this.dgvHeadMasterDetails.Name = "dgvHeadMasterDetails";
            this.dgvHeadMasterDetails.RowHeadersVisible = false;
            this.dgvHeadMasterDetails.Size = new System.Drawing.Size(756, 320);
            this.dgvHeadMasterDetails.TabIndex = 0;
            this.dgvHeadMasterDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHeadMasterDetails_CellClick);
            this.dgvHeadMasterDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHeadMasterDetails_CellContentClick);
            // 
            // pnlBasicInformation
            // 
            this.pnlBasicInformation.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBasicInformation.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlBasicInformation.Controls.Add(this.cmbParentGroup);
            this.pnlBasicInformation.Controls.Add(this.btnClose);
            this.pnlBasicInformation.Controls.Add(this.btnReset);
            this.pnlBasicInformation.Controls.Add(this.btnSave);
            this.pnlBasicInformation.Controls.Add(this.txtName);
            this.pnlBasicInformation.Controls.Add(this.labelX3);
            this.pnlBasicInformation.Controls.Add(this.labelX2);
            this.pnlBasicInformation.Location = new System.Drawing.Point(7, 31);
            this.pnlBasicInformation.Name = "pnlBasicInformation";
            this.pnlBasicInformation.Size = new System.Drawing.Size(765, 89);
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
            this.pnlBasicInformation.Text = "Inentory Sub Group Master";
            this.pnlBasicInformation.Click += new System.EventHandler(this.pnlBasicInformation_Click);
            // 
            // cmbParentGroup
            // 
            this.cmbParentGroup.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParentGroup.FormattingEnabled = true;
            this.cmbParentGroup.Location = new System.Drawing.Point(236, 36);
            this.cmbParentGroup.Name = "cmbParentGroup";
            this.cmbParentGroup.Size = new System.Drawing.Size(179, 26);
            this.cmbParentGroup.TabIndex = 0;
            this.cmbParentGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtParent_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnClose.Location = new System.Drawing.Point(643, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 48);
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
            this.btnReset.Location = new System.Drawing.Point(538, 14);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(89, 48);
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
            this.btnSave.Location = new System.Drawing.Point(439, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 48);
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
            this.txtName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(3, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(227, 26);
            this.txtName.TabIndex = 0;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(236, 3);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(166, 33);
            this.labelX3.TabIndex = 52;
            this.labelX3.Text = "Parent Group*";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(3, -2);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(97, 38);
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = "Name *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(14, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 18);
            this.label1.TabIndex = 53;
            this.label1.Text = "Product Sub Group Master";
            // 
            // frmInvSubGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 532);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlHeadDetails);
            this.Controls.Add(this.pnlBasicInformation);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(10, 10);
            this.MaximizeBox = false;
            this.Name = "frmInvSubGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Sub Grop Master";
            this.Load += new System.EventHandler(this.frmInvSubGroup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInvSubGroup_KeyDown);
            this.pnlHeadDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeadMasterDetails)).EndInit();
            this.pnlBasicInformation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel pnlHeadDetails;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.LabelX labelX18;
        private DevComponents.DotNetBar.LabelX labelX17;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNameSearch;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvHeadMasterDetails;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlBasicInformation;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbParentGroup;
    }
}