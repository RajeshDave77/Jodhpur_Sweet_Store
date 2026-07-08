using EdgePackingShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EdgePackaging
{
    class MyDataGridViewVoucher : DataGridView
    {

        protected override bool ProcessDialogKey(Keys keyData)
        {
            
                if (keyData == Keys.Enter)
                {
                    base.ProcessTabKey(Keys.Tab);
                    return true;
                }
            
            
            
            return base.ProcessDialogKey(keyData);
        }

        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                base.ProcessTabKey(Keys.Tab);
                return true;
            }
            return base.ProcessDataGridViewKey(e);
        }
    }
}
