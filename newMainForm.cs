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
            ProductOptionsForm ww = new ProductOptionsForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            ww.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(ww);
            panel2.Refresh();
            ww.Show();
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
            AboutForm ww = new AboutForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            ww.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(ww);
            panel2.Refresh();
            ww.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            OrdersOptions ww = new OrdersOptions() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            ww.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(ww);
            panel2.Refresh();
            ww.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            TableForm ww = new TableForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            ww.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(ww);
            panel2.Refresh();
            ww.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
