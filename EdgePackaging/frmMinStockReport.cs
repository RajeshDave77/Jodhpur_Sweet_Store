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
     
    public partial class frmMinStockReport : Form
    {
        database_admin da = new database_admin();
        public frmMinStockReport()
        {
            InitializeComponent();
            da.fill_combo("select id,(name)as name from Ledger_Master where type in ('Godown') order by id", cmbcompany, "ID", "Name");
            if(Convert.ToInt32(Form1.UserID)!=1)
            {
                cmbcompany.SelectedValue = Form1.CompanyID;
                cmbcompany.Enabled = false;
            }
            
            da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Sub_Group_Master order by rtag,name", cmbSubgroup, "ID", "Name");
            da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Master order by rtag,name", cmbProduct, "ID", "Name");
            da.fill_combo("select 0 as id,'All' as name,1 as rtag union all select ID,Name,2 as rtag from Ledger_Master where companyid=" + Form1.Godownid + " and type in ('Supplier') order by rtag,name", cmbParty, "ID", "Name");
            cmbParty.SelectedValue = 0;
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
                string rstring1 = ""; string rstring2 = "";
                string companyname = cmbcompany.Text;
                string rtext = "";
                rtext = "Min. Stock Level Report of " + companyname + " as on Date: " + dtDate.Value.Date.ToString("dd/MM/yyyy");
                if (cmbSubgroup.SelectedIndex != -1 && Convert.ToInt32(cmbSubgroup.SelectedValue) != 0)
                {
                    rstring1 = "where Inventory_S_Group= " + cmbSubgroup.SelectedValue;
                     rtext = "Stock Report of " + companyname + " as on Date: " + dtDate.Value.Date.ToString("dd/MM/yyyy")+ "  Sub Group: "+cmbSubgroup.Text;
                }
                if (cmbProduct.SelectedIndex != -1 && Convert.ToInt32(cmbProduct.SelectedValue) != 0)
                {
                        rstring1 = " where id= " + cmbProduct.SelectedValue;
                    rtext = "Stock Report of " + companyname + " as on Date: " + dtDate.Value.Date.ToString("dd/MM/yyyy") + "  Product: " + cmbProduct.Text;
                }
                if (cmbParty.SelectedIndex != -1 && Convert.ToInt32(cmbParty.SelectedValue) != 0)
                {
                    rstring2 = " and party= " + Convert.ToInt32(cmbParty.SelectedValue);
                }
            if (optProduct.Checked==true)
            {
                if (cmbParty.SelectedIndex != -1 && Convert.ToInt32(cmbParty.SelectedValue) != 0)
                {
                    dsReport = da.dataset_ret("select yyy.* from (select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,isnull(aaa.qty,0) as qty,isnull(inward.inward,0) as inward,0 as production, " +
                                   "   isnull(outward.outward,0) as outward,0 as sale,isnull(consumed.consumed,0) as consumed,isnull(damages.damages,0) as damages,isnull(wastage.wastage,0) as wastage " +
                                   "  ,a.unit,a.minlevel,isnull((select top 1 invoicedate from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid where StockType='Purchase' and product=a.id order by stockinwarddetail.id desc),'') as lastdt, " +
                                     "  isnull((select top 1 partyname from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid where StockType='Purchase' and product=a.id " + rstring2 + "  order by stockinwarddetail.id desc),'') as partyname from ( " +
                                   "  (select id,code,name,unit,isnull((select top 1 minlevel_entry.minlevel from minlevel_entry where productid=inventory_master.id and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "),0) as minlevel from Inventory_Master " + rstring1 + ") as a left join  " +
                                   "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master) as aa group by aa.product) as aaa on a.id=aaa.product " +
                                  "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty*conv) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') group by product union all select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return') group by product) as aa group by aa.product) as inward on a.id=inward.product " +
                                  "   left join (select product,sum(qty) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                  "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product) as outward on a.id=outward.product " +
                                   "  left join (select product,sum(qty) as consumed from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                  "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') group by product) as consumed on a.id=consumed.product " +
                                   "  left join (select product,sum(qty) as damages from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                   "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') group by product) as damages on a.id=damages.product " +
                                    "  left join (select product,sum(qty) as wastage from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                   "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') group by product) as wastage on a.id=wastage.product " +
                                   " ) ) as yyy where yyy.partyname!='' order by yyy.name");
                }
                else
                {

                    dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,isnull(aaa.qty,0) as qty,isnull(inward.inward,0) as inward,0 as production, " +
                                   "   isnull(outward.outward,0) as outward,0 as sale,isnull(consumed.consumed,0) as consumed,isnull(damages.damages,0) as damages,isnull(wastage.wastage,0) as wastage " +
                                   "  ,a.unit,a.minlevel,isnull((select top 1 invoicedate from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid where StockType='Purchase' and product=a.id order by stockinwarddetail.id desc),'') as lastdt, " +
                                     "  isnull((select top 1 partyname from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid where StockType='Purchase' and product=a.id   order by stockinwarddetail.id desc),'') as partyname from ( " +
                                   "  (select id,code,name,unit,isnull((select top 1 minlevel_entry.minlevel from minlevel_entry where productid=inventory_master.id and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "),0) as minlevel from Inventory_Master " + rstring1 + ") as a left join  " +
                                   "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master) as aa group by aa.product) as aaa on a.id=aaa.product " +
                                  "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty*conv) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') group by product union all select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return') group by product) as aa group by aa.product) as inward on a.id=inward.product " +
                                  "   left join (select product,sum(qty) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                  "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " )  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product) as outward on a.id=outward.product " +
                                   "  left join (select product,sum(qty) as consumed from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                  "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') group by product) as consumed on a.id=consumed.product " +
                                   "  left join (select product,sum(qty) as damages from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                   "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') group by product) as damages on a.id=damages.product " +
                                     "  left join (select product,sum(qty) as wastage from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                   "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') group by product) as wastage on a.id=wastage.product " +
                                   " ) order by a.name");
                }
             
            }
            else
            {
                if (cmbParty.SelectedIndex != -1 && Convert.ToInt32(cmbParty.SelectedValue) != 0)
                {
                    dsReport = da.dataset_ret("select yyy.* from (select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,isnull(aaa.qty,0) as qty,isnull(inward.inward,0) as inward,0 as production, " +
                                   "   isnull(outward.outward,0) as outward,0 as sale,isnull(consumed.consumed,0) as consumed,isnull(damages.damages,0) as damages,isnull(wastage.wastage,0) as wastage " +
                                   "  ,a.unit,a.minlevel,isnull((select top 1 invoicedate from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid where StockType='Purchase' and product=a.id order by stockinwarddetail.id desc),'') as lastdt, " +
                                     "  isnull((select top 1 partyname from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid where StockType='Purchase' and product=a.id " + rstring2 + " order by stockinwarddetail.id desc),'') as partyname from ( " +
                                   "  (select id,code,name,unit,isnull((select top 1 minlevel_entry.minlevel from minlevel_entry where productid=inventory_master.id and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "),0) as minlevel from Inventory_Master " + rstring1 + ") as a left join  " +
                                   "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master) as aaa on a.id=aaa.product " +
                                  "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty*conv) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') group by product union all select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return') group by product) as aa group by aa.product) as inward on a.id=inward.product " +
                                  "   left join (select product,sum(qty) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                  "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product) as outward on a.id=outward.product " +
                                   "  left join (select product,sum(qty) as consumed from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                  "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') group by product) as consumed on a.id=consumed.product " +
                                   "  left join (select product,sum(qty) as damages from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                   "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') group by product) as damages on a.id=damages.product " +
                                    "  left join (select product,sum(qty) as wastage from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                   "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') group by product) as wastage on a.id=wastage.product " +
                                   " ) where a.minlevel>(((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0))))) as yyy where yyy.partyname!='' order by yyy.name");
                }
                else
                {
                    dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring,a.id,a.code,a.name,isnull(aaa.qty,0) as qty,isnull(inward.inward,0) as inward,0 as production, " +
                                   "   isnull(outward.outward,0) as outward,0 as sale,isnull(consumed.consumed,0) as consumed,isnull(damages.damages,0) as damages,isnull(wastage.wastage,0) as wastage " +
                                   "  ,a.unit,a.minlevel,isnull((select top 1 invoicedate from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid where StockType='Purchase' and product=a.id order by stockinwarddetail.id desc),'') as lastdt, " +
                                     "  isnull((select top 1 partyname from stockinwardmaster inner join stockinwarddetail on stockinwardmaster.id=masterid where StockType='Purchase' and product=a.id  order by stockinwarddetail.id desc),'') as partyname from ( " +
                                   "  (select id,code,name,unit,isnull((select top 1 minlevel_entry.minlevel from minlevel_entry where productid=inventory_master.id and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "),0) as minlevel from Inventory_Master " + rstring1 + ") as a left join  " +
                                   "  (select aa.product,sum(aa.qty) as qty from( select id as  product,opening_stock as qty from inventory_master) as aa group by aa.product) as aaa on a.id=aaa.product " +
                                  "   left join (select aa.product,sum(aa.inward) as inward from (select product,sum(qty*conv) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " ) and StockType in ('Purchase','Issue Return') group by product union all select product,sum(qty) as inward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                              "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and (party=" + Convert.ToInt32(cmbcompany.SelectedValue) + ") and StockType in ('Issue','Issue Return') group by product) as aa group by aa.product) as inward on a.id=inward.product " +
                                  "   left join (select product,sum(qty) as outward from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                  "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Dispatch Challan','Issue','Purchase Return','Department') group by product) as outward on a.id=outward.product " +
                                   "  left join (select product,sum(qty) as consumed from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                  "   where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Consumed') group by product) as consumed on a.id=consumed.product " +
                                   "  left join (select product,sum(qty) as damages from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                   "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Damages') group by product) as damages on a.id=damages.product " +
                                    "  left join (select product,sum(qty) as wastage from stockinwardmaster inner join StockInwardDetail on StockInwardMaster.id=masterid " +
                                   "  where invoicedate1<='" + dtDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + "  and StockType in ('Wastage') group by product) as wastage on a.id=wastage.product " +
                                   " ) where a.minlevel>(((isnull(aaa.qty,0)+isnull(inward.inward,0))-(isnull(outward.outward,0)+isnull(consumed.consumed,0)+isnull(damages.damages,0)))) order by a.name");
                }
            }
            frmCrystalReport.ReportName = "MinStockReport";
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

        private void cmbParty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPreview.Focus();
            }
        }

        private void cmbParty_Validating(object sender, CancelEventArgs e)
        {
            if (cmbParty.Text.Trim() != "")
            {
                if (cmbParty.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select valid party.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbParty.Focus();
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

        private void cmbParty_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
