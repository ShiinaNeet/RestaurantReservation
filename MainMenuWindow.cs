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
    public partial class MainMenuWindow : Form
    {
        ReservationWindow resw = new ReservationWindow();
        TableForm tablef = new TableForm();
        CreateOrderForm orders = new CreateOrderForm();
        ViewOrders vieworder = new ViewOrders();
        OrdersOptions ordersoptions = new OrdersOptions();

        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablef.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           ordersoptions.ShowDialog();
            
        }
    }
}
