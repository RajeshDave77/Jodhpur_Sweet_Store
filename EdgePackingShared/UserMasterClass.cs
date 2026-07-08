using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EdgePackingShared
{
    public class UserMasterClass
    {
        public static Int32 UserID { get; set; }
        public static Int32 UType { get; set; }
        public Int32 ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Int32 UserType { get; set; }

        public DataSet User_Login(string username,string password)
        {
            DataSet ds = new DataSet();
            string[] User_var = new string[] {"@UserName","@Password" };
            string[] User_Per = new string[] { username, password };
            ds = DataConnection.GetSqlDataSet("Login_Check",User_var,User_Per,DataConnection.sConnstr);
            return ds;

        }

        public bool UserMaster_InsertUpdate(int id, string name, string username, string password, string Mob, int companyid, int godownid, int UserType)
        {
            ID = id;
            Name = name;
            UserName = username;
            Password = password;
                       
            string[] User_Var = new string[] { "@ID", "@Name", "@UserName", "@Password", "@UserType","@Mob","@CompanyID","@godownid"};
            object[] User_Obj = new object[] { ID, Name, UserName, Password, UserType,Mob,companyid,godownid};
            bool flag = DataConnection.RunQueryO("UserMaster_InsertUpdate", User_Var, User_Obj, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public bool UserMaster_Delete(int id)
        {
            ID = id;
            string[] User_Var = new string[] { "@ID" };
            object[] User_Obj = new object[] { ID };
            bool flag = DataConnection.RunQueryO("UserMaster_Delete", User_Var, User_Obj, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public DataSet UserMaster_GetData()
        {
            string[] var = new string[] { "@CompanyID" };
            object[] per = new object[] { CompanyMasterClass.CompanyID };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("UserMaster_Retrive", var, per, DataConnection.sConnstr);
            return ds;
        }
        public DataSet UserMaster_GetDatasearch(string name,int id)
        {
            string[] var = new string[] { "@Name", "@userid" };
            object[] per = new object[] { name,id };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("UserMaster_Search", var, per, DataConnection.sConnstr);
            return ds;
        }
        public DataSet UserMaster_GetTypeData(int utype)
        {
            string[] var = new string[] { "@usertype" };
            object[] per = new object[] { utype };
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("usertypesearch", var, per, DataConnection.sConnstr);
            return ds;
        }
    }
}
