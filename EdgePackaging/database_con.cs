using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace EdgeVastra
{
 public   class database_con
    {
        public static string sConnstr = File.ReadAllText(Application.StartupPath + "//DataConnection.txt");
   public SqlConnection con = new SqlConnection(sConnstr);
   public SqlCommand cmd = new SqlCommand();
   public SqlDataReader dr;
   public DataSet ds = new DataSet();
    public  SqlDataAdapter da = new SqlDataAdapter();
        public void con_chk()
        {
            //con = new SqlConnection(sr.ReadToEnd());
            if (con.State == ConnectionState.Open)
            {
               
                con.Close();
            }
            con.Open();
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
            catch (Exception exp)
            {
                throw exp;
            }
            con.Close();
        }
        public bool valid(string qry, string var1, string var2)
        {
            bool rslt = false;
            con_chk();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = qry;
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
            cmd.Connection = con;
            cmd.CommandText = qry;
            cmd.CommandType = CommandType.Text;
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
        public void fill_combo(string qry, ComboBox ComboBoxName, string column)
        {
            ComboBoxName.Items.Clear(); 
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = qry;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ComboBoxName.Items.Add(dr[column].ToString());
                
            }
            con.Close();
        }
        public void fill_combo(string qry, ComboBox ComboBoxName, string clmShow , string clmValue , CommandType ct)
        {
            DataSet ds = new DataSet();
            if (ds.Tables.Contains("tab"))
            {
                ds.Tables.Remove("tab");
            }
         //   ComboBoxName.Items.Clear();
            con_chk();
            SqlDataAdapter adp = new SqlDataAdapter(qry, con);
            adp.SelectCommand.CommandType = ct;
            adp.Fill(ds, "tab");
            ComboBoxName.DataSource = ds.Tables[0];
            ComboBoxName.DisplayMember = clmShow;
            ComboBoxName.ValueMember = clmValue;
            con.Close();
        }

        public void fill_list(string qry, ListBox lbName, string clmShow , string clmValue , CommandType ct)
        {
            if (ds.Tables.Contains("tab"))
            {
                ds.Tables.Remove("tab");
            }
            con_chk();
            SqlDataAdapter adp = new SqlDataAdapter(qry, con);
            adp.SelectCommand.CommandType = ct;
            adp.Fill(ds, "tab");
            lbName.DataSource = ds.Tables[0];
            lbName.DisplayMember = clmShow;
            lbName.ValueMember = clmValue; 
            
            con.Close();
        }
        public void fill_list(string qry, ListView lbName, string clm)
        {
            lbName.Items.Clear();
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = qry;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lbName.Items.Add(dr[clm].ToString());
            }
            
            con.Close();
        }
        public void fill_list(string qry, ListBox lbName, string clm)
        {
            lbName.Items.Clear();
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = qry;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lbName.Items.Add(dr[clm].ToString());
            }

            con.Close();
        }
      
        public void insert_update_delete(string qry , CommandType ct , string[] paramName , string[] paramVal)
        {
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = qry;
            cmd.CommandType = ct;
            int counter = paramName.Length;
            for (int i = 0; i < counter; i++)
            {
                cmd.Parameters.Add(paramName[i].ToString(), paramVal[i].ToString());
            }
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.Close(); 
        }
        public void suggest_combo(string qry, ComboBox cb_name, string clm)
        {
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = qry;
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection cl = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                cl.Add(dr.GetString(0));
            }
            cb_name.AutoCompleteCustomSource = cl;
            con.Close();
        }
        public void suuget_append(string qry, TextBox textBoxName, string column)
        {
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = qry;
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                str.Add(dr.GetString(0));
            }
            textBoxName.AutoCompleteCustomSource = str;
            con.Close();
        }
        public void suuget_append1(string qry, TextBox textBoxName, string column1, string clm2 , string clm3 ,string clm4 )
        {
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = qry;
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                str.Add(dr.GetString(0));
                str.Add(dr.GetString(1));
                str.Add(dr.GetString(2));
                str.Add(dr.GetString(3));
            }
            textBoxName.AutoCompleteCustomSource = str;
            con.Close();
        }
        public void suuget_append2(string qry1, string qry2, TextBox textBoxName, string column1, string clm2, string clm3, string clm4, string clm5, string clm6, string clm7, string clm8)
        {
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = qry1;
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                str.Add(dr.GetString(0));
                str.Add(dr.GetString(1));
                str.Add(dr.GetString(2));
                str.Add(dr.GetString(3));
            }
            con.Close();
            //---------------------------------------------------------------------
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = qry2;
            dr = cmd.ExecuteReader();
            //AutoCompleteStringCollection str = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                str.Add(dr.GetString(4));
                str.Add(dr.GetString(5));
                str.Add(dr.GetString(6));
                str.Add(dr.GetString(7));
            }
            textBoxName.AutoCompleteCustomSource = str;
            con.Close();
        }

        public void fill_DataGrid(string qry,CommandType ct , string[] paramName , string[] paramVal , DataGridView DGirdName)
        {
            con_chk();
            if (ds.Tables.Contains("tab"))
            {
                ds.Tables.Remove("tab");
            }
            SqlDataAdapter adp = new SqlDataAdapter(qry , con);
            adp.SelectCommand.CommandType = ct;
            for(int i = 0 ; i < paramName.Length ; i ++)
            {
                adp.SelectCommand.Parameters.Add(paramName[i].ToString() , paramVal[i].ToString());
            }
            adp.Fill(ds, "tab");
            DGirdName.DataSource = ds.Tables["tab"];
            adp.SelectCommand.Parameters.Clear();
            con.Close();
        }
        public string single_value(string query)
        {
            string val = "";
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = query;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                val = dr[0].ToString();
            }
            con.Close();
            return val;
        }
        //public string single_value(string query , CommandType ctype)
        //{
        //    string val = "";
        //    con_chk();
        //    cmd.Connection = con;
        //    cmd.CommandText = query;
        //    dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        val = dr[0].ToString();
        //    }
        //    con.Close();
        //    return val;
        //}
        public string single_value(string query , CommandType ct)
        {
            string val = "";
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.CommandType = ct;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                val = dr[0].ToString();
            }
            con.Close();
            return val;
        }
        public string single_value(string query, CommandType ct , string[] paramName , string[] paramVal)
        {
            string val = "";
            con_chk();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.CommandType = ct;
            for (int i = 0; i < paramVal.Length; i++)
            {
                cmd.Parameters.AddWithValue(paramName[i].ToString(), paramVal[i].ToString());
            }
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                val = dr[0].ToString();
            }
            cmd.Parameters.Clear();
            con.Close();
            return val;
        }
    }
}
