using CrystalDecisions.CrystalReports.Engine;
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
    public partial class PrintReport : Form
    {
        
        CommonMasterClass com = new CommonMasterClass();
       
        public PrintReport()
        {
           
            InitializeComponent();
        }

        private void PrintReport_Load(object sender, EventArgs e)
        {
            try
            {
                if (MainIndex.dr == 1)
                {
                    if (true)
                    {

                        crystalReportViewer1.ReportSource = null;
                        int ID = Convert.ToInt32(SalesForm.KOT_BillNOStatic);

                        DataSet ds = new DataSet();
                        DataView dv = new DataView();
                        ds = com.Member_Milk_Search_DailyReport_Print(ID,SalesForm.companyid);
                       // ReportDocument rd = new ReportDocument();
                       // rd.Load(Application.StartupPath + "/Reports/REP_KOT.rpt");
                       // dv = ds.Tables[0].DefaultView;
                        REP_KOT repkot = new REP_KOT();
                        repkot.SetDataSource(ds.Tables[0]);
                      //  rd.SetDataSource(ds.Tables[0]);
                          
                             // rd.PrintToPrinter(1,true,0,0);
                        crystalReportViewer1.ReportSource = repkot;

                    }
                }
                else  if (MainIndex.dr == 2)
                {
                    if (true)
                    {

                        crystalReportViewer1.ReportSource = null;
                        int ID = Convert.ToInt32(SalesForm.KOT_BillNOStatic);

                        DataSet ds = new DataSet();
                        DataView dv = new DataView();
                        ds = com.Member_Milk_Search_DailyReport_Print(ID, SalesForm.PaymentMode, SalesForm.companyid);
                        //ReportDocument rd = new ReportDocument();
                        //rd.Load(Application.StartupPath + "/Reports/REP_BILL.rpt");
                        //dv = ds.Tables[0].DefaultView;

                        //rd.SetDataSource(dv);
                        //crystalReportViewer1.ReportSource = rd;
                      //  rd.SetDataSource(ds.Tables[0]);
                        REP_BILL repbill = new REP_BILL();
                        repbill.SetDataSource(ds.Tables[0]);
                        // rd.PrintToPrinter(1,true,0,0);
                        crystalReportViewer1.ReportSource = repbill;

                    }
                }
                
            }
            catch { }
        }
    }
}
