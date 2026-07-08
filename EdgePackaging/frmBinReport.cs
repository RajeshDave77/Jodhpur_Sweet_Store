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
     
    public partial class frmBinReport : Form
    {
        database_admin da = new database_admin();
        public frmBinReport()
        {
            InitializeComponent();
            da.fill_combo("select id,(name)as name from ledger_Master where type in ('Godown') order by id", cmbcompany, "ID", "Name");
            if(Convert.ToInt32(Form1.UserID)!=1)
            {
                cmbcompany.SelectedValue = Form1.CompanyID;
                cmbcompany.Enabled = false;
            }
           
            da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Sub_Group_Master order by rtag,name", cmbSubgroup, "ID", "Name");
            da.fill_combo(" select 0 as id,'--Select--' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Master order by rtag,name", cmbProduct, "ID", "Name");

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
            if(Convert.ToInt32(cmbProduct.SelectedValue)==0)
            {
                MessageBox.Show("Please select product.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbProduct.Focus();
                return;
            }
            string company = "";
           
                company = " and companyid=" + Convert.ToInt32( cmbcompany.SelectedValue);
                string rstring1 = "";
                string rstring2 = "";
                string companyname = cmbcompany.Text;
                string rtext = "";
                rtext = "Bin Card Report of " + companyname + " From Date: " + dtDate.Value.Date.ToString("dd/MM/yyyy")+ " To Date: " + dtToDate.Value.Date.ToString("dd/MM/yyyy");
                if (cmbSubgroup.SelectedIndex != -1 && Convert.ToInt32(cmbSubgroup.SelectedValue) != 0)
                {
                    rstring1 = "where Inventory_S_Group= " + cmbSubgroup.SelectedValue;
                    rstring2 = " and Inventory_S_Group= " + cmbSubgroup.SelectedValue;
                    rtext = "Bin Card Report of " + companyname + " From Date: " + dtDate.Value.Date.ToString("dd/MM/yyyy") + " To Date: " + dtToDate.Value.Date.ToString("dd/MM/yyyy") + "  Sub Group: " + cmbSubgroup.Text;
                }
                if (cmbProduct.SelectedIndex != -1 && Convert.ToInt32(cmbProduct.SelectedValue) != 0)
                {
                        rstring1 = " where inventory_master.id= " + cmbProduct.SelectedValue;
                        rstring2 = " and inventory_master.id= " + cmbProduct.SelectedValue;
                        rtext = "Bin Card Report of  " + companyname + " From Date: " + dtDate.Value.Date.ToString("dd/MM/yyyy") + " To Date: " + dtToDate.Value.Date.ToString("dd/MM/yyyy") + "  Product: " + cmbProduct.Text;
                }
     
                         
                frmCrystalReport.ReportName = "BinReport";

                dsReport = da.dataset_ret("select '" + rtext + "' as rtext, a.name as product,a.code,a.unit as basicunit,a.mgodown,b.invoicedate,b.invoiceno,b.partyname,b.location1,b.qty,b.unit,b.username,b.qty1,case when a.unit<>b.unit1 then a.Unit else b.unit1 end as unit1,b.username1,b.StockType,isnull((select minlevel from minlevel_entry where productid=a.id and companyid=" + cmbcompany.SelectedValue + "),0) as min,b.sublocation,b.sublocation1 from ((select id,name,code,unit,'" + Form1.SingleCode(cmbcompany.Text) + "' as mgodown,1 as mid from Inventory_Master  where id=" + cmbProduct.SelectedValue + ") as a left join " +
                                                   " (select '" + dtDate.Value.ToString("dd-MM-yyyy") + "' as invoicedate,'" + dtDate.Value.ToString("yyyy-MM-dd") + "' as invoicedate1,'' as invoiceno,'Opening Balance' as partyname,'' as location1,case when sum(zz.qty)> sum(zz.qty1) then (sum(zz.qty)-sum(zz.qty1)) else 0 end as qty,'' as unit," + cmbProduct.SelectedValue + " as product,'' as username,'Opening Balance' as stocktype,case when sum(zz.qty1)>=sum(zz.qty) then  (sum(zz.qty1)-sum(zz.qty1)) else 0 end as qty1,'' as unit1,'' as username1,0 as id,'' as sublocation,'' as sublocation1 from (select isnull(sum(qty),0) as qty,0 as qty1  from StockInwardMaster  inner join StockInwardDetail on StockInwardDetail.Masterid=StockInwardMaster.id  where  invoicedate1<'" + dtDate.Value.ToString("yyyy-MM-dd") + "' and product=" + cmbProduct.SelectedValue + " and stockinwardmaster.companyid=" + cmbcompany.SelectedValue + "  and  StockType in ('Purchase') union all select isnull(sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end),0) as qty,0 as qty1  from StockInwardMaster  inner join StockInwardDetail on   StockInwardDetail.Masterid=StockInwardMaster.id   where invoicedate1<'" + dtDate.Value.ToString("yyyy-MM-dd") + "'	 and  product=" + cmbProduct.SelectedValue + " and  stockinwardmaster.party=" + cmbcompany.SelectedValue + "  and StockType in ('Issue','Department') " +
                                                   "  union all  select  0 as qty,isnull(sum(case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end),0) as qty1 from StockInwardMaster 	  inner join StockInwardDetail on 	  StockInwardDetail.Masterid=StockInwardMaster.id   where  invoicedate1<'" + dtDate.Value.ToString("yyyy-MM-dd") + "'  and  product=" + cmbProduct.SelectedValue + " and  stockinwardmaster.companyid=" + cmbcompany.SelectedValue + "  and StockType in ('Issue','Department','Damages')) as zz union all select invoicedate,invoicedate1,invoiceno,isnull(l1.name,'') as partyname,'' as location1,(qty) as qty,unit as unit,product,user_master.username,stocktype,0 as qty1,'' as unit1,'' as username1,StockInwardMaster.id,isnull(ledger_master.name,'') as sublocation,'' as sublocation1  from StockInwardMaster left join Ledger_Master l1 on l1.id=StockInwardMaster.Party " +
                                                    " inner join StockInwardDetail on StockInwardDetail.Masterid=StockInwardMaster.id left join user_master on user_master.id=stockinwardmaster.userid left join ledger_master on ledger_master.id=sublocationid  where (invoicedate1>='"+dtDate.Value.ToString("yyyy-MM-dd")+"' and invoicedate1<='"+dtToDate.Value.ToString("yyyy-MM-dd")+"') and product=" + cmbProduct.SelectedValue + " and stockinwardmaster.companyid=" + cmbcompany.SelectedValue + " and StockType in ('Purchase')  union all select invoicedate,invoicedate1,invoiceno,isnull(l1.name,'') as partyname,'' as location1, " +
                                                   " case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end as qty,unit,product,user_master.username,stocktype,0 as qty1,'' as unit1,'' as username1,StockInwardMaster.id,isnull(ledger_master.name,'') as sublocation,'' as sublocation1  from StockInwardMaster left join Ledger_Master l1 on l1.id=StockInwardMaster.companyid  inner join StockInwardDetail on StockInwardDetail.Masterid=StockInwardMaster.id left join user_master on user_master.id=stockinwardmaster.userid left join ledger_master on ledger_master.id=sublocationid  " +
                                                   " where (invoicedate1>='" + dtDate.Value.ToString("yyyy-MM-dd") + "' and invoicedate1<='" + dtToDate.Value.ToString("yyyy-MM-dd") + "') and  product=" + cmbProduct.SelectedValue + " and  stockinwardmaster.party=" + cmbcompany.SelectedValue + " and StockType in ('Issue','Department')  union all select invoicedate,invoicedate1,'' as invoiceno, '' as partyname,case when stocktype='Damages' then 'Damages' else isnull(l1.name,'') end as location1,0 as qty,'' as unit,product,'' as username,stocktype,case when dbo.GETConversionBasic(product,unit)<>0 then qty else (dbo.GETConversion(product,unit)*qty) end as qty1,unit as unit1,user_master.UserName as username1,StockInwardMaster.id,'' as sublocation, isnull(ledger_master.name,'')  as sublocation1  from StockInwardMaster left join Ledger_Master l1 on l1.id=StockInwardMaster.party " +
                                                    " inner join StockInwardDetail on StockInwardDetail.Masterid=StockInwardMaster.id left join user_master on user_master.id=stockinwardmaster.userid left join ledger_master on ledger_master.id=sublocationid2   where (invoicedate1>='" + dtDate.Value.ToString("yyyy-MM-dd") + "' and invoicedate1<='" + dtToDate.Value.ToString("yyyy-MM-dd") + "') and  product=" + cmbProduct.SelectedValue + " and  stockinwardmaster.companyid=" + cmbcompany.SelectedValue + " and StockType in ('Issue','Department','Damages') ) as b  on a.id=b.product) order by b.invoicedate1,b.id");
           
            if (dsReport.Tables[0].Rows.Count > 0)
            {
                
                frmCrystalReport obj_report = new frmCrystalReport();
                obj_report.ShowDialog();
                dsReport.Dispose();
                dsReport.Tables.Clear();
            } 
            else
            {
                MessageBox.Show("There are no bin card report available.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmbSubgroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSubgroup_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ComboBox cb = (ComboBox)sender;
                cb.DroppedDown = false;
                cb.SelectionStart = cb.Text.Length;
                cb.SelectionLength = 0;
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
