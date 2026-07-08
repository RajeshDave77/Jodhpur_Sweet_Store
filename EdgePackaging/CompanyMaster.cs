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
    public partial class frmCompanyMaster : Form
    {
        private MainIndex mainForm = null;
        public frmCompanyMaster(Form callingForm)
        {
            mainForm = callingForm as MainIndex;
            InitializeComponent();
        }
        database_admin da = new database_admin();
     

        private void frmCompanyMaster_Load(object sender, EventArgs e)
        {
           
            da.fill_combo("select ID, Name from State_Master", cmbState, "ID", "Name");
           
            pnlCompanyDetails.Hide();
          
            cmbState.Text = "Rajasthan";
          

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            BindCompanyDetailGrid();
            pnlCompanyDetails.Show();
            pnlCompanyDetails.Location = new Point(12,2);
            txtNameSearch.Focus();
        }

        public void BindCompanyDetailGrid()
        {
            txtNameSearch.Focus();
            try
            {
                //dgvCompanyDetails.Columns.Clear();

                //dgvCompanyDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11.0F, FontStyle.Regular);
                //DataGridViewColumn col1 = new DataGridViewImageButtonDeleteColumn();
                //col1.HeaderText = "";
                //col1.Name = "Delete";
                //col1.Width = 35;
                //DataGridViewColumn edit = new DataGridViewImageButtonEditColumn();
                //edit.HeaderText = "";
                //edit.Name = "Edit";
                //edit.Width = 35;
                //DataGridViewColumn select = new DataGridViewCheckBoxColumn();
                //select.HeaderText = "";
                //select.Name = "sel_rec";
                //select.Width = 40;
                //dgvCompanyDetails.Columns.Add(select);
                //dgvCompanyDetails.Columns.Add(col1);
                //dgvCompanyDetails.Columns.Add(edit);
                DataSet ds = new DataSet();
                ds = companyclass.Company_GetData();
                dgvCompanyDetails.DataSource = ds.Tables[0];
                dgvCompanyDetails.Columns["ID"].Visible = false;
             //   dgvCompanyDetails.Columns["c_ID"].Visible = false;
               // dgvCompanyDetails.Columns["s_ID"].Visible = false;
             //   dgvCompanyDetails.Columns["con_ID"].Visible = false;
                //Change cell font
                foreach (DataGridViewColumn c in dgvCompanyDetails.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 11.0F, FontStyle.Regular, GraphicsUnit.Pixel);
                }            
                //foreach (DataGridViewRow row in dgvCompanyDetails.Rows)
                //{

                //    row.Height = 42;
                //}
                dgvCompanyDetails.RowsDefaultCellStyle.Font = new Font("Arial", 11.0F, FontStyle.Regular);
            }
            catch { }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.mainForm.tabControl2.Tabs.RemoveAt(this.mainForm.tabControl2.SelectedTabIndex);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
            btnSave.Text = "&Save";
        }
        public void ClearData()
        {
            txtName.Clear();
          
            txtAddress1.Clear();

            cmbState.Text = "Rajasthan";

            txtGSTNumber.Clear();
            txtadd2.Clear();
            txtadd3.Clear();

          
          
        }

        CompanyMasterClass companyclass = new CompanyMasterClass();
        private void btnSave_Click(object sender, EventArgs e)
        
        {
            try
            
            {
                if(txtName.Text=="")
                {
                    MessageBox.Show("Company Name could not be blank", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                    return;
                }
                if (txtGSTNumber.Text == "")
                {
                    txtGSTNumber.Focus();
                    // MessageBox.Show("GSTIN  could not be blank");
                    MessageBox.Show("GSTIN  could not be blank", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                    if (txtAddress1.Text == "")
                    {
                        txtAddress1.Focus();
                     //   MessageBox.Show("Company Address could not be blank");
                        MessageBox.Show("Company Address could not be blank", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }
                 
                  
                    
                    if (btnSave.Text == "&Save")
                    {
                        int checkdup = AllCommonFunctions.Check_Duplicacy("Company_Master", txtName.Text);
                        if (checkdup == 0)
                        {
                            id = 0;
                            cmbState.Tag = Convert.ToInt32(da.value1("Select ID from State_Master where Name like '" +cmbState.Text.ToString() + "'"));



                            CompanyMasterClass.CompanyID = companyclass.Company_InsertUpdate(id,Form1.SingleCode(txtName.Text),txtAddress1.Text,txtadd2.Text,txtadd3.Text,cmbState.Text,txtGSTNumber.Text );
                            if (CompanyMasterClass.CompanyID != -1)
                            {
                             //   MessageBox.Show("Company data successfully added.");
                                MessageBox.Show("Company data successfully added.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                ClearData();
                            }
                            else
                            {
                            }
                        }
                        else
                        {
                          //  MessageBox.Show("Can't insert duplicate record.");
                            MessageBox.Show("Cannot insert duplicate record", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtName.Focus();
                        }


                    }
                    else if (btnSave.Text == "Update")
                    {
                        CompanyMasterClass.CompanyID = companyclass.Company_InsertUpdate(id,Form1.SingleCode(txtName.Text), txtAddress1.Text, txtadd2.Text, txtadd3.Text, cmbState.Text, txtGSTNumber.Text);
                        if (CompanyMasterClass.CompanyID != -1)
                        {
                          //  MessageBox.Show("Company data successfully updated.");
                            MessageBox.Show("Company data successfully updated", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);

                            btnSave.Text = "&Save";
                            ClearData();
                        }
                        else
                        {
                            MessageBox.Show("Data not saved");
                        }
                       
                    }
             
            }
                catch (Exception ex)
            {
              
            }

        }

      
       


      

      

        private void frmCompanyMaster_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void pnlCompanyDetailsClose_Click(object sender, EventArgs e)
        {
            pnlCompanyDetails.Hide();
        }
        public static int id;
        private void dgvCompanyDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dgvCompanyDetails.Columns[0].Index && e.RowIndex >= 0)
            {
                try
                {
                    id = Convert.ToInt32(dgvCompanyDetails.CurrentRow.Cells["ID"].Value);
                    txtName.Text = Convert.ToString(dgvCompanyDetails.CurrentRow.Cells["Name"].Value);
                    txtAddress1.Text = Convert.ToString(dgvCompanyDetails.CurrentRow.Cells["Address1"].Value);
                    txtadd2.Text = Convert.ToString(dgvCompanyDetails.CurrentRow.Cells["Address2"].Value);

                    txtadd3.Text = Convert.ToString(dgvCompanyDetails.CurrentRow.Cells["Address3"].Value);

                    cmbState.Text = Convert.ToString(dgvCompanyDetails.CurrentRow.Cells["State"].Value);

                    txtGSTNumber.Text = Convert.ToString(dgvCompanyDetails.CurrentRow.Cells["GSTIN"].Value);
                  
                    //txtCodeLength.Text = Convert.ToString(dgvCompanyDetails.CurrentRow.Cells["CodeLength"].Value);
                  
              //      cmbState.Text = Convert.ToString(dgvCompanyDetails.CurrentRow.Cells["s_ID"].Value);
                    btnSave.Text = "Update";
                    pnlCompanyDetails.Hide();
                }
                catch (Exception ex)
                {

                }

            }
            else if (e.ColumnIndex == dgvCompanyDetails.Columns[1].Index && e.RowIndex >= 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvCompanyDetails.CurrentRow.Cells["ID"].Value);
                    if (id == 1) { return; }
                    int a = AllCommonFunctions.Check_Used("Company_Master", id);
                    if (a > 0)
                    {
                        // MessageBox.Show("This route is already used. You can't delete this.");
                        MessageBox.Show("This Company is already used. You cannot delete this.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else            if (MessageBox.Show("Are you sure to Delete?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                        {

                            bool flag = companyclass.Company_Delete(id);
                            if (flag)
                            {
                             //   MessageBox.Show("Successfully Deleted");
                                BindCompanyDetailGrid();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Delete?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvCompanyDetails.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)(row.Cells[0].Value) == true)
                        {

                            int id = Convert.ToInt32(dgvCompanyDetails.Rows[row.Index].Cells["ID"].Value.ToString());
                             int a = AllCommonFunctions.Check_Used("Company_Master",id);
                             if (a > 0)
                             {
                                // MessageBox.Show("This route is already used. You can't delete this.");
                                 MessageBox.Show("This Company is already used. You cannot delete this.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                             }
                             else
                             {
                                 try
                                 {
                                     bool flag = companyclass.Company_Delete(id);
                                 }
                                 catch (Exception ex)
                                 {
                                     MessageBox.Show("Failed");
                                 }
                             }
                            
                        }
                    }
                }
                BindCompanyDetailGrid();
            }

        }
        public void BindCompanyDetailGrid_OnSearch()
        {
            DataSet ds = new DataSet();
            ds = AllCommonFunctions.Company_SearchData( txtNameSearch.Text);
            dgvCompanyDetails.DataSource = ds.Tables[0];
            dgvCompanyDetails.Columns["ID"].Visible = false;
            foreach (DataGridViewRow row in dgvCompanyDetails.Rows)
            {

                row.Height = 42;
            }
         //   dgvCompanyDetails.Columns["c_ID"].Visible = false;
           // dgvCompanyDetails.Columns["s_ID"].Visible = false;
          //  dgvCompanyDetails.Columns["con_ID"].Visible = false;
        }
        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {   
            if(txtNameSearch.Text!="")
            {
                BindCompanyDetailGrid_OnSearch();
            }
            else
            {
                BindCompanyDetailGrid();
            }
        }

        private void txtAliasSearch_TextChanged(object sender, EventArgs e)
        {
          
                BindCompanyDetailGrid();
           
        }

        private void labelX24_Click(object sender, EventArgs e)
        {

        }

        private void txtPinCode_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtOfficeNumber_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtResidenceNumber_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAliasSearch_KeyPress(object sender, KeyPressEventArgs e)
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

        private void buttonX1_Click(object sender, EventArgs e)
        {
            pnlCompanyDetails.Hide();
        }

        private void dgvCompanyDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            pnlCompanyDetails.Hide();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
            {
               txtGSTNumber.Focus();
            }
        }

        private void txtAddress1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtadd2.Focus();
            }
        }

        private void txtadd2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtadd3.Focus();
            }
        }

        private void txtadd3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbState.Focus();
            }
        }

        private void cmbState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnSave.Focus();
            }
        }

        private void txtGSTNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtAddress1.Focus();
            }
        }

        private void pnlCompanyDetails_Click(object sender, EventArgs e)
        {

        }

        

    }
}
