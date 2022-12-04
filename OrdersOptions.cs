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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            vieworder.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableOrder.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnclick = 3;
            this.Close();
            this.FormClosed += new FormClosedEventHandler(OrdersOptions_FormClosed);
           
        }

        private void OrdersOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (btnclick == 3)
            {
                MainForm1.loadform(new MainMenuWindow());
                MainForm1.MyrefeshMethod();
            }
        }
    }
}
