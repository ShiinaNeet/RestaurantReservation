using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

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
                button12.BringToFront();
                button12.BackColor = Color.Blue;
                button8.BackColor = Color.Black; button10.BackColor = Color.Black;
                button11.BackColor = Color.Black; button9.BackColor = Color.Black;
                button13.BackColor = Color.Black; button14.BackColor = Color.Black;

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
          
            Login.Account account = new Login.Account();
            
            label1.Text = account.getJob();
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0; 
            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderSize = 0;
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
            button6.Focus();
            panel2.Controls.Clear();
           
           
            if (button6.Focused == true) 
            {
                button14.BringToFront();
                button14.BackColor = Color.Blue;
                button8.BackColor = Color.Black; button10.BackColor = Color.Black;
                button11.BackColor = Color.Black; button12.BackColor = Color.Black;
                button13.BackColor = Color.Black; button9.BackColor = Color.Black;

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
                button11.BringToFront();
                button11.BackColor = Color.Blue;
                button8.BackColor = Color.Black; button9.BackColor = Color.Black;
                button10.BackColor = Color.Black; button12.BackColor = Color.Black;
                button13.BackColor = Color.Black; button14.BackColor = Color.Black;


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
                button9.BringToFront();
                button9.BackColor = Color.Blue;
                button8.BackColor = Color.Black; button10.BackColor = Color.Black;
                button11.BackColor = Color.Black; button12.BackColor = Color.Black;
                button13.BackColor = Color.Black; button14.BackColor = Color.Black;
               
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
                button13.BringToFront();
                button13.BackColor = Color.Blue;
                button8.BackColor = Color.Black; button10.BackColor = Color.Black;
                button11.BackColor = Color.Black; button12.BackColor = Color.Black;
                button9.BackColor = Color.Black; button14.BackColor = Color.Black;

                button5.BackColor = Color.Silver;
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
                button10.BringToFront();
                button10.BackColor = Color.Blue;
                button8.BackColor = Color.Black; button9.BackColor = Color.Black;
                button11.BackColor = Color.Black; button12.BackColor = Color.Black;
                button13.BackColor = Color.Black; button14.BackColor = Color.Black;


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
                button8.BackColor = Color.Blue;
                button9.BackColor = Color.Black; button10.BackColor = Color.Black;
                button11.BackColor = Color.Black; button12.BackColor = Color.Black;
                button13.BackColor = Color.Black; button14.BackColor = Color.Black;
                button8.BringToFront();
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

        private void newMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
