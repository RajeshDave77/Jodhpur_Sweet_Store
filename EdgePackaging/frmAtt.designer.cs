namespace EdgePackaging
{
    partial class frmAtt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAtt));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbcompany = new System.Windows.Forms.ComboBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.pnlCommonDetails = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cmbTag = new System.Windows.Forms.ComboBox();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.txtNameSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX17 = new DevComponents.DotNetBar.LabelX();
            this.dbGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSave_Print = new DevComponents.DotNetBar.ButtonX();
            this.button3 = new System.Windows.Forms.Button();
            this.pnlCommonDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Daily Attendance Entry";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 111;
            this.label2.Text = "Location";
            // 
            // cmbcompany
            // 
            this.cmbcompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbcompany.BackColor = System.Drawing.Color.White;
            this.cmbcompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcompany.Enabled = false;
            this.cmbcompany.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.FormattingEnabled = true;
            this.cmbcompany.Location = new System.Drawing.Point(104, 42);
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.Size = new System.Drawing.Size(298, 25);
            this.cmbcompany.TabIndex = 110;
            this.cmbcompany.SelectedIndexChanged += new System.EventHandler(this.cmbcompany_SelectedIndexChanged);
            this.cmbcompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbcompany_KeyDown);
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MM/yyyy";
            this.dtDate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(549, 42);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(127, 25);
            this.dtDate.TabIndex = 119;
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            this.dtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtDate_KeyPress);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(418, 42);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(125, 18);
            this.label29.TabIndex = 120;
            this.label29.Text = "Attendance Date";
            // 
            // pnlCommonDetails
            // 
            this.pnlCommonDetails.CanvasColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlCommonDetails.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlCommonDetails.Controls.Add(this.button2);
            this.pnlCommonDetails.Controls.Add(this.button1);
            this.pnlCommonDetails.Controls.Add(this.labelX1);
            this.pnlCommonDetails.Controls.Add(this.cmbTag);
            this.pnlCommonDetails.Controls.Add(this.chkSelect);
            this.pnlCommonDetails.Controls.Add(this.txtNameSearch);
            this.pnlCommonDetails.Controls.Add(this.LabelX17);
            this.pnlCommonDetails.Controls.Add(this.dbGrid);
            this.pnlCommonDetails.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCommonDetails.Location = new System.Drawing.Point(16, 82);
            this.pnlCommonDetails.Name = "pnlCommonDetails";
            this.pnlCommonDetails.Size = new System.Drawing.Size(779, 360);
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
            this.pnlCommonDetails.TabIndex = 121;
            this.pnlCommonDetails.Text = "Staff Details";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(689, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 23);
            this.button2.TabIndex = 114;
            this.button2.Text = "Clear All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(595, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 113;
            this.button1.Text = "Set Status";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(417, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(55, 19);
            this.labelX1.TabIndex = 112;
            this.labelX1.Text = "Att. Tag";
            // 
            // cmbTag
            // 
            this.cmbTag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTag.BackColor = System.Drawing.Color.White;
            this.cmbTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTag.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTag.FormattingEnabled = true;
            this.cmbTag.Items.AddRange(new object[] {
            "A",
            "2A",
            "P",
            "P1/2",
            "P1/4"});
            this.cmbTag.Location = new System.Drawing.Point(482, 4);
            this.cmbTag.Name = "cmbTag";
            this.cmbTag.Size = new System.Drawing.Size(88, 25);
            this.cmbTag.TabIndex = 111;
            this.cmbTag.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSize = true;
            this.chkSelect.BackColor = System.Drawing.Color.Transparent;
            this.chkSelect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelect.Location = new System.Drawing.Point(17, 3);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(78, 17);
            this.chkSelect.TabIndex = 29;
            this.chkSelect.Text = "Select All";
            this.chkSelect.UseVisualStyleBackColor = false;
            this.chkSelect.Click += new System.EventHandler(this.chkSelect_Click);
            // 
            // txtNameSearch
            // 
            // 
            // 
            // 
            this.txtNameSearch.Border.Class = "TextBoxBorder";
            this.txtNameSearch.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSearch.Location = new System.Drawing.Point(240, 4);
            this.txtNameSearch.MaxLength = 100;
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(159, 25);
            this.txtNameSearch.TabIndex = 18;
            this.txtNameSearch.TextChanged += new System.EventHandler(this.txtNameSearch_TextChanged);
            // 
            // LabelX17
            // 
            this.LabelX17.BackColor = System.Drawing.Color.Transparent;
            this.LabelX17.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX17.Location = new System.Drawing.Point(117, 3);
            this.LabelX17.Name = "LabelX17";
            this.LabelX17.Size = new System.Drawing.Size(117, 22);
            this.LabelX17.TabIndex = 19;
            this.LabelX17.Text = "Search By Name";
            // 
            // dbGrid
            // 
            this.dbGrid.AllowUserToAddRows = false;
            this.dbGrid.AllowUserToDeleteRows = false;
            this.dbGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dbGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dbGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dbGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.dbGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dbGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dbGrid.Location = new System.Drawing.Point(11, 34);
            this.dbGrid.Name = "dbGrid";
            this.dbGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dbGrid.RowHeadersWidth = 52;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dbGrid.RowTemplate.Height = 32;
            this.dbGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dbGrid.Size = new System.Drawing.Size(759, 287);
            this.dbGrid.TabIndex = 17;
            this.dbGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbGrid_CellClick);
            // 
            // Column1
            // 
            this.Column1.FalseValue = "false";
            this.Column1.HeaderText = "Select";
            this.Column1.Name = "Column1";
            this.Column1.TrueValue = "true";
            this.Column1.Width = 55;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Delete";
            this.Column2.Image = ((System.Drawing.Image)(resources.GetObject("Column2.Image")));
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            this.Column2.Width = 44;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Edit";
            this.Column3.Image = ((System.Drawing.Image)(resources.GetObject("Column3.Image")));
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            this.Column3.Width = 31;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Delete";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Visible = false;
            this.dataGridViewImageColumn1.Width = 56;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Edit";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Visible = false;
            this.dataGridViewImageColumn2.Width = 39;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnClose.Location = new System.Drawing.Point(446, 461);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 48);
            this.btnClose.TabIndex = 118;
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
            this.btnSave_Print.Location = new System.Drawing.Point(275, 461);
            this.btnSave_Print.Name = "btnSave_Print";
            this.btnSave_Print.Size = new System.Drawing.Size(108, 48);
            this.btnSave_Print.TabIndex = 116;
            this.btnSave_Print.Text = "&Save";
            this.btnSave_Print.Click += new System.EventHandler(this.btnSave_Print_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(421, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 23);
            this.button3.TabIndex = 122;
            this.button3.Text = "Attendance Report";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmAtt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(807, 523);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pnlCommonDetails);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave_Print);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbcompany);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmAtt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Attendance Entry";
            this.Load += new System.EventHandler(this.frmAtt_Load);
            this.pnlCommonDetails.ResumeLayout(false);
            this.pnlCommonDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbcompany;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnSave_Print;
        public System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label29;
        public DevComponents.DotNetBar.Controls.GroupPanel pnlCommonDetails;
        internal System.Windows.Forms.CheckBox chkSelect;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNameSearch;
        private DevComponents.DotNetBar.LabelX LabelX17;
        public DevComponents.DotNetBar.Controls.DataGridViewX dbGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        private System.Windows.Forms.ComboBox cmbTag;
        private System.Windows.Forms.Button button1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Button button3;
    }
}