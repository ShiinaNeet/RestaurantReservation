using RestaurantReservation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace RestaurantReservation
{
    public partial class CreateOrderForm : Form
    {
        Image imgBurger = Resources.burger;
        Image imgFries = Resources.fried_potatoes;
        Image imgCoffee = Resources.coffee_cup;
        public CreateOrderForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            pictureBox1.Image = imgBurger;
            pictureBox2.Image = imgFries;
        }

        private void CreateOrderForm_Load(object sender, EventArgs e)
        {
            cbModePayment.Items.Add("Cash");
            cbModePayment.Items.Add("Debit Card");
            cbModePayment.Items.Add("Gcash");
          
            pictureBox1.Image=imgBurger;
            pictureBox2.Image=imgFries;

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Order List",130);
            listView1.Columns.Add("Quantity", 70);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image image1 = Resources.coke;
            pictureBox1.Image = image1;
            pictureBox2.Image = imgCoffee;
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Image curpic1 = pictureBox1.Image;
           
            if (curpic1 == imgBurger)
            {
               
                listView1.Items.Add("Burger");
                Console.WriteLine("Added burger");
               
            }
            else {
                
                listView1.Items.Add("Coke");
                Console.WriteLine("Coke");
 

            }
            
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new System.EventHandler(Timer1_tick);
            timer.Start();
            

           
        }

        private void Timer1_tick(object sender, EventArgs e)
        {
            listView1.Update();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Image curpic2 = pictureBox2.Image;


            if (curpic2 == imgCoffee)
            {
               
                listView1.Items.Add("Coffee");
                Console.WriteLine("coffee");

            }
            else
            {
                
                listView1.Items.Add("French Fries");
                Console.WriteLine("French Fries");

            }
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new System.EventHandler(Timer1_tick);
            timer.Start();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
