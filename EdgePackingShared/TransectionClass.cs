using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EdgePackingShared
{
    public class TransectionClass
    {
        public Int32 MasterID { get; set; }
        public Int32 DetailID { get; set; }
        public String Type {get;set;}
        public Int32 Type_Code { get; set; }
        public String Pay_Mode{get;set;}
        public Int32 InvoiceNo {get;set;}
        public DateTime Date {get;set;}
        public String PartyCode{get;set;}
        public String PartyName{get;set;}
        public Int32 PartyID{get;set;}
        public Int32 Account{get;set;}
        public Int32 Vehical{get;set;}
        public String Narration{get;set;}
        public Int32 Account11{get;set;}
        public Decimal Account12{get;set;}
        public Decimal Account13{get;set;}
        public Int32 Account21{get;set;}
        public Decimal Account22{get;set;}
        public Decimal Account23{get;set;}
        public Int32 Account31{get;set;}
        public Decimal Account32{get;set;}
        public Decimal Account33{get;set;}
        public Int32 Account41{get;set;}
        public Decimal Account42{get;set;}
        public Decimal Account43{get;set;}
        public Decimal RoundOf{get;set;}
        public Decimal Total_Amount{get;set;}
        public DateTime CreationDate{get;set;}
        public String Account11Name { get; set; }
        public String Account21Name { get; set; }
        public String Account31Name { get; set; }
        public String Account41Name { get; set; }
        public String PCode { get; set; }
        public String PName { get; set; }
        public Int32 PID { get; set; }
        public Decimal Qty { get; set; }
        public String Unit { get; set; }
        public Decimal Rate { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Transport { get; set; }
        public Decimal Unloading { get; set; }
        public Decimal Dis_Per { get; set; }
        public Decimal Dis_Amt { get; set; }
        public Decimal OtherAmount { get; set; }
        public Decimal SalesPrice { get; set; }
        public Decimal NetAmount { get; set; }
        public String NarrationBillDetail { get; set; }
        public Int32 PurchaseID { get; set; }
        public String PurchaseDetail { get; set; }
        public Int32 CompanyID { get; set; }
        public string GetProductName_byCode(string code)        
        {
            string[] var = new string[] { "@CompanyID", "@Code" };
            object[] par = new object[] {  CompanyMasterClass.CompanyID,code };
            string name = DataConnection.sqlsclaer("Inventory_Get_ByCodeName", var, par, DataConnection.sConnstr);
            return name;
        }
        public string GetProductCode_byName(string name)
        {
            string[] var = new string[] { "@CompanyID", "@Name" };
            object[] par = new object[] { CompanyMasterClass.CompanyID, name };
            string code = DataConnection.sqlsclaer("Inventory_Get_ByCodeName", var, par, DataConnection.sConnstr);
            return code;
        }
        public string Ledger_GetOverheadPercent_ByName(string name)
        {
            string[] var = new string[] { "@CompanyID", "@Name" };
            object[] par = new object[] { CompanyMasterClass.CompanyID, name };
            string code = DataConnection.sqlsclaer("LedgerMaster_GetOverheadPercent_byNameforTax", var, par, DataConnection.sConnstr);
            return code;
        }
        public DataSet Ledger_GetData_ByName( string name)
        {
            string[] var = new string[] { "@CompanyID","@Name"};
            object[] par = new object[] { CompanyMasterClass.CompanyID,name};
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("LedgerMaster_Retrive_byCodeName", var, par, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Ledger_GetData_ByAccountName_head_no(string name, int headno)
        {
            string[] var = new string[] { "@CompanyID", "@Name" , "@Headno"};
            object[] par = new object[] { CompanyMasterClass.CompanyID, name , headno  };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("LedgerMaster_Retrive_byName_headno", var, par, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Ledger_GetData_head_no(string name, int headno)
        {
            string[] var = new string[] { "@CompanyID", "@Name", "@Headno" };
            object[] par = new object[] { CompanyMasterClass.CompanyID, name, headno };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("LedgerMaster_Retrive_headno", var, par, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Ledger_GetData_ByAccountName(string name)
        {
            string[] var = new string[] { "@CompanyID", "@Name" };
            object[] par = new object[] { CompanyMasterClass.CompanyID, name };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("LedgerMaster_Retrive_byName", var, par, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Ledger_GetData_ByCode(string code)
        {
            string[] var = new string[] { "@CompanyID", "@Code" };
            object[] par = new object[] { CompanyMasterClass.CompanyID, code };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("LedgerMaster_Retrive_byCodeName", var, par, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Ledger_GetData_ByCode_ForSales(string code)
        {
            string[] var = new string[] { "@CompanyID", "@Code" };
            object[] par = new object[] { CompanyMasterClass.CompanyID, code };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("LedgerMaster_Retrive_byCodeName_ForSales", var, par, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Ledger_GetData_ByName_ForSales(string name)
        {
            string[] var = new string[] { "@CompanyID", "@Name" };
            object[] par = new object[] { CompanyMasterClass.CompanyID, name };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("LedgerMaster_Retrive_byCodeName_ForSales", var, par, DataConnection.sConnstr);
            return ds;
        }
        public int BillMaster_InsertUpdate(int id, string type, int type_code,  int invoiceNo, DateTime date, string partyCode, string partyName, int partyID, int account, int vehical, string narration, int account11, decimal account12, decimal account13, int account21, decimal account22, decimal account23, int account31, decimal account32, decimal account33, int account41, decimal account42, decimal account43, decimal roundOf, decimal total_Amount, DateTime creationDate, string account11name, string account21name, string account31name, string account41name, int companyid)
        {
            MasterID = id;
            Type = type;
            if (type  == "Purchase")
            {
                type_code = 1;
            }

            if (type == "Sales")
            {
                type_code = 2;
            }
            if (type == "Purchase Return")
            {
                type_code = 3;
            }
            if (type == "Sales Return")
            {
                type_code = 4;
            }
            
            Type_Code = type_code;
            
            InvoiceNo=invoiceNo;
            Date=date;
            PartyCode=partyCode;
            PartyName=partyName;
            PartyID=partyID;
            Account=account;
            Vehical = vehical;
            Narration=narration;
            Account11=account11;
            Account12=account12;
            Account13=account13;
            Account21=account21;
            Account22=account22;
            Account23=account23;
            Account31=account31;
            Account32=account32;
            Account33=account33;
            Account41=account41;
            Account42=account42;
            Account43=account43;
            RoundOf=roundOf;
            Total_Amount=total_Amount;
            CreationDate=creationDate;
            Account11Name = account11name;
            Account21Name = account21name;
            Account31Name = account31name;
            Account41Name = account41name;
            CompanyID = companyid;
            String Billid;
            string[] var = new string[] { "@ID", "@Type", "@Type_Code", "@InvoiceNo", "@Date", "@PartyCode", "@PartyName", "@PartyID", "@Account", "@Vehical", "@Narration", "@Account11", "@Account12", "@Account13", "@Account21", "@Account22", "@Account23", "@Account31", "@Account32", "@Account33", "@Account41", "@Account42", "@Account43", "@RoundOf", "@Total_Amount", "@CreationDate", "@Account11Name", "@Account21Name", "@Account31Name", "@Account41Name", "@CompanyID" };
            object[] par = new object[] { MasterID, Type, Type_Code, InvoiceNo, Date, PartyCode, PartyName, PartyID, Account, Vehical, Narration, Account11, Account12, Account13, Account21, Account22, Account23, Account31, Account32, Account33, Account41, Account42, Account43, RoundOf, Total_Amount, CreationDate,Account11Name,Account21Name,Account31Name,Account41Name, CompanyID };
            Billid = DataConnection.sqlsclaer("BillMaster_InsertUpdate", var, par, DataConnection.sConnstr);
            MasterID = Convert.ToInt32(Billid);
            return MasterID;
        }
        public bool BillDetail_InsertUpdate(int id, int invoiceid, string pCode, string pName, int pID, decimal qty, string unit, decimal rate, decimal amount, decimal transport, decimal unloading, decimal otheramount,decimal salesprice, decimal netAmount,string narration, int purchaseid, string purchasedetail)
        {
            DetailID = id;            
            PCode=pCode;
            PName=pName;
            PID=pID;
            Qty=qty;
            Unit = unit;
            Rate=rate;
            Amount=amount;
            Transport = transport;
            Unloading = unloading;
            OtherAmount = otheramount;
            SalesPrice = salesprice;
            NetAmount = netAmount;
            NarrationBillDetail = narration;
            PurchaseID = purchaseid;
            PurchaseDetail = purchasedetail;
            string[] var = new string[] { "@ID", "@InvoiceID", "@PCode", "@PName", "@PID", "@Qty", "@Unit", "@Rate", "@Amount", "@Transport", "@Unloading", "@OtherAmount", "@SalesPrice", "@NetAmount", "@Narration", "@PurchaseID", "@PurchaseDetail" };
            object[] par = new object[] { DetailID, invoiceid, PCode, PName, PID, Qty,Unit, Rate, Amount, Transport, Unloading, OtherAmount,SalesPrice, NetAmount,NarrationBillDetail, PurchaseID, PurchaseDetail };
            bool flag = DataConnection.RunQueryO("BillDetail_InsertUpdate", var, par, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }
        public bool BillDetailSales_InsertUpdate(int id, int invoiceid, string pCode, string pName, int pID, decimal qty, string unit, decimal rate, decimal amount, decimal disper, decimal disamt, decimal otheramount, decimal netAmount, string narration, int purchaseid, string purchasedetail)
        {
            DetailID = id;
            PCode = pCode;
            PName = pName;
            PID = pID;
            Qty = qty;
            Unit = unit;
            Rate = rate;
            Amount = amount;
            Dis_Per = disper;
            Dis_Amt = disamt;
            OtherAmount = otheramount;
            NetAmount = netAmount;
            NarrationBillDetail = narration;
            PurchaseID = purchaseid;
            PurchaseDetail = purchasedetail;
            string[] var = new string[] { "@ID", "@InvoiceID", "@PCode", "@PName", "@PID", "@Qty", "@Unit", "@Rate", "@Amount", "@DisPer", "@DisAmount", "@OtherAmount", "@NetAmount", "@Narration", "@PurchaseID", "@PurchaseDetail" };
            object[] par = new object[] { DetailID, invoiceid, PCode, PName, PID, Qty, Unit, Rate, Amount, Dis_Per, Dis_Amt, OtherAmount, NetAmount, NarrationBillDetail, PurchaseID, PurchaseDetail };
            bool flag = DataConnection.RunQueryO("BillDetail_InsertUpdate", var, par, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }
        
        public bool BillDetail_Delete_ByID(int id)
        {
            DetailID = id;
            string[] var = new string[] { "@ID" };
            object[] par = new object[] { DetailID };
            bool flag = DataConnection.RunQueryO("BillDetail_Delete_ByID", var, par, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }
        public bool BillDetail_Delete_ByInvoiceID(string invoiceid)
        {
            string[] var = new string[] { "@InvoiceID" };
            object[] par = new object[] { invoiceid };
            bool flag = DataConnection.RunQueryO("BillDetail_Delete_ByInvoiceID", var, par, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }
        public DataSet BillMaster_GetData(string typename)
        {
            string[] var = new string[] { "@CompanyID", "@typename" };
            object[] par = new object[] { CompanyMasterClass.CompanyID , typename  };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("BillMaster_Retrive", var, par, DataConnection.sConnstr);
            return ds;
        }
        public bool Bill_Delete(int id,int invoiceid)
        {
            MasterID = id;
            
            string[] Var = new string[] { "@ID", "@InvoiceID" };
            object[] obj = new object[] { id, MasterID };
            bool flag = DataConnection.RunQueryO("BillMaster_Delete", Var, obj, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }
        public DataSet BillDetail_GetData(int invoiceno)
        {
            string[] var = new string[] { "@InvoiceID" };
            object[] par = new object[] { invoiceno };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("BillDetail_Retrive", var, par, DataConnection.sConnstr);
            return ds;
        }
        public int CheckMax(string tablename, string type)
        {
            string result;
            string[] per = new string[] { "@TableName", "@Type", "@CompanyID" };
            object[] val = new object[] { tablename, type, CompanyMasterClass.CompanyID };
            result = DataConnection.sqlsclaer("Bill_CheckMax", per, val, DataConnection.sConnstr);
            if(result=="")
            {
                result = "0";
            }
            int res = Convert.ToInt32(result);
            return res;
        }
        public int CompareMax(string tablename, string type,int invoiceno,int billid)
        {
            string result;
            string[] per = new string[] { "@TableName","@InvoiceNo", "@Type", "@Bill_id", "@CompanyID" };
            object[] val = new object[] { tablename,invoiceno, type, billid , CompanyMasterClass.CompanyID };
            result = DataConnection.sqlsclaer("Bill_CompareMax", per, val, DataConnection.sConnstr);
            int res = Convert.ToInt32(result);
            return res;
        }
        public DataSet GetPurchaseDetailforSales()
        {
            string[] var = new string[] { "@CompanyID"};
            object[] par = new object[] { CompanyMasterClass.CompanyID};
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("BillMasterSales_Retrive",var,par,DataConnection.sConnstr);
            return ds;
        }
        public DataSet GetStockDetailforPurchase(string pcode)
        {
            string[] var = new string[] { "@PCode","@CompanyID" };
            object[] par = new object[] { pcode,CompanyMasterClass.CompanyID };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("BillMasterPurchaseQuanitity_Retrive", var, par, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Inventory_GetData_ByCodeName(string name)
        {
            string[] var = new string[] { "@CompanyID", "@Name" };
            object[] par = new object[] { CompanyMasterClass.CompanyID, name };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("Inventory_Retrive_ForTransection", var, par, DataConnection.sConnstr);
            return ds;
        }
    }
}
