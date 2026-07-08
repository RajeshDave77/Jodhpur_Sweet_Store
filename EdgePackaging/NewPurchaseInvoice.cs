//using EdgeDairy;

using EdgeVastra;
using EdgeVastra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using EdgePack;
using System.Drawing;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EdgePackingShared;


namespace EdgePackaging
{
    public partial class NewPurchaseInvoice : Form
    {
        private MainIndex mainForm = null;
        public NewPurchaseInvoice(Form callingForm)
        {
            mainForm = callingForm as MainIndex;
            InitializeComponent();
        }
        database_admin da = new database_admin();
        public static DataTable dsNew = new DataTable();
        int RComboCheck = 0;
        int rcheck = 0;
        PurchaseInvoiceClass pic = new PurchaseInvoiceClass();
        DataSet ds = new DataSet();
        public static int id;
        int companyid = Form1.CompanyID;
        private void btnLedgerDetailsClose_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }
        public void setgrid()
        {
            try
            {
                int netqty = 0;
                decimal netamtf = 0;

                int rowcount = dgvChallanDetail.Rows.Count;
                for (int i = 0; i < rowcount; i++)
                {

                    dgvChallanDetail.Rows[i].Cells[3].Value = Convert.ToString(i + 1);

                    //dgvChallanDetail.Rows[i].Cells[7].Value = Convert.ToString(Math.Round(Convert.ToDecimal(Convert.ToDecimal(dgvChallanDetail.Rows[i].Cells[5].Value) * (Convert.ToDecimal(dgvChallanDetail.Rows[i].Cells[6].Value))), 2));
                    int plo = Convert.ToInt32(Math.Round(Convert.ToDecimal(dgvChallanDetail.Rows[i].Cells[5].Value), 0));
                    dgvChallanDetail.Rows[i].Cells[5].Value = Convert.ToString(plo);
                    int klm = Convert.ToInt32((netqty + plo));
                    netqty = klm;
                    netamtf = netamtf + Convert.ToDecimal(dgvChallanDetail.Rows[i].Cells[7].Value);
                  //  dgvChallanDetail.Rows[i].Cells[8].Value = Convert.ToString(Convert.ToDecimal(dgvChallanDetail.Rows[i].Cells[8].Value));
                    dgvChallanDetail.Rows[i].Cells[7].Value = Convert.ToString(Convert.ToDecimal(dgvChallanDetail.Rows[i].Cells[7].Value));
                    DataGridViewRow row = dgvChallanDetail.Rows[i];
                    row.Height = 50;
                }
                if (dgvChallanDetail.Rows.Count > 0)
                {
                    dgvChallanDetail.FirstDisplayedScrollingRowIndex = dgvChallanDetail.Rows.Count - 1;
                }

                txttotalqty.Text = Convert.ToString(netqty);
                txttotalamt.Text = Convert.ToString(netamtf);

            }
            catch { MessageBox.Show("S.No Not Valid (function ->(SetGrid)"); }
        }
       
        public void ClearData()
        {
            rcheck = 1;
            da.fill_combo(" select 0 as ID, '--Select--' as Name,1 as rtag union all select distinct ID, Name,2 as rtag from tblunit where rtag=0 order by rtag,Name", cmbUnit, "ID", "Name");
            da.fill_combo(" select 0 as ID, '--Select--' as Name,1 as rtag union all select distinct ID, Name,2 as rtag from tblunit where rtag=1 order by rtag,Name", cmbUnit1, "ID", "Name");
            cmbUnit.Enabled = true;
            cmbUnit1.Enabled = true;
            dgvChallanDetail.Rows.Clear();
            btnSave.Text = "&Save";
            btnadds.Text = "&Add";
            txtMiscExp.Text = "";
            txtNetAmount.Text = "";
            txtRoff.Text = "";
            txtBatchNo.Text = "";
            txtinvoice.Clear();
            cmbparty.SelectedValue = 0;
            txttotalamt.Clear();
            lblStock.Text = "";
            txttotalqty.Clear();
            txtremark.Text = "";
            txtRemark1.Text = "";
            txtQuantity1.Text = ""; txtQuantity2.Text = ""; txtConv.Text = "1";
            cmbUnit.SelectedValue = 0; cmbUnit1.SelectedValue = 0;
            cmbSubLocation.SelectedValue = 0;
            rValue = 0;
            dsNew.Dispose();
            dsNew.Clear();
            da.fill_comboNew("select 0 as id,'' as name union all select ID,Name from Inventory_Master where status=1 order by name", cmbitem, "ID", "Name", dsNew);
            txtBAmount.Text = "";
            txtDisPer.Text = "";
            txtDisAmt.Text = "";
            txtAfAmount.Text = "";
            txtGST.Text = "";
            txtGSTAmt.Text = "";
            txtTotDisAmt.Text = "";
            intRowModify = 0;
            txtrate.Clear();
            txtamount.Clear();
            txttotalamt.Clear();
            txttotalqty.Clear();
            txtTotAAmount.Text = "";
            btnadds.Tag = "";
            txtTotADis.Text = "";
            txtTotGstAmt.Text = "";
            dtinvoice.Text = DateTime.Now.ToString("yyyy-MM-dd").ToString();
          //  labelX12.Text = "Rate (Stock Qty.)";
            dtEx.Value = DateTime.Now;
            dtEx.Checked = false;
            Entryno = 0;
            SetEntryNo();
            rcheck = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ClearData();
            checkBox1.Checked = false;
            dgvChallanDetail.Rows.Clear();
            groupPanel3.Location = new Point(6, 0);
            groupPanel3.Show();
            //dtfromdate.Enabled = false;
            //dttodate.Enabled = false;
            chkdate.Checked = true;
            txtpartysearch.Focus();
            fillgrid();
          
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to reset fields?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }

