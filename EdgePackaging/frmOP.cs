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
    public partial class frmOP : Form
    {
        public frmOP()
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
                    billno = Convert.ToInt32(da.value1("select isnull(max(RecNo),0) as BillNo from opening_Balance "));
                     txtbillno.Text = Convert.ToString(billno + 1);
                }
                catch
                {
                    billno = 0;
                }
              
                
            }

        private void frmOP_Load(object sender, System.EventArgs e)
        {
            rcheck = 1;
            SetBillNo();

            if (Form1.utype != 0)
            {
                dgvSearchGrid.Columns[1].Visible = false;
                dgvSearchGrid.Columns[2].Visible = false;
            }
          
               rcheck = 0;
        }

   

 



  

        private void dtinvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtRecAmt.Focus();
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
                txtAmt2.Focus();
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
            SetBillNo();
          
            txtNarration.Text = "";

            txtAmt2.Text = "";
            txtAmt3.Text = "";
         
            txtRecAmt.Text = "";
            rcheck = 0;
          
           
            btnSave_Print.Text = "&Save";
            dtinvoice.Focus();
           
        }

     

  

        private void btnSave_Print_Click(object sender, System.EventArgs e)
        {
            //if(txtRecAmt.Text=="")
            //{
            //    MessageBox.Show("Please specify amount.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtRecAmt.Focus();
            //    return;
            //}
            double amt1 = 0; double amt2 = 0; double amt3 = 0;
            if(txtRecAmt.Text!="")
            {
                amt1 = Convert.ToDouble(txtRecAmt.Text);
            }
            if (txtAmt2.Text != "")
            {
                amt2 = Convert.ToDouble(txtAmt2.Text);
            }
            if (txtAmt3.Text != "")
            {
                amt3 = Convert.ToDouble(txtAmt3.Text);
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
            else
            {
                DataSet ds = new DataSet();
                ds = da.dataset_ret("select id,recno  from opening_balance where companyid=" + companyid + " and opening_balance.RecDate =  '" + dtinvoice.Value.Date.ToString("yyyy-MM-dd") + "'");
                if(ds.Tables[0].Rows.Count!=0)
                {
                    id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                    recid = id;
                    txtbillno.Text = ds.Tables[0].Rows[0]["recno"].ToString();
                }
            }
              Receipt_InsertUpdate(id, Convert.ToInt32(txtbillno.Text),txtNarration.Text,amt1,Form1.UserID,companyid,amt2,amt3);
               
            if (btnSave_Print.Text != "&Update")//for Update 
                {
                    recid = Convert.ToInt32(da.value1("select max(ID) from opening_balance where companyid=" + companyid + " and recno=" + Convert.ToInt32(txtbillno.Text)));
                    txtbillno.Tag = recid;
                }
            da.insert_update_delete("update opening_balance set recdate='" + dtinvoice.Value.ToString("yyyy-MM-dd") + "' where id=" + recid);
           
             
                try
                {
                    //string sms = "";
                    //string rdate1 = dtinvoice.Value.Date.ToString("dd/MM/yyyy");
                    //sms = "Dear " + cmbparty.Text + ", thank you for your payment of Rs. " + txtTotRecAmt.Text + " against Rec. No.: " + txtbillno.Text + " Dated: " + rdate1 + " received at Sanjay Studio.";
                   
                    //if (chkSMS.Checked == true)
                    //{
                    //    DataSet dd=new DataSet();
                    //    dd = da.dataset_ret("select mobile from ledger_master where id=" + Convert.ToInt32(cmbparty.SelectedValue));
                    //    if(dd.Tables[0].Rows[0]["mobile"].ToString()!="")
                    //    {
                    //        sendSMS(dd.Tables[0].Rows[0]["mobile"].ToString(), sms);
                    //    }
                       
                    //}
                }
                catch
                {
                    MessageBox.Show("Data not saved");
                }
                BlankField();

        }
        public bool Receipt_InsertUpdate(int ID, int RecNo,string Narration,double TotRecAmt, int UserId,int companyid,double amt2,double amt3)
        {
            bool flag = false;
            string[] Inventory_Par = new string[] { "@ID", "@RecNo",  "@Narration",  "@TotRecAmt", "@UserId" ,"companyid","@amt2","@amt3"};
            object[] Inventory_Val = new object[] { ID, RecNo,  Narration, TotRecAmt,  UserId,companyid ,amt2,amt3};
          
                flag = DataConnection.RunQueryO("OPB_InsertUpdate", Inventory_Par, Inventory_Val, DataConnection.sConnstr);
      

            if (flag)
                return true;
            else
                return false;
        }
     

        private void sendSMS(string toNumber, string sms)
        {
            System.Net.WebClient web = new System.Net.WebClient();
            string MSGSTR;
            MSGSTR = "http://msg.media-craft.in/app/smsapi/index.php?key=45BAA1AF5BCE01&routeid=6&type=text&contacts=" + toNumber + "&senderid=WEBPRO&msg=" + sms;

            web.DownloadDataAsync(new Uri(MSGSTR, UriKind.Absolute));
        }
   

        private void txtRecAmt_TextChanged(object sender, System.EventArgs e)
        {
           
        }

        private void btnOpen_Click(object sender, System.EventArgs e)
        {
            groupPanel3.Show();
            //dtfromdate.Enabled = false;
            //dttodate.Enabled = false;
           
           
            FillGrid();
        }
        public void FillGrid()
        {

            try
            {

                //dgvSearchGrid.Rows.Clear();
                string rstr = "";
                if(Form1.UserID!=1)
                {
                    rstr = " where opening_balance.companyid=" + companyid + " and opening_balance.RecDate >=  '" + dtfromdate.Value.Date.ToString("yyyy-MM-dd") + "' and opening_balance.RecDate<=  '" + dttodate.Value.Date.ToString("yyyy-MM-dd") + "' ";
                }
                else
                {
                    rstr = " where  opening_balance.RecDate >=  '" + dtfromdate.Value.Date.ToString("yyyy-MM-dd") + "' and opening_balance.RecDate<=  '" + dttodate.Value.Date.ToString("yyyy-MM-dd") + "' ";

                }
              
                    DataSet ds = new DataSet();
                    ds = da.dataset_ret("select opening_balance.id,recno as [Voucher No.],convert(nvarchar(10),recdate,103)as [Date],totrecamt as [Cash Amount],amt2 as [COD Amount],amt3 as [UPI Amount] from opening_balance " + rstr + " order by opening_balance.id asc");
             


                dgvSearchGrid.DataSource = ds.Tables[0];
                dgvSearchGrid.Columns["id"].Visible = false;

                double rTotal = 0; double rTotal1 = 0; double rTotal2 = 0;
                int intl = 0;
                for (intl = 0; intl <= ds.Tables[0].Rows.Count - 1; intl++)
                {
                    dgvSearchGrid.Rows[intl].HeaderCell.Value = Convert.ToString(intl + 1);
                    rTotal = rTotal + Convert.ToDouble(ds.Tables[0].Rows[intl]["Cash Amount"].ToString());
                    rTotal1 = rTotal1 + Convert.ToDouble(ds.Tables[0].Rows[intl]["COD Amount"].ToString());
                    rTotal2 = rTotal2 + Convert.ToDouble(ds.Tables[0].Rows[intl]["UPI Amount"].ToString());
                    // DataGridViewRow row = dgvSearchGrid.Rows[intl];
                    // row.Height = 40;

                }
                txtGridTotal.Text = rTotal.ToString();
                txtGridTotal1.Text = rTotal1.ToString();
                txtGridTotal2.Text = rTotal2.ToString();
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
                btnsearch.Focus();
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
                //Display(Convert.ToInt32(dgvSearchGrid.CurrentRow.Cells["id"].Value));
                database_admin da1 = new database_admin();
                DataSet ds11=new DataSet();
                ds11 = da1.dataset_ret("select * from opening_balance where id=" + dgvSearchGrid.CurrentRow.Cells["id"].Value);
                BlankField();

                txtbillno.Text = ds11.Tables[0].Rows[0]["recno"].ToString();
                txtbillno.Tag = ds11.Tables[0].Rows[0]["id"].ToString();
                string rdt = ds11.Tables[0].Rows[0]["recdate"].ToString();
                dtinvoice.Text = rdt.Substring(0, 2) + '/' + rdt.Substring(3, 2) + '/' + rdt.Substring(6, 4);
              
             
                txtNarration.Text = ds11.Tables[0].Rows[0]["narration"].ToString();
                txtRecAmt.Text = ds11.Tables[0].Rows[0]["totrecamt"].ToString();
                txtAmt2.Text = ds11.Tables[0].Rows[0]["amt2"].ToString();
                txtAmt3.Text = ds11.Tables[0].Rows[0]["amt3"].ToString();
               
                btnSave_Print.Text = "&Update";
                ds11.Dispose();
                ds11.Tables.Clear();
                rcheck = 1;
                dtinvoice.Focus();
                rcheck = 0;
                    groupPanel3.Visible = false;
            }
            else if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Are you sure want to delete this record?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                da.insert_update_delete("delete from opening_balance where id=" + dgvSearchGrid.CurrentRow.Cells["id"].Value);
                   FillGrid();
                
              
            }
            else if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
            //    this.Cursor = Cursors.WaitCursor;
            //    dsReport = da.dataset_ret("select a.recno,a.dt,a.totrecamt,b.name,b.address1,b.gstnumber,b.mobile,c.name as paymode from ( " +
            //                                              "  (select id,recno,convert(nvarchar(10),recdate,103)as dt,pmode,party,totrecamt from Payment_Entry where id=" + dgvSearchGrid.CurrentRow.Cells["id"].Value + ")as a left join " +
            //                                              "  (select id,name,address1,gstnumber,mobile from Ledger_Master)as b on a.party=b.id left join (select id,name from tblPaymentMode)as c on a.pmode=c.id )");

            //if (dsReport.Tables[0].Rows.Count > 0)
            //{
            //    this.Cursor = Cursors.Default;
            //    frmCrystalReport.ReportName = "PaymentReport";
            //    frmCrystalReport obj_report = new frmCrystalReport();
            //    obj_report.ShowDialog();
            //    dsReport.Dispose();
            //    dsReport.Tables.Clear();
            //} 
            //else
            //{
            //    this.Cursor = Cursors.Default;
            //    MessageBox.Show("There are no print available.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    dsReport.Dispose();
            //    dsReport.Tables.Clear();
            //    return;
            //}
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

      

        private void btnExcel_Click(object sender, System.EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "DailySaleEntryDetailExported";

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

        private void txtAmt2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAmt3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAmt2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtAmt3.Focus();
            }
        }

        private void txtAmt3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtNarration.Focus();
            }
        }

       

       

        
        
        }
    }


