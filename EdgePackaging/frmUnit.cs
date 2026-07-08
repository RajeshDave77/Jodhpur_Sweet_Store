using EdgePackingShared;
using EdgeVastra;
using EdgeVastra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EdgePackaging
{
    public partial class frmUnit : Form
    {
     
        public frmUnit()
        {
           
            InitializeComponent();
        }
        GetSet GS = new GetSet();
        private void frmUnit_Load(object sender, EventArgs e)
        {
            //pnlCommonDetails.Hide();
          
                pnlBasicInformation.Text = "Unit Master";
                pnlCommonDetails.Text = "Unit Master Details";
         
          
            BindCommonMasterDetailGrid();
            txtname.Focus();
        }
        CommonMasterClass commonclass = new CommonMasterClass();
        public static int id;
        public static int companyid = CompanyMasterClass.CompanyID;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtname.Text == "")
                {
                    MessageBox.Show("Name could not be blank", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtname.Focus();
                    return;
                }
                if ( txtname.Text != ""  )
                {
                    
                    if (txtrateper.Text  =="" )
                    {
                        txtrateper.Text = "0";
                    }
                    if (txtcode.Text == "")
                    {
                        txtcode.Text = "0";
                    }
                     
                        if (btnSave.Text == "&Save")
                        {
                            int checkdup = AllCommonFunctions.Check_Duplicacy(GS.MasterForm, txtname.Text);
                            if (checkdup == 0)
                            {
                                id = 0;
                                bool flag = commonclass.CommonMaster_InsertUpdate(id, txtname.Text, GS.MasterForm, Form1.CompanyID);
                                if (flag)
                                {
                                  //  MessageBox.Show("Group Succesfully Saved", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                                        
                                        txtname.Focus();
                                    ClearData();
                                }
                                else
                                    MessageBox.Show("Data not saved");
                            }
                            else
                            {
                                MessageBox.Show("Duplicate Data Cannot Be Saved", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                        else if (btnSave.Text == "Update")
                        {
                            bool flag = commonclass.CommonMaster_InsertUpdate(id, txtname.Text, GS.MasterForm, Form1.CompanyID);
                            if (flag)
                            {
                            //    MessageBox.Show("Group Succesfully Updated", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                                btnSave.Text = "&Save";
                                ClearData();
                            }
                            else
                                MessageBox.Show("Data not saved");
                        }
                }
                
                else
                {
                    txtcode.Focus();
                    txtcode.BackColor = Color.Yellow;
                    txtname.BackColor = Color.Yellow;
                    txtrateper.BackColor = Color.Yellow;
                }
                

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
        public void ClearData()
        {
            txtname.Clear();
            txtcode.Clear();
            txtrateper.Clear();
            txtremark.Clear();
            txtcode.Focus();
            //txtname.Focus();
            BindCommonMasterDetailGrid();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
            btnSave.Text = "&Save";
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            BindCommonMasterDetailGrid();
            pnlCommonDetails.Show();
        }
        public void BindCommonMasterDetailGrid()
        {
            GS.MasterForm = "Unit_Master";
            dgvCommonMasterDetails.Columns.Clear();
            dgvCommonMasterDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11.0F, FontStyle.Regular);
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
            dgvCommonMasterDetails.Columns.Add(select);
            dgvCommonMasterDetails.Columns.Add(col1);
            dgvCommonMasterDetails.Columns.Add(edit);
            DataSet ds = new DataSet();
            ds = commonclass.CommonMaster_GetData(GS.MasterForm);
            dgvCommonMasterDetails.DataSource = ds.Tables[0];
            dgvCommonMasterDetails.Columns["ID"].Visible = false;
         //   dgvCommonMasterDetails.Columns["CompanyID"].Visible = false;
            //dgvCommonMasterDetails.Columns["[Company Name]"].Visible = false;
            foreach (DataGridViewRow row in dgvCommonMasterDetails.Rows)
            {

                row.Height = 42;
            }
            foreach (DataGridViewColumn c in dgvCommonMasterDetails.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Pixel);
            } 
        }

        private void dgvCommonMasterDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCommonMasterDetails.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                try
                {
                    id = Convert.ToInt32(dgvCommonMasterDetails.CurrentRow.Cells["ID"].Value);
                    txtname.Text = Convert.ToString(dgvCommonMasterDetails.CurrentRow.Cells["Name"].Value);
                    
                    btnSave.Text = "Update";
                    txtname.Focus();
                    //pnlCommonDetails.Hide();
                }
                catch (Exception ex)
                {

                }

            }
            else if (e.ColumnIndex == dgvCommonMasterDetails.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvCommonMasterDetails.CurrentRow.Cells["ID"].Value);
                    int a = AllCommonFunctions.Check_Used("Unit_Master", id);
                    if(a>0)
                    {
                        MessageBox.Show("This name Is In Use. Cannot Be Deleted.", "Edge Solutions", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        return;
                    }

                    if (MessageBox.Show("Are you sure to Delete?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                        {
                            
                            bool flag = commonclass.CommonMaster_Delete(id, GS.MasterForm);
                            if (flag)
                            {
                          //      MessageBox.Show("Group Succesfully Deleted", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                                BindCommonMasterDetailGrid();
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

        private void btnCommonDetailsClose_Click(object sender, EventArgs e)
        {
            //pnlCommonDetails.Hide();
        }

        private void frmUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                return;
            }
        }

        private void pnlCommonDetails_Click(object sender, EventArgs e)
        {

        }

        private void dgvCommonMasterDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void BindCommonMasterDetailGrid_OnSearch()
        {
            DataSet ds = new DataSet();
            ds = AllCommonFunctions.Common_SearchData("Unit",txtNameSearch.Text);
            dgvCommonMasterDetails.DataSource = ds.Tables[0];
            dgvCommonMasterDetails.Columns["ID"].Visible = false;
            foreach (DataGridViewRow row in dgvCommonMasterDetails.Rows)
            {

                row.Height = 42;
            }
         //   dgvCommonMasterDetails.Columns["CompanyID"].Visible = false;

        }
        private void txtCodeSearch_TextChanged(object sender, EventArgs e)
        {
          
           
                BindCommonMasterDetailGrid();
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Delete?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvCommonMasterDetails.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)(row.Cells[0].Value) == true)
                        {

                            int id = Convert.ToInt32(dgvCommonMasterDetails.Rows[row.Index].Cells["ID"].Value.ToString());
                            int a = AllCommonFunctions.Check_Used(GS.MasterForm, id);
                            if (a > 0)
                           {
                               MessageBox.Show("This is already used. You can't delete this.", "Edge Solutions",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                          }
                           else
                           {
                                try
                                {
                                    bool flag = commonclass.CommonMaster_Delete(id, GS.MasterForm);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed");
                                }
                            }

                        }
                    }
                }
                BindCommonMasterDetailGrid();
            }
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtNameSearch.Text != "")
            {
                BindCommonMasterDetailGrid_OnSearch();
            }
            else
            {
                BindCommonMasterDetailGrid();
            }
        }

        private void btnOpen_Click_1(object sender, EventArgs e)
        {

        }

        

        
    }
}
