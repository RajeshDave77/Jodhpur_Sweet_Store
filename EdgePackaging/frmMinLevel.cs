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
    public partial class frmMinLevel : Form
    {
        public frmMinLevel()
        {
            InitializeComponent();
        }
        database_admin da = new database_admin();
        int rcheck = 0;
        private void frmMinLevel_Load(object sender, EventArgs e)
        {
            rcheck = 1;
            da.fill_combo("select id,(name)as name from ledger_Master where type in ('Godown') order by id", cmbcompany, "ID", "Name");
            if (Convert.ToInt32(Form1.UserID) != 1)
            {
                cmbcompany.SelectedValue = Form1.CompanyID;
                cmbcompany.Enabled = false;
            }

            da.fill_combo(" select 0 as id,'--Select--' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Master order by rtag,name", cmbProduct, "ID", "Name");
            if(Form1.PID>0)
            {
                cmbProduct.SelectedValue = Form1.PID;
                lblUnit.Text = Form1.PUnit;
            }
          
            cmbProduct.Focus();
            rcheck = 0;
        }

        private void cmbcompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode==Keys.Tab)
            {
                cmbProduct.Focus();
            }
        }

        private void cmbProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtD.Focus();
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

        private void txtD_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
                { e.Handled = true; }

            }
            catch (Exception ex)
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form1.PID = 0;
            this.Close();
        }

        private void txtD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnSave_Print.Focus();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to reset fields?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            BlankField();
            cmbProduct.Focus();
        }
        private void BlankField()
        {
            rcheck = 1;
            cmbcompany.SelectedValue = Form1.CompanyID;
            cmbProduct.SelectedValue = Form1.PID;
            txtD.Text = "";
            lblUnit.Text = "";
            txtD.Tag = "";
            rcheck = 0;
        }
        private void Show()
        {
            DataSet rstemp = new DataSet();
            lblUnit.Text = "";
            if(Convert.ToInt32(cmbProduct.SelectedValue)==0) {return;}
            txtD.Text = "";
            txtD.Tag = "";
            rstemp = da.dataset_ret("select minlevel,id from minlevel_entry where companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " and productid=" + Convert.ToInt32(cmbProduct.SelectedValue));
            if(rstemp.Tables[0].Rows.Count>0)
            {
                txtD.Text = rstemp.Tables[0].Rows[0]["minlevel"].ToString();
                txtD.Tag = rstemp.Tables[0].Rows[0]["id"].ToString();
            }
            rstemp.Dispose();
            rstemp.Tables.Clear();

            rstemp = da.dataset_ret("select unit from inventory_master where id=" + Convert.ToInt32(cmbProduct.SelectedValue));
            lblUnit.Text = rstemp.Tables[0].Rows[0]["unit"].ToString();
        }

        private void cmbcompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            Show();
        }

        private void cmbProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            Show();
        }

        private void btnSave_Print_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(cmbProduct.SelectedValue)==0)
            {
                MessageBox.Show("Please select product.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbProduct.Focus();
                return;
            }
            if(cmbProduct.Text=="")
            {
                MessageBox.Show("Please select product.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbProduct.Focus();
                return;
            }
            if (txtD.Text == "")
            {
                MessageBox.Show("Please specify min.level.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtD.Focus();
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            string dd = "";
            if(txtD.Tag!=null)
            {
                dd = txtD.Tag.ToString();
            }
            if(dd=="")
            {
                da.insert_update_delete("insert into minlevel_entry(productid,minlevel,companyid,userid)values(" + Convert.ToInt32(cmbProduct.SelectedValue) + "," + Convert.ToInt32(txtD.Text) + "," + Convert.ToInt32(cmbcompany.SelectedValue) + "," + Form1.UserID+")");

            }
            else
            {
                da.insert_update_delete("update minlevel_entry set productid="+Convert.ToInt32(cmbProduct.SelectedValue) +",minlevel="+Convert.ToInt32(txtD.Text)+",companyid="+Convert.ToInt32(cmbcompany.SelectedValue)+" where id="+Convert.ToInt32(txtD.Tag));
            }

            BlankField();
            this.Cursor = Cursors.Default;
            cmbProduct.Focus();
        }
    }
}
