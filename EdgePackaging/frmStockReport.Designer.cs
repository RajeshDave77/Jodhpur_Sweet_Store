namespace EdgePackaging
{
    partial class frmStockReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockReport));
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbcompany = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSubgroup = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.optProduct = new System.Windows.Forms.RadioButton();
            this.optSubGroup = new System.Windows.Forms.RadioButton();
            this.optSublocation = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSubLocation = new System.Windows.Forms.ComboBox();
            this.optS1 = new System.Windows.Forms.RadioButton();
            this.optL1 = new System.Windows.Forms.RadioButton();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnPreview = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.optB1 = new System.Windows.Forms.RadioButton();
            this.cmbPri = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MM/yyyy";
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
            this.label1.Size = new System.Drawing.Size(130, 22);
            this.label1.TabIndex = 93;
            this.label1.Text = "Stock Report";
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
            this.cmbcompany.Validating += new System.ComponentModel.CancelEventHandler(this.cmbcompany_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 95;
            this.label2.Text = "P.S.Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 184);
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
            this.cmbSubgroup.Location = new System.Drawing.Point(123, 181);
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
            this.label5.Location = new System.Drawing.Point(38, 229);
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
            this.cmbProduct.Location = new System.Drawing.Point(123, 226);
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
            this.optProduct.Location = new System.Drawing.Point(118, 275);
            this.optProduct.Name = "optProduct";
            this.optProduct.Size = new System.Drawing.Size(115, 21);
            this.optProduct.TabIndex = 104;
            this.optProduct.TabStop = true;
            this.optProduct.Text = "Product Wise";
            this.optProduct.UseVisualStyleBackColor = true;
            // 
            // optSubGroup
            // 
            this.optSubGroup.AutoSize = true;
            this.optSubGroup.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSubGroup.Location = new System.Drawing.Point(360, 10);
            this.optSubGroup.Name = "optSubGroup";
            this.optSubGroup.Size = new System.Drawing.Size(134, 21);
            this.optSubGroup.TabIndex = 105;
            this.optSubGroup.Text = "Sub Group Wise";
            this.optSubGroup.UseVisualStyleBackColor = true;
            this.optSubGroup.Visible = false;
            // 
            // optSublocation
            // 
            this.optSublocation.AutoSize = true;
            this.optSublocation.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSublocation.Location = new System.Drawing.Point(273, 275);
            this.optSublocation.Name = "optSublocation";
            this.optSublocation.Size = new System.Drawing.Size(149, 21);
            this.optSublocation.TabIndex = 106;
            this.optSublocation.Text = "Sub Location Wise";
            this.optSublocation.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 18);
            this.label7.TabIndex = 109;
            this.label7.Text = "S.S.Location";
            // 
            // cmbSubLocation
            // 
            this.cmbSubLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSubLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubLocation.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubLocation.FormattingEnabled = true;
            this.cmbSubLocation.Location = new System.Drawing.Point(123, 142);
            this.cmbSubLocation.Name = "cmbSubLocation";
            this.cmbSubLocation.Size = new System.Drawing.Size(295, 25);
            this.cmbSubLocation.TabIndex = 108;
            this.cmbSubLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSubLocation_KeyDown);
            this.cmbSubLocation.Validating += new System.ComponentModel.CancelEventHandler(this.cmbSubLocation_Validating);
            // 
            // optS1
            // 
            this.optS1.AutoSize = true;
            this.optS1.Checked = true;
            this.optS1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optS1.Location = new System.Drawing.Point(6, 3);
            this.optS1.Name = "optS1";
            this.optS1.Size = new System.Drawing.Size(92, 21);
            this.optS1.TabIndex = 110;
            this.optS1.TabStop = true;
            this.optS1.Text = "Small Unit";
            this.optS1.UseVisualStyleBackColor = true;
            // 
            // optL1
            // 
            this.optL1.AutoSize = true;
            this.optL1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optL1.Location = new System.Drawing.Point(111, 3);
            this.optL1.Name = "optL1";
            this.optL1.Size = new System.Drawing.Size(75, 21);
            this.optL1.TabIndex = 111;
            this.optL1.Text = "Lot Unit";
            this.optL1.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnClose.Location = new System.Drawing.Point(273, 319);
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
            this.btnPreview.Location = new System.Drawing.Point(121, 320);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 45);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.optB1);
            this.panel1.Controls.Add(this.optS1);
            this.panel1.Controls.Add(this.optL1);
            this.panel1.Location = new System.Drawing.Point(249, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 33);
            this.panel1.TabIndex = 112;
            // 
            // optB1
            // 
            this.optB1.AutoSize = true;
            this.optB1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optB1.Location = new System.Drawing.Point(205, 4);
            this.optB1.Name = "optB1";
            this.optB1.Size = new System.Drawing.Size(85, 21);
            this.optB1.TabIndex = 112;
            this.optB1.Text = "Both Unit";
            this.optB1.UseVisualStyleBackColor = true;
            // 
            // cmbPri
            // 
            this.cmbPri.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPri.BackColor = System.Drawing.Color.White;
            this.cmbPri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPri.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPri.FormattingEnabled = true;
            this.cmbPri.Items.AddRange(new object[] {
            "All",
            "A",
            "B",
            "C",
            "D"});
            this.cmbPri.Location = new System.Drawing.Point(495, 229);
            this.cmbPri.Name = "cmbPri";
            this.cmbPri.Size = new System.Drawing.Size(62, 25);
            this.cmbPri.TabIndex = 113;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(430, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 114;
            this.label3.Text = "Priority";
            // 
            // frmStockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 383);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPri);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbSubLocation);
            this.Controls.Add(this.optSublocation);
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
            this.Name = "frmStockReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Report";
            this.Load += new System.EventHandler(this.frmStockReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.RadioButton optSublocation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbSubLocation;
        private System.Windows.Forms.RadioButton optS1;
        private System.Windows.Forms.RadioButton optL1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton optB1;
        private System.Windows.Forms.ComboBox cmbPri;
        private System.Windows.Forms.Label label3;
    }
}