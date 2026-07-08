using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EdgePackingShared
{
    public class HeadMasterClass
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public Int32 Parent { get; set; }
        public Int32 CompanyID { get; set; }

        public bool Head_InsertUpdate(int id, string name, int parent, int companyid)
        {
            ID = id;
            Name = name;
            Parent = parent;
            CompanyID = companyid;

            string[] Head_Par = new string[] { "@ID", "@Name", "@Parent", "@CompanyID" };
            object[] Head_Val = new object[] { ID, Name, Parent, CompanyID };
            bool flag = DataConnection.RunQueryO("HeadMaster_InsertUpdate", Head_Par, Head_Val, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public bool Head_Delete(int id)
        {
            ID = id;
            string[] Head_Var = new string[] { "@ID" };
            object[] Head_obj = new object[] { ID };
            bool flag = DataConnection.RunQueryO("HeadMaster_Delete", Head_Var, Head_obj, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public DataSet Head_GetData()
        {
            string[] var = new string[] { "@CompanyID"};
            object[] per = new object[] { CompanyMasterClass.CompanyID };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("HeadMaster_Retrive", var, per, DataConnection.sConnstr);
            return ds;
        }
    }
}
