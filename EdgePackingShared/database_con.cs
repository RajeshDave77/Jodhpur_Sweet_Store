using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


using EdgePackingShared;
using System.IO;
using System.Windows.Forms;


namespace FinanceManagement
{
    class database_con
    {
        //System.Configuration.Configuration rootWebconfig  = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/My")
        public static string sConnstr = File.ReadAllText(Application.StartupPath + "//DataConnection.txt");
        public static SqlConnection con = new SqlConnection(sConnstr);
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataReader dr;
        DataSet ds = new DataSet();
        public void con_chk()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
                
        public bool valid(string qry, string var1, string var2)
        {
            bool rslt = false;
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = qry;
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            if (var2 != "")
            {
                cmd.Parameters.AddWithValue("@var2", var2);
            }
            cmd.Parameters.AddWithValue("@var1", var1);
            dr = cmd.ExecuteReader();
            if (dr.Read()==true)
            {
                rslt = true;
            }
            cmd.Parameters.Clear();
            con.Close();
            return rslt;
        }
        public int getId(string qry)
        {
            int id = 0;
            con_chk();
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = qry;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                try
                {
                    id = Convert.ToInt32(dr[0].ToString());
                }
                catch
                {
                    id = 1;
                }
            }
            return id;
        }
        public DataSet all_values(string qry)
        {
            
            con_chk();
            if (ds.Tables.Contains("tab"))
            {
                ds.Tables.Remove("tab");
            }
            SqlDataAdapter adp = new SqlDataAdapter(qry, con);
            adp.Fill(ds, "tab");
            return ds;
        }
        public DataTable  allVal(string CommandText , CommandType type , decimal param)
        {
            DataTable ds = new DataTable();
            SqlConnection cn = new SqlConnection(DataConnection.sConnstr);
            SqlCommand sqlCmd = new SqlCommand(CommandText, cn);
            cn.Open();
            sqlCmd.CommandType = type;
            sqlCmd.CommandText = CommandText;
            sqlCmd.Parameters.AddWithValue("@Id", param);
            dr = sqlCmd.ExecuteReader();
            ds.Load(dr);
            return ds;
        }
        public DataTable allVal(string CommandText, CommandType type)
        {
            DataTable ds = new DataTable();
            SqlConnection cn = new SqlConnection(DataConnection.sConnstr);
            SqlCommand sqlCmd = new SqlCommand(CommandText, cn);
            cn.Open();
            sqlCmd.CommandType = type;
            sqlCmd.CommandText = CommandText;
            dr = sqlCmd.ExecuteReader();
            ds.Load(dr);
            return ds;
        }
        
        public bool chkEntry(string tblName , string clmName , string val)
        {
            bool rslt = false;
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = "select * from " + tblName + " where " + clmName + " = '" + val + "' " ;
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                rslt = true;
            }
            con.Close();
            return rslt;
        }
        public bool chkEntry(string tblName, string clmName, string val , string id)
        {
            bool rslt = false;
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = "select * from " + tblName + " where " + clmName + " = '" + val + "' and Id != '" + id + "' ";
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                rslt = true;
            }
            con.Close();
            return rslt;
        }
        public void insert_update_delete(string qry, string[] param, int size)
        {
                con_chk();
                cmd.Connection = con;
                for (int i = 0; i < size; i++)
                {
                    int j = i + 1;
                    string value = "@var" + j;
                    string val1 = param[i];
                    cmd.Parameters.AddWithValue(value, param[i].ToString());
                }
                cmd.CommandText = qry;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();   
        }
        public void insert_update_delete(string qry)
        {
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = qry;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception exp)
            {
                throw exp;
            }
            con.Close();
        }
        public string single_value(string query)
        {
            string val = "";
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                val = dr[0].ToString();
            }
            con.Close();
            return val;
        }
       
    }
}
