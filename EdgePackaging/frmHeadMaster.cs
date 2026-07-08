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
    public partial class frmHeadMaster : Form
    {
        private MainIndex mainForm = null;
        public frmHeadMaster(Form callingForm)
        {
            mainForm = callingForm as MainIndex;
            InitializeComponent();
        }
        public static int id;
        public static int companyid=CompanyMasterClass.CompanyID;
        HeadMasterClass headclass = new HeadMasterClass();
        database_admin da = new database_admin();
        
        public void ClearData()
        {
            txtName.Clear();
            
            txtName.Focus();
            BindHeadDetailGrid();
        }
        private void btnSave_Click(object sender, EventArgs e)
        
        {
            try
            {
                if (txtName.Text=="")
                {
                    MessageBox.Show("Name Can't be Empty.");
                    txtName.Focus();
                    return;

                }

               
                Int32  idf1 = 0;
                idf1 =Convert.ToInt32( da.value1("select ID from AccountHead_Master where Name like '"+cmbParentHead.Text+"'"));
           //     idf1 = Convert.ToInt32(txtParent.Tag);
                if (idf1==0)
                {
                    MessageBox.Show("Parent Head Can't be Empty.");
                    cmbParentHead.Focus();
                    return;

                }




              //  if(txtName.Text=="" || txtParent.Text=="")
              
                //{
                    if (btnSave.Text == "&Save")
                    {
                        int checkdup = AllCommonFunctions.Check_Duplicacy("AccountHead_Master", txtName.Text);
                        if (checkdup == 0)
                        {
                            id = 0;
                            bool flag = headclass.Head_InsertUpdate(id, txtName.Text, Convert.ToInt32(cmbParentHead.Tag), companyid);
                            if (flag)
                            {

                                MessageBox.Show("Head data successfully added.");
                                ClearData();
                            }
                            else
                                MessageBox.Show("Data not saved");
                        }
                        else
                        {
                            MessageBox.Show("Can't insert duplicate record.");
                        }

                    }
                    else if (btnSave.Text == "Update")
                    {
                        bool flag = headclass.Head_InsertUpdate(id, txtName.Text, Convert.ToInt32(cmbParentHead.Tag), companyid);
                        if (flag)
                        {
                            MessageBox.Show("Head data successfully updated.");
                            btnSave.Text = "&Save";
                            ClearData();
                        }
                        else
                            MessageBox.Show("Data not saved");
                    }
                //}
                //else
                //{
                  //  txtName.Focus();
                   // txtName.BackColor = Color.Yellow;
                    //txtParent.BackColor = Color.Yellow;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
         
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
            btnSave.Text = "&Save";
            txtName.Focus();
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        CompanyMasterClass companyclass = new CompanyMasterClass();
        private void txtParent_TextChanged(object sender, EventArgs e)
        {
            string gridstr = "";
            try
            {
                gridstr = " select  Name,ID from AccountHead_Master";
                da.fill_combo(gridstr, cmbParentHead, "ID", "Name");
            }
            catch { }
            
        }

        private void txtParent_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                cmbParentHead.Focus();
            }
        }
        public void BindHeadDetailGrid()
        {
            dgvHeadMasterDetails.Columns.Clear();

            dgvHeadMasterDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11.0F, FontStyle.Regular);
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
            dgvHeadMasterDetails.Columns.Add(select);
            dgvHeadMasterDetails.Columns.Add(col1);
            dgvHeadMasterDetails.Columns.Add(edit);
            DataSet ds = new DataSet();
            ds = headclass.Head_GetData();
            dgvHeadMasterDetails.DataSource = ds.Tables[0];
            dgvHeadMasterDetails.Columns["ID"].Visible = false;
            dgvHeadMasterDetails.Columns["Company Name"].Visible = false;
            dgvHeadMasterDetails.Columns["ParentHead"].Visible = false;
            dgvHeadMasterDetails.Columns["CompanyID"].Visible = false;
            dgvHeadMasterDetails.Columns["S.N."].Width = 50;
            dgvHeadMasterDetails.Columns["Name"].Width = 250;
            dgvHeadMasterDetails.Columns["ParentName"].Width = 300;
            //Change cell font
            foreach (DataGridViewColumn c in dgvHeadMasterDetails.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Pixel);
            }   
        }
        
        private void dgvHeadMasterDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvHeadMasterDetails.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                try
                {
                    id = Convert.ToInt32(dgvHeadMasterDetails.CurrentRow.Cells["ID"].Value);
                    txtName.Text = Convert.ToString(dgvHeadMasterDetails.CurrentRow.Cells["Name"].Value);
                   // txtParent.Tag = Convert.ToString(dgvHeadMasterDetails.CurrentRow.Cells["ParentHead"].Value);
                    cmbParentHead.Text = Convert.ToString(dgvHeadMasterDetails.CurrentRow.Cells["ParentName"].Value);
                    companyid = Convert.ToInt32(dgvHeadMasterDetails.CurrentRow.Cells["CompanyID"].Value);
                    btnSave.Text = "Update";
                    //pnlHeadDetails.Hide();
                }
                catch (Exception ex)
                {

                }

            }
            else if (e.ColumnIndex == dgvHeadMasterDetails.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvHeadMasterDetails.CurrentRow.Cells["ID"].Value);

                    if (MessageBox.Show("Are you sure to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {

                        bool flag = headclass.Head_Delete(id);
                        if (flag)
                        {
                            MessageBox.Show("Successfully Deleted");
                            BindHeadDetailGrid();
                        }
                        else
                        {
                            MessageBox.Show("Failed");
                        }
                    }
                }

                catch (Exception ex)
                {

                }

            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            BindHeadDetailGrid();
            pnlHeadDetails.Show();
        }

        private void frmHeadMaster_Load(object sender, EventArgs e)
        {
            string gridstr = "";
            try
            {
                gridstr = " select  Name,ID from AccountHead_Master";
                da.fill_combo(gridstr, cmbParentHead, "ID", "Name");
            }
            catch { }
            BindHeadDetailGrid();
            //pnlHeadDetails.Hide();
        }

        private void btnHeadDetailsClose_Click(object sender, EventArgs e)
        {
            //pnlHeadDetails.Hide();
        }

        private void frmHeadMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                return;
            }
        }

        private void dgvHeadMasterDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void BindHeadDetailGrid_OnSearch()
        {
            DataSet ds = new DataSet();
        //    ds = AllCommonFunctions.Account_SearchData("AccountHead_Master", txtNameSearch.Text, txtParentSearch.Text);
            dgvHeadMasterDetails.DataSource = ds.Tables[0];
            dgvHeadMasterDetails.Columns["ID"].Visible = false;
            dgvHeadMasterDetails.Columns["Company Name"].Visible = false;
            dgvHeadMasterDetails.Columns["ParentHead"].Visible = false;
            dgvHeadMasterDetails.Columns["CompanyID"].Visible = false;
        }
        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtNameSearch.Text!="")
            {
                BindHeadDetailGrid_OnSearch();
            }
            else
            {
                BindHeadDetailGrid();
            }
            
        }

        private void txtParentSearch_TextChanged(object sender, EventArgs e)
        {
           
                BindHeadDetailGrid();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvHeadMasterDetails.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)(row.Cells[0].Value) == true)
                        {

                            int id = Convert.ToInt32(dgvHeadMasterDetails.Rows[row.Index].Cells["ID"].Value.ToString());
                            int a = AllCommonFunctions.Check_Used("AccountHead_Master",id);
                            if(a>0)
                            {
                                MessageBox.Show("This head is already used. You can't delete this.");
                            }
                            else
                            {
                                try
                                {
                                    bool flag = headclass.Head_Delete(id);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed");
                                }
                            }
                            
                        }
                    }
                }
                BindHeadDetailGrid();
            }
        }

        private void pnlBasicInformation_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
