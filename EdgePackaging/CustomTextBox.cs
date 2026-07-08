using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace EdgePackaging
{
    public partial class CustomTextBox : TextBox
    {
        public CustomTextBox()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw, true);              //|ControlStyles.UserPaint


            giveDesign();
            this.Enter += CustomTextBox_Enter;
            this.Leave += CustomTextBox_Leave;
            this.GotFocus += CustomTextBox_GotFocus;
            this.KeyDown += CustomTextBox_KeyDown;
        }

        private void giveDesign()
        {
            BackColor = Color.Transparent;
            BorderStyle = BorderStyle.None;
            Font font = new Font("Tahoma", 11.0f);
            Font = font;
            //Font = new Font(Font.FontFamily, 11);
            Font = new Font(Font, FontStyle.Regular);

            //  Size = new Size(103, 20);
        }

        private void CustomTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            TextBox tb = (TextBox)sender;

            if (e.KeyCode == Keys.Back)
            {                   
                if (tb.SelectionStart == 0)
                {
                    SendKeys.Send("+{TAB}");
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void CustomTextBox_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectionStart = 0;
            tb.SelectionLength = tb.Text.Length;
        }

        private void CustomTextBox_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.ForeColor = Color.Black;
            tb.BackColor = Color.Transparent;

        }

        private void CustomTextBox_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.ForeColor = Color.Black;
            tb.BackColor = Color.White;
        }

    }
}
