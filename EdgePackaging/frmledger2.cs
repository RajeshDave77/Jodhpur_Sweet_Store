using EdgePackingShared;
using EdgeVastra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EdgePack;

namespace EdgePackaging
{
    public partial class frmledger2 : Form
    {
        private MainIndex mainForm = null;
        private ComboBox cmb;
        private ComboBox txt;
        public frmledger2(Form callingForm)
        {
            mainForm = callingForm as MainIndex;
            InitializeComponent();
        }
        public frmledger2(ComboBox combobox, ComboBox txtbox)
        {
           
            InitializeComponent();
            cmb = combobox;
            txt = txtbox;
            if (txt.Text != "")
            {
                txtmobile.Text = txt.Text;
            }
            
        }
        public frmledger2(ComboBox combobox)
        {

            InitializeComponent();
            cmb = combobox;
        
         

        }
        public static int id;
        public static int companyid = Form1.CompanyID;
        LedgerMasterClass ledgerclass = new LedgerMasterClass();
        database_admin da = new database_admin();
        CompanyMasterClass companyclass = new CompanyMasterClass();
        private void btnSave_Click(object sender, EventArgs e)
        {
            int stateid = Convert.ToInt32(da.value1("select ID from State_Master where Name='" + cmbstate.Text + "'"));
            try
            {
                if(txtname.Text=="")
                {
                    MessageBox.Show("Please specify name. ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtname.Focus();
                    return;

                }
                if(Convert.ToInt32(cmbCompany.SelectedValue)==0)
                {
                    MessageBox.Show("Please select location name. ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCompany.Focus();
                    return;
                }
                //if (txtmobile.Text == "")
                //{
                //    MessageBox.Show("Please Provide Party Number ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtmobile.Focus();
                //    return;

                //}
                if (txtname.Text != "")
                {

                    if (btnSave.Text == "&Save")
                    {
                        int checkdup = 0;
                        //if (true)
                        //{

                        //    checkdup = AllCommonFunctions.Check_Duplicacy("Ledger_Master", txtmobile.Text);
                        //}
                        //if (cmbtype.Text != "Customer" && cmbtype.Text != "Supplier")
                        //{
                        //    MessageBox.Show("Please Provide Party Type ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}

                        if (checkdup == 0)
                        {
                            ///                          id = 0;
                            //ID,     Name,   State,              StateID,                                                                   CompanyID, Mobile,          GSTNumber,                  Tax_Per,                 Address
                            bool flag = ledgerclass.Ledger_InsertUpdate(id,Form1.SingleCode( txtname.Text), cmbstate.Text, stateid, Convert.ToInt32(cmbCompany.SelectedValue), txtmobile.Text, txtgstno.Text, cmbtype.Text, dtdob.Text, dtdoa.Text, txtadd1.Text, txtadd2.Text, Form1.UserID);
                            if (flag)
                            {
                                DataSet rstemp = new DataSet();
                                rstemp = da.dataset_ret("select max(id) as id from ledger_master where type='Staff' ");
                                da.insert_update_delete("update ledger_master set scode='" + Form1.SingleCode(txtCode.Text) +"' where id=" +Convert.ToInt32(rstemp.Tables[0].Rows[0]["id"].ToString()));
                                //MessageBox.Show("Data Successfully Added ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                                if (this.cmb != null)
                                {
                                    //SalesForm.rcheck = 1;

                                    //Form1.PartyAddress = txtadd1.Text + " " + txtadd2.Text;
                                    //Form1.PartyGST = txtgstno.Text;
                                    //Form1.PartyState = cmbstate.Text;
                                    //da.fill_combo("select ID,Mobile from Ledger_Master where type='Customer'   Order By Mobile", this.txt, "ID", "Mobile");
                                    //this.txt.Refresh();
                                
                                    da.fill_combo("select 0 as id,'---Select Party---' as Name,1 as rtag union all select ID,Name,2 as rtag from Ledger_Master where type='Supplier' order by rtag,name", this.cmb, "ID", "Name");
                                  //  da.fill_combo("select ID,name from Ledger_Master where type='Customer'   Order By name", this.cmb, "ID", "name");
                                    this.cmb.Refresh();
                                    this.cmb.SelectedValue = Convert.ToInt32(da.value1("select max(ID) from Ledger_Master where type='Supplier'"));

                                    SalesForm.rcheck = 0;
                                    this.Close();
                                }

                                ClearData();
                                cmbstate.Text = "Rajasthan";
                            }
                            else
                                MessageBox.Show("Data not saved");
                        }
                        else
                        {
                            MessageBox.Show("Duplicate Record Not Inserted ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else if (btnSave.Text == "Update")
                    {


                        //  bool flag = false;
                        bool flag = ledgerclass.Ledger_InsertUpdate(id,Form1.SingleCode( txtname.Text), cmbstate.Text, stateid, Convert.ToInt32(cmbCompany.SelectedValue), txtmobile.Text, txtgstno.Text, cmbtype.Text, dtdob.Text, dtdoa.Text, txtadd1.Text, txtadd2.Text, Form1.UserID);


                        if (flag)
                        {
                            da.insert_update_delete("update ledger_master set scode='" + Form1.SingleCode(txtCode.Text) + "' where id=" + Convert.ToInt32(id));

                           // MessageBox.Show("Data Successfully Updated ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                            //Form1.PartyAddress = txtadd1.Text + " " + txtadd2.Text;
                            //Form1.PartyGST = txtgstno.Text;
                            //Form1.PartyState = cmbstate.Text;
                            btnSave.Text = "&Save";
                            ClearData();
                            cmbstate.Text = "Rajasthan";
                        }
                        else
                            MessageBox.Show("Data not saved");
                    }

                }
                else
                {
                    txtname.Focus();
                    txtname.BackColor = Color.Yellow;
                    txtname.BackColor = Color.Yellow;
                }

            }
            catch (Exception ex)
            {
                //     MessageBox.Show(ex.ToString());
            }

        }


        public void ClearData()
        {
            txtgstno.Clear();
            txtmobile.Clear();
            txtname.Clear();
            txtname.Focus();
            dtdoa.Clear();
            dtdob.Clear();
            txtadd1.Clear();
            txtadd2.Clear();
            txtCode.Text = "";
            id = 0;
        }
        public void BindLedgerDetailGrid()
        {
            try
            {
                dgvLedgerMasterDetails.Columns.Clear();
                dgvLedgerMasterDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11.0F, FontStyle.Regular);
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
              dgvLedgerMasterDetails.Columns.Add(select);
                dgvLedgerMasterDetails.Columns.Add(col1);
                dgvLedgerMasterDetails.Columns.Add(edit);
                DataSet ds = new DataSet();
                ds = ledgerclass.ShopMaster_GetData(cmbtype.Text);
                int count = ds.Tables[0].Rows.Count;
                dgvLedgerMasterDetails.DataSource = ds.Tables[0];
                dgvLedgerMasterDetails.Columns["ID"].Visible = false;
                //dgvLedgerMasterDetails.Columns["Company Name"].Visible = false;

                dgvLedgerMasterDetails.Columns["CompanyID"].Visible = false;

                dgvLedgerMasterDetails.Columns["GSTNumber"].Visible = false;
                dgvLedgerMasterDetails.Columns["StateID"].Visible = false;
              dgvLedgerMasterDetails.Columns["userid"].Visible = false;
              dgvLedgerMasterDetails.Columns["ID"].Visible = false;
              dgvLedgerMasterDetails.Columns["mobile1"].Visible = false;
              dgvLedgerMasterDetails.Columns["doa"].Visible = false;
              dgvLedgerMasterDetails.Columns["dob"].Visible = false;
                dgvLedgerMasterDetails.Columns["S.N."].Width = 50;


                foreach (DataGridViewRow row in dgvLedgerMasterDetails.Rows)
                {

                    row.Height = 40;
                }
                foreach (DataGridViewColumn c in dgvLedgerMasterDetails.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Pixel);
                }

            }
            catch { }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
            btnSave.Text = "&Save";
            cmbstate.Text = "Rajasthan";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch { }
        }




        private void btnOpen_Click(object sender, EventArgs e)
        {
            BindLedgerDetailGrid();
            pnlLedgerDetails.Show();
            pnlLedgerDetails.Location = new Point(11, 8);
        }

        public void frmledger2_Load(object sender, EventArgs e)
        {
           
                label1.Text = "Staff Master";
                this.Text = "Staff Master";
                pnlBasicInformation.Text = "Staff Master Detail";
                pnlLedgerDetails.Text = "Staff Master Detail";
                cmbtype.Items.Add("Staff");
           
            da.fill_combo("select ID,Name from State_Master", cmbstate, "ID", "Name");
            da.fill_combo("select 0 as id,'--Select--' as name,1 as rtag union all select ID,Name,2 as rtag from Ledger_Master where  type in ('Godown','Shop')  order by  rtag,name", cmbCompany, "ID", "Name");
          //  da.fill_combo("select 0 as id,'--Select--' as name,0 as rtag union all select ID,Name,1 as rtag from company_Master order by rtag,name", cmbCompany, "ID", "Name");
            pnlLedgerDetails.Hide();
           
            cmbstate.Text = "Rajasthan";
            //if (this.cmb != null)
            //{
            //    cmbtype.Text = "Supplier";
            //}
            //else
            //{
            //    cmbtype.SelectedIndex = 0;
            //}
          
            cmbtype.SelectedIndex = 0;
            txtname.Focus();

        }

        private void btnLedgerDetailsClose_Click(object sender, EventArgs e)
        {
            pnlLedgerDetails.Hide();
        }

        private void dgvLedgerMasterDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvLedgerMasterDetails.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                try
                {
                    id = Convert.ToInt32(dgvLedgerMasterDetails.CurrentRow.Cells["ID"].Value);
                    txtname.Text = Convert.ToString(dgvLedgerMasterDetails.CurrentRow.Cells["Name"].Value);


                    cmbstate.Text = Convert.ToString(dgvLedgerMasterDetails.CurrentRow.Cells["State"].Value);
                    cmbstate.Tag = Convert.ToString(dgvLedgerMasterDetails.CurrentRow.Cells["StateID"].Value);


                    txtmobile.Text = Convert.ToString(dgvLedgerMasterDetails.CurrentRow.Cells["Mobile"].Value);

                    //txttin.Text = Convert.ToString(dgvLedgerMasterDetails.CurrentRow.Cells["TINNumber"].Value); ;
                    txtgstno.Text = Convert.ToString(dgvLedgerMasterDetails.CurrentRow.Cells["GSTNumber"].Value);
                    txtadd1.Text = Convert.ToString(dgvLedgerMasterDetails.CurrentRow.Cells["Address1"].Value);

                    txtadd2.Text = Convert.ToString(dgvLedgerMasterDetails.CurrentRow.Cells["Address2"].Value);
                    dtdob.Text = Convert.ToString(dgvLedgerMasterDetails.CurrentRow.Cells["dob"].Value);
                    dtdoa.Text = Convert.ToString(dgvLedgerMasterDetails.CurrentRow.Cells["doa"].Value);
                    cmbtype.Text = Convert.ToString(dgvLedgerMasterDetails.CurrentRow.Cells["type"].Value);
                    cmbCompany.SelectedValue = (dgvLedgerMasterDetails.CurrentRow.Cells["companyid"].Value);
                    DataSet rstemp = new DataSet();
                    rstemp = da.dataset_ret("select isnull(scode,'') as scode from ledger_master where id=" + Convert.ToInt32(id));
                    txtCode.Text = rstemp.Tables[0].Rows[0]["scode"].ToString();
                    btnSave.Text = "Update";


                    btnSave.Text = "Update";
                    pnlLedgerDetails.Hide();
                }
                catch (Exception ex)
                {
                    pnlLedgerDetails.Hide();
                }

            }
            else if (e.ColumnIndex == dgvLedgerMasterDetails.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvLedgerMasterDetails.CurrentRow.Cells["ID"].Value);
                    if (MessageBox.Show("Are you sure to Delete?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        bool flag = ledgerclass.Ledger_Delete(id);
                        if (flag)
                        {
                            BindLedgerDetailGrid();
                            //MessageBox.Show("Successfully Deleted");

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

        //private void btnInsert_Click(object sender, EventArgs e)
        //{
        //    openfileDiaImage.Filter = "Jpeg|*.jpg|Bmp|*.bmp|Png|*.png|all files|*.*";
        //    DialogResult res = openfileDiaImage.ShowDialog();
        //    if (res == DialogResult.OK)
        //    {
        //        picture1.Image = Image.FromFile(openfileDiaImage.FileName);
        //        picture1.SizeMode = PictureBoxSizeMode.StretchImage;
        //    }
        //}


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvLedgerMasterDetails.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)(row.Cells[0].Value) == true)
                        {

                            int id = Convert.ToInt32(dgvLedgerMasterDetails.Rows[row.Index].Cells["ID"].Value.ToString());
                            int a = AllCommonFunctions.Check_Used("Ledger_Master", id);
                            if (a > 0)
                            {
                                MessageBox.Show("This ledger is already used. You can't delete this.");
                            }
                            else
                            {
                                try
                                {
                                    bool flag = ledgerclass.Ledger_Delete(id);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed");
                                }
                            }

                        }
                    }
                }
                BindLedgerDetailGrid();
            }
        }

