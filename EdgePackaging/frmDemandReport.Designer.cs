namespace EdgePackaging
{
    partial class frmDemandReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDemandReport));
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbcompany = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnPreview = new DevComponents.DotNetBar.ButtonX();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSubgroup = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MM/yyyy";
            this.dtDate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(133, 60);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(110, 25);
            this.dtDate.TabIndex = 0;
            this.dtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtDate_KeyPress);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(13, 60);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(81, 18);
            this.label29.TabIndex = 91;
            this.label29.Text = "From Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 22);
            this.label1.TabIndex = 93;
            this.label1.Text = "Demand Report";
            // 
            // cmbcompany
            // 
            this.cmbcompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbcompany.BackColor = System.Drawing.Color.White;
            this.cmbcompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcompany.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.FormattingEnabled = true;
            this.cmbcompany.Location = new System.Drawing.Point(133, 103);
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.Size = new System.Drawing.Size(298, 25);
            this.cmbcompany.TabIndex = 1;
            this.cmbcompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbcompany_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 95;
            this.label2.Text = "Location";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnClose.Location = new System.Drawing.Point(287, 253);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 46);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPreview.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnPreview.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Image = global::EdgePackaging.Properties.Resources.Preview;
            this.btnPreview.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnPreview.Location = new System.Drawing.Point(123, 253);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 45);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.label4.TabIndex = 101;
            this.label4.Text = "Sub Group *";
            // 
            // cmbSubgroup
            // 
            this.cmbSubgroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSubgroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubgroup.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubgroup.FormattingEnabled = true;
            this.cmbSubgroup.Items.AddRange(new object[] {
            "0",
            "5",
            "12",
            "15",
            "18"});
            this.cmbSubgroup.Location = new System.Drawing.Point(133, 183);
            this.cmbSubgroup.Name = "cmbSubgroup";
            this.cmbSubgroup.Size = new System.Drawing.Size(298, 25);
            this.cmbSubgroup.TabIndex = 100;
            this.cmbSubgroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSubgroup_KeyDown);
            this.cmbSubgroup.Validating += new System.ComponentModel.CancelEventHandler(this.cmbSubgroup_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(169, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 18);
            this.label5.TabIndex = 103;
            this.label5.Text = "Product";
            this.label5.Visible = false;
            // 
            // cmbProduct
            // 
            this.cmbProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProduct.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Items.AddRange(new object[] {
            "0",
            "5",
            "12",
            "15",
            "18"});
            this.cmbProduct.Location = new System.Drawing.Point(256, 12);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(298, 25);
            this.cmbProduct.TabIndex = 102;
            this.cmbProduct.Visible = false;
            this.cmbProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProduct_KeyDown);
            this.cmbProduct.Validating += new System.ComponentModel.CancelEventHandler(this.cmbProduct_Validating);
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd/MM/yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(321, 60);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(110, 25);
            this.dtToDate.TabIndex = 106;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(252, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 18);
            this.label3.TabIndex = 107;
            this.label3.Text = "To Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 18);
            this.label6.TabIndex = 108;
            this.label6.Text = "Demand Days *";
            // 
            // txtD
            // 
            this.txtD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtD.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtD.Location = new System.Drawing.Point(133, 140);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(114, 25);
            this.txtD.TabIndex = 109;
            this.txtD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtD_KeyDown);
            this.txtD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtD_KeyPress);
            // 
            // frmDemandReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 321);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSubgroup);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbcompany);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label29);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmDemandReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demand Report";
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
        public System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSubgroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbProduct;
        public System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtD;
    }
}