            ClearData();
           
        }
        int rowedit = 0;
        private void dgvChallanDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dgvChallanDetail.Rows[e.RowIndex].ReadOnly = true;
            if (e.ColumnIndex ==2 && e.RowIndex >= 0)
            {

                if (MessageBox.Show("Are you sure want to delete this record?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                dgvChallanDetail.Rows.Remove(dgvChallanDetail.CurrentRow);
                SetTotal();
                rcheck = 1;
                txtQuantity1.Text = "1";
                cmbitem.SelectedValue = 0;
                txtrate.Clear();
                txtBAmount.Text = ""; txtRemark1.Text = "";
                txtDisPer.Text = "";
                txtDisAmt.Text = "";
                txtAfAmount.Text = "";
                txtGST.Text = "";
                txtGSTAmt.Text = "";
                btnadds.Tag = "";
                txtConv.Text = ""; cmbUnit.SelectedValue = 0; txtQuantity2.Text = ""; cmbUnit1.SelectedValue = 0;
                intRowModify = 0;
                int intl = 0;
                for (intl = 0; intl <= dgvChallanDetail.RowCount - 1; intl++)
                {
                    dgvChallanDetail.Rows[intl].Cells[3].Value = Convert.ToString(intl + 1);
                }
                btnadds.Text = "&Add";
                rcheck = 0;
                cmbitem.Focus();

            }
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                rcheck = 1;
                rValue = Convert.ToInt32(dgvChallanDetail.CurrentRow.Cells[18].Value.ToString());
                cmbitem.SelectedValue = rValue;
                ShowUnit();
                rcheck = 1;
                 txtQuantity1.Text = dgvChallanDetail.CurrentRow.Cells[5].Value.ToString();
                 cmbUnit.Text = dgvChallanDetail.CurrentRow.Cells[6].Value.ToString();
                 txtConv.Text = dgvChallanDetail.CurrentRow.Cells[7].Value.ToString();
                 txtQuantity2.Text = dgvChallanDetail.CurrentRow.Cells[8].Value.ToString();
                 cmbUnit1.Text = (dgvChallanDetail.CurrentRow.Cells[9].Value.ToString()+'_'+txtConv.Text);
                 txtrate.Text = dgvChallanDetail.CurrentRow.Cells[10].Value.ToString();
               txtBAmount.Text = dgvChallanDetail.CurrentRow.Cells[11].Value.ToString();
                 txtDisPer.Text = dgvChallanDetail.CurrentRow.Cells[12].Value.ToString();
                 txtDisAmt.Text = dgvChallanDetail.CurrentRow.Cells[13].Value.ToString();
            txtAfAmount.Text = dgvChallanDetail.CurrentRow.Cells[14].Value.ToString();
              txtGST.Text = dgvChallanDetail.CurrentRow.Cells[15].Value.ToString();
            txtGSTAmt.Text = dgvChallanDetail.CurrentRow.Cells[16].Value.ToString();
                 txtamount.Text = dgvChallanDetail.CurrentRow.Cells[17].Value.ToString();
               
                 btnadds.Tag = dgvChallanDetail.CurrentRow.Cells[19].Value.ToString();
                 txtRemark1.Text = dgvChallanDetail.CurrentRow.Cells[20].Value.ToString();
                 if (dgvChallanDetail.CurrentRow.Cells[22].Value.ToString()!="")
                 {
                     
                     dtEx.Text = dgvChallanDetail.CurrentRow.Cells[22].Value.ToString();
                     dtEx.Checked = true;
                 }
                 else
                 {
                     
                     dtEx.Value = DateTime.Now;
                     dtEx.Checked = false;
                 }
                 cmbSubLocation.SelectedValue = dgvChallanDetail.CurrentRow.Cells[24].Value.ToString();
                 if (dgvChallanDetail.CurrentRow.Cells[25].Value!=null)
                 {
                     txtBatchNo.Text = dgvChallanDetail.CurrentRow.Cells[25].Value.ToString();
                 }
                 else
                 {
                     txtBatchNo.Text = "";
                 }

                
                 GETStock(1);
                intRowModify = (e.RowIndex) + 1;
                btnadds.Text = "&Update";
                rcheck = 0;
                txtQuantity1.Focus();
            }
            else if (e.ColumnIndex > 2 && e.RowIndex >= 0)
            {
                dgvChallanDetail.Rows[e.RowIndex].ReadOnly = true;
            }
            else
            {
                dgvChallanDetail.Rows[e.RowIndex].ReadOnly = false;
            }
            
        }
        int Entryno = 0;
        private void SetEntryNo()
        {
            int billno = 0;

            try
            {
                billno = Convert.ToInt32(da.value1("select max(entryno)as billno from stockinwardmaster where stocktype='" + cmbStockType.Text + "' and finyear='" + Form1.CurrFinYear + "'  "));
            }
            catch
            {
                billno = 0;
            }
            Entryno = Convert.ToInt32(billno + 1);
            txtinvoice.Text = Convert.ToInt32(billno + 1).ToString();
        } 
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = false;

            try
            {
                if (txtinvoice.Text == "")
                {
                    MessageBox.Show("Please specify Invoice No", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtinvoice.Focus();
                    return;
                }
                if (Convert.ToInt32( cmbparty.SelectedValue)==0)
                {
                    MessageBox.Show("Please Select Party.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbparty.Focus();
                    return;
                }
                  if(dgvChallanDetail.Rows.Count==0)
                  {
                      MessageBox.Show("Please specify product detail.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                      cmbitem.Focus();
                      return;
                  }

                //int partyid =Convert.ToInt32( da.value1("select id from Ledger_Master where name ='"+cmbparty.Text+"'"));
               double exp = 0;
                if(txtMiscExp.Text!="")
                {
                    exp = Convert.ToDouble(txtMiscExp.Text);
                }
                double roff = 0;
                if (txtRoff.Text != "")
                {
                    roff = Convert.ToDouble(txtRoff.Text);
                }

                  int mastid = 0;
                  if (btnSave.Text == "&Save")
                    {
                         mastid = pic.Stock_InwardMaster(id,Form1.SingleCode( cmbparty.Text), Convert.ToInt32(cmbparty.SelectedValue), cmbStockType.Text, txtinvoice.Text, dtinvoice.Text, txtremark.Text, Convert.ToInt32(cmbCompany.SelectedValue), Convert.ToInt32(Form1.UserID), Entryno, Form1.CurrFinYear,exp,roff);


           
                  }
                  else if (btnSave.Text == "&Update")
                  {
                      int upid =Convert.ToInt32(txtChallan1.Text);
                      mastid = pic.Stock_InwardMaster(upid, Form1.SingleCode(cmbparty.Text), Convert.ToInt32(cmbparty.SelectedValue), cmbStockType.Text, txtinvoice.Text, dtinvoice.Text, txtremark.Text, Convert.ToInt32(cmbCompany.SelectedValue), Convert.ToInt32(Form1.UserID), Entryno, Form1.CurrFinYear,exp,roff);

                      da.insert_update_delete("delete from StockInwardDetail where masterid=" + mastid);
                   
                  }
                  string rGridValues = "";
                  foreach (DataGridViewRow row in dgvChallanDetail.Rows)
                  {
                      if(rGridValues=="")
                      {
                          rGridValues = "(" + Convert.ToInt32(row.Cells[18].Value) + "," + Convert.ToDouble(row.Cells[5].Value) + ",'" + row.Cells[6].Value.ToString() + "'," + Convert.ToDouble(row.Cells[7].Value) + "," + Convert.ToDouble(row.Cells[8].Value) + ",'" + row.Cells[9].Value.ToString() + "'," + Convert.ToDecimal(row.Cells[10].Value) + "," + Convert.ToDecimal(row.Cells[11].Value) + "," + Convert.ToDecimal(row.Cells[12].Value) + "," + Convert.ToDecimal(row.Cells[13].Value) + "," + Convert.ToDecimal(row.Cells[14].Value) + "," + Convert.ToDecimal(row.Cells[15].Value) + "," + Convert.ToDecimal(row.Cells[16].Value) + "," + Convert.ToDecimal(row.Cells[17].Value) + "," + mastid + ",'" + Form1.SingleCode(row.Cells[20].Value.ToString()) + "','" + row.Cells[21].Value.ToString() + "','" + row.Cells[22].Value.ToString() + "',"+row.Cells[24].Value.ToString()+")";
                      }
                      else
                      {
                          rGridValues = rGridValues + ",(" + Convert.ToInt32(row.Cells[18].Value) + "," + Convert.ToDouble(row.Cells[5].Value) + ",'" + row.Cells[6].Value.ToString() + "'," + Convert.ToDouble(row.Cells[7].Value) + "," + Convert.ToDouble(row.Cells[8].Value) + ",'" + row.Cells[9].Value.ToString() + "'," + Convert.ToDecimal(row.Cells[10].Value) + "," + Convert.ToDecimal(row.Cells[11].Value) + "," + Convert.ToDecimal(row.Cells[12].Value) + "," + Convert.ToDecimal(row.Cells[13].Value) + "," + Convert.ToDecimal(row.Cells[14].Value) + "," + Convert.ToDecimal(row.Cells[15].Value) + "," + Convert.ToDecimal(row.Cells[16].Value) + "," + Convert.ToDecimal(row.Cells[17].Value) + "," + mastid + ",'" + Form1.SingleCode(row.Cells[20].Value.ToString()) + "','" + row.Cells[21].Value.ToString() + "','" + row.Cells[22].Value.ToString() + "'," + row.Cells[24].Value.ToString() + ")";

                      }
                  }
                  da.insert_update_delete("INSERT INTO StockInwardDetail (product,qty,[Unit],Conv,Conqty,ConUnit,Rate,BAmount,DisPer,DisAmt,ADisAmt,GST,GSTAmt,Amount,Masterid,remark,exdate,exdate1,sublocationid) values " + rGridValues);
                  flag = true;
                if (flag)
                {
                    string invno = "";
                    if(txtinvoice.Text.Length>2)
                    {
                        invno = txtinvoice.Text.Substring(0, 3);
                    }
                    else
                    {
                        invno = txtinvoice.Text;
                    }
                  da.insert_update_delete("update stockinwarddetail set batchno=aa.batchno from (select (inventory_master.name+'_'+'"+cmbparty.Text.Substring(0,4)+"'+'_'+'"+dtinvoice.Value.ToString("ddMMyyyy")+"'+'_'+'"+invno+"') as batchno,stockinwarddetail.id from stockinwarddetail left join inventory_master on inventory_master.id=product where masterid="+mastid+") as aa where aa.id=stockinwarddetail.id");

                  
                    ClearData();
               
                }

            } 
            catch { }

        }
    private void SetBatchNo(int MasterID)
        {
            DataSet rstemp = new DataSet();
        }
        private void NewPurchaseInvoice_Load(object sender, EventArgs e)
        {

            rcheck = 1;
            dsNew.Dispose();
            dsNew.Clear();
            if (MainIndex.formname == "Purchase")
            {
                cmbStockType.Text = "Purchase";
                this.Text = "Purchase Detail";
                label8.Text = "Purchase Detail";
                pnlBasicInformation.Text = "Purchase Detail";
            }
            else if (MainIndex.formname == "Purchase Return")
            {
                cmbStockType.Text = "Purchase Return";
                this.Text = "Purchase Return Detail";
                label8.Text = "Purchase Return Detail";
                pnlBasicInformation.Text = "Purchase Return Detail";
            }
            //da.fill_combo("select id,(name) as name from ledger_Master where type in ('Shop','Godown') order by name", cmbCompany, "ID", "Name");
            da.fill_combo("select id,(name) as name from ledger_Master where type in ('Godown') order by name", cmbCompany, "ID", "Name");
            cmbCompany.SelectedValue = Form1.CompanyID;
            if (Form1.UserID==1)
            {
                cmbCompany.Enabled = true;
            }
            da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Shop') and companyid=" + cmbCompany.SelectedValue + " order by  rtag,name", cmbSubLocation, "ID", "Name");
            da.fill_combo("select 0 as id,'---Select Party---' as Name,1 as rtag union all select ID,Name,2 as rtag from Ledger_Master where companyid=" + Form1.Godownid + " and type='Supplier' order by rtag,name", cmbparty, "ID", "Name");
          

            da.fill_comboNew("select 0 as id,'' as name union all select ID,Name from Inventory_Master where status=1 order by name", cmbitem, "ID", "Name", dsNew);
            da.fill_combo(" select 0 as ID, '--Select--' as Name,1 as rtag union all select distinct ID, Name,2 as rtag from tblunit where rtag=0 order by rtag,Name", cmbUnit, "ID", "Name");
            da.fill_combo(" select 0 as ID, '--Select--' as Name,1 as rtag union all select distinct ID, Name,2 as rtag from tblunit where rtag=1 order by rtag,Name", cmbUnit1, "ID", "Name");
            SetEntryNo();
          
            //cmbparty.SelectedValue = 0;
           
            cmbparty.Focus();
            if (Form1.utype!=0)
            {
                //buttonX1.Visible = false;
                //buttonX2.Visible = false;
              //  dgvopengrid.Columns[1].Visible = false;
                dgvopengrid.Columns[2].Visible = false;
            }
            rcheck = 0;
        }
       
        private void cmbparty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

              
                cmbCompany.Focus();
               
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cmbparty.SelectedValue = 0;
                cmbparty.SelectAll();
            }
        }

        public void fillgrid()
        {
           
           
            try
            {
                  string invdt = "";
                    string invtdt ="";
              
                
                DataSet ds = new DataSet();
              
                if(chkdate.Checked==true)
                {
                     invdt = dtfromdate.Value.Date.ToString("yyyy-MM-dd");
                     invtdt = dttodate.Value.Date.ToString("yyyy-MM-dd");
                }
                else
                {
                     invdt = "";
                     invtdt = "";
                }
               if(Form1.UserID==1)
               {
                   ds = pic.Inward_GetData(txtpartysearch.Text, MainIndex.formname, invdt, invtdt, txtinvsearch.Text, 1);
               }
               else
               {
                   ds = pic.Inward_GetData(txtpartysearch.Text, MainIndex.formname, invdt, invtdt, txtinvsearch.Text, companyid);
               }
                dgvopengrid.DataSource = ds.Tables[0];

                dgvopengrid.Columns["ID"].Visible = false;
                dgvopengrid.Columns["CompanyID"].Visible = false;
                dgvopengrid.Columns["stocktype"].Visible = false;
                //dgvopengrid.Columns["Remark"].Visible = false;
                dgvopengrid.Columns["Userid"].Visible = false;
                dgvopengrid.Columns["invoicedate1"].Visible = false;
                // dgvopengrid.Columns["Product"].Visible = false;
                dgvopengrid.Columns["importtag"].Visible = false;

                dgvopengrid.Columns["party"].Visible = false;
                dgvopengrid.Columns["id"].Visible = false;
                dgvopengrid.Columns["Remark"].Visible = false;
                dgvopengrid.Columns["entryno"].Visible = false;

               
                foreach (DataGridViewRow row in dgvopengrid.Rows)
                {

                    row.Height = 37;
                  
                }
                int i = 0;
                //foreach (DataGridViewColumn c in dgvopengrid.Columns)
                //{
                //    c.DefaultCellStyle.Font = new Font("Arial", 11.0F, FontStyle.Regular, GraphicsUnit.Pixel);
                //}
                for (i = 0; i < dgvopengrid.Rows.Count; i++)
                {
                    dgvopengrid.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);

                }
                double rTotal = 0; double rTotal1 = 0;
                int intl = 0;
                txtGridTotalQty.Text = "";
                txtGridTotalAmt.Text = "";
                for (intl = 0; intl <= dgvopengrid.RowCount - 1; intl++)
                {

                    rTotal = rTotal + Convert.ToDouble(dgvopengrid.Rows[intl].Cells[15].Value);
                    rTotal1 = rTotal1 + Convert.ToDouble(dgvopengrid.Rows[intl].Cells[16].Value);

                }
                txtGridTotalQty.Text = rTotal.ToString();
                txtGridTotalAmt.Text = rTotal1.ToString();

            }
            catch { }


        }

        private void cmbpartysearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fillgrid();
            }
        }

        private void txtinvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                dtinvoice.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbQuality1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                dgvChallanDetail.Rows.Clear();
                ds = da.dataset_ret("select ID,Quality,Size,Party,Weight,quantity,ChallanNo,Quality1 from PurchaseChallan where Quality ='" + cmbitem.Text + "' and Flag=" + 1 + "");
                int count = ds.Tables["tab"].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    dgvChallanDetail.Rows.Add();
                    dgvChallanDetail.Rows[i].Cells[3].Value = ds.Tables["tab"].Rows[i]["ID"];
                    dgvChallanDetail.Rows[i].Cells[4].Value = ds.Tables["tab"].Rows[i]["Quality"];
                    dgvChallanDetail.Rows[i].Cells[5].Value = ds.Tables["tab"].Rows[i]["Size"];
                    dgvChallanDetail.Rows[i].Cells[6].Value = ds.Tables["tab"].Rows[i]["quantity"];
                    dgvChallanDetail.Rows[i].Cells[7].Value = ds.Tables["tab"].Rows[i]["Weight"];
                    dgvChallanDetail.Rows[i].Cells[8].Value = ds.Tables["tab"].Rows[i]["Party"];
                    dgvChallanDetail.Rows[i].Cells[9].Value = ds.Tables["tab"].Rows[i]["ChallanNo"];
                    dgvChallanDetail.Rows[i].Cells[11].Value = ds.Tables["tab"].Rows[i]["Quality1"];

                    //  dgvPurchase.Rows[i].Cells[8].Value = ds.Tables["tab"].Rows[i]["Quality"];

                }
                txtChallan.Focus();
                txtinvoice.Focus();
            }
            //cmbunit.Focus();
        }


        private void cmbsize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtQuantity1.Focus();
            }
        }

        private void txtQuantity1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 txtrate.Focus();
            //   cmbUnit.Focus();
               // txtConv.Focus();
            }
        }

        private void txtweight1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            //{
            //    textBox5.Focus();
            //}
        }

        private void txtrate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtDisPer.Focus();
            }
        }

        private void txtinvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
          

        }

        private void txtsize1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }

        }

        private void txtQuantity1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.' || e.KeyChar == '-'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '-' && txtDecimal.Text.Contains("-"))
            {
                e.Handled = true;
            }
        }

        private void txtweight1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }

        }

        private void txtrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }

        }

        private void cmbparty_Leave(object sender, EventArgs e)
        {
            //if (cmbparty.Text != "")
            //{
            //    int checkdups = AllCommonFunctions.Check_Duplicacy("PartyName", cmbparty.Text.ToString());
            //    if (checkdups == 0)
            //    {
            //        MessageBox.Show("Please Select Appropriate Party Name","Edge Solutions",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //        cmbparty.Focus();
            //    }
            //}
        }

        private void cmbsize_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cmbunit.Text != "")
            //    {
            //        int checkdups = AllCommonFunctions.CheckInt_Duplicacys("Size", Convert.ToInt32(cmbunit.Text));
            //        if (checkdups == 0)
            //        {
            //            MessageBox.Show("Invalid Size ");
            //            cmbunit.Focus();
            //        }
            //    }
            //}
            //catch { }
        }

        private void cmbsize_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbweight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //textBox5.Focus();
            }
        }

        private void txtQuantity1_Leave(object sender, EventArgs e)
        {
            //if (txtQuantity1.Text != "")
            //{
            //    decimal sumweight = Convert.ToDecimal(da.value1("select Quantity from Purchase where ReelSize='" + cmbunit.Text + "' and Quality='" + cmbitem.Text + "'"));
            //    if (Convert.ToDecimal(txtQuantity1.Text) > sumweight)
            //    {
            //        MessageBox.Show("Invalid Value");
            //        txtQuantity1.Text = Convert.ToString(sumweight);
            //        txtQuantity1.Focus();
            //    }
            //}
        }

        private void dgvChallanEdit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvChallanEdit.Columns["Remove"].Index && e.RowIndex >= 0)
                {
                    if (MessageBox.Show("Are you sure to Delete?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        da.insert_update_delete("delete from NewPurchaseInvoice where ID='" + dgvChallanEdit.CurrentRow.Cells[2].Value + "'");
                        //  dgvChallanDetail.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("Successfully Deleted");
                        dgvChallanEdit.Refresh();
                    }

                }
            }

            catch (Exception ex)
            {

            }
        }

        private void cmbqtynew_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cmbqtynew.Text != "")
            //    {
            //        int checkdups = AllCommonFunctions.CheckInt_Duplicacys("RellQuality", Convert.ToInt32(cmbqtynew.Text));
            //        if (checkdups == 0)
            //        {
            //            MessageBox.Show("Invalid Quality ");
            //            cmbqtynew.Focus();
            //        }
            //    }
            //}
            //catch { }
        }

        private void cmbqtynew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnadd.Focus();
            }
        }
        double qty = 0;
        double rate = 0;
        private void txtrate_TextChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            SetMargin();
        }
        int rValue = 0;
        private void cmbitem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                RComboCheck = 1;

                if (Convert.ToInt32(cmbitem.SelectedValue) != 0)
                {
                    cmbitem.Text = cmbitem.GetItemText(cmbitem.SelectedItem);
                    //  cmbitem.SelectedValue = cmbitem.GetItemText(cmbitem.SelectedValue);
                }
                cmbitem.DroppedDown = false;
                RComboCheck = 0;
                txtQuantity2.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                RComboCheck = 1;
                dsNew.Dispose();
                dsNew.Clear();
                //cmbitem.Text = "";

                rValue = 0;
                da.fill_comboNew("select 0 as id,'' as name union all select ID,Name from Inventory_Master where status=1 order by name", cmbitem, "ID", "Name", dsNew);


                cmbitem.SelectAll();
                RComboCheck = 0;
            }
            else if (e.KeyCode == Keys.Up)
            {
                RComboCheck = 1;
            }
            else if (e.KeyCode == Keys.Down)
            {
                RComboCheck = 1;
            }
        }

        private void cmbitem_Leave(object sender, EventArgs e)
        {
            //if (cmbitem.Text != "")
            //{
            //    int checkdups = AllCommonFunctions.Check_Duplicacy("Inventory_Master", cmbitem.Text.ToString());
            //    if (checkdups == 0)
            //    {
            //        MessageBox.Show("Please Enetr a Valid Product Name","Edge Solutions",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //        cmbitem.Focus();
            //    }
            //}
        }

        private void cmbunit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbparty.Focus();
            }
        }

        private void dtinvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbparty.Focus();
            }
        }

        private void txtremark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void cmbunit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantity1.Focus();
            }
        }

        private void txtamount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnadds.Focus();
            }
        }

        private void btnclosedgv_Click(object sender, EventArgs e)
        {
            groupPanel3.Hide();
        }

        private void txtQuantity1_Enter(object sender, EventArgs e)
        {
         //   txtQuantity1.Text = Convert.ToString(1);
        }

     

        private void txtamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

       
        

        private void txtItemsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
            {
                btnsearch.Focus();
            }
        }

        private void txtItemsearch_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            int count = dgvChallanDetail.Rows.Count;
            for(int i=0;i<count;i++)
            {
                if(Convert.ToBoolean(dgvChallanDetail.Rows[i].Cells[0].Value)==true)
                {
                    try
                    {
                        if (dgvChallanDetail.Rows[i].Cells[7].Value != "")
                        {
                            da.insert_update_delete("delete from StockInwardDetail where id=" + dgvChallanDetail.Rows[i].Cells[7].Value + "");
                            dgvChallanDetail.Refresh();
                            if(dgvChallanDetail.Rows.Count==0)
                            {
                                da.insert_update_delete("delete from StockInwardMaster where id=" + txtChallan1.Text + "");
                            }
                            fillgrid();
                           
                        }
                    }

                    catch
                    {
                        dgvChallanDetail.Rows.RemoveAt(i);
                        dgvChallanDetail.Refresh();
                    }
            }
              
            }
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //ds = "select Product,Quantity,Rate,Amount from dgvChallanDetail where product like '%'+"+txtproductsearch.Text+"+'%'";
            //int count = ds.Tables["tab"].Rows.Count;
            //dgvChallanDetail.Rows.Add();
           
            //for(int i=0;i<count;i++)
            //{
            //    dgvChallanDetail.Rows[i].Cells[3].Value = ds.Tables["tab"].Rows[i]["Product"].ToString();
            //    dgvChallanDetail.Rows[i].Cells[4].Value = ds.Tables["tab"].Rows[i]["Quantity"].ToString();
            //    dgvChallanDetail.Rows[i].Cells[5].Value = ds.Tables["tab"].Rows[i]["Rate"].ToString();
            //    dgvChallanDetail.Rows[i].Cells[6].Value = ds.Tables["tab"].Rows[i]["Amount"].ToString();

            //}
        }

        private void pnlBasicInformation_Click(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            fillgrid();
        }

        private void chkdate_CheckedChanged(object sender, EventArgs e)
        {
            if(Convert.ToBoolean(chkdate.Checked)==true)
            {
                dtfromdate.Enabled = true;
              
                dttodate.Enabled = true;
            }
            else  if(Convert.ToBoolean(chkdate.Checked)==false)
            {
                //dtfromdate.Enabled = false;
                dtfromdate.Text = "";
                //dttodate.Enabled = false;
                dttodate.Text = "";
              
            }
        }

        private void txtinvsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
            {
                txtpartysearch.Focus();
            }
        }

        private void dtfromdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                dttodate.Focus();
            }
        }

        private void dttodate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtinvsearch.Focus();
            }
        }

        private void cmbitem_TextChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            if (RComboCheck == 1) { return; }
            SetSearchCombo(cmbitem, dsNew);
         }

        private void groupPanel3_Click_1(object sender, EventArgs e)
        {

        }

   

        private void cmbparty_Validating(object sender, CancelEventArgs e)
        {
            if (cmbparty.Text.Trim() == "" || Convert.ToInt32(cmbparty.SelectedIndex) == -1)
            {
                MessageBox.Show("Please select valid name.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbparty.Focus();
                e.Cancel = true;
                return;
            }
          
        }

        private void cmbitem_Validating(object sender, CancelEventArgs e)
        {
            if (cmbitem.Text.Trim() != "")
            {
                if (cmbitem.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select valid name.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbitem.Focus();
                    e.Cancel = true;
                    return;
                }
                if (cmbitem.SelectedValue == null)
                {
                    MessageBox.Show("Please select valid name.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbitem.Focus();
                    e.Cancel = true;
                    return;
                }
            }
            if (cmbitem.Text.Trim() != "")
            {
                GETStock(1);
                ShowUnit();
                DataSet rsTemp = new DataSet();
                if (MainIndex.formname == "Purchase")
                {
                    if (Convert.ToInt32(cmbparty.SelectedValue) == 0)
                    {
                        rsTemp = da.dataset_ret("select Unit,rate,gst,lot1,conv1 from Inventory_Master where Name='" + Form1.SingleCode(cmbitem.Text) + "' ");
                        txtrate.Text = "0";
                        cmbUnit.SelectedValue = 0; cmbUnit1.SelectedValue = 0;
                        txtGST.Text = "";
                        if (rsTemp.Tables[0].Rows.Count > 0)
                        {
                            rcheck = 1;
                            txtrate.Text = rsTemp.Tables[0].Rows[0]["rate"].ToString();
                            cmbUnit.Text = rsTemp.Tables[0].Rows[0]["Unit"].ToString();
                           // labelX12.Text = "Rate Per : " +rsTemp.Tables[0].Rows[0]["Unit"].ToString();
                            cmbUnit1.Text = rsTemp.Tables[0].Rows[0]["lot1"].ToString();
                            txtGST.Text = rsTemp.Tables[0].Rows[0]["gst"].ToString();
                            //txtConv.Text = rsTemp.Tables[0].Rows[0]["conv1"].ToString();
                            txtConv.Text = "1";
                            rcheck = 0;
                            cmbUnit.Enabled = false;
                            SetMargin();
                        }
                    }
                    else
                    {
                        rsTemp = da.dataset_ret("select top 1 conv,StockInwardDetail.Unit,StockInwardDetail.rate,stockinwarddetail.gst,lot1 from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid left join inventory_master on inventory_master.id=product where party=" + Convert.ToInt32(cmbparty.SelectedValue) + " and product=" + Convert.ToInt32(cmbitem.SelectedValue) + " order by stockinwarddetail.id desc");
                        txtrate.Text = "0";
                        cmbUnit.SelectedValue = 0; txtGST.Text = ""; cmbUnit1.SelectedValue = 0;
                        cmbUnit.Enabled = false;
                        if (rsTemp.Tables[0].Rows.Count > 0)
                        {
                            rcheck = 1;
                            txtrate.Text = rsTemp.Tables[0].Rows[0]["rate"].ToString();
                            cmbUnit.Text = rsTemp.Tables[0].Rows[0]["Unit"].ToString();
                            cmbUnit1.Text = rsTemp.Tables[0].Rows[0]["lot1"].ToString();
                            txtGST.Text = rsTemp.Tables[0].Rows[0]["gst"].ToString();
                            txtConv.Text = rsTemp.Tables[0].Rows[0]["conv"].ToString();
                            rcheck = 0;
                            SetMargin();
                        }
                        else
                        {
                            rsTemp.Dispose(); rsTemp.Clear();
                            rsTemp = da.dataset_ret("select Unit,rate,gst,lot1,conv1 from Inventory_Master where Name='" + Form1.SingleCode(cmbitem.Text) + "' ");
                            if (rsTemp.Tables[0].Rows.Count > 0)
                            {
                                rcheck = 1;
                                txtrate.Text = rsTemp.Tables[0].Rows[0]["rate"].ToString();
                                cmbUnit.Text = rsTemp.Tables[0].Rows[0]["Unit"].ToString();
                                cmbUnit1.Text = rsTemp.Tables[0].Rows[0]["lot1"].ToString();
                                txtGST.Text = rsTemp.Tables[0].Rows[0]["gst"].ToString();
                                txtConv.Text = rsTemp.Tables[0].Rows[0]["conv1"].ToString();
                                rcheck = 0;
                                SetMargin();
                            }
                        }
                    }
                }
                else
                {
                    rsTemp = da.dataset_ret("select Unit,rate,gst,lot1,conv1 from Inventory_Master where Name='" + Form1.SingleCode(cmbitem.Text) + "' ");
                    txtrate.Text = "0";
                    cmbUnit.SelectedValue = 0; txtGST.Text = ""; cmbUnit1.SelectedValue = 0; cmbUnit.Enabled = false;
                    if (rsTemp.Tables[0].Rows.Count > 0)
                    {
                        rcheck = 1;
                        txtrate.Text = rsTemp.Tables[0].Rows[0]["rate"].ToString();
                        cmbUnit.Text = rsTemp.Tables[0].Rows[0]["Unit"].ToString();
                        cmbUnit1.Text = rsTemp.Tables[0].Rows[0]["lot1"].ToString();
                        txtGST.Text = rsTemp.Tables[0].Rows[0]["gst"].ToString();
                        txtConv.Text = rsTemp.Tables[0].Rows[0]["conv1"].ToString();
                        rcheck = 0;
                        SetMargin();
                    }
                }
            }
            
        }
        private void ShowUnit()
        {
            rcheck = 1;
            if(Convert.ToInt32(cmbitem.SelectedValue)>0)
            {
                //da.fill_combo(" select 0 as ID, '--Select--' as Name,1 as rtag union all select  tblUnit.ID,tblUnit.name,2 as rtag from tblUnit left join Inventory_Master on Inventory_Master.Unit=tblUnit.name where rtag=0 and Inventory_Master.ID=" + Convert.ToInt32(cmbitem.SelectedValue) + " union all select  ID, Name,2 as rtag from tblunit where rtag=1 and id in (select isnull(lot1id,0) as id1 from inventory_master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + " union all select isnull(lot2id,0) as id1 from inventory_master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + " union all select isnull(lot3id,0) as id1 from inventory_master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + ") order by rtag,Name", cmbUnit1, "ID", "Name");
                da.fill_combo(" select 0 as ID, '--Select--' as Name,0 as rtag union all select  tblUnit.ID,(tblUnit.Name+'_1') as Name,2 as rtag from tblUnit left join Inventory_Master on Inventory_Master.Unit=tblUnit.name where rtag=0 and Inventory_Master.ID=" + Convert.ToInt32(cmbitem.SelectedValue) + " union all select  tblUnit.ID,(tblUnit.name+'_'+cast(conv1 as varchar(10))) as Name,1 as rtag from tblUnit left join Inventory_Master on Inventory_Master.lot1id=tblUnit.id where rtag=1 and Inventory_Master.id=" + Convert.ToInt32(cmbitem.SelectedValue) + " union all select  tblUnit.ID,(tblUnit.name+'_'+cast(conv2 as varchar(10))) as Name,1 as rtag from tblUnit left join Inventory_Master on Inventory_Master.lot2id=tblUnit.id where rtag=1 and Inventory_Master.id=" + Convert.ToInt32(cmbitem.SelectedValue) + " union all select  tblUnit.ID,(tblUnit.name+'_'+cast(conv3 as varchar(10))) as Name,1 as rtag from tblUnit left join Inventory_Master on Inventory_Master.lot3id=tblUnit.id where rtag=1 and Inventory_Master.id=" + Convert.ToInt32(cmbitem.SelectedValue) + " order by rtag,Name", cmbUnit1, "ID", "Name");
                 if(cmbUnit1.Items.Count>1)
                 {
                     cmbUnit1.Enabled = true;
                 }
                 else
                 {
                     cmbUnit1.Enabled = false;
                 }
            }
            rcheck = 0;
        }
        private void GETStock(int rtag)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet rsTemp = new DataSet();
                if (rtag == 1)
                {
                    rsTemp = da.dataset_ret("select (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0)))) as stock from ( " +
                                 "  (select id,code,name,unit,minlevel from Inventory_Master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + ") as a left join  " +
                                 "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master) as aa group by aa.product) as aaa on a.id=aaa.product " +
                                "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                               "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(Form1.CompanyID) + " ) and StockType in ('Purchase','Issue Return') group by product union all select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                               "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(Form1.CompanyID) + ") and StockType in ('Issue','Issue Return') group by product) as aa group by aa.product) as inward on a.id=inward.product " +
                                "   left join (select product,sum(qty) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product) as outward on a.id=outward.product " +
                                 "  left join (select product,sum(qty) as consumed from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Consumed') group by product) as consumed on a.id=consumed.product " +
                                 "  left join (select product,sum(qty) as damages from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                 "  where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Damages') group by product) as damages on a.id=damages.product " +
                                   "  left join (select product,sum(qty) as wastage from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                 "  where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Wastage') group by product) as wastage on a.id=wastage.product " +
                                 " ) order by a.name");
                }
                
                lblStock.Text = "Stock : 0";
                if (rsTemp.Tables[0].Rows.Count > 0)
                {
                    lblStock.Text = "Stock : " + Math.Round(Convert.ToDouble(rsTemp.Tables[0].Rows[0]["stock"].ToString()), 3).ToString();
                }
                this.Cursor = Cursors.Default;
            }
            catch
            {
                this.Cursor = Cursors.Default;
            }
        }
        string rowFilterText = string.Empty;
        string text;
        DataView listDataView;
        DataTable dt = new DataTable();
        public void SetSearchCombo(ComboBox rName, DataTable dt)
        {
            text = rName.Text;
            if (text == "") { return; }
            //Gets the filter text
            rowFilterText = "[" + dt.Columns[dt.Columns[rName.DisplayMember].Ordinal].ColumnName + "]" + " LIKE '" + "%" + rName.Text + "%'";
            listDataView = new DataView(dt, rowFilterText, null, DataViewRowState.CurrentRows);
            if (listDataView.Count > 0)
            {
                //Gets the data source of the ComboBoxAdv
                RComboCheck = 1;
                rName.DataSource = listDataView;

                //if(text!="")
                //{
                rName.Text = text;
                //}
                rName.DroppedDown = true;
                rName.SelectionStart = text.Length;
                rName.SelectionLength = rName.Text.Length;

                RComboCheck = 0;
                return;
            }
            else
            {
                text = "";
                rName.DroppedDown = false;
                rName.SelectionStart = rName.Text.Length;
            }
        }
        private void SetMargin()
        {
            try
            {
                txtBAmount.Text = "";
                txtAfAmount.Text = "";
                txtamount.Text = "";
                txtGSTAmt.Text = "";
                if (txtQuantity1.Text != "")
                {
                    if (txtrate.Text == "0") { return; }
                    if (txtrate.Text != "" && txtrate.Text != "0")
                    {
                        double rAmt = 0;
                        txtBAmount.Text = Math.Round((Convert.ToDouble(txtQuantity1.Text) * Convert.ToDouble(txtrate.Text)), 2).ToString();
                        if (txtDisPer.Text != "" && txtDisPer.Text != "0")
                        {
                            rAmt = ((Convert.ToDouble(txtQuantity1.Text) * Convert.ToDouble(txtrate.Text)) * (Convert.ToDouble(txtDisPer.Text) / 100));
                            txtDisAmt.Text = Math.Round(rAmt, 2).ToString();
                            rAmt = ((Convert.ToDouble(txtQuantity1.Text) * Convert.ToDouble(txtrate.Text)) - Convert.ToDouble(rAmt));
                        }
                        else if (txtDisAmt.Text != "" && txtDisAmt.Text != "0")
                        {
                            rAmt = ((Convert.ToDouble(txtQuantity1.Text) * Convert.ToDouble(txtrate.Text)) - Convert.ToDouble(txtDisAmt.Text));
                            txtDisPer.Text = Math.Round(((Convert.ToDouble(txtDisAmt.Text) / (Convert.ToDouble(txtQuantity1.Text) * Convert.ToDouble(txtrate.Text))) * 100), 2).ToString();
                        }
                        else
                        {
                            rAmt = (Convert.ToDouble(txtQuantity1.Text) * Convert.ToDouble(txtrate.Text));
                        }

                        txtAfAmount.Text = Math.Round(rAmt, 2).ToString();
                        txtamount.Text = Math.Round(rAmt, 2).ToString();
                        if (txtGST.Text != "" && txtGST.Text != "0")
                        {
                            rAmt = (Convert.ToDouble(Math.Round(rAmt, 2)) * (Convert.ToDouble(txtGST.Text) / 100));
                            txtGSTAmt.Text = Math.Round(rAmt, 2).ToString();
                            txtamount.Text = Math.Round((Convert.ToDouble(txtamount.Text) + Convert.ToDouble(rAmt)), 2).ToString();
                        }

                    }

                }
            }
            
            catch
            {

            }
        }

        private void txtQuantity1_TextChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            if (rcheck == 1)
            {
                return;
            }
            try
            {
                double r1 = 0; double r2 = 0;
                if (txtQuantity1.Text != "")
                {
                    r1 = Convert.ToDouble(txtQuantity1.Text);
                }
                if (txtConv.Text != "")
                {
                    r2 = Convert.ToDouble(txtConv.Text);
                }
                if(r2!=0)
                {
                    rcheck = 1;
                    txtQuantity2.Text = Math.Round((r1 / r2), 2).ToString();
                    rcheck = 0;
                }
                
            }
            catch
            {

            }
            SetMargin();
        }

        private void txtDisPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtDisPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if(txtDisPer.Text=="")
                {
                    txtDisAmt.Focus();
                }
                else
                {
                    txtGST.Focus();
                }
            }
        }

        private void txtDisPer_TextChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            if (rAmt1 == 1) { return; }
            rAmt1 = 1;
            txtDisAmt.Text = "";
            SetMargin();
            rAmt1=0;
        }

        private void txtDisAmt_TextChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            if (rAmt1 == 1) { return; }
            rAmt1 = 1;
            txtDisPer.Text = "";
            SetMargin();
            rAmt1 = 0;
        }

        private void txtDisAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                
                    txtGST.Focus();
                
            }
        }

        private void txtDisAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtGST_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtRemark1.Focus();
            }
        }
        int intRowModify = 0;
        int rAmt1 = 0;
        private void btnadds_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbitem.SelectedValue) == 0)
            {
                MessageBox.Show("Please select product.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbitem.Focus();
                return;
            }
            if (txtQuantity1.Text == "")
            {
                MessageBox.Show("Please specify quantity.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity1.Focus();
                return;
            }
            if (txtQuantity2.Text == "")
            {
                MessageBox.Show("Please specify quantity.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity2.Focus();
                return;
            }
            //if (txtrate.Text == "")
            //{
            //    MessageBox.Show("Please specify rate.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtrate.Focus();
            //    return;
            //}
            if (MainIndex.formname == "Purchase")
            {
                if (dtEx.Checked == false)
                {
                    DataSet rstemp = new DataSet();
                    rstemp = da.dataset_ret("select rprint from inventory_master where id=" + Convert.ToInt32(cmbitem.SelectedValue));
                    if (rstemp.Tables[0].Rows[0]["rprint"].ToString() == "Yes")
                    {
                        MessageBox.Show("Please specify expirty date.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }
                }
            }
          
            if ((btnadds.Text == "&Add"))
            {
              
                BindGrid(0, 0);
            }
            else if ((intRowModify != 0))
            {
                BindGrid((intRowModify - 1), 1);
                btnadds.Text = "&Add";
                cmbparty.Focus();
                intRowModify = 0;
            }
            else
            {
                MessageBox.Show("There are no row for updation.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BindGrid(int intRow, int rMode)// function for set  grid
        {
            int rowCount;

            if ((rMode == 0))
            {
                rowCount = dgvChallanDetail.Rows.Add();
            }
            else
            {
                rowCount = intRow;
            }
            double disper = 0; double disamt = 0; double afamount = 0; double gst = 0; double gstamt = 0; double conv = 0; double bamount = 0;double amount=0;
            if (txtDisPer.Text!="")
            {
                disper = Convert.ToDouble(txtDisPer.Text);
            }
            if (txtDisAmt.Text != "")
            {
                disamt = Convert.ToDouble(txtDisAmt.Text);
            }
            if (txtAfAmount.Text != "")
            {
                afamount = Convert.ToDouble(txtAfAmount.Text);
            }
            if (txtGST.Text != "")
            {
                gst = Convert.ToDouble(txtGST.Text);
            }
            if (txtGSTAmt.Text != "")
            {
                gstamt = Convert.ToDouble(txtGSTAmt.Text);
            }
            if(txtConv.Text!="")
            {
                conv = Convert.ToDouble(txtConv.Text);
            }
            if (txtBAmount.Text != "")
            {
                bamount = Convert.ToDouble(txtBAmount.Text);
            }
            if (txtamount.Text != "")
            {
                amount = Convert.ToDouble(txtamount.Text);
            }
            dgvChallanDetail.Rows[rowCount].Cells[3].Value = Convert.ToInt32(rowCount) + 1;
            dgvChallanDetail.Rows[rowCount].Cells[4].Value = cmbitem.Text;
            dgvChallanDetail.Rows[rowCount].Cells[5].Value = txtQuantity1.Text;
            dgvChallanDetail.Rows[rowCount].Cells[6].Value = cmbUnit.Text;
            dgvChallanDetail.Rows[rowCount].Cells[7].Value = conv;
            dgvChallanDetail.Rows[rowCount].Cells[8].Value = txtQuantity2.Text;
            string[] rvar = cmbUnit1.Text.Split('_');
            //dgvChallanDetail.Rows[rowCount].Cells[9].Value = cmbUnit1.Text;
            dgvChallanDetail.Rows[rowCount].Cells[9].Value = rvar[0];
            dgvChallanDetail.Rows[rowCount].Cells[10].Value = txtrate.Text;
            dgvChallanDetail.Rows[rowCount].Cells[11].Value = bamount;
            dgvChallanDetail.Rows[rowCount].Cells[12].Value = disper;
            dgvChallanDetail.Rows[rowCount].Cells[13].Value = disamt;
            dgvChallanDetail.Rows[rowCount].Cells[14].Value = afamount;
            dgvChallanDetail.Rows[rowCount].Cells[15].Value = gst;
            dgvChallanDetail.Rows[rowCount].Cells[16].Value = gstamt;
            dgvChallanDetail.Rows[rowCount].Cells[17].Value = amount;
            dgvChallanDetail.Rows[rowCount].Cells[18].Value = cmbitem.SelectedValue;
            //if(btnadds.Tag=="")
            //{
                dgvChallanDetail.Rows[rowCount].Cells[19].Value = 0;
                dgvChallanDetail.Rows[rowCount].Cells[20].Value = txtRemark1.Text;
            if(dtEx.Checked==true)
            {
                dgvChallanDetail.Rows[rowCount].Cells[21].Value = dtEx.Value.ToString("dd/MM/yyyy");
                dgvChallanDetail.Rows[rowCount].Cells[22].Value = dtEx.Value.ToString("yyyy-MM-dd");
                dgvChallanDetail.Rows[rowCount].Cells[4].Value = cmbitem.Text + " Ex.Date : " + dtEx.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                dgvChallanDetail.Rows[rowCount].Cells[21].Value = "";
                dgvChallanDetail.Rows[rowCount].Cells[22].Value = "";
            }
            if(Convert.ToInt32(cmbSubLocation.SelectedValue)!=0)
            {
                dgvChallanDetail.Rows[rowCount].Cells[23].Value = cmbSubLocation.Text;
                dgvChallanDetail.Rows[rowCount].Cells[24].Value = cmbSubLocation.SelectedValue;
            }
            else
            {
                dgvChallanDetail.Rows[rowCount].Cells[23].Value = "";
                dgvChallanDetail.Rows[rowCount].Cells[24].Value = 0;
            }
            //}
            //else
            //{
            //    dgvChallanDetail.Rows[rowCount].Cells[15].Value = btnadds.Tag;
            //}
            SetTotal();
            rcheck = 1;
            txtQuantity1.Text = ""; txtQuantity2.Text = ""; txtConv.Text = "1"; lblStock.Text = "";
            cmbitem.SelectedValue = 0;
            dsNew.Dispose();
            dsNew.Clear();
            da.fill_comboNew("select 0 as id,'' as name union all select ID,Name from Inventory_Master where status=1 order by name", cmbitem, "ID", "Name", dsNew);
            txtrate.Clear();
            txtBAmount.Text = "";
            txtDisPer.Text = "";
            txtDisAmt.Text = "";
            txtAfAmount.Text = "";
            txtBatchNo.Text = "";
            txtGST.Text = "";
            txtGSTAmt.Text = ""; txtRemark1.Text = "";
            btnadds.Tag = "";
           // labelX12.Text = "Rate (Stock Qty.)";
            da.fill_combo(" select 0 as ID, '--Select--' as Name,1 as rtag union all select distinct ID, Name,2 as rtag from tblunit where rtag=0 order by rtag,Name", cmbUnit, "ID", "Name");
            da.fill_combo(" select 0 as ID, '--Select--' as Name,1 as rtag union all select distinct ID, Name,2 as rtag from tblunit where rtag=1 order by rtag,Name", cmbUnit1, "ID", "Name");

            cmbUnit.SelectedValue = 0; cmbUnit1.SelectedValue = 0;
            intRowModify = 0;
           
            txtamount.Clear();
            cmbitem.Focus();
            rcheck = 0;
        }

        private void SetTotal()
        {
            try
            {
                double tot1 = 0; double tot2 = 0; double tot3 = 0; double tot4 = 0; double tot5 = 0; double tot6 = 0;

                foreach (DataGridViewRow row in dgvChallanDetail.Rows)
                {
                    tot6 = tot6 + Convert.ToDouble(dgvChallanDetail.Rows[row.Index].Cells[5].Value);
                    if (dgvChallanDetail.Rows[row.Index].Cells[11].Value.ToString()!="")
                    {
                        tot1 = tot1 + Convert.ToDouble(dgvChallanDetail.Rows[row.Index].Cells[11].Value);
                    }
                    if (dgvChallanDetail.Rows[row.Index].Cells[13].Value.ToString() != "")
                    {
                        tot2 = (tot2 + Convert.ToDouble(dgvChallanDetail.Rows[row.Index].Cells[13].Value));
                    }
                    if (dgvChallanDetail.Rows[row.Index].Cells[14].Value.ToString()!="")
                    {
                        tot3 = (tot3 + Convert.ToDouble(dgvChallanDetail.Rows[row.Index].Cells[14].Value));
                    }
                    if (dgvChallanDetail.Rows[row.Index].Cells[16].Value.ToString()!="")
                    {
                        tot4 = (tot4 + Convert.ToDouble(dgvChallanDetail.Rows[row.Index].Cells[16].Value));
                    }
                    if (dgvChallanDetail.Rows[row.Index].Cells[17].Value.ToString()!="")
                    {
                        tot5 = (tot5 + Convert.ToDouble(dgvChallanDetail.Rows[row.Index].Cells[17].Value));
                    }
                    
                }
                txttotalqty.Text = Math.Round(tot6, 2).ToString();
                txtTotAAmount.Text = Math.Round(tot1, 2).ToString();
                txtTotDisAmt.Text = Math.Round(tot2, 2).ToString();
                txtTotADis.Text = Math.Round(tot3, 2).ToString();
                txtTotGstAmt.Text = Math.Round(tot4, 2).ToString();
                txttotalamt.Text = Math.Round(tot5, 2).ToString();
                double exp = 0;
                if (txtMiscExp.Text != "")
                {
                    exp = Convert.ToDouble(txtMiscExp.Text);
                }
                double d1 = 0;
                double d2 = 0;
                d1 = Math.Round((Convert.ToDouble(txttotalamt.Text) + Convert.ToDouble(exp)), 2);
                d2 = Math.Round((Convert.ToDouble(txttotalamt.Text) + Convert.ToDouble(exp)), 0);
                txtRoff.Text=Math.Round((d2-d1),2).ToString();
                //txtNetAmount.Text = (Convert.ToDouble(txttotalamt.Text) + Convert.ToDouble(exp)).ToString();
                txtNetAmount.Text = d2.ToString();
            }
          catch
            { }
        }

        private void txtGST_TextChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            SetMargin();
        }

        private void txtConv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.' ))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
          
        }

        private void txtConv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode==Keys.Tab)
            {
                //   txtrate.Focus();
                txtQuantity2.Focus();
            }
        }

        private void cmbUnit_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtConv.Focus();
            }
        }

        private void cmbUnit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtrate.Focus();
            }
        }

        private void txtQuantity2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.' || e.KeyChar == '-'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '-' && txtDecimal.Text.Contains("-"))
            {
                e.Handled = true;
            }
        }

        private void txtQuantity2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(cmbUnit1.Enabled==true)
                {
                    cmbUnit1.Focus();
                }
                else
                {
                    txtQuantity1.Focus();
                }
            }
        }

        private void txtConv_TextChanged(object sender, EventArgs e)
        {
            if(rcheck==1)
            {
                return;
            }
            //try
            //{
            //    double r1 = 0; double r2 = 0;
            //    if(txtQuantity1.Text!="")
            //    {
            //        r1 = Convert.ToDouble(txtQuantity1.Text);
            //    }
            //    if(txtConv.Text!="")
            //    {
            //        r2 = Convert.ToDouble(txtConv.Text);
            //    }
            //    txtQuantity2.Text = Math.Round((r1 * r2), 2).ToString();
            //}
            //catch
            //{

            //}
        }

        private void txtRemark1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                dtEx.Focus();
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvopengrid.Rows)
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            string intRowValue = "";
            try
            {
                foreach (DataGridViewRow row in dgvopengrid.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value) == true)
                        {
                            if (intRowValue == "")
                            {
                                intRowValue = Convert.ToString(dgvopengrid.Rows[row.Index].Cells["id"].Value);
                            }
                            else
                            {
                                intRowValue = intRowValue + "," + Convert.ToString(dgvopengrid.Rows[row.Index].Cells["id"].Value);

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
                    MessageBox.Show("Please select row to be deleted.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                    return;
                }
                if (MessageBox.Show("Are you sure want to delete challan?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.No) { return; }

                da.insert_update_delete("delete from StockInwardDetail where masterid in (" + intRowValue + ")");

                da.insert_update_delete("delete from StockInwardMaster where id in (" + intRowValue + ")");

                fillgrid();
            }
            catch
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvopengrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dgvopengrid.Rows[e.RowIndex].ReadOnly = true;
            if (e.ColumnIndex == dgvopengrid.Columns[1].Index && e.RowIndex >= 0)
            {
                try
                {
                    ClearData();
                    int a = Convert.ToInt32(dgvopengrid.CurrentRow.Cells["id"].Value);
                    ds = da.dataset_ret("select im.Name as ProductName,s. *,isnull(ledger_master.name,'') as sublocation,miscexp,roff from stockinwardmaster inner join  StockInwardDetail s on s.masterid=stockinwardmaster.id left join Inventory_Master as im on im.ID=s.product left join ledger_master on ledger_master.id=s.sublocationid where s.Masterid=" + a + " ");
                    int count = ds.Tables["tab"].Rows.Count;
                    Entryno = Convert.ToInt32(dgvopengrid.CurrentRow.Cells["entryno"].Value);
                    for (int i = 0; i < count; i++)
                    {

                        dgvChallanDetail.Rows.Add();
                        dgvChallanDetail.Rows[i].Cells[3].Value = i + 1;
                        dgvChallanDetail.Rows[i].Cells[4].Value = ds.Tables["tab"].Rows[i]["ProductName"];
                        dgvChallanDetail.Rows[i].Cells[5].Value = ds.Tables["tab"].Rows[i]["qty"];
                        dgvChallanDetail.Rows[i].Cells[6].Value = ds.Tables["tab"].Rows[i]["Unit"];
                        dgvChallanDetail.Rows[i].Cells[7].Value = ds.Tables["tab"].Rows[i]["Conv"];
                        dgvChallanDetail.Rows[i].Cells[8].Value = ds.Tables["tab"].Rows[i]["Conqty"];
                        dgvChallanDetail.Rows[i].Cells[9].Value = ds.Tables["tab"].Rows[i]["ConUnit"];
                        dgvChallanDetail.Rows[i].Cells[10].Value = ds.Tables["tab"].Rows[i]["Rate"];
                        dgvChallanDetail.Rows[i].Cells[11].Value = ds.Tables["tab"].Rows[i]["bamount"];
                        dgvChallanDetail.Rows[i].Cells[12].Value = ds.Tables["tab"].Rows[i]["disper"];
                        dgvChallanDetail.Rows[i].Cells[13].Value = ds.Tables["tab"].Rows[i]["disamt"];
                        dgvChallanDetail.Rows[i].Cells[14].Value = ds.Tables["tab"].Rows[i]["adisamt"];
                        dgvChallanDetail.Rows[i].Cells[15].Value = ds.Tables["tab"].Rows[i]["gst"];
                        dgvChallanDetail.Rows[i].Cells[16].Value = ds.Tables["tab"].Rows[i]["gstamt"];
                        dgvChallanDetail.Rows[i].Cells[17].Value = ds.Tables["tab"].Rows[i]["Amount"];
                        dgvChallanDetail.Rows[i].Cells[18].Value = ds.Tables["tab"].Rows[i]["product"];
                        dgvChallanDetail.Rows[i].Cells[19].Value = 0;
                        dgvChallanDetail.Rows[i].Cells[20].Value = ds.Tables["tab"].Rows[i]["remark"];
                        dgvChallanDetail.Rows[i].Cells[21].Value = ds.Tables["tab"].Rows[i]["exdate"];
                        dgvChallanDetail.Rows[i].Cells[22].Value = ds.Tables["tab"].Rows[i]["exdate1"];
                        dgvChallanDetail.Rows[i].Cells[23].Value = ds.Tables["tab"].Rows[i]["sublocation"];
                        dgvChallanDetail.Rows[i].Cells[24].Value = ds.Tables["tab"].Rows[i]["sublocationid"];
                        dgvChallanDetail.Rows[i].Cells[25].Value = ds.Tables["tab"].Rows[i]["batchno"];
                        if(ds.Tables["tab"].Rows[i]["exdate"].ToString()!="")
                        {
                            dgvChallanDetail.Rows[i].Cells[4].Value = ds.Tables["tab"].Rows[i]["ProductName"] + " Ex.Date : " + ds.Tables["tab"].Rows[i]["exdate"].ToString();
                        }

                    }
                    rcheck = 1;
                    txtMiscExp.Text = ds.Tables[0].Rows[0]["miscexp"].ToString();
                    txtRoff.Text = ds.Tables[0].Rows[0]["roff"].ToString();
                    txtinvoice.Text = dgvopengrid.CurrentRow.Cells["InvoiceNo"].Value.ToString();
                    string rdt = "";
                    rdt = dgvopengrid.CurrentRow.Cells["Invoicedate1"].Value.ToString();
                   
                    dtinvoice.Text = rdt.Substring(0, 2) + '/' + rdt.Substring(3, 2) + '/' + rdt.Substring(6, 4);
                    //int partyname =Convert.ToInt32(dgvopengrid.CurrentRow.Cells["Party"].Value);
                    txtremark.Text = dgvopengrid.CurrentRow.Cells["Remark"].Value.ToString(); ;
                    //cmbparty.Text = da.value1("select name from ledger_Master where id ="+partyname+"");
                    cmbparty.SelectedValue =Convert.ToInt32( dgvopengrid.CurrentRow.Cells["party"].Value.ToString());
                    cmbCompany.SelectedValue = dgvopengrid.CurrentRow.Cells["companyid"].Value.ToString();
                    txtChallan1.Text = dgvopengrid.CurrentRow.Cells["ID"].Value.ToString();
                    btnSave.Text = "&Update";

                    groupPanel3.Hide();
                    //setgrid();
                    SetTotal();
                    rcheck = 0;
                }
                catch (Exception ex)
                {

                }


            }
            else if (e.ColumnIndex == dgvopengrid.Columns[2].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Are you sure to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {

                    da.insert_update_delete("delete from StockInwardDetail where Masterid=" + dgvopengrid.CurrentRow.Cells["ID"].Value + "");
                    da.insert_update_delete("delete from StockInwardMaster where id=" + dgvopengrid.CurrentRow.Cells["ID"].Value + "");
                    fillgrid();
                    dgvopengrid.Refresh();
                }
                //int row = dgvopengrid.Rows.Count;
                //  for (int i = 0; i < row; i++)
                //  {
                //      if (dgvopengrid.Rows[i].Cells["ID"].Value != "")
                //      {
                //          da.insert_update_delete("delete from StockInwardDetail where Masterid=" + dgvopengrid.Rows[i].Cells["ID"].Value + "");
                //          da.insert_update_delete("delete from StockInwardMaster where id=" + dgvopengrid.Rows[i].Cells["ID"].Value + "");
                //          fillgrid();
                //      }
                //  }

                //  //   MessageBox.Show("Successfully Deleted");
                //  dgvopengrid.Refresh();



            }
            //else if (e.ColumnIndex == dgvopengrid.Columns["Print"].Index && e.RowIndex >= 0)
            //{
            //    DataSet ds = new DataSet();
            //int a =Convert.ToInt32(dgvopengrid.CurrentRow.Cells["id"].Value);

          //ds = da.dataset_ret("select im.code, im.Name as ProductName,s. qty,s.rate from StockInwardDetail s join Inventory_Master as im on im.ID=s.product where s.Masterid=" + a);
            //int loop = 0;
            //int innerLoop=0;
            //for(loop=0;loop<ds.Tables[0].Rows.Count;loop++)
            //{
            //    for (innerLoop = 0; innerLoop <Convert.ToInt32(ds.Tables[0].Rows[loop]["qty"].ToString()); innerLoop++)
            //    {
            //        da.insert_update_delete("insert into barcode_print_table(rproduct,barcode,salerate,companyid) values('" + ds.Tables[0].Rows[loop]["ProductName"].ToString() + "','" + ds.Tables[0].Rows[loop]["code"].ToString() + "'," + Convert.ToDouble(ds.Tables[0].Rows[loop]["rate"].ToString()) + "," + companyid + ")");
            //    }
            //}
            //if(ds.Tables[0].Rows.Count>0)
            //{
            //    frmCrystalReport.ReportName = "Barcode";
            //    frmCrystalReport obj_report = new frmCrystalReport();
            //    obj_report.ShowDialog();

          //}


          //}
            else if (e.ColumnIndex > 2 && e.RowIndex >= 0)
            {
                dgvopengrid.Rows[e.RowIndex].ReadOnly = true;
            }
            else
            {
                dgvopengrid.Rows[e.RowIndex].ReadOnly = false;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmledger fl = new frmledger(this.cmbparty);
            fl.ShowDialog();
            cmbitem.Focus();
        }

        private void NewPurchaseInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (Form1.UserID != 1) { return; }
            if(e.KeyCode==Keys.F7)
            {
                buttonX1_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                buttonX2_Click(sender, e);
            }
        }

        private void dtEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbSubLocation.Focus();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            frminventory fl = new frminventory(this.cmbitem);
            fl.ShowDialog();
        }

        private void cmbCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbitem.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cmbCompany.Text = "";
                cmbCompany.Focus();
            }
        }

        private void cmbCompany_Validating(object sender, CancelEventArgs e)
        {
            if (cmbCompany.Text.Trim() != "")
            {
                if (cmbCompany.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select valid name.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCompany.Focus();
                    e.Cancel = true;
                    return;
                }
            }
            if(Convert.ToInt32(cmbCompany.SelectedValue)!=0)
            {
                da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Shop') and companyid=" + cmbCompany.SelectedValue + " order by  rtag,name", cmbSubLocation, "ID", "Name");
            }
        }

        private void txtQuantity2_TextChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            if (rcheck == 1)
            {
                return;
            }
            try
            {
                double r1 = 0; double r2 = 0;
                if (txtQuantity2.Text != "")
                {
                    r1 = Convert.ToDouble(txtQuantity2.Text);
                }
                if (txtConv.Text != "")
                {
                    r2 = Convert.ToDouble(txtConv.Text);
                }
                rcheck = 1;
                txtQuantity1.Text = Math.Round((r1 * r2), 2).ToString();
                rcheck = 0;
            }
            catch
            {

            }
            SetMargin();
        }

        private void cmbSubLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnadds.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cmbSubLocation.SelectedValue = 0;
                cmbSubLocation.Focus();
            }
        }

        private void cmbitem_SelectedValueChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            if (Convert.ToInt32(cmbitem.SelectedValue) > 0)
            {
                lblStock.Visible = true;
                GETStock(1);
            }
            else
            {
                lblStock.Visible = false;
            }
        }

        private void cmbSubLocation_Validating(object sender, CancelEventArgs e)
        {
            if (cmbSubLocation.Text.Trim() != "")
            {
                if (cmbSubLocation.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select valid name.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSubLocation.Focus();
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void txtMiscExp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '-'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '-' && txtDecimal.Text.Contains("-"))
            {
                e.Handled = true;
            }
            if(e.KeyChar==(Char)13)
            {
                btnSave.Focus();
            }
        }

        private void txtMiscExp_TextChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            SetTotal();

        }

        private void cmbUnit1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbUnit1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            DataSet rstemp = new DataSet();
            //labelX12.Text = "Rate (Bill Qty.)";
            if (Convert.ToInt32(cmbitem.SelectedValue) == 0) { return; }
            if (Convert.ToInt32(cmbUnit1.SelectedValue) > 0)
            {
                rstemp = da.dataset_ret("select aa.* from (select conv1 as r1 from inventory_master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + " and lot1id=" + Convert.ToInt32(cmbUnit1.SelectedValue) + " union all select conv2 as r1 from inventory_master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + " and  lot2id=" + Convert.ToInt32(cmbUnit1.SelectedValue) + " union all select conv3 as r1 from inventory_master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + " and  lot3id=" + Convert.ToInt32(cmbUnit1.SelectedValue) + ") as aa");
                if (rstemp.Tables[0].Rows.Count > 0)
                {
                    rcheck = 1;
                    string[] rvar = cmbUnit1.Text.Split('_');
                  //  txtConv.Text = rstemp.Tables[0].Rows[0]["r1"].ToString();
                   

                    //labelX12.Text = "Rate ("+rvar[0]+")";
                    if(rvar.Length>1)
                    {
                        txtConv.Text = rvar[1];
                    }
                     
                    try
                    {
                        double r1 = 0; double r2 = 0;
                        if (txtQuantity2.Text != "")
                        {
                            r1 = Convert.ToDouble(txtQuantity2.Text);
                        }
                        if (txtConv.Text != "")
                        {
                            r2 = Convert.ToDouble(txtConv.Text);
                        }

                        txtQuantity1.Text = Math.Round((r1 * r2), 2).ToString();
                        rcheck = 0;
                    }
                    catch
                    {
                        rcheck = 0;
                    }
                    SetMargin();
                    rcheck = 0;
                }
                else
                {
                    rcheck = 1;
                    txtConv.Text = "1";
                    try
                    {
                        double r1 = 0; double r2 = 0;
                        if (txtQuantity2.Text != "")
                        {
                            r1 = Convert.ToDouble(txtQuantity2.Text);
                        }
                        if (txtConv.Text != "")
                        {
                            r2 = Convert.ToDouble(txtConv.Text);
                        }

                        txtQuantity1.Text = Math.Round((r1 * r2), 2).ToString();
                        rcheck = 0;
                    }
                    catch
                    {
                        rcheck = 0;
                    }
                    SetMargin();
                    rcheck = 0;
                    //labelX12.Text = "Rate (" + cmbUnit1.Text + ")";
                }
            }
        }

        private void cmbparty_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void cmbparty_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ComboBox cb = (ComboBox)sender;
                cb.DroppedDown = false;
                cb.SelectionStart = cb.Text.Length;
                cb.SelectionLength = 0;
            }
        }

       

       
      

    

      
    }
}