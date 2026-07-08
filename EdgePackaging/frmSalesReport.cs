using EdgePackingShared;
using EdgeVastra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EdgePack;

namespace EdgePackaging
{
     
    public partial class frmSalesReport : Form
    {
        database_admin da = new database_admin();
        int rcheck = 1;
        public frmSalesReport()
        {
            InitializeComponent();
            da.fill_combo("select id,(name+' - '+com_location)as name  from Company_Master order by id", cmbcompany, "ID", "Name");
            if(Convert.ToInt32(Form1.UserID)!=1)
            {
                cmbcompany.SelectedValue = Form1.CompanyID;
                cmbcompany.Enabled = false;
            }
            da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Sub_Group_Master order by rtag,name", cmbSubgroup, "ID", "Name");
            da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Master order by rtag,name", cmbProduct, "ID", "Name");
            da.fill_combo("select 0 as id,'All' as name union all select ID,Name from tblPaymentMode", cmbPayMode, "ID", "Name");
            rcheck = 0;
            dtFromDate.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void cmbcompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                cmbSubgroup.Focus();
            }
        }
        public static DataSet dsReport=new DataSet();
        private void btnPreview_Click(object sender, EventArgs e)
        {
            string rstring = "";
            rstring = " and ((billdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and billdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "')  or (kotdate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and kotdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "'))";
                rstring =rstring+ " and companyid=" + Convert.ToInt32( cmbcompany.SelectedValue);
          if(Convert.ToInt32(cmbPayMode.SelectedValue)!=0)
          {
              rstring = rstring + " and (paymode='" + cmbPayMode.Text+ "') ";
          }
          string rstring1 = "";
          if (cmbSubgroup.SelectedIndex != -1 && Convert.ToInt32(cmbSubgroup.SelectedValue) != 0)
          {
              rstring1 = "where Inventory_S_Group= " + cmbSubgroup.SelectedValue;
          }
          if (cmbProduct.SelectedIndex != -1 && Convert.ToInt32(cmbProduct.SelectedValue) != 0)
          {
              if(rstring1=="")
              {
                  rstring1 = " where id=" + cmbProduct.SelectedValue;
              }
              else
              {
                  rstring1 =rstring1+ " and id=" + cmbProduct.SelectedValue;
              }
          }
           // DataSet ds = new DataSet();
            string companyname = cmbcompany.Text;
            string rtext = "Sales Report of "+companyname+ " From Date: " + dtFromDate.Value.Date.ToString("dd/MM/yyyy") + " To Date: " + dtToDate.Value.Date.ToString("dd/MM/yyyy");

            dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring, a.code,a.name,b.qty,b.amount,a.subgroup,b.dt from ((select id,code,name,(select name from Inventory_Sub_Group_Master where Inventory_S_Group=Inventory_Sub_Group_Master.id) as subgroup from Inventory_Master " + rstring1 + ")as a left join " +
                                                        "(select sum(qty)as qty,sum(amount)as amount,productid,case when billno>0 then billdate1 else kotdate1 end as dt from saledetail ,sale where sale.id=saledetail.saleid "+rstring +" group by productid,case when billno>0 then billdate1 else kotdate1 end)as b " +
                                                        "on a.id=b.productid) where not b.qty is null order by b.dt,a.subgroup");
            if (dsReport.Tables[0].Rows.Count > 0)
            {
                frmCrystalReport.ReportName = "SalesReport";
                frmCrystalReport obj_report = new frmCrystalReport();
                obj_report.ShowDialog();

            } 
            else
            {
                MessageBox.Show("There are no sales report available.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dsReport.Dispose();
                dsReport.Tables.Clear();
                return;
            }
        }

        private void dtFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dtToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cmbSubgroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbProduct.Focus();
            }
        }

        private void cmbProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPayMode.Focus();
            }
        }

        private void cmbPayMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPreview.Focus();
            }
        }

        private void cmbSubgroup_TextChanged(object sender, EventArgs e)
        {
            if (rcheck == 1)
            {
                return;
            }
            if (cmbSubgroup.SelectedIndex != -1 && Convert.ToInt32(cmbSubgroup.SelectedValue) != 0)
            {
                DataSet ds = new DataSet();
                da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Master where Inventory_S_Group=" + Convert.ToInt32(cmbSubgroup.SelectedValue) + " order by rtag,name", cmbProduct, "ID", "Name");
            }
            else
            {
                da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Master order by rtag,name", cmbProduct, "ID", "Name");
            }
        }

        private void cmbSubgroup_Validating(object sender, CancelEventArgs e)
        {
            if(cmbSubgroup.Text.Trim()!="")
            {
                if(cmbSubgroup.SelectedIndex==-1)
                {
                    MessageBox.Show("Please select valid sub group.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSubgroup.Focus();
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void cmbProduct_Validating(object sender, CancelEventArgs e)
        {
            if (cmbProduct.Text.Trim() != "")
            {
                if (cmbProduct.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select valid product.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbProduct.Focus();
                    e.Cancel = true;
                    return;
                }
            }
           
        }

        private void frmSalesReport_Load(object sender, EventArgs e)
        {
           

        }

        private void cmbSubgroup_SelectedValueChanged(object sender, EventArgs e)
        {
            if (rcheck == 1)
            {
                return;
            }
            if (cmbSubgroup.SelectedIndex != -1 && Convert.ToInt32(cmbSubgroup.SelectedValue) != 0)
            {
                DataSet ds = new DataSet();
                da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Master where Inventory_S_Group=" + Convert.ToInt32(cmbSubgroup.SelectedValue) + " order by rtag,name", cmbProduct, "ID", "Name");
            }
            else
            {
                da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Master order by rtag,name", cmbProduct, "ID", "Name");
            }
        }

       
    }
}
