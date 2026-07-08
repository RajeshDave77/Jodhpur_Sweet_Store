namespace EdgePackaging
{
    partial class frmDayEnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDayEnd));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbcompany = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnPreview = new DevComponents.DotNetBar.ButtonX();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dbGridPayMode = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDayEnd = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dbGridPayModeBill = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbGridPayModeTotal = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridPayMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridPayModeBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridPayModeTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(617, 11);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(110, 25);
            this.dtFromDate.TabIndex = 0;
            this.dtFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtFromDate_KeyPress);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(530, 11);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(81, 18);
            this.label29.TabIndex = 91;
            this.label29.Text = "From Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 24);
            this.label1.TabIndex = 93;
            this.label1.Text = "END OF DAY";
            // 
            // cmbcompany
            // 
            this.cmbcompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbcompany.BackColor = System.Drawing.Color.White;
            this.cmbcompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcompany.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.FormattingEnabled = true;
            this.cmbcompany.Location = new System.Drawing.Point(226, 11);
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.Size = new System.Drawing.Size(298, 25);
            this.cmbcompany.TabIndex = 2;
            this.cmbcompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbcompany_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(147, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 95;
            this.label2.Text = "Company";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.LightCoral;
            this.btnClose.CausesValidation = false;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnClose.Location = new System.Drawing.Point(739, 377);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 55);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPreview.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnPreview.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.White;
            this.btnPreview.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnPreview.Location = new System.Drawing.Point(581, 377);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(116, 55);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.Text = "&Print";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd/MM/yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(805, 11);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(110, 25);
            this.dtToDate.TabIndex = 1;
            this.dtToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtToDate_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(735, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 18);
            this.label3.TabIndex = 97;
            this.label3.Text = "To Date";
            // 
            // dbGridPayMode
            // 
            this.dbGridPayMode.AllowUserToAddRows = false;
            this.dbGridPayMode.AllowUserToDeleteRows = false;
            this.dbGridPayMode.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbGridPayMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dbGridPayMode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(186)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbGridPayMode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dbGridPayMode.ColumnHeadersHeight = 30;
            this.dbGridPayMode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dbGridPayMode.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dbGridPayMode.EnableHeadersVisualStyles = false;
            this.dbGridPayMode.Location = new System.Drawing.Point(25, 66);
            this.dbGridPayMode.Name = "dbGridPayMode";
            this.dbGridPayMode.ReadOnly = true;
            this.dbGridPayMode.RowHeadersVisible = false;
            this.dbGridPayMode.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbGridPayMode.RowTemplate.Height = 40;
            this.dbGridPayMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dbGridPayMode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dbGridPayMode.ShowEditingIcon = false;
            this.dbGridPayMode.Size = new System.Drawing.Size(341, 170);
            this.dbGridPayMode.TabIndex = 113;
            this.dbGridPayMode.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbGridPayMode_CellClick);
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn5.HeaderText = ".";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 170;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn6.HeaderText = "";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // btnDayEnd
            // 
            this.btnDayEnd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDayEnd.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnDayEnd.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnDayEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDayEnd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDayEnd.ForeColor = System.Drawing.Color.White;
            this.btnDayEnd.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.btnDayEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnDayEnd.Image")));
            this.btnDayEnd.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnDayEnd.Location = new System.Drawing.Point(404, 377);
            this.btnDayEnd.Name = "btnDayEnd";
            this.btnDayEnd.Size = new System.Drawing.Size(125, 55);
            this.btnDayEnd.TabIndex = 114;
            this.btnDayEnd.Text = "&Day End";
            this.btnDayEnd.Click += new System.EventHandler(this.btnDayEnd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(935, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 31);
            this.btnSearch.TabIndex = 115;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dbGridPayModeBill
            // 
            this.dbGridPayModeBill.AllowUserToAddRows = false;
            this.dbGridPayModeBill.AllowUserToDeleteRows = false;
            this.dbGridPayModeBill.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbGridPayModeBill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dbGridPayModeBill.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(186)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbGridPayModeBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dbGridPayModeBill.ColumnHeadersHeight = 30;
            this.dbGridPayModeBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dbGridPayModeBill.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dbGridPayModeBill.EnableHeadersVisualStyles = false;
            this.dbGridPayModeBill.Location = new System.Drawing.Point(25, 262);
            this.dbGridPayModeBill.Name = "dbGridPayModeBill";
            this.dbGridPayModeBill.ReadOnly = true;
            this.dbGridPayModeBill.RowHeadersVisible = false;
            this.dbGridPayModeBill.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbGridPayModeBill.RowTemplate.Height = 40;
            this.dbGridPayModeBill.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dbGridPayModeBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dbGridPayModeBill.ShowEditingIcon = false;
            this.dbGridPayModeBill.Size = new System.Drawing.Size(341, 170);
            this.dbGridPayModeBill.TabIndex = 118;
            this.dbGridPayModeBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbGridPayModeBill_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Bill";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 170;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dbGridPayModeTotal
            // 
            this.dbGridPayModeTotal.AllowUserToAddRows = false;
            this.dbGridPayModeTotal.AllowUserToDeleteRows = false;
            this.dbGridPayModeTotal.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbGridPayModeTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dbGridPayModeTotal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(186)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbGridPayModeTotal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dbGridPayModeTotal.ColumnHeadersHeight = 30;
            this.dbGridPayModeTotal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dbGridPayModeTotal.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dbGridPayModeTotal.EnableHeadersVisualStyles = false;
            this.dbGridPayModeTotal.Location = new System.Drawing.Point(507, 66);
            this.dbGridPayModeTotal.Name = "dbGridPayModeTotal";
            this.dbGridPayModeTotal.ReadOnly = true;
            this.dbGridPayModeTotal.RowHeadersVisible = false;
            this.dbGridPayModeTotal.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbGridPayModeTotal.RowTemplate.Height = 40;
            this.dbGridPayModeTotal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dbGridPayModeTotal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dbGridPayModeTotal.ShowEditingIcon = false;
            this.dbGridPayModeTotal.Size = new System.Drawing.Size(341, 193);
            this.dbGridPayModeTotal.TabIndex = 119;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "Total Of Day";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 170;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn4.HeaderText = "";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // frmDayEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 474);
            this.Controls.Add(this.dbGridPayModeTotal);
            this.Controls.Add(this.dbGridPayModeBill);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDayEnd);
            this.Controls.Add(this.dbGridPayMode);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbcompany);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label29);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmDayEnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "END OF DAY";
            this.Load += new System.EventHandler(this.frmDayEnd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbGridPayMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridPayModeBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridPayModeTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbcompany;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnPreview;
        public System.Windows.Forms.DateTimePicker dtFromDate;
        public System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dbGridPayMode;
        private DevComponents.DotNetBar.ButtonX btnDayEnd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridView dbGridPayModeBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView dbGridPayModeTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}