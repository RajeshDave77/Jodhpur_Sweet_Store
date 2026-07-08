using DevComponents.DotNetBar;
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
    public partial class frmSelectFinYear : Form
    {
        public frmSelectFinYear()
        {
            InitializeComponent();
        }

        

        

        private void frmSelectFinYear_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome " + MainIndex.UserFullName;
            label2.Text = "Your default selected Company: " + MainIndex.CompanyName;
            string FinYearStart = null;
            string FinYearEnd = null;
            if(DateTime.Today.Month>3)
            {
                FinYearStart = "" + DateTime.Today.Year;
                FinYearEnd = "" + (DateTime.Today.Year +1);
            }
            else
            {
                FinYearStart = "" + (DateTime.Today.Year-1);
                FinYearEnd = "" + DateTime.Today.Year;
            }
            label3.Text = "Current Financial Year From: " + FinYearStart + " To: " + FinYearEnd;
            btnOpen.Focus();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
                return;
            }
        }
    }
}
