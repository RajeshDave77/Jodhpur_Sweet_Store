
using EdgePackaging;
using EdgePackingShared;
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
using CrystalDecisions.Shared;
//using EdgePackaging.REPORT;
using EdgePackingShared;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EdgePackaging
{
    public partial class frmCrystalReport : Form
    {
        public frmCrystalReport()
        {
            InitializeComponent();
        }
        public static string ReportName = "";



        database_admin da = new database_admin();
        database_con db = new database_con();
     
        public static int id;
        public static string Print;
        
        public static string sConnstr = File.ReadAllText(Application.StartupPath + "//DataConnection.txt");

        public SqlConnection con = new SqlConnection(sConnstr);


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmCrystalReport_Load(object sender, System.EventArgs e)
        {
            if(ReportName=="Barcode")
            {
                
                DataSet dsnew = new DataSet();
                DataView dv = new DataView();
                dsnew = da.dataset_ret("select  (select name from company_master where id=companyid)as company,barcode,salerate,rproduct from barcode_print_table where companyid=" + Form1.CompanyID);
                ReportDocument rd = new ReportDocument();
                rd.Load(Application.StartupPath + "/Reports/TAG_SMALL.rpt");
                dv = dsnew.Tables[0].DefaultView;

                rd.SetDataSource(dv);
                crystalReportViewer1.ReportSource = rd;
        da.insert_update_delete("delete from barcode_print_table where companyid=" + Form1.CompanyID);
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "Barcode1")
            {

                DataSet dsnew = new DataSet();
                DataView dv = new DataView();
                dsnew = da.dataset_ret("select  (select name from company_master where id=companyid)as company,barcode,salerate,rproduct from barcode_print_table where companyid=" + Form1.CompanyID);
                ReportDocument rd = new ReportDocument();
                rd.Load(Application.StartupPath + "/Reports/TAG_SMALL_B.rpt");
                dv = dsnew.Tables[0].DefaultView;

                rd.SetDataSource(dv);
                crystalReportViewer1.ReportSource = rd;
                da.insert_update_delete("delete from barcode_print_table where companyid=" + Form1.CompanyID);
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "StockReport")
            {
                rptStockReport stockreport = new rptStockReport();
                stockreport.SetDataSource(frmStockReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = stockreport;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "SalesReport")
            {
                rptSalesReport salesreport = new rptSalesReport();
                salesreport.SetDataSource(frmSalesReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = salesreport;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "TaxReport")
            {
                rptTaxReport taxreport = new rptTaxReport();
                taxreport.SetDataSource(frmTaxReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = taxreport;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "PurchaseReport")
            {
                rptPurchaseReport purchasereport = new rptPurchaseReport();
                purchasereport.SetDataSource(frmPurchaseReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = purchasereport;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "test")
            {
                rpttest purchasereport = new rpttest();
               // purchasereport.SetDataSource(frmPurchaseReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = purchasereport;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "billprinting")
            {
                //ReportDocument rd = new ReportDocument();
                //rd.Load(Application.StartupPath + "/Reports/REP_BILL.rpt");

                REP_BILL repbill = new REP_BILL();

                repbill.SetDataSource(frmAllBillPrint.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = repbill;
                crystalReportViewer1.Refresh();
                //  rd.PrintToPrinter(1, true, 0, 0);
            }
            else if (ReportName == "HSNReport")
            {
                DataSet dsnew = new DataSet();
                rptHSNReport hsnreport = new rptHSNReport();
                hsnreport.SetDataSource(frmHSNReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = hsnreport;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "StockReportSubGroup")
            {
                rptStockReportSubGroup rptStockReportSubGroup = new rptStockReportSubGroup();
                rptStockReportSubGroup.SetDataSource(frmStockReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = rptStockReportSubGroup;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "Challan")
            {
                rptChallan rptChallan = new rptChallan();
                rptChallan.SetDataSource(PurchaseInvoice.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = rptChallan;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "CollectionReport")
            {
                rptCollection rptCollection = new rptCollection();
                rptCollection.SetDataSource(frmDayEnd.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = rptCollection;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "NewBillPrint")
            {
                rptSaleBill_Printed rptSaleBill_Printed = new rptSaleBill_Printed();
                rptSaleBill_Printed.SetDataSource(frmAllBillPrint.dsReport.Tables[0]);
                rptSaleBill_Printed.Subreports["subreport1"].SetDataSource(frmAllBillPrint.dsReport1.Tables[0]);
                crystalReportViewer1.ReportSource = rptSaleBill_Printed;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "TaxReportBill")
            {
                rptTaxReportBill rptTaxReportBill = new rptTaxReportBill();
                rptTaxReportBill.SetDataSource(frmTaxReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = rptTaxReportBill;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "MinStockReport")
            {
                rptMinStockReport rptMinStockReport = new rptMinStockReport();
                rptMinStockReport.SetDataSource(frmMinStockReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = rptMinStockReport;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "PaymentReport")
            {
                rptPaymentEntry rptPaymentEntry = new rptPaymentEntry();
                rptPaymentEntry.SetDataSource(frmPayment1.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = rptPaymentEntry;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "StockReportEx")
            {
                rptStockReportEx rptStockReportEx = new rptStockReportEx();
                rptStockReportEx.SetDataSource(frmStockReportEx.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = rptStockReportEx;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "PaymentSummary")
            {
                rptPaymentSummary rptPaymentSummary = new rptPaymentSummary();
                rptPaymentSummary.SetDataSource(frmPayment1.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = rptPaymentSummary;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "DemandReport")
            {
                rptDemandReport rptDemandReport = new rptDemandReport();
                rptDemandReport.SetDataSource(frmDemandReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = rptDemandReport;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "BinReport")
            {
                rptBinCard rptBinCard = new rptBinCard();
                rptBinCard.SetDataSource(frmBinReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = rptBinCard;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "StockReportProduct")
            {
                rptStockReportProduct stockreport = new rptStockReportProduct();
                stockreport.SetDataSource(frmStockReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = stockreport;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "Challan1")
            {
                rptChallan rptChallan = new rptChallan();
                rptChallan.SetDataSource(PurchaseInvoice1.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = rptChallan;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "StockReport1")
            {
                rptStockReport1 stockreport = new rptStockReport1();
                stockreport.SetDataSource(frmStockReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = stockreport;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "StockReportProduct1")
            {
                rptStockReportProduct1 stockreport = new rptStockReportProduct1();
                stockreport.SetDataSource(frmStockReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = stockreport;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "StockReportEx1")
            {
                rptStockReportEx1 rptStockReportEx = new rptStockReportEx1();
                rptStockReportEx.SetDataSource(frmStockReportEx.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = rptStockReportEx;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "StockReportProductBoth")
            {
                rptStockReportProductBoth stockreport = new rptStockReportProductBoth();
                stockreport.SetDataSource(frmStockReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = stockreport;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "StockReportBoth")
            {
                rptStockReportBoth stockreport = new rptStockReportBoth();
                stockreport.SetDataSource(frmStockReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = stockreport;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "IssueReport")
            {
                rptIssueReport rptIssueReport = new rptIssueReport();
                rptIssueReport.SetDataSource(frmPurchaseReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = rptIssueReport;
                crystalReportViewer1.Refresh();
            }
            else if (ReportName == "IssueReport1")
            {
                rptIssueReport1 rptIssueReport1 = new rptIssueReport1();
                rptIssueReport1.SetDataSource(frmPurchaseReport.dsReport.Tables[0]);
                crystalReportViewer1.ReportSource = rptIssueReport1;
                crystalReportViewer1.Refresh();
            }
        }
    }
}