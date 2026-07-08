namespace EdgePackaging
{
    partial class frmMinStockReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMinStockReport));
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
            this.optProduct = new System.Windows.Forms.RadioButton();
            this.optSubGroup = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbParty = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MM/yyyy";
            this.dtDate.Enabled = false;
            this.dtDate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(123, 60);
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
            this.label29.Location = new System.Drawing.Point(33, 60);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(84, 18);
            this.label29.TabIndex = 91;
            this.label29.Text = "As on Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 22);
            this.label1.TabIndex = 93;
            this.label1.Text = "Inventory Report";
            // 
            // cmbcompany
            // 
            this.cmbcompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbcompany.BackColor = System.Drawing.Color.White;
            this.cmbcompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcompany.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.FormattingEnabled = true;
            this.cmbcompany.Location = new System.Drawing.Point(123, 103);
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
            this.label2.Location = new System.Drawing.Point(33, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 95;
            this.label2.Text = "Company";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnClose.Location = new System.Drawing.Point(288, 355);
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
            this.btnPreview.Location = new System.Drawing.Point(117, 355);
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
            this.label4.Location = new System.Drawing.Point(32, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 101;
            this.label4.Text = "Sub Group";
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
            this.cmbSubgroup.Location = new System.Drawing.Point(123, 146);
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
            this.label5.Location = new System.Drawing.Point(36, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 18);
            this.label5.TabIndex = 103;
            this.label5.Text = "Product";
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
            this.cmbProduct.Location = new System.Drawing.Point(123, 191);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(298, 25);
            this.cmbProduct.TabIndex = 102;
            this.cmbProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProduct_KeyDown);
            this.cmbProduct.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbProduct_PreviewKeyDown);
            this.cmbProduct.Validating += new System.ComponentModel.CancelEventHandler(this.cmbProduct_Validating);
            // 
            // optProduct
            // 
            this.optProduct.AutoSize = true;
            this.optProduct.Checked = true;
            this.optProduct.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optProduct.Location = new System.Drawing.Point(123, 298);
            this.optProduct.Name = "optProduct";
            this.optProduct.Size = new System.Drawing.Size(96, 21);
            this.optProduct.TabIndex = 104;
            this.optProduct.TabStop = true;
            this.optProduct.Text = "All Product";
            this.optProduct.UseVisualStyleBackColor = true;
            // 
            // optSubGroup
            // 
            this.optSubGroup.AutoSize = true;
            this.optSubGroup.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSubGroup.Location = new System.Drawing.Point(261, 298);
            this.optSubGroup.Name = "optSubGroup";
            this.optSubGroup.Size = new System.Drawing.Size(145, 21);
            this.optSubGroup.TabIndex = 105;
            this.optSubGroup.Text = "Min. Level Product";
            this.optSubGroup.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 18);
            this.label6.TabIndex = 107;
            this.label6.Text = "Supplier";
            // 
            // cmbParty
            // 
            this.cmbParty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbParty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbParty.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParty.FormattingEnabled = true;
            this.cmbParty.Items.AddRange(new object[] {
            "0",
            "5",
            "12",
            "15",
            "18"});
            this.cmbParty.Location = new System.Drawing.Point(122, 233);
            this.cmbParty.Name = "cmbParty";
            this.cmbParty.Size = new System.Drawing.Size(298, 25);
            this.cmbParty.TabIndex = 106;
            this.cmbParty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbParty_KeyDown);
            this.cmbParty.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbParty_PreviewKeyDown);
            this.cmbParty.Validating += new System.ComponentModel.CancelEventHandler(this.cmbParty_Validating);
            // 
            // frmMinStockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 427);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbParty);
            this.Controls.Add(this.optSubGroup);
            this.Controls.Add(this.optProduct);
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
            this.Name = "frmMinStockReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Report";
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
        private System.Windows.Forms.RadioButton optProduct;
        private System.Windows.Forms.RadioButton optSubGroup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbParty;
    }
}