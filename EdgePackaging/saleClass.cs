using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EdgePackingShared
{
  public  class saleClass
    {
      public bool Sale_InsertUpdateint (int ID, string PayMode,int KotNo,string KotDate,int BillNo,string BillDate,int PartyId,string partyname,string Mobile,decimal NetAmount,int UserId,int CompanyId,string BillTime,string finyear)
      {

          string[] Inventory_Par = new string[] { "@ID", "@PayMode", "@KotNo", "@KotDate", "@BillNo", "@BillDate", "@PartyId", "@partyname", "@Mobile", "@NetAmount", "@UserId", "@CompanyId","@BillTime","@finyear" };
          object[] Inventory_Val = new object[] { ID, PayMode, KotNo, KotDate, BillNo, BillDate, PartyId, partyname, Mobile, NetAmount, UserId, CompanyId,BillTime,finyear };
          bool flag = DataConnection.RunQueryO("sale_InsertUpdate", Inventory_Par, Inventory_Val, DataConnection.sConnstr);
          if (flag)
              return true;
          else
              return false;
      }
      public bool SaleDetail_InsertUpdate(int ID, int ProductId, decimal Qty, string Barcode, decimal rate, decimal amount, decimal Netamt, int SaleId, decimal taxrate)
      {


          string[] Inventory_Par = new string[] {  "@ID", "@ProductID", "@Qty", "@BarCode", "@Rate", "@Amount", "@NetAmount", "@Salesid", "@TaxRate" };
          object[] Inventory_Val = new object[] { ID, ProductId, Qty, Barcode, rate, amount, Netamt, SaleId, taxrate };
          bool flag = DataConnection.RunQueryO("SaleDetail_InsertUpdate", Inventory_Par, Inventory_Val, DataConnection.sConnstr);
          if (flag)
              return true;
          else
              return false;
      }
      public DataSet Sales_GetData(string Fromdate,string Todate,int KOT_BILL )
      {
          DataSet ds = new DataSet();
          string[] Inventory_Par = new string[] { "@FromDate", "@ToDate", "@KOT_BILL" };
          string[] Inventory_Val = new string[] { Fromdate, Todate, Convert.ToString(KOT_BILL) };
          ds = DataConnection.GetSqlDataSet("retrive_All_Master", Inventory_Par, Inventory_Val, DataConnection.sConnstr);
          return ds;
      }
      public DataSet Sales_GetData( string BILL_KOT_No,string Searchtype)
      {
          DataSet ds = new DataSet();
          string[] Inventory_Par = new string[] { "@BILL_KOT_No", "@Searchtype" };
          string[] Inventory_Val = new string[] { BILL_KOT_No, Searchtype };
          ds = DataConnection.GetSqlDataSet("retrive_Common_Master", Inventory_Par, Inventory_Val, DataConnection.sConnstr);
          return ds;
      }
      public DataSet Sales_GetDataForUpdate(int saleid)
      {
          DataSet ds = new DataSet();
          string[] Inventory_Par = new string[] { "@Saleid" };
          string[] Inventory_Val = new string[] {Convert.ToString(saleid) };
          ds = DataConnection.GetSqlDataSet("[getsaleinfoforupdate]", Inventory_Par, Inventory_Val, DataConnection.sConnstr);
          return ds;
      }
      public DataSet SalesCollection_SearchData(string fromdate,string todate)
      {
          string[] var = new string[] { "@fromdate", "@todate" };
          object[] par = new object[] { fromdate,todate };
          DataSet ds = new DataSet();
          ds = DataConnection.GetSqlDataSetO("AmountCollection", var, par, DataConnection.sConnstr);
          return ds;
      }
     
    }
}
