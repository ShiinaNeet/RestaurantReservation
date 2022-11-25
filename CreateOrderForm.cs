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
    public partial class CreateOrderForm : Form
    {
        public CreateOrderForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void CreateOrderForm_Load(object sender, EventArgs e)
        {
            cbModePayment.Items.Add("Cash");
            cbModePayment.Items.Add("Debit Card");
            cbModePayment.Items.Add("Gcash");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image image1 = Resources.coke;
            pictureBox1.Image = image1;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
