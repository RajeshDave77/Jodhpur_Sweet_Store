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
    public partial class PurchaseInvoice1 : Form
    {
        private MainIndex mainForm = null;
        public PurchaseInvoice1(Form callingForm)
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
                double netqty = 0;
                decimal netamtf = 0;

                int rowcount = dgvChallanDetail.Rows.Count;
                for (int i = 0; i < rowcount; i++)
                {

                    dgvChallanDetail.Rows[i].Cells[3].Value = Convert.ToString(i + 1);

                    //dgvChallanDetail.Rows[i].Cells[7].Value = Convert.ToString(Math.Round(Convert.ToDecimal(Convert.ToDecimal(dgvChallanDetail.Rows[i].Cells[5].Value) * (Convert.ToDecimal(dgvChallanDetail.Rows[i].Cells[6].Value))), 2));
                    double plo = Convert.ToDouble(dgvChallanDetail.Rows[i].Cells[6].Value.ToString());
                    dgvChallanDetail.Rows[i].Cells[6].Value = Convert.ToString(plo);
                    double klm = ((netqty + plo));
                    netqty = klm;
                    netamtf = netamtf + Convert.ToDecimal(dgvChallanDetail.Rows[i].Cells[8].Value);
                  //  dgvChallanDetail.Rows[i].Cells[8].Value = Convert.ToString(Convert.ToDecimal(dgvChallanDetail.Rows[i].Cells[8].Value));
                    dgvChallanDetail.Rows[i].Cells[8].Value = Convert.ToString(Convert.ToDecimal(dgvChallanDetail.Rows[i].Cells[8].Value));
                    DataGridViewRow row = dgvChallanDetail.Rows[i];
                    //row.Height = 50;
                }
                if (dgvChallanDetail.Rows.Count > 0)
                {
                    dgvChallanDetail.FirstDisplayedScrollingRowIndex = dgvChallanDetail.Rows.Count - 1;
                }

                txttotalqty.Text = Convert.ToString(netqty);
                txttotalamt.Text = Convert.ToString(netamtf);

            }
            catch { }
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbSubLocation.SelectedValue) == 0)
            {
                MessageBox.Show("Please Select Location. ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSubLocation.Focus();
                return;
            }
            if (Convert.ToInt32(cmbSubLocation2.SelectedValue) == 0)
            {
                MessageBox.Show("Please Select Location. ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSubLocation2.Focus();
                return;
            }
            try
            {
                if(Convert.ToInt32(cmbSubLocation.SelectedValue)!=0 && Convert.ToInt32(cmbSubLocation2.SelectedValue)!=0)
                {
                    if (Convert.ToInt32(cmbSubLocation.SelectedValue) == Convert.ToInt32(cmbSubLocation2.SelectedValue))
                    {
                        MessageBox.Show("Please select different second storage locations.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbSubLocation2.Focus();
                        return;
                    }
                }
                if (btnadds.Text == "Update")
                {
                    //dgvChallanDetail.Rows.Add();

                    dgvChallanDetail.Rows[rowedit].Cells[4].Value = cmbitem.Text;
                    dgvChallanDetail.Rows[rowedit].Cells[5].Value = cmbDate.Text;
                    //     dgvChallanDetail.Rows[rowedit].Cells[4].Value = cmbunit.Text.ToString();
                    dgvChallanDetail.Rows[rowedit].Cells[6].Value = txtQuantity1.Text.ToString();
                    dgvChallanDetail.Rows[rowedit].Cells[7].Value = txtrate.Text.ToString();
                    dgvChallanDetail.Rows[rowedit].Cells[8].Value = txtamount.Text.ToString();
                    dgvChallanDetail.Rows[rowedit].Cells[9].Value = cmbitem.SelectedValue;
                    dgvChallanDetail.Rows[rowedit].Cells[10].Value = cmbUnit.Text.ToString();
                    dgvChallanDetail.Rows[rowedit].Cells[11].Value = txtRemark1.Text.ToString();
                    if (Convert.ToInt32(cmbSubLocation.SelectedValue) != 0)
                    {
                        dgvChallanDetail.Rows[rowedit].Cells[12].Value = cmbSubLocation.Text;
                        dgvChallanDetail.Rows[rowedit].Cells[13].Value = cmbSubLocation.SelectedValue;
                    }
                    else
                    {
                        dgvChallanDetail.Rows[rowedit].Cells[12].Value = "";
                        dgvChallanDetail.Rows[rowedit].Cells[13].Value = 0;
                    }
                    if (Convert.ToInt32(cmbSubLocation2.SelectedValue) != 0)
                    {
                        dgvChallanDetail.Rows[rowedit].Cells[14].Value = cmbSubLocation2.Text;
                        dgvChallanDetail.Rows[rowedit].Cells[15].Value = cmbSubLocation2.SelectedValue;
                    }
                    else
                    {
                        dgvChallanDetail.Rows[rowedit].Cells[14].Value = "";
                        dgvChallanDetail.Rows[rowedit].Cells[15].Value = 0;
                    }
                    dgvChallanDetail.Rows[rowedit].Cells[16].Value = txtBatch.Text;
                    dgvChallanDetail.Rows[rowedit].Cells[17].Value = txtBatch.Tag;
                    dgvChallanDetail.Rows[rowedit].Cells[18].Value = orgRate;
                    ClearData();
                    setgrid();
                    btnadds.Text = "Add";
                    btnSave.Focus();
                  //  ClearData();
                }
                else
                {
                    if (cmbitem.Text == "")
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
                    if (txtBatch.Text == "")
                    {
                        MessageBox.Show("Please specify batch no.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cmbitem.Focus();
                        return;
                    }
                      if (btnadds.Text != "Update")
                      {
                          string[] rstr;
                          rstr = lblStock.Text.Split(':');

                          if (Convert.ToDouble(txtQuantity1.Text) > Convert.ToDouble(rstr[1].Trim()))
                          {
                              MessageBox.Show("Quantity is not greater than to available stock.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                              txtQuantity1.Focus();
                              return;
                          }
                      }
                    
                   
                    //if (cmbDate.Text == "")
                    //{
                    //    MessageBox.Show("Please specify product expiry date.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    cmbDate.Focus();
                    //    return;
                    //}
                    //if (txtrate.Text == "")
                    //{
                    //    MessageBox.Show("Please specify product rate.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    txtrate.Focus();
                    //    return;
                    //}
                   if(Convert.ToInt32(cmbUnit.SelectedValue)==0)
                   {
                       MessageBox.Show("Please select unit.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       cmbUnit.Focus();
                       return;
                   }


                        int rowcount = dgvChallanDetail.Rows.Count;
                        dgvChallanDetail.Rows.Add();
                        dgvChallanDetail.Rows[rowcount].Cells[4].Value = cmbitem.Text;
                        dgvChallanDetail.Rows[rowcount].Cells[5].Value = cmbDate.Text;
                        //         dgvChallanDetail.Rows[rowcount].Cells[5].Value = cmbunit.Text.ToString();
                        dgvChallanDetail.Rows[rowcount].Cells[6].Value = txtQuantity1.Text.ToString();
                        dgvChallanDetail.Rows[rowcount].Cells[7].Value = txtrate.Text.ToString();
                        dgvChallanDetail.Rows[rowcount].Cells[8].Value = txtamount.Text.ToString();
                        dgvChallanDetail.Rows[rowcount].Cells[9].Value = cmbitem.SelectedValue;
                        dgvChallanDetail.Rows[rowcount].Cells[10].Value = cmbUnit.Text;
                        dgvChallanDetail.Rows[rowcount].Cells[11].Value = txtRemark1.Text;
                         if(Convert.ToInt32(cmbSubLocation.SelectedValue)!=0)
                        {
                            dgvChallanDetail.Rows[rowcount].Cells[12].Value = cmbSubLocation.Text;
                            dgvChallanDetail.Rows[rowcount].Cells[13].Value = cmbSubLocation.SelectedValue;
                        }
                         else
                         {
                             dgvChallanDetail.Rows[rowcount].Cells[12].Value = "";
                             dgvChallanDetail.Rows[rowcount].Cells[13].Value = 0;
                         }
                         if (Convert.ToInt32(cmbSubLocation2.SelectedValue) != 0)
                         {
                             dgvChallanDetail.Rows[rowcount].Cells[14].Value = cmbSubLocation2.Text;
                             dgvChallanDetail.Rows[rowcount].Cells[15].Value = cmbSubLocation2.SelectedValue;
                         }
                         else
                         {
                             dgvChallanDetail.Rows[rowcount].Cells[14].Value = "";
                             dgvChallanDetail.Rows[rowcount].Cells[15].Value = 0;
                         }
                         dgvChallanDetail.Rows[rowcount].Cells[16].Value = txtBatch.Text;
                         dgvChallanDetail.Rows[rowcount].Cells[17].Value = txtBatch.Tag;
                         dgvChallanDetail.Rows[rowcount].Cells[18].Value = orgRate;
                        cmbitem.Focus();
                        ClearData();
                        setgrid();

                

                }
                orgRate = 0;
            }
            catch { }
            
        }
        public void ClearData()
        {
            rcheck = 1;
            panel1.Visible = false;
            txtBatch.Text = "";
            txtBatch.Tag = 0;
            //   txtinvoice.Clear();
            txtQuantity1.Clear();
            rValue = 0;
            dsNew.Dispose();
            dsNew.Clear();
            da.fill_comboNew("select 0 as id,'' as name union all select ID,Name from Inventory_Master where status=1 order by name", cmbitem, "ID", "Name", dsNew);
            da.fill_combo(" select 0 as ID, '--Select--' as Name,1 as rtag union all select distinct ID, Name,2 as rtag from tblunit order by rtag,Name", cmbUnit, "ID", "Name");
            lblStock.Text = "";
            //cmbitem.Text = "";
            cmbDate.Items.Clear();
          
            //cmbitem.SelectedValue = 0;
   //   txtinvoice.Clear();
          //  txtremark.Clear();
            txtrate.Clear();
            txtamount.Clear();
            txttotalamt.Clear();
            txttotalqty.Clear();
            txtRemark1.Text = "";
    //        cmbparty.Text = "";
          //  btnSave.Text = "&Save";

            //    textBox5.Clear();
            rcheck = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnReset_Click(sender, e);
            dgvChallanDetail.Rows.Clear();
            checkBox1.Checked = false;
            groupPanel3.Location = new Point(6, 0);
            groupPanel3.Show();
            //dtfromdate.Enabled = false;
            //dttodate.Enabled = false;
            chkdate.Checked = true;
            if (MainIndex.formname == "Purchase")
            {
                dgvopengrid.Columns[4].Visible = false;
            }
            dtfromdate.Focus();
            fillgrid();
          
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Mainid = 0;
            ClearData();
            cmbSubLocation.SelectedValue = 0;
            cmbSubLocation2.SelectedValue = 0;
            dgvChallanDetail.Rows.Clear();
            btnSave.Text = "&Save";
            btnadds.Text = "Add";
            txtinvoice.Clear();
            dtinvoice.Text = DateTime.Now.ToString("yyyy-MM-dd").ToString();
            cmbparty.SelectedValue = 0;
            txttotalamt.Clear();
            txttotalqty.Clear();
            txtremark.Text = "";
            orgRate = 0;
            SetEntryNo();
        }
        int rowedit = 0;
        private void dgvChallanDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dgvChallanDetail.Rows[e.RowIndex].ReadOnly = true;
            rowedit = 0;
            if (e.ColumnIndex == dgvChallanDetail.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                try
                {
                    rcheck = 1;
                    rowedit = e.RowIndex;
                    btnadds.Text = "Update";
                    rValue = Convert.ToInt32(dgvChallanDetail.CurrentRow.Cells[9].Value.ToString());
                   //cmbitem.Text = dgvChallanDetail.CurrentRow.Cells[4].Value.ToString();
                    //dsNew.Dispose();
                    //dsNew.Clear();
                    ////cmbitem.Text = "";

                    //da.fill_comboNew("select 0 as id,'' as name union all select ID,Name from Inventory_Master where id=" + rValue + " order by name", cmbitem, "ID", "Name", dsNew);

                    cmbitem.SelectedValue = rValue;
                    ShowUnit();
                    DataSet rstemp1 = new DataSet();
                    rstemp1 = da.dataset_ret("select a.* from (select distinct exdate from stockinwarddetail inner join stockinwardmaster on stockinwardmaster.id=masterid where exdate<>'' and stocktype='Purchase' and product=" + Convert.ToInt32(cmbitem.SelectedValue) + " ) as a ORDER BY CONVERT(DATETIME, a.exdate, 105)");
                    cmbDate.Items.Clear();
                    rcheck = 1;
                    cmbDate.Items.Add("");


                    int intloop = 0;
                    for (intloop = 0; intloop < rstemp1.Tables[0].Rows.Count; intloop++)
                    {
                        cmbDate.Items.Add(rstemp1.Tables[0].Rows[intloop]["exdate"].ToString());
                    }
                    cmbDate.Text = dgvChallanDetail.CurrentRow.Cells[5].Value.ToString(); 
                    txtQuantity1.Text = dgvChallanDetail.CurrentRow.Cells[6].Value.ToString();
                    txtrate.Text = dgvChallanDetail.CurrentRow.Cells[7].Value.ToString();
                    txtamount.Text = dgvChallanDetail.CurrentRow.Cells[8].Value.ToString();
                    cmbUnit.Text = dgvChallanDetail.CurrentRow.Cells[10].Value.ToString();
                    txtRemark1.Text = dgvChallanDetail.CurrentRow.Cells[11].Value.ToString();
                    cmbSubLocation.SelectedValue = dgvChallanDetail.CurrentRow.Cells[13].Value.ToString();
                    cmbSubLocation2.SelectedValue = dgvChallanDetail.CurrentRow.Cells[15].Value.ToString();
                    txtBatch.Text = dgvChallanDetail.CurrentRow.Cells[16].Value.ToString();
                    txtBatch.Tag = dgvChallanDetail.CurrentRow.Cells[17].Value.ToString();
                   orgRate =Convert.ToDouble( dgvChallanDetail.CurrentRow.Cells[18].Value.ToString());

                    if (Convert.ToInt32(cmbSubLocation.SelectedValue) == 0)
                    {
                        GETStock(1);
                    }
                    else
                    {
                        GETStock(3);
                    }
                   
                    rcheck = 0;

                }
                catch (Exception ex)
                {

                }

            }
            else if (e.ColumnIndex == dgvChallanDetail.Columns["Delete"].Index && e.RowIndex >= 0)
            {

                try
                {
                    if (e.ColumnIndex == dgvChallanDetail.Columns["Delete"].Index && e.RowIndex >= 0)
                    {
                        //int row = dgvChallanDetail.Rows.Count;
                        //for (int i = 0; i < row; i++)
                        //{
                        //    if (dgvChallanDetail.Rows[i].Cells[8].Value != "" || dgvChallanDetail.Rows[i].Cells[8].Value == null)
                        //    {
                        //        da.insert_update_delete("delete from StockInwardDetail where id=" + dgvChallanDetail.Rows[i].Cells[8].Value + "");
                        //        dgvChallanDetail.Refresh();
                        //        if(dgvChallanDetail.Rows.Count==0)
                        //        {
                        //            da.insert_update_delete("delete from StockInwardMaster where id=" + txtChallan1.Text + "");
                        //        }
                        //        fillgrid();
                               
                        //    }
                        //}

                        dgvChallanDetail.Rows.RemoveAt(e.RowIndex);
                        //   MessageBox.Show("Successfully Deleted");
                        ClearData();
                        btnadds.Text = "Add";
                        dgvChallanDetail.Refresh();
                        setgrid();
                    }

                }



                catch (Exception ex)
                {
                    
                }
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

        int Mainid = 0;
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = false;

            try
            {
                string partyname = "";
                if(cmbparty.Visible==true)
                {
                    if (Convert.ToInt32(cmbparty.SelectedValue) == 0)
                    {
                        MessageBox.Show("Please Select Location. ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbparty.Focus();
                        return;
                    }
                    partyname = cmbparty.Text;
                }
                else
                {
                    partyname = cmbSubLocation2.Text;
                }
                //int sublocationid = 0;
                //if( Convert.ToInt32( cmbSubLocation.SelectedValue)!=0)
                //{
                //    sublocationid = Convert.ToInt32(cmbSubLocation.SelectedValue);
                //}
               

             
                if (dgvChallanDetail.Rows.Count == 0)
                {
                    MessageBox.Show("Please specify product detail. ", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbitem.Focus();
                    return;
                }
                  if (btnSave.Text == "&Save")
                    {
                       int a =0;// pic.Check_Duplicacys("Stock", txtinvoice.Text);
           //             if (a > 0)
               //         {
            //                MessageBox.Show("Cannot Insert Duplicate Invoice Number", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           //                 txtinvoice.Focus();
          //                  return;
          //              }
                ////        else
                //        {


                       int mastid = pic.Stock_InwardMaster(id, partyname, Convert.ToInt32(cmbSubLocation2.SelectedValue), cmbStockType.Text, txtinvoice.Text, dtinvoice.Text, txtremark.Text, Convert.ToInt32(cmbCompany.SelectedValue), Convert.ToInt32(Form1.UserID), Convert.ToInt32(txtEntry.Text), Form1.CurrFinYear, 0);
                int count = dgvChallanDetail.Rows.Count;
                Mainid = mastid;
                for (int i = 0; i < count; i++)
                {

                    double qty = Convert.ToDouble(dgvChallanDetail.Rows[i].Cells[6].Value);
                    decimal rate = Convert.ToDecimal(dgvChallanDetail.Rows[i].Cells[7].Value);
                    decimal amt = Convert.ToDecimal(dgvChallanDetail.Rows[i].Cells[8].Value);
                    string rdate = "";

                    rdate = dgvChallanDetail.Rows[i].Cells[5].Value.ToString();
                    if(rdate!="")
                    {
                        rdate = rdate.Substring(6, 4) + "-" + rdate.Substring(3, 2) + "-" + rdate.Substring(0, 2);
                    }
                    int sid = 0;
                    if (dgvChallanDetail.Rows[i].Cells[12].Value!=null)
                    {
                        if (dgvChallanDetail.Rows[i].Cells[12].Value.ToString() != "")
                        {
                            sid = Convert.ToInt32(dgvChallanDetail.Rows[i].Cells[13].Value.ToString());
                        }
                    }
                    int sid1 = 0;
                    if (dgvChallanDetail.Rows[i].Cells[14].Value != null)
                    {
                        if (dgvChallanDetail.Rows[i].Cells[14].Value.ToString() != "")
                        {
                            sid1 = Convert.ToInt32(dgvChallanDetail.Rows[i].Cells[15].Value.ToString());
                        }
                    }
                    string batchno = "";
                    int batchnoid = 0;
                    if (dgvChallanDetail.Rows[i].Cells[16].Value != null)
                    {
                        batchno = dgvChallanDetail.Rows[i].Cells[16].Value.ToString();
                    }
                    if (dgvChallanDetail.Rows[i].Cells[17].Value != null)
                    {
                        batchnoid =Convert.ToInt32( dgvChallanDetail.Rows[i].Cells[17].Value.ToString());
                    }
                    flag = pic.Stock_InwardDetail(id, Convert.ToInt32(dgvChallanDetail.Rows[i].Cells[9].Value), qty, rate, amt, mastid, Form1.SingleCode(dgvChallanDetail.Rows[i].Cells[11].Value.ToString()), Convert.ToInt32(Form1.CompanyID), Form1.SingleCode(dgvChallanDetail.Rows[i].Cells[10].Value.ToString()), dgvChallanDetail.Rows[i].Cells[5].Value.ToString(), rdate, sid, sid1, batchno, batchnoid, Convert.ToDouble( dgvChallanDetail.Rows[i].Cells[18].Value.ToString()));
                          //  MessageBox.Show("Data SuccessFully Added", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                   }
                      //  MessageBox.Show("Data SuccessFully Added", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
            //        }
                  }
                  else if (btnSave.Text == "&Update")
                  {
                      int upid =Convert.ToInt32(txtChallan1.Text);
                      int mastid = pic.Stock_InwardMaster(upid, partyname, Convert.ToInt32(cmbSubLocation2.SelectedValue), cmbStockType.Text, txtinvoice.Text, dtinvoice.Text, txtremark.Text, Convert.ToInt32(cmbCompany.SelectedValue), Convert.ToInt32(Form1.UserID), Convert.ToInt32(txtEntry.Text), Form1.CurrFinYear,0);

                      Mainid = mastid;
                      int count = dgvChallanDetail.Rows.Count;

                      da.insert_update_delete("delete from StockInwardDetail where masterid=" + upid + " ");
                   
                      for (int i = 0; i < count; i++)
                      {
                          int mastid1 = Convert.ToInt32(txtChallan1.Text);

                          double qty = Convert.ToDouble(dgvChallanDetail.Rows[i].Cells[6].Value);
                          decimal rate = Convert.ToDecimal(dgvChallanDetail.Rows[i].Cells[7].Value);
                          decimal amt = Convert.ToDecimal(dgvChallanDetail.Rows[i].Cells[8].Value);
                          int id1 =0;// Convert.ToInt32(dgvChallanDetail.Rows[i].Cells[7].Value);
                          string rdate = dgvChallanDetail.Rows[i].Cells[5].Value.ToString();
                          if (rdate != "")
                          {
                              rdate = rdate.Substring(6, 4) + "-" + rdate.Substring(3, 2) + "-" + rdate.Substring(0, 2);
                          }
                          int sid = 0;
                          if (dgvChallanDetail.Rows[i].Cells[12].Value != null)
                          {
                              if (dgvChallanDetail.Rows[i].Cells[12].Value.ToString() != "")
                              {
                                  sid = Convert.ToInt32(dgvChallanDetail.Rows[i].Cells[13].Value.ToString());
                              }
                          }
                          int sid1 = 0;
                          if (dgvChallanDetail.Rows[i].Cells[14].Value != null)
                          {
                              if (dgvChallanDetail.Rows[i].Cells[14].Value.ToString() != "")
                              {
                                  sid1 = Convert.ToInt32(dgvChallanDetail.Rows[i].Cells[15].Value.ToString());
                              }
                          }
                          string batchno = "";
                          int batchnoid = 0;
                          if (dgvChallanDetail.Rows[i].Cells[16].Value != null)
                          {
                              batchno = dgvChallanDetail.Rows[i].Cells[16].Value.ToString();
                          }
                          if (dgvChallanDetail.Rows[i].Cells[17].Value != null)
                          {
                              batchnoid = Convert.ToInt32(dgvChallanDetail.Rows[i].Cells[17].Value.ToString());
                          }
                          flag = pic.Stock_InwardDetail(id1, Convert.ToInt32(dgvChallanDetail.Rows[i].Cells[9].Value), qty, rate, amt, mastid, Form1.SingleCode(dgvChallanDetail.Rows[i].Cells[11].Value.ToString()), Convert.ToInt32(Form1.CompanyID), Form1.SingleCode(dgvChallanDetail.Rows[i].Cells[10].Value.ToString()), dgvChallanDetail.Rows[i].Cells[5].Value.ToString(), rdate, sid, sid1, batchno, batchnoid, Convert.ToDouble(dgvChallanDetail.Rows[i].Cells[18].Value.ToString()));


                      }
                     // MessageBox.Show("Data SuccessFully Updated", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.None);
                  }
                  
                
                if (flag)
                {
           
                    dgvChallanDetail.Rows.Clear();
                    ClearData();
               
                  
                    btnSave.Text = "&Save";
                    cmbparty.SelectedValue = 0;
                    txtinvoice.Clear();
                    SetEntryNo();
                    txtinvoice.Focus();
                }

            } 
            catch { }

        }

        private void PurchaseInvoice1_Load(object sender, EventArgs e)
        {
            rcheck = 1;
            if(Form1.UserID==1)
            {
                cmbCompany.Enabled = true;
            }
            dsNew.Dispose();
            dsNew.Clear();
            this.Cursor = Cursors.WaitCursor;
            if (MainIndex.formname == "Purchase")
            {
                cmbStockType.Text = "Purchase";
                this.Text = "Purchase";
                label8.Text = "Purchase";
                groupPanel3.Text = "Purchase Detail";
                btnPrint.Enabled = false;
            }
            else if (MainIndex.formname == "Consumed")
            {
                cmbStockType.Text = "Consumed";
                this.Text = "Consumed";
                label8.Text = "Consumed";
                groupPanel3.Text = "Consumed Detail";
                lblParty.Visible = false;
                cmbparty.Visible = false;
                if(Form1.utype==2)
                {
                    cmbDate.Enabled = false;
                    btnStock.Visible = true;
                }
                
            }
            else  if (MainIndex.formname == "Stock Inward")
            {
                cmbStockType.Text = "Stock Inward";
                this.Text = "Stock Inward";
                label8.Text = "Stock Inward";
                groupPanel3.Text = "Stock Inward Detail";
                btnSave.Enabled = false;
                btnPrint.Enabled = false;
            }
            else  if (MainIndex.formname == "Damages")
            {
                cmbStockType.Text = "Damages";
                this.Text = "Damages";
                label8.Text = "Damages";
                groupPanel3.Text = "Damages Detail";
                lblParty.Visible = false;
                cmbparty.Visible = false;
                labelX20.Visible = false;
                dgvChallanDetail.Columns[14].Visible = false;
                cmbSubLocation2.Visible = false;
                if (Form1.utype == 2)
                {
                    cmbDate.Enabled = false;
                }
            }
            else if (MainIndex.formname == "Production")
            {
                cmbStockType.Text = "Production";
                this.Text = "Production";
                label8.Text = "Production";
                groupPanel3.Text = "Production Detail";
            }
            else if (MainIndex.formname == "Dispatch Challan")
            {
                cmbStockType.Text = "Dispatch Challan";
                this.Text = "Dispatch Challan";
                label8.Text = "Dispatch Challan";
                groupPanel3.Text = "Dispatch Challan Detail";
                btnExport.Visible = true;
            }
            else if (MainIndex.formname == "Issue")
            {
                cmbStockType.Text = "Issue";
                this.Text = "Internal Inventory Transfer Detail";
                label8.Text = "Internal Inventory Transfer Detail";
                groupPanel3.Text = "Internal Inventory Transfer Detail";
                btnExport.Visible = true;
            }
            else if (MainIndex.formname == "Department")
            {
                cmbStockType.Text = "Department";
                this.Text = "Issue Detail";
                label8.Text = "Issue Detail";
                groupPanel3.Text = "Issue Detail";
                btnExport.Visible = true;
               // labelX20.Text = "Department";
            }
            else if (MainIndex.formname == "Issue Return")
            {
                cmbStockType.Text = "Issue Return";
                this.Text = "Issue Return Detail";
                label8.Text = "Issue Return Detail";
                groupPanel3.Text = "Issue Return Detail";
                btnExport.Visible = true;
            }
            else if (MainIndex.formname == "Wastage")
            {
                cmbStockType.Text = "Wastage";
                this.Text = "Wastage";
                label8.Text = "Wastage";
                groupPanel3.Text = "Wastage Detail";
                lblParty.Visible = false;
                cmbparty.Visible = false;
                if (Form1.utype == 2)
                {
                    cmbDate.Enabled = false;
                }
            }
         //   da.fill_combo("select id,(name) as name from ledger_Master", cmbCompany, "ID", "Name");
          //  cmbparty.SelectedValue = Form1.CompanyID;
            if (MainIndex.formname == "Purchase")
            {
                da.fill_combo("select 0 as id,'--Select Party--' as name,1 as rtag union all select ID,Name,2 as rtag from Ledger_Master where companyid=" + Form1.Godownid +" and type in ('Supplier','Godown','Shop') and id<>"+ Form1.CompanyID +" order by rtag,name", cmbparty, "ID", "Name");
                cmbparty.SelectedValue = 0;

                da.fill_combo(" select ID,Name,2 as rtag from Ledger_Master where  type in ('Supplier','Godown','Shop')  order by rtag,name", cmbCompany, "ID", "Name");
                cmbCompany.SelectedValue = Form1.CompanyID;
            }
            else if (MainIndex.formname == "Stock Transfer")
            {
                da.fill_combo("select 0 as id,'--Select--' as name,1 as rtag union all select ID,Name,2 as rtag from Ledger_Master where companyid=" + Form1.Godownid + " and type in ('Department','Godown','Shop') and id<>" + Form1.CompanyID + " order by rtag,name", cmbparty, "ID", "Name");
                cmbparty.SelectedValue = 0;

                da.fill_combo(" select ID,Name,2 as rtag from Ledger_Master where type in ('Department','Godown','Shop')  order by rtag,name", cmbCompany, "ID", "Name");
                cmbCompany.SelectedValue = Form1.CompanyID; ;
            }
            else
            {
                //da.fill_combo("select 0 as id,'--Select--' as name,1 as rtag union all select ID,Name,2 as rtag from Ledger_Master where companyid=" + Form1.Godownid + " and type in ('Godown') and id<>" + Form1.CompanyID + " order by  rtag,name", cmbparty, "ID", "Name");
                da.fill_combo("select 0 as id,'--Select--' as name,1 as rtag union all select ID,Name,2 as rtag from Ledger_Master where companyid=" + Form1.Godownid + " and type in ('Godown')  order by  rtag,name", cmbparty, "ID", "Name");
                da.fill_combo("select ID,Name,2 as rtag from Ledger_Master where  type in ('Godown')  order by  rtag,name", cmbCompany, "ID", "Name");

                cmbCompany.SelectedValue = Form1.CompanyID;
                cmbparty.SelectedValue = Form1.CompanyID;
            }
            da.fill_comboNew("select 0 as id,'' as name union all select ID,Name from Inventory_Master where status=1 order by name", cmbitem, "ID", "Name", dsNew);
            da.fill_combo(" select 0 as ID, '--Select--' as Name,1 as rtag union all select distinct ID, Name,2 as rtag from tblunit order by rtag,Name", cmbUnit, "ID", "Name");
           
                da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag ", cmbSubLocation2, "ID", "Name");
                if (MainIndex.formname == "Department")
                {
                    da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Shop') and companyid=" + cmbCompany.SelectedValue + " order by  rtag,name", cmbSubLocation, "ID", "Name");
                    da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Department') and companyid=" + cmbCompany.SelectedValue + " order by  rtag,name", cmbSubLocation2, "ID", "Name");
                }
                else
                {
                    da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Shop') and companyid=" + cmbCompany.SelectedValue + " order by  rtag,name", cmbSubLocation, "ID", "Name");

                }

         
            //cmbitem.Text = "";
           
            SetEntryNo();
            if(Form1.utype!=0)
            {
                dgvopengrid.Columns[1].Visible = false;
               // dgvopengrid.Columns[2].Visible = false;
            }
            this.Cursor = Cursors.Default;
            txtinvoice.Focus();
            rcheck = 0;
        }
        private void SetEntryNo() 
        {
            int billno = 0;

            try
            {
                billno = Convert.ToInt32(da.value1("select max(entryno)as billno from stockinwardmaster where stocktype='" + cmbStockType.Text +"' and finyear='" + Form1.CurrFinYear +"'  "));
            }
            catch
            {
                billno = 0;
            }
            txtEntry.Text = Convert.ToString(billno + 1);
            txtinvoice.Text = Convert.ToString(billno + 1);
        }
        private void cmbparty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbSubLocation2.Focus();
            }
            else if(e.KeyCode==Keys.Escape)
            {
                cmbparty.SelectedValue = 0;
                cmbparty.Focus();
            }
        }

        public void fillgrid()
        {
           
           
            try
            {
                  string invdt = "";
                    string invtdt ="";
              
                

              //  dgvopengrid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12.00F, FontStyle.Regular);
              //  DataGridViewColumn col1 = new DataGridViewImageButtonDeleteColumn();
              //  col1.HeaderText = "";
              //  col1.Name = "Delete";
              //  col1.Width = 35;
              //  DataGridViewColumn edit = new DataGridViewImageButtonEditColumn();
              //  edit.HeaderText = "";
              //  edit.Name = "Edit";
              //  edit.Width = 35;
              //  DataGridViewColumn select = new DataGridViewCheckBoxColumn();
              //  select.HeaderText = "";
              //  select.Name = "sel_rec";
              //  select.Width = 40;
              //  DataGridViewColumn print = new DataGridViewImageButtonPrintColumn();
              //  print.HeaderText = "";
              //  print.Name = "Print";
              //  print.Width = 40;
              ////  dgvopengrid.Columns.Add(select);
              //  dgvopengrid.Columns.Add(col1);
              //  dgvopengrid.Columns.Add(edit);
              //  dgvopengrid.Columns.Add(print);
              //  DataSet ds = new DataSet();
              
              //  if(chkdate.Checked==true)
              //  {
              //       invdt = dtfromdate.Value.Date.ToString("yyyy-MM-dd");
              //       invtdt = dttodate.Value.Date.ToString("yyyy-MM-dd");
              //  }
              //  else
              //  {
              //       invdt = "";
              //       invtdt = "";
              //  }
                invdt = dtfromdate.Value.Date.ToString("yyyy-MM-dd");
                invtdt = dttodate.Value.Date.ToString("yyyy-MM-dd");
                if (Form1.UserID==1)
                {
                    if (txtinvsearch.Text != "")
                    {
                        ds = pic.Inward_GetData(txtpartysearch.Text, MainIndex.formname, invdt, invtdt, txtinvsearch.Text, 1);
                    }
                    else
                    {
                        ds = pic.Inward_GetData(txtpartysearch.Text, MainIndex.formname, invdt, invtdt, "", 1);
                    }
                }
                else
                {
                    if (txtinvsearch.Text != "")
                    {
                        ds = pic.Inward_GetData(txtpartysearch.Text, MainIndex.formname, invdt, invtdt, txtinvsearch.Text, companyid);
                    }
                    else
                    {
                        ds = pic.Inward_GetData(txtpartysearch.Text, MainIndex.formname, invdt, invtdt, "", companyid);
                    }
                }
                dgvopengrid.DataSource = ds.Tables[0];
                //if (MainIndex.formname == "Dispatch Challan")
                //{
                //    dgvopengrid.Columns[0].Visible = true;
                //}
                //else if (MainIndex.formname == "Shop Transfer")
                //{
                //    dgvopengrid.Columns[0].Visible = true;
                //}
                //else if (MainIndex.formname == "Stock Transfer")
                //{
                //    dgvopengrid.Columns[1].Visible = false;
                   
                //}
                dgvopengrid.Columns["ID"].Visible = false;
                dgvopengrid.Columns["invoiceno"].Visible = false;
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
           
              //  dgvopengrid.Columns["ProductID"].Visible = false;



                //foreach (DataGridViewRow row in dgvopengrid.Rows)
                //{

                //    row.Height = 42;

                //}
                //foreach (DataGridViewColumn c in dgvopengrid.Columns)
                //{
                //    c.DefaultCellStyle.Font = new Font("Arial", 12.00F, FontStyle.Regular);
                //}
                int i = 0;
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

                    rTotal = rTotal + Convert.ToDouble(dgvopengrid.Rows[intl].Cells[17].Value);
                    rTotal1 = rTotal1 + Convert.ToDouble(dgvopengrid.Rows[intl].Cells[18].Value);

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
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                buttonX1_Click(sender, e);
              //txtrate.Focus();
                //buttonX1_Click(sender, e);
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
                buttonX1_Click(sender, e);
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
            try
            {
                if (txtrate.Text == "")
                {
                    txtamount.Text = Convert.ToString(0);
                }
                if (txtQuantity1.Text == "") { return; }
                qty = Convert.ToDouble(txtQuantity1.Text);
                rate = Convert.ToDouble(txtrate.Text);
                double amount = qty * rate;
                txtamount.Text = Convert.ToString(amount);
            }
            catch { }
        }

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
               
                    txtQuantity1.Focus();
                
            }
            else if (e.KeyCode == Keys.Escape)
            {
                RComboCheck = 1;
                dsNew.Dispose();
                dsNew.Clear();
                //cmbitem.Text = "";
                lblStock.Text = "";
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
                if (cmbparty.Visible==true)
                {
                    cmbparty.Focus();
                }
                else
                {
                    cmbitem.Focus();
                }
            }
        }

        private void txtremark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
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
            SetEntryNo();
            groupPanel3.Hide();
        }

        private void txtQuantity1_Enter(object sender, EventArgs e)
        {
         //   txtQuantity1.Text = Convert.ToString(1);
        }

        private void txtQuantity1_TextChanged_1(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            try
            {
                if (txtQuantity1.Text == "")
                {
                    txtamount.Text = Convert.ToString(0);
                }
                qty = Convert.ToDouble(txtQuantity1.Text);
                rate = Convert.ToDouble(txtrate.Text);
                double amount = qty * rate;
                txtamount.Text = Convert.ToString(amount);
            }
            catch { }
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
        public static DataSet dsReport = new DataSet();
        private void dgvopengrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dgvopengrid.Rows[e.RowIndex].ReadOnly = true;
            if (e.ColumnIndex == dgvopengrid.Columns[2].Index && e.RowIndex >= 0)
            {
                try
                {
                    rcheck = 1;
                    int a =Convert.ToInt32(dgvopengrid.CurrentRow.Cells["id"].Value);
                    ds = da.dataset_ret("select im.Name as ProductName,s. *,isnull(ledger_master.name,'') as sublocation,isnull(ledger_master2.name,'') as sublocation2 from StockInwardDetail s join Inventory_Master as im on im.ID=s.product left join ledger_master on ledger_master.id=sublocationid left join ledger_master as ledger_master2 on ledger_master2.id=sublocationid2  where s.Masterid=" + a + " ");
                    int count = ds.Tables["tab"].Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                   
                        dgvChallanDetail.Rows.Add();
                        dgvChallanDetail.Rows[i].Cells[4].Value = ds.Tables["tab"].Rows[i]["ProductName"];
                        dgvChallanDetail.Rows[i].Cells[5].Value = ds.Tables["tab"].Rows[i]["exdate"];
                        dgvChallanDetail.Rows[i].Cells[6].Value = ds.Tables["tab"].Rows[i]["qty"];
                        dgvChallanDetail.Rows[i].Cells[7].Value = ds.Tables["tab"].Rows[i]["Rate"];
                        dgvChallanDetail.Rows[i].Cells[8].Value = ds.Tables["tab"].Rows[i]["Amount"];
                        dgvChallanDetail.Rows[i].Cells[9].Value = ds.Tables["tab"].Rows[i]["product"];
                        dgvChallanDetail.Rows[i].Cells[10].Value = ds.Tables["tab"].Rows[i]["unit"];
                        dgvChallanDetail.Rows[i].Cells[11].Value = ds.Tables["tab"].Rows[i]["remark"];
                        dgvChallanDetail.Rows[i].Cells[12].Value = ds.Tables["tab"].Rows[i]["sublocation"];
                        dgvChallanDetail.Rows[i].Cells[13].Value = ds.Tables["tab"].Rows[i]["sublocationid"];
                        dgvChallanDetail.Rows[i].Cells[14].Value = ds.Tables["tab"].Rows[i]["sublocation2"];
                        dgvChallanDetail.Rows[i].Cells[15].Value = ds.Tables["tab"].Rows[i]["sublocationid2"];
                        dgvChallanDetail.Rows[i].Cells[16].Value = ds.Tables["tab"].Rows[i]["batchno"];
                        dgvChallanDetail.Rows[i].Cells[17].Value = ds.Tables["tab"].Rows[i]["batchnoid"];
                        dgvChallanDetail.Rows[i].Cells[18].Value = ds.Tables["tab"].Rows[i]["orgrate"];
                    }
                    cmbCompany.SelectedValue = dgvopengrid.CurrentRow.Cells["companyid"].Value.ToString();
                    string rdt = "";
                    rdt = dgvopengrid.CurrentRow.Cells["Invoicedate1"].Value.ToString();

                    dtinvoice.Text = rdt.Substring(0, 2) + '/' + rdt.Substring(3, 2) + '/' + rdt.Substring(6, 4);
                        txtinvoice.Text = dgvopengrid.CurrentRow.Cells["InvoiceNo"].Value.ToString();
                        txtEntry.Text = dgvopengrid.CurrentRow.Cells["entryno"].Value.ToString();
                        txtremark.Text = dgvopengrid.CurrentRow.Cells["Remark"].Value.ToString(); ;
                        //cmbparty.SelectedValue =Convert.ToInt32( dgvopengrid.CurrentRow.Cells["party"].Value.ToString());
                        txtChallan1.Text = dgvopengrid.CurrentRow.Cells["ID"].Value.ToString();
                        btnSave.Text = "&Update";
                    groupPanel3.Hide();
                    setgrid();
                    if (Convert.ToInt32(cmbCompany.SelectedValue) != 0)
                    {
                        if (MainIndex.formname == "Department")
                        {
                            da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Shop') and companyid=" + cmbCompany.SelectedValue + " order by  rtag,name", cmbSubLocation, "ID", "Name");
                            da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Department') and companyid=" + cmbCompany.SelectedValue + " order by  rtag,name", cmbSubLocation2, "ID", "Name");

                        }
                        else
                        {
                            da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Shop') and companyid=" + cmbCompany.SelectedValue + " order by  rtag,name", cmbSubLocation, "ID", "Name");

                        }
                    }
                    else
                    {
                        da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag ", cmbSubLocation, "ID", "Name");
                        da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag ", cmbSubLocation2, "ID", "Name");
                    }
                    cmbSubLocation2.SelectedValue = Convert.ToInt32(dgvopengrid.CurrentRow.Cells["party"].Value.ToString());
                    cmbSubLocation.SelectedValue = Convert.ToInt32(dgvChallanDetail.Rows[0].Cells[13].Value.ToString());
                    rcheck = 0;
                }
            catch (Exception ex)
                {
                    rcheck = 0;
                }
                

            }
              else if (e.ColumnIndex == dgvopengrid.Columns[1].Index && e.RowIndex >= 0)
            {
                if (MainIndex.formname == "Dispatch Challan")
                {
                    if (dgvopengrid.CurrentRow.Cells["importtag"].Value.ToString() == "1")
                    {
                        MessageBox.Show("Selected Dispatch Challan has been imported by shop user already."+Environment.NewLine+"So you cannot delete this.Please use cancel option for this.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                    }
                }
                else if (MainIndex.formname == "Shop Transfer")
                {
                    if (dgvopengrid.CurrentRow.Cells["importtag"].Value.ToString() == "1")
                    {
                        MessageBox.Show("Selected Transfer Challan has been imported by shop user already." + Environment.NewLine + "So you cannot delete this.Please use cancel option for this.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (MessageBox.Show("Are you sure want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
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
            else if (e.ColumnIndex == dgvopengrid.Columns[3].Index && e.RowIndex >= 0)
            {
                DataSet ds = new DataSet();
            int a =Convert.ToInt32(dgvopengrid.CurrentRow.Cells["id"].Value);
        
            ds = da.dataset_ret("select im.code, im.Name as ProductName,s. qty,s.rate from StockInwardDetail s join Inventory_Master as im on im.ID=s.product where im.rprint='Yes' and s.Masterid=" + a);
            int loop = 0;
            int innerLoop=0;
            for(loop=0;loop<ds.Tables[0].Rows.Count;loop++)
            {
                for (innerLoop = 0; innerLoop <Convert.ToInt32(ds.Tables[0].Rows[loop]["qty"].ToString()); innerLoop++)
                {
                    da.insert_update_delete("insert into barcode_print_table(rproduct,barcode,salerate,companyid) values('" + ds.Tables[0].Rows[loop]["ProductName"].ToString() + "','" + ds.Tables[0].Rows[loop]["code"].ToString() + "'," + Convert.ToDouble(ds.Tables[0].Rows[loop]["rate"].ToString()) + "," + companyid + ")");
                }
            }
            if(ds.Tables[0].Rows.Count>0)
            {
                frmCrystalReport.ReportName = "Barcode";
                frmCrystalReport obj_report = new frmCrystalReport();
                obj_report.ShowDialog();
                
            }
            
        
            }
            else if (e.ColumnIndex == dgvopengrid.Columns[4].Index && e.RowIndex >= 0)
            {
              
                int a = Convert.ToInt32(dgvopengrid.CurrentRow.Cells["id"].Value);
              
                    //dsReport = da.dataset_ret("select a.*,d.name as subgroup,c.name as pname,c.hsn,b.Qty,b.rate,b.Amount,e.name as comname,e.Address1,e.address2,e.address3,e.GSTIN, " +
                    //          " f.name as partyname,f.address1 as partyaddress1,f.address2 as partyaddress2,f.GSTNumber,f.mobile,b.remark as remark1 from ((select s.id,EntryNo,InvoiceNo,InvoiceDate,party,stocktype, " +
                    //          "  remark,s.companyid from StockInwardMaster as s where id=" + a + ") as a left join (select masterid,product,qty,rate,amount,remark from stockinwarddetail ) as b on a.id=b.masterid " +
                    //            "    left join (select id,inventory_s_group ,name,hsn from inventory_master) as c on b.product=c.id left join (select id,name from Inventory_Sub_Group_Master) as d on c.inventory_s_group=d.id " +
                    //            "    left join (select id,name,Address1,Address2,Address3,gstin from company_master union all select id,name,address1,address2,'' as address3,GSTNumber as gstin from ledger_master) as e on a.companyid=e.id left join (select id,name,address1,address2,GSTNumber,mobile from ledger_master) as f on a.party=f.id)");
                    dsReport = da.dataset_ret("select a.*,d.name as subgroup,c.name as pname,c.hsn,b.Qty,b.rate,b.Amount,e.name as comname,e.Address1,e.address2,e.address3,e.GSTIN, " +
          " f.name as partyname,f.address1 as partyaddress1,f.address2 as partyaddress2,f.GSTNumber,f.mobile,b.remark as remark1 from ((select s.id,EntryNo,InvoiceNo,InvoiceDate,party,stocktype, " +
          "  remark,s.companyid,1 as rcom,isnull((select ledger_master.name from stockinwardmaster rd left join Ledger_Master on Ledger_Master.id=rd.companyid where rd.id=" + a + "),'') as [lfrom] from StockInwardMaster as s where id=" + a + ") as a left join (select masterid,product,qty,rate,amount,remark from stockinwarddetail ) as b on a.id=b.masterid " +
            "    left join (select id,inventory_s_group ,name,hsn from inventory_master) as c on b.product=c.id left join (select id,name from Inventory_Sub_Group_Master) as d on c.inventory_s_group=d.id " +
            "    left join (select id,name,Address1,Address2,Address3,gstin from company_master) as e on a.rcom=e.id left join (select id,name,address1,address2,GSTNumber,mobile from ledger_master) as f on a.party=f.id)");

            
               


                if (dsReport.Tables[0].Rows.Count > 0)
                {
                    //if (Form1.CompanyID == 1 || Form1.CompanyID == 7)
                    //{
                        frmCrystalReport.ReportName = "Challan1";
                        frmCrystalReport obj_report = new frmCrystalReport();
                        obj_report.ShowDialog();
                    //}
                    //else
                    //{
                    //    rptChallan_Thermal rptChallan = new rptChallan_Thermal();
                    //    rptChallan.SetDataSource(dsReport.Tables[0]);
                    //    string rline = File.ReadAllText(Application.StartupPath + "//printer.txt");

                    //    rptChallan.PrintOptions.PrinterName = rline;
                    //    rptChallan.PrintToPrinter(1, true, 0, 0);
                    //}

                }
                dsReport.Dispose();
                dsReport.Clear();

            }
            else if (e.ColumnIndex > 4 && e.RowIndex >= 0)
            {
                dgvopengrid.Rows[e.RowIndex].ReadOnly = true;
            }
            else
            {
                dgvopengrid.Rows[e.RowIndex].ReadOnly = false;
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
                //dtfromdate.Text = "";
                //dttodate.Enabled = false;
                //dttodate.Text = "";
              
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

        private void dgvChallanDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    int temp=0;
            //    if (e.ColumnIndex == dgvChallanDetail.Columns["Quantity"].Index && e.RowIndex >= 0)
            //    {
            //        int count = dgvChallanDetail.Rows.Count;

            //        for (int i = 0; i < count; i++)
            //        {
            //           // int a = Convert.ToInt32(dgvChallanDetail.Rows[i].Cells["Quantity"].Value);
            //            if (count == 1)
            //            {
            //                txttotalqty.Text = dgvChallanDetail.Rows[i].Cells["Quantity"].Value.ToString();
            //            }
            //            else
            //            {
                            
                            
            //                        temp += Convert.ToInt32(dgvChallanDetail.Rows[i].Cells["Quantity"].Value);


            //                        txttotalqty.Text = temp.ToString();         
                               
            //            }
                       
            //        }
                  
            //    }
            //      if (e.ColumnIndex == dgvChallanDetail.Columns["qtynew"].Index && e.RowIndex >= 0)
            //    {
            //        int temp1 = 0;
            //        int count = dgvChallanDetail.Rows.Count;

            //        for (int i = 0; i < count; i++)
            //        {
            //            int a = Convert.ToInt32(dgvChallanDetail.Rows[i].Cells["qtynew"].Value);
            //            if (count == 1)
            //            {
            //                txttotalamt.Text = Convert.ToString(a);
            //            }
            //            else
            //            {
            //                temp1 += Convert.ToInt32(dgvChallanDetail.Rows[i].Cells["qtynew"].Value);
            //                txttotalamt.Text = temp1.ToString();
            //            }
                      
            //        }
            //    }
            //}
            //catch { }
        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void txtinvoice_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbparty_Validating(object sender, CancelEventArgs e)
        {
            if (cmbparty.Text.Trim() != "")
            {
                if (cmbparty.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select valid name.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbparty.Focus();
                    e.Cancel = true;
                    return;
                }
            }
            if(Convert.ToInt32(cmbparty.SelectedValue)!=0)
            {
                if(MainIndex.formname=="Department")
                {
                    da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Department') and companyid=" + cmbparty.SelectedValue + " order by  rtag,name", cmbSubLocation2, "ID", "Name");
                }
                else
                {
                    da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Shop') and companyid=" + cmbparty.SelectedValue + " order by  rtag,name", cmbSubLocation2, "ID", "Name");
                }
            }
            else
            {
                da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag ", cmbSubLocation2, "ID", "Name");

            }
        }
        double orgRate = 0;
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
                if(cmbitem.SelectedValue==null)
                {
                    MessageBox.Show("Please select valid name.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbitem.Focus();
                    e.Cancel = true;
                    return;
                }
            }
            if(cmbitem.Text.Trim()!="")
            {
               
                if (Convert.ToInt32(cmbSubLocation.SelectedValue) == 0)
                {
                    GETStock(1);
                }
                else
                {
                    GETStock(3);
                }
                DataSet rstemp1 = new DataSet();
                rstemp1 = da.dataset_ret("select a.* from (select distinct exdate from stockinwarddetail inner join stockinwardmaster on stockinwardmaster.id=masterid where exdate<>'' and stocktype='Purchase' and product=" + Convert.ToInt32(cmbitem.SelectedValue) +" ) as a ORDER BY CONVERT(DATETIME, a.exdate, 105)");
                cmbDate.Items.Clear();
                rcheck = 1;
                cmbDate.Items.Add("");
               
              
                int intloop = 0;
                for(intloop=0;intloop<rstemp1.Tables[0].Rows.Count;intloop++)
                {
                    cmbDate.Items.Add(rstemp1.Tables[0].Rows[intloop]["exdate"].ToString());
                }
                if (rstemp1.Tables[0].Rows.Count>0)
                {
                    cmbDate.SelectedIndex = 1;
                }
                else
                {
                    cmbDate.SelectedIndex = 0;
                }
                ShowUnit();
                DataSet rsTemp = new DataSet();
               
                 
                        if(Convert.ToInt32(cmbparty.SelectedValue)==0)
                        {
                            rsTemp = da.dataset_ret("select top 1 StockInwardDetail.Unit, rate from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid where (party=" + Convert.ToInt32(Form1.CompanyID) + " or companyid=" + Convert.ToInt32(Form1.CompanyID) + ") and product=" + Convert.ToInt32(cmbitem.SelectedValue) + " order by stockinwarddetail.id desc");

                        }
                        else
                        {
                            rsTemp = da.dataset_ret("select top 1 StockInwardDetail.Unit, rate from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid where (party=" + Convert.ToInt32(Form1.CompanyID) + " or companyid=" + Convert.ToInt32(Form1.CompanyID) + ") and product=" + Convert.ToInt32(cmbitem.SelectedValue) + " order by stockinwarddetail.id desc");

                        }
                        txtrate.Text = "0";
                        
                        cmbUnit.SelectedValue = 0;
                        if (rsTemp.Tables[0].Rows.Count > 0)
                        {
                            rcheck = 1;
                            txtrate.Text = rsTemp.Tables[0].Rows[0]["rate"].ToString();
                            orgRate = Convert.ToDouble(rsTemp.Tables[0].Rows[0]["rate"].ToString());
                            rcheck = 0;
                          //  cmbUnit.Text = rsTemp.Tables[0].Rows[0]["Unit"].ToString();
                        }
                        rsTemp.Dispose(); rsTemp.Clear();
                        rsTemp = da.dataset_ret("select Unit,rate from Inventory_Master where Name='" + Form1.SingleCode(cmbitem.Text) + "' ");
                        if (rsTemp.Tables[0].Rows.Count > 0)
                        {
                           // txtrate.Text = rsTemp.Tables[0].Rows[0]["rate"].ToString();
                            cmbUnit.Text = rsTemp.Tables[0].Rows[0]["Unit"].ToString();
                        }
                    
              
                rcheck = 0;
                if (lblStock.Text != "Stock : 0")
                {
                    ShowBatchData(Convert.ToInt32(cmbitem.SelectedValue));
                }
                
                //txtrate.Text = Convert.ToString(da.value1("select rate from Inventory_Master where Name='" + cmbitem.Text + "' "));
            }
          
        }
        private void ShowUnit()
        {
            if (Convert.ToInt32(cmbitem.SelectedValue) > 0)
            {
                da.fill_combo(" select 0 as ID, '--Select--' as Name,1 as rtag union all select distinct ID, Name,2 as rtag from tblunit where  id in (select isnull(unitid,0) as id1 from inventory_master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + " union all select isnull(lot1id,0) as id1 from inventory_master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + " union all select isnull(lot2id,0) as id1 from inventory_master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + " union all select isnull(lot3id,0) as id1 from inventory_master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + ") order by rtag,Name", cmbUnit, "ID", "Name");
                if (cmbUnit.Items.Count > 2)
                {
                    cmbUnit.Enabled = true;
                }
                else
                {
                    cmbUnit.Enabled = false;
                }
            }
        }
        private void GETStock(int rtag)
        {
           try
           {
               this.Cursor = Cursors.WaitCursor;
               DataSet rsTemp = new DataSet();
               if(rtag==1)
               {
                   rsTemp = da.dataset_ret("select (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0)))) as stock from ( " +
                                "  (select id,code,name,unit,minlevel from Inventory_Master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + ") as a left join  " +
                                "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master) as aa group by aa.product) as aaa on a.id=aaa.product " +
                               "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(Form1.CompanyID) + " ) and StockType in ('Purchase','Issue Return') group by product union all select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(Form1.CompanyID) + ") and StockType in ('Issue','Issue Return','Department') group by product) as aa group by aa.product) as inward on a.id=inward.product " +
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
               else if (rtag == 3)
               {
                   rsTemp = da.dataset_ret("select (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0)))) as stock from ( " +
                                "  (select id,code,name,unit,minlevel from Inventory_Master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + ") as a left join  " +
                                "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master) as aa group by aa.product) as aaa on a.id=aaa.product " +
                               "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(Form1.CompanyID) + " ) and (sublocationid="+cmbSubLocation.SelectedValue+")  and StockType in ('Purchase','Issue Return') group by product union all select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(Form1.CompanyID) + ") and ( sublocationid2=" + cmbSubLocation.SelectedValue + " )  and StockType in ('Issue','Issue Return','Department') group by product) as aa group by aa.product) as inward on a.id=inward.product " +
                               "   left join (select product,sum(qty) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                               "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(Form1.CompanyID) + " )  and (sublocationid=" + cmbSubLocation.SelectedValue + "  )  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product) as outward on a.id=outward.product " +
                                "  left join (select product,sum(qty) as consumed from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                               "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + " and (sublocationid=" + cmbSubLocation.SelectedValue + " )   and StockType in ('Consumed') group by product) as consumed on a.id=consumed.product " +
                                "  left join (select product,sum(qty) as damages from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                "  where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + " and (sublocationid=" + cmbSubLocation.SelectedValue + " )   and StockType in ('Damages') group by product) as damages on a.id=damages.product " +
                                  "  left join (select product,sum(qty) as wastage from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                "  where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and (sublocationid=" + cmbSubLocation.SelectedValue + " )  and StockType in ('Wastage') group by product) as wastage on a.id=wastage.product " +
                                " ) order by a.name");
               }

               else
               {
                   string rdate = "";
                   if(cmbDate.Text!="")
                   {
                       rdate = cmbDate.Text.Substring(6, 4) + "-" + cmbDate.Text.Substring(3, 2) + "-" + cmbDate.Text.Substring(0, 2);
                   }
                   rsTemp = da.dataset_ret("select (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0)))) as stock from ( " +
                            "  (select inventory_master.id,code,name,exdate1 as subgroupname,inventory_master.unit from Inventory_Master inner join stockinwarddetail on stockinwarddetail.product=inventory_master.id inner join stockinwardmaster on stockinwardmaster.id=masterid where exdate1>='" + rdate + "' and exdate1<='" + rdate + "' and  stockinwardmaster.stocktype='Purchase' and stockinwarddetail.product=" + Convert.ToInt32(cmbitem.SelectedValue) + ") as a left join  " +
                            "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
                            "   left join (select aa.product,sum(aa.inward) as inward,aa.exdate1 from (select product,sum(qty) as inward,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                            "   where exdate1>='" + rdate + "' and exdate1<='" + rdate + "' and  (companyid=" + Convert.ToInt32(Form1.CompanyID) + " ) and StockType in ('Purchase','Issue Return') group by product,exdate1 union all select product,sum(qty) as inward,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                            "   where  exdate1>='" + rdate + "' and exdate1<='" + rdate + "' and (party=" + Convert.ToInt32(Form1.CompanyID) + ") and StockType in ('Issue','Issue Return','Department') group by product,exdate1) as aa group by aa.product,aa.exdate1) as inward on a.id=inward.product and a.subgroupname=inward.exdate1 " +
                            "   left join (select product,sum(qty) as outward,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                            "   where  exdate1>='" + rdate + "' and exdate1<='" + rdate + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product,exdate1) as outward on a.id=outward.product  and a.subgroupname=outward.exdate1 " +
                            "  left join (select product,sum(qty) as consumed,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                            "   where  exdate1>='" + rdate + "' and exdate1<='" + rdate + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Consumed') group by product,exdate1) as consumed on a.id=consumed.product and a.subgroupname=consumed.exdate1 " +
                            "  left join (select product,sum(qty) as damages,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                            "  where exdate1>='" + rdate + "' and exdate1<='" + rdate + "'  and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Damages') group by product,exdate1) as damages on a.id=damages.product and a.subgroupname=damages.exdate1" +
                            "  left join (select product,sum(qty) as wastage,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                            "  where exdate1>='" + rdate + "' and exdate1<='" + rdate + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Wastage') group by product,exdate1) as wastage on a.id=wastage.product and a.subgroupname=wastage.exdate1 " +
                            "  ) ");



                  

               }
               lblStock.Text = "Stock : 0";
               if (rsTemp.Tables[0].Rows.Count > 0)
               {
                   lblStock.Text = "Stock : " +Math.Round(Convert.ToDouble( rsTemp.Tables[0].Rows[0]["stock"].ToString()),3).ToString();
               }
               this.Cursor = Cursors.Default;
           }
            catch
           {
               this.Cursor = Cursors.Default;
           }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvopengrid.Rows.Count == 0) { return; }
            if (MessageBox.Show("Are you sure want to cancel dispatch challan?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvopengrid.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[0].Value == "true")
                        {

                            int id = Convert.ToInt32(dgvopengrid.Rows[row.Index].Cells["ID"].Value.ToString());
                          
                                try
                                {
                                    da.insert_update_delete("update stockinwardmaster set importtag=0 where id=" + id);
                                    da.insert_update_delete("delete from stockinwarddetail where masterid=" + id);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed");
                                }
                            
                        }
                    }
                }
                fillgrid();
            }

        }

        private void dgvopengrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (MainIndex.formname == "Dispatch Challan")
            {
                if(dgvopengrid.Rows[e.RowIndex].Cells["importtag"].Value.ToString()=="1")
                {
                    dgvopengrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else
                {
                    dgvopengrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
            //else if (MainIndex.formname == "Shop Transfer")
            //{
            //    if (dgvopengrid.Rows[e.RowIndex].Cells["importtag"].Value.ToString() == "1")
            //    {
            //        dgvopengrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
            //    }
            //    else
            //    {
            //        dgvopengrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            //    }
            //}
        }

        private void txtRemark1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtRemark1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnadds.Focus();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
            if (Mainid!=0)
            {
                dsReport = da.dataset_ret("select a.*,d.name as subgroup,c.name as pname,c.hsn,b.Qty,b.rate,b.Amount,e.name as comname,e.Address1,e.address2,e.address3,e.GSTIN, " +
                                             " f.name as partyname,f.address1 as partyaddress1,f.address2 as partyaddress2,f.GSTNumber,f.mobile,b.remark as remark1 from ((select s.id,EntryNo,InvoiceNo,InvoiceDate,party,stocktype, " +
                                             "  remark,s.companyid from StockInwardMaster as s where id=" + Mainid + ") as a left join (select masterid,product,qty,rate,amount,remark from stockinwarddetail ) as b on a.id=b.masterid " +
                                               "    left join (select id,inventory_s_group ,name,hsn from inventory_master) as c on b.product=c.id left join (select id,name from Inventory_Sub_Group_Master) as d on c.inventory_s_group=d.id " +
                                               "    left join (select * from company_master) as e on a.companyid=e.id left join (select id,name,address1,address2,GSTNumber,mobile from ledger_master) as f on a.party=f.id)");

                if (dsReport.Tables[0].Rows.Count > 0)
                {
                    //frmCrystalReport.ReportName = "Challan";
                    //frmCrystalReport obj_report = new frmCrystalReport();
                    //obj_report.ShowDialog();
                    if (Form1.CompanyID==1 || Form1.CompanyID==7)
                    {
                        rptChallan rptChallan = new rptChallan();
                        rptChallan.SetDataSource(dsReport.Tables[0]);
                        string rline = File.ReadAllText(Application.StartupPath + "//printer.txt");

                        rptChallan.PrintOptions.PrinterName = rline;
                        rptChallan.PrintToPrinter(1, true, 0, 0);
                    }
                    else
                    {
                        rptChallan_Thermal rptChallan = new rptChallan_Thermal();
                        rptChallan.SetDataSource(dsReport.Tables[0]);
                        string rline = File.ReadAllText(Application.StartupPath + "//printer.txt");

                        rptChallan.PrintOptions.PrinterName = rline;
                        rptChallan.PrintToPrinter(1, true, 0, 0);
                    }
                }
                dsReport.Dispose();
                dsReport.Clear();
                Mainid = 0;
            }
        }
        int rValue = 0;
        private void cmbitem_Enter(object sender, EventArgs e)
        {
           // if (rcheck == 1) { return; }
           // if (RComboCheck == 1) { return; }
           // cmbitem.DroppedDown = false;
           // //cmbitem.SelectedValue = 0;
            
           ////SetSearchCombo(cmbitem, dsNew);
         
           // if(rValue!=0)
           // {
           //     cmbitem.SelectedValue = rValue;
           // }
       
           
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
             string intRowValue="";
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

        private void cmbCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbSubLocation.Focus();
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
            if (Convert.ToInt32(cmbCompany.SelectedValue) != 0)
            {
                if (MainIndex.formname == "Department")
                {
                    da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Shop') and companyid=" + cmbCompany.SelectedValue + " order by  rtag,name", cmbSubLocation, "ID", "Name");
                    da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Department') and companyid=" + cmbCompany.SelectedValue + " order by  rtag,name", cmbSubLocation2, "ID", "Name");

                }
                else
                {
                    da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Shop') and companyid=" + cmbCompany.SelectedValue + " order by  rtag,name", cmbSubLocation, "ID", "Name");

                }
            }
            else
            {
                da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag ", cmbSubLocation, "ID", "Name");
                da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag ", cmbSubLocation2, "ID", "Name");
            }
            cmbparty.SelectedValue = cmbCompany.SelectedValue;
        }

        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnadds.Focus();
            }
        }
        private void ShowBatchData(int productid)
        {
            this.Cursor = Cursors.WaitCursor;
            DataSet rsTemp = new DataSet();

            label9.Text = "Batch No. Wise Detail of Product : " + cmbitem.Text;
            rsTemp = da.dataset_ret("select a.masterid,a.id,a.code,a.name,a.subgroupname,a.exdate,(((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0)))) as stock " +
                                          "  ,a.unit,a.rate from ( " +
                                          "  (select stockinwarddetail.masterid, inventory_master.id,code,name,batchno as subgroupname,inventory_master.unit,exdate,stockinwarddetail.rate from Inventory_Master inner join stockinwarddetail on stockinwarddetail.product=inventory_master.id inner join stockinwardmaster on stockinwardmaster.id=masterid where  stockinwardmaster.stocktype='Purchase' and product="+productid+") as a left join  " +
                                          "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
                                         "   left join (select aa.product,sum(aa.inward) as inward,aa.exdate1 from (select product,sum(qty) as inward,batchno as exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                          "   where  (companyid=" + Convert.ToInt32(Form1.CompanyID) + " ) and StockType in ('Purchase','Issue Return') and product=" + productid + " group by product,batchno union all select product,sum(qty) as inward,batchno as exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                          "   where  (party=" + Convert.ToInt32(Form1.CompanyID) + ") and StockType in ('Issue','Issue Return','Department') and product=" + productid + " group by product,batchno) as aa group by aa.product,aa.exdate1) as inward on a.id=inward.product and a.subgroupname=inward.exdate1 " +
                                         "   left join (select product,sum(qty) as outward,batchno as exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                         "   where  companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') and product=" + productid + " group by product,batchno) as outward on a.id=outward.product  and a.subgroupname=outward.exdate1 " +
                                          "  left join (select product,sum(qty) as consumed,batchno as exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                         "   where  companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Consumed') and product=" + productid + " group by product,batchno) as consumed on a.id=consumed.product and a.subgroupname=consumed.exdate1 " +
                                          "  left join (select product,sum(qty) as damages,batchno as exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                          "  where  companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Damages') and product=" + productid + " group by product,batchno) as damages on a.id=damages.product and a.subgroupname=damages.exdate1" +
                                          "  left join (select product,sum(qty) as wastage,batchno as exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                          "  where  companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Wastage') and product=" + productid + " group by product,batchno) as wastage on a.id=wastage.product and a.subgroupname=wastage.exdate1 " +
                                          "  ) where (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0))))<>0 order by a.masterid");

            int intloop = 0;
            double total = 0;
            dbGrid.Rows.Clear();
            for (intloop = 0; intloop < rsTemp.Tables[0].Rows.Count; intloop++)
            {
                dbGrid.Rows.Add();
                dbGrid.Rows[intloop].Cells[0].Value = rsTemp.Tables[0].Rows[intloop]["code"].ToString();
                dbGrid.Rows[intloop].Cells[1].Value = rsTemp.Tables[0].Rows[intloop]["name"].ToString();
                dbGrid.Rows[intloop].Cells[2].Value = rsTemp.Tables[0].Rows[intloop]["exdate"].ToString();
                dbGrid.Rows[intloop].Cells[3].Value = rsTemp.Tables[0].Rows[intloop]["subgroupname"].ToString();
                dbGrid.Rows[intloop].Cells[4].Value = rsTemp.Tables[0].Rows[intloop]["stock"].ToString();
                dbGrid.Rows[intloop].Cells[5].Value = rsTemp.Tables[0].Rows[intloop]["unit"].ToString();
                dbGrid.Rows[intloop].Cells[6].Value = rsTemp.Tables[0].Rows[intloop]["rate"].ToString();
                dbGrid.Rows[intloop].Cells[7].Value = rsTemp.Tables[0].Rows[intloop]["masterid"].ToString();
                dbGrid.Rows[intloop].HeaderCell.Value = Convert.ToString(intloop + 1);
                total += Convert.ToDouble(rsTemp.Tables[0].Rows[intloop]["stock"].ToString());
            }
            lblGridStock.Text = total.ToString();
            if(dbGrid.Rows.Count==1)
            {
                rcheck = 1;
                txtBatch.Text = dbGrid.Rows[0].Cells[3].Value.ToString();
                txtBatch.Tag = dbGrid.Rows[0].Cells[7].Value.ToString();
                txtrate.Text = dbGrid.Rows[0].Cells[6].Value.ToString();
                rcheck = 0;
              //  cmbDate.Text = dbGrid.Rows[0].Cells[2].Value.ToString();
                panel1.Visible = false;
                //txtQuantity1.Focus();
            }
            else
            {
                cmbitem.DroppedDown = false;
                panel1.Visible = true;
                dbGrid.Focus();
            }
          
            this.Cursor = Cursors.Default;
        }
        private void cmbitem_SelectedValueChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            if(Convert.ToInt32(cmbitem.SelectedValue)>0)
            {
                lblStock.Visible = true;
                //ShowBatchData(Convert.ToInt32(cmbitem.SelectedValue));
                
                if(Convert.ToInt32(cmbSubLocation.SelectedValue)==0)
                {
                    GETStock(1);
                }
                else
                {
                    if (MainIndex.formname == "Issue" || MainIndex.formname == "Department")
                    {
                        GETStock(3);
                    }
                    else
                    {
                        GETStock(1);
                    }
                }
            }
            else
            {
                lblStock.Visible = false;
            }
        }

        private void cmbDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtQuantity1.Focus();
            }
        }

        private void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
           
                lblStock.Visible = true;
            if(cmbDate.Text!="")
            {
                GETStock(2);
            }
            else
            {
                if (Convert.ToInt32(cmbSubLocation.SelectedValue) == 0)
                {
                    GETStock(1);
                }
                else
                {
                    GETStock(3);
                }
            }
                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dbGrid.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dbGrid.Rows.Count==0)
            {
                MessageBox.Show("Please specify stock quantity.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int count = dbGrid.Rows.Count;
            int intl=0;
            intl = dgvChallanDetail.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (dbGrid.Rows[i].Cells[12].Value!=null)
                {
                    if (dbGrid.Rows[i].Cells[12].Value.ToString() != "0")
                    {
                        dgvChallanDetail.Rows.Add();
                        dgvChallanDetail.Rows[intl].Cells[4].Value = dbGrid.Rows[i].Cells[4].Value.ToString();
                        dgvChallanDetail.Rows[intl].Cells[5].Value = "";
                        dgvChallanDetail.Rows[intl].Cells[6].Value = dbGrid.Rows[i].Cells[13].Value.ToString();
                        dgvChallanDetail.Rows[intl].Cells[7].Value = dbGrid.Rows[i].Cells[7].Value.ToString();
                        dgvChallanDetail.Rows[intl].Cells[8].Value = Convert.ToDouble(dbGrid.Rows[i].Cells[13].Value.ToString())*Convert.ToDouble(dbGrid.Rows[i].Cells[7].Value.ToString());
                        dgvChallanDetail.Rows[intl].Cells[9].Value = dbGrid.Rows[i].Cells[9].Value.ToString();
                        dgvChallanDetail.Rows[intl].Cells[10].Value = dbGrid.Rows[i].Cells[10].Value.ToString();
                        dgvChallanDetail.Rows[intl].Cells[11].Value = "";
                        intl += 1;
                    }
                }

            }
            setgrid();
            panel1.Visible = false;
            dbGrid.Rows.Clear();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataSet rsTemp = new DataSet();

            rsTemp = da.dataset_ret("select a.id,a.code,a.name, (((isnull(aaa.qty,0)+isnull(inward.inward,0)+isnull(production.production,0))-(isnull(outward.outward,0)+isnull(sale.sale,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0)))) as stock," +
                            " isnull((select top 1 round((StockInwardDetail.amount/stockinwarddetail.qty),2) as rate from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid where party=" + Convert.ToInt32(Form1.CompanyID) + " and product= a.id order by stockinwarddetail.id desc ),0) as rate, " +
                             " isnull((select top 1 StockInwardDetail.Unit from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid where party=" + Convert.ToInt32(Form1.CompanyID) + " and product= a.id order by stockinwarddetail.id desc),'') as unit " +
                                " from ( " +
                             "  (select id,code,name,unit,minlevel from Inventory_Master ) as a left join  " +
                             "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master) as aa group by aa.product) as aaa on a.id=aaa.product " +
                            "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                           "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(Form1.CompanyID) + " ) and StockType in ('Purchase','Issue Return') group by product union all select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                           "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(Form1.CompanyID) + ") and StockType in ('Issue','Issue Return') group by product) as aa group by aa.product) as inward on a.id=inward.product " +
                            "   left join (select product,sum(qty) as production from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                             "  where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Production') group by product) as production on a.id=production.product " +
                            "   left join (select product,sum(qty) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                            "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return') group by product) as outward on a.id=outward.product " +
                            "   left join (select zz.product,sum(zz.sale) as sale from (select productid as product,(sum(qty)) as sale from sale inner join SaleDetail on sale.id=saleid where " +
                             "  kotdate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and BillNo=0 group by ProductId " +
                             "  union all select productid as product,(sum(qty)) as sale from sale inner join SaleDetail on sale.id=saleid where " +
                             "  billdate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and kotNo=0 group by ProductId " +
                             "  ) as zz group by zz.product ) as sale on a.id=sale.product " +
                             "  left join (select product,sum(qty) as consumed from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                            "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Consumed') group by product) as consumed on a.id=consumed.product " +
                             "  left join (select product,sum(qty) as damages from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                             "  where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Damages') group by product) as damages on a.id=damages.product " +
                               "  left join (select product,sum(qty) as wastage from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                             "  where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Wastage') group by product) as wastage on a.id=wastage.product " +
                             " ) where (((isnull(aaa.qty,0)+isnull(inward.inward,0)+isnull(production.production,0))-(isnull(outward.outward,0)+isnull(sale.sale,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0))))<>0 order by a.code");

            int intloop = 0;
            for(intloop=0;intloop<rsTemp.Tables[0].Rows.Count;intloop++)
            {
                dbGrid.Rows.Add();
                dbGrid.Rows[intloop].Cells[3].Value = rsTemp.Tables[0].Rows[intloop]["code"].ToString();
                dbGrid.Rows[intloop].Cells[4].Value = rsTemp.Tables[0].Rows[intloop]["name"].ToString();
                dbGrid.Rows[intloop].Cells[6].Value = rsTemp.Tables[0].Rows[intloop]["stock"].ToString();
                dbGrid.Rows[intloop].Cells[9].Value = rsTemp.Tables[0].Rows[intloop]["id"].ToString();
                dbGrid.Rows[intloop].Cells[7].Value = rsTemp.Tables[0].Rows[intloop]["rate"].ToString();
                dbGrid.Rows[intloop].Cells[10].Value = rsTemp.Tables[0].Rows[intloop]["unit"].ToString();
                dbGrid.Rows[intloop].HeaderCell.Value = Convert.ToString(intloop + 1);
            }
            panel1.Visible = true;
            this.Cursor = Cursors.Default;
        }

        private void dbGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == -1)
            //{
            //    return;
            //}
         
          
            // if (e.ColumnIndex ==12 && e.RowIndex >= 0)
            //{
            //    dbGrid.Rows[e.RowIndex].ReadOnly = false;
            //}
            //else
            //{
            //    dbGrid.Rows[e.RowIndex].ReadOnly = true;
            //}
        }

        private void dbGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (dbGrid.Rows.Count == 0) { return; }
                rcheck = 1;
                txtBatch.Text = dbGrid.CurrentRow.Cells[3].Value.ToString();
                txtrate.Text = dbGrid.CurrentRow.Cells[6].Value.ToString();
                txtBatch.Tag = dbGrid.CurrentRow.Cells[7].Value.ToString();
                cmbDate.Text = dbGrid.CurrentRow.Cells[2].Value.ToString();
                orgRate = Convert.ToDouble(dbGrid.CurrentRow.Cells[6].Value.ToString());
                panel1.Visible = false;
                txtQuantity1.Focus();
                rcheck = 0;
            }
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (dbGrid.Rows.Count == (Convert.ToInt32(dbGrid.CurrentRow.Index) + 1))
            //    {
            //        if (dbGrid.CurrentRow.Cells[12].Value!="")
            //        {
            //            dbGrid.CurrentRow.Cells[13].Value = Convert.ToDouble(dbGrid.CurrentRow.Cells[6].Value) - Convert.ToDouble(dbGrid.CurrentRow.Cells[12].Value);
            //        }
                    
            //        button1.Focus();
            //    }
            //    else
            //    {
            //        if (dbGrid.CurrentRow.Cells[12].Value != "")
            //        {
            //            dbGrid.CurrentRow.Cells[13].Value = Convert.ToDouble(dbGrid.CurrentRow.Cells[6].Value) - Convert.ToDouble(dbGrid.CurrentRow.Cells[12].Value);
            //        }
            //    }
            //}
        }

        private void dbGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (rcheck == 1) { return; }
            //if(e.ColumnIndex==12)
            //{
            //    if (dbGrid.Rows.Count == 0) { return; }
            //    if (dbGrid.CurrentRow.Cells[12].Value != "")
            //    {
            //        dbGrid.CurrentRow.Cells[13].Value = Convert.ToDouble(dbGrid.CurrentRow.Cells[6].Value) - Convert.ToDouble(dbGrid.CurrentRow.Cells[12].Value);
            //    }
            //}
        }

        private void cmbSubLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbSubLocation2.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cmbSubLocation.SelectedValue = 0;
                cmbSubLocation.Focus();
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

        private void cmbSubLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSubLocation_SelectedValueChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            if(Convert.ToInt32(cmbitem.SelectedValue)!=0)
            {
                if (Convert.ToInt32(cmbSubLocation.SelectedValue) == 0)
                {
                    GETStock(1);
                }
                else
                {
                    if(MainIndex.formname=="Issue" || MainIndex.formname=="Department")
                    {
                        GETStock(3);
                    }
                    else
                    {
                        GETStock(1);
                    }
                }
            }
           
        }

        private void cmbSubLocation2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbitem.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cmbSubLocation2.SelectedValue = 0;
                cmbSubLocation2.Focus();
            }
        }

        private void cmbSubLocation2_Validating(object sender, CancelEventArgs e)
        {
            if (cmbSubLocation2.Text.Trim() != "")
            {
                if (cmbSubLocation2.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select valid name.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSubLocation2.Focus();
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void dbGrid_DoubleClick(object sender, EventArgs e)
        {
            if (dbGrid.Rows.Count == 0) { return; }
            rcheck = 1;
            txtBatch.Text = dbGrid.CurrentRow.Cells[3].Value.ToString();
            txtBatch.Tag = dbGrid.CurrentRow.Cells[7].Value.ToString();
            cmbDate.Text = dbGrid.CurrentRow.Cells[2].Value.ToString();
            txtrate.Text = dbGrid.CurrentRow.Cells[6].Value.ToString();
            orgRate = Convert.ToDouble(dbGrid.CurrentRow.Cells[6].Value.ToString());
            panel1.Visible = false;
            txtQuantity1.Focus();
            rcheck = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            if (Convert.ToInt32(cmbUnit.SelectedValue) == 0) { return; }
            DataSet rstemp = new DataSet();
            rstemp = da.dataset_ret("select aa.* from (select 1 as r1 from inventory_master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + " and unitid=" + Convert.ToInt32(cmbUnit.SelectedValue) + " union all select conv1 as r1 from inventory_master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + " and lot1id=" + Convert.ToInt32(cmbUnit.SelectedValue) + " union all select conv2 as r1 from inventory_master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + " and  lot2id=" + Convert.ToInt32(cmbUnit.SelectedValue) + " union all select conv3 as r1 from inventory_master where id=" + Convert.ToInt32(cmbitem.SelectedValue) + " and  lot3id=" + Convert.ToInt32(cmbUnit.SelectedValue) + ") as aa");
            if(rstemp.Tables[0].Rows.Count>0)
            {
                double qty1 = 0;
                if(txtQuantity1.Text!="")
                {
                    qty1 = Convert.ToDouble(txtQuantity1.Text);
                }
                rate = (orgRate*Convert.ToDouble(rstemp.Tables[0].Rows[0]["r1"].ToString()));
                rcheck = 1;
                txtrate.Text = rate.ToString();
                    rcheck=0;
                    double amount = qty1 * rate;
                txtamount.Text = Convert.ToString(amount);
            }
        }

       
    }
}