using DevComponents.DotNetBar;
using EdgePackingShared;
using EdgeVastra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EdgePack;

namespace EdgePackaging
{
    public partial class frmSelectCompany : Form
    {
        database_admin da = new database_admin();
        public frmSelectCompany()
        {
            InitializeComponent();
        }
        CompanyMasterClass companyclass = new CompanyMasterClass();
        private void frmSelectCompany_Load(object sender, EventArgs e)
        {
            ;
            try
            {
                label1.Text = "Welcome " + MainIndex.UserFullName;
                label2.Text = "Your default selected Company: " + MainIndex.CompanyName;
                dgvCompanyDetails.Columns.Clear();

                dgvCompanyDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11.0F, FontStyle.Bold);
              
                DataSet ds = new DataSet();
                ds = companyclass.Company_GetData();
                dgvCompanyDetails.DataSource = ds.Tables[0];
                dgvCompanyDetails.Columns["ID"].Visible = false;
                dgvCompanyDetails.Columns["Address1"].Visible = false;
                dgvCompanyDetails.Columns["Address2"].Visible = false;
                dgvCompanyDetails.Columns["Address3"].Visible = false;
                dgvCompanyDetails.Columns["State"].Visible = false;
                dgvCompanyDetails.Columns["S.N."].Visible = false;
                //Change cell font
                foreach (DataGridViewColumn c in dgvCompanyDetails.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Pixel);
                   
                }
                DataGridViewColumn column = dgvCompanyDetails.Columns[2];
                column.Width =350;
              column = dgvCompanyDetails.Columns[7];
                column.Width = 150;
                int rRow = 0;
              
                foreach (DataGridViewRow row in dgvCompanyDetails.Rows)
                {

                    row.Height = 30;
                   
                    if(Form1.CompanyID== Convert.ToInt32(row.Cells["ID"].Value))
                    {
                        dgvCompanyDetails.ClearSelection();
                       // dgvCompanyDetails.Rows[2].Selected = true;
                        
                    }
                }
                
                
                dgvCompanyDetails.RowsDefaultCellStyle.Font = new Font("Arial", 12.0F, FontStyle.Regular);
                btnOpen.Focus();
            }
            catch { }
        }

        

        

        private void btnOpen_Click(object sender, EventArgs e)
        {
            frmSelectFinYear frmselectfinyear = new frmSelectFinYear();
            this.Hide();
            frmselectfinyear.ShowDialog(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
                return;
            }
        }
    }
}
