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
     
    public partial class frmStockReportEx : Form
    {
        database_admin da = new database_admin();
        public frmStockReportEx()
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
                btnPreview.Focus();
            }
        }
        public static DataSet dsReport=new DataSet();
        private void btnPreview_Click(object sender, EventArgs e)
        {
            string company = "";
           
                company = " and companyid=" + Convert.ToInt32( cmbcompany.SelectedValue);
                string rstring1 = "";
                string rstring2 = "";
                string companyname = cmbcompany.Text;
                string rtext = "";
                rtext = "Stock Report - By Expiry Date of " + companyname + " From Date: " + dtDate.Value.Date.ToString("dd/MM/yyyy")+ " To Date: " + dtToDate.Value.Date.ToString("dd/MM/yyyy");
                if (cmbSubgroup.SelectedIndex != -1 && Convert.ToInt32(cmbSubgroup.SelectedValue) != 0)
                {
                    rstring1 = "where Inventory_S_Group= " + cmbSubgroup.SelectedValue;
                    rstring2 = " and Inventory_S_Group= " + cmbSubgroup.SelectedValue;
                    rtext = "Stock Report of " + companyname + " From Date: " + dtDate.Value.Date.ToString("dd/MM/yyyy") + " To Date: " + dtToDate.Value.Date.ToString("dd/MM/yyyy") + "  Sub Group: " + cmbSubgroup.Text;
                }
                if (cmbProduct.SelectedIndex != -1 && Convert.ToInt32(cmbProduct.SelectedValue) != 0)
                {
                        rstring1 = " where inventory_master.id= " + cmbProduct.SelectedValue;
                        rstring2 = " and inventory_master.id= " + cmbProduct.SelectedValue;
                        rtext = "Stock Report of " + companyname + " From Date: " + dtDate.Value.Date.ToString("dd/MM/yyyy") + " To Date: " + dtToDate.Value.Date.ToString("dd/MM/yyyy") + "  Product: " + cmbProduct.Text;
                }
                if (checkBox1.Checked == false)
                {
                    if(optL1.Checked==true)
                    {
                        dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,a.subgroupname,case when isnull(inward.inward,0)>0 then round((isnull(inward.inward,0)/a.conv1),2) else 0 end  as inward,0 as production, " +
                        "   case when isnull(outward.outward,0)>0 then  round( (isnull(outward.outward,0)/a.conv1),2) else 0 end as outward,0 as sale,isnull(consumed.consumed,0) as consumed,case when isnull(damages.damages,0)>0 then round((isnull(damages.damages,0)/a.conv1),2) else 0 end as damages,isnull(wastage.wastage,0) as wastage " +
                        "  ,a.unit from ( " +
                        "  (select inventory_master.id,code,name,exdate1 as subgroupname,lot1 as unit,conv1 from Inventory_Master inner join stockinwarddetail on stockinwarddetail.product=inventory_master.id inner join stockinwardmaster on stockinwardmaster.id=masterid where exdate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and exdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and  stockinwardmaster.stocktype='Purchase' " + rstring2 + ") as a left join  " +
                        "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
                        "   left join (select aa.product,sum(aa.inward) as inward,aa.exdate1 from (select product,sum(qty) as inward,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where exdate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and exdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and  (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') group by product,exdate1 union all select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as inward,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where  exdate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and exdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return','Department') group by product,exdate1) as aa group by aa.product,aa.exdate1) as inward on a.id=inward.product and a.subgroupname=inward.exdate1 " +
                        "   left join (select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as outward,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where  exdate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and exdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product,exdate1) as outward on a.id=outward.product  and a.subgroupname=outward.exdate1 " +
                        "  left join (select product,sum(qty) as consumed,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where  exdate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and exdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') group by product,exdate1) as consumed on a.id=consumed.product and a.subgroupname=consumed.exdate1 " +
                        "  left join (select product,sum(qty) as damages,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "  where exdate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and exdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "'  and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') group by product,exdate1) as damages on a.id=damages.product and a.subgroupname=damages.exdate1" +
                        "  left join (select product,sum(qty) as wastage,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "  where exdate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and exdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') group by product,exdate1) as wastage on a.id=wastage.product and a.subgroupname=wastage.exdate1 " +
                        "  ) where  (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0))))<>0 order by a.name");

                    }
                    else
                    {
                        dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,a.subgroupname,isnull(aaa.qty,0) as qty,isnull(inward.inward,0) as inward,0 as production, " +
                        "   isnull(outward.outward,0) as outward,0 as sale,isnull(consumed.consumed,0) as consumed,isnull(damages.damages,0) as damages,isnull(wastage.wastage,0) as wastage " +
                        "  ,a.unit from ( " +
                        "  (select inventory_master.id,code,name,exdate1 as subgroupname,inventory_master.unit from Inventory_Master inner join stockinwarddetail on stockinwarddetail.product=inventory_master.id inner join stockinwardmaster on stockinwardmaster.id=masterid where exdate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and exdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and  stockinwardmaster.stocktype='Purchase' " + rstring2 + ") as a left join  " +
                        "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
                        "   left join (select aa.product,sum(aa.inward) as inward,aa.exdate1 from (select product,sum(qty) as inward,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where exdate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and exdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and  (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') group by product,exdate1 union all select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as inward,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where  exdate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and exdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return','Department') group by product,exdate1) as aa group by aa.product,aa.exdate1) as inward on a.id=inward.product and a.subgroupname=inward.exdate1 " +
                        "   left join (select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as outward,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where  exdate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and exdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product,exdate1) as outward on a.id=outward.product  and a.subgroupname=outward.exdate1 " +
                        "  left join (select product,sum(qty) as consumed,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where  exdate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and exdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') group by product,exdate1) as consumed on a.id=consumed.product and a.subgroupname=consumed.exdate1 " +
                        "  left join (select product,sum(qty) as damages,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "  where exdate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and exdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "'  and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') group by product,exdate1) as damages on a.id=damages.product and a.subgroupname=damages.exdate1" +
                        "  left join (select product,sum(qty) as wastage,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "  where exdate1>='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and exdate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') group by product,exdate1) as wastage on a.id=wastage.product and a.subgroupname=wastage.exdate1 " +
                        "  ) where  (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0))))<>0 order by a.name");

                    }

                }
                else
                {

                    if(optL1.Checked==true)
                    {
                        dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,a.subgroupname,isnull(aaa.qty,0) as qty,case when isnull(inward.inward,0)>0 then round((isnull(inward.inward,0)/a.conv1),2) else 0 end  as inward,0 as production, " +
                        "   case when isnull(outward.outward,0)>0 then  round( (isnull(outward.outward,0)/a.conv1),2) else 0 end as outward,0 as sale,isnull(consumed.consumed,0) as consumed,case when isnull(damages.damages,0)>0 then round((isnull(damages.damages,0)/a.conv1),2) else 0 end as damages,isnull(wastage.wastage,0) as wastage " +
                        "  ,a.unit from ( " +
                        "  (select inventory_master.id,code,name,exdate1 as subgroupname,lot1 as unit,conv1 from Inventory_Master inner join stockinwarddetail on stockinwarddetail.product=inventory_master.id inner join stockinwardmaster on stockinwardmaster.id=masterid where  stockinwardmaster.stocktype='Purchase' " + rstring2 + ") as a left join  " +
                        "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
                        "   left join (select aa.product,sum(aa.inward) as inward,aa.exdate1 from (select product,sum(qty) as inward,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where  (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') group by product,exdate1 union all select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as inward,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where  (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return','Department') group by product,exdate1) as aa group by aa.product,aa.exdate1) as inward on a.id=inward.product and a.subgroupname=inward.exdate1 " +
                        "   left join (select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as outward,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where  companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product,exdate1) as outward on a.id=outward.product  and a.subgroupname=outward.exdate1 " +
                        "  left join (select product,sum(qty) as consumed,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where  companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') group by product,exdate1) as consumed on a.id=consumed.product and a.subgroupname=consumed.exdate1 " +
                        "  left join (select product,sum(qty) as damages,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "  where  companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') group by product,exdate1) as damages on a.id=damages.product and a.subgroupname=damages.exdate1" +
                        "  left join (select product,sum(qty) as wastage,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "  where  companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') group by product,exdate1) as wastage on a.id=wastage.product and a.subgroupname=wastage.exdate1 " +
                        "  ) where (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0))))<>0 order by a.name");

                    }
                    else
                    {
                        dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,a.subgroupname,isnull(aaa.qty,0) as qty,isnull(inward.inward,0) as inward,0 as production, " +
                        "   isnull(outward.outward,0) as outward,0 as sale,isnull(consumed.consumed,0) as consumed,isnull(damages.damages,0) as damages,isnull(wastage.wastage,0) as wastage " +
                        "  ,a.unit from ( " +
                        "  (select inventory_master.id,code,name,exdate1 as subgroupname,inventory_master.unit from Inventory_Master inner join stockinwarddetail on stockinwarddetail.product=inventory_master.id inner join stockinwardmaster on stockinwardmaster.id=masterid where  stockinwardmaster.stocktype='Purchase' " + rstring2 + ") as a left join  " +
                        "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
                        "   left join (select aa.product,sum(aa.inward) as inward,aa.exdate1 from (select product,sum(qty) as inward,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where  (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') group by product,exdate1 union all select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as inward,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where  (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return','Department') group by product,exdate1) as aa group by aa.product,aa.exdate1) as inward on a.id=inward.product and a.subgroupname=inward.exdate1 " +
                        "   left join (select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as outward,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where  companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product,exdate1) as outward on a.id=outward.product  and a.subgroupname=outward.exdate1 " +
                        "  left join (select product,sum(qty) as consumed,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "   where  companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') group by product,exdate1) as consumed on a.id=consumed.product and a.subgroupname=consumed.exdate1 " +
                        "  left join (select product,sum(qty) as damages,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "  where  companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') group by product,exdate1) as damages on a.id=damages.product and a.subgroupname=damages.exdate1" +
                        "  left join (select product,sum(qty) as wastage,exdate1 from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                        "  where  companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') group by product,exdate1) as wastage on a.id=wastage.product and a.subgroupname=wastage.exdate1 " +
                        "  ) where (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0))))<>0 order by a.name");

                    }

                }
             if(Form1.StockTag==1)
             {
                 frmCrystalReport.ReportName = "StockReportEx1";
             }
             else
             {
                 frmCrystalReport.ReportName = "StockReportEx";
             }
               
            
           
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
                cmbProduct.Focus();
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

        private void cmbProduct_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ComboBox cb = (ComboBox)sender;
                cb.DroppedDown = false;
                cb.SelectionStart = cb.Text.Length;
                cb.SelectionLength = 0;
            }
        }

       
    }
}
