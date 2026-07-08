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
    public partial class frmUser : Form
    {
        private MainIndex mainForm = null;
        database_admin da = new database_admin();
    
  
        public frmUser(Form callingForm)
        {
            mainForm = callingForm as MainIndex;
            InitializeComponent();
        }
        UserMasterClass uc = new UserMasterClass();
     
        private void frmUser_Load(object sender, EventArgs e)
        {
            BindUserGrid();
            if (Form1.UserID==1)
            {
                da.fill_combo("select id,(name) as name from ledger_Master where type in ('Godown') order by name", cmbcompany, "ID", "Name");

            }
            else
            {
                da.fill_combo("select id,(name) as name from ledger_Master where type in ('Godown') and id=" + Convert.ToInt32(Form1.CompanyID) +" order by name", cmbcompany, "ID", "Name");

            }
            txtusername.Focus();
           

        }
      
        UserMasterClass userclass = new UserMasterClass();
        Form1 f1 = new Form1();
        public void BindUserGrid()
        {
            dgvUserMasterDetails.Columns.Clear();
            dgvUserMasterDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11.0F, FontStyle.Regular);
            DataGridViewColumn col1 = new DataGridViewImageButtonDeleteColumn();
            col1.HeaderText = "";
            col1.Name = "Delete";
            col1.Width = 35;
            DataGridViewColumn edit = new DataGridViewImageButtonEditColumn();
            edit.HeaderText = "";
            edit.Name = "Edit";
            edit.Width = 35;
            DataGridViewColumn select = new DataGridViewCheckBoxColumn();
            select.HeaderText = "";
            select.Name = "sel_rec";
            select.Width = 40;
            dgvUserMasterDetails.Columns.Add(select);
            dgvUserMasterDetails.Columns.Add(col1);
            dgvUserMasterDetails.Columns.Add(edit);
            DataSet ds = new DataSet();
            ds = userclass.UserMaster_GetTypeData(Form1.UserID);
            dgvUserMasterDetails.DataSource = ds.Tables[0];
            dgvUserMasterDetails.Columns["ID"].Visible = false;
            dgvUserMasterDetails.Columns["companyID"].Visible = false;
            dgvUserMasterDetails.Columns["Password"].Visible = false;
            dgvUserMasterDetails.Columns["godownid"].Visible = false;
            foreach (DataGridViewRow row in dgvUserMasterDetails.Rows)
            {

                row.Height = 42;
            }
            foreach (DataGridViewColumn c in dgvUserMasterDetails.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Pixel);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ClearData()
        {
            txtMob.Clear();
            txtname.Clear();
            txtusername.Clear();
            txtpassword.Clear();
            btnSave.Text = "&Save";
        }
        public static int id;
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
            txtusername.Enabled = true;
         
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //int companyid = Convert.ToInt32(da.value1("select  id from company_master where name ='" + cmbcompany.Text + "'"));
                int companyid = Convert.ToInt32(cmbcompany.SelectedValue);
                if (txtusername.Text == "")
                {
                    MessageBox.Show("You Must Have A Username", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtusername.Focus();
                    return;
                }
                if (txtname.Text == "")
                {
                    MessageBox.Show("You Must Have A Name", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtname.Focus();
                    return;
                }
                if (txtpassword.Text == "")
                {
                    MessageBox.Show("You Must Have A Password", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtpassword.Focus();
                    return;
                }
                if (cmbcompany.Text == "")
                {
                    MessageBox.Show("You Must Have A Company", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbcompany.Focus();
                    return;
                }
                DataSet rstemp=new DataSet();
                rstemp=da.dataset_ret("select companyid,type from ledger_master where id=" +Convert.ToInt32(cmbcompany.SelectedValue));
                int usertype = 0;
                if(rstemp.Tables[0].Rows[0]["type"].ToString()=="Godown")
                {
                    usertype = 1;
                }
                else if(rstemp.Tables[0].Rows[0]["type"].ToString()=="Shop")
                {
                    usertype = 2;
                }
                if (txtusername.Text != "" && txtpassword.Text != "" && txtname.Text != "" && cmbcompany.Text != "")
                {

                    if (btnSave.Text == "&Save")
                    {
                        int checkdup = AllCommonFunctions.Check_Duplicacy("User_Master", txtusername.Text);
                        if (checkdup == 0)
                        {
                            if(txtusername.Text.ToLower()=="admin")
                            {
                                usertype = 0;
                            }
                            id = 0;
                            bool flag = userclass.UserMaster_InsertUpdate(id, txtname.Text, txtusername.Text, txtpassword.Text, txtMob.Text,Convert.ToInt32(rstemp.Tables[0].Rows[0]["companyid"].ToString()), companyid,usertype);
                            if (flag)
                            {
                                MessageBox.Show("User Successfully Added", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                                ClearData();
                            }
                            else
                                MessageBox.Show("Data not saved");
                        }
                        else
                        {
                            MessageBox.Show("Duplicate Record Cannot Be Saved", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else if (btnSave.Text == "Update")
                    {
                        if (txtusername.Text.ToLower() == "admin")
                        {
                            usertype = 0;
                        }
                        bool flag = userclass.UserMaster_InsertUpdate(id, txtname.Text, txtusername.Text, txtpassword.Text, txtMob.Text,Convert.ToInt32(rstemp.Tables[0].Rows[0]["companyid"].ToString()), companyid,usertype);
                        if (flag)
                        {
                            MessageBox.Show("User Successfully Updated", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                            btnSave.Text = "&Save";
                            ClearData();
                            txtusername.Enabled = true;
                        }
                        else
                            MessageBox.Show("Data not saved");
                    }
                }

                else
                {
                    txtname.Focus();
                    //txtusername.BackColor = Color.Yellow;
                    //txtpassword.BackColor = Color.Yellow;                    
                }

                BindUserGrid();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {


            foreach (DataGridViewRow row in dgvUserMasterDetails.Rows)
            {
                if (row.Cells["Sel_rec"].Value != null)
                {
                    if ((bool)(row.Cells["Sel_rec"].Value) == true)
                    {
                        if (MessageBox.Show("Are you sure to Delete?","Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                        {
                            int id = Convert.ToInt32(dgvUserMasterDetails.Rows[row.Index].Cells["ID"].Value.ToString());

                            try
                            {
                                bool flag = userclass.UserMaster_Delete(id);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Failed");
                            }
                        }

                    }
                }
                BindUserGrid();
            }
        }
        private void dgvUserMasterDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvUserMasterDetails.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                try
                {
                    id = Convert.ToInt32(dgvUserMasterDetails.CurrentRow.Cells["ID"].Value);
                    txtname.Text = Convert.ToString(dgvUserMasterDetails.CurrentRow.Cells["Name"].Value);
                    txtusername.Text = Convert.ToString(dgvUserMasterDetails.CurrentRow.Cells["UserName"].Value);
                    txtpassword.Text = Convert.ToString(dgvUserMasterDetails.CurrentRow.Cells["Password"].Value);
                    txtMob.Text = Convert.ToString(dgvUserMasterDetails.CurrentRow.Cells["MobileNo"].Value);
                  cmbcompany.SelectedValue = Convert.ToInt32(dgvUserMasterDetails.CurrentRow.Cells["godownid"].Value);
                    txtusername.Enabled = false;

                    btnSave.Text = "Update";
                    txtname.Focus();
                    //pnlCommonDetails.Hide();
                }
                catch (Exception ex)
                {

                }

            }
            else if (e.ColumnIndex == dgvUserMasterDetails.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvUserMasterDetails.CurrentRow.Cells["ID"].Value);
                    int a = AllCommonFunctions.Check_Used("Username", id);
                    if (a > 0)
                    {
                        MessageBox.Show("This is already used. You can't delete this.");
                    }
                    else
                    {
                        if (MessageBox.Show("Are you sure to Delete?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                        {

                            bool flag = userclass.UserMaster_Delete(id);
                            if (flag)
                            {
                                MessageBox.Show("User Successfully Deleted", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                                BindUserGrid();
                            }
                            else
                            {
                                MessageBox.Show("Failed");
                            }
                        }
                    }


                }
                catch (Exception ex)
                {

                }

            }
        }

        private void frmUser_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

        private void txtMob_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '.')
            { e.Handled = true; return; }
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Delete || e.KeyChar == 8 || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void txtMob_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnamesearch_TextChanged(object sender, EventArgs e)
        {

            dgvUserMasterDetails.Columns.Clear();
            dgvUserMasterDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11.0F, FontStyle.Regular);
            DataGridViewColumn col1 = new DataGridViewImageButtonDeleteColumn();
            col1.HeaderText = "";
            col1.Name = "Delete";
            col1.Width = 35;
            DataGridViewColumn edit = new DataGridViewImageButtonEditColumn();
            edit.HeaderText = "";
            edit.Name = "Edit";
            edit.Width = 35;
            DataGridViewColumn select = new DataGridViewCheckBoxColumn();
            select.HeaderText = "";
            select.Name = "sel_rec";
            select.Width = 40;
            dgvUserMasterDetails.Columns.Add(select);
            dgvUserMasterDetails.Columns.Add(col1);
            dgvUserMasterDetails.Columns.Add(edit);
            DataSet ds = new DataSet();
            ds = userclass.UserMaster_GetDatasearch(txtnamesearch.Text,Form1.UserID);
            dgvUserMasterDetails.DataSource = ds.Tables[0];
            dgvUserMasterDetails.Columns["ID"].Visible = false;
            dgvUserMasterDetails.Columns["Password"].Visible = false;
            dgvUserMasterDetails.Columns["companyid"].Visible = false;
            dgvUserMasterDetails.Columns["godownid"].Visible = false;
            foreach (DataGridViewRow row in dgvUserMasterDetails.Rows)
            {

                row.Height = 42;
            }
            foreach (DataGridViewColumn c in dgvUserMasterDetails.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Pixel);
            }


        }

        private void txtnamesearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string intRowValue = "";
            foreach (DataGridViewRow row in dgvUserMasterDetails.Rows)
            {
                if (row.Cells["Sel_rec"].Value != null)
                {
                    if (Convert.ToBoolean(row.Cells["Sel_rec"].Value) == true)
                    {
                        if (intRowValue == "")
                        {
                            intRowValue = Convert.ToString(dgvUserMasterDetails.Rows[row.Index].Cells["id"].Value);
                        }
                        else
                        {
                            intRowValue = intRowValue + "," + Convert.ToString(dgvUserMasterDetails.Rows[row.Index].Cells["id"].Value);

                        }
                    }
                }

            }
            if (MessageBox.Show("Are you sure to Delete?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                int a = AllCommonFunctions.Check_Used("Username",Convert.ToInt32(intRowValue));
                if (a > 0)
                {
                    MessageBox.Show("This User Is In Use. You Cannot delet this user", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    da.insert_update_delete("delete from User_Master where id in (" + intRowValue + ")");
                }
            }

            else
            {
                return;
            }
            BindUserGrid();
        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
            {
                txtMob.Focus();
            }
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtpassword.Focus();
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtname.Focus();
            }
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbcompany.Focus();
            }
        }

        private void cmbcompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnSave.Focus();
            }
        }
        public void BindUserGridonsearch()
        {
            dgvUserMasterDetails.Columns.Clear();
            dgvUserMasterDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11.0F, FontStyle.Regular);
            DataGridViewColumn col1 = new DataGridViewImageButtonDeleteColumn();
            col1.HeaderText = "";
            col1.Name = "Delete";
            col1.Width = 35;
            DataGridViewColumn edit = new DataGridViewImageButtonEditColumn();
            edit.HeaderText = "";
            edit.Name = "Edit";
            edit.Width = 35;
            DataGridViewColumn select = new DataGridViewCheckBoxColumn();
            select.HeaderText = "";
            select.Name = "sel_rec";
            select.Width = 40;
            dgvUserMasterDetails.Columns.Add(select);
            dgvUserMasterDetails.Columns.Add(col1);
            dgvUserMasterDetails.Columns.Add(edit);
            DataSet ds = new DataSet();
            ds = userclass.UserMaster_GetTypeData(Form1.utype);
            dgvUserMasterDetails.DataSource = ds.Tables[0];
            dgvUserMasterDetails.Columns["ID"].Visible = false;
            dgvUserMasterDetails.Columns["Password"].Visible = false;
            dgvUserMasterDetails.Columns["godownid"].Visible = false;
            foreach (DataGridViewRow row in dgvUserMasterDetails.Rows)
            {

                row.Height = 42;
            }
            foreach (DataGridViewColumn c in dgvUserMasterDetails.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Pixel);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}