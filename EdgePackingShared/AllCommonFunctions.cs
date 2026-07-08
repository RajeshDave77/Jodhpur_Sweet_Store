using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EdgePackingShared
{
    public class AllCommonFunctions
    {
        public static int Check_Duplicacy(string tablename, string name)
        {
          string result;
                string[] per = new string[] { "@TableName", "@Name" };
                object[] val = new object[] { tablename, name };
                result = DataConnection.sqlsclaer("CheckDuplicacy_All_Master", per, val, DataConnection.sConnstr);
                int res = 0;
            try
            {
            res = Convert.ToInt32(result);
                return res;
            }
            catch { return res; }
        }
        public static int Check_Duplicacys(string tablename, string name)
        {
            string result;
            string[] per = new string[] { "@TableName", "@Name" };
            object[] val = new object[] { tablename, name };
            result = DataConnection.sqlsclaer("CheckDuplicacy_All_Master", per, val, DataConnection.sConnstr);
            int res = Convert.ToInt32(result);
            return res;
           
        }
        public static int Check_Duplicacy(string tablename, string name, string code)
        {
            string result;
            string[] per = new string[] { "@TableName", "@Name", "@CompanyID","@Code" };
            object[] val = new object[] { tablename, name, CompanyMasterClass.CompanyID, code };
            result = DataConnection.sqlsclaer("CheckDuplicacy_All_Master", per, val, DataConnection.sConnstr);
            int res = Convert.ToInt32(result);
            return res;
        }
        public static int Check_Duplicacy(string tablename, string name, int id)
        {
            string result;
            string[] per = new string[] { "@TableName", "@Name", "@CompanyID", "@ID" };
            object[] val = new object[] { tablename, name, CompanyMasterClass.CompanyID, id };
            result = DataConnection.sqlsclaer("CheckDuplicacy_All_Master", per, val, DataConnection.sConnstr);
            int res = Convert.ToInt32(result);
            return res;
        }
        public static int Check_Duplicacy( int id)
        {
            string result;
            string[] per = new string[] { "@ID" };
            object[] val = new object[] {  id };
            result = DataConnection.sqlsclaer("Ledger_Exists", per, val, DataConnection.sConnstr);
            int res = Convert.ToInt32(result);
            return res;
        }
        public static int Check_Duplicacy(string tablename, string name, Decimal PerDayCost)
        {
            string result;
            string[] per = new string[] { "@TableName", "@Name", "@CompanyID", "@PerDayCost" };
            object[] val = new object[] { tablename, name, CompanyMasterClass.CompanyID, PerDayCost };
            result = DataConnection.sqlsclaer("CheckDuplicacy_All_Master", per, val, DataConnection.sConnstr);
            int res = Convert.ToInt32(result);
            return res;
        }
        public static DataSet Company_SearchData( string name)
        {
            string[] var = new string[] { "@name" };
            string[] par = new string[] {name };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSet("Search_Company_Master", var, par, DataConnection.sConnstr);
            return ds;
        }

        public static DataSet Account_SearchData(string tablename, string name, string alias)
        {
            string[] var = new string[] { "@TableName", "@Name", "@ParentHead","@CompanyID" };
            object[] par = new object[] { tablename, name, alias,CompanyMasterClass.CompanyID };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("Search_AccountHead_Master", var, par, DataConnection.sConnstr);
            return ds;
        }

        public static int Check_Used(string tablename,int id)
        {
            string[] var = new string[] { "@TableName","@ID"};
            object[] per = new object[] { tablename,id};
            string res = DataConnection.sqlsclaer("check_used",var,per,DataConnection.sConnstr);
            int result = Convert.ToInt32(res);
            return result;
        }

        public static DataSet Route_SearchData(string tablename,string name,string incharge)
        {
            string[] var = new string[] { "@TableName", "@Name", "@Incharge", "@CompanyID" };
            object[] par = new object[] { tablename, name, incharge, CompanyMasterClass.CompanyID };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("Search_Route_Master", var, par, DataConnection.sConnstr);
            return ds;
        }

        public static DataSet Ledger_SearchData( string name)
        {
            string[] var = new string[] { "@Name" };
            object[] par = new object[] {  name };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("Search_Ledger_Master", var, par, DataConnection.sConnstr);
            return ds;
        }

        public static DataSet Common_SearchData(string tablename, string name)
        {
            string[] var = new string[] { "@TableName", "@Name",   };
            object[] par = new object[] { tablename, name };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("[subgroup_Search]", var, par, DataConnection.sConnstr);
            return ds;
        }
        public static DataSet Inventory_SearchData( string name )
        {
            string[] var = new string[] {  "@Name" };
            object[] par = new object[] {  name,  };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("Search_Inventory_Master", var, par, DataConnection.sConnstr);
            return ds;
        }
        public static DataSet HSN_SearchData(string tablename, string code, string name)
        {
            string[] var = new string[] { "@TableName", "@Code", "@Name", "@CompanyID" };
            object[] par = new object[] { tablename, code, name, CompanyMasterClass.CompanyID };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("Search_HSN_Master", var, par, DataConnection.sConnstr);
            return ds;
        }
        public static DataSet Invoice_SearchData(string tablename, string name, string invoiceno)
        {
            string[] var = new string[] { "@TableName", "@Name", "@InvoiceNo", "@CompanyID" };
            object[] par = new object[] { tablename, name, invoiceno, CompanyMasterClass.CompanyID };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("Search_Invoice_Master", var, par, DataConnection.sConnstr);
            return ds;
        }
        public static DataSet RateList_SearchData(string fat,string clr,string rate )
        {
            string[] var = new string[] {  "@FAT", "@CLR","@RATE", "@CompanyID" };
            object[] par = new object[] { fat, clr, rate, CompanyMasterClass.CompanyID };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("Search_RateList_Master", var, par, DataConnection.sConnstr);
            return ds;
        }
        public static DataSet PurchaseDetail_SearchData(string billno, string productname, string partyname)
        {
            string[] var = new string[] { "@InvoiceNo", "@ProductName", "@PartyName", "@CompanyID" };
            object[] par = new object[] { billno, productname, partyname, CompanyMasterClass.CompanyID };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("Search_PurchaseDetail", var, par, DataConnection.sConnstr);
            return ds;
        }
        public static decimal getTextValue(string val)
        {
            if(string.IsNullOrEmpty(val as string)==false )
            {
                string Str = Convert.ToString(val);
                decimal Num;
                bool isNum = decimal.TryParse(Str, out Num);
                if (isNum)
                    return Num;
                else                    
                    return 0;
            }
            return 0;
            
        }
        public static DataSet Shop_SearchData(string name,string rtag)
        {
            string[] var = new string[] { "@Name" ,"@rtag"};
            object[] par = new object[] { name,rtag };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("Search_Shop_Master", var, par, DataConnection.sConnstr);
            return ds;
        }
    }
}
