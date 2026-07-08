using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EdgePackingShared
{
    public class LedgerMasterClass
    {
        public Int32 ID { get; set; }
        public String Name {get;set;}
        public String NameInHindi { get; set; }
        public String Code {get;set;}
        public String Village {get;set;}
        public Int32 VillageID { get; set; }
        public String District { get; set; }
        public Int32 DistrictID { get; set; }
        public String State { get; set; }
        public Int32 StateID { get; set; }
        public Int32 AccountHead_ID {get;set;}
        public Int32 CompanyID {get;set;}
        public Int32 Route_Id {get;set;}
        public String Mobile {get;set;}
        public byte[] Photo {get;set;}
        public String Email {get;set;}
        public String Website {get;set;}
        public String PANNumber {get;set;}
        public String TINNumber {get;set;}
        public String GSTNumber {get;set;}
        public String BankName {get;set;}
        public String BranchName {get;set;}
        public String BankAccountNumber {get;set;}
        public String AccountName { get; set; }
        public String IFSC {get;set;}
        public String OP_Dr_Cr {get;set;}
        public Decimal OpeningBalance {get;set;}
        public Decimal Overhead_Per { get; set; }

        public bool Ledger_InsertUpdate(int id, string name, string state, int stateid,  int companyID,string mobileno, string gstNumber, string type ,string dob,string doa ,string add1,string add2,int userid )
        {
            ID=id;
            Name=name;
        State = state;
            StateID = stateid;
           CompanyID=companyID;
           GSTNumber=gstNumber;
           string[] Company_Par = new string[] { "ID", "@Name", "@State", "@StateID", "@CompanyID", "@Mobile", "@GSTNumber", "@type", "@dob", "@doa", "@add1", "@add2","@userid" };
           object[] Company_Val = new object[] { ID, Name, State, StateID, CompanyID, mobileno, GSTNumber, type, dob, doa, add1, add2,userid };
            bool flag = DataConnection.RunQueryO("LedgerMaster_InsertUpdate", Company_Par, Company_Val, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public DataSet Ledger_GetData()
        {
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSet("LedgerMaster_Retrive", null, null, DataConnection.sConnstr);
            return ds;
        }

        public bool Ledger_Delete(int id)
        {
            ID = id;
            string[] Ledger_Var = new string[] { "@ID" };
            object[] Ledger_Obj = new object[] { ID };
            bool flag = DataConnection.RunQueryO("LedgerMaster_Delete", Ledger_Var, Ledger_Obj, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }
        public DataSet SearchList_GetData(string TableName)
        {
            DataSet ds = new DataSet();
            string[] List_Var = new string[] { "@TableName"};
            string[] List_Obj = new string[] { TableName};
            ds = DataConnection.GetSqlDataSet("retrive_All_Master", List_Var, List_Obj, DataConnection.sConnstr);
            return ds;

        }
        public DataSet LedgerMaster_GetData(int ID, DateTime Fromdate, DateTime Todate)
        {
            string[] var = new string[] { "@ID", "@Fromdate", "@Todate" };
            object[] par = new object[] { ID, Fromdate, Todate };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("Ledger_Report", var, par, DataConnection.sConnstr);
            return ds;
        }
        public DataSet LedgerPrint_byID_Date(int ID, DateTime Fromdate, DateTime Todate)
        {

            DataSet ds = new DataSet();
            string[] Session_MilK_Var = new string[] { "@ID", "@Fromdate", "@Todate" };
            object[] Session_MilK_Par = new Object[] { ID, Fromdate, Todate };
            ds = DataConnection.GetSqlDataSetO("Ledger_Report", Session_MilK_Var, Session_MilK_Par, DataConnection.sConnstr);
            return ds;
        }
        public DataSet ShopMaster_GetData(string rtag)
        {
            string[] var = new string[] { "@rtag" };
            object[] par = new object[] { rtag };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("ShopMaster_Retrive", var, par, DataConnection.sConnstr);
            return ds;
        }
    }
}
