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
       public int Stock_InwardMaster(int id1,string party,string stocktype,int invoiceno,string invoicedate,int companyid,int userid)
       {
           string cid;
           int a1 = 0;
           string[] Rate_Par = new string[] { "@ID", "@party", "@stocktype", "@invoiceno", "@invoicedate", "@companyid", "@userid" };
           object[] Rate_Val = new object[] { id1,party,stocktype,invoiceno,invoicedate,companyid,userid };
          cid = DataConnection.sqlsclaer("StockInwardmaster_InsertUpdate", Rate_Par, Rate_Val, DataConnection.sConnstr);
          a1 = Convert.ToInt32(cid);
          if (a1 != 0)
              return a = a1;
          else
              return a = -1;
    
       }
       public bool Stock_InwardDetail(int id1,int product,int qty,decimal rate,decimal amt,string remark,int masterid)
       {
           string[] Rate_Par = new string[] { "@ID", "@Product","@Qty","@Rate","@amt","@Remark","@Masterid"  };
           object[] Rate_Val = new object[] { id1, product,qty,rate,amt,remark,masterid };
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
            public int Check_Duplicacys(string tablename, int Challanno)
            {
                string result;
                string[] per = new string[] { "@TableName", "@ID" };
                object[] val = new object[] { tablename, Challanno };
                result = DataConnection.sqlsclaer("CheckDuplicacy_All_Master", per, val, DataConnection.sConnstr);
                int res = Convert.ToInt32(result);
                return res;
            }
            public DataSet Inward_GetData(string party,string stocktype,string fromdate,string todate,int invoiceno,int companyid)
            {
                DataSet ds = new DataSet();
                string[] List_Var = new string[] { "@Party", "@stocktype", "@fromdate", "@todate", "@invoiceno","@Companyid" };
                string[] List_Obj = new string[] {party ,stocktype,fromdate,todate,Convert.ToString(invoiceno),Convert.ToString(companyid) };
                ds = DataConnection.GetSqlDataSet("stock_inward_Retrive", List_Var, List_Obj, DataConnection.sConnstr);
                return ds;
            }
   
    
    }
}
