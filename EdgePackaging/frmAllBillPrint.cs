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
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace EdgePackaging
{
     
    public partial class frmAllBillPrint : Form
    {
        database_admin da = new database_admin();
        int rcheck = 1;
        public frmAllBillPrint()
        {
            InitializeComponent();
            da.fill_combo("select id,(name+' - '+com_location)as name from Company_Master order by id", cmbcompany, "ID", "Name");
            if(Convert.ToInt32(Form1.UserID)!=1)
            {
                cmbcompany.SelectedValue = Form1.CompanyID;
                cmbcompany.Enabled = false;
            }
            da.fill_combo("select 0 as id,'All' as name union all select ID,Name from tblPaymentMode", cmbPayMode, "ID", "Name");
            rcheck = 0;
            dtFromDate.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void cmbcompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                cmbPayMode.Focus();
            }
        }
        public static DataSet dsReport=new DataSet();
        public static DataSet dsReport1 = new DataSet();
        CommonMasterClass com = new CommonMasterClass();
        private void btnPreview_Click(object sender, EventArgs e)
        {
           // string rstring = "";
         //  rstring= " (billdate>='" + dtFromDate.Value.Date.ToString("dd/MM/yyyy") + "' and billdate<='" + dtToDate.Value.Date.ToString("dd/MM/yyyy") + "') ";
             //   rstring =rstring+ " and s.companyid=" + Convert.ToInt32( cmbcompany.SelectedValue);
            DataSet ds = new DataSet();
            string paymode = "";
            if(Form1.CompanyID!=1 && Form1.CompanyID!=7)
            {
                if (cmbPayMode.Text == "All")
                {
                    paymode = "All";
                }
                else
                {
                    paymode = cmbPayMode.Text;
                }
                ds = com.Member_Milk_Search_DailyReport_Print_All(0, paymode, Convert.ToInt32(cmbcompany.SelectedValue), dtFromDate.Value.Date.ToString("yyyy-MM-dd"), dtToDate.Value.Date.ToString("yyyy-MM-dd"), 1);
                int rloop = 0;
                //dsReport = da.dataset_ret("select  s.Id,s.BillNo as Bill_NO,s.BillDate as DT,C.Address1,c.Address2,c.Address3,c.GSTIN as CompanyGST,s.Mobile,s.NetAmount as NET_TOTAL, " +
                //                                              "s.PartyId,s.partyname as MEM_NAME,um.Name as UserName,sd.Barcode as Code,sd.amount as Amount,im.Name as Name,sd.Qty,sd.rate as RATE,sd.taxrate as Vat_Name,s.PayMode as BTYPE,sd.taxrate as Vat_Per,im.hsn as HSN_Code, " +
                //                                              "l.GSTNumber as GST_No,((sd.amount*sd.taxrate)/100) as TaxAmount,IM.cess from Sale as s join User_Master as um on um.ID=s.UserId join SaleDetail as sd on sd.SaleId=s.Id join Inventory_Master as im on im.ID=sd.ProductId " +
                //                                              "join Ledger_Master as l on l.ID=s.PartyId left join Company_Master as C on c.ID=s.CompanyId where " + rstring + "  and s.CompanyId=" + Convert.ToInt32(cmbcompany.SelectedValue));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (rloop = 0; rloop < ds.Tables[0].Rows.Count; rloop++)
                    {
                        dsReport = com.Member_Milk_Search_DailyReport_Print(Convert.ToInt32(ds.Tables[0].Rows[rloop]["Id"].ToString()), ds.Tables[0].Rows[rloop]["BTYPE"].ToString(), Convert.ToInt32(cmbcompany.SelectedValue));
                        //frmCrystalReport.ReportName = "billprinting";
                        //frmCrystalReport obj_report = new frmCrystalReport();
                        //obj_report.ShowDialog();
                        ////ReportDocument rd = new ReportDocument();
                        ////rd.Load(Application.StartupPath + "/Reports/REP_BILL.rpt");
                        REP_BILL repbill = new REP_BILL();

                        repbill.SetDataSource(dsReport.Tables[0]);
                        repbill.PrintToPrinter(1, true, 0, 0);

                        dsReport.Dispose();
                        dsReport.Tables.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("There are no bill printing available.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsReport.Dispose();
                    dsReport.Tables.Clear();
                    return;
                } 
            
            }
            else
            {
                if(txtCount.Text=="")
                {
                    MessageBox.Show("Please specify bill no.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCount.Focus();
                    return;
                }
                ds = da.dataset_ret("select id from sale where finyear='"+Form1.CurrFinYear+"' and companyid="+Convert.ToInt32( cmbcompany.SelectedValue)+" and paymode='" +cmbPayMode.Text+"' and  billno=" + Convert.ToInt32(txtCount.Text));
                if(ds.Tables[0].Rows.Count==0)
                {
                    MessageBox.Show("Please specify valid bill no.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCount.Focus();
                    return;
                }
                int Billno = 0;
                Billno = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                dsReport = com.SaleBill_Print(Billno);
                dsReport1 = da.dataset_ret(" select saleid,isnull(taxrate,0)as taxrate,sum(amount) as netamt,isnull((select stateid from ledger_master where partyid=id),0)as state " +
                                                     ",cess from saledetail,sale where sale.id=saledetail.saleid and saleid  =" + Billno + " group by saleid,taxrate,partyid,cess");

                frmCrystalReport.ReportName = "NewBillPrint";
                frmCrystalReport obj_report = new frmCrystalReport();
                obj_report.ShowDialog();
            }
            
          
        }

        private void dtFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dtToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)13)
            {
                btnPreview.Focus();
            }
        }

        private void cmbPayMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCount.Focus();
            }
        }

       


       
    }
}
