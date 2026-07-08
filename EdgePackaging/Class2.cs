using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace EdgePack
{
   public class database_admin_Online
    {
        string qry;
        public SqlConnection con_admin = new SqlConnection(File.ReadAllText(Application.StartupPath + "//DataConnection1.txt"));
        public SqlConnection run_con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public void chk_connection()
        {
            if (con_admin.State == ConnectionState.Open)
            {
                con_admin.Close();
                return;
            }


        }

        public void fill_combo(string qry, ComboBox comboBoxName, string value, string display)
        {

            chk_connection();
            con_admin.Open();
            if (ds.Tables.Contains("tab"))
            {
                ds.Tables.Remove("tab");
            }
            adp.SelectCommand = new SqlCommand(qry, con_admin);
            adp.Fill(ds, "tab");
            comboBoxName.DataSource = ds.Tables["tab"];
            try
            {
                comboBoxName.DisplayMember = ds.Tables["tab"].Columns[display].ToString();
                comboBoxName.ValueMember = ds.Tables["tab"].Columns[value].ToString();
            }
            catch
            { }
            con_admin.Close();

        }
        public void fill_comboNew(string qry, ComboBox comboBoxName, string value, string display, DataTable dsNew)
        {

            chk_connection();
            con_admin.Open();
            //if (dsNew.Tables.Contains("tab"))
            //{
            //    dsNew.Tables.Remove("tab");
            //}
            adp.SelectCommand = new SqlCommand(qry, con_admin);
            adp.Fill(dsNew);
            comboBoxName.DataSource = dsNew;
            comboBoxName.DisplayMember = "name";
            comboBoxName.ValueMember = "id";
            con_admin.Close();

        }
        public void grid_view(DataGridView grideName, string query)
        {
            chk_connection();

            if (con_admin.State == ConnectionState.Open)
            {
                con_admin.Close();
            }
            con_admin.Open();

            if (ds.Tables.Contains("tab"))
            {
                ds.Tables.Remove("tab");
            }
            adp.SelectCommand = new SqlCommand(query, con_admin);
            adp.Fill(ds, "tab");
            grideName.DataSource = ds.Tables["tab"];
            con_admin.Close();
        }

        public void auto_fill(string qry, ComboBox combobox_name, string database)
        {
            database_set(database);
            chk_connection();
            if (ds.Tables.Contains("tab"))
            {
                ds.Tables.Remove("tab");
            }
            adp.SelectCommand = new SqlCommand(qry, con_admin);
            adp.Fill(ds, "tab");
            combobox_name.DataSource = ds.Tables["tab"];
            combobox_name.DisplayMember = ds.Tables["tab"].Columns[1].ToString();
            combobox_name.ValueMember = ds.Tables["tab"].Columns[0].ToString();

        }

        public DataSet dataset_ret(string query)
        {

            chk_connection();
            con_admin.Open();
            if (ds.Tables.Contains("tab"))
            {
                ds.Tables.Remove("tab");
            }
            adp.SelectCommand = new SqlCommand(query, con_admin);
            adp.Fill(ds, "tab");
            con_admin.Close();
            return ds;
        }
        public DataSet dataset_ret_prodedure(string sProc, string[] sArgField, string[] sArgValue)
        {
            using (SqlConnection conn = new SqlConnection())
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

                    return ds;
                }
                catch
                {
                    return ds;
                }
            }
            
        }
      
   
        public void database_set(string database_name)
        {
            if (database_name == "admin")
            {
                // con_admin.Open();
                //cmd.Connection = con_admin;
                run_con = con_admin;
            }

            if (con_admin.State == ConnectionState.Open)
            {
                con_admin.Close();
            }
            con_admin.Open();
            cmd.Connection = con_admin;
        }
        public int get_id(string cmnd)
        {

            int req_id = 0;
            chk_connection();

            con_admin.Open();
            cmd.Connection = con_admin;
            try
            {
                cmd.CommandText = cmnd;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    req_id = Convert.ToInt32(dr[0].ToString());

                }
            }
            catch
            {
                req_id = 1;
            }
            con_admin.Close();
            return req_id;
        }

        public bool login_method(string qry, string userId, string pass)
        {
            bool res = false;
            chk_connection();
            con_admin.Open();
            cmd.Connection = con_admin;
            cmd.CommandText = qry;
            cmd.Parameters.AddWithValue("user", userId);
            cmd.Parameters.AddWithValue("pass", pass);
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                res = true;

            }
            cmd.Parameters.Clear();
            con_admin.Close();

            return res;

        }

        public string value1(string qry1)
        {
            string result = "";
            chk_connection();
            con_admin.Open();
            cmd.Connection = con_admin;
            cmd.CommandText = qry1;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = dr[0].ToString();
            }
            con_admin.Close();
            return result;
        }
        /*
        public void grid_fill(string qry1, DataGridView gname)
        {
            chk_connection();
            
            cmd.CommandText = qry1;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                gname.Rows.Add();
                gname.CurrentRow.Cells[0].Value = dr[0].ToString();
                gname.CurrentRow.Cells[1].Value = dr[1].ToString();
                gname.CurrentRow.Cells[2].Value = dr[2].ToString();
                gname.CurrentRow.Cells[3].Value = dr[3].ToString();
            }
            con_admin.Close();
        }
      
        public string values(string qry1)
        {
            string result = "";
            chk_connection();
            con_admin.Open();
            cmd.Connection = con_admin;
            cmd.CommandText = qry1;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = dr[0].ToString();
            }
            con_admin.Close();
            return result;
        }*/
        public void suggest(string qry, TextBox textboxname, string column)
        {
            chk_connection();
            con_admin.Open();
            cmd.Connection = con_admin;
            cmd.CommandText = qry;
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocom = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocom.Add(dr.GetString(0));
            }
            textboxname.AutoCompleteCustomSource = autocom;
            con_admin.Close();
        }
        public void insert_update_delete(string qry_insert)
        {
            chk_connection();
            con_admin.Open();
            cmd.Connection = con_admin;
            cmd.CommandText = qry_insert;
            cmd.ExecuteNonQuery();
            con_admin.Close();
        }
        public void execute_multiple_qury(string mulqry1, string mulqry2, string mulqry3)
        {
            using (con_admin)
            {
                List<string> sqlCommandList = new List<string>();
                con_admin.Open();
                foreach (var commandString in sqlCommandList)
                {
                    cmd.Connection = con_admin;
                    cmd.CommandText = mulqry1;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = mulqry2;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = mulqry3;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void suuget_append2(string qry1, string qry2, ComboBox textBoxName, string column1, string clm5)
        {
            chk_connection();
            con_admin.Open();
            cmd.Connection = con_admin;
            cmd.CommandText = qry1;
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                str.Add(dr.GetString(0));

            }
            con_admin.Close();
            //---------------------------------------------------------------------
            chk_connection();
            con_admin.Open();
            cmd.Connection = con_admin;
            cmd.CommandText = qry2;
            dr = cmd.ExecuteReader();
            //AutoCompleteStringCollection str = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                str.Add(dr.GetString(0));

            }
            textBoxName.AutoCompleteCustomSource = str;
            con_admin.Close();
        }
        public void suuget_append3(string qry1, string qry2, string qry3, ComboBox textBoxName, string column1, string clm5, string column)
        {
            chk_connection();
            con_admin.Open();
            cmd.Connection = con_admin;
            cmd.CommandText = qry1;
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                str.Add(dr.GetString(0));

            }
            con_admin.Close();
            //---------------------------------------------------------------------
            chk_connection();
            con_admin.Open();
            cmd.Connection = con_admin;
            cmd.CommandText = qry2;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                str.Add(dr.GetString(0));

            }
            textBoxName.AutoCompleteCustomSource = str;
            con_admin.Close();
            //----------------------------------------------
            chk_connection();
            con_admin.Open();
            cmd.Connection = con_admin;
            cmd.CommandText = qry3;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                str.Add(dr.GetString(0));

            }
            con_admin.Close();
        }

        public DataSet retrieve(string qry_retreive)
        {
            chk_connection();
            if (ds.Tables.Contains("tab"))
            {
                ds.Tables.Remove("tab");
            }
            adp.SelectCommand = new SqlCommand(qry_retreive, con_admin);
            adp.Fill(ds, "tab");
            con_admin.Close();
            return ds;
        }

        public void fill_list(string qry_fill, ListBox lb_name, string column)
        {
            lb_name.Items.Clear();
            DataSet ds1 = new DataSet();
            ds1 = retrieve(qry_fill);
            int i = 0;
            int rows = Convert.ToInt32(ds1.Tables["tab"].Rows.Count.ToString());
            for (i = 0; i < rows; i++)
            {
                lb_name.Items.Add(ds1.Tables["tab"].Rows[i][column].ToString());

            }
        }

    }
}
