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
     
    public partial class frmDemandReport : Form
    {
        database_admin da = new database_admin();
        public frmDemandReport()
        {
            InitializeComponent();
            da.fill_combo("select id,(name)as name from ledger_Master where type in ('Godown','Shop') order by id", cmbcompany, "ID", "Name");
            if(Convert.ToInt32(Form1.UserID)!=1)
            {
                cmbcompany.SelectedValue = Form1.CompanyID;
                cmbcompany.Enabled = false;
            }
           
            da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Sub_Group_Master order by rtag,name", cmbSubgroup, "ID", "Name");
            da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Master order by rtag,name", cmbProduct, "ID", "Name");

            dtDate.Focus();
        }
       
      
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cmbcompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                txtD.Focus();
            }
        }
        public static DataSet dsReport=new DataSet();
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if(txtD.Text=="")
            {
                MessageBox.Show("Please specify demand days.", "Edge Softwares", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtD.Focus();
                return;
            }
            if (txtD.Text == "0")
            {
                MessageBox.Show("Please specify demand days.", "Edge Softwares", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtD.Focus();
                return;
            }
            if (Convert.ToInt32(cmbSubgroup.SelectedValue)==0)
            {
                MessageBox.Show("Please specify product sub group.", "Edge Softwares", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSubgroup.Focus();
                return;
            }
            string company = "";
            DateTime d1 = dtDate.Value.Date;
            DateTime d2 = dtToDate.Value.Date;
            TimeSpan t1 = d2 - d1;
            int rdays = t1.Days;
                company = " and companyid=" + Convert.ToInt32( cmbcompany.SelectedValue);
                string rstring1 = "";
                string rstring2 = "";
                string companyname = cmbcompany.Text;
                string rtext = "";
                if (cmbSubgroup.SelectedIndex != -1 && Convert.ToInt32(cmbSubgroup.SelectedValue) != 0)
                {
                    rstring1 = "where Inventory_S_Group= " + cmbSubgroup.SelectedValue;
                    rstring2 = " and Inventory_S_Group= " + cmbSubgroup.SelectedValue;
                }
                if (cmbProduct.SelectedIndex != -1 && Convert.ToInt32(cmbProduct.SelectedValue) != 0)
                {
                        rstring1 = " where inventory_master.id= " + cmbProduct.SelectedValue;
                        rstring2 = " and inventory_master.id= " + cmbProduct.SelectedValue;
                }
                rtext = "Demand Report of " + companyname + " (Product Sub Group : " + cmbSubgroup.Text + ") From Date: " + dtDate.Value.Date.ToString("dd/MM/yyyy") + " To Date: " + dtToDate.Value.Date.ToString("dd/MM/yyyy");

               



                dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,a.subgroupname,isnull(aaa.qty,0) as qty,isnull(inward.inward,0) as inward,isnull(production.production,0) as production, " +
                              "   isnull(outward.outward,0) as outward,isnull(sale.sale,0) as sale,isnull(consumed.consumed,0) as consumed,isnull(damages.damages,0) as damages,isnull(wastage.wastage,0) as wastage " +
                              "  ,a.unit,  isnull((select top 1 round((StockInwardDetail.amount/stockinwarddetail.qty),2) as rate from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid where party=" + Convert.ToInt32(cmbcompany.SelectedValue) + " and product= a.id order by stockinwarddetail.id desc ),0) as rate," +txtD.Text+" as demanddays,"+rdays.ToString()+" as rdays from ( " +
                              "  (select id,code,name,(select name from inventory_sub_group_master where inventory_sub_group_master.id=inventory_s_group) as subgroupname,unit from Inventory_Master " + rstring1 + ") as a left join  " +
                              "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
                             "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and invoicedate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') group by product union all select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and invoicedate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return') group by product) as aa group by aa.product) as inward on a.id=inward.product  " +
                             "   left join (select product,sum(qty) as production from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "  where invoicedate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and invoicedate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Production') group by product) as production on a.id=production.product  " +
                             "   left join (select product,sum(qty) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                             "   where invoicedate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and invoicedate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return') group by product) as outward on a.id=outward.product  " +
                             "   left join (select zz.product,sum(zz.sale) as sale from (select productid as product,(sum(qty)) as sale from sale inner join SaleDetail on sale.id=saleid where " +
                              "  kotdate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and BillNo=0 group by ProductId " +
                              "  union all select productid as product,(sum(qty)) as sale from sale inner join SaleDetail on sale.id=saleid where " +
                              "  billdate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and kotNo=0 group by ProductId " +
                              "  ) as zz group by zz.product ) as sale on a.id=sale.product " +
                              "  left join (select product,sum(qty) as consumed from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                             "   where invoicedate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and invoicedate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') group by product) as consumed on a.id=consumed.product  " +
                              "  left join (select product,sum(qty) as damages from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "  where invoicedate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and invoicedate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') group by product) as damages on a.id=damages.product  " +
                                 "  left join (select product,sum(qty) as wastage from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "  where invoicedate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and invoicedate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') group by product) as wastage on a.id=wastage.product  " +
                              "  )  where (((isnull(aaa.qty,0)+isnull(inward.inward,0)+isnull(production.production,0))-(isnull(outward.outward,0)+isnull(sale.sale,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0))))<>0 order by a.name");


             
                frmCrystalReport.ReportName = "DemandReport";
            
           
            if (dsReport.Tables[0].Rows.Count > 0)
            {
                
                frmCrystalReport obj_report = new frmCrystalReport();
                obj_report.ShowDialog();

            } 
            else
            {
                MessageBox.Show("There are no stock report available.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dsReport.Dispose();
                dsReport.Tables.Clear();
                return;
            }
        }

        private void cmbSubgroup_Validating(object sender, CancelEventArgs e)
        {
            if (cmbSubgroup.Text.Trim() != "")
            {
                if (cmbSubgroup.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select valid sub group.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSubgroup.Focus();
                    e.Cancel = true;
                    return;
                }
            }
            if (Convert.ToInt32(cmbSubgroup.SelectedValue)==0)
            {
                da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Master order by rtag,name", cmbProduct, "ID", "Name");

            }
            else
            {
                da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Master where inventory_s_group=" + Convert.ToInt32(cmbSubgroup.SelectedValue)  + " order by rtag,name", cmbProduct, "ID", "Name");

            }
        }

        private void cmbSubgroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPreview.Focus();
            }
        }

        private void cmbProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPreview.Focus();
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

        private void txtD_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back ))
                { e.Handled = true; }
                
            }
            catch (Exception ex)
            {
            }
        }

        private void txtD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbSubgroup.Focus();
            }
        }

       
    }
}
