using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EdgePackingShared
{
    public class reportparam
    {
        public static DateTime Date1 { get; set; }
        public static DateTime Date2 { get; set; }
        public static Int32 MemID { get; set; }
        public static Int32 SessionID1 { get; set; }
        public static Int32 SessionID2 { get; set; }
        public static Int32 RouteID { get; set; }
        private static string fileNames;
        public  string OrderNo { get; set; }

        public static string FileName
        {
            get { return fileNames; }
            set { fileNames = value; }
        }
        public DataSet Ledger_Report()
        {
            DataSet ds = new DataSet();
            string[] var = null;
            object[] par = null;
            ds = DataConnection.GetSqlDataSetO("LedgerMaster_Retrive",var,par,DataConnection.sConnstr);
            return ds;
        }
        public DataSet Item_Report()
        {
            DataSet ds = new DataSet();
            string[] var = null;
            object[] par = null;
            ds = DataConnection.GetSqlDataSetO("InventoryMaster_Retrive", var, par, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Route_Report(string tablename)
        {
            DataSet ds = new DataSet();
          
            string[] var = new string[] { "TableName" };
            object[] per = new object[] { tablename  };
            ds = DataConnection.GetSqlDataSetO( "retrive_All_Master", var,  per, DataConnection.sConnstr);
            return ds;
        }

        public DataSet Bill_Master_Report(string typename)
        {
            DataSet ds = new DataSet();

            string[] var = new string[] { "typename", "Date1", "Date2", "Memid", "CompanyID" };
            object[] per = new object[] { typename , reportparam.Date1 , reportparam.Date2 , reportparam.MemID , CompanyMasterClass.CompanyID  };
            ds = DataConnection.GetSqlDataSetO("BillMaster_Report", var, per, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Bill_d_Master_Report(string typename)
        {
            DataSet ds = new DataSet();

            string[] var = new string[] { "typename", "Date1", "Date2", "Memid", "CompanyID" };
            object[] per = new object[] { typename, reportparam.Date1, reportparam.Date2, reportparam.MemID, CompanyMasterClass.CompanyID };
            ds = DataConnection.GetSqlDataSetO("Bill_D_Master_Report", var, per, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Milk_p_Report(string tbname)
        {
            DataSet ds = new DataSet();

            string[] var = new string[] { "@TableName", "Date1", "Date2" , "Memid" };
            object[] per = new object[] { tbname, reportparam.Date1,reportparam.Date2,reportparam.MemID  };
            ds = DataConnection.GetSqlDataSetO("Milk_Proc_by_data_member", var, per, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Inv_stock_Report()
        {
            DataSet ds = new DataSet();

            string[] var = new string[] {  "Date1", "Date2"  };
            object[] per = new object[] { reportparam.Date1, reportparam.Date2 };
            ds = DataConnection.GetSqlDataSetO("Inventory_stock_by_Date", var, per, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Milk_Receipt_Print(int id)
        {
            DataSet ds = new DataSet();

            string[] var = new string[] { "@ID" };
            object[] per = new object[] { id };
            ds = DataConnection.GetSqlDataSetO("Milk_Procurment_PrintByID", var, per, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Member_Milk_Ledger_Report()
        {
            DataSet ds = new DataSet();

            string[] var = new string[] {  "Date1", "Date2", "Memid" };
            object[] per = new object[] { reportparam.Date1, reportparam.Date2, reportparam.MemID };
            ds = DataConnection.GetSqlDataSetO("Member_Milk_Ledger_new", var, per, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Milk_stk_Report()
        {
            DataSet ds = new DataSet();

            string[] var = new string[] {"Date1", "Date2", "Milk_id" };
            object[] per = new object[] { reportparam.Date1 , reportparam.Date2 , reportparam.MemID   };
            ds = DataConnection.GetSqlDataSetO("Milk_Stock_Between_date", var, per, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Milk_Rate_Report()
        {
            DataSet ds = new DataSet();

            string[] var = new string[] { "Date1" };
            object[] per = new object[] { reportparam.Date1 };
            ds = DataConnection.GetSqlDataSetO("RateMaster_Report", var, per, DataConnection.sConnstr);
            return ds;
        }
    }
}
