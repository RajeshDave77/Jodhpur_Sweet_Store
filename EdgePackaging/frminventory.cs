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
    public partial class frminventory : Form
    {
        private MainIndex mainForm = null;
        private ComboBox cmb;
      
        public frminventory(Form callingForm)
        {
            mainForm = callingForm as MainIndex;
            InitializeComponent();
        }
        public frminventory(ComboBox combobox)
        {
           
            InitializeComponent();
            cmb = combobox;
           
            
        }
        database_admin da = new database_admin();
        int rcheck = 0;
        private void frminventory_Load(object sender, EventArgs e)
        {
            cmbStatus.Text = "Active";
            cmbPri.SelectedIndex = 0;
            try
            {
                da.fill_combo(" select distinct ID, Name from Inventory_Sub_Group_Master order by Name", cmbSubgroup, "ID", "Name");
                da.fill_combo(" select 0 as ID, '--Select--' as Name,1 as rtag union all select distinct ID, Name,2 as rtag from tblunit where rtag=0 order by rtag,Name", cmbKOT, "ID", "Name");
                da.fill_combo(" select 0 as ID, 'All' as Name union all select distinct ID, Name from Inventory_Sub_Group_Master order by Name", cmbSubgroup1, "ID", "Name");
                da.fill_combo(" select 0 as ID, '--Select--' as Name,1 as rtag union all select distinct ID, Name,2 as rtag from tblunit where rtag=1 order by rtag,Name", cmbLot1, "ID", "Name");
                da.fill_combo(" select 0 as ID, '--Select--' as Name,1 as rtag union all select distinct ID, Name,2 as rtag from tblunit where rtag=1 order by rtag,Name", cmbLot2, "ID", "Name");
                da.fill_combo(" select 0 as ID, '--Select--' as Name,1 as rtag union all select distinct ID, Name,2 as rtag from tblunit where rtag=1 order by rtag,Name", cmbLot3, "ID", "Name");
                cmbSubgroup.SelectedValue = 27;
                txtC1.Text = "1";
                txtC2.Text = "1";
                txtC3.Text = "1";

            }
            catch { }

            rcheck = 1;
            pnlBasicInformation.Show();
            //pnlInventoryDetails.Hide();
            txtcode.Focus();
            BindInventoryDetailGrid();

            cmbgst.SelectedIndex = 0;
            cmbPrint.SelectedIndex = 0;
            cmbKOT.SelectedValue = 0;
            int rcode = 0;
            rcode = Convert.ToInt32(da.value1("select isnull(max(convert(int,code)),0) as billno from inventory_master "));
            txtcode.Text = (Convert.ToInt32(rcode) + 1).ToString();
        }

        InventoryMasterClass inventoryclass = new InventoryMasterClass();
       
  

        private void txtgroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                    cmbSubgroup.Focus();
                }
            }

        private void txtunit_KeyDown(object sender, KeyEventArgs e)
        {
           
          
            }
       

        private void frminventory_KeyDown(object sender, KeyEventArgs e)
        {
          
        }
        public static int id;
        int checkFav = 0;
        public static int companyid = CompanyMasterClass.CompanyID;
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtname.Text == "")
                {
                  //  MessageBox.Show("Product Name Can't be Empty.");
                    MessageBox.Show("Please specify product name."," Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtname.Focus();
                    return;

                }

                if (txtcode.Text == "")
                {
                    MessageBox.Show("Please specify product code.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtcode.Focus();
                    return;

                }
                if (cmbSubgroup.Text == "")
                {
                    MessageBox.Show("Please specify product sub group.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSubgroup.Focus();
                    return;

                }
              
                //if (cmbunit.Text == "")
                //{
                //    MessageBox.Show("Unit Name Can't be Empty.");
                //    cmbunit.Focus();
                //    return;

                //}
                //if (txtrate.Text == "")
                //{
                //    MessageBox.Show("Please specify product rate.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtrate.Focus();
                //    return;

                //}
                if (cmbgst.Text == "")
                {
                    MessageBox.Show("Please specify product GST.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbgst.Focus();
                    return;

                }
                if (Convert.ToInt32(cmbKOT.SelectedValue) == 0)
                {
                    MessageBox.Show("Please select unit.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbKOT.Focus();
                    return;

                }
                if (Convert.ToInt32(cmbLot1.SelectedValue) == 0 )
                {
                    MessageBox.Show("Please select Lot.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbLot1.Focus();
                    return;

                }
                if(txtC1.Text=="")
                {
                    MessageBox.Show("Please specify conversion.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtC1.Focus();
                    return;
                }
                if (txtC1.Text == "0")
                {
                    MessageBox.Show("Please specify valid conversion.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtC1.Focus();
                    return;
                }
                //if (cmbHSN_Cat.Text == "")
                //{
                //    MessageBox.Show("HSN Category Can't be Empty.");
                //    cmbHSN_Cat.Focus();
                //    return;

                //}
             
               
             
                if (txtopeningstock.Text == "")
                {
                    txtopeningstock.Text =Convert.ToString(0);
                }
                if (txtcess.Text == "")
                {
                    txtcess.Text =Convert.ToString(0);
                }
                if (chkFav.Checked == true)
                {

                    checkFav = 1;
                }
                if (chkFav.Checked == false)
                {
                    checkFav = 0;
                }
                if (txtminlevel.Text == "" || txtminlevel.Text == null)
                {
                    txtminlevel.Text = Convert.ToString(0);
                }
                if (txtMaxLevel.Text == "" || txtMaxLevel.Text == null)
                {
            txtMaxLevel.Text=  Convert.ToString(0);
                }
                string lot1 = "";
                string lot2 = "";
                string lot3 = "";
                if(Convert.ToInt32(cmbLot1.SelectedValue)!=0)
                {
                    lot1 = cmbLot1.Text;
                }
                if (Convert.ToInt32(cmbLot2.SelectedValue) != 0)
                {
                    lot2 = cmbLot2.Text;
                }
                if (Convert.ToInt32(cmbLot3.SelectedValue) != 0)
                {
                    lot3 = cmbLot3.Text;
                }
                double conv1 = 1;
                double conv2 = 1;
                double conv3 = 1;
                
                if(txtC1.Text!="")
                {
                    conv1 = Convert.ToDouble(txtC1.Text);
                }
                if (txtC2.Text != "")
                {
                    conv2 = Convert.ToDouble(txtC2.Text);
                }
                if (txtC3.Text != "")
                {
                    conv3 = Convert.ToDouble(txtC3.Text);
                }
                if (txtcode.Text != "" || txtname.Text != "")
                {
                    if (btnSave.Text == "Save")
                    {
                        int checkdup = AllCommonFunctions.Check_Duplicacy("Inventory_Master", txtname.Text,txtcode.Text);
                        if (checkdup == 0)
                        {
                            int subgroupid = Convert.ToInt32(da.value1("select sgm.ID from Inventory_Sub_Group_Master as sgm join InventoryGroup_Master as IGM on IGM.ID=sgm.ParentGroup where sgm.Name='"+cmbSubgroup.Text+"'"));
                           
                            
                            id = 0;
                            bool flag = inventoryclass.Inventory_InsertUpdate(id, Form1.SingleCode(txtname.Text), txtcode.Text, 0, subgroupid, Convert.ToInt32(txtminlevel.Text), Convert.ToInt32(txtMaxLevel.Text), Convert.ToInt32(status), checkFav, txthsn.Text, Convert.ToDecimal(cmbgst.Text), Convert.ToDecimal(txtcess.Text), Convert.ToDecimal(txtopeningstock.Text), Convert.ToInt32(Form1.CompanyID), cmbPrint.Text, cmbPri.Text, cmbKOT.Text, Convert.ToInt32(cmbKOT.SelectedValue), lot1, lot2, lot3, Convert.ToInt32(cmbLot1.SelectedValue), Convert.ToInt32(cmbLot2.SelectedValue), Convert.ToInt32(cmbLot3.SelectedValue),conv1,conv2,conv3);
                            if (flag)
                            {
                               // MessageBox.Show("Product data successfully added.");
                                MessageBox.Show("Product successfully added. Please specify minimum level of this product.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               

                                if (this.cmb != null)
                                {
                                    da.fill_combo("select 0 as id,'' as name union all select ID,Name from Inventory_Master where status=1 order by name", this.cmb, "ID", "Name");
                                    this.cmb.Refresh();
                                    this.cmb.SelectedValue = Convert.ToInt32(da.value1("select max(ID) from Inventory_Master "));
                                    
                                    this.Close();
                                    return;
                                }
                                DataSet rstemp = new DataSet();
                                rstemp = da.dataset_ret("select top 1 id from inventory_master order by id desc");
                                if(rstemp.Tables[0].Rows.Count>0)
                                {
                                    Form1.PID =Convert.ToInt32( rstemp.Tables[0].Rows[0]["id"].ToString());
                                    Form1.PUnit = cmbKOT.Text;
                                }
                                ClearData();
                                if(Form1.PID>0)
                                {
                                    frmMinLevel frmminlevel = new frmMinLevel();
                                    frmminlevel.Show();
                                }
                            }
                            else
                                MessageBox.Show("Data not saved");
                        }
                        else
                        {
                          //  MessageBox.Show("Can't insert duplicate record.");
                            MessageBox.Show("You cannot insert duplicate record. Please try again.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                    }
                    else if (btnSave.Text == "Update")
                    {
                        int subgroupid = Convert.ToInt32(da.value1("select sgm.ID from Inventory_Sub_Group_Master as sgm join InventoryGroup_Master as IGM on IGM.ID=sgm.ParentGroup where sgm.Name='" + cmbSubgroup.Text + "'"));



                        bool flag = inventoryclass.Inventory_InsertUpdate(id, Form1.SingleCode(txtname.Text), txtcode.Text, 0, subgroupid, Convert.ToInt32(txtminlevel.Text), Convert.ToInt32(txtMaxLevel.Text), Convert.ToInt32(status), checkFav, txthsn.Text, Convert.ToDecimal(cmbgst.Text), Convert.ToDecimal(txtcess.Text), Convert.ToDecimal(txtopeningstock.Text), Convert.ToInt32(Form1.CompanyID), cmbPrint.Text, cmbPri.Text, cmbKOT.Text, Convert.ToInt32(cmbKOT.SelectedValue), lot1, lot2, lot3, Convert.ToInt32(cmbLot1.SelectedValue), Convert.ToInt32(cmbLot2.SelectedValue), Convert.ToInt32(cmbLot3.SelectedValue), conv1, conv2, conv3);
                        if (flag)
                        {
                         //   MessageBox.Show("Product data successfully updated.");
                            MessageBox.Show("Product Successfully Updated", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            btnSave.Text = "Save";
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
                }

            }
            catch (Exception ex)
            {
     //           MessageBox.Show(ex.ToString());
            }

        }
        public void ClearData()
        {
            txtname.Clear();
            txtcode.Clear();
            txtrate.Clear();
            txtminlevel.Clear();
            txtMaxLevel.Clear();
            cmbgst.Text = "";
            txtcess.Clear();
            txthsn.Clear();
            txtopeningstock.Clear();
            cmbgst.Text =Convert.ToString( 0);
            cmbSubgroup.SelectedValue = 27;
            cmbStatus.Text = "Active";
            chkFav.Checked = false;
            cmbPri.SelectedIndex = 0;
            int rcode = 0;
            rcode = Convert.ToInt32(da.value1("select isnull(max(convert(int,code)),0) as billno from inventory_master where  companyid='" + companyid + "'  "));
            txtcode.Text = (Convert.ToInt32(rcode) + 1).ToString();
            BindInventoryDetailGrid();
            cmbgst.ForeColor =Color.Black;
            cmbgst.BackColor = Color.White;

            cmbStatus.ForeColor = Color.Black;
            cmbStatus.BackColor = Color.White;

            chkFav.ForeColor = Color.Black;
            chkFav.BackColor = Color.White;
            cmbLot2.SelectedValue = 0;
            cmbLot3.SelectedValue = 0;
            txtC1.Text = "1";
            txtC2.Text = "1";
            txtC3.Text = "1";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
            btnSave.Text = "Save";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form1.PID = 0;
            this.Close();
        }

        private void btnInventoryDetailsClose_Click(object sender, EventArgs e)
        {
            //pnlInventoryDetails.Hide();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            BindInventoryDetailGrid();
            pnlInventoryDetails.Show();
        }
        public void BindInventoryDetailGrid()
        {
            DataSet ds = new DataSet();
            string rSearch = "";


            if (txtNameSearch.Text !="")
            {
                rSearch=" where im.Name like '%" + txtNameSearch.Text + "%' ";
            }

                if(cmbSubgroup1.Text!="All")
                {
                    if(rSearch=="")
                    {
                        rSearch=" where im.Inventory_S_Group=" + Convert.ToInt32(cmbSubgroup1.SelectedValue) ;
                    }
                    else
                    {
                         rSearch=rSearch+ " and im.Inventory_S_Group=" + Convert.ToInt32(cmbSubgroup1.SelectedValue) ;
                    }
                }
                if (txtSearchCode1.Text != "")
                {
                    if (rSearch == "")
                    {
                        rSearch = " where im.code = '" + txtSearchCode1.Text + "' ";
                    }
                    else
                    {
                        rSearch =rSearch+ " and im.code = '" + txtSearchCode1.Text + "' ";
                    }
                }
                if (txtSearchCode2.Text != "")
                {
                    if (rSearch == "")
                    {
                        rSearch = " where im.minlevel like '%" + txtSearchCode2.Text + "%' ";
                    }
                    else
                    {
                        rSearch = rSearch + " and im.minlevel like '%" + txtSearchCode2.Text + "%' ";
                    }
                }
                    ds = da.dataset_ret("select im.ID, im.Name,im.Code,im.Rate,sgm.Name as SubGroup,im.Minlevel,im.Maxlevel,im.FAV,im.hsn,im.gst,im.cess,im.Opening_Stock,(case im.status when '1' then 'Active' when '2' then 'Inactive' end) as Status,Rprint as [Barcode Print],rkotshow ,unit,lot1,lot2,lot3,lot1id,lot2id,lot3id,conv1,conv2,conv3 from Inventory_Master as im join Inventory_Sub_Group_Master as sgm on sgm.ID=im.Inventory_S_Group " + rSearch +"  order by im.id desc");
                    dgvProductGrid.Rows.Clear();
                
               
                
           
            int count = ds.Tables["tab"].Rows.Count;
            
            for (int i = 0; i < count; i++)
            {
             
                dgvProductGrid.Rows.Add();

                dgvProductGrid.Rows[i].Cells[3].Value = ds.Tables["tab"].Rows[i]["ID"].ToString();
                dgvProductGrid.Rows[i].Cells[4].Value = ds.Tables["tab"].Rows[i]["Name"].ToString();
                dgvProductGrid.Rows[i].Cells[5].Value = ds.Tables["tab"].Rows[i]["Code"].ToString();
                dgvProductGrid.Rows[i].Cells[6].Value = ds.Tables["tab"].Rows[i]["Rate"].ToString();
                dgvProductGrid.Rows[i].Cells[7].Value = ds.Tables["tab"].Rows[i]["SubGroup"].ToString();
                dgvProductGrid.Rows[i].Cells[8].Value = ds.Tables["tab"].Rows[i]["Minlevel"].ToString();
                dgvProductGrid.Rows[i].Cells[9].Value = ds.Tables["tab"].Rows[i]["Maxlevel"].ToString();
                dgvProductGrid.Rows[i].Cells[10].Value = ds.Tables["tab"].Rows[i]["FAV"].ToString();
                dgvProductGrid.Rows[i].Cells[11].Value = ds.Tables["tab"].Rows[i]["hsn"].ToString();
                dgvProductGrid.Rows[i].Cells[12].Value = ds.Tables["tab"].Rows[i]["gst"].ToString();
                dgvProductGrid.Rows[i].Cells[13].Value = ds.Tables["tab"].Rows[i]["cess"].ToString();
                dgvProductGrid.Rows[i].Cells[14].Value = ds.Tables["tab"].Rows[i]["Opening_Stock"].ToString();
                dgvProductGrid.Rows[i].Cells[15].Value = ds.Tables["tab"].Rows[i]["Status"].ToString();
                dgvProductGrid.Rows[i].Cells[16].Value = ds.Tables["tab"].Rows[i]["barcode print"].ToString();
                dgvProductGrid.Rows[i].Cells[17].Value = ds.Tables["tab"].Rows[i]["unit"].ToString();
                dgvProductGrid.Rows[i].Cells[18].Value = ds.Tables["tab"].Rows[i]["lot1"].ToString();
                dgvProductGrid.Rows[i].Cells[19].Value = ds.Tables["tab"].Rows[i]["lot2"].ToString();
                dgvProductGrid.Rows[i].Cells[20].Value = ds.Tables["tab"].Rows[i]["lot3"].ToString();
                dgvProductGrid.Rows[i].Cells[21].Value = ds.Tables["tab"].Rows[i]["lot1id"].ToString();
                dgvProductGrid.Rows[i].Cells[22].Value = ds.Tables["tab"].Rows[i]["lot2id"].ToString();
                dgvProductGrid.Rows[i].Cells[23].Value = ds.Tables["tab"].Rows[i]["lot3id"].ToString();

                dgvProductGrid.Rows[i].Cells[24].Value = ds.Tables["tab"].Rows[i]["conv1"].ToString();
                dgvProductGrid.Rows[i].Cells[25].Value = ds.Tables["tab"].Rows[i]["conv2"].ToString();
                dgvProductGrid.Rows[i].Cells[26].Value = ds.Tables["tab"].Rows[i]["conv3"].ToString();
                dgvProductGrid.Rows[i].Cells[27].Value = ds.Tables["tab"].Rows[i]["rkotshow"].ToString();
                DataGridViewRow row = dgvProductGrid.Rows[i];
                row.Height = 36;
                dgvProductGrid.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
            }
               
        }

        private void dgvInventoryMasterDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProductGrid.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                try
                {
                    //select im.ID, im.Name,im.Code,im.Rate,sgm.Name as SubGroup,um.Name as Unit,hsn.Cat_Name,im.Minlevel,im.Maxlevel,im.Reorder,im.Status,im.FAV 
               id = Convert.ToInt32(dgvProductGrid.CurrentRow.Cells["primaryid"].Value);
                    txtname.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells["Name"].Value);
                    txtcode.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells["Code"].Value);
                   txtrate.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells["Rate"].Value);
                    cmbSubgroup.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells["SubGroup"].Value);

                    txtminlevel.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells["Minlevel"].Value);
                    txtMaxLevel.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells["Maxlevel"].Value);
                    cmbStatus.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells["Statusactive"].Value);

                    string ci = Convert.ToString(dgvProductGrid.CurrentRow.Cells["FAV"].Value);

                    txthsn.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells["HSN"].Value);
                    cmbgst.Text=Convert.ToString (Convert.ToDouble( dgvProductGrid.CurrentRow.Cells["GST"].Value));
                    txtcess.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells["CESS"].Value);
                    txtopeningstock.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells["OpeningStock"].Value);
                    cmbPrint.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells[16].Value);
                    cmbKOT.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells[17].Value);

                    cmbLot1.SelectedValue = Convert.ToInt32(dgvProductGrid.CurrentRow.Cells[21].Value);
                    cmbLot2.SelectedValue = Convert.ToInt32(dgvProductGrid.CurrentRow.Cells[22].Value);
                    cmbLot3.SelectedValue = Convert.ToInt32(dgvProductGrid.CurrentRow.Cells[23].Value);

                    txtC1.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells[24].Value);
                    txtC2.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells[25].Value);
                    txtC3.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells[26].Value);
                    cmbPri.Text = Convert.ToString(dgvProductGrid.CurrentRow.Cells[27].Value);
                    if(ci!="0")
                    {
                        chkFav.Checked=true;
                    }
                    else
                    {
                        chkFav.Checked=false;
                    }
                
                    btnSave.Text = "Update";
                    //pnlInventoryDetails.Hide();
                }
                catch (Exception ex)
                {

                }

            }
            else if (e.ColumnIndex == dgvProductGrid.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvProductGrid.CurrentRow.Cells["primaryid"].Value);
              
                    try
                    {
                        int a = AllCommonFunctions.Check_Used("Inventory_Master123", id);
                     if (a > 0)
                    {
                       // MessageBox.Show("This inventory is already used. You can't delete this.");
                        MessageBox.Show("This Product is already used. You cannot delete this", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

                    }
                    catch{}
                  
                    if(true)
                    {

                        if (MessageBox.Show("Are you sure to Delete?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                        {
                            
                            bool flag = inventoryclass.Inventory_Delete(id);
                            if (flag)
                            {
                                MessageBox.Show("Successfully Deleted", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
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
        public void BindInventoryDetailGrid_OnSearch()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = AllCommonFunctions.Inventory_SearchData( txtNameSearch.Text);
                dgvProductGrid.DataSource = ds.Tables[0];
                foreach (DataGridViewRow row in dgvProductGrid.Rows)
                {

                    row.Height = 42;
                }
            }
            catch { }
        }
        
        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
           
            if (txtNameSearch.Text != "")
            {
                BindInventoryDetailGrid();
            }
            else
            {
                BindInventoryDetailGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvProductGrid.Rows)
                {
                    if (row.Cells["select"].Value != null)
                    {
                        if ((bool)(row.Cells["select"].Value) == true)
                        {
                            if (MessageBox.Show("Are you sure to Delete?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                            {
                                int id = Convert.ToInt32(dgvProductGrid.Rows[row.Index].Cells["primaryid"].Value.ToString());
                                int a = AllCommonFunctions.Check_Used("Inventory_Master", id);
                                if (a > 0)
                                {
                                    MessageBox.Show("This is already used. You can't delete this.");
                                }
                                else
                                {
                                    try
                                    {
                                        bool flag = inventoryclass.Inventory_Delete(id);
                                       
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Failed");
                                    }
                                }

                            }
                        }
                    }
                    BindInventoryDetailGrid();
                }
            }
            catch { }
        }

        private void btnOpen_Click_1(object sender, EventArgs e)
        {

        }

        private void txtpurrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&   (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtsalesrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtdisper_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

       
        private void txtclrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtopenstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtsgroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                    cmbSubgroup.Focus();
                }
            }

       

        private void pnlBasicInformation_Click(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

     
        private void txtQuality_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtgsm_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                    e.Handled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void dgvInventoryMasterDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int status = 1;
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus.Text == "Active")
            {
                status = 1;
            }
            if (cmbStatus.Text == "Inactive")
            {
                status = 2;
            }
        }
        public void BindCommonMasterDetailGrid_OnSearch()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = AllCommonFunctions.Inventory_SearchData(  txtNameSearch.Text);
                dgvProductGrid.DataSource = ds.Tables[0];
                dgvProductGrid.Columns["ID"].Visible = false;
                dgvProductGrid.Columns["CompanyID"].Visible = false;
            }
            catch { }
        }
        private void cmbsubgroupsearch_SelectedValueChanged(object sender, EventArgs e)
        {

            {
                BindInventoryDetailGrid();
            }
        }

        private void txtMinLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtMaxLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtrate_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab )
            {
                
                cmbgst.Focus();
            }
        }

        private void cmbSubgroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtcode.Focus();
            }
        }

        private void txttax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
               
            }
        }

        private void txtMinLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtMaxLevel.Focus();
            }
        }

        private void txtMaxLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (cmbStatus.Text != String.Empty)
                {
                    cmbStatus.ForeColor = Color.Red;
                    cmbStatus.BackColor = Color.Black;
                    
                    // Move the selection pointer to the end of the text of the control.
               //     cmbStatus.Select(cmbStatus.Text.Length, 0);
                }
                cmbStatus.Focus();
            }
        
        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txthsn.Focus();
            }
        }

        private void txtcode_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
               txtname.Focus();
            }
        }

        private void txtReorder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbStatus.Focus();
            }
        }

        private void cmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                chkFav.Focus();
            }
        }

        private void chkFav_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbPrint.Focus();
            }
        }

        private void pnlBasicInformation_Click_1(object sender, EventArgs e)
        {

        }

        private void labelX9_Click(object sender, EventArgs e)
        {

        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txthsn_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
            {
                cmbgst.Focus();
            }
        }

        private void cmbgst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbKOT.Focus();
            }
        }

        private void txtcess_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbKOT.Focus();
            }
        }

        private void txtminlevel_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtMaxLevel.Focus();
            }
        }

        private void txtcess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtopeningstock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtminlevel.Focus();
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow row in dgvProductGrid.Rows)
            {
                DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
                if ((bool)checkBox1.Checked == true)
                {
                    row.Cells[0].Value = true;
                }
                else
                {
                    row.Cells[0].Value = false;
                }
             
            }
       

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string intRowValue="";
            try
            {
                foreach (DataGridViewRow row in dgvProductGrid.Rows)
                {
                    if (row.Cells["select"].Value != null)
                    {
                        if (Convert.ToBoolean(row.Cells["select"].Value) == true)
                        {
                            if (intRowValue == "")
                            {
                                intRowValue = Convert.ToString(dgvProductGrid.Rows[row.Index].Cells["primaryid"].Value);
                            }
                            else
                            {
                                intRowValue = intRowValue + "," + Convert.ToString(dgvProductGrid.Rows[row.Index].Cells["primaryid"].Value);

                            }
                        }
                        else
                        {
                        //    MessageBox.Show("Please Select Rows", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                    }

                   
                }
                if(intRowValue=="")
                {
                    MessageBox.Show("Please Select Rows", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                    return;
                }
                if(txtupdategst.Text!="")
                {
                    da.insert_update_delete("update Inventory_Master set hsn='" + txtupdategst.Text + "' where id in (" + intRowValue + ")");

                }
                if(cmbgst1.Text!="")
                {
                    da.insert_update_delete("update Inventory_Master set gst=" + Convert.ToInt32(cmbgst1.Text) + " where id in (" + intRowValue + ")");

                }
             checkBox1.Checked = false;
             txtupdategst.Clear();
             cmbgst1.SelectedIndex = 0;
             MessageBox.Show("Successfully Updated", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
             BindInventoryDetailGrid();

            }
            catch { }
        }

        private void txtupdategst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtupdategst_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
            {
                buttonX1.Focus();
            }
        }

        private void labelX11_Click(object sender, EventArgs e)
        {

        }

        private void txtupdategst_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlInventoryDetails_Click(object sender, EventArgs e)
        {

        }

        private void txtopeningstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtminlevel_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cmbgst_KeyPress(object sender, KeyPressEventArgs e)
        {
      //      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      //(e.KeyChar != '.'))
      //      {
      //          e.Handled = true;
      //      }

      //      // only allow one decimal point
      //      if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
      //      {
      //          e.Handled = true;
      //      }
            e.Handled = true;
        }

      

        private void cmbSubgroup_Leave(object sender, EventArgs e)
        {
            if(cmbSubgroup.Text!="")
            {
                int a = AllCommonFunctions.Check_Duplicacys("Inventory_Sub_Group", cmbSubgroup.Text);
                if (a == 0)
                {
                    MessageBox.Show("Please Insert Valid Sub Group", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbSubgroup.Focus();
                    return;
                }
                else
                {
                    txtcode.Focus();
                }
            }
            
        }

        private void cmbStatus_Enter(object sender, EventArgs e)
        {
            if (cmbStatus.Text != String.Empty)
            {
                cmbStatus.ForeColor = Color.Red;
                cmbStatus.BackColor = Color.LightYellow;
                // Move the selection pointer to the end of the text of the control.
                cmbStatus.Select(cmbStatus.Text.Length, 0);
            }
        }

        private void cmbgst_Enter(object sender, EventArgs e)
        {
          
                cmbgst.ForeColor = Color.Red;
                cmbgst.BackColor = Color.LightYellow;

                // Move the selection pointer to the end of the text of the control.
                cmbgst.Select(cmbStatus.Text.Length, 0);
            }

        private void chkFav_Enter(object sender, EventArgs e)
        {
            chkFav.ForeColor = Color.Red;
            chkFav.BackColor = Color.LightYellow;

            // Move the selection pointer to the end of the text of the control.
          //  chkFav.Select(chkFav.Text.Length, 0);
        }

        private void cmbStatus_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbSubgroup1_TextChanged(object sender, EventArgs e)
        {
           if(rcheck==1)
           {
               BindInventoryDetailGrid();
           }
            
            
        }

        private void cmbPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbPri.Focus();
            }
        }

        private void cmbKOT_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void cmbKOT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnSave.Focus();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchCode1_TextChanged(object sender, EventArgs e)
        {
          
            if (txtSearchCode1.Text != "")
            {
                BindInventoryDetailGrid();
            }
            else
            {
                BindInventoryDetailGrid();
            }
        }

        private void txtSearchCode2_TextChanged(object sender, EventArgs e)
        {
         
            if (txtSearchCode2.Text != "")
            {
                BindInventoryDetailGrid();
            }
            else
            {
                BindInventoryDetailGrid();
            }
        }

        private void txtNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtSearchCode1.Focus();
            }
        }

        private void txtSearchCode1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtSearchCode2.Focus();
            }
        }

        private void txtSearchCode2_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtSearchCode2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbSubgroup.Focus();
            }
        }

        private void cmbKOT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string intRowValue = "";
            try
            {
                foreach (DataGridViewRow row in dgvProductGrid.Rows)
                {
                    if (row.Cells["select"].Value != null)
                    {
                        if (Convert.ToBoolean(row.Cells["select"].Value) == true)
                        {
                            if (intRowValue == "")
                            {
                                intRowValue = Convert.ToString(dgvProductGrid.Rows[row.Index].Cells["primaryid"].Value);
                            }
                            else
                            {
                                intRowValue = intRowValue + "," + Convert.ToString(dgvProductGrid.Rows[row.Index].Cells["primaryid"].Value);

                            }
                        }
                        else
                        {
                            //    MessageBox.Show("Please Select Rows", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                    }


                }
                if (intRowValue == "")
                {
                    MessageBox.Show("Please Select Rows", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                    return;
                }

                da.insert_update_delete("update Inventory_Master set rprint='" + cmbPrint.Text + "' where id in (" + intRowValue + ")");



                checkBox1.Checked = false;

                MessageBox.Show("Successfully Updated", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                BindInventoryDetailGrid();

            }
            catch { }
        }

        private void txtC1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void labelX24_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void cmbLot1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                txtC1.Focus();
            }
        }

        private void txtC1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbLot2.Focus();
            }
        }

        private void cmbLot2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtC2.Focus();
            }
        }

        private void txtC2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbLot3.Focus();
            }
        }

        private void cmbLot3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtC3.Focus();
            }
        }

        private void txtC3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void cmbPri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbLot1.Focus();
            }
        }
        

      
    }
}
