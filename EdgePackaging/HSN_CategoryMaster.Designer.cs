namespace EdgePackaging
{
    partial class HSN_CategoryMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HSN_CategoryMaster));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBasicInformation = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtHSN_CAT = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtHSN_CODE = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cmbtax = new System.Windows.Forms.ComboBox();
            this.pnlInventoryDetails = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.txtHSN_CATSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtHSNCodeSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            this.dgvHSNMasterDetails = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.pnlBasicInformation.SuspendLayout();
            this.pnlInventoryDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHSNMasterDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBasicInformation
            // 
            this.pnlBasicInformation.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBasicInformation.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlBasicInformation.Controls.Add(this.btnClose);
            this.pnlBasicInformation.Controls.Add(this.btnReset);
            this.pnlBasicInformation.Controls.Add(this.btnSave);
            this.pnlBasicInformation.Controls.Add(this.txtHSN_CAT);
            this.pnlBasicInformation.Controls.Add(this.txtHSN_CODE);
            this.pnlBasicInformation.Controls.Add(this.labelX10);
            this.pnlBasicInformation.Controls.Add(this.labelX6);
            this.pnlBasicInformation.Controls.Add(this.labelX2);
            this.pnlBasicInformation.Controls.Add(this.cmbtax);
            this.pnlBasicInformation.Location = new System.Drawing.Point(1, 3);
            this.pnlBasicInformation.Name = "pnlBasicInformation";
            this.pnlBasicInformation.Size = new System.Drawing.Size(835, 84);
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
            this.pnlBasicInformation.TabIndex = 1;
            this.pnlBasicInformation.Text = "HSN Category Master";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnClose.Location = new System.Drawing.Point(713, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 58);
            this.btnClose.TabIndex = 38;
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
            this.btnReset.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnReset.Location = new System.Drawing.Point(607, 0);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 58);
            this.btnReset.TabIndex = 37;
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
            this.btnSave.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnSave.Location = new System.Drawing.Point(501, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 58);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtHSN_CAT
            // 
            // 
            // 
            // 
            this.txtHSN_CAT.Border.Class = "TextBoxBorder";
            this.txtHSN_CAT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHSN_CAT.Location = new System.Drawing.Point(3, 31);
            this.txtHSN_CAT.Name = "txtHSN_CAT";
            this.txtHSN_CAT.Size = new System.Drawing.Size(167, 26);
            this.txtHSN_CAT.TabIndex = 34;
            this.txtHSN_CAT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHSN_CAT_KeyDown);
            // 
            // txtHSN_CODE
            // 
            // 
            // 
            // 
            this.txtHSN_CODE.Border.Class = "TextBoxBorder";
            this.txtHSN_CODE.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHSN_CODE.Location = new System.Drawing.Point(176, 31);
            this.txtHSN_CODE.Name = "txtHSN_CODE";
            this.txtHSN_CODE.Size = new System.Drawing.Size(202, 26);
            this.txtHSN_CODE.TabIndex = 10;
            this.txtHSN_CODE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHSN_CODE_KeyDown);
            this.txtHSN_CODE.ImeModeChanged += new System.EventHandler(this.txtHSN_CODE_ImeModeChanged);
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            this.labelX10.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX10.Location = new System.Drawing.Point(176, 8);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(128, 20);
            this.labelX10.TabIndex = 33;
            this.labelX10.Text = "HSN Code";
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            this.labelX6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.Location = new System.Drawing.Point(384, 8);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(110, 20);
            this.labelX6.TabIndex = 27;
            this.labelX6.Text = "Tax %";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(8, 5);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(131, 22);
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = "HSN Category";
            // 
            // cmbtax
            // 
            this.cmbtax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtax.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtax.FormattingEnabled = true;
            this.cmbtax.Location = new System.Drawing.Point(384, 31);
            this.cmbtax.Name = "cmbtax";
            this.cmbtax.Size = new System.Drawing.Size(110, 26);
            this.cmbtax.TabIndex = 8;
            this.cmbtax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbtax_KeyDown);
            // 
            // pnlInventoryDetails
            // 
            this.pnlInventoryDetails.CanvasColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlInventoryDetails.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlInventoryDetails.Controls.Add(this.labelX17);
            this.pnlInventoryDetails.Controls.Add(this.txtHSN_CATSearch);
            this.pnlInventoryDetails.Controls.Add(this.txtHSNCodeSearch);
            this.pnlInventoryDetails.Controls.Add(this.labelX19);
            this.pnlInventoryDetails.Controls.Add(this.dgvHSNMasterDetails);
            this.pnlInventoryDetails.Location = new System.Drawing.Point(1, 93);
            this.pnlInventoryDetails.Name = "pnlInventoryDetails";
            this.pnlInventoryDetails.Size = new System.Drawing.Size(835, 360);
            // 
            // 
            // 
            this.pnlInventoryDetails.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlInventoryDetails.Style.BackColorGradientAngle = 90;
            this.pnlInventoryDetails.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlInventoryDetails.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlInventoryDetails.Style.BorderBottomWidth = 1;
            this.pnlInventoryDetails.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlInventoryDetails.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlInventoryDetails.Style.BorderLeftWidth = 1;
            this.pnlInventoryDetails.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlInventoryDetails.Style.BorderRightWidth = 1;
            this.pnlInventoryDetails.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlInventoryDetails.Style.BorderTopWidth = 1;
            this.pnlInventoryDetails.Style.CornerDiameter = 4;
            this.pnlInventoryDetails.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlInventoryDetails.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.pnlInventoryDetails.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlInventoryDetails.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.pnlInventoryDetails.TabIndex = 35;
            this.pnlInventoryDetails.Text = "All Details";
            // 
            // labelX17
            // 
            this.labelX17.BackColor = System.Drawing.Color.Transparent;
            this.labelX17.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX17.Location = new System.Drawing.Point(5, -17);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(116, 21);
            this.labelX17.TabIndex = 43;
            this.labelX17.Text = "HSN Category";
            this.labelX17.Visible = false;
            // 
            // txtHSN_CATSearch
            // 
            // 
            // 
            // 
            this.txtHSN_CATSearch.Border.Class = "TextBoxBorder";
            this.txtHSN_CATSearch.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHSN_CATSearch.Location = new System.Drawing.Point(126, -18);
            this.txtHSN_CATSearch.Name = "txtHSN_CATSearch";
            this.txtHSN_CATSearch.Size = new System.Drawing.Size(194, 25);
            this.txtHSN_CATSearch.TabIndex = 42;
            this.txtHSN_CATSearch.Visible = false;
            // 
            // txtHSNCodeSearch
            // 
            // 
            // 
            // 
            this.txtHSNCodeSearch.Border.Class = "TextBoxBorder";
            this.txtHSNCodeSearch.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHSNCodeSearch.Location = new System.Drawing.Point(417, -18);
            this.txtHSNCodeSearch.Name = "txtHSNCodeSearch";
            this.txtHSNCodeSearch.Size = new System.Drawing.Size(120, 25);
            this.txtHSNCodeSearch.TabIndex = 37;
            this.txtHSNCodeSearch.Visible = false;
            this.txtHSNCodeSearch.TextChanged += new System.EventHandler(this.txtHSNCodeSearch_TextChanged);
            // 
            // labelX19
            // 
            this.labelX19.BackColor = System.Drawing.Color.Transparent;
            this.labelX19.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX19.Location = new System.Drawing.Point(328, -14);
            this.labelX19.Name = "labelX19";
            this.labelX19.Size = new System.Drawing.Size(82, 18);
            this.labelX19.TabIndex = 41;
            this.labelX19.Text = "HSN Code";
            this.labelX19.Visible = false;
            // 
            // dgvHSNMasterDetails
            // 
            this.dgvHSNMasterDetails.AllowUserToAddRows = false;
            this.dgvHSNMasterDetails.AllowUserToDeleteRows = false;
            this.dgvHSNMasterDetails.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvHSNMasterDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHSNMasterDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHSNMasterDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvHSNMasterDetails.Location = new System.Drawing.Point(3, 13);
            this.dgvHSNMasterDetails.Name = "dgvHSNMasterDetails";
            this.dgvHSNMasterDetails.ReadOnly = true;
            this.dgvHSNMasterDetails.RowHeadersVisible = false;
            this.dgvHSNMasterDetails.Size = new System.Drawing.Size(823, 323);
            this.dgvHSNMasterDetails.TabIndex = 0;
            this.dgvHSNMasterDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHSNMasterDetails_CellClick);
            // 
            // HSN_CategoryMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 457);
            this.Controls.Add(this.pnlBasicInformation);
            this.Controls.Add(this.pnlInventoryDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HSN_CategoryMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HSN_CategoryMaster";
            this.Load += new System.EventHandler(this.HSN_CategoryMaster_Load);
            this.pnlBasicInformation.ResumeLayout(false);
            this.pnlInventoryDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHSNMasterDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel pnlBasicInformation;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHSN_CODE;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.ComboBox cmbtax;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHSN_CAT;
        private DevComponents.DotNetBar.Controls.GroupPanel pnlInventoryDetails;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHSNCodeSearch;
        private DevComponents.DotNetBar.LabelX labelX19;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvHSNMasterDetails;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.LabelX labelX17;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHSN_CATSearch;
    }
}