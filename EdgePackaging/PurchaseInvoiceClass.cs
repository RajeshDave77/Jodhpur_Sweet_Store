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
   public class PurchaseInvoiceClass
    {
    public static   int a;
       public int Stock_InwardMaster(int id1,string partyname,int party,string stocktype,string invoiceno,string invoicedate,string remark ,int companyid,int userid,int Entryno,string finyear,double miscexp,double roff=0)
       {
           string cid;
           int a1 = 0;
           string[] Rate_Par = new string[] { "@ID", "@partyname","@party", "@stocktype", "@invoiceno", "@invoicedate","@Remark" ,"@companyid", "@userid" ,"@Entryno","@finyear","@miscexp","@roff"};
           object[] Rate_Val = new object[] { id1, partyname,party, stocktype, invoiceno, invoicedate, remark, companyid, userid, Entryno, finyear,miscexp,roff };
          cid = DataConnection.sqlsclaer("StockInwardmaster_InsertUpdate", Rate_Par, Rate_Val, DataConnection.sConnstr);
          a1 = Convert.ToInt32(cid);
          if (a1 != 0)
              return a = a1;
          else
              return a = -1;
    
       }
       public bool Stock_InwardDetail(int id1,int product,double qty,decimal rate,decimal amt, int masterid,string remark,int comid,string unit,string exdate,string exdate1,int sublocationid,int sublocation2,string batchno,int batchnoid,double orgrate=0)
       {
           string[] Rate_Par = new string[] { "@ID", "@Product","@Qty","@Rate","@amt","@Masterid","@remark" ,"@comid" ,"@unit","@exdate","@exdate1","@sublocationid","@sublocationid2","@batchno","@batchnoid","@orgrate"};
           object[] Rate_Val = new object[] { id1, product,qty,rate,amt,masterid,remark ,comid,unit,exdate,exdate1,sublocationid,sublocation2,batchno,batchnoid,orgrate};
           bool flag = DataConnection.RunQueryO("stockinwardetail_InsertUpdate", Rate_Par, Rate_Val, DataConnection.sConnstr);
           if (flag)
               return true;
           else
               return false;
       }



            public bool Roll_Invoice_InsertUpdate(string Quality, decimal Quantity, int Size, decimal Weight, string PartyName, int InvoiceNo, string InvoiceDate, Decimal Rate,int ChallanNo,int C_id,string quality1)
       {
           string[] Rate_Par = new string[] { "@Quality", "@Quantity", "@Size", "@Weight", "@Party", "@InvoiceNo", "@InvoiceDate", "@Rate", "@ChallanNo","@C_id","@Quality1" };
           object[] Rate_Val = new object[] { Quality, Quantity, Size, Weight, PartyName, InvoiceNo, InvoiceDate, Rate,ChallanNo,C_id,quality1 };
           bool flag = DataConnection.RunQueryO("[Roll_PurchaseInvoice_InsertUpdate]", Rate_Par, Rate_Val, DataConnection.sConnstr);
           if (flag)
               return true;
           else
               return false;
       }
            public int Check_Duplicacys(string tablename, string name)
            {
                string result;
                string[] per = new string[] { "@TableName", "@Name" };
                object[] val = new object[] { tablename, name };
                result = DataConnection.sqlsclaer("CheckDuplicacy_All_Master", per, val, DataConnection.sConnstr);
                int res = Convert.ToInt32(result);
                return res;
            }
            public DataSet Inward_GetData(string party,string stocktype,string fromdate,string todate,string invoiceno,int companyid)
            {
                DataSet ds = new DataSet();
                string[] List_Var = new string[] { "@Party", "@stocktype", "@fromdate", "@todate", "@invoiceno","@Companyid" };
                string[] List_Obj = new string[] {party ,stocktype,fromdate,todate,Convert.ToString(invoiceno),Convert.ToString(companyid) };
                ds = DataConnection.GetSqlDataSet("[searchingtest]", List_Var, List_Obj, DataConnection.sConnstr);
                return ds;
            }
   
    
    }
}
