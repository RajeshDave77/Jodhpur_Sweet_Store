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
using System.Data.SqlClient;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
namespace EdgePackaging
{
     
    public partial class frmDayEnd : Form
    {
        database_admin da = new database_admin();
        int rcheck = 1;
        public frmDayEnd()
        {
            InitializeComponent();
            da.fill_combo("select id,(name+' - '+com_location)as name from Company_Master order by id", cmbcompany, "ID", "Name");
            if(Convert.ToInt32(Form1.UserID)!=1)
            {
                cmbcompany.SelectedValue = Form1.CompanyID;
                cmbcompany.Enabled = false;
            }
            rcheck = 0;
            ShowNew();
          
            dtFromDate.Focus();
        }
        private void ShowNew()
        {
            this.Cursor = Cursors.WaitCursor;
            string rstring = "";
            DataSet ds = new DataSet();


            ds = da.dataset_ret("select '" + cmbcompany.Text + "' as rcompany,'" + rstring + "' as rtext, aa.rrtag,aa.rtag,aa.paymode,format(isnull(aa.amt,0),'N', 'en-in') as amt from (select 1 as rrtag,' - ' as rtag,paymode,sum(netamount) as amt from sale where (kotdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and kotdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "') and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " and billno=0 group by paymode " +
                                                          "  union all select 2 as rrtag, ' -' as rtag,'Total' as paymode,sum(netamount) as amt from sale where (kotdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and kotdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "') and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " and billno=0 ) as aa order by aa.rrtag ");

            int intLoop = 0; double ramt = 0;
            dbGridPayMode.Rows.Clear();
            dbGridPayMode.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 13.75F, FontStyle.Bold);
            for (intLoop = 0; intLoop < ds.Tables[0].Rows.Count; intLoop++)
            {
                dbGridPayMode.Rows.Add();
                dbGridPayMode.Rows[intLoop].Cells[0].Value = ds.Tables[0].Rows[intLoop]["paymode"].ToString() + " : ";
                dbGridPayMode.Rows[intLoop].Cells[1].Value = ds.Tables[0].Rows[intLoop]["amt"].ToString();
              
            }
            dbGridPayMode.ClearSelection();
        
            ds.Dispose(); ds.Clear();

            ds = da.dataset_ret("select '" + cmbcompany.Text + "' as rcompany,'" + rstring + "' as rtext, aa.rrtag,aa.rtag,aa.paymode,format(isnull(aa.amt,0),'N', 'en-in') as amt from (select 3 as rrtag,'Bill' as rtag,paymode,sum(netamount) as amt from sale where (billdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and billdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "') and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " and kotno=0 group by paymode " +
                                                        "   union all select 4 as rrtag,'Bill Total' as rtag,'Total' as paymode,sum(netamount) as amt from sale where (billdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and billdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "') and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " and kotno=0  ) as aa order by aa.rrtag ");

           intLoop = 0; 
            dbGridPayModeBill.Rows.Clear();
            dbGridPayModeBill.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 13.75F, FontStyle.Bold);
            for (intLoop = 0; intLoop < ds.Tables[0].Rows.Count; intLoop++)
            {
                dbGridPayModeBill.Rows.Add();
                dbGridPayModeBill.Rows[intLoop].Cells[0].Value = ds.Tables[0].Rows[intLoop]["paymode"].ToString() + " : ";
                dbGridPayModeBill.Rows[intLoop].Cells[1].Value = ds.Tables[0].Rows[intLoop]["amt"].ToString();
             
            }
            dbGridPayModeBill.ClearSelection();
           
            ds.Dispose(); ds.Clear();

            ds = da.dataset_ret("select '" + cmbcompany.Text + "' as rcompany,'" + rstring + "' as rtext, aa.rrtag,aa.rtag,aa.paymode,format(isnull(aa.amt,0),'N', 'en-in') as amt from (select 5 as rrtag,'Total' as rtag,paymode,sum(netamount) as amt from sale where ((billdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and billdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "') or (kotdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and kotdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "')) and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " group by paymode union all select 5 as rrtag,'Total' as rtag,'Total' as paymode,sum(netamount) as amt from sale where ((billdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and billdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "') or (kotdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and kotdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "')) and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) as aa order by aa.rrtag,aa.paymode ");

           intLoop = 0; 
            dbGridPayModeTotal.Rows.Clear();
            dbGridPayModeTotal.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 13.75F, FontStyle.Bold);
            for (intLoop = 0; intLoop < ds.Tables[0].Rows.Count; intLoop++)
            {
                dbGridPayModeTotal.Rows.Add();
                dbGridPayModeTotal.Rows[intLoop].Cells[0].Value = ds.Tables[0].Rows[intLoop]["paymode"].ToString() + " : ";
                dbGridPayModeTotal.Rows[intLoop].Cells[1].Value = ds.Tables[0].Rows[intLoop]["amt"].ToString();
                if (Convert.ToInt16(ds.Tables[0].Rows[intLoop]["rrtag"].ToString()) == 5)
                {
                    ramt += Convert.ToDouble(ds.Tables[0].Rows[intLoop]["amt"].ToString());
                }
            }
            dbGridPayModeTotal.ClearSelection();
         
            ds.Dispose(); ds.Clear();
            this.Cursor = Cursors.Default;
        }
        private void Show()
        {
            this.Cursor = Cursors.WaitCursor;
            string rstring = "";
         // rstring = " and ((billdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and billdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "') or (kotdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and kotdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "'))";
         //   rstring = rstring + " and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue);
            rstring = "Collection Summary From " + dtFromDate.Value.ToString("dd/MM/yyyy") + "  To " + dtToDate.Value.ToString("dd/MM/yyyy");
            // DataSet ds = new DataSet();
            string companyname = cmbcompany.Text;

            // CommonMasterClass com = new CommonMasterClass();
            //   dsReport = com.Tax_Report_Print(dtFromDate.Value.Date.ToString("yyyy-MM-dd"), dtToDate.Value.Date.ToString("yyyy-MM-dd"),Convert .ToInt32( cmbcompany.SelectedValue),cmbcompany.Text);

            dsReport = da.dataset_ret("select '" +cmbcompany.Text+"' as rcompany,'" +rstring+"' as rtext, aa.rrtag,aa.rtag,aa.paymode,isnull(aa.amt,0) as amt from (select 1 as rrtag,'.' as rtag,paymode,sum(netamount) as amt from sale where (kotdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and kotdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "') and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) +" and billno=0 group by paymode " +
                                                          "  union all select 2 as rrtag, '.' as rtag,'Total' as paymode,sum(netamount) as amt from sale where (kotdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and kotdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "') and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " and billno=0 " +
                                                         "   union all select 3 as rrtag,'Bill' as rtag,paymode,sum(netamount) as amt from sale where (billdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and billdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "') and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " and kotno=0 group by paymode " +
                                                         "   union all select 4 as rrtag,'Bill' as rtag,'Total' as paymode,sum(netamount) as amt from sale where (billdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and billdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "') and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " and kotno=0  " +
                                                         "   union all select 5 as rrtag,'Total Of Day' as rtag,paymode,sum(netamount) as amt from sale where ((billdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and billdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "') or (kotdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and kotdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "')) and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " group by paymode union all select 5 as rrtag,'Total Of Day' as rtag,'Total' as paymode,sum(netamount) as amt from sale where ((billdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and billdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "') or (kotdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and kotdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "')) and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) as aa order by aa.rrtag,aa.paymode ");

          
                this.Cursor = Cursors.Default;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void cmbcompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                btnPreview.Focus();
            }
        }
        public static DataSet dsReport=new DataSet();
        private void btnPreview_Click(object sender, EventArgs e)
        {

            Show();
            if (dsReport.Tables[0].Rows.Count > 0)
            {
                //frmCrystalReport.ReportName = "CollectionReport";
                //frmCrystalReport obj_report = new frmCrystalReport();
                //obj_report.ShowDialog();

                rptCollection rptCollection = new rptCollection();
                rptCollection.SetDataSource(dsReport.Tables[0]);
                string rline = File.ReadAllText(Application.StartupPath + "//printer.txt");

                rptCollection.PrintOptions.PrinterName = rline;
                rptCollection.PrintToPrinter(1, true, 0, 0);

            } 
            else
            {
                MessageBox.Show("There are no daily collection report available.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dsReport.Dispose();
                dsReport.Tables.Clear();
                return;
            }
            dsReport.Dispose(); dsReport.Clear();
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

    

       

      

       

        private void frmDayEnd_Load(object sender, EventArgs e)
        {
        }

        private void dbGridPayMode_CellClick(object sender, DataGridViewCellEventArgs e)
        {
              if (e.RowIndex == -1)
          {
              return;
          }
        }

        private void btnDayEnd_Click(object sender, EventArgs e)
        {
            try
            {
                string rdate = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
                string rdate2 = DateTime.Now.ToString("dd/MM/yyyy");
                string rdate1 = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

                if (MessageBox.Show("Are you sure want to Day End of Dated: " + rdate2 + "?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }

                DataSet dsnew = new DataSet();
                Cursor.Current = Cursors.WaitCursor;
                //******************query for get stock of current date of every product

                dsnew = da.dataset_ret("select * from sale where   paymode=' Unsetteled' ");
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Some kot payment mode is not setteled. So you cannot Day End." + Environment.NewLine + "Please try again after set payment mode.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dsnew.Dispose(); dsnew.Clear();
                da.insert_update_delete("insert into productstock(productid,qty,rate,stdate,companyid,stdate1) select aa.product,sum(aa.qty) as qty,0,'" + rdate + "'," + Form1.CompanyID + ",'" + rdate1 + "' from( select product,sum(qty) as qty from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                "  where invoicedate1='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(Form1.CompanyID) + " or party=" + Convert.ToInt32(Form1.CompanyID) + ")  and StockType in ('Purchase','Stock Inward','Production') group by product " +
                                "  union all select product,(sum(qty)*-1) as qty from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                               "   where invoicedate1='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Dispatch Challan','Shop Transfer','Consumed','Damages') group by product " +
                                "  union all select productid as product,(sum(qty)*-1) as qty from sale inner join SaleDetail on sale.id=saleid where " +
                                "  kotdate1='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and BillNo=0 group by ProductId " +
                                "  union all select productid as product,(sum(qty)*-1) as qty from sale inner join SaleDetail on sale.id=saleid where " +
                                "  billdate1='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and kotNo=0 and importtag=0 group by ProductId) as aa group by aa.product");

                dsnew.Dispose(); dsnew.Clear();
                // query for get id's those bill has not be created yet and want to delete when day end
                dsnew = da.dataset_ret("SELECT STUFF((SELECT ',' + cast(id  as nvarchar(500)) FROM sale where billno=0 and companyid=" + Form1.CompanyID + " FOR XML PATH('')) ,1,1,'' ) AS ids");
                if (string.IsNullOrEmpty(dsnew.Tables[0].Rows[0]["ids"].ToString()) == false)
                {

                    // insert kot records into productstock table for stock counting
                    // delete query for both sale master and child tables
                    da.insert_update_delete("delete from sale where id in (" + dsnew.Tables[0].Rows[0]["ids"].ToString() + ") and companyid=" + Form1.CompanyID);
                    da.insert_update_delete("delete from saledetail where saleid in (" + dsnew.Tables[0].Rows[0]["ids"].ToString() + ")");

                }
                //else
                //{
                //    Cursor.Current = Cursors.Default;
                //    MessageBox.Show("There are no stock available for Day End.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                da.insert_update_delete("update setting set dayenddate='" + rdate2 + "' where id=1");
                //***************************************************************************************************
                SqlCommand objCMD = new SqlCommand();
                int intLoop = 0;
                string DBFile = File.ReadAllText(Application.StartupPath + "/DataConnection1.txt");
                SqlConnection rCon1 = new SqlConnection(DBFile);
                rCon1.Open();
                DataSet rsTemp = new DataSet();
                objCMD.Connection = rCon1;

                //*******************************export data from sale master and sale child table and insert into online database***************************************
                rsTemp = da.dataset_ret("select * from sale where    billno<>0 and companyid=" + Form1.CompanyID + " and importtag=0 order by id");

                string rStrSale = ""; string rStrSaleID = "";
                int intl = 0;
                for (intLoop = 0; intLoop < rsTemp.Tables[0].Rows.Count; intLoop++)
                {
                    intl += 1;
                    if (rStrSale == "")
                    {
                        if (rStrSaleID=="")
                        {
                            rStrSaleID = rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        }
                        rStrSale = "('" + rsTemp.Tables[0].Rows[intLoop]["PayMode"].ToString() + "'," + rsTemp.Tables[0].Rows[intLoop]["KotNo"].ToString() + ",'" + (rsTemp.Tables[0].Rows[intLoop]["KotDate"].ToString()) + "'," + (rsTemp.Tables[0].Rows[intLoop]["BillNo"].ToString()) + ",'" + (rsTemp.Tables[0].Rows[intLoop]["billDate"].ToString()) + "'," + (rsTemp.Tables[0].Rows[intLoop]["PartyId"].ToString()) + "," + (rsTemp.Tables[0].Rows[intLoop]["companyid"].ToString()) + ",'" + (rsTemp.Tables[0].Rows[intLoop]["mobile"].ToString()) + "'," + (rsTemp.Tables[0].Rows[intLoop]["netamount"].ToString()) + "," + (rsTemp.Tables[0].Rows[intLoop]["userid"].ToString()) + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["partyname"].ToString()) + "','" + (rsTemp.Tables[0].Rows[intLoop]["finyear"].ToString()) + "','" + (rsTemp.Tables[0].Rows[intLoop]["billtime"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Partyaddress"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Partygstin"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Partystate"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["username"].ToString()) + "',1," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ")";
                    }
                    else
                    {
                        rStrSaleID = rStrSaleID + "," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        rStrSale = rStrSale + ",('" + rsTemp.Tables[0].Rows[intLoop]["PayMode"].ToString() + "'," + rsTemp.Tables[0].Rows[intLoop]["KotNo"].ToString() + ",'" + (rsTemp.Tables[0].Rows[intLoop]["KotDate"].ToString()) + "'," + (rsTemp.Tables[0].Rows[intLoop]["BillNo"].ToString()) + ",'" + (rsTemp.Tables[0].Rows[intLoop]["billDate"].ToString()) + "'," + (rsTemp.Tables[0].Rows[intLoop]["PartyId"].ToString()) + "," + (rsTemp.Tables[0].Rows[intLoop]["companyid"].ToString()) + ",'" + (rsTemp.Tables[0].Rows[intLoop]["mobile"].ToString()) + "'," + (rsTemp.Tables[0].Rows[intLoop]["netamount"].ToString()) + "," + (rsTemp.Tables[0].Rows[intLoop]["userid"].ToString()) + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["partyname"].ToString()) + "','" + (rsTemp.Tables[0].Rows[intLoop]["finyear"].ToString()) + "','" + (rsTemp.Tables[0].Rows[intLoop]["billtime"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Partyaddress"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Partygstin"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Partystate"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["username"].ToString()) + "',1," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ")";
                    }
                    if (intl == 999)
                    {
                        if (rStrSale != "")
                        {

                            //objCMD.CommandType = CommandType.Text;
                            //objCMD.CommandText = "delete saledetail from saledetail inner join sale on sale.id=saledetail.saleid where comid=" + Form1.CompanyID + " and companyid=" + Form1.CompanyID + " and orgid in (" + rStrSaleID + ")";
                            //objCMD.ExecuteNonQuery();

                            //objCMD.CommandType = CommandType.Text;
                            //objCMD.CommandText = "delete from sale where companyid=" + Form1.CompanyID + " and orgid in (" + rStrSaleID + ")";
                            //objCMD.ExecuteNonQuery();

                            objCMD.CommandType = CommandType.Text;
                            objCMD.CommandText = "insert into sale(PayMode,KotNo,KotDate,BillNo,BillDate,PartyId,CompanyId,Mobile,NetAmount,UserId,partyname,FinYear,BillTime,PartyAddress,PartyGstin,PartyState,Username,Importtag,OrgID) values " + rStrSale;
                            objCMD.ExecuteNonQuery();


                            intl = 0;
                            rStrSale = "";

                        }
                    }
                   
                }

                if (rStrSale != "")
                {

                    //objCMD.CommandType = CommandType.Text;
                    //objCMD.CommandText = "delete saledetail from saledetail inner join sale on sale.id=saledetail.saleid where comid=" + Form1.CompanyID + " and companyid=" + Form1.CompanyID + " and orgid in (" + rStrSaleID + ")";
                    //objCMD.ExecuteNonQuery();

                    //objCMD.CommandType = CommandType.Text;
                    //objCMD.CommandText = "delete from sale where companyid=" + Form1.CompanyID + " and orgid in (" + rStrSaleID + ")";
                    //objCMD.ExecuteNonQuery();

                    objCMD.CommandType = CommandType.Text;
                    objCMD.CommandText = "insert into sale(PayMode,KotNo,KotDate,BillNo,BillDate,PartyId,CompanyId,Mobile,NetAmount,UserId,partyname,FinYear,BillTime,PartyAddress,PartyGstin,PartyState,Username,Importtag,OrgID) values " + rStrSale;
                    objCMD.ExecuteNonQuery();
                }
                if(rStrSaleID!="")
                {
                    objCMD.CommandType = CommandType.Text;
                    objCMD.CommandText = "update sale set billdate1= substring(BillDate,7,4) + '-' + substring(BillDate,4,2)+'-'+substring(BillDate,1,2) where billdate1 is null and companyid=" + Form1.CompanyID + " and orgid in (" + rStrSaleID + ")";
                    objCMD.ExecuteNonQuery();

                    da.insert_update_delete("update sale set  importtag=1 where  id in (" + rStrSaleID + ")");
                }
                intl = 0;
                rsTemp.Dispose(); rsTemp.Clear();
                if (rStrSaleID != "")
                {
                    rsTemp = da.dataset_ret("select * from saledetail where saleid in (" + rStrSaleID + ") order by saleid,id");

                    string rStrChallanDetail = "";
                    for (intLoop = 0; intLoop < rsTemp.Tables[0].Rows.Count; intLoop++)
                    {
                        intl += 1;
                        if (rStrChallanDetail == "")
                        {
                            rStrChallanDetail = "(" + rsTemp.Tables[0].Rows[intLoop]["productid"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["qty"].ToString() + ",'" + rsTemp.Tables[0].Rows[intLoop]["barcode"].ToString() + "'," + rsTemp.Tables[0].Rows[intLoop]["Rate"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Amount"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["netAmt"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["saleid"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["taxrate"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["productname"].ToString()) + "','" + rsTemp.Tables[0].Rows[intLoop]["hsncode"].ToString() + "'," + rsTemp.Tables[0].Rows[intLoop]["cess"].ToString() + "," + Form1.CompanyID + "," + rsTemp.Tables[0].Rows[intLoop]["disper"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["disamt"].ToString() + ")";
                        }
                        else
                        {
                            rStrChallanDetail = rStrChallanDetail + ",(" + rsTemp.Tables[0].Rows[intLoop]["productid"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["qty"].ToString() + ",'" + rsTemp.Tables[0].Rows[intLoop]["barcode"].ToString() + "'," + rsTemp.Tables[0].Rows[intLoop]["Rate"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Amount"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["netAmt"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["saleid"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["taxrate"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["productname"].ToString()) + "','" + rsTemp.Tables[0].Rows[intLoop]["hsncode"].ToString() + "'," + rsTemp.Tables[0].Rows[intLoop]["cess"].ToString() + "," + Form1.CompanyID + "," + rsTemp.Tables[0].Rows[intLoop]["disper"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["disamt"].ToString() + ")";
                        }
                        if (intl == 999)
                        {
                            if (rStrChallanDetail != "")
                            {
                                objCMD.CommandType = CommandType.Text;
                                objCMD.CommandText = " insert into saledetail(ProductId,Qty,Barcode,rate,amount,Netamt,SaleId,taxrate,Productname,hsncode,cess,comid,disper,disamt) values " + rStrChallanDetail;
                                objCMD.ExecuteNonQuery();
                                intl = 0;

                                rStrChallanDetail = "";
                            }
                        }
                       
                    }
                    if (rStrChallanDetail != "")
                    {
                        objCMD.CommandType = CommandType.Text;
                        objCMD.CommandText = " insert into saledetail(ProductId,Qty,Barcode,rate,amount,Netamt,SaleId,taxrate,Productname,hsncode,cess,comid,disper,disamt) values " + rStrChallanDetail;
                        objCMD.ExecuteNonQuery();
                    }
                    if(rStrSaleID!="")
                    {
                        objCMD.CommandType = CommandType.Text;
                        objCMD.CommandText = "update saledetail set saleid=sale.id  from saledetail inner join sale on sale.orgid=saledetail.saleid where comid=" + Form1.CompanyID + " and companyid=" + Form1.CompanyID + "  and orgid in (" + rStrSaleID + ")";
                        objCMD.ExecuteNonQuery();

                    }
                    intl = 0;
                    rsTemp.Dispose(); rsTemp.Clear();
                }

                //****************************************************************************************************************************************
                rCon1.Close();
                //***************************************************************************************************
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Day End completed successfully.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void oldDayEnd()
        {
            try
            {
                string rdate = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
                string rdate2 = DateTime.Now.ToString("dd/MM/yyyy");
                string rdate1 = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

                if (MessageBox.Show("Are you sure want to Day End of Dated: " + rdate2 + "?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                if (MessageBox.Show("Once you will use day end option all entries will be closed for this date." + Environment.NewLine + " Are you sure want to Day End of Dated: " + rdate2 + "?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }

                DataSet dsnew = new DataSet();
                Cursor.Current = Cursors.WaitCursor;
                //******************query for get stock of current date of every product
                dsnew = da.dataset_ret("select * from productstock where companyid=" + Form1.CompanyID + " and stdate1='" + rdate1 + "' ");
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Day End has been already done. Please try again for other day.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dsnew.Dispose(); dsnew.Clear();
                dsnew = da.dataset_ret("select * from sale where paymode=' Unsetteled' ");
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Some kot payment mode is not setteled. So you cannot Day End." + Environment.NewLine + "Please try again after set payment mode.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dsnew.Dispose(); dsnew.Clear();
                da.insert_update_delete("insert into productstock(productid,qty,rate,stdate,companyid,stdate1) select aa.product,sum(aa.qty) as qty,0,'" + rdate + "'," + Form1.CompanyID + ",'" + rdate1 + "' from( select product,sum(qty) as qty from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                "  where invoicedate1='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(Form1.CompanyID) + " or party=" + Convert.ToInt32(Form1.CompanyID) + ")  and StockType in ('Purchase','Stock Inward','Production') group by product " +
                                "  union all select product,(sum(qty)*-1) as qty from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                               "   where invoicedate1='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Dispatch Challan','Shop Transfer','Consumed','Damages') group by product " +
                                "  union all select productid as product,(sum(qty)*-1) as qty from sale inner join SaleDetail on sale.id=saleid where " +
                                "  kotdate1='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and BillNo=0 group by ProductId " +
                                "  union all select productid as product,(sum(qty)*-1) as qty from sale inner join SaleDetail on sale.id=saleid where " +
                                "  billdate1='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and kotNo=0 group by ProductId) as aa group by aa.product");

                dsnew.Dispose(); dsnew.Clear();
                // query for get id's those bill has not be created yet and want to delete when day end
                dsnew = da.dataset_ret("SELECT STUFF((SELECT ',' + cast(id  as nvarchar(500)) FROM sale where billno=0 and companyid=" + Form1.CompanyID + " FOR XML PATH('')) ,1,1,'' ) AS ids");
                if (string.IsNullOrEmpty(dsnew.Tables[0].Rows[0]["ids"].ToString()) == false)
                {

                    // insert kot records into productstock table for stock counting
                    // delete query for both sale master and child tables
                    da.insert_update_delete("delete from sale where id in (" + dsnew.Tables[0].Rows[0]["ids"].ToString() + ") and companyid=" + Form1.CompanyID);
                    da.insert_update_delete("delete from saledetail where saleid in (" + dsnew.Tables[0].Rows[0]["ids"].ToString() + ")");

                }
                //else
                //{
                //    Cursor.Current = Cursors.Default;
                //    MessageBox.Show("There are no stock available for Day End.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                da.insert_update_delete("update setting set dayenddate='" + rdate2 + "' where id=1");
                //***************************************************************************************************
                SqlCommand objCMD = new SqlCommand();
                int intLoop = 0;
                string DBFile = File.ReadAllText(Application.StartupPath + "/DataConnection1.txt");
                SqlConnection rCon1 = new SqlConnection(DBFile);
                rCon1.Open();
                DataSet rsTemp = new DataSet();
                objCMD.Connection = rCon1;

                //*******************************export data from sale master and sale child table and insert into online database***************************************
                rsTemp = da.dataset_ret("select * from sale where billdate1='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and billno<>0 and companyid=" + Form1.CompanyID + " and importtag=0 order by id");

                string rStrSale = ""; string rStrSaleID = "";
                for (intLoop = 0; intLoop < rsTemp.Tables[0].Rows.Count; intLoop++)
                {
                    if (rStrSale == "")
                    {
                        rStrSaleID = rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        rStrSale = "('" + rsTemp.Tables[0].Rows[intLoop]["PayMode"].ToString() + "'," + rsTemp.Tables[0].Rows[intLoop]["KotNo"].ToString() + ",'" + (rsTemp.Tables[0].Rows[intLoop]["KotDate"].ToString()) + "'," + (rsTemp.Tables[0].Rows[intLoop]["BillNo"].ToString()) + ",'" + (rsTemp.Tables[0].Rows[intLoop]["billDate"].ToString()) + "'," + (rsTemp.Tables[0].Rows[intLoop]["PartyId"].ToString()) + "," + (rsTemp.Tables[0].Rows[intLoop]["companyid"].ToString()) + ",'" + (rsTemp.Tables[0].Rows[intLoop]["mobile"].ToString()) + "'," + (rsTemp.Tables[0].Rows[intLoop]["netamount"].ToString()) + "," + (rsTemp.Tables[0].Rows[intLoop]["userid"].ToString()) + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["partyname"].ToString()) + "','" + (rsTemp.Tables[0].Rows[intLoop]["finyear"].ToString()) + "','" + (rsTemp.Tables[0].Rows[intLoop]["billtime"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Partyaddress"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Partygstin"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Partystate"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["username"].ToString()) + "',1," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ")";
                    }
                    else
                    {
                        rStrSaleID = rStrSaleID + "," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        rStrSale = rStrSale + ",('" + rsTemp.Tables[0].Rows[intLoop]["PayMode"].ToString() + "'," + rsTemp.Tables[0].Rows[intLoop]["KotNo"].ToString() + ",'" + (rsTemp.Tables[0].Rows[intLoop]["KotDate"].ToString()) + "'," + (rsTemp.Tables[0].Rows[intLoop]["BillNo"].ToString()) + ",'" + (rsTemp.Tables[0].Rows[intLoop]["billDate"].ToString()) + "'," + (rsTemp.Tables[0].Rows[intLoop]["PartyId"].ToString()) + "," + (rsTemp.Tables[0].Rows[intLoop]["companyid"].ToString()) + ",'" + (rsTemp.Tables[0].Rows[intLoop]["mobile"].ToString()) + "'," + (rsTemp.Tables[0].Rows[intLoop]["netamount"].ToString()) + "," + (rsTemp.Tables[0].Rows[intLoop]["userid"].ToString()) + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["partyname"].ToString()) + "','" + (rsTemp.Tables[0].Rows[intLoop]["finyear"].ToString()) + "','" + (rsTemp.Tables[0].Rows[intLoop]["billtime"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Partyaddress"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Partygstin"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Partystate"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["username"].ToString()) + "',1," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ")";
                    }
                }

                if (rStrSale != "")
                {

                    objCMD.CommandType = CommandType.Text;
                    objCMD.CommandText = "delete saledetail from saledetail inner join sale on sale.id=saledetail.saleid where comid=" + Form1.CompanyID + " and companyid=" + Form1.CompanyID + " and orgid in (" + rStrSaleID + ")";
                    objCMD.ExecuteNonQuery();

                    objCMD.CommandType = CommandType.Text;
                    objCMD.CommandText = "delete from sale where companyid=" + Form1.CompanyID + " and orgid in (" + rStrSaleID + ")";
                    objCMD.ExecuteNonQuery();

                    objCMD.CommandType = CommandType.Text;
                    objCMD.CommandText = "insert into sale(PayMode,KotNo,KotDate,BillNo,BillDate,PartyId,CompanyId,Mobile,NetAmount,UserId,partyname,FinYear,BillTime,PartyAddress,PartyGstin,PartyState,Username,Importtag,OrgID) values " + rStrSale;
                    objCMD.ExecuteNonQuery();

                    objCMD.CommandType = CommandType.Text;
                    objCMD.CommandText = "update sale set billdate1= substring(BillDate,7,4) + '-' + substring(BillDate,4,2)+'-'+substring(BillDate,1,2) where billdate1 is null and companyid=" + Form1.CompanyID + " and orgid in (" + rStrSaleID + ")";
                    objCMD.ExecuteNonQuery();

                    da.insert_update_delete("update sale set  importtag=1 where  id in (" + rStrSaleID + ")");
                }
                rsTemp.Dispose(); rsTemp.Clear();
                if (rStrSaleID != "")
                {
                    rsTemp = da.dataset_ret("select * from saledetail where saleid in (" + rStrSaleID + ") order by saleid,id");

                    string rStrChallanDetail = "";
                    for (intLoop = 0; intLoop < rsTemp.Tables[0].Rows.Count; intLoop++)
                    {
                        if (rStrChallanDetail == "")
                        {
                            rStrChallanDetail = "(" + rsTemp.Tables[0].Rows[intLoop]["productid"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["qty"].ToString() + ",'" + rsTemp.Tables[0].Rows[intLoop]["barcode"].ToString() + "'," + rsTemp.Tables[0].Rows[intLoop]["Rate"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Amount"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["netAmt"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["saleid"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["taxrate"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["productname"].ToString()) + "','" + rsTemp.Tables[0].Rows[intLoop]["hsncode"].ToString() + "'," + rsTemp.Tables[0].Rows[intLoop]["cess"].ToString() + "," + Form1.CompanyID + "," + rsTemp.Tables[0].Rows[intLoop]["disper"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["disamt"].ToString() + ")";
                        }
                        else
                        {
                            rStrChallanDetail = rStrChallanDetail + ",(" + rsTemp.Tables[0].Rows[intLoop]["productid"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["qty"].ToString() + ",'" + rsTemp.Tables[0].Rows[intLoop]["barcode"].ToString() + "'," + rsTemp.Tables[0].Rows[intLoop]["Rate"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Amount"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["netAmt"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["saleid"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["taxrate"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["productname"].ToString()) + "','" + rsTemp.Tables[0].Rows[intLoop]["hsncode"].ToString() + "'," + rsTemp.Tables[0].Rows[intLoop]["cess"].ToString() + "," + Form1.CompanyID + "," + rsTemp.Tables[0].Rows[intLoop]["disper"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["disamt"].ToString() + ")";
                        }
                    }
                    if (rStrChallanDetail != "")
                    {
                        objCMD.CommandType = CommandType.Text;
                        objCMD.CommandText = " insert into saledetail(ProductId,Qty,Barcode,rate,amount,Netamt,SaleId,taxrate,Productname,hsncode,cess,comid,disper,disamt) values " + rStrChallanDetail;
                        objCMD.ExecuteNonQuery();

                        objCMD.CommandType = CommandType.Text;
                        objCMD.CommandText = "update saledetail set saleid=sale.id  from saledetail inner join sale on sale.orgid=saledetail.saleid where comid=" + Form1.CompanyID + " and companyid=" + Form1.CompanyID + "  and orgid in (" + rStrSaleID + ")";
                        objCMD.ExecuteNonQuery();

                    }
                    rsTemp.Dispose(); rsTemp.Clear();
                }

                //****************************************************************************************************************************************
                rCon1.Close();
                //***************************************************************************************************
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Day End completed successfully.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowNew();
        }

        private void dbGridPayModeBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
        }

       
    }
}
