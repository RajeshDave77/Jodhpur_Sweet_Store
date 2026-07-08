using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EdgePackingShared
{
    public class InventoryMasterClass
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public Int32 InventoryGroup { get; set; }
        public Int32 InventorySGroup { get; set; }
        public Int32 InventoryUnit { get; set; }
        public Int32 Quality { get; set; }
        public Int32 GSM { get; set; }
        public Decimal PurchaseRate { get; set; }
        public Decimal SalesRate { get; set; }
        public Decimal Discount { get; set; }
        public Decimal OpeningStock { get; set; }
        public Decimal ClosingStock { get; set; }
        public String Remark { get; set; }
        public Int32 CompanyID { get; set; }
        public String OrderNo { get; set; }
        public Int32 InvoiceNo { get; set; }
        public String TableName { get; set; }



        public bool Inventory_InsertUpdate(int id, string name, string code, decimal Rate, int ProductSubgroupID, int MinLevel, int Maxlevel, int Status, int Fav, string hsn, decimal gst, decimal cess, decimal openingstock, int companyid, string rprint, string rkotshow, string unit, int unitid, string lot1, string lot2, string lot3, int lot1id, int lot2id, int lot3id, double conv1, double conv2, double conv3)
        {
            ID = id;
            Name = name;
       

            string[] Inventory_Par = new string[] { "@ID", "@Name", "@code", "@Rate", "@ProductSubgroupID", "@MinLevel", "@Maxlevel",  "@Status",  "@Fav","@hsn","@gst","@cess","@OpeningStock","@companyid","@rprint" ,"@rkotshow","@unit","@unitid","@lot1","@lot2","@lot3","@lot1id","@lot2id","@lot3id","@conv1","@conv2","@conv3"};
            object[] Inventory_Val = new object[] { ID, Name, code, Rate, ProductSubgroupID, MinLevel, Maxlevel,  Status, Fav,hsn,gst,cess,openingstock,companyid,rprint,rkotshow,unit,unitid ,lot1,lot2,lot3,lot1id,lot2id,lot3id,conv1,conv2,conv3};
            bool flag = DataConnection.RunQueryO("InventoryMaster_InsertUpdate", Inventory_Par, Inventory_Val, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }
        public bool HSN_InsertUpdate(int id, string HSN_Cat, string HSN_Code, decimal Tax)
        {
            ID = id;

            string[] Inventory_Par = new string[] { "@ID", "@HSN_Cat", "@HSN_Code", "@Tax","@CompanyID" };
            object[] Inventory_Val = new object[] { ID, HSN_Cat, HSN_Code, Tax,CompanyMasterClass.CompanyID };
            bool flag = DataConnection.RunQueryO("HSNMaster_InsertUpdate", Inventory_Par, Inventory_Val, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public bool Inventory_Delete(int id)
        {
            ID = id;
            string[] Inventory_Var = new string[] { "@ID" };
            object[] Inventory_Obj = new object[] { ID };
            bool flag = DataConnection.RunQueryO("InventoryMaster_Delete", Inventory_Var, Inventory_Obj, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }
        public bool HSN_Delete(int id)
        {
            ID = id;
            string[] Inventory_Var = new string[] { "@ID" };
            object[] Inventory_Obj = new object[] { ID };
            bool flag = DataConnection.RunQueryO("HSNMaster_Delete", Inventory_Var, Inventory_Obj, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }
        public DataSet Inventory_GetData()
        {
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSet("InventoryMaster_Retrive", null, null, DataConnection.sConnstr);
            return ds;
        }
        public DataSet HSN_GetData()
        {
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSet("HSNMaster_Retrive", null, null, DataConnection.sConnstr);
            return ds;
        }
        public DataSet Inventory_GetData_ByID(int id)
        {
            string[] Inventory_Var = new string[] { "@ID" };
            object[] Inventory_Obj = new object[] { id };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("InventoryMaster_Retrive", Inventory_Var, Inventory_Obj, DataConnection.sConnstr);
            return ds;
        }

        public DataSet BillPurchase_GetData()
        {
            DataSet ds = new DataSet();
            string[] Var = new string[] { "@CompanyID" };
            object[] Obj = new object[] { CompanyMasterClass.CompanyID };
            ds = DataConnection.GetSqlDataSetO("Inventory_Retrive_ForSalesTransection", Var, Obj, DataConnection.sConnstr);
            return ds;
        }

        public void SearchList_GetData(string Name, string TableName, ListBox lbName)
        {
            try
            {
                DataSet ds = new DataSet();
                string[] List_Var = new string[] { "@TableName", "@Name" };
                string[] List_Obj = new string[] { TableName, Name };
                ds = DataConnection.GetSqlDataSet("retrive_All_Master", List_Var, List_Obj, DataConnection.sConnstr);
                lbName.DataSource = ds.Tables[0];
                lbName.DisplayMember = "Name";
                lbName.ValueMember = "ID";
            }
            catch { }
        }
        public void SearchList_GetDataForPaper(string id1, string TableName, ListBox lbName)
        {
            OrderNo = id1;
            DataSet ds = new DataSet();
            string[] List_Var = new string[] { "@TableName", "@OrderNo" };
            string[] List_Obj = new string[] { TableName, OrderNo };
            ds = DataConnection.GetSqlDataSet("Paper_Fill", List_Var, List_Obj, DataConnection.sConnstr);
            lbName.DataSource = ds.Tables[0];
            lbName.DisplayMember = "Name";
      //      lbName.ValueMember = "ID";

        }
        public void SearchList_GetDataforSheet(string id1, string TableName, ListBox lbName)
        {
            try
            {
                OrderNo = id1;
                DataSet ds = new DataSet();
                string[] List_Var = new string[] { "@OrderNo", "@TableName" };
                string[] List_Obj = new string[] { OrderNo, TableName };
                ds = DataConnection.GetSqlDataSet("Paper_Fill", List_Var, List_Obj, DataConnection.sConnstr);
                lbName.DataSource = ds.Tables[0];
                lbName.DisplayMember = "Name";
                //lbName.ValueMember = "ID";
            }
            catch
            { }
        }

        public DataSet sheet_Report(string orderno)
        {
            DataSet ds = new DataSet();

            string[] var = new string[] { "OrderNo" };
            object[] per = new object[] { orderno };
            ds = DataConnection.GetSqlDataSetO("SheetReport", var, per, DataConnection.sConnstr);
            return ds;
        }
        public void SearchList_GetDataforRoll(int invoiceno, string TableName, ListBox lbName)
        {
          
            InvoiceNo = invoiceno;
            DataSet ds = new DataSet();
            string[] List_Var = new string[] { "@TableName", "@InvoiceNo" };
            string[] List_Obj = new string[] { TableName,Convert.ToString(InvoiceNo) };
            ds = DataConnection.GetSqlDataSet("retrive_All_Master", List_Var, List_Obj, DataConnection.sConnstr);
            lbName.DataSource = ds.Tables[0];
            lbName.DisplayMember = "InvoiceNo";
            //lbName.ValueMember = "ID";

        }
    }
}
