using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EdgeVastra.Data;
using System.Threading;
using EdgePackingShared;
using EdgePackaging;
using EdgePack;
namespace EdgeVastra
{
    public partial class Form1 : Form
    {
        database_admin obj_class = new database_admin();
        public static int UserID = 0;
        public static int CompanyID = 0;
        public static int LoginUserID = 0;
        public static int utype;
        public static string CurrFinYear = "";
        public static string PartyAddress = "";
        public static string PartyGST = "";
        public static string PartyState = "";
        public static string username = "";
        public static int LTag=0;
        public static int Godownid = 0;
        public static int PID = 0;
        public static int StockTag = 0;
        public static string PUnit = "";
        public Form1()
        {
            InitializeComponent();
        }
        public static string SingleCode(string Str_Value = "")
        {
            string functionReturnValue = null;
            if (Str_Value == null)
            {
                return functionReturnValue = "";
            }
            else
            {
                return functionReturnValue = Str_Value.Replace("'", "''");
            }

        }
        public void panelEx1_Click(object sender, EventArgs e)
        {

        }


       
            public void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        public void btnExit_Click(object sender, EventArgs e)
        {           
            
            if (MessageBox.Show("Are you sure want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
                return;
            }
        }

        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                return;
            }
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                MessageBox.Show("Fill Username Details", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtname.Focus();
                return;

            }

            if (txtpass.Text == "")
            {
                MessageBox.Show("Fill Password Details", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtpass.Focus();
                return;

            }

        //    bool logincheck=obj_class.login_method("select MobileNo from User_Master where UserName='" + textBoxX1.Text + "' and Password= '" + textBoxX2.Text + "'", textBoxX1.Text, textBoxX2.Text);
           // if (logincheck == true)
           // {
               
          //  }
          // // else 
          ////  {
          //      MessageBox.Show("UserName Or Password Incorrect");
          //      return;
          //  }


           // frmUser use = new frmUser(txtname.Text);

            
            if (Login())
            {
                DataSet rstemp = new DataSet();
                rstemp = obj_class.dataset_ret("select user_master.* from user_master where UserName='" + txtname.Text + "' and Password='" + txtpass.Text + "'");
                CompanyID = Convert.ToInt32(rstemp.Tables[0].Rows[0]["godownid"].ToString());
                Godownid = Convert.ToInt32(rstemp.Tables[0].Rows[0]["companyid"].ToString());
                UserID = Convert.ToInt32(rstemp.Tables[0].Rows[0]["id"].ToString());
                utype = Convert.ToInt32(rstemp.Tables[0].Rows[0]["usertype"].ToString());
             ////   Godownid = Convert.ToInt32(obj_class.value1("select godownid from User_Master where UserName='" + txtname.Text + "' and Password='" + txtpass.Text + "'"));
             //   CompanyID = Convert.ToInt32(obj_class.value1("select godownid from User_Master where UserName='" + txtname.Text + "' and Password='" + txtpass.Text + "'"));
             //   UserID = Convert.ToInt32(obj_class.value1("select ID from User_Master where UserName='" + txtname.Text + "' and Password='" + txtpass.Text + "' and godownid=" + CompanyID + ""));
                LoginUserID = UserID;
                GetSet em = new GetSet();
                          em.UserId = txtname.Text;
                em.UserName = txtname.Text;
                username = txtname.Text;
              CompanyMasterClass.CompanyID = CompanyID;
               // em.UserLevel = "ADMIN";
             //   em.FinYear =;
               MainIndex MI = new MainIndex();
             
                this.Hide();
                MI.Show();
               
            }
            else
            {
                MessageBox.Show("Invalid user name or password!", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                txtname.Focus();
                txtpass.Clear();
            }
            
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            //FillCombo();
            //GetCompany();
            //comboBoxEx1.Text = "2017-18";
            string FinYearStart = "";
            string FinYearEnd = "";
            int Year1 = 0;
            int Year2 = 0;
            if ((DateTime.Today.Month > 3))
            {
                Year1 = DateTime.Today.Year;
                Year2 = (DateTime.Today.Year + 1);
                FinYearStart = ("" + Convert.ToInt32(Year1));
                FinYearEnd = ("" + Convert.ToInt32(Year2));
            }
            else
            {
                Year1 = (DateTime.Today.Year - 1);
                Year2 = DateTime.Today.Year;
                FinYearStart = ("" + Convert.ToInt32(Year1));
                FinYearEnd = ("" + Convert.ToInt32(Year2));
            }

            CurrFinYear = (FinYearStart + ("-" + FinYearEnd));
            
        }
        CompanyMasterClass companyclass = new CompanyMasterClass();
        public void GetCompany()
        {
            //try
            //{
            //    DataSet ds = new DataSet();
            //    ds = companyclass.Company_GetData();
            //    cmbCompany.DataSource = ds.Tables[0];
            //    cmbCompany.DisplayMember = "Name";
            //    cmbCompany.ValueMember = "ID";
            //}
            //catch(Exception ex)
            //{

            //}
            
        }
        public void FillCombo()
        {
            //comboBoxEx1.Items.Add("2015-16");
            //comboBoxEx1.Items.Add("2016-17");
            //comboBoxEx1.Items.Add("2017-18");
            //comboBoxEx1.Items.Add("2018-19");
            
        }
        database_con db_con = new database_con();
        UserMasterClass userclass = new UserMasterClass();
        public bool Login()
        {
            try
            {

                bool result = true;
                DataSet ds = new DataSet();
                ds = userclass.User_Login(txtname.Text, txtpass.Text);
                UserMasterClass.UType = Convert.ToInt32(ds.Tables[0].Rows[0]["UserType"].ToString());
                utype = UserMasterClass.UType;
                //result = db_con.valid("Select * from users where username = @var1 and password = @var2", textBoxX1.Text, textBoxX2.Text);
                return result;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        public void textBoxX1_Enter(object sender, EventArgs e)
        {
            txtname.SelectAll();
        }

        public void textBoxX2_Enter(object sender, EventArgs e)
        {
            txtpass.SelectAll();
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panelEx2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        
    }
}