        public void BindLedgerDetailGrid_OnSearch()
        {
            try
            {
                dgvLedgerMasterDetails.Columns.Clear();
                dgvLedgerMasterDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11.0F, FontStyle.Regular);
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
                dgvLedgerMasterDetails.Columns.Add(select);
                dgvLedgerMasterDetails.Columns.Add(col1);
                dgvLedgerMasterDetails.Columns.Add(edit);
                DataSet ds = new DataSet();
              ds = AllCommonFunctions.Shop_SearchData( txtNameSearch.Text,cmbtype.Text);
                dgvLedgerMasterDetails.DataSource = ds.Tables[0];
                dgvLedgerMasterDetails.Columns["ID"].Visible = false;
                dgvLedgerMasterDetails.Columns["CompanyID"].Visible = false;
                dgvLedgerMasterDetails.Columns["GSTNumber"].Visible = false;
                dgvLedgerMasterDetails.Columns["userid"].Visible = false;
                dgvLedgerMasterDetails.Columns["stateid"].Visible = false;
                dgvLedgerMasterDetails.Columns["mobile1"].Visible = false;
                dgvLedgerMasterDetails.Columns["doa"].Visible = false;
                dgvLedgerMasterDetails.Columns["dob"].Visible = false;
                dgvLedgerMasterDetails.Columns["S.N."].Width = 50;
                dgvLedgerMasterDetails.Columns["Name"].Width = 150;
           //     dgvLedgerMasterDetails.Columns["StateID"].Visible =false;
          //      dgvLedgerMasterDetails.Columns["Code"].Width = 60;
                foreach (DataGridViewRow row in dgvLedgerMasterDetails.Rows)
                {

                    row.Height = 42;
                }
                foreach (DataGridViewColumn c in dgvLedgerMasterDetails.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Pixel);
                }
            }
            catch { }
        }

        private void txtCodeSearch_TextChanged(object sender, EventArgs e)
        {

            BindLedgerDetailGrid();

        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtNameSearch.Text != "")
            {
                BindLedgerDetailGrid_OnSearch();
            }
            else
            {
                BindLedgerDetailGrid();
            }
        }

        private void txttax_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Delete || e.KeyChar == 8 || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtCodeSearch_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtmobile.Focus();
            }
        }

        private void txtadd_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbstate.Focus();
            }
        }

        private void cmbstate_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnSave.Focus();
            }
        }

        private void txtmobile_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtadd1.Focus();
            }
        }

        private void txttax_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtgstno.Focus();
            }
        }

        private void txtgstno_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtmobile.Focus();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            pnlLedgerDetails.Hide();
        }

        private void txtmobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Delete || e.KeyChar == 8 || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtadd1_KeyDown(object sender, KeyEventArgs e)
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
                cmbCompany.Focus();
            }
        }

        private void cmbtype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                dtdob.Focus();
            }
        }

        private void txtdob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                dtdoa.Focus();
            }
        }

        private void txtdoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnSave.Focus();
            }
        }

        private void dtdob_Leave(object sender, EventArgs e)
        {
            
      bool flag=   IsValidDate(dtdob);
            if(flag=false)
            
            {
                  MessageBox.Show("Please Enter Valid Date", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtdob_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
          
        }

        private void dtdob_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
            {
                dtdoa.Focus();
            }
        }

        private void dtdoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnSave.Focus();
            }
        }


        bool IsValidDate(MaskedTextBox dateTextBox)
        {
          
            string DateContents = dtdob.Text.Replace("/", "").Trim();

          
            if (!string.IsNullOrEmpty(DateContents) && DateContents != "")
            {
                // Split the original date into components:
                string[] dateSoFar = dtdob.Text.Split('/');
                string month = dateSoFar[0].Trim(); ;
                string day = dateSoFar[1].Trim();
                string year = dateSoFar[2].Trim();

                // If the component values are of the proper length for mm/dd/yyyy formatting:
                if (month.Length == 2
                    && day.Length == 2
                    && year.Length == 4
                    && (year.StartsWith("19") || year.StartsWith("20")))
                {
                    // Check to see if the string resolves to a valid date:
                    DateTime d;
                    if (!DateTime.TryParse(dateTextBox.Text, out d))
                    {
                    //   
                        return false;
                    }
                    else
                        // The string resolved to a valid date:
                        return true;
                }
                else
                {
                  //  MessageBox.Show("Please Enter Valid Date", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                } // End if Components are correctly sized
            }
            else
                // The date string is empty or whitespace - no date is a valid return:
                return true;
        }

        private void dtdoa_Leave(object sender, EventArgs e)
        {
            IsValidDate(dtdoa);
        }

        private void cmbCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtCode.Focus();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnSave.Focus();
            }
        }


       



        }
    
}