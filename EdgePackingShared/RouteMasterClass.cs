using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EdgePackingShared
{
    public class RouteMasterClass
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public String Incharge { get; set; }
        public String VehicleNumber { get; set; }
        public Decimal RouteKM { get; set; }
        public Decimal Fare { get; set; }
        public String Remark { get; set; }
        public Int32 CompanyID { get; set; }

        public bool Route_InsertUpdate(int id, string name, string incharge, string vehicle, decimal routekm, decimal fare, string remark, int companyid)
        {
            ID = id;
            Name = name;
            Incharge = incharge;
            VehicleNumber = vehicle;
            RouteKM = routekm;
            Fare = fare;
            Remark = remark;
            CompanyID = companyid;

            string[] Route_Par = new string[] { "@ID", "@Name","@Incharge", "@VehicleNumber", "@RouteKM", "@Fare", "@Remark", "@CompanyID" };
            object[] Route_Val = new object[] { ID, Name, Incharge, VehicleNumber, RouteKM, Fare, Remark, CompanyID };
            bool flag = DataConnection.RunQueryO("RouteMaster_InsertUpdate", Route_Par, Route_Val, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public bool Route_Delete(int id)
        {
            ID = id;
            string[] Route_Var = new string[] { "@ID" };
            object[] Route_Obj = new object[] { ID };
            bool flag = DataConnection.RunQueryO("RouteMaster_Delete", Route_Var, Route_Obj, DataConnection.sConnstr);
            if (flag)
                return true;
            else
                return false;
        }

        public DataSet Route_GetData()
        {
            string[] var = new string[] { "CompanyID"};
            object[] per = new object[] { CompanyMasterClass.CompanyID};
            DataSet ds = new DataSet();
            ds = DataConnection.GetSqlDataSetO("RouteMaster_Retrive", var, per, DataConnection.sConnstr);
            return ds;
        }

    }
}
