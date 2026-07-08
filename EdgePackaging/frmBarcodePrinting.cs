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
    public partial class frmBarcodePrinting : Form
    {
        database_admin da = new database_admin();
        public frmBarcodePrinting()
        {

            InitializeComponent();
            da.fill_combo(" select 0 as id,'--Select Product--' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Master order by rtag,name", cmbProduct, "ID", "Name");
        }

        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back ))
                { e.Handled = true; }
                TextBox txtDecimal = sender as TextBox;
              
            }
            catch (Exception ex)
            {
            }
        }

        private void txtCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnPreview.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
      
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex == -1 && Convert.ToInt32(cmbProduct.SelectedValue) == 0)
            {
                MessageBox.Show("Please specify product.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbProduct.Focus();
                return;
            }
            if(Convert.ToInt32(txtCount.Text)==0)
            {
                MessageBox.Show("Please specify count of barcode printing.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCount.Focus();
                return;
            }
            DataSet ds = new DataSet();
            int a = Convert.ToInt32(cmbProduct.SelectedValue);

            ds = da.dataset_ret("select im.code, im.Name as ProductName,im.rate from  Inventory_Master as im  where im.id=" + a);
            int loop = 0;
        
            for (loop = 0; loop < Convert.ToInt32( txtCount.Text); loop++)
            {
               
                    da.insert_update_delete("insert into barcode_print_table(rproduct,barcode,salerate,companyid) values('" +Form1.SingleCode( ds.Tables[0].Rows[0]["ProductName"].ToString()) + "','" + ds.Tables[0].Rows[0]["code"].ToString() + "'," + Convert.ToDouble(ds.Tables[0].Rows[0]["rate"].ToString()) + "," + Form1.CompanyID + ")");
               
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                frmCrystalReport.ReportName = "Barcode";
                frmCrystalReport obj_report = new frmCrystalReport();
                obj_report.ShowDialog();

            }
        }

        private void cmbProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCount.Focus();
            }
        }

        private void cmbProduct_Validating(object sender, CancelEventArgs e)
        {
            if (cmbProduct.Text.Trim() != "")
            {
                if (cmbProduct.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select valid product.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbProduct.Focus();
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex == -1 && Convert.ToInt32(cmbProduct.SelectedValue) == 0)
            {
                MessageBox.Show("Please specify product.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbProduct.Focus();
                return;
            }
            if (Convert.ToInt32(txtCount.Text) == 0)
            {
                MessageBox.Show("Please specify count of barcode printing.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCount.Focus();
                return;
            }
            DataSet ds = new DataSet();
            int a = Convert.ToInt32(cmbProduct.SelectedValue);

            ds = da.dataset_ret("select im.maxlevel as code, im.Name as ProductName,im.rate from  Inventory_Master as im  where im.id=" + a);
            int loop = 0;

            for (loop = 0; loop < Convert.ToInt32(txtCount.Text); loop++)
            {

                da.insert_update_delete("insert into barcode_print_table(rproduct,barcode,salerate,companyid) values('" + Form1.SingleCode(ds.Tables[0].Rows[0]["ProductName"].ToString()) + "','" + ds.Tables[0].Rows[0]["code"].ToString() + "'," + Convert.ToDouble(ds.Tables[0].Rows[0]["rate"].ToString()) + "," + Form1.CompanyID + ")");

            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                frmCrystalReport.ReportName = "Barcode1";
                frmCrystalReport obj_report = new frmCrystalReport();
                obj_report.ShowDialog();

            }
        }
    }
}
