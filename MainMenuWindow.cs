using MySqlX.XDevAPI.Relational;
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
    public partial class MainMenuWindow : Form
    {
        ReservationWindow resw = new ReservationWindow();
        TableForm tablef = new TableForm();
        CreateOrderForm orders = new CreateOrderForm();
        ViewOrders vieworder = new ViewOrders();
        OrdersOptions ordersoptions = new OrdersOptions();
        ProductOptionsForm productoptionform = new ProductOptionsForm();
        int btnclick;

        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnclick = 1;
            this.Close();
            this.FormClosed += new FormClosedEventHandler(MainMenuWindow_FormClosed);
           
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            btnclick = 2;
            this.Close();
            this.FormClosed += new FormClosedEventHandler(MainMenuWindow_FormClosed);
            this.Show();
            this.Hide();
        }

        private void MainMenuWindow_Load(object sender, EventArgs e)
        {
            BackgroundImage = Resources.texture_background_1404_991;
            BackgroundImageLayout = ImageLayout.None;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnclick = 3;
            this.Close();
            this.FormClosed += new FormClosedEventHandler(MainMenuWindow_FormClosed);
        }

        private void MainMenuWindow_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (btnclick == 1)
            {
                MainForm1.loadform(new TableForm());
                MainForm1.MyrefeshMethod();
            }
            else if(btnclick == 2)
            {
                MainForm1.loadform(new OrdersOptions());
                MainForm1.MyrefeshMethod();
            }
            else
            {
                MainForm1.loadform(new ProductOptionsForm());
                MainForm1.MyrefeshMethod();
            }

        }

        private void MainMenuWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }
    }
}
