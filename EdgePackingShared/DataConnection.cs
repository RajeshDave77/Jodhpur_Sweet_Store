using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EdgePackingShared
{
    public class DataConnection
    {
        public static string sConnstr=File.ReadAllText(Application.StartupPath+"//DataConnection.txt");// = "Data Source=DESKTOP-314ET10\\SQLEXPRESS;initial catalog=EdgeDairy;Integrated Security = true";//ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //public static string sConnstr = "Data Source=Ankur;initial catalog=EdgeDairy;Integrated Security = true";//ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //Get Sql Data Reader by select query
        public static SqlDataReader GetSqlDataReader(string sProc, string[] sArgField, string[] sArgValue, string sConnStr = "")
        {
            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                SqlCommand cmd = new SqlCommand(sProc, conn);
                SqlDataReader dr = null;
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (sArgField != null)
                        for (int i = 0; i < sArgField.Count(); i++)
                            cmd.Parameters.Add(new SqlParameter(sArgField[i], sArgValue[i]));

                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();

                    dr = cmd.ExecuteReader();
                    return dr;
                }
                catch
                {
                    return dr;
                }
            }

        }

        public static SqlDataReader GetSqlDataReader_Query(string str, string sConnStr = "")
        {
            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader dr = null;
                try
                {

                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();

                    dr = cmd.ExecuteReader();
                    return dr;
                }
                catch
                {
                    return dr;
                }
            }

        }
        public static SqlDataReader GetSqlDataReaderO(string sProc, string[] sArgField, object[] sArgValue, string sConnStr = "")
        {
            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                SqlCommand cmd = new SqlCommand(sProc, conn);
                SqlDataReader dr = null;
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (sArgField != null)
                        for (int i = 0; i < sArgField.Count(); i++)
                            cmd.Parameters.Add(new SqlParameter(sArgField[i], sArgValue[i]));

                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();

                    dr = cmd.ExecuteReader();
                    return dr;
                }
                catch
                {
                    return dr;
                }
            }

        }
        //Get Sql Data Reader by select query
        public static DataSet GetSqlDataSet(string sProc, string[] sArgField, string[] sArgValue, string sConnStr = "")
        {
            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                SqlCommand cmd = new SqlCommand(sProc, conn);
                DataSet ds = null;
                ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (sArgField != null)
                        for (int i = 0; i < sArgField.Count(); i++)
                            cmd.Parameters.Add(new SqlParameter(sArgField[i], sArgValue[i]));
                    if (conn.State == ConnectionState.Open) conn.Close();
                   
                    adp.SelectCommand = cmd;
                    adp.Fill(ds);

                    return ds;
                }
                catch
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Server connection is not establish properly. Please try again.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                  return ds;
                }
            }

        }


        //Get Sql Data Reader by select query
        public static DataSet GetSqlDataSet_Query(string str, string sConnStr = "")
        {
            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                SqlCommand cmd = new SqlCommand(str, conn);
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                try
                {


                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();
                    adp.SelectCommand = cmd;
                    adp.Fill(ds);

                    return ds;
                }
                catch
                {
                    return ds;
                }
            }

        }


        public static DataSet GetSqlDataSetO(string sProc, string[] sArgField, object[] sArgValue, string sConnStr = "")
        {
            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                SqlCommand cmd = new SqlCommand(sProc, conn);
                DataSet ds = null;
                ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    if (sArgField != null)
                        for (int i = 0; i < sArgField.Count(); i++)
                            cmd.Parameters.Add(new SqlParameter(sArgField[i], sArgValue[i]));
                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();
                    adp.SelectCommand = cmd;
                    adp.Fill(ds);
                    conn.Dispose();
                    return ds;
                }
                catch
                {
                    return ds;
                }
            }

        }
        //Get Sql Data Reader by select query
        public static Boolean RunQuery(string sProc, string[] sArgField, string[] sArgValue, string sConnstr = "")
        {
            using (SqlConnection conn = new SqlConnection(sConnstr))
            {
                SqlCommand cmd = new SqlCommand(sProc, conn);

                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    if (sArgField != null)
                        for (int i = 0; i < sArgField.Count(); i++)
                            cmd.Parameters.Add(new SqlParameter(sArgField[i], sArgValue[i]));

                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    conn.Dispose();
                    return true;

                }
                catch
                {
                    return false;
                }
            }

        }
        //Get Sql Data Reader by select query
        public static Boolean RunQueryO(string sProc, string[] sArgField, object[] sArgValue, string sConnstr = "")
        {
            using (SqlConnection conn = new SqlConnection(sConnstr))
            {
                SqlCommand cmd = new SqlCommand(sProc, conn);

                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    if (sArgField != null)
                        for (int i = 0; i < sArgField.Count(); i++)
                            cmd.Parameters.Add(new SqlParameter(sArgField[i], sArgValue[i]));

                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;

                }
                catch
                {
                    return false;
                }
            }

        }

        public static Boolean RunQuery_Query(string str, string sConnStr = "")
        {
            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                SqlCommand cmd = new SqlCommand(str, conn);

                try
                {

                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch
                {
                    return false;
                }
            }

        }


        public static DataSet GetSqlDataSet_Query2(string str, string TblName, string sConnStr = "")
        {
            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                SqlCommand cmd = new SqlCommand(str, conn);
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();

                try
                {


                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();
                    adp.SelectCommand = cmd;
                    if (ds.Tables.Contains(TblName) == true)
                    {
                        ds.Tables.Remove(TblName);
                    }
                    adp.Fill(ds, TblName);
                    return ds;

                }
                catch
                {
                    return ds;
                }
            }

        }

        public static DataTable GetSqlDatatable_Query(string str, string sConnStr = "")
        {
            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                SqlCommand cmd = new SqlCommand(str, conn);
                DataTable ds = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                try
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();
                    adp.SelectCommand = cmd;
                    adp.Fill(ds);

                    return ds;
                }
                catch
                {
                    return ds;
                }
            }

        }

        public static DataSet GetSqlDataSetwithtablename(string sProc, string TblName, string[] sArgField, object[] sArgValue, string sConnStr = "")
        {
            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                SqlCommand cmd = new SqlCommand(sProc, conn);
                DataSet ds = null;
                ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                try
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    if (sArgField != null)
                        for (int i = 0; i < sArgField.Count(); i++)
                            cmd.Parameters.Add(new SqlParameter(sArgField[i], sArgValue[i]));
                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();
                    adp.SelectCommand = cmd;
                    if (ds.Tables.Contains(TblName) == true)
                    {
                        ds.Tables.Remove(TblName);
                    }
                    adp.Fill(ds, TblName);


                    return ds;
                }
                catch
                {
                    return ds;
                }
            }

        }


        public static SqlDataReader RunQueryToRead(string str, string sConnStr = "")
        {

            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataReader dr = default(SqlDataReader);


                try
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = str;
                    dr = cmd.ExecuteReader();
                    return dr;
                }
                catch
                {
                    return dr;
                }
            }


        }

        public static string sqlsclaer(string sp, string[] sArgField, object[] sArgValue, string sConnStr)
        {
            string result = "null";
            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                SqlCommand cmd = new SqlCommand(sp, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {

                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Open();

                    if (sArgField != null)
                        for (int i = 0; i < sArgField.Count(); i++)
                            cmd.Parameters.Add(new SqlParameter(sArgField[i], sArgValue[i]));
                    result = cmd.ExecuteScalar().ToString();
                    return result;

                }
                catch
                {
                    result = "error";
                }
                return result;
            }


        }

        /* Val function as in vb.net*/
        public static Int64 ValInt64(string sStr)
        {
            try
            {
                if (sStr == null)
                    return 0;
                else if (sStr == "")
                    return 0;
                else
                    return Convert.ToInt32(sStr);
            }
            catch
            {
                return 0;
            }
        }
        public static int ValInt(string sStr)
        {
            try
            {
                if (sStr == null)
                    return 0;
                else if (sStr == "")
                    return 0;
                else
                    return Convert.ToInt32(sStr);
            }
            catch
            {
                return 0;
            }
        }
        public static double ValDouble(string sStr)
        {
            try
            {
                if (sStr == null)
                    return 0;
                else if (sStr == "")
                    return 0;
                else
                    return Convert.ToDouble(sStr);
            }
            catch
            {
                return 0;
            }
        }
        /**/
        public static string ConnStr
        {
            get
            {
                return sConnstr;
            }
            set
            {
                sConnstr = value;

            }
        }
    }
}
