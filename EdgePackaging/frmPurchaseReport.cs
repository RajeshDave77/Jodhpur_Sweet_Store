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
     
    public partial class frmPurchaseReport : Form
    {
        database_admin da = new database_admin();
        int rcheck = 1;
        public frmPurchaseReport()
        {
            InitializeComponent();
            da.fill_combo("select id,(name)as name  from ledger_Master where  type in ('Godown') order by id", cmbcompany, "ID", "Name");
            if(Convert.ToInt32(Form1.UserID)!=1)
            {
                cmbcompany.SelectedValue = Form1.CompanyID;
                cmbcompany.Enabled = false;
            }
            da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Shop') and companyid="+cmbcompany.SelectedValue+" order by  rtag,name", cmbSubLocation, "ID", "Name");
            da.fill_combo("select 0 as id,'--Select--' as name,1 as rtag union all select ID,Name,2 as rtag from Ledger_Master where companyid=" + Form1.Godownid + " and type in ('Supplier','Godown','Department') order by rtag,name", cmbParty, "ID", "Name");
            cmbParty.SelectedValue = 0;
            da.fill_combo(" select 0 as id,'All' as name,1 as rtag union all select  ID, Name,2 as rtag from Inventory_Master order by rtag,name", cmbProduct, "ID", "Name");
            cmbOption.SelectedIndex = 0;
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
                cmbSubLocation.Focus();
            }
        }
        public static DataSet dsReport=new DataSet();
        private void btnPreview_Click(object sender, EventArgs e)
        {
            string rstring = "";
            string rstring2 = "";
            string rOption = "";
            if(cmbOption.Text=="Production")
            {
                rstring = " StockType='Production' ";
                rOption = " Production ";
            }
            else if (cmbOption.Text == "Dispatch Challan")
            {
                rstring = " StockType='Dispatch Challan' ";
                rOption = " Dispatch Challan ";
            }
            else if (cmbOption.Text == "Purchase")
            {
                rstring = " StockType='Purchase' ";
                rOption = " Purchase ";
            }
            else if (cmbOption.Text == "Purchase Return")
            {
                rstring = " StockType='Purchase Return' ";
                rOption = " Purchase Return ";
            }
            else if (cmbOption.Text == "Issue" || cmbOption.Text == "Issue (Inv.Date Wise)" || cmbOption.Text == "Issue (Ex.Date Wise)")
            {
                rstring = " StockType='Department' ";
                rOption = " Issue ";
            }
            else if (cmbOption.Text == "Issue Return")
            {
                rstring = " StockType='Issue Return' ";
                rOption = " Issue Return ";
            }
            else if (cmbOption.Text == "Stock Inward")
            {
                rstring = " StockType='Stock Inward' ";
                rOption = " Stock Inward ";
            }
            else if (cmbOption.Text == "Consumed")
            {
                rstring = " StockType='Consumed' ";
                rOption = " Consumed ";
            }
            else if (cmbOption.Text == "Damages")
            {
                rstring = " StockType='Damages' ";
                rOption = " Damages ";
            }
            rstring =rstring+ "  and invoicedate1>='" + dtFromDate.Value.Date.ToString("yyyy-MM-dd") + "' and invoicedate1<='" + dtToDate.Value.Date.ToString("yyyy-MM-dd") + "' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue);
            if (cmbParty.SelectedIndex != -1 && Convert.ToInt32(cmbParty.SelectedValue) != 0)
            {

                rstring = rstring + " and party=" + cmbParty.SelectedValue;

            }
            if (cmbSubLocation.SelectedIndex != -1 && Convert.ToInt32(cmbSubLocation.SelectedValue) != 0)
            {

                rstring2 = " where  sublocationid=" + cmbSubLocation.SelectedValue;

            }
          string rstring1 = "";
       
          if (cmbProduct.SelectedIndex != -1 && Convert.ToInt32(cmbProduct.SelectedValue) != 0)
          {
            
                  rstring1 = " where not b.product is null and b.product=" + cmbProduct.SelectedValue;
            
          }
            else
          {
              rstring1 = " where not b.product is null ";
          }
           // DataSet ds = new DataSet();
            string companyname = cmbcompany.Text;
            string rtext =rOption+ " Report of "+companyname+ " From Date: " + dtFromDate.Value.Date.ToString("dd/MM/yyyy") + " To Date: " + dtToDate.Value.Date.ToString("dd/MM/yyyy");
            if (Convert.ToInt16(cmbOption.SelectedIndex) == 5 || Convert.ToInt16(cmbOption.SelectedIndex) == 6)
            {
                dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring, a.invoicedate,a.invoicedate1,b.productname,sum(b.qty) as qty,b.unit,b.exdate,b.ExDate1 from ((select StockInwardMaster.* from StockInwardMaster where " + rstring + ") as a left join " +
                                            "(select StockInwardDetail.*,(select name from Inventory_Master where id=product)as productname,isnull((select ledger_master.name from ledger_master where ledger_master.id=sublocationid),'') as sublocation from StockInwardDetail " + rstring2 + ")as b on a.id=b.masterid left join (select id,name from ledger_master) as c on a.companyid=c.id) " + rstring1 + " group by a.invoicedate,a.invoicedate1,b.productname,b.unit,b.exdate,b.ExDate1 order by a.invoicedate1 ");

            }
            else
            {
                dsReport = da.dataset_ret("select '" + companyname + "' as rcompany,'" + rtext + "' as rstring, a.*,b.*,isnull(c.name,'') as location1 from ((select StockInwardMaster.* from StockInwardMaster where " + rstring + ") as a left join " +
                                            "(select StockInwardDetail.*,(select name from Inventory_Master where id=product)as productname,isnull((select ledger_master.name from ledger_master where ledger_master.id=sublocationid),'') as sublocation from StockInwardDetail " + rstring2 + ")as b on a.id=b.masterid left join (select id,name from ledger_master) as c on a.companyid=c.id)" + rstring1 +" order by a.id ");

            }
            if (dsReport.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt16(cmbOption.SelectedIndex) == 5)
                {
                    frmCrystalReport.ReportName = "IssueReport";
                }
                else if (Convert.ToInt16(cmbOption.SelectedIndex) == 6)
                {
                    frmCrystalReport.ReportName = "IssueReport1";
                }
                else
                {
                    frmCrystalReport.ReportName = "PurchaseReport";
                }
             
                frmCrystalReport obj_report = new frmCrystalReport();
                obj_report.ShowDialog();

            } 
            else
            {
                MessageBox.Show("There are no purchase report available.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmbSubLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSubLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmbParty.Focus();
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
                da.fill_combo("select 0 as id,'---Select---' as name,1 as rtag union all select id,(name) as name,2 as rtag from ledger_Master where type in ('Shop','Department') and companyid=" + cmbcompany.SelectedValue + " order by  rtag,name", cmbSubLocation, "ID", "Name");
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
