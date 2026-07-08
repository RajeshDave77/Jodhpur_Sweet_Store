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
    public partial class frmSalary : Form
    {
        public frmSalary()
        {
            InitializeComponent();
        }
        database_admin da = new database_admin();
        int rcheck = 0;
        private void frmSalary_Load(object sender, EventArgs e)
        {
            rcheck = 1;
            cmbAll.SelectedIndex = 0;
            da.fill_combo("select id,(name)as name from ledger_Master where type in ('Godown','Shop') order by id", cmbcompany, "ID", "Name");
            if (Convert.ToInt32(Form1.UserID) != 1)
            {
                cmbcompany.SelectedValue = Form1.CompanyID;
                cmbcompany.Enabled = false;
            }

            int intloop;
            for (intloop = 2020; (intloop <= DateTime.Now.Year); intloop++)
            {
                cmbYear.Items.Add(intloop);
            }

            cmbYear.Text = DateTime.Now.Year.ToString();
            DateTime dt = DateTime.Today;

            string thisMonth = dt.ToString("MMMM");
            cmbAll.Text = thisMonth;
            Show();
            cmbAll.Focus();
            rcheck = 0;
        }
        private void Show()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet rstemp = new DataSet();
                string rString = "";
                string rString1 = "";
                string rDate;
                string rWhere = "";
                if (txtNameSearch.Text.Trim() != "")
                {
                    rWhere = " and name like '%" + txtNameSearch.Text + "%' ";
                }
                if ((Convert.ToInt32(cmbAll.SelectedIndex) < 10))
                {
                    rString = " and locationid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " and substring(cast(attdate as varchar(10)),1,7) =('" + cmbYear.Text + "-0" + Convert.ToInt32(cmbAll.SelectedIndex) + "' )";
                    rString1 = "  substring(cast(attdate as varchar(10)),1,7) =('" + cmbYear.Text + "-0" + Convert.ToInt32(cmbAll.SelectedIndex) + "' )";
                    rDate = cmbYear.Text + "-0" + Convert.ToInt32(cmbAll.SelectedIndex) + "-25";
                }
                else
                {
                    rString = " and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " and substring(cast(attdate as varchar(10)),1,7) =('" + cmbYear.Text + "-" + Convert.ToInt32(cmbAll.SelectedIndex) + "' )";
                    rString1 = "  substring(cast(attdate as varchar(10)),1,7) =('" + cmbYear.Text + "-" + Convert.ToInt32(cmbAll.SelectedIndex) + "' )";
                    rDate = cmbYear.Text + "-" + Convert.ToInt32(cmbAll.SelectedIndex) + "-25";
                }
                rstemp = da.dataset_ret("select a.id,a.Name,a.scode as [Staff Code],isnull(b.pp,0) as Present,isnull(c.aa,0) as Absent from ((select id,scode,name from ledger_master where type='Staff' and companyid=" + Convert.ToInt32(cmbcompany.SelectedValue) + " " + rWhere + ") as a left join (select aa.staffid,sum(cast(pp as decimal(10,2))) as pp from (select staffid,sum(1.00) as pp from Attendance where att='P' " + rString + " group by staffid union all select staffid,sum(.50) as pp from Attendance where att='P1/2' " + rString + " group by staffid union all select staffid,sum(0.25) as pp from Attendance where att='P1/4' " + rString + " group by staffid) as aa group by aa.staffid) as b on a.id=b.staffid left join (select aa.staffid,sum(cast(pp as decimal(10,2))) as aa from (select staffid,sum(1) as pp from Attendance where att='A' " + rString + " group by staffid union all select staffid,sum(2) as pp from Attendance where att='2A' " + rString + " group by staffid ) as aa group by aa.staffid) as c on a.id=c.staffid) order by a.name");
                dbGrid.DataSource = rstemp.Tables[0];
                int intloop = 0;

                dbGrid.Columns["id"].Visible = false;
              
                for (intloop = 0; intloop < dbGrid.Rows.Count; intloop++)
                {
                   
                    
                    dbGrid.Rows[intloop].HeaderCell.Value = Convert.ToString(intloop + 1);
                }
                this.Cursor = Cursors.Default;
            }
            catch
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbAll_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(cmbAll.SelectedIndex)==0)
            {
                MessageBox.Show("Please select month.", "Edge Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbAll.Focus();
            }
            Show();
        }
    }
}
