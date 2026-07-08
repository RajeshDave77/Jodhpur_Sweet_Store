using EdgePackingShared;
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
    public partial class HSN_CategoryMaster : Form
    {
        public HSN_CategoryMaster()
        {
            InitializeComponent();
        }
        database_admin class_Obj = new database_admin();
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHSN_CODE.Text != "" || txtHSN_CAT.Text != "")
                {
                    if (btnSave.Text == "Save")
                    {
                        int checkdup = AllCommonFunctions.Check_Duplicacy("HSN_Master", txtHSN_CAT.Text);
                        if (checkdup == 0)
                        {
                            id = 0;
                            bool flag = inventoryclass.HSN_InsertUpdate(id, txtHSN_CAT.Text, txtHSN_CODE.Text, Convert.ToDecimal(cmbtax.Text));
                            if (flag)
                            {
                                MessageBox.Show("HSN data successfully added.");
                                
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
                        
                        bool flag = inventoryclass.HSN_InsertUpdate(id, txtHSN_CAT.Text, txtHSN_CODE.Text, Convert.ToDecimal(cmbtax.Text));
                        if (flag)
                        {
                            MessageBox.Show("HSN data successfully updated.");
                            btnSave.Text = "Save";
                            ClearData();
                        }
                        else
                            MessageBox.Show("Data not saved");
                    }

                }
                else
                {
                    txtHSN_CAT.Focus();
                    txtHSN_CAT.BackColor = Color.Yellow;
                    txtHSN_CAT.BackColor = Color.Yellow;
                }
            }
            catch { }
        }
        
        public void ClearData()
         {
             txtHSN_CAT.Text = "";
             txtHSN_CODE.Text = "";
             txtHSNCodeSearch.Text = "";
             txtHSN_CATSearch.Text = "";

             try
             {
                 class_Obj.fill_combo(" select id,Tax_Per from Ledger_Master where Tax_Per>0", cmbtax, "ID", "Tax_Per");

             }
             catch { }
             BindInventoryDetailGrid();
         }
        public void BindInventoryDetailGrid()
        {
            dgvHSNMasterDetails.Columns.Clear();
            dgvHSNMasterDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11.0F, FontStyle.Regular);
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
            dgvHSNMasterDetails.Columns.Add(select);
            dgvHSNMasterDetails.Columns.Add(col1);
            dgvHSNMasterDetails.Columns.Add(edit);

            DataSet ds = new DataSet();
            ds = inventoryclass.HSN_GetData();
            dgvHSNMasterDetails.DataSource = ds.Tables[0];
            dgvHSNMasterDetails.Columns["ID"].Visible = false;

            dgvHSNMasterDetails.Columns["Cat_Name"].Width = 200;

            dgvHSNMasterDetails.Columns["HSN_Code"].Width = 80;
            dgvHSNMasterDetails.Columns["Tax"].Width = 80;

            foreach (DataGridViewRow row in dgvHSNMasterDetails.Rows)
            {

                row.Height = 42;
            }
            foreach (DataGridViewColumn c in dgvHSNMasterDetails.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Pixel);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        public void BindInventoryDetailGrid_OnSearch()
        {
            DataSet ds = new DataSet();
            ds = AllCommonFunctions.HSN_SearchData("HSN_Master", txtHSNCodeSearch.Text, txtHSN_CATSearch.Text);
            dgvHSNMasterDetails.DataSource = ds.Tables[0];
            //dgvHSNMasterDetails.Columns["ID"].Visible = false;
            //dgvHSNMasterDetails.Columns["Cat_Name"].Visible = false;
            //dgvHSNMasterDetails.Columns["HSN_Code"].Visible = false;
            //dgvHSNMasterDetails.Columns["Tax"].Visible = false;
        }
        int id=0;
        private void dgvHSNMasterDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvHSNMasterDetails.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                try
                {
                    id = Convert.ToInt32(dgvHSNMasterDetails.CurrentRow.Cells["ID"].Value);
                    txtHSN_CAT.Text = Convert.ToString(dgvHSNMasterDetails.CurrentRow.Cells["Cat_Name"].Value);
                    txtHSN_CODE.Text = Convert.ToString(dgvHSNMasterDetails.CurrentRow.Cells["HSN_Code"].Value);
                    string tx = Convert.ToString(Convert.ToDecimal(dgvHSNMasterDetails.CurrentRow.Cells["Tax"].Value));
                    cmbtax.Text = tx.ToString();

                    btnSave.Text = "Update";
             
                }
                catch (Exception ex)
                {

                }

            }
            else if (e.ColumnIndex == dgvHSNMasterDetails.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvHSNMasterDetails.CurrentRow.Cells["ID"].Value);
                    int a = AllCommonFunctions.Check_Used("HSN_Master", id);
                    if (a > 0)
                    {
                        MessageBox.Show("This HSN is already used. You can't delete this.");
                    }
                    else
                    {

                        if (MessageBox.Show("Are you sure to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                        {

                            bool flag = inventoryclass.HSN_Delete(id);
                            if (flag)
                            {
                                MessageBox.Show("Successfully Deleted");
                                BindInventoryDetailGrid();
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
        InventoryMasterClass inventoryclass = new InventoryMasterClass();
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void txtHSNCodeSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtHSNCodeSearch.Text != "")
            {
                BindInventoryDetailGrid_OnSearch();
            }
            else
            {
                BindInventoryDetailGrid();
            }
        }

        private void txtHSN_CAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtHSN_CODE.Focus();
            }
        }

        private void txtHSN_CODE_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void txtHSN_CODE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbtax.Focus();
            }
        }

        private void cmbtax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnSave.Focus();
            }
        }

        private void txtHSN_CATSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtHSN_CATSearch.Text != "")
            {
                BindInventoryDetailGrid_OnSearch();
            }
            else
            {
                BindInventoryDetailGrid();
            }
        }

        private void HSN_CategoryMaster_Load(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}
