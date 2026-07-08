namespace EdgePackaging
{
    partial class frmSalary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalary));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX17 = new DevComponents.DotNetBar.LabelX();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.cmbAll = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.dbGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbcompany = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Attendance Report";
            // 
            // txtNameSearch
            // 
            // 
            // 
            // 
            this.txtNameSearch.Border.Class = "TextBoxBorder";
            this.txtNameSearch.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSearch.Location = new System.Drawing.Point(318, 62);
            this.txtNameSearch.MaxLength = 100;
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(129, 25);
            this.txtNameSearch.TabIndex = 92;
            // 
            // LabelX17
            // 
            this.LabelX17.BackColor = System.Drawing.Color.Transparent;
            this.LabelX17.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX17.ForeColor = System.Drawing.Color.Black;
            this.LabelX17.Location = new System.Drawing.Point(318, 40);
            this.LabelX17.Name = "LabelX17";
            this.LabelX17.Size = new System.Drawing.Size(129, 22);
            this.LabelX17.TabIndex = 93;
            this.LabelX17.Text = "Search By Name";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(190, 61);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(87, 25);
            this.cmbYear.TabIndex = 91;
            // 
            // LabelX1
            // 
            this.LabelX1.AutoSize = true;
            this.LabelX1.BackColor = System.Drawing.Color.Transparent;
            this.LabelX1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelX1.ForeColor = System.Drawing.Color.Black;
            this.LabelX1.Location = new System.Drawing.Point(28, 38);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(164, 20);
            this.LabelX1.TabIndex = 90;
            this.LabelX1.Text = "Select  Month && Year";
            // 
            // cmbAll
            // 
            this.cmbAll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAll.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAll.FormattingEnabled = true;
            this.cmbAll.Items.AddRange(new object[] {
            "--Select--",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbAll.Location = new System.Drawing.Point(28, 61);
            this.cmbAll.Name = "cmbAll";
            this.cmbAll.Size = new System.Drawing.Size(156, 25);
            this.cmbAll.TabIndex = 89;
            this.cmbAll.SelectedIndexChanged += new System.EventHandler(this.cmbAll_SelectedIndexChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Blue;
            this.Label2.Location = new System.Drawing.Point(25, 100);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(167, 14);
            this.Label2.TabIndex = 94;
            this.Label2.Text = "Staff Attendance Details";
            // 
            // dbGrid
            // 
            this.dbGrid.AllowUserToAddRows = false;
            this.dbGrid.AllowUserToDeleteRows = false;
            this.dbGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dbGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dbGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            this.dbGrid.Location = new System.Drawing.Point(28, 126);
            this.dbGrid.Name = "dbGrid";
            this.dbGrid.ReadOnly = true;
            this.dbGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dbGrid.RowHeadersWidth = 52;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dbGrid.RowTemplate.Height = 32;
            this.dbGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dbGrid.Size = new System.Drawing.Size(689, 287);
            this.dbGrid.TabIndex = 95;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnClose.Location = new System.Drawing.Point(605, 53);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 33);
            this.btnClose.TabIndex = 119;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(243, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 121;
            this.label3.Text = "Location";
            // 
            // cmbcompany
            // 
            this.cmbcompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbcompany.BackColor = System.Drawing.Color.White;
            this.cmbcompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcompany.Enabled = false;
            this.cmbcompany.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.FormattingEnabled = true;
            this.cmbcompany.Location = new System.Drawing.Point(318, 9);
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.Size = new System.Drawing.Size(298, 25);
            this.cmbcompany.TabIndex = 120;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(474, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 33);
            this.button1.TabIndex = 122;
            this.button1.Text = "&Preview";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(742, 434);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbcompany);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dbGrid);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtNameSearch);
            this.Controls.Add(this.LabelX17);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.LabelX1);
            this.Controls.Add(this.cmbAll);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmSalary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance Report";
            this.Load += new System.EventHandler(this.frmSalary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNameSearch;
        private DevComponents.DotNetBar.LabelX LabelX17;
        private System.Windows.Forms.ComboBox cmbYear;
        private DevComponents.DotNetBar.LabelX LabelX1;
        private System.Windows.Forms.ComboBox cmbAll;
        public System.Windows.Forms.Label Label2;
        public DevComponents.DotNetBar.Controls.DataGridViewX dbGrid;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbcompany;
        private System.Windows.Forms.Button button1;
    }
}