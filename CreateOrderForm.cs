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
        int curMode = 0;
        public CreateOrderForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            curMode = 0;
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
            listView1.Columns.Add("Price", 50);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            curMode = 1;
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
            string[] selectedrow = new string[3];
            Image curpic1 = pictureBox1.Image;
            
            int BurgerPrice = 29;
            int CokePrice = 19;
            Boolean isInsideLV=false;
            foreach (ListViewItem itemv in listView1.Items) 
            {
                if (curMode == 0)
                {
                    if (itemv.Text.Equals("Burger"))
                    {
                        double updQty = Convert.ToDouble(itemv.SubItems[1].Text) + 1;
                        double updPrice = Convert.ToDouble(itemv.SubItems[2].Text) + BurgerPrice;
                        string[] ww = { itemv.SubItems[0].Text, updQty.ToString(), updPrice.ToString() };
                        selectedrow = ww;
                        itemv.Remove();

                        isInsideLV = true;
                        break;
                    }
                }
                if (curMode == 1) 
                {
                     if (itemv.Text.Equals("coke"))
                     {
                        double updQty = Convert.ToDouble(itemv.SubItems[1].Text) + 1;
                        double updPrice = Convert.ToDouble(itemv.SubItems[2].Text) + CokePrice;
                        string[] ww = { itemv.SubItems[0].Text, updQty.ToString(), updPrice.ToString() };
                        selectedrow = ww;
                        itemv.Remove();

                        isInsideLV = true;
                        break;
                     }  
                }
            }
            
            if (curpic1 == imgBurger)
            {
                if (isInsideLV == true)
                {
                    AddItems(selectedrow[0], Convert.ToInt32(selectedrow[1]), Convert.ToInt32(selectedrow[2]));
                }
                else
                {
                    AddItems("Burger", 1, 29);
                }
            }
            else
            {
                if (isInsideLV == true)
                {
                    AddItems(selectedrow[0], Convert.ToInt32(selectedrow[1]), Convert.ToInt32(selectedrow[2]));
                }
                else
                {
                    AddItems("coke", 1, 19);
                }
                

            }

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new System.EventHandler(Timer1_tick);
         //   timer.Start();
            
        }

        private void Timer1_tick(object sender, EventArgs e)
        {
            listView1.Update();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Image curpic2 = pictureBox2.Image;
            
            string[] selectedrow = new string[3];
            int i = 0;
            int CoffeePrice = 29;
            int FriesPRice = 20;
            Boolean isInsideLV = false;
            foreach (ListViewItem itemv in listView1.Items)
            {
                if (curMode == 0) 
                {
                    if (itemv.Text.Equals("French Fries"))
                    {
                        double updQty = Convert.ToDouble(itemv.SubItems[1].Text) + 1;
                        double updPrice = Convert.ToDouble(itemv.SubItems[2].Text) + FriesPRice;
                        string[] ww = { itemv.SubItems[0].Text, updQty.ToString(), updPrice.ToString() };
                        selectedrow = ww;
                        itemv.Remove();

                        isInsideLV = true;
                        break;
                    }
                }
                if (curMode == 1)
                {
                    if (itemv.Text.Equals("Coffee"))
                    {
                        double updQty = Convert.ToDouble(itemv.SubItems[1].Text) + 1;
                        double updPrice = Convert.ToDouble(itemv.SubItems[2].Text) + CoffeePrice;
                        string[] ww = { itemv.SubItems[0].Text, updQty.ToString(), updPrice.ToString() };
                        selectedrow = ww;
                        itemv.Remove();

                        isInsideLV = true;
                        break;
                    }
                }
            }

            if (curpic2 == imgCoffee)
            {
                if (isInsideLV == true)
                {
                    AddItems(selectedrow[0], Convert.ToInt32(selectedrow[1]), Convert.ToInt32(selectedrow[2]));
                }
                else
                {
                    AddItems("Coffee", 1, 45);
                }
            }
            else
            {
                if (isInsideLV == true)
                {
                    AddItems(selectedrow[0], Convert.ToInt32(selectedrow[1]), Convert.ToInt32(selectedrow[2]));
                }
                else
                {
                    AddItems("French Fries", 1, 20);
                }

            }
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new System.EventHandler(Timer1_tick);
            //timer.Start();

        }
        public void AddItems(string itemname,int quantity, int price) 
        {
            string[] row = { itemname, quantity.ToString(), price.ToString() };
            ListViewItem itemss = new ListViewItem(row);

            listView1.Items.Add(itemss);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RemoveItem();
        }
        public void RemoveItem() 
        {
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
