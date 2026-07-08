using EdgeVastra;
using EdgeVastra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using EdgePack;
using System.Drawing;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EdgePackingShared;
using EdgePack;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;

namespace EdgePackaging
{
    public partial class SalesForm : Form
    {
      
     
        
        public SalesForm()
        {
                     
            InitializeComponent();
        }
        database_admin da = new database_admin();
        DataSet ds = new DataSet();
        LedgerMasterClass lc = new LedgerMasterClass();
        public static int id;
       public static int companyid = Form1.CompanyID;
        //int userid=Form1.us
        saleClass sc = new saleClass();
        database_con Data_clss = new database_con();
            public static int dr;
            public static int rcheck = 1;
       // MainIndex mi = new MainIndex();
     

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }
        int productclickcode = 0;
       // DataSet ds = new DataSet();
        void la_Click(object sender, EventArgs e)
        {
            var b = sender as Label;
           if (productID == 1)
            {
                nRowIndex = -1;
                try
                {
                    //  clear();
                    if (Convert.ToInt32(txtQuantityforProuct.Text) >= 1)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please Insert Currect Quantity");
                        return;
                    }
                    // var b = sender as Button;
                    int ProductClickID = Convert.ToInt32(b.Tag);
                    clickonProductForgrid = ProductClickID;
                    ds = da.dataset_ret("select ID,Code,Name,Rate,gst,hsn,cess from Inventory_Master where ID  =" + ProductClickID + " order by Name asc");
                    bool flag = checkDuplicateProductinGrid();
                    setgrid();
                    if (flag == true)
                    {
                        // setgrid();
                        return;
                    }
                    dgvsalesdetail.Rows.Add();
                    DataGridViewRow row = dgvsalesdetail.Rows[0];
                    //row.Height = 42;
                    int gridrow = dgvsalesdetail.Rows.Count;
                    dgvsalesdetail.Rows[gridrow - 1].Cells[3].Value = ds.Tables["tab"].Rows[0]["Code"].ToString();

                    dgvsalesdetail.Rows[gridrow - 1].Cells[4].Value = ds.Tables["tab"].Rows[0]["Name"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[5].Value = txtQuantityforProuct.Text;

                    dgvsalesdetail.Rows[gridrow - 1].Cells[6].Value = ds.Tables["tab"].Rows[0]["Rate"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[7].Value = Convert.ToString(Convert.ToDouble(Convert.ToDouble(txtQuantityforProuct.Text) * Convert.ToDouble(ds.Tables["tab"].Rows[0]["Rate"].ToString())));
                    dgvsalesdetail.Rows[gridrow - 1].Cells[8].Value = ds.Tables["tab"].Rows[0]["gst"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[9].Value = ds.Tables["tab"].Rows[0]["id"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[10].Value = ds.Tables["tab"].Rows[0]["hsn"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[11].Value = ds.Tables["tab"].Rows[0]["cess"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[12].Value = 0;
                    dgvsalesdetail.Rows[gridrow - 1].Cells[13].Value = 0;
                    setgrid();


                }
                catch { }

            }
            else if (FavID == 1)
            {
                nRowIndex = -1;
                try
                {
                    // clear();
                    if (Convert.ToInt32(txtQuantityforProuct.Text) >= 1)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please Insert Currect Quantity");
                        return;
                    }
                    // var b = sender as Button;
                    int ProductClickID = Convert.ToInt32(b.Tag);
                    clickonProductForgrid = ProductClickID;
                    ds = da.dataset_ret("select ID,Code,Name,Rate,gst,hsn,cess from Inventory_Master where ID=" + ProductClickID + " order by Name asc");
                    if (Convert.ToDouble(ds.Tables["tab"].Rows[0]["Rate"].ToString()) == 0 || ds.Tables["tab"].Rows[0]["Code"].ToString() == "" || Convert.ToDouble(ds.Tables["tab"].Rows[0]["gst"].ToString()) == 0)
                    {
                        MessageBox.Show("Rate, Code, GstTax values are Missing In table");
                        return;
                    }
                    bool flag = checkDuplicateProductinGrid();
                    setgrid();
                    if (flag == true)
                    {
                        // setgrid();
                        return;
                    }
                    dgvsalesdetail.Rows.Add();

                    int gridrow = dgvsalesdetail.Rows.Count;
                    dgvsalesdetail.Rows[gridrow - 1].Cells[3].Value = ds.Tables["tab"].Rows[0]["Code"].ToString();

                    dgvsalesdetail.Rows[gridrow - 1].Cells[4].Value = ds.Tables["tab"].Rows[0]["Name"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[5].Value = txtQuantityforProuct.Text;

                    dgvsalesdetail.Rows[gridrow - 1].Cells[6].Value = ds.Tables["tab"].Rows[0]["Rate"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[7].Value = Convert.ToString(Convert.ToDouble(Convert.ToDouble(txtQuantityforProuct.Text) * Convert.ToDouble(ds.Tables["tab"].Rows[0]["Rate"].ToString())));
                    dgvsalesdetail.Rows[gridrow - 1].Cells[8].Value = ds.Tables["tab"].Rows[0]["gst"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[9].Value = ds.Tables["tab"].Rows[0]["id"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[10].Value = ds.Tables["tab"].Rows[0]["hsn"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[11].Value = ds.Tables["tab"].Rows[0]["cess"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[12].Value = 0;
                    dgvsalesdetail.Rows[gridrow - 1].Cells[13].Value = 0;
                    setgrid();


                }
                catch { }
            }
        }
        void pa_Click(object sender, EventArgs e)
        {
            var b = sender as PictureBox;
            if (GroupId == 1 && productID == 0 && FavID == 0)
            {
                productclickcode = Convert.ToInt32(b.Tag);

                allproduct = productclickcode;
                // rbGroup.Checked = false;
                if (MainIndex.dr == 2)
                {
                    ds = da.dataset_ret("select top 100 im.Name,im.ID,im.rate from Inventory_Master as im  where im.inventory_S_group=" + productclickcode + " order by im.name ");
                }
                else
                {
                    ds = da.dataset_ret("select  top 100 im.Name,im.ID,im.rate from Inventory_Master as im  where im.rkotshow='Yes' and im.inventory_S_group=" + productclickcode + " order by im.name ");

                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("There are no products available.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rbGroup.Checked = true;
                    return;
                }
                GroupId = 0;
                hexColor = "#F38EBF";
             
                DynamicButton();
                rbProduct.Checked = true;
                //rbProduct2.Visible = true;
                //rbProduct2.Checked = true;
                productID = 1;
                //return;

            }
        }
        void b_MouseHover(object sender, EventArgs e, object sender1)
        {
            var b = sender as Button;
            b.ForeColor = Color.Black;
            b.Cursor = Cursors.Hand;
           if (productID == 1 )
           {
               var b1 = sender1 as Label;
               b1.ForeColor = Color.Black;
               b1.Cursor = Cursors.Hand;
           }
        }
        void b_MouseLeave(object sender, EventArgs e, object sender1)
        {
            var b = sender as Button;
            b.ForeColor = Color.White;
            b.Cursor = Cursors.Default;
            if (productID == 1)
            {
                var b1 = sender1 as Label;
                b1.ForeColor = Color.White;
                b1.Cursor = Cursors.Default;
            }
        }
         void pa_MouseHover(object sender,EventArgs e, object sender1 )
        {
            var b = sender as PictureBox;
            b.ForeColor = Color.Black;
            b.Cursor = Cursors.Hand;
            if (GroupId == 1 && productID == 0 && FavID == 0)
            {
                var b1 = sender1 as Button;
                b1.ForeColor = Color.Black;
                b1.Cursor = Cursors.Hand;
            }
        }
         void pa_MouseLeave(object sender, EventArgs e, object sender1)
        {
            var b = sender as PictureBox;
            b.ForeColor = Color.White;
            b.Cursor = Cursors.Default;
            if (GroupId == 1 && productID == 0 && FavID == 0)
            {
                var b1 = sender1 as Button;
                b1.ForeColor = Color.White;
                b1.Cursor = Cursors.Default;
            }
        }
         void la_MouseHover(object sender, EventArgs e, object sender1)
        {
            var b = sender as Label;
            b.ForeColor = Color.Black;
            b.Cursor = Cursors.Hand;
            if (productID == 1)
            {
                var b1 = sender1 as Button;
                b1.ForeColor = Color.Black;
                b1.Cursor = Cursors.Hand;
            }
        }
         void la_MouseLeave(object sender, EventArgs e, object sender1)
        {
            var b = sender as Label;
            b.ForeColor = Color.White;
            b.Cursor = Cursors.Default;
            if (productID == 1)
            {
                var b1 = sender1 as Button;
                b1.ForeColor = Color.White;
                b1.Cursor = Cursors.Default;
            }
        }
        void b_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (GroupId == 1 && productID==0 && FavID==0)
            {
                productclickcode =Convert.ToInt32( b.Tag);

                allproduct = productclickcode;
               // rbGroup.Checked = false;
                if (MainIndex.dr == 2)
                {
                    ds = da.dataset_ret("select top 100 im.Name,im.ID,im.rate from Inventory_Master as im  where im.inventory_S_group=" + productclickcode + " order by im.name ");
                }
                else
                {
                    ds = da.dataset_ret("select top 100 im.Name,im.ID,im.rate from Inventory_Master as im  where im.rkotshow='Yes' and im.inventory_S_group=" + productclickcode + " order by im.name ");

                }
                    if (ds.Tables[0].Rows.Count==0)
                {
                    MessageBox.Show("There are no products available.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rbGroup.Checked = true;
                    return;
                }
                GroupId = 0;
                hexColor = "#F38EBF";
                DynamicButton();
                rbProduct.Checked = true;
                //rbProduct2.Visible = true;
                //rbProduct2.Checked = true;
                productID = 1;
              
               //return;
            
            }
          else  if (productID == 1 )
            {
                nRowIndex = -1;
                try
                {
                  //  clear();
                    if (Convert.ToInt32(txtQuantityforProuct.Text) >= 1)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please Insert Currect Quantity");
                        return;
                    }
                   // var b = sender as Button;
                    
                    int ProductClickID = Convert.ToInt32(b.Tag);
                    clickonProductForgrid = ProductClickID;
                    ds = da.dataset_ret("select ID,Code,Name,Rate,gst,hsn,cess from Inventory_Master where ID  =" + ProductClickID + " order by Name asc");
                    bool flag = checkDuplicateProductinGrid();
                    setgrid();
                    if (flag == true)
                    {
                        // setgrid();
                        return;
                    }
                   
                    b.ForeColor = Color.Black;
                    dgvsalesdetail.Rows.Add();
                    DataGridViewRow row = dgvsalesdetail.Rows[0];
                    //row.Height = 42;
                    int gridrow = dgvsalesdetail.Rows.Count;
                    dgvsalesdetail.Rows[gridrow - 1].Cells[3].Value = ds.Tables["tab"].Rows[0]["Code"].ToString();

                    dgvsalesdetail.Rows[gridrow - 1].Cells[4].Value = ds.Tables["tab"].Rows[0]["Name"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[5].Value = txtQuantityforProuct.Text;

                    dgvsalesdetail.Rows[gridrow - 1].Cells[6].Value = ds.Tables["tab"].Rows[0]["Rate"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[7].Value = Convert.ToString(Convert.ToDouble(Convert.ToDouble(txtQuantityforProuct.Text) * Convert.ToDouble(ds.Tables["tab"].Rows[0]["Rate"].ToString())));
                    dgvsalesdetail.Rows[gridrow - 1].Cells[8].Value = ds.Tables["tab"].Rows[0]["gst"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[9].Value = ds.Tables["tab"].Rows[0]["id"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[10].Value = ds.Tables["tab"].Rows[0]["hsn"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[11].Value = ds.Tables["tab"].Rows[0]["cess"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[12].Value = 0;
                    dgvsalesdetail.Rows[gridrow - 1].Cells[13].Value = 0;
                    setgrid();
                    dgvsalesdetail.ClearSelection();

                }
                catch { }
               
            }
            else if (FavID == 1)
            {
                nRowIndex = -1;
                try
                {
                   // clear();
                    if (Convert.ToInt32(txtQuantityforProuct.Text) >= 1)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please Insert Currect Quantity");
                        return;
                    }
                   // var b = sender as Button;
                    int ProductClickID = Convert.ToInt32(b.Tag);
                    clickonProductForgrid = ProductClickID;
                    ds = da.dataset_ret("select ID,Code,Name,Rate,gst,hsn,cess from Inventory_Master where ID=" + ProductClickID + " order by Name asc");
                    if (Convert.ToDouble(ds.Tables["tab"].Rows[0]["Rate"].ToString()) == 0 || ds.Tables["tab"].Rows[0]["Code"].ToString() == "" || Convert.ToDouble(ds.Tables["tab"].Rows[0]["gst"].ToString()) == 0)
                    {
                        MessageBox.Show("Rate, Code, GstTax values are Missing In table");
                        return;
                    }
                    bool flag = checkDuplicateProductinGrid();
                    setgrid();
                    if (flag == true)
                    {
                        // setgrid();
                        return;
                    }
                    dgvsalesdetail.Rows.Add();
                   
                    int gridrow = dgvsalesdetail.Rows.Count;
                    dgvsalesdetail.Rows[gridrow - 1].Cells[3].Value = ds.Tables["tab"].Rows[0]["Code"].ToString();

                    dgvsalesdetail.Rows[gridrow - 1].Cells[4].Value = ds.Tables["tab"].Rows[0]["Name"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[5].Value = txtQuantityforProuct.Text;

                    dgvsalesdetail.Rows[gridrow - 1].Cells[6].Value = ds.Tables["tab"].Rows[0]["Rate"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[7].Value = Convert.ToString(Convert.ToDouble(Convert.ToDouble(txtQuantityforProuct.Text) * Convert.ToDouble(ds.Tables["tab"].Rows[0]["Rate"].ToString())));
                    dgvsalesdetail.Rows[gridrow - 1].Cells[8].Value = ds.Tables["tab"].Rows[0]["gst"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[9].Value = ds.Tables["tab"].Rows[0]["id"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[10].Value = ds.Tables["tab"].Rows[0]["hsn"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[11].Value = ds.Tables["tab"].Rows[0]["cess"].ToString();
                    dgvsalesdetail.Rows[gridrow - 1].Cells[12].Value = 0;
                    dgvsalesdetail.Rows[gridrow - 1].Cells[13].Value = 0;
                    setgrid();


                }
                catch { }
            }
        }
        int clickonProductForgrid = 0;
        string hexColor = "#97BAF7";
        public void DynamicButton()
        {
            clickonProductForgrid = 0;

            int rows = 0;

            if (GroupId == 1 && productID==0 && FavID==0)
            {
                ds = da.dataset_ret("select Inventory_Sub_Group_Master.Name,Inventory_Sub_Group_Master.ID,0 as rate,isnull(count(inventory_s_group),0) as rcnt from  Inventory_Sub_Group_Master left join Inventory_Master on Inventory_Sub_Group_Master.id=inventory_s_group  group by Inventory_Sub_Group_Master.name,Inventory_Sub_Group_Master.id order By Inventory_Sub_Group_Master.Name");
                rbGroup.BackColor = Color.LimeGreen;
                rbGroup.ForeColor = Color.White;
                rbProduct.BackColor = Color.FromArgb(224, 224, 224);
                rbProduct.ForeColor = Color.Black;
                rbFav.BackColor = Color.FromArgb(224, 224, 224);
                rbFav.ForeColor = Color.Black;
            }
            if (GroupId == 0 && productID == 1 && FavID == 0)
            {
                if (MainIndex.dr == 2)
                {
                    ds = da.dataset_ret("select top 100 Name,ID,rate,0 as rcnt from Inventory_Master where status=1 order By Name");
                }
                else
                {
                    ds = da.dataset_ret("select top 100 Name,ID,rate,0 as rcnt from Inventory_Master where rkotshow='Yes' and status=1 order By Name");
                }
                rbGroup.BackColor = Color.FromArgb(224, 224, 224); 
                rbGroup.ForeColor = Color.Black; 
                rbProduct.BackColor = Color.LimeGreen;
                rbProduct.ForeColor = Color.White;
                rbFav.BackColor = Color.FromArgb(224, 224, 224);
                rbFav.ForeColor = Color.Black;
            }
            if (GroupId == 0 && productID == 0 && FavID == 1)
            {
                if (MainIndex.dr == 2)
                {
                    ds = da.dataset_ret("select Name,ID,rate,0 as rcnt from Inventory_Master where status=1 and FAV=1 order By Name");
                }
                else
                {
                    ds = da.dataset_ret("select Name,ID,rate from Inventory_Master where rkotshow='Yes' and status=1 and FAV=1 order By Name");
                }
                rbGroup.BackColor = Color.FromArgb(224, 224, 224);
                rbGroup.ForeColor = Color.Black;
                rbProduct.BackColor = Color.FromArgb(224, 224, 224);
                rbProduct.ForeColor = Color.White;
                rbFav.BackColor = Color.Black; 
                rbFav.ForeColor = Color.White;
            }
         
          int buttoncount = ds.Tables["tab"].Rows.Count;
          if (buttoncount == 0)
          {
              MessageBox.Show("There are no products available.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
              rbGroup.Checked = true;
              return;
          }
            var columnCount = 4;
          if (buttoncount <= 1)
          {
              rows = 1;
          }
          else 
          {

              int roundValue = buttoncount / columnCount + Convert.ToInt32(buttoncount % columnCount > 0);
         // decimal rowforcoun =Convert.ToDecimal(Convert.ToDecimal(buttoncount) / Convert.ToDecimal( columnCount));
              rows = (int)Math.Abs(roundValue); 
          }
            var rowCount = Convert.ToInt32(rows);// this value comes from database count

            this.tableLayoutPanel1.ColumnCount = columnCount;
            this.tableLayoutPanel1.RowCount = rowCount;

            this.tableLayoutPanel1.Controls.Clear();
            this.tableLayoutPanel1.RowCount = 0;
            Color myColor = System.Drawing.ColorTranslator.FromHtml(hexColor);

          //  form1.BackColor = myColor;
            for (int i = 0; i < buttoncount; i++)
            {
                try
                {
                    string ButtonName = ds.Tables["tab"].Rows[i]["Name"].ToString();
                    string labelName = "";
                    if(Convert.ToDouble(ds.Tables["tab"].Rows[i]["rate"].ToString())!=0)
                    {
                        labelName = ds.Tables["tab"].Rows[i]["rate"].ToString().Remove(ds.Tables["tab"].Rows[i]["rate"].ToString().Length-1, 1);
                    }
                    int ButtonID = Convert.ToInt32(ds.Tables["tab"].Rows[i]["ID"]);
                    var b = new Button();
                    if (GroupId == 0)
                    {
                        b.Text = ButtonName.ToString();
                    }
                    else
                    {
                        b.Text = ButtonName + "  " + "[" + ds.Tables["tab"].Rows[i]["rcnt"].ToString()+"]".ToString();
                    }
                    b.Tag = ButtonID;
                    var la = new Label();
                    if (GroupId == 0)
                    {
                    
                        if (Convert.ToDouble(ds.Tables["tab"].Rows[i]["rate"].ToString()) != 0)
                        {
                           
                            b.Controls.Add(la);
                            la.Text = Convert.ToDouble(ds.Tables["tab"].Rows[i]["rate"].ToString()).ToString("N");
                            la.ForeColor = Color.White;
                            la.BackColor = Color.Green;
                            //la.Width = 58;
                            //la.Height = 18;
                            la.AutoSize = true;
                            la.Top = 0;

                            la.TextAlign = ContentAlignment.TopRight;
                            la.Location = new Point((b.Right -la.Width)+22, 105);
                            la.Tag = ButtonID;
                            la.Click += la_Click;
                        
                            la.MouseHover += delegate(object sender, EventArgs e) { la_MouseHover(sender, e, b); };
                            la.MouseLeave += delegate(object sender, EventArgs e) { la_MouseLeave(sender, e, b); };
                        }
                    }
                    else
                    {
                        if(Directory.Exists(Application.StartupPath + "\\GroupImage"))
                        {
                            var pa = new PictureBox();
                            b.Controls.Add(pa);
                            pa.Width = 35;
                            pa.Height = 35;
                            pa.Location = new Point(35, 15);
                            if (File.Exists(Application.StartupPath + "\\GroupImage\\" + ds.Tables["tab"].Rows[i]["id"].ToString() + ".png"))
                            {
                                pa.Image = Image.FromFile(Application.StartupPath + "\\GroupImage\\" + ds.Tables["tab"].Rows[i]["id"].ToString() + ".png");
                            }
                            else
                            {
                                pa.Image = Image.FromFile(Application.StartupPath + "\\GroupImage\\0.png");

                            }
                            pa.SizeMode = PictureBoxSizeMode.Zoom;
                            pa.Tag = ButtonID;
                            pa.Click += pa_Click;

                            pa.MouseHover += delegate(object sender, EventArgs e) { pa_MouseHover(sender, e, b); };
                            pa.MouseLeave +=delegate(object sender, EventArgs e) { pa_MouseLeave(sender, e, b); };
                        }
                       
                        
                    }
                  
                    if (GroupId == 0)
                    {
                        b.Width = 94;
                        b.Height = 123;
                       // b.TextAlign = ContentAlignment.TopCenter;
                    }
                    else
                    {
                        b.Width = 94;
                        b.Height = 94;
                       b.TextAlign = ContentAlignment.BottomCenter;
                      
                    }
                    b.Name = string.Format("b_{0}", ButtonName);
                    b.Click += b_Click;
                    b.BackColor = myColor;
                    b.ForeColor = Color.White;
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.MouseOverBackColor = myColor;
                    b.MouseHover += delegate(object sender, EventArgs e) { b_MouseHover(sender, e, la); };
                    b.MouseLeave +=  delegate(object sender, EventArgs e) { b_MouseLeave(sender, e, la); };
                   b.Margin = new Padding(0);
                    b.Dock = DockStyle.Fill;

                    tableLayoutPanel1.Controls.Add(b);
                }
                catch { }
            }

        }
        public void DynamicButtonAlpha(string Alpha)
        {
            clickonProductForgrid = 0;

            int rows = 0;
            GroupId = 0;
            hexColor = "#F38EBF";
            if (productclickcode==0)
            {
                if (MainIndex.dr == 2)
                {
                    ds = da.dataset_ret("select  Name,ID,rate from Inventory_Master where name like '" + Alpha + "%' and  status=1 order By Name");
                }
                else
                {
                    ds = da.dataset_ret("select  Name,ID,rate from Inventory_Master where rkotshow='Yes' and name like '" + Alpha + "%' and  status=1 order By Name");
                }

            }
            else
            {
                if (MainIndex.dr == 2)
                {
                    ds = da.dataset_ret("select  Name,ID,rate from Inventory_Master where inventory_s_group=" + productclickcode + " and name like '" + Alpha + "%' and  status=1 order By Name");
                }
                else
                {
                    ds = da.dataset_ret("select  Name,ID,rate from Inventory_Master where rkotshow='Yes' and inventory_s_group=" + productclickcode + " and name like '" + Alpha + "%' and  status=1 order By Name");
                }

            }
            int buttoncount = ds.Tables["tab"].Rows.Count;
            if (buttoncount == 0)
            {
                MessageBox.Show("There are no products available.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rbGroup.Checked = true;
                return;
            }
            var columnCount = 4;
            if (buttoncount <= 1)
            {
                rows = 1;
            }
            else
            {
                int roundValue = buttoncount / columnCount + Convert.ToInt32(buttoncount % columnCount > 0);
                // decimal rowforcoun =Convert.ToDecimal(Convert.ToDecimal(buttoncount) / Convert.ToDecimal( columnCount));
                rows = (int)Math.Abs(roundValue);
            }
            var rowCount = Convert.ToInt32(rows);// this value comes from database count

            this.tableLayoutPanel1.ColumnCount = columnCount;
            this.tableLayoutPanel1.RowCount = rowCount;

            this.tableLayoutPanel1.Controls.Clear();
            this.tableLayoutPanel1.RowCount = 0;
            Color myColor = System.Drawing.ColorTranslator.FromHtml(hexColor);

            //  form1.BackColor = myColor;
            for (int i = 0; i < buttoncount; i++)
            {
                try
                {
                    string ButtonName = ds.Tables["tab"].Rows[i]["Name"].ToString();
                    string labelName = "";
                    if (Convert.ToDouble(ds.Tables["tab"].Rows[i]["rate"].ToString()) != 0)
                    {
                        labelName = ds.Tables["tab"].Rows[i]["rate"].ToString().Remove(ds.Tables["tab"].Rows[i]["rate"].ToString().Length - 3, 3);
                    }

                    int ButtonID = Convert.ToInt32(ds.Tables["tab"].Rows[i]["ID"]);
                    var b = new Button();
                    var la = new Label();
                    if (Convert.ToDouble(ds.Tables["tab"].Rows[i]["rate"].ToString()) != 0)
                    {
                     
                        b.Controls.Add(la);
                        la.Text = Convert.ToDouble(ds.Tables["tab"].Rows[i]["rate"].ToString()).ToString("N");
                        la.ForeColor = Color.White;
                        la.BackColor = Color.Green;
                        //la.Width = 58;
                        //la.Height = 18;
                        la.AutoSize = true;
                        la.Top = 0;

                        la.TextAlign = ContentAlignment.TopRight;
                        la.Location = new Point((b.Right - la.Width) + 22, 105);
                        la.Tag = ButtonID;
                        la.Click += la_Click;

                        la.MouseHover += delegate(object sender, EventArgs e) { la_MouseHover(sender, e, b); };
                        la.MouseLeave += delegate(object sender, EventArgs e) { la_MouseLeave(sender, e, b); };
                    }
                    b.Text = ButtonName.ToString();
                    b.Tag = ButtonID;
                    if (Convert.ToDouble(ds.Tables["tab"].Rows[i]["rate"].ToString()) != 0)
                    {
                        b.Width = 94;
                        b.Height = 123;
                    }
                    else
                    {
                        b.Width = 94;
                        b.Height = 100;
                    }
                    b.Name = string.Format("b_{0}", ButtonName);
                    b.Click += b_Click;
                    b.BackColor = myColor;
                    b.ForeColor = Color.White;
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.MouseOverBackColor = myColor;
                    b.MouseHover += delegate(object sender, EventArgs e) { b_MouseHover(sender, e, la); };
                    b.MouseLeave += delegate(object sender, EventArgs e) { b_MouseLeave(sender, e, la); };
                    //b.TextAlign = ContentAlignment.TopCenter;
                    b.Margin = new Padding(0);
                    b.Dock = DockStyle.Fill;

                    tableLayoutPanel1.Controls.Add(b);
                }
                catch { }
            }
            rbProduct.Checked = true;
            //rbProduct2.Visible = true;
            //rbProduct2.Checked = true;
            productID = 1;
        }
        public void NewFunction()
        {
            DynamicButton();
           // da.fill_combo("select ID,Mobile from Ledger_Master where type='Customer' Order By Mobile", cmbMobile, "ID", "Mobile");
            da.fill_combo("select ID,Name from tblPaymentMode order by name", cmbseries, "ID", "Name");
            // da.fill_combo("select ID,Name from Inventory_Master Order By Name", cmbparty, "ID", "Name");       
            da.fill_combo("select ID,Name from Ledger_Master where type='Customer' Order By Name", cmbparty, "ID", "Name");
            da.fill_combo("select ID,Name from Ledger_Master where type='Customer' Order By Name", cmbParty2, "ID", "Name");
            if (MainIndex.dr == 2)
            {
                da.fill_combo("select 0 as ID,'' as Name union all select ID,Name from Inventory_Master Order By name", cmbproduct, "ID", "Name");
            }
            else
            {
                da.fill_combo("select 0 as ID,'' as Name union all select ID,Name from Inventory_Master where rkotshow='Yes' Order By name", cmbproduct, "ID", "Name");

            }
            Data_clss.fill_combo("select ID,Name from tblPaymentMode order by Name", cmbPaymodeSearch, "Name");
            Data_clss.fill_combo("select ID,Name from tblPaymentMode where name<>' Unsetteled' order by id", cmbChooseMode, "Name");
            Data_clss.fill_combo("select ID,Name from tblPaymentMode where name<>' Unsetteled' order by id", cmbPayMode1, "Name");
        }
        private void RefreshGrid()
        {
            txtnetAmount.Text = "";
            txtTotDisAmt.Text = "";
            txtNetQty.Text = "";
            dgvsalesdetail.Rows.Clear();
        }
        public void RefreshPage()
        {
            btnSave_Print.Text = "&Save/F1";
            
            //rbProduct2.Visible = false;
          
            txtQuantityforProuct.Text = "1";
            txtBarCode.Focus();
            rbGroup.Checked = true;
            rbGroup.BackColor = Color.LimeGreen;
            rbGroup.ForeColor = Color.White;
            GroupId = 1;
            btnSave.Enabled = true;
            btnSave_Print.Enabled = true;
         //   cmbproduct.Text = "----Select Product-----";
            panel2.AutoScrollMinSize = new Size(0, 800);
            if (MainIndex.dr == 1)
            {
                da.fill_combo("select 0 as ID,'' as Name union all select ID,Name from Inventory_Master  where rkotshow='Yes' Order By name", cmbproduct, "ID", "Name");
                optKOT.BackColor = Color.LimeGreen;
                optKOT.ForeColor = Color.White;
                optSale.BackColor = Color.FromArgb(224,224,224);
                optSale.ForeColor = Color.Black;
               // this.Text = "KOT";
                label22.Visible=true;
                txtKotno.Visible = true;
                btnTransfer.Visible = true;
                button1.Visible = true;
                label14.Text = "KOT NO";
                //groupPanel3.Text = "KOT Information";
                //groupPanel1.Text = "KOT Detail";
             //   txtbillno.Text = da.value1("select Max(kotno)+1 from sale where CompanyId=" + companyid + "");
                txtDisPer.Enabled = true;
                txtDAmt.Enabled = true;
                btnSetParty.Visible = false;
            }
            else if (MainIndex.dr == 2)
            {
                optSale.BackColor = Color.LimeGreen;
                optSale.ForeColor = Color.White;
             optKOT.BackColor = Color.FromArgb(224, 224, 224);
            optKOT.ForeColor = Color.Black;
                txtDisPer.Enabled = false;
                txtDAmt.Enabled = false;
                da.fill_combo("select 0 as ID,'' as Name union all select ID,Name from Inventory_Master Order By name", cmbproduct, "ID", "Name");
                btnTransfer.Visible = false;
                label22.Visible = false;
                txtKotno.Visible = false;
                button1.Visible = true;
              //  this.Text = "SALES";
                label14.Text = "Bill NO";
                //groupPanel3.Text = "Bill Information";
                //groupPanel1.Text = "Bill Detail";
              //  txtbillno.Text = da.value1("select Max(BillNo)+1 from sale where PayMode='" + cmbseries.Text + "' and CompanyId=" + companyid + "");
                btnSetParty.Visible = true;
            }
           
            //cmbseries.Text = "Cash";
            cmbseries.Text = " Unsetteled";
            textBox2.Text = "";
            txtKotno.Text = "";
            txtKOTNo1.Text = "";
            txtKOTNo1.Tag = "";
            cmbMobile2.Text = "";
            grpChooseMode.Visible = false; grpBillDetail.Visible = false;

           // cmbseries.Focus();
            cmbparty.Text = "Cash";
            Form1.PartyAddress = "";
            Form1.PartyGST = "";
            Form1.PartyState = "";
          
            SetBillNo();
            rcheck = 0;
        }
        int UserType = 0;
        private void SalesForm_Load(object sender, EventArgs e)
        {
            
            this.Cursor = Cursors.WaitCursor;
            if (MainIndex.dr == 1)
            {
                optKOT.Checked = true;
                optKOT.BackColor = Color.LimeGreen;
                optKOT.ForeColor = Color.White;
            }
            else
            {
                optSale.BackColor = Color.LimeGreen;
                optSale.ForeColor = Color.White;
                optSale.Checked = true;
                txtDisPer.Enabled = false;
                txtDAmt.Enabled = false;
            }
            RefreshPage();
            RefreshGrid();
            NewFunction();
            cmbparty.Text = "CASH";
            DataSet rsTemp = new DataSet();
            rsTemp = da.dataset_ret("Select UserType from user_master where id=" + Form1.UserID);
            UserType =Convert.ToInt16( rsTemp.Tables[0].Rows[0]["usertype"].ToString());
            if(UserType==0)
            {
                txtDisPer.Enabled = false;
                txtDAmt.Enabled = false;
            }
            this.Cursor = Cursors.Default;
        }
       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbseries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbparty.Focus();
            }
        }

        private void txtbillno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                dtinvoice.Focus();
            }

        }

        private void dtinvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbparty.Focus();
            }
        }

        private void cmbparty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbMobile.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cmbparty.Text = "CASH";
                cmbparty.SelectAll();
            }
        }

        private void txtmobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbproduct.Focus();
            }
        }
        decimal tax = 0;
        string hsn = ""; decimal cess = 0;
        private void txtcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (txtcode.Text != "" && e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                //{
                //    int checkdup = AllCommonFunctions.Check_Duplicacy("Inventory_Mast_Code", txtcode.Text);
                //    if (checkdup == 0)
                //    {
                //        MessageBox.Show("Select Proper Code");
                //        txtcode.Focus();
                //    }
                //    else
                //    {
                //        cmbproduct.Focus();
                //    }
                //}
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (txtcode.Text != "")
                    {
                        DataSet ds = new DataSet();
                        txtamt.Text = Convert.ToString(0);
                        txtqty.Text = Convert.ToString(0);
                        if (MainIndex.dr == 2)
                        {
                            ds = da.dataset_ret("select Name,Rate,gst,hsn,cess from Inventory_Master  where Code ='" + txtcode.Text + "'");
                        }
                        else
                        {
                            ds = da.dataset_ret("select Name,Rate,gst,hsn,cess from Inventory_Master  where rkotshow='Yes' and Code ='" + txtcode.Text + "'");
                        }
                        if(ds.Tables[0].Rows.Count>0)
                        {
                            cmbproduct.Text = ds.Tables["tab"].Rows[0]["Name"].ToString();
                            txtrate.Text = ds.Tables["tab"].Rows[0]["Rate"].ToString();
                            txtqty.Text = "1";
                            txtamt.Text = Convert.ToString(Convert.ToDouble(Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtrate.Text)));
                            tax = Convert.ToDecimal(ds.Tables["tab"].Rows[0]["gst"].ToString());
                            cess = Convert.ToDecimal(ds.Tables["tab"].Rows[0]["cess"].ToString());
                            hsn = ds.Tables["tab"].Rows[0]["hsn"].ToString();

                            btnadd_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Please select valid code.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtcode.Focus();
                            return;
                        }
                    }
                    
                }
            }
            catch { }
        }

        private void cmbproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
              
                txtqty.Focus();
            }
        }

        private void txtqty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                AddToGrid();
                cmbproduct.Focus();
            }
        }

        private void txtrate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnadd_Click(sender, e);
            }
        }

        private void txtamt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnadd.Focus();
            }
        }
        public void gridResetSNo()
        {
            setgrid(); 
            //try
            //{
            //    int NowRow = dgvsalesdetail.Rows.Count;
            //    for (int i = 0; i < NowRow; i++)
            //    {
            //        dgvsalesdetail.Rows[i].Cells[2].Value = i + 1;
            //    }
            //   dgvsalesdetail.Rows[NowRow].Cells[2].Value = null;
            //}
            //catch { }
           
        }
        public bool  checkDuplicateProductinGrid()
        
        {
            
            bool check = false;
            try
            {
               
                string coded = "";
                string qty="";
                if (txtcode.Text == "" && clickonProductForgrid != 0)
                {
                    coded = ds.Tables["tab"].Rows[0]["Code"].ToString();
                    qty = txtQuantityforProuct.Text;

                }
                else 
                {
                    coded = txtcode.Text;
                    qty = txtqty.Text;
                }
                int rowcount = dgvsalesdetail.Rows.Count;
                if (rowcount == 0)
                {
                    check = false;
                    return check;
                }
                for (int i = 0; i < rowcount; i++)
                {
                    if (coded == dgvsalesdetail.Rows[i].Cells[3].Value.ToString())
                    {

                        dgvsalesdetail.Rows[i].Cells[5].Value = Convert.ToInt32(Convert.ToInt32(qty) + Convert.ToInt32(dgvsalesdetail.Rows[i].Cells[5].Value));
                        check = true;
                        return check;
                    }
                    else 
                    {
                        check = false;
                       
                    }
                    
                   
                }
                return check;
            }
            catch 
            {
                MessageBox.Show("Qty Not Valid (function ->checkDuplicateProductinGrid)");
              
            }
            check = true;
            return check;
        }
        public void setgrid()
        {
            try
            {
                double netqty = 0;
                decimal netamtf=0;
                double netdis = 0;
               int rowcount = dgvsalesdetail.Rows.Count;
                for (int i = 0; i < rowcount; i++)
                {

                   dgvsalesdetail.Rows[i].Cells[2].Value = Convert.ToString(i + 1);
                  
                   dgvsalesdetail.Rows[i].Cells[7].Value =Convert.ToString( Math.Round(Convert.ToDecimal(Convert.ToDecimal(dgvsalesdetail.Rows[i].Cells[5].Value) * (Convert.ToDecimal(dgvsalesdetail.Rows[i].Cells[6].Value))), 2));
                   double plo = Math.Round(Convert.ToDouble(dgvsalesdetail.Rows[i].Cells[5].Value),2);
                   dgvsalesdetail.Rows[i].Cells[5].Value = Convert.ToString(plo);
                  double klm = ((netqty + plo));
                    netqty =klm ;
                  
                    dgvsalesdetail.Rows[i].Cells[8].Value =Convert.ToString( Convert.ToDecimal(dgvsalesdetail.Rows[i].Cells[8].Value));
                 
                    if(dgvsalesdetail.Rows[i].Cells[13].Value.ToString()!="")
                    {
                        netdis += Convert.ToDouble(dgvsalesdetail.Rows[i].Cells[13].Value.ToString());
                        dgvsalesdetail.Rows[i].Cells[7].Value = Convert.ToString(Convert.ToDecimal(dgvsalesdetail.Rows[i].Cells[7].Value) - Convert.ToDecimal(dgvsalesdetail.Rows[i].Cells[13].Value));
                    }
                    else
                    {
                        dgvsalesdetail.Rows[i].Cells[7].Value = Convert.ToString(Convert.ToDecimal(dgvsalesdetail.Rows[i].Cells[7].Value));
                    }
                    netamtf = netamtf + Convert.ToDecimal(dgvsalesdetail.Rows[i].Cells[7].Value);
                    DataGridViewRow row = dgvsalesdetail.Rows[i];
                    //row.Height = 50;
                }
                if (dgvsalesdetail.Rows.Count>0)
                {
                    dgvsalesdetail.FirstDisplayedScrollingRowIndex = dgvsalesdetail.Rows.Count - 1;
                }
               
                txtNetQty.Text = Convert.ToString(netqty);
                txtnetAmount.Text = Convert.ToString(netamtf);
                txtTotDisAmt.Text = Convert.ToString(netdis);
            }
            catch { MessageBox.Show("S.No Not Valid (function ->(SetGrid)"); }
        }
        public void AddToGrid()
        {
            
            clickonProductForgrid = 0;
            try
            {
             if(txtqty.Text == "")
                {
                    MessageBox.Show("Quantity Not Currect");
                    return;
                }
                else if (btnadd.Text == "Set")
                {

                    dgvsalesdetail.CurrentRow.Cells[3].Value = txtcode.Text.ToString();
                    dgvsalesdetail.CurrentRow.Cells[4].Value = cmbproduct.Text.ToString();
                    dgvsalesdetail.CurrentRow.Cells[5].Value = txtqty.Text.ToString();
                    dgvsalesdetail.CurrentRow.Cells[6].Value = txtrate.Text.ToString();
                    dgvsalesdetail.CurrentRow.Cells[7].Value = txtamt.Text.ToString();
                    dgvsalesdetail.CurrentRow.Cells[9].Value = cmbproduct.SelectedValue;

                    dgvsalesdetail.CurrentRow.Cells[10].Value = hsn;
                    dgvsalesdetail.CurrentRow.Cells[11].Value = cess;
                    dgvsalesdetail.CurrentRow.Cells[12].Value = txtDisPer.Text; 
                    dgvsalesdetail.CurrentRow.Cells[13].Value = txtDAmt.Text;
                    setgrid();
                    btnadd.Text = "Add";
                    dgvsalesdetail.ClearSelection();
                    clear();
                }
                else if (btnadd.Text == "Update1")
                {

                    dgvsalesdetail.CurrentRow.Cells[3].Value = txtcode.Text.ToString();
                    dgvsalesdetail.CurrentRow.Cells[4].Value = cmbproduct.Text.ToString();
                    dgvsalesdetail.CurrentRow.Cells[5].Value = txtqty.Text.ToString();
                    dgvsalesdetail.CurrentRow.Cells[6].Value = txtrate.Text.ToString();
                    dgvsalesdetail.CurrentRow.Cells[7].Value = txtamt.Text.ToString();
                    dgvsalesdetail.CurrentRow.Cells[9].Value = cmbproduct.SelectedValue;

                    dgvsalesdetail.CurrentRow.Cells[10].Value = hsn;
                    dgvsalesdetail.CurrentRow.Cells[11].Value = cess;
                    dgvsalesdetail.CurrentRow.Cells[12].Value = txtDisPer.Text;
                    dgvsalesdetail.CurrentRow.Cells[13].Value = txtDAmt.Text;
                    btnadd.Text = "Add";
                    setgrid();
                    dgvsalesdetail.ClearSelection();
                    clear();
                }
                else if (btnadd.Text == "Add")
                {


                    if (txtcode.Text != "" && cmbproduct.Text != "" && txtqty.Text != "" || txtrate.Text != "" || txtamt.Text != "")
                    {
                        bool flag = checkDuplicateProductinGrid();
                        setgrid();
                        if (flag == true)
                        {
                            clear();
                            return;

                        }
                        int rowcount = dgvsalesdetail.Rows.Count;

                        dgvsalesdetail.Rows.Add();
                        DataGridViewRow row = dgvsalesdetail.Rows[0];
                        //row.Height = 50;

                        dgvsalesdetail.Rows[rowcount].Cells[3].Value = txtcode.Text.ToString();
                        dgvsalesdetail.Rows[rowcount].Cells[4].Value = cmbproduct.Text.ToString();
                        dgvsalesdetail.Rows[rowcount].Cells[5].Value = txtqty.Text.ToString();
                        dgvsalesdetail.Rows[rowcount].Cells[6].Value = txtrate.Text.ToString();
                        dgvsalesdetail.Rows[rowcount].Cells[7].Value = txtamt.Text.ToString();
                        dgvsalesdetail.Rows[rowcount].Cells[9].Value = cmbproduct.SelectedValue;
                        dgvsalesdetail.Rows[rowcount].Cells[8].Value = tax.ToString();//da.value1("select gst from Inventory_Master where Code='" + txtcode.Text + "'");
                        dgvsalesdetail.Rows[rowcount].Cells[11].Value = cess.ToString();
                        dgvsalesdetail.Rows[rowcount].Cells[10].Value = hsn.ToString();
                         dgvsalesdetail.Rows[rowcount].Cells[12].Value = txtDisPer.Text ;
                         dgvsalesdetail.Rows[rowcount].Cells[13].Value = txtDAmt.Text;
                        setgrid();
                        dgvsalesdetail.ClearSelection();
                        cmbproduct.Focus();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Values", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }
                }

            }
            catch { MessageBox.Show("Proudct Add Not Valid (On Button Add Click)"); }
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtcode.Text != "")
            {
                DataSet ds = new DataSet();

                if (MainIndex.dr == 2)
                {
                    ds = da.dataset_ret("select Name,Rate,gst,hsn,cess from Inventory_Master  where Code ='" + txtcode.Text + "'");
                }
                else
                {
                    ds = da.dataset_ret("select Name,Rate,gst,hsn,cess from Inventory_Master  where rkotshow='Yes' and Code ='" + txtcode.Text + "'");
                }
                if (ds.Tables[0].Rows.Count == 0)
                {


                    MessageBox.Show("Please select valid code.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbproduct.Focus();
                    return;
                }
                if(cmbproduct.Text=="")
                {
                    MessageBox.Show("Please select valid product name.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbproduct.Focus();
                    return;
                }
                AddToGrid();
               
            }
        }
        public void fetch()
        {


        }

        private void dgvsalesdetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nRowIndex = e.RowIndex;
            try
            {
                if (e.ColumnIndex == dgvsalesdetail.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    try
                    {
                        //select im.ID, im.Name,im.Code,im.Rate,sgm.Name as SubGroup,um.Name as Unit,hsn.Cat_Name,im.Minlevel,im.Maxlevel,im.Reorder,im.Status,im.FAV 
                        //     id = Convert.ToInt32(dgvsalesdetail.CurrentRow.Cells["ID"].Value);
                        //  txtcode.Text = Convert.ToString(dgvsalesdetail.CurrentRow.Cells["Name"].Value);
                        txtcode.Text = Convert.ToString(dgvsalesdetail.CurrentRow.Cells[3].Value);
                        cmbproduct.Text = Convert.ToString(dgvsalesdetail.CurrentRow.Cells[4].Value);
                        txtqty.Text = Convert.ToString(dgvsalesdetail.CurrentRow.Cells[5].Value);
                        txtrate.Text = Convert.ToString(dgvsalesdetail.CurrentRow.Cells[6].Value);
                        txtamt.Text = Convert.ToString(dgvsalesdetail.CurrentRow.Cells[7].Value);
                        hsn = Convert.ToString(dgvsalesdetail.CurrentRow.Cells[10].Value);
                        cess =Convert.ToDecimal( dgvsalesdetail.CurrentRow.Cells[11].Value);
                        txtDisPer.Text = Convert.ToString(dgvsalesdetail.CurrentRow.Cells[12].Value);
                        txtDAmt.Text = Convert.ToString(dgvsalesdetail.CurrentRow.Cells[13].Value);
                        btnadd.Text = "Set";            
                        setgrid();
                    }


                    catch (Exception ex)
                    {

                    }


                }
                else if (e.ColumnIndex == dgvsalesdetail.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    try
                    {
                        dgvsalesdetail.Rows.RemoveAt(e.RowIndex);
                        setgrid();
                        clear();
                        btnadd.Text = "Add";
                    }
                    catch (Exception ex)
                    {

                    }

                }

            }
            catch { }

        }
        int billno = 0;
        private void SetBillNo() // function for set bill or kot no.
          {
            DataSet ds = new DataSet();
           
            if (Convert.ToInt32(MainIndex.dr) == 2)
            {
                try
                {
                    //billno = Convert.ToInt32(da.value1("select max(BillNo) as BillNo from sale where finyear='" + Form1.CurrFinYear +"' and paymode='" + cmbseries.Text + "' and CompanyId=" + companyid + ""));
                    billno = Convert.ToInt32(da.value1("select max(BillNo) as BillNo from sale where finyear='" + Form1.CurrFinYear + "'  and CompanyId=" + companyid + ""));

                }
                catch 
                {
                    billno = 0;
                    //MessageBox.Show("");
                }
               // ds = da.dataset_ret("select max(BillNo)as BillNo from sale where paymode='" + cmbseries.Text + "' and companyid=" + Convert.ToInt32(companyid));
                if (billno==0)
                {
                    
                    if (cmbseries.Text != "")
                    {
                       // billno = billno + 1;
                        if(cmbseries.Text=="Cash")
                        {
                            billno = Convert.ToInt32(da.value1("select  cashbillno as BillNo from company_master where id=" + companyid));
                            billno = billno + 1;
                            txtbillno.Text = Convert.ToString(billno);
                        }
                        else if (cmbseries.Text == "Card")
                        {
                            billno = Convert.ToInt32(da.value1("select  cardbillno as BillNo from company_master where id=" + companyid));
                            billno = billno + 1;
                            txtbillno.Text = Convert.ToString(billno);
                        }
                        else
                        {
                            billno = billno + 1;
                            txtbillno.Text = Convert.ToString(billno);

                        }
                        
                    }
                    else
                    {
                        billno = Convert.ToInt32(da.value1("select  cashbillno as BillNo from company_master where id=" + companyid));
                        billno = billno + 1;
                        txtbillno.Text = Convert.ToString(billno);
                        cmbseries.Text = "Cash";
                    }
                }
                else
                {
                    try
                    {
                         billno = Convert.ToInt32(billno);
                    }
                    catch
                    {
                        billno = 0;
                    }
                    txtbillno.Text =Convert.ToString(billno + 1);
                }
            }
            else
            {
                try
                {
                    billno = Convert.ToInt32(da.value1("select max(KotNo)as billno from Sale where KotDate='" + Convert.ToString(dtinvoice.Text ) + "' and companyid='"+companyid+"'  "));
                }
                catch 
                {
                    billno = 0;
                }
                    txtbillno.Text = Convert.ToString(billno + 1);
                
            }


        }
        public void clear()
        {
            txtcode.Text = "";
            cmbproduct.Text = "";
            txtqty.Text = "";
            txtrate.Text = "";
            txtamt.Text = "";
            hsn = "";
            cess = 0;
            txtDisPer.Text = "";
            txtDAmt.Text = "";
                       // dgvsalesdetail.Rows.Clear();
            //RefreshPage();
        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {
            try
            {

                decimal val1 = string.IsNullOrEmpty(txtqty.Text) ? 0 : Convert.ToDecimal(txtqty.Text);
                decimal val2 = string.IsNullOrEmpty(txtrate.Text) ? 0 : Convert.ToDecimal(txtrate.Text);
                //if (Convert.ToInt32( txtqty.Text) != 0 || Convert.ToInt32( txtrate.Text) !=0)
                //{
                txtamt.Text = Math.Round((val1 * val2), 2).ToString();
                //}
            }
            catch { }
        }

     

        private void buttonX9_Click(object sender, EventArgs e)
        {
            groupPanel2.Hide();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmledger fl = new frmledger(this.cmbparty,this.cmbMobile);
            fl.ShowDialog();
           cmbproduct.Focus();
           
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

        }

        private void btnledgersave_Click(object sender, EventArgs e)
        {
            //   bool flag = lc.Ledger_InsertUpdate(id, txtname.Text, Convert.ToString(""), Convert.ToString(""), Convert.ToInt32(0), Convert.ToString(""), Convert.ToInt32(0), Convert.ToString(""), Convert.ToInt32(0), companyid, Convert.ToInt32(0), txtmobile.Text, Convert.ToString(""), Convert.ToString(""), Convert.ToString(""), Convert.ToString(""), Convert.ToString(""), Convert.ToString(""), Convert.ToString(""), Convert.ToString(""), Convert.ToString(""), Convert.ToString(""), Convert.ToDecimal(0), Convert.ToString(""), Convert.ToDecimal(0), Convert.ToString(""));
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            KOT_BillNO = 0;
            if (MainIndex.dr == 2)
            {
                optKOT.Checked = true;
                optKOT_Click(sender, e);
            }
            clear();
            RefreshPage();
            RefreshGrid();
            dtinvoice.Value = DateTime.Now;
            groupPanel4.Visible = false;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbProductSearch_Enter(object sender, EventArgs e)
        {
         //   da.fill_combo("select ProductId,im.Name from SaleDetail  as sd join Inventory_Master as im on sd.ProductId=im.ID", cmbProductSearch, "ProductId", "Name");
        }
        public void clearserchfield()
        {
            cmbPaymodeSearch.Text = "";
            cmbpartysearch.Text = "";
            cmbBillSearch.Text = "";
            //dtfromDate.Value = DateTime.Now.Date;
        }
        public void OpenDetial()
        {
            SearchBy = 6;

          //  groupPanel4.Location = new Point(579, 12);
            groupPanel4.Show();
            groupPanel2.BringToFront();
            Data_clss.fill_combo("select ID,Name from Ledger_Master where type='Customer' order by Name", cmbpartysearch, "Name");
            //if (MainIndex.dr == 1)
            //{

            //    Data_clss.fill_combo("select ID,KotNo from Sale where KotNo>0 and CompanyId=" + companyid + " group by KotNo,ID order by KotNo ", cmbBillSearch, "KotNo");
            //}
            //if (MainIndex.dr == 2)
            //{

            //    Data_clss.fill_combo("select ID,BillNo from Sale where BillNo>0 and CompanyId=" + companyid + "  group by BillNo,ID order by BillNo", cmbBillSearch, "BillNo");
            //}
            clearserchfield();
           // cmbPaymodeSearch.Focus();
            FillGrid();
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            KOT_BillNO = 0;
            clear();
            RefreshPage();
            RefreshGrid();
            OpenDetial();
        }
        public void FillGrid()
        {

            try
            {
              
             //  dgvSearchGrid.Rows.Clear();
                // ******************************new code by Rajesh Dave*******************************************************
                string rstr=""; 
                if (MainIndex.dr == 1)
                   {
                    //if(UserType!=0)
                    //{
                       dgvSearchGrid.Columns[1].Visible = true;
                    //}
                       rstr = " and KotDate1 >=  '" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and kotdate1<=  '" + dtfromDate.Value.Date.ToString("yyyy-MM-dd") + "' ";

                        if (cmbPaymodeSearch.Text != "")
                        {
                            rstr=rstr+ " and PayMode='" + cmbPaymodeSearch.Text + "' ";
                        }
                        if (cmbBillSearch.Text != "")
                        {
                            rstr=rstr+ " and KotNo=" + cmbBillSearch.Text;
                        }

                        if (cmbpartysearch.Text != "")
                        {
                            rstr=rstr+" and partyname='" + cmbpartysearch.Text + "' ";

                        }
                       ds = da.dataset_ret("select PayMode,KotNo, KotDate,partyname as Party,NetAmount ,ID from Sale where  KotNo>0  and CompanyId=" + companyid + rstr +" order by KotNo desc");
                   }
                   else
                   {
                       dgvSearchGrid.Columns[1].Visible = true;
                       rstr = " and BillDate1 >=  '" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and billdate1<=  '" + dtfromDate.Value.Date.ToString("yyyy-MM-dd") + "' ";

                        if (cmbPaymodeSearch.Text != "")
                        {
                                rstr=rstr+ " and PayMode='" + cmbPaymodeSearch.Text + "' ";
                        }
                        if (cmbBillSearch.Text != "")
                        {
                                rstr=rstr+ " and BillNo=" + cmbBillSearch.Text;
                        }

                         if (cmbpartysearch.Text != "")
                         {
                             rstr = rstr + " and partyname='" + cmbpartysearch.Text + "' ";

                        }
                 ds = da.dataset_ret("select PayMode,BillNo, BillDate,partyname as Party,NetAmount,ID from Sale where  BillNo>0  and CompanyId=" + companyid + rstr+ " order by BillNo desc");
                   }
                //******************************************************************************************************************

                dgvSearchGrid.DataSource = ds.Tables[0];
                dgvSearchGrid.Columns["ID"].Visible = false;
             double rTotal = 0;
                int intl = 0;
                for (intl = 0; intl <= dgvSearchGrid.RowCount - 1; intl++)
                {
                    dgvSearchGrid.Rows[intl].HeaderCell.Value = Convert.ToString(intl + 1);
                    rTotal = rTotal + Convert.ToDouble(ds.Tables["tab"].Rows[intl]["NetAmount"].ToString());
                   // DataGridViewRow row = dgvSearchGrid.Rows[intl];
                   // row.Height = 40;
                  
                }
                txtGridTotal.Text = rTotal.ToString();
                if(UserType==0)
                {
                    label33.Visible=false;
                    txtGridTotal.Visible = false;
                    buttonX2.Enabled = false;
                }
              //int count = ds.Tables["tab"].Rows.Count;
              //string kot_billNo = "";
              //string kot_billDate = "";
              //double rTotal = 0;
              //for (int i = 0; i < count; i++)
              //{
              //    dgvSearchGrid.Rows.Add();
              //    dgvSearchGrid.Rows[i].Cells[2].Value =Convert.ToString(Convert.ToInt32( i + 1));
              //    dgvSearchGrid.Rows[i].Cells[3].Value = ds.Tables["tab"].Rows[i]["PayMode"].ToString();
              //    if (MainIndex.dr == 1)
              //    {
              //        kot_billNo = "KotNo";
              //        kot_billDate = "KotDate";
              //    }
              //    else 
              //    {
              //        kot_billNo = "BillNo";
              //        kot_billDate="BillDate";
              //    }
               
              //    dgvSearchGrid.Rows[i].Cells[4].Value = ds.Tables["tab"].Rows[i][kot_billNo].ToString();
              //    dgvSearchGrid.Rows[i].Cells[5].Value = ds.Tables["tab"].Rows[i][kot_billDate].ToString();
              //    dgvSearchGrid.Rows[i].Cells[6].Value = ds.Tables["tab"].Rows[i]["Party"].ToString();
              //    dgvSearchGrid.Rows[i].Cells[7].Value = ds.Tables["tab"].Rows[i]["NetAmount"].ToString();
              //    dgvSearchGrid.Rows[i].Cells[8].Value = ds.Tables["tab"].Rows[i]["ID"].ToString();
              //    rTotal = rTotal + Convert.ToDouble(ds.Tables["tab"].Rows[i]["NetAmount"].ToString());
              //    DataGridViewRow row = dgvSearchGrid.Rows[i];
              //    row.Height = 40;
              //}
         
              //if (Convert.ToInt32(Form1.UserID) != 1)
              //{
              //    dgvSearchGrid.Columns[0].Visible = false;
              //}
          
            }
            catch { }
        }
        string TableName = "";
        public static int KOT_BillNOStatic = 0;
        public static string PaymentMode="";
        
        public void SaveData()
        {
            checksave = 0;
          //  try
            //{
                //if (MainIndex.dr == 1)
                //{
                //    btnTransfer.Visible = true;
                //    label14.Text = "KOT NO";
                //    groupPanel3.Text = "KOT Information";
                //    groupPanel1.Text = "KOT Detail";
                //    txtbillno.Text = da.value1("select Max(kotno)+1 from sale where CompanyId=" + companyid + "");

                //}
                //else if (MainIndex.dr == 2)
                //{
                //    label14.Text = "Bill NO";
                //    groupPanel3.Text = "Bill Information";
                //    groupPanel1.Text = "Bill Detail";
                //    txtbillno.Text = da.value1("select Max(BillNo)+1 from sale where PayMode='" + cmbseries.Text + "' and CompanyId=" + companyid + "");

                //}
              
                
                if (cmbseries.Text == "")
                {
                    MessageBox.Show("Please select payment mode.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbseries.Focus();
                    return;
                }
                if (cmbparty.Text == "")
                {
                    MessageBox.Show("Please select party.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbparty.Focus();
                    return;
                }
               
                if (btnSave_Print.Text == "&Save/F1" || btnSave_Print.Text == "&Update/F1")
                {
                    bool flag = true;
                    if (dgvsalesdetail.Rows.Count > 0)
                    {
                        btnSave.Enabled = false;
                        btnSave_Print.Enabled = false;
                        //int partyid = Convert.ToInt32(da.value1("select ID from Ledger_Master where Name='" + cmbparty.Text + "' "));
                        int partyid = Convert.ToInt32(cmbparty.SelectedValue);
                        id = 0;
                        int saleid = 0;
                        if (btnSave_Print.Text == "&Update/F1")//for Update 
                        {
                            //id = Convert.ToInt32(txtbillno.Text);
                            //if (MainIndex.dr == 1)
                            //{
                            //    saleid = Convert.ToInt32(da.value1("select ID from sale where KotNo=" + txtbillno.Text + " and PayMode='" + cmbseries.Text + "' and CompanyId=" + companyid + ""));
                            //}
                            //else 
                            //{
                            //    saleid = Convert.ToInt32(da.value1("select ID from sale where BillNo=" + txtbillno.Text + " and PayMode='"+cmbseries.Text+"' and CompanyId=" + companyid + ""));
                            //}
                            id = KOT_BillNO;
                            saleid = KOT_BillNO;
                        }
                        //else
                        //{
                        //    DataSet rDataset = new DataSet();
                        //    // code for check kot/billno exists or not
                        //    if (MainIndex.dr == 1)
                        //    {
                        //        rDataset = da.dataset_ret("select ID from sale where KotNo=" + txtbillno.Text + "  and CompanyId=" + companyid + " and KotDate='" + Convert.ToString(dtinvoice.Text) + "' ");
                               
                        //    }
                        //    else
                        //    {
                        //        rDataset = da.dataset_ret("select ID from sale where BillNo=" + txtbillno.Text + " and PayMode='" + cmbseries.Text + "' and CompanyId=" + companyid + "");
                               
                        //    }
                        //    if(rDataset.Tables[0].Rows.Count!=0)
                        //    {
                        //        MessageBox.Show("Kot/Bill No.is already exists. Please renter bill details.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        txtcode.Focus();
                        //        return;
                        //    }
                        //}
                        int ordercount = dgvsalesdetail.Rows.Count;
                        bool flag1 = false;
                      
                       
                        if (btnSave_Print.Text != "&Update/F1")
                        {
                            SetBillNo();
                        }
                      
                        try
                        { 
                        if (MainIndex.dr == 1)//for KOT
                        {

                            flag1 = sc.Sale_InsertUpdateint(id, cmbseries.Text, Convert.ToInt32(txtbillno.Text), Convert.ToString(dtinvoice.Text), Convert.ToInt32(0), Convert.ToString(""), Convert.ToInt32(partyid), Convert.ToString(cmbparty.Text), Convert.ToString(cmbMobile.Text), Convert.ToDecimal(txtnetAmount.Text), Form1.LoginUserID, companyid, string.Format("{0:hh:mm tt}", DateTime.Now),Form1.CurrFinYear);
                            KOT_BillNOStatic = Convert.ToInt32(da.value1("select max(ID) from Sale where kotno=" + Convert.ToInt32(txtbillno.Text) + " and CompanyID=" + companyid + ""));
                            da.insert_update_delete(" update sale set username='" +Form1.username+"', PartyAddress='" + Form1.SingleCode(Form1.PartyAddress) + "',PartyGstin='" + Form1.SingleCode(Form1.PartyGST) + "',PartyState='" + Form1.SingleCode(Form1.PartyState) + "', KotDate1 = substring(KotDate,7,4) + '-' + substring(KotDate,4,2)+'-'+substring(KotDate,1,2) where id=" + KOT_BillNOStatic);
                        }
                        else//For Bill
                        {

                            flag1 = sc.Sale_InsertUpdateint(id, cmbseries.Text, Convert.ToInt32(0), Convert.ToString(""), Convert.ToInt32(txtbillno.Text), Convert.ToString(dtinvoice.Text), Convert.ToInt32(partyid), Convert.ToString(cmbparty.Text), Convert.ToString(cmbMobile.Text), Convert.ToDecimal(txtnetAmount.Text), Form1.LoginUserID, companyid, string.Format("{0:hh:mm tt}", DateTime.Now), Form1.CurrFinYear);
                            KOT_BillNOStatic = Convert.ToInt32(da.value1("select max(ID) from Sale where billno=" + Convert.ToInt32(txtbillno.Text) + " and CompanyID=" + companyid + ""));
                            da.insert_update_delete(" update sale set username='" + Form1.username + "', PartyAddress='" + Form1.SingleCode(Form1.PartyAddress) + "',PartyGstin='" + Form1.SingleCode(Form1.PartyGST) + "',PartyState='" + Form1.SingleCode(Form1.PartyState) + "', BillDate1 = substring(BillDate,7,4) + '-' + substring(BillDate,4,2)+'-'+substring(BillDate,1,2) where id=" + KOT_BillNOStatic);

                        }
                     
                        PaymentMode = cmbseries.Text.ToString();
                        string rGridValues = "";
                        if (btnSave_Print.Text == "&Save/F1")
                        {
                           
                                saleid = KOT_BillNOStatic;
                                    //
                                    //Convert.ToInt32(da.value1("select top 1 ID from Sale where CompanyId=" + companyid + " order by id desc"));
                         
                        }
                        else 
                        {
                            da.insert_update_delete("delete from SaleDetail where SaleId=" + saleid + " ");
                        }
                        decimal netamt = Convert.ToDecimal(txtnetAmount.Text);
                        foreach (DataGridViewRow row in dgvsalesdetail.Rows)
                        {
                            double val1 = string.IsNullOrEmpty(row.Cells[12].Value.ToString()) ? 0 : Convert.ToDouble(row.Cells[12].Value.ToString());
                            double val2 = string.IsNullOrEmpty(row.Cells[13].Value.ToString()) ? 0 : Convert.ToDouble(row.Cells[13].Value.ToString());
                           // int productid = Convert.ToInt32(da.value1("select ID from Inventory_Master where Name ='" +row.Cells[4].Value + "'"));
                            if (rGridValues == "")
                            {
                                rGridValues = "(" + Convert.ToInt32(row.Cells[9].Value) + ",'" + Convert.ToDecimal(row.Cells[5].Value) + "'," + Convert.ToString(row.Cells[3].Value) + "," + Convert.ToDecimal(row.Cells[6].Value) + "," + Convert.ToDecimal(row.Cells[7].Value) + "," + Convert.ToDecimal(netamt) + "," + Convert.ToInt32(saleid) + "," + Convert.ToDecimal(row.Cells[8].Value) + ",'" + Form1.SingleCode(row.Cells[4].Value.ToString()) + "','" + Form1.SingleCode(row.Cells[10].Value.ToString()) + "'," + Convert.ToDecimal(row.Cells[11].Value) + ","+Form1.CompanyID+" ,"+val1+","+val2+")";
                            }
                            else
                            {
                                rGridValues = rGridValues + "," + "(" + Convert.ToInt32(row.Cells[9].Value) + ",'" + Convert.ToDecimal(row.Cells[5].Value) + "'," + Convert.ToString(row.Cells[3].Value) + "," + Convert.ToDecimal(row.Cells[6].Value) + "," + Convert.ToDecimal(row.Cells[7].Value) + "," + Convert.ToDecimal(netamt) + "," + Convert.ToInt32(saleid) + "," + Convert.ToDecimal(row.Cells[8].Value) + ",'" + Form1.SingleCode(row.Cells[4].Value.ToString()) + "','" + Form1.SingleCode(row.Cells[10].Value.ToString()) + "'," + Convert.ToDecimal(row.Cells[11].Value) + "," + Form1.CompanyID + " ," + val1 + "," + val2 + "  )";
                            }
                        }
                      
                            da.insert_update_delete("Insert into SaleDetail(ProductId,Qty,Barcode,rate,amount,Netamt,SaleId,taxrate,productname,hsncode,cess,comid,disper,disamt) values "+ rGridValues);
                            checksave = 1;
                            
                       }
                        catch
                        {
                            
                            MessageBox.Show("Data not saved");
                        }

                    }
                    else
                    {
                      MessageBox.Show("Please select product details.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbproduct.Focus();
                        return;
                    }
                }

           
           
        }
        int checksave = 0;
        private void btnSave_Print_Click(object sender, EventArgs e)
        {
            if (MainIndex.dr == 2)
            {
                if (cmbseries.Text == " Unsetteled")
                {
                    MessageBox.Show("Please specify valid payment mode.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbseries.Focus();
                    return;
                }
            }
          
            if (btnSave_Print.Text == "&Update/F1")
            {
                KOT_BillNOStatic = KOT_BillNO;
            }
            if (checksave == 0)
            {
                SaveData();
            }
           // Printreport.Activate();

            if (checksave!=0)
            {
                // MessageBox.Show("Da");
                RefreshPage();
                RefreshGrid();
               
                clear();
                checksave = 0;
                btnSave_Print.Text = "&Save/F1";
                txtBarCode.Focus();
                if(MainIndex.dr==2)
                {
                    optKOT.Checked = true;
                    optKOT_Click(sender, e);
                }
            }
            
        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {
            groupPanel4.Hide();
        }

        private void txtcodSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                FillGrid();
            //    cmbProductSearch.Focus();
            }


        }

        private void cmbProductSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                FillGrid();
               
            }

        }
        int KOT_BillNO = 0;
        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            FillGrid();
            
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void dtfromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                FillGrid();
                SearchBy = 6;
            }
            catch { }
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            groupPanel4.Hide();
            SearchBy = 6;
        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel4_Click(object sender, EventArgs e)
        {

        }

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
                { e.Handled = true; }
                TextBox txtDecimal = sender as TextBox;
                if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void txtmobile_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
                { e.Handled = true; }
                TextBox txtDecimal = sender as TextBox;
               
            }
            catch (Exception ex)
            {
            }
        }

        private void cmbseries_Leave(object sender, EventArgs e)
        {
            if (cmbseries.Text == "")
            {
                return;
            }
            int checkdup = AllCommonFunctions.Check_Duplicacy("PayMode", cmbseries.Text);
            if(checkdup==0)
            {
                MessageBox.Show("Select Proper Mode");
                cmbseries.Focus();
            }
            cmbseries.DroppedDown = false;
            //else
            //{
            //    cmbparty.Focus();
            //}

        }

        private void cmbparty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbparty.Text != "")
                {
                    int checkdup = AllCommonFunctions.Check_Duplicacy("Ledger_Masters", cmbparty.Text);
                    if (checkdup == 0)
                    {
                        MessageBox.Show("Select Proper Name");
                        cmbparty.Focus();
                    }
                    else
                    {

                        cmbMobile.Focus();
                    }
                }
            }
            catch { }
        }

        private void txtcode_Leave(object sender, EventArgs e)
        {
            //if(txtcode.Text!="")
            //{
            //int checkdup = AllCommonFunctions.Check_Duplicacy("Inventory_Mast_Code", txtcode.Text);
            //if (checkdup == 0)
            //{
            //    MessageBox.Show("Select Proper Code");
            //    txtcode.Focus();
            //}
            //else
            //{
            //    cmbproduct.Focus();
            //}
            //}
        }

        private void cmbproduct_Leave(object sender, EventArgs e)
        {
            if (cmbproduct.Text == "")
            {
                return;
            }
            int checkdup = AllCommonFunctions.Check_Duplicacy("Inventory_Mast", cmbproduct.Text);
            if (checkdup == 0)
            {
                MessageBox.Show("Select Proper Product");
                cmbproduct.Focus();
            }
            else
            {
                DataSet ds = new DataSet();
                ds = da.dataset_ret("select Code,Rate,hsn,cess from Inventory_Master where Name='" + cmbproduct.Text + "'");
                txtcode.Text = ds.Tables["tab"].Rows[0]["Code"].ToString();
                txtrate.Text = ds.Tables["tab"].Rows[0]["Rate"].ToString();
                txtqty.Text = "1";
                txtamt.Text = Convert.ToString(Convert.ToDecimal(Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtrate.Text)));
                hsn = ds.Tables["tab"].Rows[0]["hsn"].ToString();
                cess = Convert.ToDecimal(ds.Tables["tab"].Rows[0]["cess"].ToString());
             //   txtcode_KeyDown(sender, null);
                txtqty.Focus();
            }
        }

    
        private void cmbpartysearch_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtpaymode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
            {
                cmbBillSearch.Focus();
            }
        }

        private void cmbBillSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbBillSearch.Focus();
            }
        }

        private void cmbpartysearch_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                dtToDate.Focus();
            }
        }

        private void txtbill_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
                { e.Handled = true; }
                TextBox txtDecimal = sender as TextBox;
               
            }
            catch (Exception ex)
            {
            }
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvupdate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        int GroupId = 0;
        int productID = 0;
        int FavID = 0;
        private void rbGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGroup.Checked == true)
            {
                hexColor = "#97BAF7";
                rbGroup.Checked = true;
                rbGroup.BackColor = Color.LimeGreen;
                rbGroup.ForeColor = Color.White;
                rbProduct.BackColor = Color.FromArgb(224, 224, 224);
                rbProduct.ForeColor = Color.Black;
                rbFav.BackColor = Color.FromArgb(224, 224, 224);
                rbFav.ForeColor = Color.Black;
                GroupId = 1;
                productID = 0;
                FavID = 0;
                productclickcode = 0;
                //allproduct = 0;
                DynamicButton();

            }
            
        }
        int allproduct = 0;
        private void rbProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProduct.Checked == true)
            {
                hexColor = "#F38EBF";
                rbProduct.Checked = true;
                rbGroup.BackColor = Color.FromArgb(224, 224, 224);
                rbGroup.ForeColor = Color.Black;
                rbProduct.BackColor = Color.LimeGreen;
                rbProduct.ForeColor = Color.White; 
                rbFav.BackColor = Color.FromArgb(224, 224, 224);
                rbFav.ForeColor = Color.Black;
                GroupId = 0;
                productID = 1;
                FavID = 0;
                //productclickcode = 1;
                //allproduct = 1;
                if(productclickcode ==0)
                {
                   DynamicButton();
                }
              

            }
        }

        private void rbFav_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFav.Checked == true)
            {
                hexColor = "#1BD578";
                rbFav.Checked = true;
                rbGroup.BackColor = Color.FromArgb(224, 224, 224);
                rbGroup.ForeColor = Color.Black;
                rbProduct.BackColor = Color.FromArgb(224, 224, 224);
                rbProduct.ForeColor = Color.Black;
                rbFav.BackColor = Color.LimeGreen; 
                rbFav.ForeColor = Color.White; 
                GroupId = 0;
                productID = 0;
                FavID = 1;
                //productclickcode = 1;
                //allproduct = 1;
                DynamicButton();

            }

        }

        private void dgvsalesdetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int nRowIndex =-1;
        private void buttonX6_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvsalesdetail.CurrentRow.Cells[5].Value != "" && Convert.ToInt32(dgvsalesdetail.CurrentRow.Cells[5].Value) >= 1)
                {
                 if(nRowIndex==-1)
                 {
                     nRowIndex = dgvsalesdetail.Rows.Count - 1;
                 }
                       
                        dgvsalesdetail.ClearSelection();

                        //  dgvsalesdetail.Rows[nRowIndex].Cells[2].Selected = true;
                        //   int a = Convert.ToInt32(dgvsalesdetail.CurrentRow.Cells[5].Value);
                        int a = Convert.ToInt32(dgvsalesdetail.Rows[nRowIndex].Cells[5].Value);
                        dgvsalesdetail.Rows[nRowIndex].Cells[5].Value = a + 1;
                        // dgvsalesdetail.CurrentRow.Cells[5].Value = a + 1;
                        dgvsalesdetail.Rows[nRowIndex].Cells[7].Value = Convert.ToInt32(dgvsalesdetail.CurrentRow.Cells[5].Value) * Convert.ToDecimal(dgvsalesdetail.CurrentRow.Cells[6].Value);
                        //  dgvsalesdetail.CurrentRow.Cells[7].Value = Convert.ToInt32(dgvsalesdetail.CurrentRow.Cells[5].Value) * Convert.ToDecimal(dgvsalesdetail.CurrentRow.Cells[6].Value);
                        //clear();
                        //txtnetAmount.Text = Convert.ToString(dgvsalesdetail.CurrentRow.Cells[8].Value);
                        dgvsalesdetail.Refresh();
                        setgrid(); 
                 
                   
                }
            }
            catch { }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvsalesdetail.CurrentRow.Cells[5].Value != "" && Convert.ToInt32(dgvsalesdetail.CurrentRow.Cells[5].Value) >= 1)
                {
                    if (nRowIndex == -1)
                    {
                        nRowIndex = dgvsalesdetail.Rows.Count - 1;
                    }
                    dgvsalesdetail.ClearSelection();
                    int a = Convert.ToInt32(dgvsalesdetail.Rows[nRowIndex].Cells[5].Value);
                    if (a == 1)
                    {
                        return;
                    }
                    dgvsalesdetail.Rows[nRowIndex].Cells[5].Value = a - 1;
                    dgvsalesdetail.Rows[nRowIndex].Cells[7].Value = Convert.ToInt32(dgvsalesdetail.CurrentRow.Cells[5].Value) * Convert.ToDecimal(dgvsalesdetail.CurrentRow.Cells[6].Value);
                    dgvsalesdetail.Refresh();
                    setgrid(); 
                    //int a = Convert.ToInt32(dgvsalesdetail.CurrentRow.Cells[5].Value);
                 
                    //dgvsalesdetail.CurrentRow.Cells[5].Value = a - 1;
                    //dgvsalesdetail.CurrentRow.Cells[7].Value = Convert.ToInt32(dgvsalesdetail.CurrentRow.Cells[5].Value) * Convert.ToDecimal(dgvsalesdetail.CurrentRow.Cells[6].Value);
                
                    //setgrid(); 
                }
            }
            catch { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // cmbparty.Tag = cmbMobile.Tag;
             //   cmbparty.Text = Convert.ToString(cmbparty.Tag);
                cmbproduct.Focus();
            }
        }

        

        private void cmbMobile_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(rcheck) != 1)
                {
                    if (rcheckField == 0)
                    {
                        rcheckField = 1;
                        cmbparty.Text = da.value1("select Name from Ledger_Master where  type='Customer' and Mobile='" + cmbMobile.Text + "'");
                        rcheckField = 0;
                    }
                }

            }
            catch { }
        }
        int rcheckField = 0;
        private void cmbparty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(rcheck) != 1)
                {
                    if (rcheckField == 0)
                    {
                        rcheckField = 1;
                        cmbMobile.Text = da.value1("select Mobile from Ledger_Master where type='Customer' and Name='" + cmbparty.Text + "'");
                        rcheckField = 0;
                    }
                }

            }
            catch { }
        }

        

        //private void rbProduct2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rbProduct2.Checked == false)
        //    {
        //        hexColor = "#F38EBF";
        //        rbProduct2.Visible = false;
        //        rbProduct.Visible = true;
        //    }
        //}
        int SearchBy = 0;
        private void cmbPaymodeSearch_TextChanged(object sender, EventArgs e)
        {
            if (cmbPaymodeSearch.Text != "" && cmbPaymodeSearch.Text != "System.Data.DataRowView")
            {

                SearchBy = 4;
                FillGrid();
            }
        }

        private void cmbBillSearch_TextChanged(object sender, EventArgs e)
        {
            if (cmbBillSearch.Text != "" && cmbBillSearch.Text != "System.Data.DataRowView")
            {
               
                SearchBy = 3;
                FillGrid();
            }
        }

        private void cmbpartysearch_TextChanged(object sender, EventArgs e)
        {
            if (cmbpartysearch.Text != "" && cmbpartysearch.Text != "System.Data.DataRowView")
            {
               
                SearchBy = 5;
                FillGrid();
            }
        }

        private void cmbPaymodeSearch_Enter(object sender, EventArgs e)
        {
          //  clearserchfield();
            cmbPaymodeSearch.DroppedDown = true;
        }

        private void cmbBillSearch_Enter(object sender, EventArgs e)
        {
            //clearserchfield();
        }

        private void cmbpartysearch_Enter(object sender, EventArgs e)
        {
           // clearserchfield();
        }

        private void cmbPaymodeSearch_TextUpdate(object sender, EventArgs e)
        {
          
        }

        private void dgvSearchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSearchGrid.Rows.Count > 0)
            {
                try
                {
                    KOT_BillNO = Convert.ToInt32(dgvSearchGrid.CurrentRow.Cells[7].Value);
                }
                catch 
                {
                    MessageBox.Show("Invalid Bill NO:");
                }
                if (dgvSearchGrid.CurrentCell.ColumnIndex == 1)
                {

                    DataSet ds = new DataSet();

                    if (MainIndex.dr == 1)
                    {

                        if (KOT_BillNO == null || KOT_BillNO == 0)
                        {
                            MessageBox.Show("Invalid Selection");
                            return;
                        }
                        ds = da.dataset_ret("select s.id,s.PayMode,s.KotNo,s.KotDate,s.PartyId,s.partyname,s.Mobile,s.NetAmount,sd.Barcode,sd.productname as Product,sd.Qty,sd.rate,sd.amount,sd.taxrate,sd.productid,s.partygstin,s.partyaddress,s.partystate,s.username,sd.hsncode,sd.cess,sd.disper,sd.disamt from Sale as s join SaleDetail as sd on sd.SaleId=s.Id  where s.id=" + KOT_BillNO + " and Paymode='" + dgvSearchGrid.CurrentRow.Cells[2].Value.ToString() + "' and s.KotNo>0 and s.CompanyId=" + companyid + "");

                    }
                    if (MainIndex.dr == 2)
                    {

                        //KOT_BillNO = Convert.ToInt32(dgvSearch.CurrentRow.Cells[3].Value);
                        if (KOT_BillNO == null || KOT_BillNO == 0)
                        {
                            MessageBox.Show("Invalid Selection");
                            return;
                        }
                        ds = da.dataset_ret("select s.id,s.PayMode,s.BillNo,s.BillDate,s.PartyId,s.partyname,s.Mobile,s.NetAmount,sd.Barcode,sd.productname as Product,sd.Qty,sd.rate,sd.amount,sd.taxrate,sd.productid,s.partygstin,s.partyaddress,s.partystate,s.username,sd.hsncode,sd.cess,sd.disper,sd.disamt from Sale as s join SaleDetail as sd on sd.SaleId=s.Id  where s.id=" + KOT_BillNO + " and Paymode='" + dgvSearchGrid.CurrentRow.Cells[2].Value.ToString() + "' and s.BillNo>0 and s.CompanyId=" + companyid + "");

                    }
                    try
                    {
                        cmbseries.Text = ds.Tables["tab"].Rows[0]["PayMode"].ToString();
                        if (MainIndex.dr == 1)
                        {
                            txtbillno.Text = ds.Tables["tab"].Rows[0]["KotNo"].ToString();
                            dtinvoice.Value =Convert.ToDateTime( ds.Tables["tab"].Rows[0]["KotDate"].ToString());
                        }
                        else  
                        {
                            txtbillno.Text = ds.Tables["tab"].Rows[0]["BillNo"].ToString();
                            dtinvoice.Text = ds.Tables["tab"].Rows[0]["BillDate"].ToString();
                        }
                      
                        cmbparty.Text = ds.Tables["tab"].Rows[0]["partyname"].ToString();
                        cmbMobile.Text = ds.Tables["tab"].Rows[0]["Mobile"].ToString();
                        Form1.username = ds.Tables["tab"].Rows[0]["username"].ToString();
                        Form1.PartyAddress = ds.Tables["tab"].Rows[0]["partyaddress"].ToString();
                        Form1.PartyGST = ds.Tables["tab"].Rows[0]["partygstin"].ToString();
                        Form1.PartyState = ds.Tables["tab"].Rows[0]["partystate"].ToString();
                        int countrow = ds.Tables["tab"].Rows.Count;
                        dgvsalesdetail.Rows.Clear();
                        for (int i = 0; i < countrow; i++)
                        {
                            dgvsalesdetail.Rows.Add();
                            dgvsalesdetail.Rows[i].Cells[3].Value = ds.Tables["tab"].Rows[i]["Barcode"].ToString();
                            dgvsalesdetail.Rows[i].Cells[4].Value = ds.Tables["tab"].Rows[i]["Product"].ToString();
                            dgvsalesdetail.Rows[i].Cells[5].Value = ds.Tables["tab"].Rows[i]["Qty"].ToString();
                            dgvsalesdetail.Rows[i].Cells[6].Value = ds.Tables["tab"].Rows[i]["rate"].ToString();
                            dgvsalesdetail.Rows[i].Cells[7].Value = ds.Tables["tab"].Rows[i]["amount"].ToString();
                            dgvsalesdetail.Rows[i].Cells[8].Value = ds.Tables["tab"].Rows[i]["taxrate"].ToString();
                            dgvsalesdetail.Rows[i].Cells[9].Value = ds.Tables["tab"].Rows[i]["productid"].ToString();

                            dgvsalesdetail.Rows[i].Cells[10].Value = ds.Tables["tab"].Rows[i]["hsncode"].ToString();
                            dgvsalesdetail.Rows[i].Cells[11].Value = ds.Tables["tab"].Rows[i]["cess"].ToString();

                            dgvsalesdetail.Rows[i].Cells[12].Value = ds.Tables["tab"].Rows[i]["disper"].ToString();
                            dgvsalesdetail.Rows[i].Cells[13].Value = ds.Tables["tab"].Rows[i]["disamt"].ToString();
                        }
                        setgrid();
                        btnSave_Print.Text = "&Update/F1";
                        groupPanel4.Visible = false;
                        if(UserType==0)
                        {
                            btnSave.Enabled = false;
                            btnSave_Print.Enabled = false;
                        }
                        else
                        {
                            if(MainIndex.dr==1)
                            {
                                btnSave.Enabled = true;
                                btnSave_Print.Enabled = true;
                            }
                            else
                            {
                                btnSave.Enabled = false;
                                btnSave_Print.Enabled = false;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("There are no product available.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSave_Print.Text = "&Update/F1";
                        groupPanel4.Visible = false;
                    }

                }
                if (dgvSearchGrid.CurrentCell.ColumnIndex == 0)
                {
                    if (MessageBox.Show("Are you sure to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                       
                        if (MainIndex.dr == 1)
                        {
                            int saleidFordelete = Convert.ToInt32(da.value1("select ID from Sale where id=" + KOT_BillNO + " and CompanyId=" + companyid + ""));
                            da.insert_update_delete("delete from Sale where id=" + KOT_BillNO + ";;delete from SaleDetail where SaleId=" + KOT_BillNO + "");
                            FillGrid();
                            clear();
                            RefreshPage();
                            RefreshGrid();
                        }
                        if (MainIndex.dr == 2)
                        {
                            int saleidFordelete = Convert.ToInt32(da.value1("select ID from Sale where id=" + KOT_BillNO + " and CompanyId=" + companyid + ""));
                            da.insert_update_delete("delete from Sale where id=" + KOT_BillNO + ";;delete from SaleDetail where SaleId=" + KOT_BillNO + "");
                            FillGrid();
                            clear();
                            RefreshPage();
                            RefreshGrid();
                        }

                    }
                }
            }
        }

        private void cmbPaymodeSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbPaymodeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbBillSearch.Focus();
            }
        }

        private void cmbBillSearch_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void dtToDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                dtfromDate.Focus();
            }
        }

        private void dtfromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    FillGrid();
                    SearchBy = 0;
                }
                catch { }
            }
            
        }

        private void cmbseries_TextChanged(object sender, EventArgs e)
        {
            if (MainIndex.dr == 2)
            {
                //try
                //{
                //    billno = Convert.ToInt32(da.value1("select max(BillNo) as BillNo from sale where PayMode='" + cmbseries.Text + "' and CompanyId=" + companyid + "")) + 1;
                //}
                //catch 
                //{
                //    billno = 1;
                //}
                //if (billno == 0)
                //{
                //    billno = 1;
                //}
                //    txtbillno.Text = Convert.ToString(billno);
                SetBillNo();
            }
        }

        private void SalesForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 112)
            //{
            //    SaveData();
            //    return;
            //}

            //if (e.KeyChar == 113)
            //{

            //}

            //if (e.KeyChar == 114)
            //{

            //}

            //if (e.KeyChar == 115)
            //{

            //}
            //if (e.KeyChar == 116)
            //{

            //}
            //if (e.KeyChar == 117)
            //{

            //}
            //if (e.KeyChar == 118)
            //{

            //}

            //if (e.KeyChar == 119)
            //{
            //    OpenDetial();
            //    return;
            //}
            //if (e.KeyChar == 120)
            //{
            //    clear();
            //    RefreshPage();
            //    return;
            //}
            //if (e.KeyChar == 121)
            //{

            //}
            //if (e.KeyChar == 122)
            //{

            //}
            //if (e.KeyChar == 123)
            //{
            //    this.Hide();
            //    return;
            //}
        }
        CommonMasterClass com = new CommonMasterClass();
     
        private void buttonX3_Click_1(object sender, EventArgs e)
        {
            
            
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSearchGrid.Rows.Count != 0)
                {
                    if (KOT_BillNO==0)
                    {
                        MessageBox.Show("Please select kot no. for transfer to bill.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    grpBillDetail.Visible = true;
                    if (KOT_BillNO.ToString() != "")
                    {
                        if (KOT_BillNO != 0)
                        {
                            txtKOTNo1.Text = dgvSearchGrid.CurrentRow.Cells[3].Value.ToString();
                            txtKOTNo1.Tag = dgvSearchGrid.CurrentRow.Cells[2].Value.ToString();
                        }

                    }

                    cmbPayMode1.Text = "Cash";
                    cmbParty2.Text = "CASH";
                    txtKOTNo1.Focus();
                    //if (dgvSearchGrid.CurrentRow.Cells[2].Value.ToString()==" Unsetteled")
                    //{
                    //    MessageBox.Show("Selected Kot payment mode is not setteled."+Environment.NewLine+"Please set payment mode and try again for transfer into bill.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                    //if (MessageBox.Show("Are you sure to Transfer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    //{
                        
                    //}
                }
                else 
                {
                    MessageBox.Show("There are no kot no. for transfer to bill.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }

        private void chkForSearchDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkForSearchDate.Checked == true)
            {
                pnlfordatesearch.Enabled = true;
                SearchBy = 6;
            }
            else 
            {
                pnlfordatesearch.Enabled = false;
                SearchBy = 0;
            }
        }
        public void printdata(string rMode)
        {
          //  crystalReportViewer1.ReportSource = null;
            if (MainIndex.dr == 1)
            {
                int ID = Convert.ToInt32(KOT_BillNOStatic);

                DataSet ds = new DataSet();
                DataView dv = new DataView();
                ds = com.Member_Milk_Search_DailyReport_Print(ID, companyid);
               // ReportDocument rd = new ReportDocument();
              //  rd.Load(Application.StartupPath + "/Reports/REP_KOT.rpt");
              //  dv = ds.Tables[0].DefaultView;

                //rd.SetDataSource(ds.Tables[0]);

               // rd.PrintToPrinter(1, true, 0, 0);
              //    crystalReportViewer1.ReportSource = rd;
                REP_KOT repkot = new REP_KOT();
                repkot.SetDataSource(ds.Tables[0]);
                string rline = File.ReadAllText(Application.StartupPath + "//printer.txt");

                repkot.PrintOptions.PrinterName = rline;
                repkot.PrintToPrinter(1, true, 0, 0);
                if(rMode=="Card")
                {
                    repkot.PrintToPrinter(1, true, 0, 0);
                }
                if (rMode == "Online")
                {
                    repkot.PrintToPrinter(1, true, 0, 0);
                }
               // repkot.Refresh();
                repkot.Close();
                repkot.Dispose();
               
            }
            if (MainIndex.dr == 2)
            {
                int ID = Convert.ToInt32(KOT_BillNOStatic);

                DataSet ds = new DataSet();
                DataView dv = new DataView();
                ds = com.Member_Milk_Search_DailyReport_Print(ID,PaymentMode,companyid);
                //ReportDocument rd = new ReportDocument();
                //rd.Load(Application.StartupPath + "/Reports/REP_BILL.rpt");
                // dv = ds.Tables[0].DefaultView;

               // rd.SetDataSource(ds.Tables[0]);

           //rd.PrintToPrinter(1, true, 0, 0);
           // crystalReportViewer1.ReportSource = rd;
                REP_BILL repbill = new REP_BILL();
                repbill.SetDataSource(ds.Tables[0]);

                string rline = File.ReadAllText(Application.StartupPath + "//printer.txt");

                repbill.PrintOptions.PrinterName = rline;
                repbill.PrintToPrinter(1, true, 0, 0);
                if (rMode == "Card")
                {
                    repbill.PrintToPrinter(1, true, 0, 0);
                }
                if (rMode == "Online")
                {
                    repbill.PrintToPrinter(1, true, 0, 0);
                }
               // repbill.Refresh();
                repbill.Close();
                repbill.Dispose();
            }
            
          
      }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.EnableRaisingEvents = false;
            //proc.StartInfo.FileName = Application.StartupPath + "\\testvb\\BILL.exe";
            //proc.Start();
            //return;
            if (MainIndex.dr == 2)
            {
                if (cmbseries.Text == " Unsetteled")
                {
                    MessageBox.Show("Please specify valid payment mode.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbseries.Focus();
                    return;
                }
            }
            if (btnSave_Print.Text == "&Update/F1")
            {
                KOT_BillNOStatic = KOT_BillNO;
                PaymentMode = cmbseries.Text;
                if (checksave == 0)
                {
                    SaveData();
                }
                
            }
            else
            {
                if (checksave == 0)
                {
                    SaveData();
                }
            }

            //NewPrintDataAccess(KOT_BillNOStatic);
            //PrintReport obj_report = new PrintReport();

            //obj_report.ShowDialog();
            if (checksave!=0)
            {

             printdata(cmbseries.Text);
                // MessageBox.Show("Da");
                RefreshPage();
                RefreshGrid();
               
                clear();
                txtBarCode.Focus();
                checksave = 0;
                btnSave_Print.Text = "&Save/F1";
                if (MainIndex.dr == 2)
                {
                    optKOT.Checked = true;
                    optKOT_Click(sender, e);
                }
            }
        }
        public  void NewPrintDataAccess(int ID)
        {
            int billtag=0;
            DataSet ds = new DataSet();
            // **********************printing record retrieve from sql by store procedure*********************
            if (MainIndex.dr == 1)
            {
              

                ds = com.Member_Milk_Search_DailyReport_Print(ID, companyid);
                billtag=1; // for kot
            }
            else
            {

              
              
                ds = com.Member_Milk_Search_DailyReport_Print(ID, PaymentMode, companyid);
                billtag=2; // for bill
            }
            //**************************************************************************************************
            int intLoop = 0;
            string billData = "";
           
                //********************* connect with access database and fill printing value**************************************
                    OleDbConnection con = new OleDbConnection(File.ReadAllText(Application.StartupPath + "//dbpath.txt"));
                    con.Open();
                    OleDbCommand rCommand = new OleDbCommand();
                    rCommand.Connection = con;
                    for (intLoop = 0; intLoop < ds.Tables[0].Rows.Count; intLoop++)
                    {

                        rCommand.CommandText = "insert into sale ( Id,Bill_NO,DT,Address1,Address2,Address3,CompanyGST,Mobile,NET_TOTAL,PartyId,MEM_NAME,UserName,Code,Amount,Name,Qty,RATE,Vat_Name,BTYPE,Vat_Per,HSN_Code,GST_No,TaxAmount,cess,billtag,hcl) values (" + ds.Tables[0].Rows[intLoop]["Id"].ToString() + "," + ds.Tables[0].Rows[intLoop]["Bill_NO"].ToString() + ",'" + ds.Tables[0].Rows[intLoop]["DT"].ToString() + "','" + ds.Tables[0].Rows[intLoop]["Address1"].ToString() + "','" + ds.Tables[0].Rows[intLoop]["Address2"].ToString() + "','" + ds.Tables[0].Rows[intLoop]["Address3"].ToString() + "','" + ds.Tables[0].Rows[intLoop]["CompanyGST"].ToString() + "','" + ds.Tables[0].Rows[intLoop]["Mobile"].ToString() + "', " +
                                         "   " + Convert.ToDouble(ds.Tables[0].Rows[intLoop]["NET_TOTAL"].ToString()) + "," + ds.Tables[0].Rows[intLoop]["PartyId"].ToString() + ",'" + ds.Tables[0].Rows[intLoop]["MEM_NAME"].ToString() + "','" + ds.Tables[0].Rows[intLoop]["UserName"].ToString() + "','" + ds.Tables[0].Rows[intLoop]["Code"].ToString() + "', " + Convert.ToDouble(ds.Tables[0].Rows[intLoop]["Amount"].ToString()) + ",'" + ds.Tables[0].Rows[intLoop]["Name"].ToString() + "', " +
                                         "  " + Convert.ToDouble(ds.Tables[0].Rows[intLoop]["Qty"].ToString()) + "," + Convert.ToDouble(ds.Tables[0].Rows[intLoop]["RATE"].ToString()) + ",'" + ds.Tables[0].Rows[intLoop]["Vat_Name"].ToString() + "','" + ds.Tables[0].Rows[intLoop]["BTYPE"].ToString() + "'," + Convert.ToDouble(ds.Tables[0].Rows[intLoop]["Vat_Per"].ToString()) + ",'" + ds.Tables[0].Rows[intLoop]["HSN_Code"].ToString() + "','" + ds.Tables[0].Rows[intLoop]["GST_No"].ToString() + "' , " +
                                         " " + Convert.ToDouble(ds.Tables[0].Rows[intLoop]["TaxAmount"].ToString()) + "," + Convert.ToDouble(ds.Tables[0].Rows[intLoop]["cess"].ToString()) + "," + billtag + ",1)";
                        rCommand.ExecuteNonQuery();
                    }
                    
                //***********************************************************************************************************************
                //**********************call another exe for print record***********************************
                 //System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.EnableRaisingEvents = false;
            //proc.StartInfo.FileName = Application.StartupPath + "\\testvb\\BILL.exe";
            //proc.Start();
                //********************************************************************************************
           // frmCrystalReport.ReportName = "test";
           // frmCrystalReport obj_report = new frmCrystalReport();
          //  obj_report.ShowDialog();
          // rpttest test = new rpttest();
           
      //     test.PrintToPrinter(1, true, 0, 0);

            //OleDbDataAdapter da = new OleDbDataAdapter();
         
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            //da.SelectCommand = new OleDbCommand("SELECT * FROM FooTable", con);
            
            //da.Fill(ds, "FooTable");
            //dt = ds.Tables["FooTable"];

        }
        private void buttonX2_Click_2(object sender, EventArgs e)
        {
            if (dgvSearchGrid.Rows.Count != 0)
            {
                KOT_BillNOStatic = Convert.ToInt32(dgvSearchGrid.CurrentRow.Cells[7].Value);
                PaymentMode = dgvSearchGrid.CurrentRow.Cells[2].Value.ToString();
                printdata(PaymentMode);
                //PrintReport obj_report = new PrintReport();
                //obj_report.ShowDialog();
            }
            else { MessageBox.Show("data not valid"); }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupPanel6_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void txttotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnclosesales_Click(object sender, EventArgs e)
        {
            groupPanel6.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                panelforcollection.Enabled = true;
              
            }
            else
            {
                panelforcollection.Enabled = false;
               
            }

        }

        private void buttonX3_Click_2(object sender, EventArgs e)
        {
        string    fromdate = dtfromdatesearch.Text;
          string  todate = dttodatesearch.Text;
           
Netamt();
        }
           public void Netamt()
           {
               string fromdate = dtfromdatesearch.Value.Date.ToString("yyyy-MM-dd");
               string todate = dttodatesearch.Value.Date.ToString("yyyy-MM-dd");
         
       
           //if(checkBox1.Checked==true)
           //{
           //  //  ds = sc.SalesCollection_SearchData(fromdate, todate);
           ////    ds = da.dataset_ret("select sum(NetAmount) as NetCashAmount from Sale where PayMode ='cash' and BillDate between '" + fromdate + "' and '" + todate + "' ;select sum(NetAmount) as NetCreditAmount from Sale where PayMode ='Credit' and BillDate between '" + fromdate + "' and '" + todate + "';select sum(NetAmount) as NetCardAmount from Sale where PayMode ='card' and BillDate between '" + fromdate + "' and '" + todate + "'");
           ////    txtcash.Text = ds.Tables["tab"].Rows[0]["NetCashAmount"].ToString();
           ////    txtcredit.Text = ds.Tables["tab"].Rows[0]["NetCreditAmount"].ToString();
           ////    txtcard.Text = ds.Tables["tab"].Rows[0]["NetCardAmount"].ToString();
           //    txtcash.Text=da.value1("select sum(NetAmount) as NetCashAmount from Sale where PayMode ='cash' and BillDate between '" + fromdate + "' and '" + todate + "'");
           //    txtcredit.Text = da.value1("select sum(NetAmount) as NetCashAmount from Sale where PayMode ='credit' and BillDate between '" + fromdate + "' and '" + todate + "'");
           //    txtcard.Text = da.value1("select sum(NetAmount) as NetCashAmount from Sale where PayMode ='card' and BillDate between '" + fromdate + "' and '" + todate + "'");
           //}
           //else
           //{
           //  //  ds = da.dataset_ret("select sum(NetAmount) as NetCashAmount from Sale where PayMode ='cash' and BillDate between '" + fromdate + "' and '" + todate + "' ,select sum(NetAmount) as NetCreditAmount from Sale where PayMode ='Credit' and BillDate between '" + fromdate + "' and '" + todate + "',select sum(NetAmount) as NetCardAmount from Sale where PayMode ='card' and BillDate between '" + fromdate + "' and '" + todate + "'");
           //    txtcash.Text = da.value1("select sum(NetAmount) as NetCashAmount from Sale where PayMode ='cash' and BillDate between '" + fromdate + "' and '" + todate + "'");
           //    txtcredit.Text = da.value1("select sum(NetAmount) as NetCashAmount from Sale where PayMode ='credit' and BillDate between '" + fromdate + "' and '" + todate + "'");
           //    txtcard.Text = da.value1("select sum(NetAmount) as NetCashAmount from Sale where PayMode ='card' and BillDate between '" + fromdate + "' and '" + todate + "'");
           
           //}
          txtcash.Text = "";
          txtcard.Text = "";
          txtcredit.Text = "";
          ds = da.dataset_ret("select sum(netamount)as amt ,paymode from sale where ((kotDate1 >= '" + fromdate + "' and kotdate1<='" + todate + "') or (billDate1 >= '" + fromdate + "' and billdate1<='" + todate + "')) and CompanyId=" + companyid + " group by paymode");
           if(ds.Tables[0].Rows.Count>0)
           {
               int loop = 0;
               for(loop=0;loop<ds.Tables[0].Rows.Count;loop++)
               {
                   if(ds.Tables[0].Rows[loop]["paymode"].ToString()=="Cash")
                   {
                       txtcash.Text = ds.Tables[0].Rows[loop]["amt"].ToString();
                   }
                   else if (ds.Tables[0].Rows[loop]["paymode"].ToString() == "Card")
                   {
                       txtcard.Text = ds.Tables[0].Rows[loop]["amt"].ToString();
                   }
                   else if (ds.Tables[0].Rows[loop]["paymode"].ToString() == "Credit")
                   {
                       txtcredit.Text = ds.Tables[0].Rows[loop]["amt"].ToString();
                   }
               }
           }
               if(txtcash.Text=="")
            {
          txtcash.Text = Convert.ToString(0); 
            }
            if (txtcard.Text == "")
            {
                txtcard.Text = Convert.ToString(0);
            }
            if (txtcredit.Text == "")
            {
                txtcredit.Text = Convert.ToString(0);
            }
            decimal total = Convert.ToDecimal(Convert.ToDecimal(txtcard.Text) + Convert.ToDecimal(txtcash.Text) + Convert.ToDecimal(txtcredit.Text));
           txttotal.Text = Convert.ToString(total);
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            groupPanel6.Location = new Point(1, 59);
            groupPanel6.Show();

        }

        private void SalesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
               // SendKeys.Send("{TAB}");
                //return;
               // groupPanel6.Location = new Point(1, 59);
                if (UserType == 0) { return; }
                dtfromdatesearch.Value = DateTime.Today;
                dttodatesearch.Value = DateTime.Today;
                groupPanel6.Show();
                Netamt();
            }
            else if (e.KeyCode == Keys.F1)
            {
               
             if(btnSave_Print.Enabled==true)
             {
                 btnSave_Print_Click(sender, e);
             }
              
                return;
            }
            else if (e.KeyCode == Keys.F6)
            {
                button2_Click(sender, e);
                return;
            }
            else if (e.KeyCode == Keys.F2)
            {
                if(btnSave.Enabled==true)
                {
                    btnSave_Click(sender, e);
                }
                return;
            }
            else if (e.KeyCode == Keys.F8)
            {
                OpenDetial();
                return;
            }
            else if (e.KeyCode == Keys.F9)
            {
                clear();
                RefreshPage();
                RefreshGrid();
                return;
            }
            else if (e.KeyCode == Keys.F11)
            {
                this.Close();
                return;
            }
            else if (e.KeyCode == Keys.F12)
            {
                button1_Click(sender, e);
                return;
            }
            else if (e.KeyCode == Keys.F7)
            {
                buttonX1_Click(sender, e);
                return;
            }

            else if (e.KeyCode == Keys.Escape)
            {
                if (groupPanel4.Visible == true)
                {
                    groupPanel4.Visible = false;
                    return;
                }

                else if (groupPanel6.Visible == true)
                {
                    groupPanel6.Visible = false;
                }

            }
        
        }

        private void txtrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
                { e.Handled = true; }
                TextBox txtDecimal = sender as TextBox;
                if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void rbGroup_Click(object sender, EventArgs e)
        {
            
        }

        private void rbProduct2_Click(object sender, EventArgs e)
        {
           
        }

        private void rbFav_Click(object sender, EventArgs e)
        {
           
        }

        private void txtcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Delete || e.KeyChar == 8 || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cmbBillSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Delete || e.KeyChar == 8 || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtBarCode_Enter(object sender, EventArgs e)
        {
          
          
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
     
    {
            if(e.KeyChar==(char)13) 
            {
                if(txtBarCode.Text=="")
                {
                    return;
                }
               string barcode = (txtBarCode.Text);
               txtBarCode.Text = barcode.ToString();
               if (barcode != "")
                {
                    DataSet ds = new DataSet();
                    txtamt.Text = Convert.ToString(0);
                    txtqty.Text = Convert.ToString(0);
                   if(MainIndex.dr==2)
                   {
                       ds = da.dataset_ret("select Name,Rate,code,gst,id,cess,hsn from Inventory_Master  where (Code ='" + barcode + "' or maxlevel="+barcode+")");

                   }
                   else
                   {
                       ds = da.dataset_ret("select Name,Rate,code,gst,id,cess,hsn from Inventory_Master  where rkotshow='Yes' and (Code ='" + barcode + "' or maxlevel=" + barcode + ")");

                   }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtcode.Text = ds.Tables["tab"].Rows[0]["code"].ToString();
                        cmbproduct.Text = ds.Tables["tab"].Rows[0]["Name"].ToString();
                        cmbproduct.SelectedValue = ds.Tables["tab"].Rows[0]["id"].ToString();
                        txtrate.Text = ds.Tables["tab"].Rows[0]["Rate"].ToString();
                        txtqty.Text = "1";
                        hsn = ds.Tables["tab"].Rows[0]["hsn"].ToString();
                        cess = Convert.ToDecimal(ds.Tables["tab"].Rows[0]["cess"].ToString());
                        txtamt.Text = Convert.ToString(Convert.ToDouble(Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtrate.Text)));
                        if (ds.Tables["tab"].Rows[0]["gst"].ToString()!="")
                        {
                            tax = Convert.ToDecimal(ds.Tables["tab"].Rows[0]["gst"].ToString());
                        }
                        else
                        {
                            tax = 0;
                        }
                        AddToGrid();
                        dgvsalesdetail.ClearSelection();
                        txtBarCode.Text = "";
                        clear();
                        txtBarCode.Focus();
                    }
                    else 
                    {
                        txtBarCode.Text = "";
                    }
                }
            }
           

        }

        private void optKOT_Click(object sender, EventArgs e)
        {
            MainIndex.dr = 1;
            RefreshPage();
            RefreshGrid();
            groupPanel4.Visible = false;
        }

        private void optSale_Click(object sender, EventArgs e)
        {
            MainIndex.dr = 2;
           
            if (btnSave_Print.Text == "&Update/F1")
            {
                RefreshGrid();
            }
            else
            {
                if (dgvsalesdetail.Rows.Count == 0)
                {
                    RefreshGrid();
                }
            }
            RefreshPage();
            groupPanel4.Visible = false;
        }

        private void A_Click(object sender, EventArgs e)
        {

            DynamicButtonAlpha("A");
        }
        void SmallButtonMouse_Hover(object sender, EventArgs e)
        {
            var b = sender as Button;
            b.BackColor = Color.LimeGreen;
        }
        void SmallButtonMouse_Leave(object sender, EventArgs e,string Co)
        {
            var b = sender as Button;
            b.BackColor=Color.FromName(Co);
        }

        private void B_Click_1(object sender, EventArgs e)
        {
            DynamicButtonAlpha("B");
        }

        private void D_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("D");
        }

        private void E_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("E");
        }

        private void C_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("C");
        }

        private void F_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("F");
        }

        private void G_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("G");
        }

        private void bHutton4_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("H");
        }

        private void I_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("I");
        }

        private void J_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("J");
        }

        private void K_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("K");
        }

        private void L_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("L");
        }

        private void M_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("M");
        }

        private void N_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("N");
        }

        private void O_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("O");
        }

        private void P_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("P");
        }

        private void Q_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("Q");
        }

        private void R_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("R");
        }

        private void S_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("S");
        }

        private void T_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("T");
        }

        private void U_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("U");
        }

        private void V_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("V");
        }

        private void W_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("W");
        }

        private void X_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("X");
        }

        private void Y_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("Y");
        }

        private void Z_Click(object sender, EventArgs e)
        {
            DynamicButtonAlpha("Z");
        }

        private void txtrate_TextChanged(object sender, EventArgs e)
        {
            try
            {

                decimal val1 = string.IsNullOrEmpty(txtqty.Text) ? 0 : Convert.ToDecimal(txtqty.Text);
                decimal val2 = string.IsNullOrEmpty(txtrate.Text) ? 0 : Convert.ToDecimal(txtrate.Text);
                //if (Convert.ToInt32( txtqty.Text) != 0 || Convert.ToInt32( txtrate.Text) !=0)
                //{
                txtamt.Text = Math.Round((val1 * val2), 2).ToString();
                //}
            }
            catch { }
        }

        private void cmbparty_Validating(object sender, CancelEventArgs e)
        {
            DataSet ds = new DataSet();
           if(Convert.ToInt32(cmbparty.SelectedValue)!=0)
           {
               ds = da.dataset_ret("select GSTNumber,address1,address2,state from ledger_master  where id =" + Convert.ToInt32(cmbparty.SelectedValue));
               Form1.PartyAddress = ds.Tables[0].Rows[0]["address1"].ToString() + " " + ds.Tables[0].Rows[0]["address2"].ToString();
               Form1.PartyGST = ds.Tables[0].Rows[0]["GSTNumber"].ToString();
               Form1.PartyState = ds.Tables[0].Rows[0]["state"].ToString();
           }
           else
           {
               Form1.PartyAddress = "";
               Form1.PartyGST = "";
               Form1.PartyState = "";
           }

        }

        private void cmbMobile_Validating(object sender, CancelEventArgs e)
        {
            DataSet ds = new DataSet();
            if (cmbMobile.Text!="")
            {
                ds = da.dataset_ret("select GSTNumber,address1,address2,state from ledger_master  where mobile ='" + cmbMobile.Text + "' ");
                if(ds.Tables[0].Rows.Count>0)
                {
                    Form1.PartyAddress = ds.Tables[0].Rows[0]["address1"].ToString() + " " + ds.Tables[0].Rows[0]["address2"].ToString();
                    Form1.PartyGST = ds.Tables[0].Rows[0]["GSTNumber"].ToString();
                    Form1.PartyState = ds.Tables[0].Rows[0]["state"].ToString();
                }
                else
                {
                    Form1.PartyAddress = "";
                    Form1.PartyGST = "";
                    Form1.PartyState = "";
                }
            }
            else
            {
                Form1.PartyAddress = "";
                Form1.PartyGST = "";
                Form1.PartyState = "";
            }
        }

        private void cmbChooseMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnPendingKotSave_Click(sender, e);
            }
        }

        private void btnPendingKotSave_Click(object sender, EventArgs e)
        {
            try
            {
              if(textBox2.Text.Trim()=="")
                {
                    MessageBox.Show("Please specify Kot No. to be set payment mode.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Focus();
                    return;
                }
                if(textBox2.Tag!="")
                {
                    if(textBox2.Tag.ToString().Trim()==cmbChooseMode.Text.Trim())
                    {
                        MessageBox.Show("Please select different payment mode.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbChooseMode.Focus();
                        return;
                    }
                }
                DataSet rsTemp = new DataSet();
                if (MainIndex.dr == 1)
                {
                    rsTemp = da.dataset_ret("select top 1 id,importtag from sale where companyid=" +Form1.CompanyID+" and kotno=" + textBox2.Text.TrimStart('0') + " order by id desc");

                }
                else
                {
                    rsTemp = da.dataset_ret("select top 1 id,importtag from sale where PayMode='" + textBox2.Tag.ToString() + "' and  companyid=" + Form1.CompanyID + " and finyear='" + Form1.CurrFinYear + "' and billno=" + textBox2.Text.TrimStart('0') + " order by id desc");
                }
                if(rsTemp.Tables[0].Rows.Count==0)
                {
                    MessageBox.Show("Specified  No. is not valid. Please try again.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Focus();
                    return;
                }
                else
                {
                    if(Convert.ToInt32(rsTemp.Tables[0].Rows[0]["importtag"].ToString())==1)
                    {
                        MessageBox.Show("You cannot change payment mode. Day End has done for this no.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Focus();
                        return;
                    }
                }
                if(MainIndex.dr==1)
                {
                    da.insert_update_delete("Update sale set paymode='" + cmbChooseMode.Text + "' where Id=" + rsTemp.Tables[0].Rows[0]["id"].ToString());

                }
                else
                {
                    int billno1 = 0;
                    //billno1 = Convert.ToInt32(da.value1("select isnull(max(BillNo),0) as BillNo from sale where finyear='" + Form1.CurrFinYear + "' and paymode='" + cmbChooseMode.Text + "' and CompanyId=" + companyid + ""));
                    //billno1 = Convert.ToInt32(billno1) + 1;
                    //da.insert_update_delete("Update sale set billno=" +( billno1) + " , paymode='" + cmbChooseMode.Text + "' where Id=" + rsTemp.Tables[0].Rows[0]["id"].ToString());
                    da.insert_update_delete("Update sale set paymode='" + cmbChooseMode.Text + "' where Id=" + rsTemp.Tables[0].Rows[0]["id"].ToString());
                }
            
                grpChooseMode.Visible = false;
                textBox2.Text = "";
                textBox2.Tag = "";
                txtKotno.Text = "";
                KOT_BillNO = 0;
                FillGrid();

            }
            catch { }
        }

        private void txtKotno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtKotno.Text == "")
                {
                    return;
                }
                DataSet rsTemp = new DataSet();
                rsTemp = da.dataset_ret("select top 1 id from sale where kotno=" + txtKotno.Text.TrimStart('0') + " order by id desc");
                if (rsTemp.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Specified Kot No. is not valid. Please try again.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Focus();
                  
                    return;
                }
                KOT_BillNO = Convert.ToInt32(rsTemp.Tables[0].Rows[0]["id"].ToString());
                btnTransfer_Click(sender, e);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cmbChooseMode.Focus();
            }
        }

        private void cmbChooseMode_Leave(object sender, EventArgs e)
        {
            if (cmbChooseMode.Text == "")
            {
                return;
            }
            int checkdup = AllCommonFunctions.Check_Duplicacy("PayMode", cmbChooseMode.Text);
            if (checkdup == 0)
            {
                MessageBox.Show("Select Proper Mode");
                cmbChooseMode.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grpChooseMode.Visible = true;
            if(KOT_BillNO.ToString()!="")
            {
                if (KOT_BillNO!=0)
                {
                    textBox2.Text = dgvSearchGrid.CurrentRow.Cells[3].Value.ToString();
                    textBox2.Tag = dgvSearchGrid.CurrentRow.Cells[2].Value.ToString();
                }
                
            }
           
            cmbChooseMode.Text = "Cash";
            //if (dgvSearchGrid.SelectedCells.Count>0)
            //{
            //    textBox2.Text = dgvSearchGrid.CurrentRow.Cells[3].Value.ToString();
            //}
            //else
            //{
            //    textBox2.Text = "";
            //}
            textBox2.Focus();
        }
       
        private void txtKotno_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void buttonX50_Click(object sender, EventArgs e)
        {
            grpChooseMode.Visible = false;
            textBox2.Text = ""; textBox2.Tag = ""; KOT_BillNO = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MainIndex.dr == 2)
            {
                da.fill_combo("select 0 as ID,'' as Name union all select ID,Name from Inventory_Master Order By name", cmbproduct, "ID", "Name");
            }
            else
            {
                da.fill_combo("select 0 as ID,'' as Name union all select ID,Name from Inventory_Master  where rkotshow='Yes' Order By name", cmbproduct, "ID", "Name");
            }
        }

        private void txtDisPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }
        }

        private void txtDisPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txtDisPer.Text != "")
                {
                    if (Convert.ToDouble(txtDisPer.Text) > 20)
                    {
                        MessageBox.Show("Discount Invalid.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDisPer.Focus();

                        return;
                    }
                }
                btnadd_Click(sender, e);
            }
        }

        private void txtDAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txtDisPer.Text != "")
                {
                    if (Convert.ToDouble(txtDisPer.Text) > 20)
                    {
                        MessageBox.Show("Discount Invalid.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDisPer.Focus();

                        return;
                    }
                }
                btnadd_Click(sender, e);
            }
        }

        private void txtDAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }
        }
        int rAmt = 0;
        private void txtDisPer_TextChanged(object sender, EventArgs e)
        {
            if (rAmt == 1) { return; }
            double val1 = string.IsNullOrEmpty(txtqty.Text) ? 0 : Convert.ToDouble(txtqty.Text);
            double val2 = string.IsNullOrEmpty(txtrate.Text) ? 0 : Convert.ToDouble(txtrate.Text);
            //if (Convert.ToInt32( txtqty.Text) != 0 || Convert.ToInt32( txtrate.Text) !=0)
            //{
        
            double amt =Convert.ToDouble( Math.Round((val1 * val2), 2));
            double disper = string.IsNullOrEmpty(txtDisPer.Text) ? 0 : Convert.ToDouble(txtDisPer.Text);
            if (disper != 0)
            {
                rAmt = 1;
                double disamt = Math.Round((amt * (disper / 100)), 0);
                txtDAmt.Text = disamt.ToString("#");
                rAmt = 0;
                double finalamt = amt - disamt;
                if (finalamt < 0)
                {
                    txtamt.Text = "0.00";
                }
                else
                {
                    txtamt.Text = finalamt.ToString("#,0.00");
                }
            }
            else
            {
                txtamt.Text = amt.ToString();
                txtDAmt.Text = "";
            }
        }

        private void txtDAmt_TextChanged(object sender, EventArgs e)
        {
            if (rAmt == 1) { return; }
            double val1 = string.IsNullOrEmpty(txtqty.Text) ? 0 : Convert.ToDouble(txtqty.Text);
            double val2 = string.IsNullOrEmpty(txtrate.Text) ? 0 : Convert.ToDouble(txtrate.Text);

            double amt = Convert.ToDouble(Math.Round((val1 * val2), 2));
            double disper = string.IsNullOrEmpty(txtDAmt.Text) ? 0 : Convert.ToDouble(txtDAmt.Text);
            if (disper != 0)
            {
                rAmt = 1;
                double disamt = Math.Round(((disper / amt) * (100)), 0);
                txtDisPer.Text = disamt.ToString();
                rAmt = 0;
                double finalamt = amt - disper;
                if (finalamt < 0)
                {
                    txtamt.Text = "0.00";
                }
                else
                {
                    txtamt.Text = finalamt.ToString("#,0.00");
                }

            }
            else
            {
                txtamt.Text = amt.ToString();
                txtDisPer.Text = "";
            }
        }

        private void txtDisPer_Validating(object sender, CancelEventArgs e)
        {
            if(txtDisPer.Text!="")
            {
                if(Convert.ToDouble(txtDisPer.Text)>20)
                {
                    MessageBox.Show("Discount Invalid.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDisPer.Focus();
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void txtDAmt_Validating(object sender, CancelEventArgs e)
        {
            if (txtDisPer.Text != "")
            {
                if (Convert.ToDouble(txtDisPer.Text) > 20)
                {
                    MessageBox.Show("Discount Invalid.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDisPer.Focus();
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void txtDisPer_Leave(object sender, EventArgs e)
        {
          
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            grpBillDetail.Visible = false;
            txtKOTNo1.Text = "";
            txtKOTNo1.Tag = "";
            cmbMobile2.Text = "";
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            frmledger fl = new frmledger(this.cmbParty2, this.cmbMobile2);
            fl.ShowDialog();
            btnPrintBill.Focus();
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
           
                if (txtKOTNo1.Text.Trim() == "")
                {
                    MessageBox.Show("Please specify Kot No. to be create bill.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtKOTNo1.Focus();
                    return;
                }

                if (cmbPayMode1.Text == " Unsetteled")
                    {
                        MessageBox.Show("Please select valid payment mode.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbPayMode1.Focus();
                        return;
                    }
              
                DataSet rsTemp = new DataSet();
                if (MainIndex.dr == 1)
                {
                rsTemp = da.dataset_ret("select top 1 id from sale where companyid=" + Form1.CompanyID + " and kotno=" + txtKOTNo1.Text.TrimStart('0') + " order by id desc");
                }
                else
                {
                    rsTemp = da.dataset_ret("select top 1 id from sale where PayMode='" + cmbPayMode1.Text + "' and   companyid=" + Form1.CompanyID + " and finyear='" + Form1.CurrFinYear + "' and billno=" + txtKOTNo1.Text.TrimStart('0') + " order by id desc");
                }
              
                if (rsTemp.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Specified  No. is not valid. Please try again.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtKOTNo1.Focus();
                    return;
                }
                btnPrintBill.Enabled = false;
                if (MainIndex.dr == 1)
                {
                    da.insert_update_delete("Update sale set partyid=" + Convert.ToInt32(cmbParty2.SelectedValue) + ",partyname='" + Form1.SingleCode(cmbParty2.Text) + "',mobile='" + cmbMobile2.Text + "', paymode='" + cmbPayMode1.Text + "' where Id=" + rsTemp.Tables[0].Rows[0]["id"].ToString());
                }
                else
                {
                    da.insert_update_delete("Update sale set userid=" + Form1.UserID + ",  username='" + Form1.username + "', PartyAddress='" + Form1.SingleCode(Form1.PartyAddress) + "',PartyGstin='" + Form1.SingleCode(Form1.PartyGST) + "',PartyState='" + Form1.SingleCode(Form1.PartyState) + "', partyid=" + Convert.ToInt32(cmbParty2.SelectedValue) + ",partyname='" + Form1.SingleCode(cmbParty2.Text) + "',mobile='" + cmbMobile2.Text + "'  where Id=" + rsTemp.Tables[0].Rows[0]["id"].ToString());
                    KOT_BillNOStatic = KOT_BillNO;
                    KOT_BillNO = 0;
                    MainIndex.dr = 2;
                    printdata(dgvSearchGrid.CurrentRow.Cells[2].Value.ToString());
                    
                    txtKOTNo1.Text = "";
                    txtKOTNo1.Tag = "";
                    cmbMobile2.Text = "";

                    FillGrid();
                  
                    btnPrintBill.Enabled = true;
                    txtKOTNo1.Enabled = true;
                    cmbPayMode1.Enabled = true;
                    label38.Text = "Kot No.";
                    grpBillDetail.Visible = false;
                    if (MainIndex.dr == 2)
                    {
                        optKOT.Checked = true;
                        optKOT_Click(sender, e);
                    }
                    return;
                }
                PaymentMode = cmbPayMode1.Text;
                //int MaxID = Convert.ToInt32(da.value1("select max(BillNo) from Sale where finyear='" + Form1.CurrFinYear + "' and PayMode='" + cmbPayMode1.Text + "' and CompanyId=" + companyid + ""));
                int MaxID = Convert.ToInt32(da.value1("select max(BillNo) from Sale where finyear='" + Form1.CurrFinYear + "' and  CompanyId=" + companyid + ""));
                if (MaxID == 0)
                {
                    if (PaymentMode == "Cash")
                    {
                        billno = Convert.ToInt32(da.value1("select  cashbillno as BillNo from company_master where id=" + companyid));
                        MaxID = billno + 1;

                    }
                    else if (PaymentMode == "Card")
                    {
                        billno = Convert.ToInt32(da.value1("select  cardbillno as BillNo from company_master where id=" + companyid));
                        MaxID = billno + 1;

                    }
                    else
                    {
                        MaxID = MaxID + 1;

                    }
                }
                else
                {
                    MaxID = MaxID + 1;

                }
                string billdate1 = dgvSearchGrid.CurrentRow.Cells[4].Value.ToString();

                billdate1 = billdate1.Substring(6, 4) + '-' + billdate1.Substring(3, 2) + '-' + billdate1.Substring(0, 2);
                da.insert_update_delete("Update Sale set userid="+ Form1.UserID+",  username='" + Form1.username + "', PartyAddress='" + Form1.SingleCode(Form1.PartyAddress) + "',PartyGstin='" + Form1.SingleCode(Form1.PartyGST) + "',PartyState='" + Form1.SingleCode(Form1.PartyState) + "', billtime='" + string.Format("{0:hh:mm tt}", DateTime.Now) + "', BillDate1 = '" + billdate1.ToString() + "', KotNo=" + Convert.ToInt32(0) + ",KotDate='" + Convert.ToString("") + "',BillNo=" + MaxID + ",BillDate='" + dgvSearchGrid.CurrentRow.Cells[4].Value.ToString() + "' where id=" + KOT_BillNO + " and CompanyId=" + companyid + "");

                // da.insert_update_delete(" update sale set BillDate1 = substring(BillDate,7,4) + '-' + substring(BillDate,4,2)+'-'+substring(BillDate,1,2) where id=" + KOT_BillNO);
                KOT_BillNOStatic = KOT_BillNO;
                KOT_BillNO = 0;
                MainIndex.dr = 2;
                printdata(cmbPayMode1.Text);
                MainIndex.dr = 1;
                txtKOTNo1.Text = "";
                txtKOTNo1.Tag = "";
                cmbMobile2.Text = "";
                
                FillGrid();
                txtKotno.Text = "";
                btnPrintBill.Enabled = true;
                grpBillDetail.Visible = false;

                //PrintReport obj_report = new PrintReport();

                //obj_report.ShowDialog();

            
        }

        private void cmbPayMode1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void cmbPayMode1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbParty2.Focus();
            }
        }

        private void cmbPayMode1_Leave(object sender, EventArgs e)
        {
            if (cmbPayMode1.Text == "")
            {
                return;
            }
            int checkdup = AllCommonFunctions.Check_Duplicacy("PayMode", cmbPayMode1.Text);
            if (checkdup == 0)
            {
                MessageBox.Show("Select Proper Mode");
                cmbPayMode1.Focus();
            }
        }

        private void cmbParty2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbMobile2.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cmbParty2.Text = "CASH";
                cmbParty2.SelectAll();
            }
        }

        private void cmbParty2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbParty2.Text != "")
                {
                    int checkdup = AllCommonFunctions.Check_Duplicacy("Ledger_Masters", cmbParty2.Text);
                    if (checkdup == 0)
                    {
                        MessageBox.Show("Please select valid name.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cmbParty2.Focus();
                    }
                    else
                    {

                        cmbMobile2.Focus();
                    }
                }
            }
            catch { }
        }

        private void cmbParty2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(rcheck) != 1)
                {
                    if (rcheckField == 0)
                    {
                        rcheckField = 1;
                        cmbMobile2.Text = da.value1("select Mobile from Ledger_Master where type='Customer' and Name='" + cmbParty2.Text + "'");
                        rcheckField = 0;
                    }
                }

            }
            catch { }
        }

        private void cmbParty2_Validating(object sender, CancelEventArgs e)
        {
            DataSet ds = new DataSet();
            if (Convert.ToInt32(cmbParty2.SelectedValue) != 0)
            {
                ds = da.dataset_ret("select GSTNumber,address1,address2,state from ledger_master  where id =" + Convert.ToInt32(cmbParty2.SelectedValue));
                Form1.PartyAddress = ds.Tables[0].Rows[0]["address1"].ToString() + " " + ds.Tables[0].Rows[0]["address2"].ToString();
                Form1.PartyGST = ds.Tables[0].Rows[0]["GSTNumber"].ToString();
                Form1.PartyState = ds.Tables[0].Rows[0]["state"].ToString();
            }
            else
            {
                Form1.PartyAddress = "";
                Form1.PartyGST = "";
                Form1.PartyState = "";
            }
        }

        private void cmbMobile2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btnPrintBill.Focus();
            }
        }

        private void cmbMobile2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(rcheck) != 1)
                {
                    if (rcheckField == 0)
                    {
                        rcheckField = 1;
                        cmbParty2.Text = da.value1("select Name from Ledger_Master where  type='Customer' and Mobile='" + cmbMobile2.Text + "'");
                        rcheckField = 0;
                    }
                }

            }
            catch { }
        }

        private void cmbMobile2_Validating(object sender, CancelEventArgs e)
        {
            DataSet ds = new DataSet();
            if (cmbMobile2.Text != "")
            {
                ds = da.dataset_ret("select GSTNumber,address1,address2,state from ledger_master  where mobile ='" + cmbMobile2.Text + "' ");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Form1.PartyAddress = ds.Tables[0].Rows[0]["address1"].ToString() + " " + ds.Tables[0].Rows[0]["address2"].ToString();
                    Form1.PartyGST = ds.Tables[0].Rows[0]["GSTNumber"].ToString();
                    Form1.PartyState = ds.Tables[0].Rows[0]["state"].ToString();
                }
                else
                {
                    Form1.PartyAddress = "";
                    Form1.PartyGST = "";
                    Form1.PartyState = "";
                }
            }
            else
            {
                Form1.PartyAddress = "";
                Form1.PartyGST = "";
                Form1.PartyState = "";
            }
        }

        private void btnSetParty_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSearchGrid.Rows.Count != 0)
                {
                    if (KOT_BillNO == 0)
                    {
                        MessageBox.Show("Please select bill no. for set party.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                  
                    if (KOT_BillNO.ToString() != "")
                    {
                        if (KOT_BillNO != 0)
                        {
                            txtKOTNo1.Text = dgvSearchGrid.CurrentRow.Cells[3].Value.ToString();
                            txtKOTNo1.Tag = dgvSearchGrid.CurrentRow.Cells[2].Value.ToString();
                        }

                    }

                    cmbPayMode1.Text = txtKOTNo1.Tag.ToString();
                    cmbParty2.Text = "CASH";
                    cmbParty2.Focus();
                    txtKOTNo1.Enabled = false;
                    cmbPayMode1.Enabled = false;
                    label38.Text = "Bill No.";
                    grpBillDetail.Visible = true;
                    //if (dgvSearchGrid.CurrentRow.Cells[2].Value.ToString()==" Unsetteled")
                    //{
                    //    MessageBox.Show("Selected Kot payment mode is not setteled."+Environment.NewLine+"Please set payment mode and try again for transfer into bill.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                    //if (MessageBox.Show("Are you sure to Transfer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    //{

                    //}
                }
                else
                {
                    MessageBox.Show("There are no bill no. for set party.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }

        private void A_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender,e);
        }

        private void B_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void A_MouseLeave(object sender, EventArgs e)
        {
            SmallButtonMouse_Leave(sender, e,"DeepSkyBlue" );
        }

        private void C_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void D_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void E_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void F_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void G_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void bHutton4_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void I_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void J_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void K_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void L_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void M_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void N_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void O_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void P_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void Q_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void R_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void S_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void T_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void U_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void V_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void W_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void X_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void Y_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void Z_MouseHover(object sender, EventArgs e)
        {
            SmallButtonMouse_Hover(sender, e);
        }

        private void G_MouseLeave(object sender, EventArgs e)
        {
            SmallButtonMouse_Leave(sender, e, "DeepSkyBlue");
        }

        private void N_MouseLeave(object sender, EventArgs e)
        {
            SmallButtonMouse_Leave(sender, e, "DeepSkyBlue");
        }

        private void B_MouseLeave(object sender, EventArgs e)
        {
            SmallButtonMouse_Leave(sender, e, "DodgerBlue");
        }

        private void bHutton4_MouseLeave(object sender, EventArgs e)
        {
            SmallButtonMouse_Leave(sender, e, "DeepSkyBlue");
        }

        private void O_MouseLeave(object sender, EventArgs e)
        {
            SmallButtonMouse_Leave(sender, e, "DeepSkyBlue");
        }

        private void cmbseries_Enter(object sender, EventArgs e)
        {
            cmbseries.DroppedDown = true;
        }

        private void cmbparty_Enter(object sender, EventArgs e)
        {
            cmbparty.DroppedDown = true;
        }

        private void cmbChooseMode_Enter(object sender, EventArgs e)
        {
            cmbChooseMode.DroppedDown = true;
        }

        private void cmbPayMode1_Enter(object sender, EventArgs e)
        {
            cmbPayMode1.DroppedDown = true;
        }

        private void cmbParty2_Enter(object sender, EventArgs e)
        {
            cmbParty2.DroppedDown = true;
        }
    }
    }

