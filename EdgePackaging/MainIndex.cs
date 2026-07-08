using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EdgeVastra.Data;
using EdgePackaging;
using EdgePackingShared;
using System.Diagnostics;
using EdgePackaging;
using EdgePack;
using System.Data.SqlClient;
using System.IO;
namespace EdgeVastra
{
    public partial class MainIndex : Form
    {
        public MainIndex()
        {
            InitializeComponent();
        }
        public static int dr = 0;
        database_admin da = new database_admin();
        public static int tax1 = 0;
        private void buttonItem13_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
                return;
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }

        private void MainIndex_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            //TopLevel for form is set to false
          
            //Added new TabPage
            //TabPage tbp = new TabPage();
            //tbp.Text = "Product Master";
            //TabItem newTab = tabControl1.CreateTab("Product Master");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //ProductMaster textBox = new ProductMaster();
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0,0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //childForm.WindowState = FormWindowState.Maximized;
            //childForm.Show();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            //tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            //tabControl1.Tabs.Remove(tabControl1.SelectedTab);
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {

        }
        public static Int32 companyid = CompanyMasterClass.CompanyID;
        public static string UserFullName = "";
        public static string CompanyName = "";
        private void MainIndex_Load(object sender, EventArgs e)
        {
            try
            {


                CompanyName = da.value1("select name from ledger_Master where id=" + companyid + " ");
                UserFullName = da.value1("select (name)  as name from user_Master where id=" + Form1.LoginUserID);
                GetSet em = new GetSet();
                string rstr = " Developed By : Edge Softwares (9828584748)";
                string rstr1 = " Curr: Fin. Year : " + Form1.CurrFinYear;
              string rstr2 = " Location : " + CompanyName;
                string rstr4 = "Welcome:  " + UserFullName;
                this.Text = rstr4.PadRight(40) + " " + rstr2.PadRight(40) +rstr1.PadRight(40)+ rstr;
               
             //   tabControl2.Tabs.Remove(tabItem1);
                //string fileName = Application.StartupPath + "\\Image\\surbhicow.gif";
                //tabControl2.BackgroundImage = Image.FromFile(fileName);
                //tabControl2.BackgroundImageLayout = ImageLayout.Stretch;
               //int screentag =  Convert.ToInt32( da.value1("select screentag from Company_Master where id=" + companyid + " "));
               // if(screentag==1)
               // {
               //     //frmSelectCompany frmselectcompany = new frmSelectCompany();
               //     //frmselectcompany.ShowDialog(this);
               //     frmSelectFinYear frmselectfinyear = new frmSelectFinYear();
                    
               //     frmselectfinyear.ShowDialog(this);
               // }
               if(Form1.utype==2)
               {
                   mnuMaster.Visible = false;
                   //mnuChallan.Visible = false;
                   //mnuPReturn.Visible = false;
                   mnuStock.Visible = false;
               }
               else if(Form1.utype==1)
               {
                   mnuMaster.Visible = false;
                   mnuPayment.Visible = false;
                   mnuEntry1.Visible = false;
                   toolStripSeparator17.Visible = false;
               }
               ShowStock();
               ShowMinOrder();
               ShowStockFav();
            }
            catch (Exception ex)
            {

            }
        }

       
        private void buttonItem3_Click(object sender, EventArgs e)
        {
        
        }


        private void buttonItem2_Click(object sender, EventArgs e)
        {
            // // Open Master Form with Department Master
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Dept";
            //MasterForm mf = new MasterForm();
            //mf.Show();
            TabItem newTab = tabControl2.CreateTab("Company Master");
            TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //PartyMaster textBox = new PartyMaster();
            frmCompanyMaster textBox = new frmCompanyMaster(this);
            textBox.Dock = DockStyle.Fill;
            textBox.TopLevel = false;
            textBox.TopMost = true;
            textBox.Location = new Point(0, 0);
            panel.Controls.Add(textBox);
            //Added form to tabpage
            textBox.WindowState = FormWindowState.Maximized;
            textBox.Show();
            //ProductMaster PM = new ProductMaster();
            //PM.ShowDialog();
        }

        private void Brand_Click(object sender, EventArgs e)
        {
            //// Open Master Form with Brand Master
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Brand";
            //MasterForm mf = new MasterForm();
            //mf.Show();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            //// Open Master Form with Quality Master
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Qual";
            //MasterForm mf = new MasterForm();
            //mf.Show();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            //// Open Master Form with Style Master
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Style";
            //MasterForm mf = new MasterForm();
            //mf.Show();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
        //    // Open Master Form with Shade Master
        //    GetSet GS = new GetSet();
        //    GS.MasterForm = "Shade";
        //    MasterForm mf = new MasterForm();
        //    mf.Show();
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            //// Open Master Form with Size Master
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Size";
            //MasterForm mf = new MasterForm();
            //mf.Show();
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            //// Open Master Form with Color Master
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Color";
            //MasterForm mf = new MasterForm();
            //mf.Show();
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            //// Open Master Form with Counts Master
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Count";
            //MasterForm mf = new MasterForm();
            //mf.Show();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            //// Open Master Form with Composition Master
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Comp";
            //MasterForm mf = new MasterForm();
            //mf.Show();
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {

            //// Open Master Form with Design Master
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Design";
            //MasterForm mf = new MasterForm();
            //mf.Show();
        }

        public void changeText(string s)
        {
        }


      

        private void buttonItem11_Click(object sender, EventArgs e)
        {

        }

        private void ribbonTabItem2_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Ledger Master");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //ProductMaster textBox = new ProductMaster();
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
            ////ProductMaster PM = new ProductMaster();
            ////PM.ShowDialog();
        }

        private void Area_Click(object sender, EventArgs e)
        {
        //    GetSet GS = new GetSet();
        //    GS.MasterForm = "Area_Master";
        //    MasterForm mf = new MasterForm();
        //    mf.Show();
        }

        private void btnCity_Click(object sender, EventArgs e)
        {
        //    GetSet GS = new GetSet();
        //    GS.MasterForm = "City_Master";
        //    MasterForm mf = new MasterForm();
        //    mf.Show();
        }

        private void btnState_Click(object sender, EventArgs e)
        {
            //GetSet GS = new GetSet();
            //GS.MasterForm = "State_Master";
            //MasterForm mf = new MasterForm();
            //mf.Show();
        }

        private void btnCountry_Click(object sender, EventArgs e)
        {
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Country_Master";
            //MasterForm mf = new MasterForm();
            //mf.Show();
        }

        private void btnCompanyMaster_Click(object sender, EventArgs e)
        {
            TabItem newTab = tabControl2.CreateTab("Company Master");
            tabControl2.SelectedTab = newTab;
            TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            frmCompanyMaster textBox = new frmCompanyMaster(this);
            textBox.Dock = DockStyle.Fill;
            textBox.TopLevel = false;
            textBox.TopMost = true;
            textBox.Location = new Point(0, 0);
            panel.Controls.Add(textBox);
            //Added form to tabpage
            textBox.WindowState = FormWindowState.Maximized;
            textBox.Show();

        }

        private void btnRouteMaster_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Route Master");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //frmroute textBox = new frmroute(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnGroupMaster_Click(object sender, EventArgs e)
        {

            try
            {
                GetSet GS = new GetSet();
                GS.MasterForm = "InventoryGroup_Master";
                TabItem newTab = tabControl2.CreateTab("Inventory Group Master");
                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                tabControl2.SelectedTab = newTab;
                frmmastercommon textBox = new frmmastercommon(this);
                textBox.Dock = DockStyle.Fill;
                textBox.TopLevel = false;
                textBox.TopMost = true;
                textBox.Location = new Point(0, 0);
                panel.Controls.Add(textBox);
                //Added form to tabpage
                textBox.WindowState = FormWindowState.Maximized;
                textBox.Show();
            }
            catch { }

        }

        private void btnUnitMaster_Click(object sender, EventArgs e)
        {
            try
            {

                GetSet GS = new GetSet();
                GS.MasterForm = "InventoryUnit_Master";
                TabItem newTab = tabControl2.CreateTab("Inventory Unit Master");
                tabControl2.SelectedTab = newTab;
                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                frmmastercommon textBox = new frmmastercommon(this);
                textBox.Dock = DockStyle.Fill;
                textBox.TopLevel = false;
                textBox.TopMost = true;
                textBox.Location = new Point(0, 0);
                panel.Controls.Add(textBox);
                //Added form to tabpage
                textBox.WindowState = FormWindowState.Maximized;
                textBox.Show();
            }
            catch { }
            //}
        }

