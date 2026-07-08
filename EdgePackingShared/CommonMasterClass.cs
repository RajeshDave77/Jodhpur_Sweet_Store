using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EdgePackingShared
{
    public class CommonMasterClass
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public String Remark { get; set; }
        public Int32 CompanyID { get; set; }
        public Decimal RatePercent { get; set; }
        public DataSet SaleBill_Print(int ID)
        {

            DataSet ds = new DataSet();
            string[] Session_MilK_Var = new string[] { "@ID"};
            object[] Session_MilK_Par = new Object[] { ID };
            ds = DataConnection.GetSqlDataSetO("[Sale_Report_Printing]", Session_MilK_Var, Session_MilK_Par, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Member_Milk_Search_DailyReport_Print(int ID, int CompanyID)
        {

            DataSet ds = new DataSet();
            string[] Session_MilK_Var = new string[] { "@ID", "@CompanyID" };
            object[] Session_MilK_Par = new Object[] { ID, CompanyID };
            ds = DataConnection.GetSqlDataSetO("[KotPrint]", Session_MilK_Var, Session_MilK_Par, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Member_Milk_Search_DailyReport_Print(int ID, string Paymode, int CompanyID)
        {

            DataSet ds = new DataSet();
            string[] Session_MilK_Var = new string[] { "@ID", "@Paymode", "@CompanyID" };
            object[] Session_MilK_Par = new Object[] { ID, Paymode, CompanyID };
            ds = DataConnection.GetSqlDataSetO("[KotPrint]", Session_MilK_Var, Session_MilK_Par, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Member_Milk_Search_DailyReport_Print_All(int ID, string Paymode, int CompanyID,string startdate,string enddate,int billtag)
        {

            DataSet ds = new DataSet();
            string[] Session_MilK_Var = new string[] { "@ID", "@Paymode", "@CompanyID","startdate","enddate","billtag" };
            object[] Session_MilK_Par = new Object[] { ID, Paymode, CompanyID, startdate,enddate,billtag };
            ds = DataConnection.GetSqlDataSetO("[KotPrint]", Session_MilK_Var, Session_MilK_Par, DataConnection.sConnstr);
            return ds;
        }
        public bool CommonMaster_InsertUpdate(int id, string name ,string tablename,int companyid)
        {
            ID = id;
            Name = name;
            
       
      
            string[] CommonMaster_Var = new string[] { "@TableName", "@ID", "@Name" ,"@companyid"};
            object[] CommonMaster_Obj = new object[] { tablename, ID, Name,companyid };
            bool flag = DataConnection.RunQueryO("InsertUpdate_Common_Master", CommonMaster_Var, CommonMaster_Obj, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public bool CommonMaster_Delete(int id, string tablename)
        {
            ID = id;
            string[] CommonMaster_Var = new string[] { "@TableName", "@ID" };
            object[] CommonMaster_Obj = new object[] { tablename, ID };
            bool flag = DataConnection.RunQueryO("delete_Common_Master", CommonMaster_Var, CommonMaster_Obj, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public DataSet CommonMaster_GetData(string tablename)
        {
            DataSet ds = new DataSet();
            string[] List_Var = new string[] { "@TableName" };
            string[] List_Obj = new string[] { tablename };
            ds = DataConnection.GetSqlDataSet("retrive_Common_Master", List_Var, List_Obj, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Tax_Report_Print(string datefrom,string dateto,int companyid,string comname,string paymode)
        {

            DataSet ds = new DataSet();
            string[] Session_MilK_Var = new string[] { "@CompanyID" ,"@datefrom","@dateto","@Companyname","@paymode"};
            object[] Session_MilK_Par = new Object[] { companyid,datefrom,dateto,comname,paymode };
            ds = DataConnection.GetSqlDataSetO("[TaxReport]", Session_MilK_Var, Session_MilK_Par, DataConnection.sConnstr);
            return ds;
        }
    }
}
