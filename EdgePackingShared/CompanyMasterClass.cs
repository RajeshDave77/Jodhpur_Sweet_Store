using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EdgePackingShared
{
    public class CompanyMasterClass
    {
        public static Int32 CompanyID {get;set;}
        public static String CompanyName { get; set; }
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public String Alias { get; set; }
        public String Address { get; set; }
        public String Area { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Country { get; set; }
        public String PINCODE { get; set; }
        public String Mobile { get; set; }
        public String ResidenceNumber { get; set; }
        public String OfficeNumber { get; set; }
        public String Fax { get; set; }
        public String Email { get; set; }
        public String Website { get; set; }
        public String TINNumber { get; set; }
        public String PANNumber { get; set; }
        public String GSTNumber { get; set; }
        public String SMS { get; set; }
        public String API { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String SendID { get; set; }
        public Int32 CodeLength { get; set; }
        public String FooterMessage { get; set; }

        public int Company_InsertUpdate(int id, string name, string address1,string address2,string address3, string state,string gst)
        {
            ID = id;
            Name = name;
          
           
            State = state;
           
          
           
            GSTNumber = gst;
         
            String cid;
            string[] Company_Par = new string[] { "@ID", "@Name", "@Address1", "@Address2", "@Address3", "@State", "@GSTNumber" };
            object[] Company_Val = new object[] { id,name, address1,address2, address3, state ,gst };
            cid = DataConnection.sqlsclaer("CompanyMaster_InsertUpdate", Company_Par, Company_Val, DataConnection.sConnstr);
            ID = Convert.ToInt32(cid);
            if (ID!=0)
                return CompanyID=ID;
            else
                return CompanyID=-1;
        }
        
        public DataSet Company_GetData()
        {
            DataSet ds = new DataSet();
            //ds = DataConnection.GetSqlDataSet("CustomerMasterSelectAll", null, null, DataConnection.sConnstr);
            ds = DataConnection.GetSqlDataSet("CompanyMaster_Retrive", null, null, DataConnection.sConnstr);
            return ds;
        }

        public void SearchList_GetData(string Name, string TableName, ListBox lbName)
        {
            DataSet ds = new DataSet();
            string[] List_Var = new string[]{"@TableName","@Name"}; 
            string[] List_Obj = new string[]{TableName,Name};
            ds = DataConnection.GetSqlDataSet("retrive_All_Master", List_Var, List_Obj, DataConnection.sConnstr);
            lbName.DataSource = ds.Tables[0];
            lbName.DisplayMember = "Name";
            lbName.ValueMember = "ID";

        }

        public bool Company_Delete(int id)
        {
            ID = id;
            string[] Company_Var = new string[] { "@ID"};
            object[] Company_Obj = new object[] { ID};
            bool flag = DataConnection.RunQueryO("CompanyMaster_Delete",Company_Var,Company_Obj,DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public bool Master_Delete(int id,string tablename)
        {
            ID = id;
            string[] Master_Var = new string[] { "@TableName","@ID"};
            object[] Master_Obj = new object[] { tablename,ID};
            bool flag = DataConnection.RunQueryO("delete_All_Master",Master_Var,Master_Obj,DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public bool Master_InsertUpdate(int id,string name, string tablename)
        {
            string[] Master_Var = new string[] { "@TableName","@ID","@Name"};
            object[] Master_Obj = new object[] { tablename,id,name};
            bool flag = DataConnection.RunQueryO("InsertUpdate_All_Master",Master_Var,Master_Obj,DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public int Get_CodeLength()
        {
            string[] var = new string[] { "@CompanyID"};
            object[] par = new object[] { CompanyMasterClass.CompanyID };
            string codeleng = DataConnection.sqlsclaer("Company_CodeLength_Retrive",var,par,DataConnection.sConnstr);
            CodeLength = Convert.ToInt32(codeleng);
            return CodeLength;
        }
    }
}
