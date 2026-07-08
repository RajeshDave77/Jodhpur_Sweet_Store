using EdgePackingShared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EdgeVastra.Data
{
    public class GetSet
    {
        // Login Details
        public static string userId;
        public static string userLevel;
        public static string userName;
        public static string finYear;
        
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public string UserLevel
        {
            get { return userLevel; }
            set { userLevel = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string FinYear
        {
            get { return finYear; }
            set { finYear = value; }
        }
        // Master form Details
        public static string masterForm;
        public string MasterForm
        {
            get { return masterForm; }
            set { masterForm = value; }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            txtWriter.Dispose();
        }
        
        database_con db_con = new database_con();
  
        public bool Duplicate(string tblName , int id , string Name , string condition)
        {
            bool result =  false;
            try
            {
                result = db_con.valid("select * from " + tblName + " where Name = '" + Name + "' and id <>" + id + " " + condition, "", "");
            }
            catch(Exception exp)
            {
                StreamWriter w = File.AppendText(Application.StartupPath + "\\" + "log.txt");
                Log(exp.ToString(), w);
            }
            return result;
        }

        public bool CheckDuplicacy(string Name,string TableName)
        {
            bool flag = false;
            try
            {
                string[] Check_Var = new string[]{"@TableName","@Name"};
                object[] Check_Obj = new object[]{TableName,Name};
                int i = Convert.ToInt32(DataConnection.sqlsclaer("CheckDuplicacy_All_Master",Check_Var,Check_Obj,DataConnection.sConnstr));
                if (i > 0)
                {
                    flag = true;
                    return flag;
                }                  
               
            }
            catch (Exception exp)
            {
                StreamWriter w = File.AppendText(Application.StartupPath + "\\" + "log.txt");
                Log(exp.ToString(), w);
            }
            return flag;
        }
    }
}
