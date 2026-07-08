using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EdgePackingShared
{
    class InvoiceClass
    {
        public string Name { get; set; }

        public Int32 ID { get; set; }
        public Int32 InvoiceNO { get; set; }
        public String BillNo { get; set; }
        public Int32 ChallanNo { get; set; }

        public String PoNo { get; set; }
        public DateTime PoDate { get; set; }
        public String VAT { get; set; }

        public String Cartrage { get; set; }
        public String Others { get; set; }
        public String NetAmount { get; set; }

        public string Notification { get; set; }
        public string SubHeadingNo { get; set; }
       
        public DateTime ChallanDate { get; set; }
        public DateTime InvoiceDate { get; set; }




        public bool Invoice_InsertUpdate(int invoiceno, string billno, int challanno,string pono, DateTime podate, string vat,string cartrage,string others, string notification,string subheadingno,DateTime challandate,DateTime invoicedate,int cid,string PartyName,decimal NetAmount,string Dis_Party,string OtherText)
        {
            //  ID = id;
            InvoiceNO = invoiceno;
            BillNo = billno;
            ChallanNo = challanno;
            PoNo = pono;
            PoDate = podate;
            VAT = vat;
            Cartrage = cartrage;
            Others = others;
            Notification = notification;
            SubHeadingNo = subheadingno;
            ChallanDate = challandate;
            InvoiceDate = invoicedate;

            string[] Rate_Par = new string[] { "@InvoiceNo", "@BillNo", "@ChallanNo", "@PoNo", "@PoDate", "@VAT", "@Cartrage", "@Others", "@Notification", "@SubHeadingNo", "@ChallanDate", "@InvoiceDate", "cid", "@PartyName", "@NetAmount", "@Dis_Party", "@OtherText" };
            object[] Rate_Val = new object[] { invoiceno, billno, challanno, pono, podate, vat, cartrage, others, notification, subheadingno, ChallanDate, invoicedate, cid, PartyName, NetAmount, Dis_Party, OtherText };
            bool flag = DataConnection.RunQueryO("Invoice_InsertUpdate", Rate_Par, Rate_Val, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }
    public void OwnerList_GetData(string TableName, string name, ListBox lbsearch)
        {
            DataSet ds = new DataSet();
            string[] List_Var = new string[] { "@TableName", "@Name" };
            string[] List_Obj = new string[] { TableName, name };
            ds = DataConnection.GetSqlDataSet("retrive_All_Master", List_Var, List_Obj, DataConnection.sConnstr);
            lbsearch.DataSource = ds.Tables[0];
            lbsearch.DisplayMember = "Name";
            //     lbsearch.ValueMember = "ID";

        }
        public void ChallanList_GetData(string TableName, string name, ListBox lbsearch)
        {
DataSet ds = new DataSet();
            string[] List_Var = new string[] { "@TableName", "@Name" };
            string[] List_Obj = new string[] { TableName,name };
            ds = DataConnection.GetSqlDataSet("retrive_All_Master", List_Var, List_Obj, DataConnection.sConnstr);
            lbsearch.DataSource = ds.Tables[0];
            lbsearch.DisplayMember = "ChallanNo";
            //     lbsearch.ValueMember = "ID";

        }
        public DataSet Member_Milk_Search_DailyReport_Print(int ID, string Print)
        {

            DataSet ds = new DataSet();
            string[] Session_MilK_Var = new string[] { "@ID","@Print" };
            object[] Session_MilK_Par = new Object[] {ID,Print};
            ds = DataConnection.GetSqlDataSetO("ChallanPrint", Session_MilK_Var, Session_MilK_Par, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Invoice_Member_Milk_Search_DailyReport_Print(int ID,string Print)
        {

            DataSet ds = new DataSet();
            string[] Session_MilK_Var = new string[] { "@ID","@Print" };
            object[] Session_MilK_Par = new Object[] { ID ,Print};
            ds = DataConnection.GetSqlDataSetO("InvoiceReport", Session_MilK_Var, Session_MilK_Par, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Roll_Member_Milk_Search_DailyReport_Print(int InvoiceNo,string Print)
        {

            DataSet ds = new DataSet();
            string[] Session_MilK_Var = new string[] { "@InvoiceNo","@Print" };
            object[] Session_MilK_Par = new Object[] { InvoiceNo ,Print};
            ds = DataConnection.GetSqlDataSetO("InvoiceForRollReport", Session_MilK_Var, Session_MilK_Par, DataConnection.sConnstr);
            return ds;
        }
    }
}
