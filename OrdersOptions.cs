using RestaurantReservation.Properties;
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
    public partial class OrdersOptions : Form
    {
        ViewOrders vieworder = new ViewOrders();
        CreateOrderForm createOrderForm = new CreateOrderForm();
        TableOrder TableOrder = new TableOrder();
        int btnclick;
        public OrdersOptions()
        {
            InitializeComponent();
        }

        private void OrdersOptions_Load(object sender, EventArgs e)
        {
            BackgroundImage = Resources.texture_background_1404_991;
            BackgroundImageLayout = ImageLayout.None;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vieworder.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //   MainForm1.loadform(new TableOrder());
            TableOrder to = new TableOrder()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(to);
            to.Show();
            this.Close();
            // MainForm1.MyrefeshMethod();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            newMainForm wz = new newMainForm();
            HomeForm rs = new HomeForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            wz.resetBTNfocus();
            rs.Show();
            ww.resetBTNfocus();
            this.Close();

        }

        private void OrdersOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (btnclick == 3)
            {
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActiveOrdersForm ww = new ActiveOrdersForm();
            ww.ShowDialog();
        }
    }
}