        private void btnMilkMaster_Click(object sender, EventArgs e)
        {
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Milk_Master";
            //TabItem newTab = tabControl2.CreateTab("Milk Type Master");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //frmmastercommon textBox = new frmmastercommon(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnSessionMaster_Click(object sender, EventArgs e)
        {
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Session_Master";
            //TabItem newTab = tabControl2.CreateTab("Session/Shift Master");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //frmmastercommon textBox = new frmmastercommon(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        

        private void buttonItem14_Click(object sender, EventArgs e)
        {

        }

        private void rbnMenuExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
                return;
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            TabItem newTab = tabControl2.CreateTab("Inventory Master");
            TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            tabControl2.SelectedTab = newTab;
            frminventory textBox = new frminventory(this);
            textBox.Dock = DockStyle.Fill;
            textBox.TopLevel = false;
            textBox.TopMost = true;
            textBox.Location = new Point(0, 0);
            panel.Controls.Add(textBox);
            //Added form to tabpage
            textBox.WindowState = FormWindowState.Maximized;
            textBox.Show();
        }

        private void btnRateList_Click(object sender, EventArgs e)
        {

            //TabItem RateList = tabControl2.CreateTab("Rate List Master");
            //TabControlPanel panel = (TabControlPanel)RateList.AttachedControl;
            //tabControl2.SelectedTab = RateList;
            //RateListMaster textBox = new RateListMaster(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
            //textBox.Focus();

        }
        public static string formname = "";
        private void btnMilkProcurement_Click(object sender, EventArgs e)
        {
            
            try
            {

                formname = "Purchase";
                TabItem newTab = tabControl2.CreateTab("Purchase");
                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                tabControl2.SelectedTab = newTab;
                PurchaseInvoice textBox = new PurchaseInvoice(this);
                textBox.Dock = DockStyle.Fill;
                textBox.TopLevel = false;
                textBox.TopMost = true;
                textBox.Location = new Point(0, 0);
                panel.Controls.Add(textBox);
                //Added form to tabpage
                textBox.WindowState = FormWindowState.Maximized;
                textBox.Show();
            }
            catch { }
        }

        private void btnHead_Click(object sender, EventArgs e)
        {
            TabItem newTab = tabControl2.CreateTab("Account Head Master");
            TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            tabControl2.SelectedTab = newTab;
            frmHeadMaster textBox = new frmHeadMaster(this);
            textBox.Dock = DockStyle.Fill;
            textBox.TopLevel = false;
            textBox.TopMost = true;
            textBox.Location = new Point(0, 0);
            panel.Controls.Add(textBox);
            //Added form to tabpage
            textBox.WindowState = FormWindowState.Maximized;
            textBox.Show();
            textBox.Focus();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
        //    GetSet GS = new GetSet();
        //    GS.MasterForm = "Purchase";
        //    TabItem newTab = tabControl2.CreateTab("Purchase");
        //    tabControl2.SelectedTab = newTab;
        //    TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
        //    frmtransactionWithTextBox textBox = new frmtransactionWithTextBox(this);
        //    textBox.Dock = DockStyle.Fill;
        //    textBox.TopLevel = false;
        //    textBox.TopMost = true;
        //    textBox.Location = new Point(0, 0);
        //    panel.Controls.Add(textBox);
        //    //Added form to tabpage
        //    textBox.WindowState = FormWindowState.Maximized;
        //    textBox.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Sales";
            //TabItem newTab = tabControl2.CreateTab("Sales");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //frmtransactionSalesWithTextBox textBox = new frmtransactionSalesWithTextBox(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnPurchaseReturn_Click(object sender, EventArgs e)
        {
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Purchase Return";
            //TabItem newTab = tabControl2.CreateTab("Purchase Return");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //frmtransaction textBox = new frmtransaction(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnSalesReturn_Click(object sender, EventArgs e)
        {
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Sales Return";
            //TabItem newTab = tabControl2.CreateTab("Sales Return");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //frmtransaction textBox = new frmtransaction(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

     

        

        private void ribbonTabItem3_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {

            //TabItem newTab = tabControl2.CreateTab("Milk Despatch");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //frmmilkdesp textBox = new frmmilkdesp(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void buttonItem4_Click_1(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("MIS Reports");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //frmmisreportsnew textBox = new frmmisreportsnew();
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }



        private void ribbonBar16_ItemClick(object sender, EventArgs e)
        {

        }

       

        private void buttonItem2_Click_1(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Milk Challan");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //frmBulkDispachChallan textBox = new frmBulkDispachChallan(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

      

        private void btnAmmy_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Paper Rate Master");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //PaperRateMaster textBox = new PaperRateMaster();
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
            //textBox.Focus();
        }

        private void btnShowMyPC_Click(object sender, EventArgs e)
        {
          
        }

        private void buttonItem3_Click_1(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("MIS Reports");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //frmmisreportsnew textBox = new frmmisreportsnew();
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void buttonItem18_Click_1(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Milk Despatch");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //frmmilkdesp textBox = new frmmilkdesp(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void ribbonBar10_ItemClick(object sender, EventArgs e)
        {

        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMilkProcSearch_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Member Milk Procurement");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //frmmilkprocSearch textBox = new frmmilkprocSearch(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void ribbonBar23_ItemClick(object sender, EventArgs e)
        {

        }

        private void btnTrailLedgerWise_Click(object sender, EventArgs e)
        {

        }

        private void btnTrailGroupWise_Click(object sender, EventArgs e)
        {

            //TabItem newTab = tabControl2.CreateTab("Trail Balance");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //TrailBalanceForm textBox = new TrailBalanceForm(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            //Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();

        }

        private void btnTrailGroupDetailWise_Click(object sender, EventArgs e)
        {
            //TrailBalanceClass.ProcedureName = "Trial_by_Date";
            //TabItem newTab = tabControl2.CreateTab("Trail Balance");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //TrailBalanceForm textBox = new TrailBalanceForm(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            //Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();

        }

        private void ribbonPanel6_Click(object sender, EventArgs e)
        {

        }

        private void btnP_L_Click(object sender, EventArgs e)
        {
            //TrailBalanceClass.ProcedureName = "Profit&Loss_by_Group";
            //TabItem newTab = tabControl2.CreateTab("Profit/Loss Account");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //Profit_Loss textBox = new Profit_Loss(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();

        }

        private void btnBalanceSheet_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Balance Sheet");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //BalanceSheet textBox = new BalanceSheet(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnDailyReport_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Daily Report");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //DailyReport textBox = new DailyReport(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnMemLedgerReport_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Member Ledger Report");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //MemberLedgerReport textBox = new MemberLedgerReport(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnMilkPaymentReport_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Milk Payment Summary");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //MilkMemberPayment textBox = new MilkMemberPayment(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            TabItem newTab = tabControl2.CreateTab("User Master");
            TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            tabControl2.SelectedTab = newTab;
            frmUser textBox = new frmUser(this);
            textBox.Dock = DockStyle.Fill;
            textBox.TopLevel = false;
            textBox.TopMost = true;
            textBox.Location = new Point(0, 0);
            panel.Controls.Add(textBox);
            //Added form to tabpage
            textBox.WindowState = FormWindowState.Maximized;
            textBox.Show();
        }

        private void btnSubGroup_Click(object sender, EventArgs e)
        {
            TabItem newTab = tabControl2.CreateTab("Sub Group Master");
            TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            tabControl2.SelectedTab = newTab;
            frmInvSubGroup textBox = new frmInvSubGroup(this);
            textBox.Dock = DockStyle.Fill;
            textBox.TopLevel = false;
            textBox.TopMost = true;
            textBox.Location = new Point(0, 0);
            panel.Controls.Add(textBox);
            //Added form to tabpage
            textBox.WindowState = FormWindowState.Maximized;
            textBox.Show();
        }

        private void btnFlapType_Click(object sender, EventArgs e)
        {
            //GetSet GS = new GetSet();
            //GS.MasterForm = "FlapType_Master";
            //TabItem newTab = tabControl2.CreateTab("Flap Type Master");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //frmmastercommon textBox = new frmmastercommon(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnQuality_Click(object sender, EventArgs e)
        {
            //GetSet GS = new GetSet();
            //GS.MasterForm = "Quality_Master";
            //TabItem newTab = tabControl2.CreateTab("Quality Master");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //frmmastercommon textBox = new frmmastercommon(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Sales Order");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //SalesOrder textBox = new SalesOrder(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnSheetCuting_Click(object sender, EventArgs e)
        {

            //TabItem newTab = tabControl2.CreateTab("Sheet Cutting");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //SheetCuttingMaster textBox = new SheetCuttingMaster(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnChallan_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Challan");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //Challan textBox = new Challan(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Invoice");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //Invoice textBox = new Invoice(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnPurchasePackingSlip_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Receipt");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //Purchase textBox = new Purchase(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Issue Rolls");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //IssueForm textBox = new IssueForm(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnInvoicePaperRoll_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Invoice Paper Rolls");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //bill_for_paper_roll textBox = new bill_for_paper_roll(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnProductPaper_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Sheet Cutting");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //SheetCutting textBox = new SheetCutting(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void ribbonTabItem4_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem3_Click_2(object sender, EventArgs e)
        {

        }

        private void buttonItem2_Click_2(object sender, EventArgs e)
        {
        //    TabItem newTab = tabControl2.CreateTab("Sheet Cutting Master");
        //    tabControl2.SelectedTab = newTab;
        //    TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
        //    SheetCuttingMaster textBox = new SheetCuttingMaster(this);
        //    textBox.Dock = DockStyle.Fill;
        //    textBox.TopLevel = false;
        //    textBox.TopMost = true;
        //    textBox.Location = new Point(0, 0);
        //    panel.Controls.Add(textBox);
        //    //Added form to tabpage
        //    textBox.WindowState = FormWindowState.Maximized;
        //    textBox.Show();
        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
           
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void ribbonBar5_ItemClick(object sender, EventArgs e)
        {

        }

        private void buttonItem2_Click_3(object sender, EventArgs e)
        {
            //SheetCuttingMaster.Staticorderno = "";
            //SheetCutting.id1 = "";
            //TabItem newTab = tabControl2.CreateTab("Sheet Cutting Master");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //SheetCutting textBox = new SheetCutting(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void btnCoastHeadMaster_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Cost Head Master");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //FrmCostHeadMaster textBox = new FrmCostHeadMaster();
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
            //textBox.Focus();
        }

        private void btnCostSheet_Click(object sender, EventArgs e)
        {

            //TabItem newTab = tabControl2.CreateTab("Cost Sheet Master");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //FrmCostSheet textBox = new FrmCostSheet();
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
            //textBox.Focus();
        }

        private void btnProfitCalcuation_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Profit Calculation");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //FrmProfitCalculation textBox = new FrmProfitCalculation();
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
            //textBox.Focus();

        }

        private void btnSQMCoastCal_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Cost Cal.Sqm Master");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            //CostCalSqmMaster textBox = new CostCalSqmMaster();
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
            //textBox.Focus();
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {

        }

        private void ribbonBar17_ItemClick(object sender, EventArgs e)
        {

        }

        private void btnhsn_Click(object sender, EventArgs e)
        {
            TabItem newTab = tabControl2.CreateTab("HSN Master");
            TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            tabControl2.SelectedTab = newTab;
            HSN_CategoryMaster textBox = new HSN_CategoryMaster();
            textBox.Dock = DockStyle.Fill;
            textBox.TopLevel = false;
            textBox.TopMost = true;
            textBox.Location = new Point(0, 0);
            panel.Controls.Add(textBox);
            //Added form to tabpage
            textBox.WindowState = FormWindowState.Maximized;
            textBox.Show();
            textBox.Focus();
        }

        private void ribbonBar19_ItemClick(object sender, EventArgs e)
        {

        }

        private void buttonItem8_Click_1(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Sheet Cutting");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //SheetCutting textBox = new SheetCutting(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
        }

        private void UserMaster_Click(object sender, EventArgs e)
        {
            TabItem newTab = tabControl2.CreateTab("User Master");
            tabControl2.SelectedTab = newTab;
            TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            frmUser textBox = new frmUser(this);
            textBox.Dock = DockStyle.Fill;
            textBox.TopLevel = false;
            textBox.TopMost = true;
            textBox.Location = new Point(0, 0);
            panel.Controls.Add(textBox);
            //Added form to tabpage
            textBox.WindowState = FormWindowState.Maximized;
         
            textBox.Show();
        }
        
        public void buttonItem2_Click_4(object sender, EventArgs e)
        {
            try
            {
                TabItem newTab = tabControl2.CreateTab("K.O.T.");
                tabControl2.SelectedTab = newTab;
                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                dr = 1;
                SalesForm textBox = new SalesForm();
                textBox.Dock = DockStyle.Fill;
                textBox.TopLevel = false;
                textBox.TopMost = true;
                textBox.Location = new Point(0, 0);
                panel.Controls.Add(textBox);
                //Added form to tabpage
                textBox.WindowState = FormWindowState.Maximized;

                textBox.Show();
            }
            catch { }
            
        }

        public void buttonItem9_Click_1(object sender, EventArgs e)
        {
            TabItem newTab = tabControl2.CreateTab("Bill");
            tabControl2.SelectedTab = newTab;
            TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            dr = 2;
            SalesForm textBox = new SalesForm();
            textBox.Dock = DockStyle.Fill;
            textBox.TopLevel = false;
            textBox.TopMost = true;
            textBox.Location = new Point(0, 0);
            panel.Controls.Add(textBox);
            //Added form to tabpage
            textBox.WindowState = FormWindowState.Maximized;
            textBox.Show();
            //dr = 2;
        }

       

        private void Stock_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem10_Click_1(object sender, EventArgs e)
        {

        }

        private void ribbonPanel3_Click(object sender, EventArgs e)
        {

        }

        private void btnMilkProcurement_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonItem10_Click_2(object sender, EventArgs e)
        {
            try
            {

                formname = "Consumed";
                TabItem newTab = tabControl2.CreateTab("Consumed");
                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                tabControl2.SelectedTab = newTab;
                PurchaseInvoice textBox = new PurchaseInvoice(this);
                textBox.Dock = DockStyle.Fill;
                textBox.TopLevel = false;
                textBox.TopMost = true;
                textBox.Location = new Point(0, 0);
                panel.Controls.Add(textBox);
                //Added form to tabpage
                textBox.WindowState = FormWindowState.Maximized;
                textBox.Show();
            }
            catch { }
        }

        private void buttonItem11_Click_1(object sender, EventArgs e)
        {
            try
            {

                formname = "Stock Inward";
                TabItem newTab = tabControl2.CreateTab("Stock Inward");
                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                tabControl2.SelectedTab = newTab;
                PurchaseInvoice textBox = new PurchaseInvoice(this);
                textBox.Dock = DockStyle.Fill;
                textBox.TopLevel = false;
                textBox.TopMost = true;
                textBox.Location = new Point(0, 0);
                panel.Controls.Add(textBox);
                //Added form to tabpage
                textBox.WindowState = FormWindowState.Maximized;
                textBox.Show();
            }
            catch { }
        }

        private void buttonItem14_Click_1(object sender, EventArgs e)
        {
            try
            {

                formname = "Damages";
                TabItem newTab = tabControl2.CreateTab("Damages");
                TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                tabControl2.SelectedTab = newTab;
                PurchaseInvoice textBox = new PurchaseInvoice(this);
                textBox.Dock = DockStyle.Fill;
                textBox.TopLevel = false;
                textBox.TopMost = true;
                textBox.Location = new Point(0, 0);
                panel.Controls.Add(textBox);
                //Added form to tabpage
                textBox.WindowState = FormWindowState.Maximized;
                textBox.Show();

            }
            catch { }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void stockMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ribbonTabItem1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
                return;
            }
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Company Master");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            frmCompanyMaster textBox = new frmCompanyMaster(this);
          //  textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
         //   textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            //Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            textBox.Show();
        }

        private void headToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Account Head Master");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            frmHeadMaster textBox = new frmHeadMaster(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            textBox.ShowDialog();

        //    textBox.Focus();
        }

        private void ledgerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Ledger Master");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            frmledger textBox = new frmledger(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            textBox.ShowDialog();
        }

        private void kOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsnew = new DataSet();
              Cursor.Current = Cursors.WaitCursor;

            // query for get day end date
              //dsnew = da.dataset_ret("select dayenddate from setting where id=1");
              //  if (dsnew.Tables[0].Rows.Count>0)
              //  {
              //      if (dsnew.Tables[0].Rows[0]["dayenddate"].ToString() != "")
              //      {
              //          DateTime dateCurrent = DateTime.Now.Date;

              //          if (Convert.ToDateTime(dsnew.Tables[0].Rows[0]["dayenddate"]) >= dateCurrent)
              //          {
              //              MessageBox.Show("Day End has been completed for this date. You cannot enter more kot or bills.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
              //              return;
              //          }
              //      }
              //  }
              
                //TabItem newTab = tabControl2.CreateTab("K.O.T.");
                //tabControl2.SelectedTab = newTab;
                //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                dr = 1;
                SalesForm textBox = new SalesForm();
                //textBox.Dock = DockStyle.Fill;
                //textBox.TopLevel = false;
                //textBox.TopMost = true;
                //textBox.Location = new Point(0, 0);
                //panel.Controls.Add(textBox);
                ////Added form to tabpage
                //textBox.WindowState = FormWindowState.Maximized;

                textBox.Show();

            }
            catch { }
        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // query for get day end date
            //dsnew = da.dataset_ret("select dayenddate from setting where id=1");
            //  if (dsnew.Tables[0].Rows.Count>0)
            //  {
            //      if (dsnew.Tables[0].Rows[0]["dayenddate"].ToString() != "")
            //      {
            //          DateTime dateCurrent = DateTime.Now.Date;

            //          if (Convert.ToDateTime(dsnew.Tables[0].Rows[0]["dayenddate"]) >= dateCurrent)
            //          {
            //              MessageBox.Show("Day End has been completed for this date. You cannot enter more kot or bills.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //              return;
            //          }
            //      }
            //  }
            //TabItem newTab = tabControl2.CreateTab("Bill");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            dr = 2;
            SalesForm textBox = new SalesForm();
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            textBox.Show();
        }

      

        private void consumedToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void stockInwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void damageToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void voucherMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser fu = new frmUser(this);
            fu.Show();
        }

        private void ledgerToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //GetSet GS = new GetSet();
                //GS.MasterForm = "InventoryGroup_Master";
                //TabItem newTab = tabControl2.CreateTab("Inventory Group Master");
                //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
                //tabControl2.SelectedTab = newTab;
                frmmastercommon textBox = new frmmastercommon(this);
                //textBox.Dock = DockStyle.Fill;
                //textBox.TopLevel = false;
                //textBox.TopMost = true;
                //textBox.Location = new Point(0, 0);
                //panel.Controls.Add(textBox);
                ////Added form to tabpage
                //textBox.WindowState = FormWindowState.Maximized;
                textBox.Show();
            }
            catch { }
        }

