using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EdgePackingShared
{
    public class Inventory_Sub_GroupClass
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public Int32 Parent { get; set; }
        public Int32 CompanyID { get; set; }

        public bool Inv_S_Grp_InsertUpdate(int id, string name, int parent,int companyid)
        {
            ID = id;
            Name = name;
            Parent = parent;
            
            string[] Head_Par = new string[] { "@ID", "@Name", "@Parent" ,"@companyid"};
            object[] Head_Val = new object[] { ID, Name, Parent,companyid };
            bool flag = DataConnection.RunQueryO("Inventory_Sub_Group_Master_InsertUpdate", Head_Par, Head_Val, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public bool Inv_S_Grp_Delete(int id)
        {
            ID = id;
            string[] Head_Var = new string[] { "@ID" };
            object[] Head_obj = new object[] { ID };
            bool flag = DataConnection.RunQueryO("Inventory_Sub_Group_Master_Delete", Head_Var, Head_obj, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public DataSet Inv_S_Grp_GetData()
        {
            string[] var = new string[] { };
            object[] per = new object[] { };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("Inventory_Sub_Group_Master_Retrive", var, per, DataConnection.sConnstr);
            return ds;
        }
    }
}

