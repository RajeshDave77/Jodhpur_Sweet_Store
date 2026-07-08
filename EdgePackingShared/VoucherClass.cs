using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EdgePackingShared
{
    public class VoucherClass
    {
        public static int COLUMNINDEX = 0;
        public static int ROWINDEX = 0;
        public Int32 MasterID { get; set; }
        public Int32 DetailID { get; set; }
        public String V_Type { get; set; }
        public String V_No { get; set; }
        public DateTime V_Date { get; set; }
        public String V_Narration { get; set; }
        public String BillNo { get; set; }
        public DateTime CreationDate { get; set; }
        public Decimal Total_Dr { get; set; }
        public Decimal Total_Cr { get; set; }
        public String Total_Balance { get; set; }
        public Int32 CompanyID { get; set; }
        public String CreatedBy { get; set; }
        public Int32 IsDeleted { get; set; }
        public String DeletedBy { get; set; }
        public Int32 LedgerID { get; set; }
        public String DrCr { get; set; }
        public Decimal Amount { get; set; }        
        public String Balance { get; set; }
        public String Narration { get; set; }

        public String Reference { get; set; }

        public DataSet Opening_Ledger_GetData(string tablename, string name)
        {
            DataSet ds = new DataSet();
            string[] Var = new string[] { "@TableName", "@Name" };
            string[] Par = new string[] { tablename, name };
            ds = DataConnection.GetSqlDataSet("retrive_All_Master", Var, Par, DataConnection.sConnstr);
            return ds;
        }
        public int VoucherMaster_InsertUpdate(int id, string v_type, string v_no, DateTime v_date, string billno, string reference, string narration, DateTime creationdate,decimal total_dr,decimal total_cr,string total_balance, int companyid)
        {
            MasterID = id;
            V_Type = v_type;
            V_No = v_no;
            V_Date = v_date;
            BillNo = billno;
            Narration = narration;
            Reference = reference;
            CreationDate = creationdate;
            Total_Dr = total_dr;
            Total_Cr = total_cr;
            Total_Balance = total_balance;
            CompanyID = companyid;
            string[] var = new string[] { "@ID", "@V_Type", "@V_No", "@V_Date", "@BillNo", "@Reference", "@V_Narration", "@CreationDate", "@Total_Dr", "@Total_Cr", "@Balance", "@CompanyID" };
            object[] par = new object[] { MasterID, V_Type, V_No, V_Date,BillNo,Reference,Narration, CreationDate,Total_Dr,Total_Cr,Total_Balance, CompanyID };
            string res = DataConnection.sqlsclaer("VoucherMaster_InsertUpdate", var, par, DataConnection.sConnstr);
            MasterID = Convert.ToInt32(res);
            return MasterID;
        }
        public bool VoucherDetail_InsertUpdate(int id, string v_id,int ledgerid, string drcr,decimal AmountCr,decimal AmountDr, decimal Balance)
        {
            DetailID = id;            
            
            LedgerID = ledgerid;
            DrCr = drcr;



            string[] var = new string[] { "@ID", "@v_id", "@LedgerID", "@DrCr", "@AmountCr", "@AmountDr", "@Balance" };
            object[] par = new object[] { DetailID, v_id, LedgerID, DrCr, AmountCr, AmountDr, Balance };
            bool flag = DataConnection.RunQueryO("VoucherDetail_InsertUpdate", var, par, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }
        
        public bool VoucherDetail_Delete_ByID(int id)
        {
            DetailID = id;
            string[] var = new string[] { "@ID" };
            object[] par = new object[] { DetailID };
            bool flag = DataConnection.RunQueryO("VoucherDetail_Delete_ByID", var, par, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }
        public bool VoucherDetail_Delete_ByVID(string v_id)
        {
            
            string[] var = new string[] { "@V_ID" };
            object[] par = new object[] { v_id };
            bool flag = DataConnection.RunQueryO("VoucherDetail_Delete_ByVID", var, par, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public DataSet VoucherMaster_GetData()
        {
            string[] var = new string[] { "@CompanyID"};
            object[] par = new object[] { CompanyMasterClass.CompanyID };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("VoucherMaster_Retrive", var, par, DataConnection.sConnstr);
            return ds;
        }
        public bool Voucher_Delete(int id)
        {
            MasterID = id;

            string[] Var = new string[] { "@ID", "@V_ID" };
            object[] obj = new object[] { MasterID,MasterID };
            bool flag = DataConnection.RunQueryO("VoucherMaster_Delete", Var, obj, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }
        public DataSet VoucherDetail_GetData(string v_id)
        {
            string[] var = new string[] { "@V_ID" };
            object[] par = new object[] { v_id };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("VoucherDetail_Retrive", var, par, DataConnection.sConnstr);
            return ds;
        }
        public int LedgerMaster_GetID_ByName(string name)
        {
            string[] var = new string[] { "@Name", "@CompanyID" };
            object[] par = new object[] { name,CompanyMasterClass.CompanyID};
            string res = DataConnection.sqlsclaer("LedgerMaster_GETID_byName",var,par,DataConnection.sConnstr);
            if(res!="error")
            {
                LedgerID = Convert.ToInt32(res);
                return LedgerID;
            }
            else
            {
                return -1;
            }
            
        }
        public int CheckMax(string type)
        {
            string result;
            string[] per = new string[] { "@Type", "@CompanyID" };
            object[] val = new object[] { type, CompanyMasterClass.CompanyID };
            result = DataConnection.sqlsclaer("Voucher_CheckMax", per, val, DataConnection.sConnstr);
            if (result == ""||result=="error")// By Rishi
            {
                result = "0";
            }
            int res = Convert.ToInt32(result);
            return res;
        }
        public int CompareMax( string type, int invoiceno)
        {
            string result;
            string[] per = new string[] { "@InvoiceNo", "@Type", "@CompanyID" };
            object[] val = new object[] { invoiceno, type, CompanyMasterClass.CompanyID };
            result = DataConnection.sqlsclaer("Voucher_CompareMax", per, val, DataConnection.sConnstr);
            int res = Convert.ToInt32(result);
            return res;
        }
    }
}
