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
    public partial class frmInvSubGroup : Form
    {
        private MainIndex mainForm = null;
        public frmInvSubGroup(Form callingForm)
        {
            mainForm = callingForm as MainIndex;
            InitializeComponent();
        }
        public static int id;
        public static int companyid = CompanyMasterClass.CompanyID;
        Inventory_Sub_GroupClass invsgclass = new Inventory_Sub_GroupClass();
        database_admin da = new database_admin();

        public void ClearData()
        {
            txtName.Clear();
            
            txtName.Focus();
            BindHeadDetailGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
            btnSave.Text = "&Save";
            txtName.Focus();
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("Please Provide Name ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;

                }

                if (cmbParentGroup.Text == "")
                {
                    MessageBox.Show("Please Provide Parent Group ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbParentGroup.Focus();
                    return;

                }

                if (btnSave.Text == "&Save")
                {
                    int checkdup = AllCommonFunctions.Check_Duplicacy("Inventory_Sub_Group", txtName.Text);
                    if (checkdup == 0)
                    {
                        id = 0;
                        int groupid = Convert.ToInt32(da.value1("select ID from InventoryGroup_Master where Name='" + cmbParentGroup.Text + "' "));
                        bool flag = invsgclass.Inv_S_Grp_InsertUpdate(id, txtName.Text, groupid,Form1.CompanyID);
                        if (flag)
                        {

                            MessageBox.Show("Data Successfully Added ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                            ClearData();
                        }
                        else
                            MessageBox.Show("Data not saved");
                    }
                    else
                    {
                        MessageBox.Show("Cannot Save Duplicate Record ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else if (btnSave.Text == "&Update")
                {
                    int groupid = Convert.ToInt32(da.value1("select ID from InventoryGroup_Master where Name='" + cmbParentGroup.Text + "' "));
                    bool flag = invsgclass.Inv_S_Grp_InsertUpdate(id, txtName.Text, groupid,Form1.CompanyID);
                    if (flag)
                    {
                        MessageBox.Show("Data Successfully Updated ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
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
            ds = invsgclass.Inv_S_Grp_GetData ();
            dgvHeadMasterDetails.DataSource = ds.Tables[0];
            dgvHeadMasterDetails.Columns["ID"].Visible = false;
           // dgvHeadMasterDetails.Columns["Company Name"].Visible = false;
       //     dgvHeadMasterDetails.Columns["ParentGroup"].Visible = false;
          //  dgvHeadMasterDetails.Columns["CompanyID"].Visible = false;
            dgvHeadMasterDetails.Columns["S.N."].Width = 50;
            dgvHeadMasterDetails.Columns["Name"].Width = 250;
      //      dgvHeadMasterDetails.Columns["ParentName"].Width = 300;
            foreach (DataGridViewRow row in dgvHeadMasterDetails.Rows)
            {

                row.Height = 42;
            }
            dgvHeadMasterDetails.RowsDefaultCellStyle.Font = new Font("Arial", 12.0F, FontStyle.Regular);

        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Delete?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvHeadMasterDetails.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)(row.Cells[0].Value) == true)
                        {

                            int id = Convert.ToInt32(dgvHeadMasterDetails.Rows[row.Index].Cells["ID"].Value.ToString());
                            int a = AllCommonFunctions.Check_Used("Inventory_Sub_Group_Master", id);
                            if (a > 0)
                            {
                                MessageBox.Show("This Sub Group is already used. You can't delete this.");
                            }
                            else
                            {
                                try
                                {
                                    bool flag = invsgclass.Inv_S_Grp_Delete (id);
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

        private void frmInvSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
           }

        CompanyMasterClass companyclass = new CompanyMasterClass();
        private void txtParent_TextChanged(object sender, EventArgs e)
        {
            //companyclass.SearchList_GetData(txtParent.Text, "InventoryGroup_Master", lstSearch);
            //lstSearch.Refresh();
        }

        
        private void dgvHeadMasterDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvHeadMasterDetails.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                try
                {
                    id = Convert.ToInt32(dgvHeadMasterDetails.CurrentRow.Cells["ID"].Value);
                    txtName.Text = Convert.ToString(dgvHeadMasterDetails.CurrentRow.Cells["Name"].Value);
               //     cmbParentGroup.Tag = Convert.ToString(dgvHeadMasterDetails.CurrentRow.Cells["ParentGroup"].Value);
                   cmbParentGroup.Text = Convert.ToString(dgvHeadMasterDetails.CurrentRow.Cells["ParentName"].Value);
                    //companyid = Convert.ToInt32(dgvHeadMasterDetails.CurrentRow.Cells["CompanyID"].Value);
                    btnSave.Text = "&Update";
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
                    int a = AllCommonFunctions.Check_Used("Inventory_Sub_Group_Master", id);
                    if (a > 0)
                    {
                        MessageBox.Show("This Sub Group is already used. You can't delete this.");
                    }
                    else
                    {
                        if (MessageBox.Show("Are you sure to Delete?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                        {

                            bool flag = invsgclass.Inv_S_Grp_Delete(id);
                            if (flag)
                            {
                                MessageBox.Show("Data Successfully Deleted ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                                BindHeadDetailGrid();
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

        private void dgvHeadMasterDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtParent_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
                }
            }
      

        private void frmInvSubGroup_Load(object sender, EventArgs e)
        {
            //string gridstr = "";
            //try
            //{
            //    gridstr = "  select ID,Name from InventoryGroup_Master";
            //    da.fill_combo(gridstr,cmbParentGroup,"ID","Name");
            //}
            //catch { }
            da.fill_combo("select ID,Name from InventoryGroup_Master",cmbParentGroup,"ID","Name");
           
            BindHeadDetailGrid();
            txtName.Focus();
        }

        private void pnlBasicInformation_Click(object sender, EventArgs e)
        {

        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = AllCommonFunctions.Common_SearchData("subgroup", txtNameSearch.Text);
            dgvHeadMasterDetails.DataSource = ds.Tables[0];
            dgvHeadMasterDetails.Columns["ID"].Visible = false;
            foreach (DataGridViewRow row in dgvHeadMasterDetails.Rows)
            {

                row.Height = 42;
            }
            //   dgvCommonMasterDetails.Columns["CompanyID"].Visible = false;

        }

        private void cmbParentGroup_Enter(object sender, EventArgs e)
        {
            da.fill_combo("select ID,Name from InventoryGroup_Master", cmbParentGroup, "ID", "Name");
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab )
            {
                cmbParentGroup.Focus();
            }
        }

        

    }
}
