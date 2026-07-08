using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using EdgeVastra;
using EdgeVastra.Data;


using System.Data.OleDb;
using System.Data.SqlClient;
using EdgePack;

using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EdgePackingShared;

using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;

namespace EdgePackaging
{
    public partial class frmPayment1 : Form
    {
        public frmPayment1()
        {
            InitializeComponent();
        }
        database_admin da = new database_admin();
        int rcheck = 0;
        public static int companyid = Form1.CompanyID;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetBillNo() // function for set bill or kot no.
        {
            int billno = 0;

         
                try
                {
                    billno = Convert.ToInt32(da.value1("select isnull(max(RecNo),0) as BillNo from payment_entry "));
                     txtbillno.Text = Convert.ToString(billno + 1);
                }
                catch
                {
                    billno = 0;
                }
              
                
            }

        private void frmPayment1_Load(object sender, System.EventArgs e)
        {
       
            rcheck = 1;
            SetBillNo();
            da.fill_combo("select 0 as ID,'--Select--' as name,1 as rtag union all select  ID,Name,2 as rtag from ledger_master where companyid=" + Form1.Godownid + " and  type in ('Supplier','Expenses') Order By rtag, Name", cmbparty, "ID", "Name");
            da.fill_combo("select 0 as ID,'--All--' as name,1 as rtag union all select  ID,Name,2 as rtag from ledger_master where companyid=" + Form1.Godownid + " and  type in ('Supplier','Expenses')  Order By rtag, Name", cmbPartySearch, "ID", "Name");
               da.fill_combo("select ID,Name from tblPaymentMode", cmbseries, "ID", "Name");
            if(Form1.utype!=0)
            {
                dgvSearchGrid.Columns[1].Visible = false;
                dgvSearchGrid.Columns[2].Visible = false;
            }
               cmAll.SelectedIndex = 0;
               rcheck = 0;
        }