        private void subGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Sub Group Master");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            frmInvSubGroup textBox = new frmInvSubGroup(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            textBox.Show();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Inventory Master");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
            frminventory textBox = new frminventory(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            textBox.Show();
        }

        private void hSNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("HSN Master");
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //tabControl2.SelectedTab = newTab;
           // HSN_CategoryMaster textBox = new HSN_CategoryMaster();
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
      //      textBox.ShowDialog();
        }

        private void accountBookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cashToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuMaster_MouseEnter(object sender, EventArgs e)
        {
            mnuMaster.DropDown.Show();
            mnuMaster.DropDownDirection = ToolStripDropDownDirection.BelowRight;

        }

        private void mnuStock_MouseEnter(object sender, EventArgs e)
        {
            mnuStock.DropDown.Show();
            mnuStock.DropDownDirection = ToolStripDropDownDirection.BelowRight;
        }

        private void mnuSales_MouseEnter(object sender, EventArgs e)
        {
            mnuSales.DropDown.Show();
            mnuSales.DropDownDirection = ToolStripDropDownDirection.BelowRight;
        }

        private void mnuReports_MouseEnter(object sender, EventArgs e)
        {
            mnuReports.DropDown.Show();
            mnuReports.DropDownDirection = ToolStripDropDownDirection.BelowRight;
        }

        private void mnuStockReport_Click(object sender, EventArgs e)
        {
            Form1.StockTag = 1;
            frmStockReport frmstockreport = new frmStockReport();
            frmstockreport.Show();
        }

        private void mnuSalesReport_Click(object sender, EventArgs e)
        {
            frmSalesReport frmsalesreport = new frmSalesReport();
            frmsalesreport.Show();
        }

        private void ledger_Click(object sender, EventArgs e)
        {
            //TabItem newTab = tabControl2.CreateTab("Ledger Master");
            //tabControl2.SelectedTab = newTab;
            //TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            //frmledger textBox = new frmledger(this);
            //textBox.Dock = DockStyle.Fill;
            //textBox.TopLevel = false;
            //textBox.TopMost = true;
            //textBox.Location = new Point(0, 0);
            //panel.Controls.Add(textBox);
            ////Added form to tabpage
            //textBox.WindowState = FormWindowState.Maximized;
            //textBox.Show();
            frmledger frmledger = new frmledger(this);
            frmledger.Show();
        }

        private void mnuDayEnd_Click(object sender, EventArgs e)
        {
            frmDayEnd frmDayEnd = new frmDayEnd();
            frmDayEnd.Show();
        }

        private void MainIndex_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F10)
            {
                if (UserMasterClass.UType == 1)
                {
                    mnuDayEnd_Click(sender, e);
                }
               
            }
            else if (e.KeyCode == Keys.F2)
            {
                ShowStock();
                ShowMinOrder();
                ShowStockFav();
            }
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void mnuTaxReport_Click(object sender, EventArgs e)
        {
            tax1 = 1;
            frmTaxReport frmtaxreport = new frmTaxReport();
            frmtaxreport.Show();
        }

        private void barcodePrintingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBarcodePrinting frmbarcodeprinting = new frmBarcodePrinting();
            frmbarcodeprinting.Show();
        }

        private void mnuPurchaseReport_Click(object sender, EventArgs e)
        {
            frmPurchaseReport frmpurchasereport = new frmPurchaseReport();
            frmpurchasereport.Show();
        }

        private void mnuAllBillPrinting_Click(object sender, EventArgs e)
        {
            frmAllBillPrint frmallbillprinting = new frmAllBillPrint();
            frmallbillprinting.Show();
        }

        private void mnuHSNReport_Click(object sender, EventArgs e)
        {

            frmHSNReport frmhsnreport = new frmHSNReport();
            frmhsnreport.Show();
        }

        private void mnuProduction_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuOutward_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuShopTransfer_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuChallan_Click(object sender, EventArgs e)
        {
            try
            {

                formname = "Purchase";

                NewPurchaseInvoice textBox = new NewPurchaseInvoice(this);

                textBox.Show();
            }
            catch { }

        }

        private void importChallanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please check your internet connection properly before Import Challan." + Environment.NewLine + "Are you sure to Import Challan?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                SqlCommand objCMD = new SqlCommand();

                string DBFile = File.ReadAllText(Application.StartupPath + "/DataConnection1.txt");
                SqlConnection rCon1 = new SqlConnection(DBFile);
                rCon1.Open();
                DataSet rsTemp = new DataSet();
                objCMD.Connection = rCon1;
                //*******************************import data from inventorygroup_master table and insert into local database***************************************
                SqlDataAdapter rAdapter = new SqlDataAdapter("select * from inventorygroup_master  order by id", rCon1);
                rAdapter.Fill(rsTemp);
                string rStrGroup = ""; string rStrGroupID = "";
                int intLoop = 0;
                for (intLoop = 0; intLoop < rsTemp.Tables[0].Rows.Count;intLoop++ )
                {
                    if (rStrGroup=="")
                    {
                        rStrGroupID = rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        rStrGroup = "(" + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ", '" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["name"].ToString()) + "',1,1 )";
                    }
                    else
                    {
                        rStrGroupID =rStrGroupID+","+ rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        rStrGroup = rStrGroup + ",(" + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ", '" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["name"].ToString()) + "',1,1 )";
                    }
                }
                if (rStrGroup != "")
                {
                    da.insert_update_delete("delete from inventorygroup_master where id in (" + rStrGroupID + ")");
                  da.insert_update_delete(" SET IDENTITY_INSERT InventoryGroup_Master ON insert into inventorygroup_master(id,name,companyid,importtag) values " + rStrGroup + " SET IDENTITY_INSERT InventoryGroup_Master OFF");
               
                    objCMD.CommandType = CommandType.Text;
                    //objCMD.CommandText = "update InventoryGroup_Master set importtag=1 where id in (" + rStrGroupID + ")";
                    //objCMD.ExecuteNonQuery();
                }
               //****************************************************************************************************************************************
                rsTemp.Dispose(); rsTemp.Clear();
                //*******************************import data from inventorysubgroup_master table and insert into local database***************************************
                rAdapter = new SqlDataAdapter("select * from Inventory_Sub_Group_Master  order by id", rCon1);
                rAdapter.Fill(rsTemp);
                string rStrSubGroup = ""; string rStrSubGroupID = "";
                for (intLoop = 0; intLoop < rsTemp.Tables[0].Rows.Count; intLoop++)
                {
                    if (rStrSubGroup == "")
                    {
                        rStrSubGroupID = rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        rStrSubGroup = "(" + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ", '" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["name"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["ParentGroup"].ToString() + ",1,1 )";
                    }
                    else
                    {
                        rStrSubGroupID = rStrSubGroupID + "," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        rStrSubGroup = rStrSubGroup + ",(" + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ", '" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["name"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["ParentGroup"].ToString() + ",1,1 )";
                    }
                }

                if (rStrSubGroup != "")
                {
                    da.insert_update_delete("delete from Inventory_Sub_Group_Master where id in (" + rStrSubGroupID + ")");
                    da.insert_update_delete(" SET IDENTITY_INSERT Inventory_Sub_Group_Master ON insert into Inventory_Sub_Group_Master(id,name,ParentGroup,companyid,importtag) values " + rStrSubGroup + " SET IDENTITY_INSERT Inventory_Sub_Group_Master OFF ");

                    objCMD.CommandType = CommandType.Text;
                    //objCMD.CommandText = "update Inventory_Sub_Group_Master set importtag=1 where id in (" + rStrSubGroupID + ")";
                    //objCMD.ExecuteNonQuery();
                }
                //****************************************************************************************************************************************
                rsTemp.Dispose(); rsTemp.Clear();
                //*******************************import data from inventory_master table and insert into local database***************************************
                rAdapter = new SqlDataAdapter("select * from Inventory_Master  order by id", rCon1);
                rAdapter.Fill(rsTemp);
                string rStrProduct = ""; string rStrProductID = "";
                for (intLoop = 0; intLoop < rsTemp.Tables[0].Rows.Count; intLoop++)
                {
                    if (rStrProduct == "")
                    {
                        rStrProductID = rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        rStrProduct = "(" + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ", '" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["name"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["code"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["rate"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Inventory_S_Group"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["gst"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["companyid"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["minlevel"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["maxlevel"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["hsn"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["status"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["fav"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["cess"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Opening_Stock"].ToString() + ",'" + rsTemp.Tables[0].Rows[intLoop]["grp_name"].ToString() + "',1,'" + rsTemp.Tables[0].Rows[intLoop]["rprint"].ToString() + "','" + rsTemp.Tables[0].Rows[intLoop]["rkotshow"].ToString() + "' )";
                    }
                    else
                    {
                        rStrProductID = rStrProductID + "," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        rStrProduct = rStrProduct + ",(" + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ", '" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["name"].ToString()) + "','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["code"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["rate"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Inventory_S_Group"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["gst"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["companyid"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["minlevel"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["maxlevel"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["hsn"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["status"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["fav"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["cess"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Opening_Stock"].ToString() + ",'" + rsTemp.Tables[0].Rows[intLoop]["grp_name"].ToString() + "',1,'" + rsTemp.Tables[0].Rows[intLoop]["rprint"].ToString() + "', '" + rsTemp.Tables[0].Rows[intLoop]["rkotshow"].ToString() + "')";
                    }
                }

                if (rStrProduct != "")
                {
                    da.insert_update_delete("delete from Inventory_Master where id in (" + rStrProductID + ")");
                    da.insert_update_delete(" SET IDENTITY_INSERT Inventory_Master ON insert into Inventory_Master(id,Name,Code,Rate,Inventory_S_Group,gst,CompanyID,Minlevel,Maxlevel,hsn,Status,FAV,cess,Opening_Stock,grp_name,ImportTag,rprint,rkotshow) values " + rStrProduct + " SET IDENTITY_INSERT Inventory_Master OFF ");

                    objCMD.CommandType = CommandType.Text;
                    //objCMD.CommandText = "update Inventory_Master set importtag=1 where id in (" + rStrProductID + ")";
                    //objCMD.ExecuteNonQuery();
                }
            //****************************************************************************************************************************************
                rsTemp.Dispose(); rsTemp.Clear();
           //*******************************import data from challan master and challan child table and insert into local database***************************************
                rAdapter = new SqlDataAdapter("select * from stockinwardmaster where stocktype='Dispatch Challan' and party=" + Form1.CompanyID +" and importtag=0 order by id", rCon1);
                rAdapter.Fill(rsTemp);
                string rStrChallan = ""; string rStrChallanD = "";
                for (intLoop = 0; intLoop < rsTemp.Tables[0].Rows.Count; intLoop++)
                {
                    if (rStrChallan == "")
                    {
                        rStrChallanD = rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        rStrChallan = "(" + rsTemp.Tables[0].Rows[intLoop]["EntryNo"].ToString() + ", '" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["PartyName"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["Party"].ToString() + ",'Stock Inward','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["InvoiceNo"].ToString()) + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + rsTemp.Tables[0].Rows[intLoop]["companyid"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["userid"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Remark"].ToString()) + "','" + Form1.CurrFinYear + "',0," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ")";
                    }
                    else
                    {
                        rStrChallanD = rStrChallanD + "," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        rStrChallan = rStrChallan + ",(" + rsTemp.Tables[0].Rows[intLoop]["EntryNo"].ToString() + ", '" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["PartyName"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["Party"].ToString() + ",'Stock Inward','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["InvoiceNo"].ToString()) + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + rsTemp.Tables[0].Rows[intLoop]["companyid"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["userid"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Remark"].ToString()) + "','" + Form1.CurrFinYear + "',0," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ")";
                    }
                }

                if (rStrChallan != "")
                {
                    da.insert_update_delete("delete stockinwarddetail from stockinwarddetail inner join stockinwardmaster on stockinwardmaster.id=stockinwarddetail.masterid where  stocktype='Stock Inward' and orgid in (" + rStrChallanD + ")");
                    da.insert_update_delete("delete from stockinwardmaster where  stocktype='Stock Inward' and orgid in (" + rStrChallanD + ")");
                    da.insert_update_delete(" insert into stockinwardmaster(EntryNo,PartyName,Party,StockType,InvoiceNo,InvoiceDate,invoicedate1,CompanyID,UserID,Remark,FinYear,ImportTag,OrgID) values " + rStrChallan);

                    objCMD.CommandType = CommandType.Text;
                    objCMD.CommandText = "update stockinwardmaster set  importtag=1 where party=" + Form1.CompanyID + " and stocktype='Dispatch Challan' and id in (" + rStrChallanD + ")";
                    objCMD.ExecuteNonQuery();
                }
                rsTemp.Dispose(); rsTemp.Clear();
                if (rStrChallanD!="")
                {
                    rAdapter = new SqlDataAdapter("select * from stockinwarddetail where masterid in (" + rStrChallanD + ") order by masterid,id", rCon1);
                    rAdapter.Fill(rsTemp);
                    string rStrChallanDetail = "";
                    for (intLoop = 0; intLoop < rsTemp.Tables[0].Rows.Count; intLoop++)
                    {
                        if (rStrChallanDetail == "")
                        {
                            rStrChallanDetail = "(" + rsTemp.Tables[0].Rows[intLoop]["product"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["qty"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Rate"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Amount"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Masterid"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["remark"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["comid"].ToString() + ")";
                        }
                        else
                        {
                            rStrChallanDetail = rStrChallanDetail + ",(" + rsTemp.Tables[0].Rows[intLoop]["product"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["qty"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Rate"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Amount"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Masterid"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["remark"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["comid"].ToString() + ")";
                        }
                    }
                    if (rStrChallanDetail != "")
                    {
                        da.insert_update_delete(" insert into stockinwarddetail(product,qty,Rate,Amount,Masterid,remark,comid) values " + rStrChallanDetail);
                        da.insert_update_delete("update stockinwarddetail set masterid=stockinwardmaster.id  from stockinwarddetail inner join stockinwardmaster on stockinwardmaster.orgid=stockinwarddetail.masterid where  stocktype='Stock Inward' and orgid in (" + rStrChallanD + ")");
                    }
                    rsTemp.Dispose(); rsTemp.Clear();
                }
                
           //****************************************************************************************************************************************

                //*******************************import data from challan master (shop transfer) and challan child table and insert into local database***************************************
                rAdapter = new SqlDataAdapter("select * from stockinwardmaster where stocktype='Shop Transfer' and party=" + Form1.CompanyID + " and importtag=0 order by id", rCon1);
                rAdapter.Fill(rsTemp);
                string rStrChallanShopTransfer = ""; string rStrChallanShopTransferID = "";
                for (intLoop = 0; intLoop < rsTemp.Tables[0].Rows.Count; intLoop++)
                {
                    if (rStrChallanShopTransfer == "")
                    {
                        rStrChallanShopTransferID = rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        rStrChallanShopTransfer = "(" + rsTemp.Tables[0].Rows[intLoop]["EntryNo"].ToString() + ", '" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["PartyName"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["Party"].ToString() + ",'Stock Inward','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["InvoiceNo"].ToString()) + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + rsTemp.Tables[0].Rows[intLoop]["companyid"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["userid"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Remark"].ToString()) + "','" + Form1.CurrFinYear + "',0," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ")";
                    }
                    else
                    {
                        rStrChallanShopTransferID = rStrChallanShopTransferID + "," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        rStrChallanShopTransfer = rStrChallanShopTransfer + ",(" + rsTemp.Tables[0].Rows[intLoop]["EntryNo"].ToString() + ", '" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["PartyName"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["Party"].ToString() + ",'Stock Inward','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["InvoiceNo"].ToString()) + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + rsTemp.Tables[0].Rows[intLoop]["companyid"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["userid"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Remark"].ToString()) + "','" + Form1.CurrFinYear + "',0," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ")";
                    }
                }

                if (rStrChallanShopTransfer != "")
                {
                    da.insert_update_delete("delete stockinwarddetail from stockinwarddetail inner join stockinwardmaster on stockinwardmaster.id=stockinwarddetail.masterid where  stocktype='Stock Inward' and orgid in (" + rStrChallanShopTransferID + ")");
                    da.insert_update_delete("delete from stockinwardmaster where stocktype='Stock Inward' and orgid in (" + rStrChallanShopTransferID + ")");
                    da.insert_update_delete(" insert into stockinwardmaster(EntryNo,PartyName,Party,StockType,InvoiceNo,InvoiceDate,invoicedate1,CompanyID,UserID,Remark,FinYear,ImportTag,OrgID) values " + rStrChallanShopTransfer);

                    objCMD.CommandType = CommandType.Text;
                    objCMD.CommandText = "update stockinwardmaster set  importtag=1 where party=" + Form1.CompanyID + " and stocktype='Shop Transfer' and id in (" + rStrChallanShopTransferID + ")";
                    objCMD.ExecuteNonQuery();
                }
                rsTemp.Dispose(); rsTemp.Clear();
                if (rStrChallanShopTransferID != "")
                {
                    rAdapter = new SqlDataAdapter("select * from stockinwarddetail where masterid in (" + rStrChallanShopTransferID + ") order by masterid,id", rCon1);
                    rAdapter.Fill(rsTemp);
                    string rStrChallanShopTransferDetail = "";
                    for (intLoop = 0; intLoop < rsTemp.Tables[0].Rows.Count; intLoop++)
                    {
                        if (rStrChallanShopTransferDetail == "")
                        {
                            rStrChallanShopTransferDetail = "(" + rsTemp.Tables[0].Rows[intLoop]["product"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["qty"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Rate"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Amount"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Masterid"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["remark"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["comid"].ToString() + ")";
                        }
                        else
                        {
                            rStrChallanShopTransferDetail = rStrChallanShopTransferDetail + ",(" + rsTemp.Tables[0].Rows[intLoop]["product"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["qty"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Rate"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Amount"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Masterid"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["remark"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["comid"].ToString() + ")";
                        }
                    }
                    if (rStrChallanShopTransferDetail != "")
                    {
                        da.insert_update_delete(" insert into stockinwarddetail(product,qty,Rate,Amount,Masterid,remark,comid) values " + rStrChallanShopTransferDetail);
                        da.insert_update_delete("update stockinwarddetail set masterid=stockinwardmaster.id  from stockinwarddetail inner join stockinwardmaster on stockinwardmaster.orgid=stockinwarddetail.masterid where stocktype='Stock Inward' and orgid in (" + rStrChallanShopTransferID + ")");
                    }
                    rsTemp.Dispose(); rsTemp.Clear();
                }

                //****************************************************************************************************************************************
                rCon1.Close();
                    this.Cursor = Cursors.Default;

                    MessageBox.Show("Data Imported Successfully.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void exportSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please check your internet connection properly before Export Challan." + Environment.NewLine + "Are you sure to Export Challan?", "Edge Solutions", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                SqlCommand objCMD = new SqlCommand();
                int intLoop = 0;
                string DBFile = File.ReadAllText(Application.StartupPath + "/DataConnection1.txt");
                SqlConnection rCon1 = new SqlConnection(DBFile);
                rCon1.Open();
                DataSet rsTemp = new DataSet();
                objCMD.Connection = rCon1;
                database_admin da = new database_admin();
                //*******************************import data from challan master and challan child table and insert into local database***************************************
                rsTemp = da.dataset_ret("select * from stockinwardmaster where stocktype='Shop Transfer' and companyid=" + Form1.CompanyID + " and importtag=0 order by id");
             
                string rStrChallan = ""; string rStrChallanD = "";
                for (intLoop = 0; intLoop < rsTemp.Tables[0].Rows.Count; intLoop++)
                {
                    if (rStrChallan == "")
                    {
                        rStrChallanD = rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        rStrChallan = "(" + rsTemp.Tables[0].Rows[intLoop]["EntryNo"].ToString() + ", '" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["PartyName"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["Party"].ToString() + ",'Shop Transfer','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["InvoiceNo"].ToString()) + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + Form1.CompanyID + "," + Form1.UserID + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Remark"].ToString()) + "','" + Form1.CurrFinYear + "',0," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ")";
                    }
                    else
                    {
                        rStrChallanD = rStrChallanD + "," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString();
                        rStrChallan = rStrChallan + ",(" + rsTemp.Tables[0].Rows[intLoop]["EntryNo"].ToString() + ", '" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["PartyName"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["Party"].ToString() + ",'Shop Transfer','" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["InvoiceNo"].ToString()) + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + Form1.CompanyID + "," + Form1.UserID + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["Remark"].ToString()) + "','" + Form1.CurrFinYear + "',0," + rsTemp.Tables[0].Rows[intLoop]["id"].ToString() + ")";
                    }
                }

                if (rStrChallan != "")
                {

                    objCMD.CommandType = CommandType.Text;
                    objCMD.CommandText = "delete stockinwarddetail from stockinwarddetail inner join stockinwardmaster on stockinwardmaster.id=stockinwarddetail.masterid where comid="+ Form1.CompanyID +" and companyid="+ Form1.CompanyID +" and stocktype='Shop Transfer' and orgid in (" + rStrChallanD + ")";
                    objCMD.ExecuteNonQuery();

                    objCMD.CommandType = CommandType.Text;
                    objCMD.CommandText = "delete from stockinwardmaster where companyid=" + Form1.CompanyID +" and stocktype='Shop Transfer' and orgid in (" + rStrChallanD + ")";
                    objCMD.ExecuteNonQuery();

                    objCMD.CommandType = CommandType.Text;
                    objCMD.CommandText = "insert into stockinwardmaster(EntryNo,PartyName,Party,StockType,InvoiceNo,InvoiceDate,invoicedate1,CompanyID,UserID,Remark,FinYear,ImportTag,OrgID) values " + rStrChallan;
                    objCMD.ExecuteNonQuery();


                    da.insert_update_delete("update stockinwardmaster set  importtag=1 where stocktype='Shop Transfer' and id in (" + rStrChallanD + ")");
                }
                rsTemp.Dispose(); rsTemp.Clear();
                if (rStrChallanD != "")
                {
                    rsTemp = da.dataset_ret("select * from stockinwarddetail where masterid in (" + rStrChallanD + ") order by masterid,id");
                   
                    string rStrChallanDetail = "";
                    for (intLoop = 0; intLoop < rsTemp.Tables[0].Rows.Count; intLoop++)
                    {
                        if (rStrChallanDetail == "")
                        {
                            rStrChallanDetail = "(" + rsTemp.Tables[0].Rows[intLoop]["product"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["qty"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Rate"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Amount"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Masterid"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["remark"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["comid"].ToString() + ")";
                        }
                        else
                        {
                            rStrChallanDetail = rStrChallanDetail + ",(" + rsTemp.Tables[0].Rows[intLoop]["product"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["qty"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Rate"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Amount"].ToString() + "," + rsTemp.Tables[0].Rows[intLoop]["Masterid"].ToString() + ",'" + Form1.SingleCode(rsTemp.Tables[0].Rows[intLoop]["remark"].ToString()) + "'," + rsTemp.Tables[0].Rows[intLoop]["comid"].ToString() + ")";
                        }
                    }
                    if (rStrChallanDetail != "")
                    {
                        objCMD.CommandType = CommandType.Text;
                        objCMD.CommandText = " insert into stockinwarddetail(product,qty,Rate,Amount,Masterid,remark,comid) values " + rStrChallanDetail;
                        objCMD.ExecuteNonQuery();

                        objCMD.CommandType = CommandType.Text;
                        objCMD.CommandText = "update stockinwarddetail set masterid=stockinwardmaster.id  from stockinwarddetail inner join stockinwardmaster on stockinwardmaster.orgid=stockinwarddetail.masterid where comid=" +Form1.CompanyID +" and companyid=" + Form1.CompanyID +" and stocktype='Shop Transfer' and orgid in (" + rStrChallanD + ")";
                        objCMD.ExecuteNonQuery();

                    }
                    rsTemp.Dispose(); rsTemp.Clear();
                }

                //****************************************************************************************************************************************
                rCon1.Close();
                this.Cursor = Cursors.Default;

                MessageBox.Show("Data Exported Successfully.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void softwareAutoDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "\\AutoUpdate.exe");
            Application.Exit();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            tax1 = 2;
            frmTaxReport frmtaxreport = new frmTaxReport();
            frmtaxreport.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuMinStock_Click(object sender, EventArgs e)
        {
            frmMinStockReport frmMinStockReport = new frmMinStockReport();
            frmMinStockReport.Show();
        }

        private void mnuPReturn_Click(object sender, EventArgs e)
        {
            try
            {

                formname = "Purchase Return";

                NewPurchaseInvoice textBox = new NewPurchaseInvoice(this);

                textBox.ShowDialog();
            }
            catch { }
        }

        private void mnuStock_Click(object sender, EventArgs e)
        {
            try
            {

                formname = "Department";

                PurchaseInvoice1 textBox = new PurchaseInvoice1(this);

                textBox.Show();
              
            }
            catch { }
        }

        private void mnuCons_Click(object sender, EventArgs e)
        {
            try
            {

                formname = "Consumed";
            
                PurchaseInvoice textBox = new PurchaseInvoice(this);
            
                textBox.ShowDialog();

            }
            catch { }
        }

        private void mnuDamage_Click(object sender, EventArgs e)
        {
            try
            {

                formname = "Damages";
             
                PurchaseInvoice textBox = new PurchaseInvoice(this);
             

                textBox.ShowDialog();


            }
            catch { }
        }

        private void mnuIReturn_Click(object sender, EventArgs e)
        {
            try
            {

                formname = "Issue";

                PurchaseInvoice textBox = new PurchaseInvoice(this);

                textBox.Show();

            }
            catch { }
        }

        private void mnuGodown_Click(object sender, EventArgs e)
        {
            Form1.LTag = 1;
            frmledger1 frmledger = new frmledger1(this);
            frmledger.Show();
        }

        private void mnuShop_Click(object sender, EventArgs e)
        {
            Form1.LTag = 2;
            frmledger1 frmledger = new frmledger1(this);
            frmledger.Show();
        }

        private void mnuPayment_Click(object sender, EventArgs e)
        {
            frmPayment1 frmpayment1 = new frmPayment1();
            frmpayment1.Show();
        }

        private void mnuDSaleEntry_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuStockReportEx_Click(object sender, EventArgs e)
        {
            Form1.StockTag = 1;
            frmStockReportEx frmst = new frmStockReportEx();
            frmst.Show();
        }

        private void mnuWastage_Click(object sender, EventArgs e)
        {
            try
            {

                formname = "Wastage";

                PurchaseInvoice textBox = new PurchaseInvoice(this);


                textBox.ShowDialog();


            }
            catch { }
        }

        private void mnuDemandReport_Click(object sender, EventArgs e)
        {
            frmDemandReport frmdemandreport = new frmDemandReport();
            frmdemandreport.Show();
        }

        private void mnuEntry1_Click(object sender, EventArgs e)
        {
            frmOP frmop = new frmOP();
            frmop.Show();
        }

        private void mnuMinEntry_Click(object sender, EventArgs e)
        {
            frmMinLevel frmminlevel = new frmMinLevel();
            frmminlevel.Show();
        }

        private void mnuStaffMaster_Click(object sender, EventArgs e)
        {
            frmledger2 frmledger2 = new frmledger2(this);
            frmledger2.Show();
        }

        private void mnuAtt_Click(object sender, EventArgs e)
        {
            frmAtt frmatt = new frmAtt();
            frmatt.Show();
        }

        private void toolStripSeparator22_Click(object sender, EventArgs e)
        {

        }

        private void mnuSalary_Click(object sender, EventArgs e)
        {
            frmSalary frmsalary = new frmSalary();
            frmsalary.Show();
        }

        private void mnuBinReport_Click(object sender, EventArgs e)
        {
            frmBinReport frmbinreport = new frmBinReport();
            frmbinreport.Show();
        }

        private void dbGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      private void ShowStock()
        {
            this.Cursor = Cursors.WaitCursor;
            DataSet rstemp = new DataSet();

            rstemp = da.dataset_ret("select a.id,a.code,a.name,isnull(aaa.qty,0) as qty,isnull(inward.inward,0) as inward,isnull(inward1.inward,0) as inward1, " +
                "   isnull(outward.outward,0) as outward,isnull(outward1.outward,0) as outward1,isnull(consumed.consumed,0) as consumed,isnull(damages.damages,0) as damages,isnull(wastage.wastage,0) as wastage " +
                "  ,a.unit from ( " +
                "  (select id,code,name,unit from Inventory_Master ) as a left join  " +
                "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
               "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(Form1.CompanyID) + " ) and StockType in ('Purchase','Issue Return') group by product union all select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(Form1.CompanyID) + ") and StockType in ('Issue','Issue Return','Department') group by product) as aa group by aa.product) as inward on a.id=inward.product " +
                 "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                "   where invoicedate1='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(Form1.CompanyID) + " ) and StockType in ('Purchase','Issue Return') group by product union all select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                "   where invoicedate1='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(Form1.CompanyID) + ") and StockType in ('Issue','Issue Return','Department') group by product) as aa group by aa.product) as inward1 on a.id=inward1.product " +
               "   left join (select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
               "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product) as outward on a.id=outward.product " +
               "   left join (select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
               "   where invoicedate1='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product) as outward1 on a.id=outward1.product " +
               "  left join (select product,sum(qty) as consumed from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
               "   where invoicedate1<='"+DateTime.Now.ToString("yyyy-MM-dd")+"' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Consumed') group by product) as consumed on a.id=consumed.product " +
                "  left join (select product,sum(qty) as damages from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                "  where invoicedate1<='"+DateTime.Now.ToString("yyyy-MM-dd")+"' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Damages') group by product) as damages on a.id=damages.product " +
                "  left join (select product,sum(qty) as wastage from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                "  where invoicedate1<='"+DateTime.Now.ToString("yyyy-MM-dd")+"' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Wastage') group by product) as wastage on a.id=wastage.product " +
                "  ) where (((isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0))))<>0 and (isnull(inward1.inward,0)>0 or isnull(outward1.outward,0)>0) order by a.name");

          
          int intloop = 0;
          dbGrid1.Rows.Clear();
          for (intloop = 0; intloop < 12;intloop++ )
          {
              dbGrid1.Rows.Add();
              dbGrid1.Rows[intloop].HeaderCell.Value = Convert.ToString(intloop + 1);
          }
              for (intloop = 0; intloop < rstemp.Tables[0].Rows.Count; intloop++)
              {
                  if(intloop>=12)
                  {
                      dbGrid1.Rows.Add();
                  }
               
                      dbGrid1.Rows[intloop].Cells[0].Value = rstemp.Tables[0].Rows[intloop]["name"].ToString();
                      dbGrid1.Rows[intloop].Cells[1].Value = rstemp.Tables[0].Rows[intloop]["unit"].ToString();
                      dbGrid1.Rows[intloop].Cells[2].Value = rstemp.Tables[0].Rows[intloop]["inward1"].ToString();
                      dbGrid1.Rows[intloop].Cells[3].Value = rstemp.Tables[0].Rows[intloop]["outward1"].ToString();
                      double rbal = 0;
                      rbal = ((Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["inward"].ToString())) - (Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["outward"].ToString()) + Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["consumed"].ToString()) + Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["damages"].ToString()) + Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["wastage"].ToString())));
                      dbGrid1.Rows[intloop].Cells[4].Value = rbal;
                  
                  dbGrid1.Rows[intloop].HeaderCell.Value = Convert.ToString(intloop + 1);
              }
           
          this.Cursor=Cursors.Default;
        }
        private void ShowMinOrder()
      {
          this.Cursor = Cursors.WaitCursor;
          DataSet rstemp = new DataSet();

          rstemp = da.dataset_ret("select yyy.* from (select a.id,a.code,a.name,isnull(aaa.qty,0) as qty,isnull(inward.inward,0) as inward, " +
                         "   isnull(outward.outward,0) as outward,isnull(consumed.consumed,0) as consumed,isnull(damages.damages,0) as damages,isnull(wastage.wastage,0) as wastage " +
                         "  ,a.unit,a.minlevel,isnull((select top 1 invoicedate from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid where StockType='Purchase' and product=a.id order by stockinwarddetail.id desc),'') as lastdt, " +
                           "  isnull((select top 1 partyname from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid where StockType='Purchase' and product=a.id   order by stockinwarddetail.id desc),'') as partyname from ( " +
                         "  (select id,code,name,unit,isnull((select top 1 minlevel_entry.minlevel from minlevel_entry where productid=inventory_master.id and companyid=" + Convert.ToInt32(Form1.CompanyID) + "),0) as minlevel from Inventory_Master ) as a left join  " +
                         "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master) as aa group by aa.product) as aaa on a.id=aaa.product " +
                        "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                    "   where invoicedate1<='"+DateTime.Now.ToString("yyyy-MM-dd")+"' and (companyid=" + Convert.ToInt32(Form1.CompanyID) + " ) and StockType in ('Purchase','Issue Return','Department') group by product union all select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                    "   where invoicedate1<='"+DateTime.Now.ToString("yyyy-MM-dd")+"' and (party=" + Convert.ToInt32(Form1.CompanyID) + ") and StockType in ('Issue','Issue Return') group by product) as aa group by aa.product) as inward on a.id=inward.product " +
                        "   left join (select product,sum(qty) as production from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                         "  where invoicedate1<='"+DateTime.Now.ToString("yyyy-MM-dd")+"' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Production') group by product) as production on a.id=production.product " +
                        "   left join (select product,sum(qty) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(Form1.CompanyID) + " )  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product) as outward on a.id=outward.product " +
                         "  left join (select product,sum(qty) as consumed from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where invoicedate1<='"+DateTime.Now.ToString("yyyy-MM-dd")+"' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Consumed') group by product) as consumed on a.id=consumed.product " +
                         "  left join (select product,sum(qty) as damages from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                         "  where invoicedate1<='"+DateTime.Now.ToString("yyyy-MM-dd")+"' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Damages') group by product) as damages on a.id=damages.product " +
                           "  left join (select product,sum(qty) as wastage from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                         "  where invoicedate1<='"+DateTime.Now.ToString("yyyy-MM-dd")+"' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Wastage') group by product) as wastage on a.id=wastage.product " +
                         " ) where isnull(a.minlevel,0)>0 and a.minlevel>(((isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0))))) as yyy order by yyy.name ");


          int intloop = 0;
          dbGrid2.Rows.Clear();
          for (intloop = 0; intloop < 12; intloop++)
          {
              dbGrid2.Rows.Add();
              dbGrid2.Rows[intloop].HeaderCell.Value = Convert.ToString(intloop + 1);
          }
          for (intloop = 0; intloop < rstemp.Tables[0].Rows.Count; intloop++)
          {
              if (intloop >= 12)
              {
                  dbGrid2.Rows.Add();
              }

              dbGrid2.Rows[intloop].Cells[0].Value = rstemp.Tables[0].Rows[intloop]["name"].ToString();
              dbGrid2.Rows[intloop].Cells[1].Value = rstemp.Tables[0].Rows[intloop]["unit"].ToString();
              dbGrid2.Rows[intloop].Cells[3].Value = rstemp.Tables[0].Rows[intloop]["minlevel"].ToString();
              double rbal = 0;
              rbal = ((Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["inward"].ToString())) - (Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["outward"].ToString()) + Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["consumed"].ToString()) + Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["damages"].ToString()) + Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["wastage"].ToString())));
              dbGrid2.Rows[intloop].Cells[2].Value = rbal;
              //if (rbal <= Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["minlevel"].ToString()))
              //{
              //    dbGrid2.Rows[intloop].DefaultCellStyle.BackColor = Color.LightPink;
              //}
              dbGrid2.Rows[intloop].HeaderCell.Value = Convert.ToString(intloop + 1);
          }

          this.Cursor = Cursors.Default;
      }
        private void ShowStockFav()
        {
            this.Cursor = Cursors.WaitCursor;
            DataSet rstemp = new DataSet();

            rstemp = da.dataset_ret("select a.id,a.code,a.name,isnull(aaa.qty,0) as qty,isnull(inward.inward,0) as inward, " +
                "   isnull(outward.outward,0) as outward,isnull(consumed.consumed,0) as consumed,isnull(damages.damages,0) as damages,isnull(wastage.wastage,0) as wastage " +
                "  ,a.unit from ( " +
                "  (select id,code,name,unit from Inventory_Master where fav=1) as a left join  " +
                "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
               "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(Form1.CompanyID) + " ) and StockType in ('Purchase','Issue Return') group by product union all select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(Form1.CompanyID) + ") and StockType in ('Issue','Issue Return','Department') group by product) as aa group by aa.product) as inward on a.id=inward.product " +
                 "   left join (select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
               "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product) as outward on a.id=outward.product " +
               "  left join (select product,sum(qty) as consumed from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
               "   where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Consumed') group by product) as consumed on a.id=consumed.product " +
                "  left join (select product,sum(qty) as damages from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                "  where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Damages') group by product) as damages on a.id=damages.product " +
                "  left join (select product,sum(qty) as wastage from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                "  where invoicedate1<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(Form1.CompanyID) + "  and StockType in ('Wastage') group by product) as wastage on a.id=wastage.product " +
                "  )  order by a.name");


            int intloop = 0;
            dbGrid3.Rows.Clear();
            for (intloop = 0; intloop < 12; intloop++)
            {
                dbGrid3.Rows.Add();
                dbGrid3.Rows[intloop].HeaderCell.Value = Convert.ToString(intloop + 1);
            }
            for (intloop = 0; intloop < rstemp.Tables[0].Rows.Count; intloop++)
            {
                if (intloop >= 12)
                {
                    dbGrid3.Rows.Add();
                }

                dbGrid3.Rows[intloop].Cells[0].Value = rstemp.Tables[0].Rows[intloop]["name"].ToString();
                dbGrid3.Rows[intloop].Cells[1].Value = rstemp.Tables[0].Rows[intloop]["unit"].ToString();
                //dbGrid3.Rows[intloop].Cells[2].Value = rstemp.Tables[0].Rows[intloop]["inward1"].ToString();
                //dbGrid3.Rows[intloop].Cells[3].Value = rstemp.Tables[0].Rows[intloop]["outward1"].ToString();
                double rbal = 0;
                rbal = ((Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["inward"].ToString())) - (Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["outward"].ToString()) + Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["consumed"].ToString()) + Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["damages"].ToString()) + Convert.ToDouble(rstemp.Tables[0].Rows[intloop]["wastage"].ToString())));
                dbGrid3.Rows[intloop].Cells[4].Value = rbal;

                dbGrid3.Rows[intloop].HeaderCell.Value = Convert.ToString(intloop + 1);
            }

            this.Cursor = Cursors.Default;
        }
        private void mnuMin1_Click(object sender, EventArgs e)
        {
            frmMinLevel frmminlevel = new frmMinLevel();
            frmminlevel.Show();
        }

        private void mnuDepartment_Click(object sender, EventArgs e)
        {
            Form1.LTag = 3;
            frmledger1 frmledger = new frmledger1(this);
            frmledger.Show();
        }

        private void mnuUnit_Click(object sender, EventArgs e)
        {
            frmUnit frmUnit = new frmUnit();
            frmUnit.Show();
        }

        private void mnuLot_Click(object sender, EventArgs e)
        {
            frmUnit1 frmUnit = new frmUnit1();
            frmUnit.Show();
        }

        private void mnuStockReport1_Click(object sender, EventArgs e)
        {
            Form1.StockTag = 0;
            frmStockReport frmstockreport = new frmStockReport();
            frmstockreport.Show();
        }

        private void mnuStockReportE1_Click(object sender, EventArgs e)
        {
            Form1.StockTag = 0;
            frmStockReportEx frmst = new frmStockReportEx();
            frmst.Show();
        }

        private void dbGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dbGrid1.Rows[e.RowIndex].ReadOnly = true;
        }
     

      

       

    }
}
