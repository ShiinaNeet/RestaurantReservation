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
        public string job;
        public newMainForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            ProductBTN.Focus();
            if (ProductBTN.Focused == true)
            {
              /*  button12.BringToFront();
                button12.BackColor = Color.Blue;
                button8.BackColor = Color.Black; button10.BackColor = Color.Black;
                button11.BackColor = Color.Black; button9.BackColor = Color.Black;
                button13.BackColor = Color.Black; button14.BackColor = Color.Black;
              */
                ProductBTN.BackColor = Color.Silver;
                ProductOptionsForm ww = new ProductOptionsForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                ww.FormBorderStyle = FormBorderStyle.None;
                panel2.Controls.Add(ww);
                panel2.Refresh();
                ww.Show();
                AboutBTN.BackColor = SystemColors.InfoText;
                HomeBTN.BackColor = SystemColors.InfoText;
                OrderBTN.BackColor = SystemColors.InfoText;
                DashboardBTN.BackColor = SystemColors.InfoText;
                AccountBTN.BackColor = SystemColors.InfoText;
                ReservationBTN.BackColor = SystemColors.InfoText;
            }
        }
        public void checkAccLevel() 
        {
            if (job.ToLower().Equals("server"))
            {
                DashboardBTN.Enabled = false;
                DashboardBTN.Visible = false;
                ProductBTN.Enabled = false;
                ProductBTN.Visible = false;
                AccountBTN.Enabled = false;
                AccountBTN.Visible = false;

            }
            else if (job.ToLower().Equals("admin"))
            {

            }
            else if (job.ToLower().Equals("cook"))
            {

                DashboardBTN.Enabled = false;
                DashboardBTN.Visible = false;
                AccountBTN.Enabled = false;
                AccountBTN.Visible = false;

            }
            else
            {
                var result = MessageBox.Show("How did you get here with incorrect details? " + Environment.NewLine
                    + " Application Restarting... ", "Warning!", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    Application.Restart();

                }
                else
                {
                    Application.Restart();
                }


            }
        }
        public void resetBTNfocus() 
        {
            AboutBTN.BackColor = SystemColors.InfoText;
            HomeBTN.BackColor = SystemColors.InfoText;
            ProductBTN.BackColor = SystemColors.InfoText;
            DashboardBTN.BackColor = SystemColors.InfoText;
            AccountBTN.BackColor = SystemColors.InfoText;
            OrderBTN.BackColor = SystemColors.InfoText;
            ReservationBTN.BackColor = SystemColors.InfoText;
        }
        private void newMainForm_Load(object sender, EventArgs e)
        {

            Login.Account account = new Login.Account();
            label1.Text = Login.Account.Username;
            job = Login.Account.Job;
            label1.Text = Login.Account.Username;
            HomeBTN.BackgroundImageLayout = ImageLayout.Zoom;
            checkAccLevel();
            


            HomeBTN.FlatStyle = FlatStyle.Flat;
            HomeBTN.FlatAppearance.BorderSize = 0;
            OrderBTN.FlatStyle = FlatStyle.Flat;
            OrderBTN.FlatAppearance.BorderSize = 0;
            ProductBTN.FlatStyle = FlatStyle.Flat;
            ProductBTN.FlatAppearance.BorderSize = 0;
            DashboardBTN.FlatStyle = FlatStyle.Flat;
            DashboardBTN.FlatAppearance.BorderSize = 0;
            AccountBTN.FlatStyle = FlatStyle.Flat;
            AccountBTN.FlatAppearance.BorderSize = 0; 
            AboutBTN.FlatStyle = FlatStyle.Flat;
            AboutBTN.FlatAppearance.BorderSize = 0;
            ReservationBTN.FlatStyle = FlatStyle.Flat;
            ReservationBTN.FlatAppearance.BorderSize = 0;
        }
       

        private void button6_Click(object sender, EventArgs e)
        {
            AboutBTN.Focus();
            panel2.Controls.Clear();
           
           
            if (AboutBTN.Focused == true) 
            {
              /*  button14.BringToFront();
                button14.BackColor = Color.Blue;
                button8.BackColor = Color.Black; button10.BackColor = Color.Black;
                button11.BackColor = Color.Black; button12.BackColor = Color.Black;
                button13.BackColor = Color.Black; button9.BackColor = Color.Black;
              */
                AboutBTN.BackColor = Color.Silver;
                AboutForm ww = new AboutForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
                ww.FormBorderStyle = FormBorderStyle.None;
                ww.Focus();
                panel2.Controls.Add(ww);
                panel2.Refresh();
                ww.Show();
                OrderBTN.BackColor = SystemColors.InfoText;
                HomeBTN.BackColor = SystemColors.InfoText;
                ProductBTN.BackColor = SystemColors.InfoText;
                DashboardBTN.BackColor = SystemColors.InfoText;
                AccountBTN.BackColor = SystemColors.InfoText;
                ReservationBTN.BackColor = SystemColors.InfoText;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            panel2.Controls.Clear();
            OrderBTN.Focus();
            if (OrderBTN.Focused == true)
            {
              /*  button11.BringToFront();
                button11.BackColor = Color.Blue;
                button8.BackColor = Color.Black; button9.BackColor = Color.Black;
                button10.BackColor = Color.Black; button12.BackColor = Color.Black;
                button13.BackColor = Color.Black; button14.BackColor = Color.Black;
              */

                OrderBTN.BackColor = Color.Silver;
                OrdersOptions ww = new OrdersOptions() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                ww.FormBorderStyle = FormBorderStyle.None;
                panel2.Controls.Add(ww);
                panel2.Refresh();
                ww.Show();
                AboutBTN.BackColor = SystemColors.InfoText;
                HomeBTN.BackColor = SystemColors.InfoText;
                ProductBTN.BackColor = SystemColors.InfoText;
                DashboardBTN.BackColor = SystemColors.InfoText;
                AccountBTN.BackColor = SystemColors.InfoText;
                ReservationBTN.BackColor = SystemColors.InfoText;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            ReservationBTN.Focus();
            if (ReservationBTN.Focused == true)
            {
                /*
                button9.BringToFront();
                button9.BackColor = Color.Blue;
                button8.BackColor = Color.Black; button10.BackColor = Color.Black;
                button11.BackColor = Color.Black; button12.BackColor = Color.Black;
                button13.BackColor = Color.Black; button14.BackColor = Color.Black;
               */
                ReservationBTN.BackColor = Color.Silver;
                TableForm ww = new TableForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                ww.FormBorderStyle = FormBorderStyle.None;
                panel2.Controls.Add(ww);
                panel2.Refresh();
                ww.Show();
                AboutBTN.BackColor = SystemColors.InfoText;
                HomeBTN.BackColor = SystemColors.InfoText;
                ProductBTN.BackColor = SystemColors.InfoText;
                DashboardBTN.BackColor = SystemColors.InfoText;
                AccountBTN.BackColor = SystemColors.InfoText;
                OrderBTN.BackColor = SystemColors.InfoText;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            AccountBTN.Focus();
            if (AccountBTN.Focused == true)
            {
              /*  button13.BringToFront();
                button13.BackColor = Color.Blue;
                button8.BackColor = Color.Black; button10.BackColor = Color.Black;
                button11.BackColor = Color.Black; button12.BackColor = Color.Black;
                button9.BackColor = Color.Black; button14.BackColor = Color.Black;
              */
                AccountBTN.BackColor = Color.Silver;
                AccountsForm ww = new AccountsForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                ww.FormBorderStyle = FormBorderStyle.None;
                panel2.Controls.Add(ww);
                panel2.Refresh();
                ww.Show();
                AboutBTN.BackColor = SystemColors.InfoText;
                HomeBTN.BackColor = SystemColors.InfoText;
                ProductBTN.BackColor = SystemColors.InfoText;
                OrderBTN.BackColor = SystemColors.InfoText;
                DashboardBTN.BackColor = SystemColors.InfoText;
                ReservationBTN.BackColor = SystemColors.InfoText;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            DashboardBTN.Focus();
            if (DashboardBTN.Focused == true)
            {
             /*   button10.BringToFront();
                button10.BackColor = Color.Blue;
                button8.BackColor = Color.Black; button9.BackColor = Color.Black;
                button11.BackColor = Color.Black; button12.BackColor = Color.Black;
                button13.BackColor = Color.Black; button14.BackColor = Color.Black;
             */

                DashboardBTN.BackColor = Color.Silver;
                SalesDashboard ww = new SalesDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                ww.FormBorderStyle = FormBorderStyle.None;
                panel2.Controls.Add(ww);
                panel2.Refresh();
                ww.Show();
                AboutBTN.BackColor = SystemColors.InfoText;
                HomeBTN.BackColor = SystemColors.InfoText;
                ProductBTN.BackColor = SystemColors.InfoText;
                OrderBTN.BackColor = SystemColors.InfoText;
                AccountBTN.BackColor = SystemColors.InfoText;
                ReservationBTN.BackColor = SystemColors.InfoText;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            HomeBTN.Focus();
            if (HomeBTN.Focused == true)
            {
              /*  button8.BackColor = Color.Blue;
                button9.BackColor = Color.Black; button10.BackColor = Color.Black;
                button11.BackColor = Color.Black; button12.BackColor = Color.Black;
                button13.BackColor = Color.Black; button14.BackColor = Color.Black;
                button8.BringToFront();
              */
                HomeBTN.BackColor = Color.Silver;
                HomeForm ww = new HomeForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                ww.FormBorderStyle = FormBorderStyle.None;
                panel2.Controls.Add(ww);
                panel2.Refresh();
                ww.Show();
                AboutBTN.BackColor = SystemColors.InfoText;
                DashboardBTN.BackColor = SystemColors.InfoText;
                ProductBTN.BackColor = SystemColors.InfoText;
                OrderBTN.BackColor = SystemColors.InfoText;
                AccountBTN.BackColor = SystemColors.InfoText;
                ReservationBTN.BackColor = SystemColors.InfoText;
            }
        }

        private void newMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
