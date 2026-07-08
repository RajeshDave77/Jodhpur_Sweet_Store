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
     
    public partial class frmStockReport : Form
    {
        database_admin da = new database_admin();
        public frmStockReport()
        {
            InitializeComponent();
            da.fill_combo("select id,(name)as name from ledger_Master where type in ('Godown') order by id", cmbcompany, "ID", "Name");
            if(Convert.ToInt32(Form1.UserID)!=1)
            {
                cmbcompany.SelectedValue = Form1.CompanyID;
                cmbcompany.Enabled = false;
            }
            da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Shop') and companyid=" +cmbcompany.SelectedValue+" order by  rtag,name", cmbSubLocation, "ID", "Name");
            da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Sub_Group_Master order by rtag,name", cmbSubgroup, "ID", "Name");
            da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Master order by rtag,name", cmbProduct, "ID", "Name");
            if(Form1.StockTag==0)
            {
                optB1.Visible = false;
            }
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
                btnPreview.Focus();
            }
        }

        private void cmbcompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                cmbSubLocation.Focus();
            }
        }
        public static DataSet dsReport=new DataSet();
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if(optSublocation.Checked==true)
            {
                if(Convert.ToInt32(cmbSubLocation.SelectedValue)==0)
                {
                    MessageBox.Show("Please select sub location.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSubLocation.Focus();
                    return;
                }
              
            }
            string company = "";
           
                company = " and companyid=" + Convert.ToInt32( cmbcompany.SelectedValue);
                string rstring1 = "";
                string companyname = cmbcompany.Text;
                string rtext = "";
                rtext = "Stock Report of " + companyname + " as on Date: " + dtDate.Value.Date.ToString("dd/MM/yyyy");
                if (cmbSubgroup.SelectedIndex != -1 && Convert.ToInt32(cmbSubgroup.SelectedValue) != 0)
                {
                    rstring1 = "where Inventory_S_Group= " + cmbSubgroup.SelectedValue;
                     rtext = "Stock Report of " + companyname + " as on Date: " + dtDate.Value.Date.ToString("dd/MM/yyyy")+ "  Sub Group: "+cmbSubgroup.Text;
                }
                if (cmbProduct.SelectedIndex != -1 && Convert.ToInt32(cmbProduct.SelectedValue) != 0)
                {
                    if(rstring1=="")
                    {
                        rstring1 = " where Inventory_Master.id= " + cmbProduct.SelectedValue;
                    }
                    else
                    {
                        rstring1 = rstring1 + " and Inventory_Master.id= " + cmbProduct.SelectedValue;
                    }
                   
                    rtext = "Stock Report of " + companyname + " as on Date: " + dtDate.Value.Date.ToString("dd/MM/yyyy") + "  Product: " + cmbProduct.Text;
                }
            if(Convert.ToInt16(cmbPri.SelectedIndex)!=0)
            {
                if (rstring1 == "")
                {
                    rstring1 = " where rkotshow='"+cmbPri.Text+"' ";
                }
                else
                {
                    rstring1 =rstring1+ " and rkotshow='" + cmbPri.Text + "' ";
                }
            }
            if (optSublocation.Checked==true)
            {
                if(optL1.Checked==true)
                {
                    dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,isnull(aaa.qty,0) as qty,case when isnull(inward.inward,0)>0 then round((isnull(inward.inward,0)/a.conv1),2) else 0 end  as inward,0 as production, " +
               "   case when isnull(outward.outward,0)>0 then  round( (isnull(outward.outward,0)/a.conv1),2) else 0 end as outward,0 as sale,isnull(consumed.consumed,0) as consumed,case when isnull(damages.damages,0)>0 then round((isnull(damages.damages,0)/a.conv1),2) else 0 end as damages,isnull(wastage.wastage,0) as wastage " +
               "  ,a.unit,a.sublocation from ( " +
               "  (select distinct Inventory_Master.id,Inventory_Master.code,Inventory_Master.name,lot1 as unit,conv1,'" + Form1.SingleCode(cmbSubLocation.Text) + "' as sublocation," + cmbSubLocation.SelectedValue + " as sublocationid from Inventory_Master  " + rstring1 + ") as a left join  " +
               "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
              "   left join (select aa.product,sum(aa.inward) as inward,aa.sublocationid from (select product,sum(qty) as inward,sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') and sublocationid=" + cmbSubLocation.SelectedValue + " group by product,sublocationid union all select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as inward,sublocationid2 as sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return','Department') and sublocationid2=" + cmbSubLocation.SelectedValue + " group by product,sublocationid2) as aa group by aa.product,aa.sublocationid) as inward on a.id=inward.product and a.sublocationid=inward.sublocationid " +
              "   left join (select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as outward,sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') and sublocationid=" + cmbSubLocation.SelectedValue + " group by product,sublocationid) as outward on a.id=outward.product and a.sublocationid=outward.sublocationid " +
               "  left join (select product,sum(qty) as consumed,sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') and sublocationid=" + cmbSubLocation.SelectedValue + " group by product,sublocationid) as consumed on a.id=consumed.product and a.sublocationid=consumed.sublocationid " +
               "  left join (select product,sum(qty) as damages,sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
               "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') and sublocationid=" + cmbSubLocation.SelectedValue + " group by product,sublocationid) as damages on a.id=damages.product and a.sublocationid=damages.sublocationid" +
                "  left join (select product,sum(qty) as wastage,sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
               "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') and sublocationid=" + cmbSubLocation.SelectedValue + " group by product,sublocationid) as wastage on a.id=wastage.product and a.sublocationid=wastage.sublocationid " +
               "  ) where (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0))))<>0 order by a.name");

                }
                else if (optB1.Checked == true)
                {
                    dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,isnull(aaa.qty,0) as qty,case when isnull(inward.inward,0)>0 then round((isnull(inward.inward,0)/a.conv1),2) else 0 end  as inward,0 as production, " +
               "   case when isnull(outward.outward,0)>0 then  round( (isnull(outward.outward,0)/a.conv1),2) else 0 end as outward,0 as sale,isnull(consumed.consumed,0) as consumed,case when isnull(damages.damages,0)>0 then round((isnull(damages.damages,0)/a.conv1),2) else 0 end as damages,isnull(wastage.wastage,0) as wastage " +
               "  ,a.unit,a.sublocation,a.smallunit,a.conv1 from ( " +
               "  (select distinct Inventory_Master.id,Inventory_Master.code,Inventory_Master.name,lot1 as unit,conv1,'" + Form1.SingleCode(cmbSubLocation.Text) + "' as sublocation," + cmbSubLocation.SelectedValue + " as sublocationid,unit as smallunit from Inventory_Master  " + rstring1 + ") as a left join  " +
               "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
              "   left join (select aa.product,sum(aa.inward) as inward,aa.sublocationid from (select product,sum(qty) as inward,sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') and sublocationid=" + cmbSubLocation.SelectedValue + " group by product,sublocationid union all select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as inward,sublocationid2 as sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return','Department') and sublocationid2=" + cmbSubLocation.SelectedValue + " group by product,sublocationid2) as aa group by aa.product,aa.sublocationid) as inward on a.id=inward.product and a.sublocationid=inward.sublocationid " +
              "   left join (select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as outward,sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') and sublocationid=" + cmbSubLocation.SelectedValue + " group by product,sublocationid) as outward on a.id=outward.product and a.sublocationid=outward.sublocationid " +
               "  left join (select product,sum(qty) as consumed,sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') and sublocationid=" + cmbSubLocation.SelectedValue + " group by product,sublocationid) as consumed on a.id=consumed.product and a.sublocationid=consumed.sublocationid " +
               "  left join (select product,sum(qty) as damages,sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
               "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') and sublocationid=" + cmbSubLocation.SelectedValue + " group by product,sublocationid) as damages on a.id=damages.product and a.sublocationid=damages.sublocationid" +
                "  left join (select product,sum(qty) as wastage,sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
               "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') and sublocationid=" + cmbSubLocation.SelectedValue + " group by product,sublocationid) as wastage on a.id=wastage.product and a.sublocationid=wastage.sublocationid " +
               "  ) where (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0))))<>0 order by a.name");

                }
                else
                {
                    dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,isnull(aaa.qty,0) as qty,isnull(inward.inward,0) as inward,0 as production, " +
               "   isnull(outward.outward,0) as outward,0 as sale,isnull(consumed.consumed,0) as consumed,isnull(damages.damages,0) as damages,isnull(wastage.wastage,0) as wastage " +
               "  ,a.unit,a.sublocation from ( " +
               "  (select distinct Inventory_Master.id,Inventory_Master.code,Inventory_Master.name,Inventory_Master.unit,'" + Form1.SingleCode(cmbSubLocation.Text) + "' as sublocation," + cmbSubLocation.SelectedValue + " as sublocationid from Inventory_Master  " + rstring1 + ") as a left join  " +
               "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
              "   left join (select aa.product,sum(aa.inward) as inward,aa.sublocationid from (select product,sum(qty) as inward,sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') and sublocationid=" + cmbSubLocation.SelectedValue + " group by product,sublocationid union all select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as inward,sublocationid2 as sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return','Department') and sublocationid2=" + cmbSubLocation.SelectedValue + " group by product,sublocationid2) as aa group by aa.product,aa.sublocationid) as inward on a.id=inward.product and a.sublocationid=inward.sublocationid " +
              "   left join (select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as outward,sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') and sublocationid=" + cmbSubLocation.SelectedValue + " group by product,sublocationid) as outward on a.id=outward.product and a.sublocationid=outward.sublocationid " +
               "  left join (select product,sum(qty) as consumed,sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') and sublocationid=" + cmbSubLocation.SelectedValue + " group by product,sublocationid) as consumed on a.id=consumed.product and a.sublocationid=consumed.sublocationid " +
               "  left join (select product,sum(qty) as damages,sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
               "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') and sublocationid=" + cmbSubLocation.SelectedValue + " group by product,sublocationid) as damages on a.id=damages.product and a.sublocationid=damages.sublocationid" +
                "  left join (select product,sum(qty) as wastage,sublocationid from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
               "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') and sublocationid=" + cmbSubLocation.SelectedValue + " group by product,sublocationid) as wastage on a.id=wastage.product and a.sublocationid=wastage.sublocationid " +
               "  ) where (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0))))<>0 order by a.name");

                }
                if(Form1.StockTag==1)
                {
                    if(optB1.Checked==true)
                    {
                        frmCrystalReport.ReportName = "StockReportBoth";
                    }
                    else
                    {
                        frmCrystalReport.ReportName = "StockReport1";
                    }
                    
                }
                else
                {
                    frmCrystalReport.ReportName = "StockReport";
                }
               
            }
   //         else if (optProduct.Checked == true)
   //         {
   //             dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,isnull(aaa.qty,0) as qty,isnull(inward.inward,0) as inward,0 as production, " +
   // "   isnull(outward.outward,0) as outward,0 as sale,isnull(consumed.consumed,0) as consumed,isnull(damages.damages,0) as damages,isnull(wastage.wastage,0) as wastage " +
   // "  ,a.unit from ( " +
   // "  (select id,code,name,unit from Inventory_Master " + rstring1 + ") as a left join  " +
   // "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
   //"   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty*conv) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
   // "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') group by product union all select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
   // "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return') group by product) as aa group by aa.product) as inward on a.id=inward.product " +
   //"   left join (select product,sum(qty) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
   //"   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product) as outward on a.id=outward.product " +
   // "  left join (select product,sum(qty) as consumed from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
   //"   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') group by product) as consumed on a.id=consumed.product " +
   // "  left join (select product,sum(qty) as damages from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
   // "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') group by product) as damages on a.id=damages.product " +
   // "  left join (select product,sum(qty) as wastage from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
   // "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') group by product) as wastage on a.id=wastage.product " +
   // "  ) where (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0))))<>0 order by a.name");
   //             frmCrystalReport.ReportName = "StockReportProduct";
   //         }
            else
            {
                if(optL1.Checked==true)
                {
                    dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,a.subgroupname,isnull(aaa.qty,0) as qty,case when isnull(inward.inward,0)>0 then round((isnull(inward.inward,0)/a.conv1),2) else 0 end  as inward,0 as production, " +
              "  case when isnull(outward.outward,0)>0 then  round( (isnull(outward.outward,0)/a.conv1),2) else 0 end as outward,0 as sale,isnull(consumed.consumed,0) as consumed,case when isnull(damages.damages,0)>0 then round((isnull(damages.damages,0)/a.conv1),2) else 0 end as damages,isnull(wastage.wastage,0) as wastage " +
              "  ,a.unit from ( " +
              "  (select id,code,name,(select name from inventory_sub_group_master where inventory_sub_group_master.id=inventory_s_group) as subgroupname,lot1 as unit,conv1 from Inventory_Master " + rstring1 + ") as a left join  " +
              "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
             "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') group by product union all select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return','Department') group by product) as aa group by aa.product) as inward on a.id=inward.product " +
             "   left join (select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
             "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product) as outward on a.id=outward.product " +
              "  left join (select product,sum(qty) as consumed from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
             "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') group by product) as consumed on a.id=consumed.product " +
              "  left join (select product,sum(qty) as damages from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') group by product) as damages on a.id=damages.product " +
              "  left join (select product,sum(qty) as wastage from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') group by product) as wastage on a.id=wastage.product " +
              "  ) where (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0))))<>0 order by a.name");

                }
                else if (optB1.Checked == true)
                {
                    dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,a.subgroupname,isnull(aaa.qty,0) as qty,case when isnull(inward.inward,0)>0 then round((isnull(inward.inward,0)),2) else 0 end  as inward,0 as production, " +
              "  case when isnull(outward.outward,0)>0 then  round( (isnull(outward.outward,0)),2) else 0 end as outward,0 as sale,isnull(consumed.consumed,0) as consumed,case when isnull(damages.damages,0)>0 then round((isnull(damages.damages,0)),2) else 0 end as damages,isnull(wastage.wastage,0) as wastage " +
              "  ,a.unit ,a.unitsmall,a.conv1 from ( " +
              "  (select id,code,name,(select name from inventory_sub_group_master where inventory_sub_group_master.id=inventory_s_group) as subgroupname,lot1 as unit,conv1,unit as unitSmall from Inventory_Master " + rstring1 + ") as a left join  " +
              "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
             "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') group by product union all select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return','Department') group by product) as aa group by aa.product) as inward on a.id=inward.product " +
             "   left join (select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
             "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product) as outward on a.id=outward.product " +
              "  left join (select product,sum(qty) as consumed from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
             "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') group by product) as consumed on a.id=consumed.product " +
              "  left join (select product,sum(qty) as damages from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') group by product) as damages on a.id=damages.product " +
              "  left join (select product,sum(qty) as wastage from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
              "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') group by product) as wastage on a.id=wastage.product " +
              "  ) where (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0))))<>0 order by a.name");

                }
                else
                {
                                    dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,a.subgroupname,isnull(aaa.qty,0) as qty,isnull(inward.inward,0) as inward,0 as production, " +
                              "   isnull(outward.outward,0) as outward,0 as sale,isnull(consumed.consumed,0) as consumed,isnull(damages.damages,0) as damages,isnull(wastage.wastage,0) as wastage " +
                              "  ,a.unit from ( " +
                              "  (select id,code,name,(select name from inventory_sub_group_master where inventory_sub_group_master.id=inventory_s_group) as subgroupname,unit from Inventory_Master " + rstring1 + ") as a left join  " +
                              "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master ) as aa group by aa.product) as aaa on a.id=aaa.product " +
                             "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') group by product union all select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return','Department') group by product) as aa group by aa.product) as inward on a.id=inward.product " +
                             "   left join (select product,sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                             "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product) as outward on a.id=outward.product " +
                              "  left join (select product,sum(qty) as consumed from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                             "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') group by product) as consumed on a.id=consumed.product " +
                              "  left join (select product,sum(qty) as damages from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') group by product) as damages on a.id=damages.product " +
                              "  left join (select product,sum(qty) as wastage from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') group by product) as wastage on a.id=wastage.product " +
                              "  ) where (((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)+isnull(wastage.wastage,0))))<>0 order by a.name");

                }

                if(Form1.StockTag==1)
                {
                    if(optB1.Checked==true)
                    {
                        frmCrystalReport.ReportName = "StockReportProductBoth";
                    }
                    else
                    {
                        frmCrystalReport.ReportName = "StockReportProduct1";
                    }
                   
                }
                else
                {
                    if (optB1.Checked == true)
                    {
                        frmCrystalReport.ReportName = "StockReportProductBoth";
                    }
                    else
                    {
                        frmCrystalReport.ReportName = "StockReportProduct";
                    }
                   
                }
              
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

        private void cmbSubLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbSubgroup.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cmbSubLocation.SelectedValue = 0;
                cmbSubLocation.Focus();
            }
        }

        private void cmbSubLocation_Validating(object sender, CancelEventArgs e)
        {
            if (cmbSubLocation.Text.Trim() != "")
            {
                if (cmbSubLocation.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select valid name.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSubLocation.Focus();
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void cmbcompany_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(cmbcompany.SelectedValue) != 0)
            {
                da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Shop') and companyid=" + cmbcompany.SelectedValue + " order by  rtag,name", cmbSubLocation, "ID", "Name");
            }

        }

        private void dtDateTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnPreview.Focus();
            }
        }

        private void frmStockReport_Load(object sender, EventArgs e)
        {
            cmbPri.SelectedIndex = 0;
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
