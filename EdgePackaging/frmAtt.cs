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
    public partial class frmAtt : Form
    {
        public frmAtt()
        {
            InitializeComponent();
        }
        database_admin da = new database_admin();
        int rcheck = 0;
        private void frmAtt_Load(object sender, EventArgs e)
        {
            rcheck = 1;
            da.fill_combo("select id,(name)as name from ledger_Master where type in ('Godown','Shop') order by id", cmbcompany, "ID", "Name");
            if (Convert.ToInt32(Form1.UserID) != 1)
            {
                cmbcompany.SelectedValue = Form1.CompanyID;
                cmbcompany.Enabled = false;
            }

            dtDate.Focus();
            cmbTag.SelectedIndex = 0;
            Show();
            rcheck = 0;
        }

        private void cmbcompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode==Keys.Tab)
            {
                dtDate.Focus();
            }
        }

      

        private void txtD_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtD_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

      
        private void Show()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet rstemp = new DataSet();
                string rWhere = "";
                if (txtNameSearch.Text.Trim() != "")
                {
                    rWhere = " and name like '%" + txtNameSearch.Text + "%' ";
                }
                rstemp = da.dataset_ret("select a.id,a.scode,a.Name,isnull(b.att,'') as Status from ((select id,scode,name from ledger_master where type='Staff' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " " + rWhere + ") as a left join (select staffid,att from Attendance where locationid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " and attdate='" + dtDate.Value.ToString("yyyy-MM-dd") + "') as b on a.id=b.staffid) order by a.name");
                dbGrid.DataSource = rstemp.Tables[0];
                int intloop = 0;
              
                dbGrid.Columns["id"].Visible = false;
                dbGrid.Columns["scode"].Visible = false;
                for (intloop = 0; intloop < dbGrid.Rows.Count; intloop++)
                {
                    //if (Convert.ToInt16(dbGrid.Rows[intloop].Cells["att"].Value.ToString()) == 1)
                    //{
                    //    dbGrid.Rows[intloop].Cells["Column1"].Value = true;
                    //}
                    //else
                    //{
                    //    dbGrid.Rows[intloop].Cells["Column1"].Value = false;
                    //}
                    dbGrid.Rows[intloop].Cells["Column1"].Value = true;
                    dbGrid.Rows[intloop].HeaderCell.Value = Convert.ToString(intloop + 1);
                }
                this.Cursor = Cursors.Default;
            }
           catch
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cmbcompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            Show();
        }

       

        private void btnSave_Print_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            int intRow = 0;
            string rString = "";
          int intl=0;
            string staffid = "";
            foreach (DataGridViewRow row in dbGrid.Rows)
            {
                intl+=1;
                if( row.Cells["status"].Value.ToString()=="")
                {
                   intRow=1;
                    break;
                }
                //if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value) == true)
                //{
                //    intRow = 1;
                //}
                //else
                //{
                //    intRow = 0;
                //}
                if(rString=="")
                {
                    staffid = row.Cells["id"].Value.ToString();
                    rString = "(" + Convert.ToInt32(row.Cells["id"].Value.ToString()) + ",'" + Form1.SingleCode(row.Cells["name"].Value.ToString()) + "', '" + dtDate.Value.ToString("yyyy-MM-dd") + "','" + row.Cells["status"].Value.ToString() + "','" + Form1.SingleCode(row.Cells["scode"].Value.ToString()) + "'," + Convert.ToInt32(cmbcompany.SelectedValue) + " )";
                }
                else
                {
                    staffid =staffid +"," + row.Cells["id"].Value.ToString();
                    rString = rString + "," + "(" + Convert.ToInt32(row.Cells["id"].Value.ToString()) + ",'" + Form1.SingleCode(row.Cells["name"].Value.ToString()) + "', '" + dtDate.Value.ToString("yyyy-MM-dd") + "','" + row.Cells["status"].Value.ToString() + "','" + Form1.SingleCode(row.Cells["scode"].Value.ToString()) + "'," + Convert.ToInt32(cmbcompany.SelectedValue) + " )";
                }
            }
            if(intRow==1)
            {
                MessageBox.Show("Please set staff attendance status at Row No. "+intl, "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(rString!="")
            {
                da.insert_update_delete("delete from attendance where staffid in (" + staffid + ") and attdate='"+dtDate.Value.ToString("yyyy-MM-dd")+"' ");
                da.insert_update_delete("insert into attendance(staffid,name,attdate,att,staffcode,locationid) values " + rString);
            }
            this.Cursor = Cursors.Default;
            MessageBox.Show(dtDate.Value.ToString("dd/MM/yyyy")+" Attendance Updated Successfully.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dtDate.Focus();
        }

        private void dtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            Show();
        }

        private void chkSelect_Click(object sender, EventArgs e)
        {
            if (chkSelect.Checked == false)
            {
                foreach (DataGridViewRow row in dbGrid.Rows)
                {
                    row.Cells[0].Value = false;
                }

            }
            else
            {
                foreach (DataGridViewRow row in dbGrid.Rows)
                {
                    row.Cells[0].Value = true;
                }

            }
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            if(rcheck==1)
            {
                return;
            }
            Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int intloop = 0;
            for (intloop = 0; intloop < dbGrid.Rows.Count; intloop++)
            {
                if (dbGrid.Rows[intloop].Cells[0].Value != null && Convert.ToBoolean(dbGrid.Rows[intloop].Cells[0].Value) == true)
                {
                    dbGrid.Rows[intloop].Cells["status"].Value = cmbTag.Text;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int intloop = 0;
            for (intloop = 0; intloop < dbGrid.Rows.Count; intloop++)
            {
                    dbGrid.Rows[intloop].Cells["Column1"].Value = true;
                    dbGrid.Rows[intloop].Cells["status"].Value = "";
            }
        }

        private void dbGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dbGrid.Rows[e.RowIndex].ReadOnly = true;
      if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                dbGrid.Rows[e.RowIndex].ReadOnly = true;
            }
            else
            {
                dbGrid.Rows[e.RowIndex].ReadOnly = false;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSalary frmsalary = new frmSalary();
            frmsalary.Show();
        }
    }
}
