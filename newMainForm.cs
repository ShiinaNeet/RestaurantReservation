using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantReservation
{
    public partial class newMainForm : Form
    {
        public delegate void setformValue(int ss);
        public setformValue setTableNum;
        public newMainForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            button3.Focus();
            if (button3.Focused == true)
            {
                button3.BackColor = Color.Silver;
                ProductOptionsForm ww = new ProductOptionsForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                ww.FormBorderStyle = FormBorderStyle.None;
                panel2.Controls.Add(ww);
                panel2.Refresh();
                ww.Show();
                button6.BackColor = SystemColors.InfoText;
                button1.BackColor = SystemColors.InfoText;
                button2.BackColor = SystemColors.InfoText;
                button4.BackColor = SystemColors.InfoText;
                button5.BackColor = SystemColors.InfoText;
                button7.BackColor = SystemColors.InfoText;
            }
        }

        private void newMainForm_Load(object sender, EventArgs e)
        {
            
        }
        public void formselect(Form f)  
        {
            panel2.Controls.Clear();
           // f.Dock = DockStyle.Fill;
          //  f.TopLevel = false;
          //  f.TopMost = true;
            f = new Form() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            // f ww = new f() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            f.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f);
            panel2.Refresh();
            panel2.Update();
            f.Show();
            f.Update();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
           
            button6.Focus();
           
            if (button6.Focused == true) 
            {
                button6.BackColor = Color.Silver;
                AboutForm ww = new AboutForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
                ww.FormBorderStyle = FormBorderStyle.None;
                ww.Focus();
                panel2.Controls.Add(ww);
                panel2.Refresh();
                ww.Show();
                button2.BackColor = SystemColors.InfoText;
                button1.BackColor = SystemColors.InfoText;
                button3.BackColor = SystemColors.InfoText;
                button4.BackColor = SystemColors.InfoText;
                button5.BackColor = SystemColors.InfoText;
                button7.BackColor = SystemColors.InfoText;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            panel2.Controls.Clear();
            button2.Focus();
            if (button2.Focused == true)
            {
                button2.BackColor = Color.Silver;
                OrdersOptions ww = new OrdersOptions() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                ww.FormBorderStyle = FormBorderStyle.None;
                panel2.Controls.Add(ww);
                panel2.Refresh();
                ww.Show();
                button6.BackColor = SystemColors.InfoText;
                button1.BackColor = SystemColors.InfoText;
                button3.BackColor = SystemColors.InfoText;
                button4.BackColor = SystemColors.InfoText;
                button5.BackColor = SystemColors.InfoText;
                button7.BackColor = SystemColors.InfoText;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            button7.Focus();
            if (button7.Focused == true)
            {
                button7.BackColor = Color.Silver;
                TableForm ww = new TableForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                ww.FormBorderStyle = FormBorderStyle.None;
                panel2.Controls.Add(ww);
                panel2.Refresh();
                ww.Show();
                button6.BackColor = SystemColors.InfoText;
                button1.BackColor = SystemColors.InfoText;
                button3.BackColor = SystemColors.InfoText;
                button4.BackColor = SystemColors.InfoText;
                button5.BackColor = SystemColors.InfoText;
                button2.BackColor = SystemColors.InfoText;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            button5.Focus();
            if (button5.Focused == true)
            {
                button4.BackColor = Color.Silver;
                AccountsForm ww = new AccountsForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                ww.FormBorderStyle = FormBorderStyle.None;
                panel2.Controls.Add(ww);
                panel2.Refresh();
                ww.Show();
                button6.BackColor = SystemColors.InfoText;
                button1.BackColor = SystemColors.InfoText;
                button3.BackColor = SystemColors.InfoText;
                button2.BackColor = SystemColors.InfoText;
                button4.BackColor = SystemColors.InfoText;
                button7.BackColor = SystemColors.InfoText;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            button4.Focus();
            if (button4.Focused == true)
            {
                button4.BackColor = Color.Silver;
                SalesDashboard ww = new SalesDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                ww.FormBorderStyle = FormBorderStyle.None;
                panel2.Controls.Add(ww);
                panel2.Refresh();
                ww.Show();
                button6.BackColor = SystemColors.InfoText;
                button1.BackColor = SystemColors.InfoText;
                button3.BackColor = SystemColors.InfoText;
                button2.BackColor = SystemColors.InfoText;
                button5.BackColor = SystemColors.InfoText;
                button7.BackColor = SystemColors.InfoText;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            button1.Focus();
            if (button1.Focused == true)
            {
                button1.BackColor = Color.Silver;
                HomeForm ww = new HomeForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                ww.FormBorderStyle = FormBorderStyle.None;
                panel2.Controls.Add(ww);
                panel2.Refresh();
                ww.Show();
                button6.BackColor = SystemColors.InfoText;
                button4.BackColor = SystemColors.InfoText;
                button3.BackColor = SystemColors.InfoText;
                button2.BackColor = SystemColors.InfoText;
                button5.BackColor = SystemColors.InfoText;
                button7.BackColor = SystemColors.InfoText;
            }
        }
    }
}