        private void cmbparty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRecAmt.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cmbparty.SelectedValue = 0;
                cmbparty.SelectAll();
            }
        }

        private void cmbparty_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (rcheck == 1) { return; }
            if (cmbparty.Text.Trim() == "" || Convert.ToInt32(cmbparty.SelectedIndex) == -1)
            {
                MessageBox.Show("Please select valid name.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbparty.Focus();
                e.Cancel = true;
                return;
            }
          
        }

        private void cmbseries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbparty.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cmbseries.SelectedValue = 0;
                cmbseries.SelectAll();
            }
        }

        private void cmbseries_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbseries.Text.Trim() == "" || Convert.ToInt32(cmbseries.SelectedIndex) == -1)
            {
                MessageBox.Show("Please select valid name.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbseries.Focus();
                e.Cancel = true;
                return;
            }
        }

  

        private void dtinvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cmbseries.Focus();
            }
        }

        private void txtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSave_Print.Focus();
            }
        }

        private void txtRecAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtNarration.Focus();
            }
        }

      
   
    
        private void txtRecAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
                { e.Handled = true; }
                TextBox txtDecimal = sender as TextBox;
                if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

  

   

        private void btnReset_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to reset fields?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            BlankField();
        } 
          
        private void BlankField()
        {
            rcheck = 1;
            SetBillNo();
            cmbseries.SelectedValue = 1;
            txtNarration.Text = "";
            txtMobile.Text = "";
            cmbparty.SelectedValue = 0;
            lblBal.Text = "";
            txtRecAmt.Text = "";
            rcheck = 0;
          
            btnSave.Text = "Save && &Print";
            btnSave_Print.Text = "&Save";
            cmbparty.Focus();
           
        }

     

  

        private void btnSave_Print_Click(object sender, System.EventArgs e)
        {
            if(Convert.ToInt32(cmbparty.SelectedValue)==0)
            {
                MessageBox.Show("Please specify name.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbparty.Focus();
                return;
            }
          if(txtRecAmt.Text=="")
          {
              MessageBox.Show("Please specify amount.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
              txtRecAmt.Focus();
              return;
          }
            if (btnSave_Print.Text != "&Update")
            {
                SetBillNo();
            }
            int id = 0; int recid = 0;
            if (btnSave_Print.Text == "&Update")//for Update 
            {
                id = Convert.ToInt32(txtbillno.Tag);
                recid = id;
            }
            string rtype = "";
            if(optReceipt.Checked==true)
            {
                rtype = "Receipt";
            }
            else
            {
                rtype = "Payment";
            }
            Receipt_InsertUpdate(id, Convert.ToInt32(txtbillno.Text), Convert.ToInt32(cmbseries.SelectedValue), Convert.ToInt32(cmbparty.SelectedValue), txtNarration.Text, Convert.ToDouble(txtRecAmt.Text), Form1.UserID, companyid, rtype);
               
            if (btnSave_Print.Text != "&Update")//for Update 
                {
                    recid = Convert.ToInt32(da.value1("select max(ID) from Payment_Entry where  companyid=" + companyid + " and recno=" + Convert.ToInt32(txtbillno.Text)));
                    txtbillno.Tag = recid;
                }
            da.insert_update_delete("update Payment_Entry set recdate='" + dtinvoice.Value.ToString("yyyy-MM-dd") + "' where id=" + recid);
           
             
                try
                {
                    string sms = "";
                    string rdate1 = dtinvoice.Value.Date.ToString("dd/MM/yyyy");

                    if (chkSMS.Checked == true)
                    {
                      
                        DataSet dd = new DataSet();
                        string CustMobile = "";
                        dd = da.dataset_ret("select mobile from ledger_master where id=" + Convert.ToInt32(cmbparty.SelectedValue));
                        if (dd.Tables[0].Rows[0]["mobile"].ToString() != "")
                        {
                            CustMobile = dd.Tables[0].Rows[0]["mobile"].ToString();
                            DataSet DS = new DataSet();
                            double WBal = 0;
                            DS = da.dataset_ret("select sum(aa.netamount) as netamount from (select isnull(sum(netamount)*-1,0) as netamount from sale where partyid=" + cmbparty.SelectedValue + " and paymode='Credit' union all select isnull(sum(totrecamt),0) as netamount from payment_entry where party=" + cmbparty.SelectedValue + " and rtype='Receipt' union all select isnull((sum((totrecamt))*-1),0) as netamount from payment_entry where party=" + cmbparty.SelectedValue + " and rtype='Payment') as aa");
                            if (DS.Tables[0].Rows.Count > 0)
                            {
                                WBal = Convert.ToDouble(DS.Tables[0].Rows[0]["netamount"].ToString());
                            }
                            DS.Dispose(); DS.Clear();
                            sms = "Dear " + cmbparty.Text + ", Your wallet is top up with Rs " + txtRecAmt.Text + ". Now your current balance is "+WBal+". Thank you for visit "+MainIndex.CompanyName;

                            sendSMS(CustMobile, sms);
                        }

                    }
                }
                catch
                {
                    MessageBox.Show("Data not saved");
                }
                BlankField();

        }
        private void GETBalance(int Partyid)
        {
            //if (cmbparty.Text == "Cash" || cmbparty.Text == "CASH") { return; }
            //DataSet DS = new DataSet();
            //DS = da.dataset_ret("select sum(aa.netamount) as netamount from (select isnull(sum(netamount)*-1,0) as netamount from sale where partyid=" + Partyid + " and paymode='Pay by Membership' union all select isnull(sum(totrecamt),0) as netamount from payment_entry where party=" + Partyid + " and rtype='Receipt' union all select isnull((sum((totrecamt))*-1),0) as netamount from payment_entry where party=" + Partyid + " and rtype='Payment') as aa");
            //if (DS.Tables[0].Rows.Count > 0)
            //{
            //    lblBal.Text = "Balance Amount : " + DS.Tables[0].Rows[0]["netamount"].ToString();
            //}
            //DS.Dispose(); DS.Clear();
        }
        public bool Receipt_InsertUpdate(int ID, int RecNo,int PMode,int Party,string Narration,double TotRecAmt, int UserId,int companyid,string rtype)
        {
            bool flag = false;
            string[] Inventory_Par = new string[] { "@ID", "@RecNo", "@PMode", "@Party", "@Narration",  "@TotRecAmt", "@UserId" ,"companyid","rtype"};
            object[] Inventory_Val = new object[] { ID, RecNo, PMode, Party, Narration, TotRecAmt,  UserId,companyid,rtype};
          
                flag = DataConnection.RunQueryO("Payment_InsertUpdate", Inventory_Par, Inventory_Val, DataConnection.sConnstr);
      

            if (flag)
                return true;
            else
                return false;
        }
     

        private void sendSMS(string toNumber, string sms)
        {
            System.Net.WebClient web = new System.Net.WebClient();
            string MSGSTR;
            MSGSTR = "http://sms.media-craft.in/api/mt/SendSMS?APIKey=mOoiKa0iYkyPq16RdVkzWw&senderid=INFOSM&channel=Trans&DCS=0&flashsms=0&number=" + toNumber + "&text=" + sms + "&route=2";

            web.DownloadDataAsync(new Uri(MSGSTR, UriKind.Absolute));
        }
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            btnSave_Print_Click(sender, e);
            if (txtbillno.Tag == "" || txtbillno.Tag == null)
            {
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            dsReport = da.dataset_ret("select '" + MainIndex.CompanyName + "' as comname, a.recno,a.dt,a.totrecamt,b.name,b.address1,b.gstnumber,b.mobile,c.name as paymode,a.narration,a.rtype from ( " +
                                                          "  (select id,recno,convert(nvarchar(10),recdate,103)as dt,pmode,party,totrecamt,narration,rtype from Payment_Entry where id=" + Convert.ToInt32( txtbillno.Tag) + ")as a left join " +
                                                          "  (select id,name,address1,gstnumber,mobile from Ledger_Master)as b on a.party=b.id left join (select id,name from tblPaymentMode)as c on a.pmode=c.id )");



            if (dsReport.Tables[0].Rows.Count > 0)
            {
                this.Cursor = Cursors.Default;
             
                rptPaymentEntry rptPaymentEntry = new rptPaymentEntry();
                rptPaymentEntry.SetDataSource(dsReport.Tables[0]);

                string rline = File.ReadAllText(Application.StartupPath + "//printer.txt");

                rptPaymentEntry.PrintOptions.PrinterName = rline;
                rptPaymentEntry.PrintToPrinter(1, true, 0, 0);


                rptPaymentEntry.Close();
                rptPaymentEntry.Dispose();
                dsReport.Dispose();
                dsReport.Tables.Clear();
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("There are no print available.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dsReport.Dispose();
                dsReport.Tables.Clear();
                return;
            }
           
         
            txtbillno.Tag = "";
            this.Cursor = Cursors.Default;
        }

        private void txtRecAmt_TextChanged(object sender, System.EventArgs e)
        {
            //if (rcheck == 1) { return; }
            //double amt1 = 0; double amt2 = 0;
            //if(txtBillAmount.Text!="")
            //{
            //    amt1 = Convert.ToDouble(txtBillAmount.Text);
            //}
            //if(txtRecAmt.Text!="")
            //{
            //    amt2 = Convert.ToDouble(txtRecAmt.Text);
            //}
            //txtDueAmt.Text = Math.Round((amt1 - amt2),0).ToString();
        }

        private void btnOpen_Click(object sender, System.EventArgs e)
        {
            groupPanel3.Show();
            //dtfromdate.Enabled = false;
            //dttodate.Enabled = false;
           
            txtinvsearch.Focus();
            FillGrid();
        }
        public void FillGrid()
        {

            try
            {

                //dgvSearchGrid.Rows.Clear();
                string rstr = "";
                if(Form1.UserID==1)
                {
                    rstr = " where payment_entry.rtype='Payment' and Payment_Entry.companyid=1 and Payment_Entry.RecDate >=  '" + dtfromdate.Value.Date.ToString("yyyy-MM-dd") + "' and Payment_Entry.RecDate<=  '" + dttodate.Value.Date.ToString("yyyy-MM-dd") + "' ";
                }
                else
                {
                    rstr = " where payment_entry.rtype='Payment' and Payment_Entry.companyid=" + companyid + " and Payment_Entry.RecDate >=  '" + dtfromdate.Value.Date.ToString("yyyy-MM-dd") + "' and Payment_Entry.RecDate<=  '" + dttodate.Value.Date.ToString("yyyy-MM-dd") + "' ";
                }
                    if (txtinvsearch.Text != "")
                    {
                        rstr = rstr + " and Payment_Entry.RecNo=" + Convert.ToInt32(txtinvsearch.Text);
                    }
                    if (Convert.ToInt32(cmbPartySearch.SelectedValue)!=0)
                    {
                        rstr = rstr + " and Payment_Entry.party=" + Convert.ToInt32(cmbPartySearch.SelectedValue);
                    }
                //if(Convert.ToInt16(cmAll.SelectedIndex)!=0)
                //{
                //    rstr=rstr+" and payment_entry.rtype='"+ cmAll.Text +"' ";
                //}
                    DataSet ds = new DataSet();
                    ds = da.dataset_ret("select Payment_Entry.id,recno as [Voucher No.],convert(nvarchar(10),recdate,103)as [Date],led.name as [Party Name],tblpaymentmode.name as [Pay Mode],totrecamt as [Paid Amount],rtype as [Entry Mode] from Payment_Entry inner join Ledger_Master as led on Payment_Entry.Party=led.id inner join tblPaymentMode on Payment_Entry.pmode=tblPaymentMode.id " + rstr + " order by Payment_Entry.id asc");
             


                dgvSearchGrid.DataSource = ds.Tables[0];
                dgvSearchGrid.Columns["id"].Visible = false;
             
                double rTotal = 0;
                int intl = 0;
                for (intl = 0; intl <= ds.Tables[0].Rows.Count - 1; intl++)
                {
                    dgvSearchGrid.Rows[intl].HeaderCell.Value = Convert.ToString(intl + 1);
                    rTotal = rTotal + Convert.ToDouble(ds.Tables[0].Rows[intl]["Paid Amount"].ToString());
                    // DataGridViewRow row = dgvSearchGrid.Rows[intl];
                    // row.Height = 40;

                }
                txtGridTotal.Text = rTotal.ToString();

            }
            catch { }
        }
        private void dtfromdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dttodate.Focus();
            }
        }

        private void dttodate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtinvsearch.Focus();
            }
        }

        private void txtinvsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
                { e.Handled = true; }
                if (e.KeyChar == (char)13)
                {
                    cmbPartySearch.Focus();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void cmbPartySearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               btnsearch.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cmbPartySearch.SelectedValue = 0;
                cmbPartySearch.SelectAll();
            }
        }

        private void btnclosedgv_Click(object sender, System.EventArgs e)
        {
            groupPanel3.Hide();
        }

        private void chkdate_Click(object sender, System.EventArgs e)
        {
            if(chkdate.Checked==true)
            {
                dtfromdate.Enabled = true;
                dttodate.Enabled = true;
            }
            else
            {
                dtfromdate.Enabled = false;
                dttodate.Enabled = false;
                dtfromdate.Value = DateTime.Now.Date;
                dttodate.Value = DateTime.Now.Date;
            }
        }

        private void btnsearch_Click(object sender, System.EventArgs e)
        {
            FillGrid();
        }
        public static DataSet dsReport = new DataSet();
        private void dgvSearchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dgvSearchGrid.Rows[e.RowIndex].ReadOnly = true;
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                rcheck = 1;
                //Display(Convert.ToInt32(dgvSearchGrid.CurrentRow.Cells["id"].Value));
                database_admin da1 = new database_admin();
                DataSet ds11=new DataSet();
                ds11 = da1.dataset_ret("select * from Payment_Entry where id=" + dgvSearchGrid.CurrentRow.Cells["id"].Value);
                BlankField();

                txtbillno.Text = ds11.Tables[0].Rows[0]["recno"].ToString();
                txtbillno.Tag = ds11.Tables[0].Rows[0]["id"].ToString();
                string rdt = ds11.Tables[0].Rows[0]["recdate"].ToString();
                dtinvoice.Text = rdt.Substring(0, 2) + '/' + rdt.Substring(3, 2) + '/' + rdt.Substring(6, 4);
              
                cmbseries.SelectedValue = ds11.Tables[0].Rows[0]["pmode"].ToString();
                txtNarration.Text = ds11.Tables[0].Rows[0]["narration"].ToString();
                txtRecAmt.Text = ds11.Tables[0].Rows[0]["totrecamt"].ToString();
                int party =Convert.ToInt32( ds11.Tables[0].Rows[0]["party"].ToString());
                cmbparty.SelectedValue = party;
                btnSave.Text = "Update && &Print";
                btnSave_Print.Text = "&Update";
                if(ds11.Tables[0].Rows[0]["rtype"].ToString()=="Receipt")
                {
                    optReceipt.Checked = true;
                }
                else
                {
                    optPayment.Checked = true;
                }
                ds11.Dispose();
                ds11.Tables.Clear();
                DataSet rsTemp = new DataSet();
                rsTemp = da.dataset_ret("select mobile from ledger_master where id=" + Convert.ToInt32(cmbparty.SelectedValue));
                if (rsTemp.Tables[0].Rows.Count > 0)
                {
                    txtMobile.Text = rsTemp.Tables[0].Rows[0]["mobile"].ToString();
                }
                rsTemp.Dispose(); rsTemp.Clear();
                dtinvoice.Focus();
                rcheck = 0;
                    groupPanel3.Visible = false;
            }
            else if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Are you sure want to delete this record?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                da.insert_update_delete("delete from Payment_Entry where id=" + dgvSearchGrid.CurrentRow.Cells["id"].Value);
                   FillGrid();
                
              
            }
            else if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                this.Cursor = Cursors.WaitCursor;
                dsReport = da.dataset_ret("select '"+ MainIndex.CompanyName +"' as comname, a.recno,a.dt,a.totrecamt,b.name,b.address1,b.gstnumber,b.mobile,c.name as paymode,a.narration,a.rtype from ( " +
                                                          "  (select id,recno,convert(nvarchar(10),recdate,103)as dt,pmode,party,totrecamt,narration,rtype from Payment_Entry where id=" + dgvSearchGrid.CurrentRow.Cells["id"].Value + ")as a left join " +
                                                          "  (select id,name,address1,gstnumber,mobile from Ledger_Master)as b on a.party=b.id left join (select id,name from tblPaymentMode)as c on a.pmode=c.id )");



            if (dsReport.Tables[0].Rows.Count > 0)
            {
                this.Cursor = Cursors.Default;
                frmCrystalReport.ReportName = "PaymentReport";
                frmCrystalReport obj_report = new frmCrystalReport();
                obj_report.ShowDialog();
                //rptPaymentEntry rptPaymentEntry = new rptPaymentEntry();
                //rptPaymentEntry.SetDataSource(dsReport.Tables[0]);

                //string rline = File.ReadAllText(Application.StartupPath + "//printer.txt");

                //rptPaymentEntry.PrintOptions.PrinterName = rline;
                //rptPaymentEntry.PrintToPrinter(1, true, 0, 0);


                //rptPaymentEntry.Close();
                //rptPaymentEntry.Dispose();
                dsReport.Dispose();
                dsReport.Tables.Clear();
            } 
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("There are no print available.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dsReport.Dispose();
                dsReport.Tables.Clear();
                return;
            }
            }
            else if (e.ColumnIndex > 3 && e.RowIndex >= 0)
            {
                dgvSearchGrid.Rows[e.RowIndex].ReadOnly = true;
            }
            else
            {
                dgvSearchGrid.Rows[e.RowIndex].ReadOnly = false;
            }
        }

        private void cmbPartySearch_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbPartySearch.Text.Trim() == "" || Convert.ToInt32(cmbPartySearch.SelectedIndex) == -1)
            {
                MessageBox.Show("Please select valid name.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbPartySearch.Focus();
                e.Cancel = true;
                return;
            }
        }

        private void btnExcel_Click(object sender, System.EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "PaymentDetailExported";

                int cc = 0; int i = 0; int j = 0;
                for (cc = 5; (cc <= (dgvSearchGrid.ColumnCount - 1)); cc++)
                {
                    worksheet.Cells[1, (cc - 4)] = dgvSearchGrid.Columns[cc].HeaderText;
                    worksheet.Cells[1, (cc - 4)].Font.Bold = true;
                }
                for (i = 1; (i <= dgvSearchGrid.RowCount); i++)
                {
                    // worksheet.Cells(i + 1, 1) = dbGrid1.Rows(i - 1).Cells(i).Value
                    for (j = 5; (j <= (dgvSearchGrid.Columns.Count - 1)); j++)
                    {
                        worksheet.Cells[(i + 1), (j - 4)] = dgvSearchGrid.Rows[(i - 1)].Cells[j].Value;
                    }

                }
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FilterIndex = 1;
                worksheet.Range["A1:I1"].EntireColumn.AutoFit();
                if ((saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK))
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successfully.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch
            {

            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
                //releaseObject(excel);
                //releaseObject(workbook);
                //releaseObject(excel);
            }

        }

        private void cmbparty_TextChanged(object sender, EventArgs e)
        {
            if (rcheck == 1) { return; }
            lblBal.Text = "";
            if (Convert.ToInt32(cmbparty.SelectedValue) != 0)
            {
                GETBalance(Convert.ToInt32(cmbparty.SelectedValue));
                DataSet rsTemp = new DataSet();
                rsTemp = da.dataset_ret("select mobile from ledger_master where id=" + Convert.ToInt32(cmbparty.SelectedValue));
                if (rsTemp.Tables[0].Rows.Count > 0)
                {
                    txtMobile.Text = rsTemp.Tables[0].Rows[0]["mobile"].ToString();
                }
                rsTemp.Dispose(); rsTemp.Clear();
            }
        }

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtRecAmt.Focus();
            }
        }

        private void txtMobile_Validating(object sender, CancelEventArgs e)
        {
            if(txtMobile.Text.Trim()!="")
            {
                DataSet rsTemp = new DataSet();
                  rsTemp = da.dataset_ret("select id from ledger_master where mobile='" +txtMobile.Text+"' ");
                if(rsTemp.Tables[0].Rows.Count>0)
                {
                   
                    cmbparty.SelectedValue=Convert.ToInt32(rsTemp.Tables[0].Rows[0]["id"].ToString());
                  
                }
                rsTemp.Dispose(); rsTemp.Clear();
            }
        }

        private void btnProductPlus_Click(object sender, EventArgs e)
        {
            //Form1.formCheck = 2;
            ComboBox rC = new ComboBox();
            rC.Text = txtMobile.Text;
            frmledger fl = new frmledger(this.cmbparty, rC);
            fl.ShowDialog();
            cmbparty.Focus();
            //Form1.formCheck = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rstr = "";

            rstr = " where payment_entry.rtype='Payment' and Payment_Entry.companyid=" + companyid + " and Payment_Entry.RecDate >=  '" + dtfromdate.Value.Date.ToString("yyyy-MM-dd") + "' and Payment_Entry.RecDate<=  '" + dttodate.Value.Date.ToString("yyyy-MM-dd") + "' ";

            
            if (Convert.ToInt32(cmbPartySearch.SelectedValue) != 0)
            {
                rstr = rstr + " and Payment_Entry.party=" + Convert.ToInt32(cmbPartySearch.SelectedValue);
            }
            this.Cursor = Cursors.WaitCursor;
            string rtext = " Payment Summary From Date : " + dtfromdate.Value.ToString("dd/MM/yyyy") + " To Date : " + dttodate.Value.ToString("dd/MM/yyyy");

            dsReport = da.dataset_ret("select '" + MainIndex.CompanyName + "' as comname,'"+rtext+"' as rtext, ledger_master.name,sum(totrecamt) as amt from payment_entry inner join ledger_master on payment_entry.party=ledger_master.id " + rstr+" group by ledger_master.name order by ledger_master.name");

            if (dsReport.Tables[0].Rows.Count > 0)
            {
                this.Cursor = Cursors.Default;
                frmCrystalReport.ReportName = "PaymentSummary";
                frmCrystalReport obj_report = new frmCrystalReport();
                obj_report.ShowDialog();
                dsReport.Dispose();
                dsReport.Tables.Clear();
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("There are no print available.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dsReport.Dispose();
                dsReport.Tables.Clear();
                return;
            }
        }

       

        
        
        }
    }


