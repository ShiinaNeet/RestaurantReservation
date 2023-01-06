using MySql.Data.MySqlClient;
using MySqlConnector;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Ocsp;
using RestaurantReservation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        static int tablenum;
        string[] images1 = Directory.GetFiles(@"C:\Users\dayan\source\repos\New Restaurant Reservation\Mode 1\", "*.png");
        string[] images2 = Directory.GetFiles(@"C:\Users\dayan\source\repos\New Restaurant Reservation\Mode 2\", "*.jpg");
        string[] imagesname = Directory.GetFiles(@"C:\Users\dayan\source\repos\New Restaurant Reservation\Mode 1\", "*.png");
        string[] itemInside = new string[50];
        PictureBox[] pictureBox = new PictureBox[50];
        PictureBox[] pictureBox2 = new PictureBox[50];
        Image[] ImagesPanel = new Image[50];
        Image[] ImagesPanel1 = new Image[50];
        HashSet<string> myhashitemsinside = new HashSet<string>();
        Image curpic1;
        Image curpic2;
        int orderid =0;
        public CreateOrderForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            curMode = 0;

            flowLayoutPanel2.Controls.Clear();

            lblDate.Text = DateTime.Now.ToString();
            string[] images = Directory.GetFiles(@"C:\Users\dayan\source\repos\New Restaurant Reservation\Mode 1\", "*.png");
            PictureBox[] pictureBox = new PictureBox[50];
            for (int i = 0; i < images1.Count(); i++)
            {
                pictureBox[i] = new PictureBox();
                pictureBox[i].Name = "pictureBox" + i;
                pictureBox[i].Size = new Size(155, 98);

                Image image = Image.FromFile(images1[i]);
                pictureBox[i].Image = image;
                pictureBox[i].SizeMode = PictureBoxSizeMode.Zoom;

                flowLayoutPanel2.Controls.Add(pictureBox[i]);
                flowLayoutPanel2.WrapContents = true;
                if (i == 0)
                {
                    pictureBox[i].Click += new EventHandler(pictureBox1_Click);
                    ImagesPanel[i] = pictureBox[i].Image;
                    curMode = 0;
                    curpic1 = ImagesPanel[0];
                }
                else if (i == 1)
                {
                    pictureBox[i].Click += new EventHandler(pictureBox2_Click);
                    ImagesPanel[i] = pictureBox[i].Image;
                    curMode = 0;
                    curpic2 = ImagesPanel1[1];
                }
                else if (i == 2)
                {
                    pictureBox[i].Click += new EventHandler(pictureBox3_Click);
                    ImagesPanel[i] = pictureBox[i].Image;
                    curMode = 0;
                    
                }
                else if (i == 3)
                {
                    pictureBox[i].Click += new EventHandler(pictureBox4_Click);
                    ImagesPanel[i] = pictureBox[i].Image;
                    curMode = 0;

                }
                else if (i == 4)
                {
                    pictureBox[i].Click += new EventHandler(pictureBox5_Click);
                    ImagesPanel[i] = pictureBox[i].Image;
                    curMode = 0;

                }
                else if (i == 5)
                {
                    pictureBox[i].Click += new EventHandler(pictureBox6_Click);
                    ImagesPanel[i] = pictureBox[i].Image;
                    curMode = 0;

                }
            }
        }

        private void CreateOrderForm_Load(object sender, EventArgs e)
        {

            BackgroundImage = Resources.texture_background_1404_991;
            BackgroundImageLayout = ImageLayout.None;

            cbModePayment.Items.Add("Cash");
            cbModePayment.Items.Add("Debit Card");
            cbModePayment.Items.Add("Gcash");



            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Order List", 130);
            listView1.Columns.Add("Quantity", 70);
            listView1.Columns.Add("Price", 50);

            lblDate.Text = DateTime.Now.ToString();
            flowLayoutPanel2.Controls.Clear();


            curMode = 0;

            flowLayoutPanel2.Controls.Clear();

            lblDate.Text = DateTime.Now.ToString();
            string[] images = Directory.GetFiles(@"C:\Users\dayan\source\repos\New Restaurant Reservation\Mode 1\", "*.png");

            PictureBox[] pictureBox = new PictureBox[50];
            for (int i = 0; i < images1.Count(); i++)
            {
                pictureBox[i] = new PictureBox();
               pictureBox[i].Name = "pictureBox" + i;
                pictureBox[i].Size = new Size(155, 98);
             //   pictureBox[i].Name= images[i];
                Image image = Image.FromFile(images1[i]);
                pictureBox[i].Image = image;
                pictureBox[i].SizeMode = PictureBoxSizeMode.Zoom;

                flowLayoutPanel2.Controls.Add(pictureBox[i]);
                flowLayoutPanel2.WrapContents = true;
                if (i == 0)
                {
                    pictureBox[i].Click += new EventHandler(pictureBox1_Click);
                    ImagesPanel[i] = pictureBox[i].Image;
                        
                    curMode = 0;
                    curpic1 = ImagesPanel[0];
                }
                else if (i == 1)
                {
                    pictureBox[i].Click += new EventHandler(pictureBox2_Click);
                    ImagesPanel[i] = pictureBox[i].Image;
                    curMode = 0;
                    curpic2 = ImagesPanel1[1];
                }
                else if (i == 2) 
                {
                    pictureBox[i].Click += new EventHandler(pictureBox3_Click);
                    ImagesPanel[i] = pictureBox[i].Image;
                    curMode = 0;
                    //   curpic2 = ImagesPanel1[1];
                }
                else if (i == 3)
                {
                    pictureBox[i].Click += new EventHandler(pictureBox4_Click);
                    ImagesPanel[i] = pictureBox[i].Image;
                    curMode = 0;
                    curpic2 = ImagesPanel1[1];
                }
                else if (i == 4)
                {
                    pictureBox[i].Click += new EventHandler(pictureBox5_Click);
                    ImagesPanel[i] = pictureBox[i].Image;
                    curMode = 0;
                    curpic2 = ImagesPanel1[1];
                }
                else if (i == 5)
                {
                    pictureBox[i].Click += new EventHandler(pictureBox6_Click);
                    ImagesPanel[i] = pictureBox[i].Image;
                    curMode = 0;
                    curpic2 = ImagesPanel1[1];
                }




            }
            timer1.Interval = (100); // 1 secs
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            
            

        }

        private void timer1_Tick(object? sender, EventArgs e)
        {
            int sum = 0;
            TableNumLabel.Text = tablenum.ToString();

            foreach (ListViewItem itemv in listView1.Items) 
            { 
                sum += Convert.ToInt32(itemv.SubItems[2].Text);
            }
            textBox3.Text = sum.ToString();

            listView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            curMode = 1;
            Image image1 = Resources.coke;
            //  pictureBox1.Image = image1;
            // pictureBox2.Image = imgCoffee;
            flowLayoutPanel2.Controls.Clear();

            lblDate.Text = DateTime.Now.ToString();
            images2 = Directory.GetFiles(@"C:\Users\dayan\source\repos\New Restaurant Reservation\Mode 2\", "*.jpg");

            for (int i = 0; i < images2.Count(); i++)
            {
                pictureBox2[i] = new PictureBox();
                pictureBox2[i].Name = "pictureBox" + i;
                pictureBox2[i].Size = new Size(155, 98);

                Image image = Image.FromFile(images2[i]);
                pictureBox2[i].Image = image;
                pictureBox2[i].SizeMode = PictureBoxSizeMode.Zoom;

                flowLayoutPanel2.Controls.Add(pictureBox2[i]);
                flowLayoutPanel2.WrapContents = true;
                if (i == 0)
                {
                    pictureBox2[i].Click += new EventHandler(pictureBox1_Click);
                    ImagesPanel1[i] = pictureBox2[i].Image;
                    curMode = 1;
                }
                else if (i == 1)
                {
                    pictureBox2[i].Click += new EventHandler(pictureBox2_Click);
                    ImagesPanel1[i] = pictureBox2[i].Image;
                    curMode = 1;
                }
                else if (i == 2)
                {
                    pictureBox2[i].Click += new EventHandler(pictureBox3_Click);
                    ImagesPanel1[i] = pictureBox2[i].Image;
                    curMode = 1;

                }
                else if (i == 3)
                {
                    pictureBox2[i].Click += new EventHandler(pictureBox4_Click);
                    ImagesPanel1[i] = pictureBox2[i].Image;
                    curMode = 1;

                }
                else if (i == 4)
                {
                    pictureBox2[i].Click += new EventHandler(pictureBox5_Click);
                    ImagesPanel1[i] = pictureBox2[i].Image;
                    curMode = 1;

                }
                else if (i == 5)
                {
                    pictureBox2[i].Click += new EventHandler(pictureBox6_Click);
                    ImagesPanel1[i] = pictureBox2[i].Image;
                    curMode = 1;

                }
                else if (i == 6)
                {
                    pictureBox2[i].Click += new EventHandler(pictureBox7_Click);
                    ImagesPanel1[i] = pictureBox2[i].Image;
                    curMode = 1;

                }

            }
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string[] selectedrow = new string[3];

            // Image curpic1 = imgBurger;
            int picbox3 = 1;
            int BurgerPrice = 40;
            int CokePrice = 19;
            Boolean isInsideLV = false;

            foreach (ListViewItem itemv in listView1.Items)
            {
                int price = Convert.ToInt32(itemv.SubItems[2].Text);
                string itemInside = itemv.Text.ToString().ToLower();
                if (curMode == 0)
                {
                    curpic1 = ImagesPanel[0];

                    if (itemv.Text.ToString().Equals(""))
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

                    curpic2 = ImagesPanel1[2];
                    if (itemv.Text.Equals("Wine"))
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

            if (curpic1 == ImagesPanel[0])
            {
                if (isInsideLV == true)
                {
                    AddItems(selectedrow[0], Convert.ToInt32(selectedrow[1]), Convert.ToInt32(selectedrow[2]));

                }
                else
                {
                    if (curMode == 0)
                    {
                        AddItems("", 1, 40);
                    }
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
                    AddItems("Wine", 1, 19);

                }

            }
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string[] selectedrow = new string[3];

            // Image curpic1 = imgBurger;
            int picbox3 = 1;
            int BurgerPrice = 40;
            int CokePrice = 19;
            Boolean isInsideLV = false;

            foreach (ListViewItem itemv in listView1.Items)
            {
                int price = Convert.ToInt32(itemv.SubItems[2].Text);
                string itemInside = itemv.Text.ToString().ToLower();
                if (curMode == 0)
                {
                    curpic1 = ImagesPanel[0];

                    if (itemv.Text.ToString().Equals("Mushroom Burger"))
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

                    curpic2 = ImagesPanel1[2];
                    if (itemv.Text.Equals("Lemon Tea"))
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

            if (curpic1 == ImagesPanel[0])
            {
                if (isInsideLV == true)
                {
                    AddItems(selectedrow[0], Convert.ToInt32(selectedrow[1]), Convert.ToInt32(selectedrow[2]));

                }
                else
                {
                    if (curMode == 0)
                    {
                        AddItems("Mushroom Burger", 1, 40);
                    }
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
                    AddItems("Lemon Tea", 1, 19);

                }

            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string[] selectedrow = new string[3];

            // Image curpic1 = imgBurger;
            int picbox3 = 1;
            int BurgerPrice = 40;
            int CokePrice = 19;
            Boolean isInsideLV = false;

            foreach (ListViewItem itemv in listView1.Items)
            {
                int price = Convert.ToInt32(itemv.SubItems[2].Text);
                string itemInside = itemv.Text.ToString().ToLower();
                if (curMode == 0)
                {
                    curpic1 = ImagesPanel[0];

                    if (itemv.Text.ToString().Equals("Grand Tower Supreme Burger"))
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

                    curpic2 = ImagesPanel1[2];
                    if (itemv.Text.Equals("Iced Matcha Latte"))
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

            if (curpic1 == ImagesPanel[0])
            {
                if (isInsideLV == true)
                {
                    AddItems(selectedrow[0], Convert.ToInt32(selectedrow[1]), Convert.ToInt32(selectedrow[2]));

                }
                else
                {
                    if (curMode == 0)
                    {
                        AddItems("Grand Tower Supreme Burger", 1, 40);
                    }
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
                    AddItems("Iced Matcha Latte", 1, 19);

                }

            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string[] selectedrow = new string[3];

            // Image curpic1 = imgBurger;
            int picbox3 = 1;
            int BurgerPrice = 40;
            int CokePrice = 19;
            Boolean isInsideLV = false;

            foreach (ListViewItem itemv in listView1.Items)
            {
                string itemInside = itemv.Text.ToString().ToLower();
                if (curMode == 0)
                {
                    curpic1 = ImagesPanel[0];

                    if (itemv.Text.ToString().Equals("Burger Field"))
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
                   
                    curpic2 = ImagesPanel1[2];
                    if (itemv.Text.Equals("Classic Coffee"))
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

            if (curpic1 == ImagesPanel[0])
            {
                if (isInsideLV == true)
                {
                    AddItems(selectedrow[0], Convert.ToInt32(selectedrow[1]), Convert.ToInt32(selectedrow[2]));

                }
                else
                {
                    if (curMode == 0)
                    {
                        AddItems("Burger Field", 1, 40);
                    }
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
                     AddItems("Classic Coffee", 1, 19);   
                    
                }

            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string[] selectedrow = new string[3];

            // Image curpic1 = imgBurger;
            int picbox3 = 1;
            int BurgerPrice = 40;
            int CokePrice = 19;
            Boolean isInsideLV = false;

            foreach (ListViewItem itemv in listView1.Items)
            {
                string itemInside = itemv.Text.ToString().ToLower();
                if (curMode == 0)
                {
                    curpic1 = ImagesPanel[0];

                    if (itemv.Text.ToString().Equals("Chilli Burger"))
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

                    curpic2 = ImagesPanel1[2];
                    if (itemv.Text.Equals("Frappe"))
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

            if (curpic1 == ImagesPanel[0])
            {
                if (isInsideLV == true)
                {
                    AddItems(selectedrow[0], Convert.ToInt32(selectedrow[1]), Convert.ToInt32(selectedrow[2]));

                }
                else
                {
                    if (curMode == 0)
                    {
                        AddItems("Chilli Burger", 1, 40);
                    }
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
                    AddItems("Frappe", 1, 19);

                }

            }
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
            
           // Image curpic1 = imgBurger;
           
            int BurgerPrice = 30;
            int CokePrice = 19;
            Boolean isInsideLV=false;
            foreach (ListViewItem itemv in listView1.Items) 
            {
                int price = Convert.ToInt32(itemv.SubItems[2].Text);
                if (curMode == 0)
                {
                    curpic1 = ImagesPanel[0];
                    string[] imagesName = Directory.GetFiles(@"C:\Users\dayan\source\repos\New Restaurant Reservation\Mode 1\", "*.png");


                    if (itemv.Text.ToString().Equals("Burger Whooper"))
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
                    curpic1 = ImagesPanel1[1];
                    if (itemv.Text.ToLower().Equals("beer"))
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
                myhashitemsinside.Add(itemv.Text.ToString());
            }
            
            if (curpic1 == ImagesPanel[0])
            {
                if (isInsideLV == true)
                {
                    AddItems(selectedrow[0], Convert.ToInt32(selectedrow[1]), Convert.ToInt32(selectedrow[2]));
                    
                }
                else
                {
                    AddItems("Burger Whooper", 1, 30);
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
                    AddItems("Beer", 1, 19);
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
          
           

            string[] selectedrow = new string[3];
           
            int cheesyburger = 45;
            int Fberrysmothe = 20;
            Boolean isInsideLV = false;
            foreach (ListViewItem itemv in listView1.Items)
            {
                int price = Convert.ToInt32(itemv.SubItems[2].Text);

                if (curMode == 0) 
                {
                    
                    curpic2 = ImagesPanel[1];
                    
                        
                        if (itemv.Text.ToString().Equals("Burger Cheesy Monster"))
                        {
                            double updQty = Convert.ToDouble(itemv.SubItems[1].Text) + 1;
                            double updPrice = Convert.ToDouble(itemv.SubItems[2].Text) + cheesyburger;
                            string[] ww = { itemv.SubItems[0].Text, updQty.ToString(), updPrice.ToString() };
                            selectedrow = ww;
                            itemv.Remove();

                            isInsideLV = true;
                        Console.WriteLine("Hegeferqweqw");
                            break;
                        }
                    
                }
                if (curMode == 1)
                {
                    curpic2 = ImagesPanel1[1];
                    if (itemv.Text.Equals("Berry Smoothies"))
                    {
                        double updQty = Convert.ToDouble(itemv.SubItems[1].Text) + 1;
                        double updPrice = Convert.ToDouble(itemv.SubItems[2].Text) + Fberrysmothe;
                        string[] ww = { itemv.SubItems[0].Text, updQty.ToString(), updPrice.ToString() };
                        selectedrow = ww;
                        itemv.Remove();

                        isInsideLV = true;
                        break;
                    }
                }
            }

            if (curpic2 == ImagesPanel[1])
            {
                if (isInsideLV == true)
                {
                    AddItems(selectedrow[0], Convert.ToInt32(selectedrow[1]), Convert.ToInt32(selectedrow[2]));
                }
                else
                {
                    AddItems("Burger Cheesy Monster", 1, 45);
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
                    AddItems("Berry Smoothies", 1, 20);
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
            MainForm1.loadform(new MainMenuWindow());
            MainForm1.MyrefeshMethod();
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
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Theres no item to remove","Warning: No Items to remove", MessageBoxButtons.OK);
            }
            else
            {
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            int productid;
            int ordernum;
            string orderdate= DateTime.Today.ToString();
            int orderqty=0;
            

            

            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Please place an item before making an order!", "No Items found to order!", MessageBoxButtons.OK);
            }
            else
            {
                try
                {

                    using (SqlConnection cnn = ConnectionClasss.connnect())
                    {
                        using (SqlCommand command = new SqlCommand("SELECT MAX(OrderID) from Orders", cnn))
                        {
                            cnn.Open();

                            orderid = Convert.ToInt32(command.ExecuteScalar());
                            
                            cnn.Close();
                        }
                        
                        using (SqlCommand command = new SqlCommand("SELECT MAX(Order_Number) from Orders", cnn))
                        {
                            cnn.Open();

                            ordernum = Convert.ToInt32(command.ExecuteScalar());
                           
                            cnn.Close();
                        }


                    }
                    foreach (ListViewItem items in listView1.Items)
                    {
                        string itemname = items.SubItems[0].Text;
                        int price = Convert.ToInt32(items.SubItems[2].Text);
                        using (SqlConnection cnn = ConnectionClasss.connnect()) 
                        {
                            using (SqlCommand command = new SqlCommand("SELECT ProductsID from ProductsTbl where ProductName = @Productnumber", cnn))
                            {
                                
                                cnn.Open();
                                command.Parameters.AddWithValue("Productnumber", itemname);
                                productid = Convert.ToInt32(command.ExecuteScalar());
                               
                                cnn.Close();
                            }

                           
                        }

                        using (SqlConnection cnn = ConnectionClasss.connnect())
                        {
                            int order_number = ordernum + 1;
                            using (SqlCommand command1 = new SqlCommand("insert into Orders(OrderID,ProductsID,DateOrder,Quantity,Order_Number,tablenum,Price) " +
                                "\r\nVALUES(@OrderIDsss,@ProductsID,@GETDATE,@Quantity,@Order_Number,@tablenum,@Price)", cnn))
                            {
                                command1.Parameters.AddWithValue("OrderIDsss", orderid + 1);
                                command1.Parameters.AddWithValue("ProductsID", productid);
                                command1.Parameters.AddWithValue("@GETDATE", DateTime.Today);
                                command1.Parameters.AddWithValue("Quantity", Convert.ToInt32(items.SubItems[1].Text));
                                command1.Parameters.AddWithValue("Order_Number", order_number.ToString());
                                command1.Parameters.AddWithValue("tablenum", tablenum);
                                command1.Parameters.AddWithValue("@Price", price);

                                cnn.Open();
                                command1.ExecuteNonQuery();

                                cnn.Close();
                            }

                        }
                    }

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                   

                }
            }


            //check if order status
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                using (SqlCommand command = new SqlCommand("SELECT\r\n    CASE WHEN EXISTS \r\n    (\r\n        SELECT * FROM Orders WHERE OrderID = @OrderID\r\n    )\r\n    THEN 'TRUE'\r\n    ELSE 'FALSE'\r\nEND", cnn))
                {
                    command.Parameters.AddWithValue("@OrderID", orderid+1);
                    cnn.Open();

                    var result = Convert.ToBoolean(command.ExecuteScalar());
                    if (result == true) 
                    {
                        MessageBox.Show("Order Successful!", "Order Status!",MessageBoxButtons.OK);

                        if (MessageBox.Show("Do you want to print receipt?", "Print Order?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            printPreviewDialog1.Document = printDocument1;

                            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("papersizen", 380, 600);
                            printPreviewDialog1.ShowDialog();
                        }


                        listView1.Clear();
                        this.Close();
                        MainForm1.loadform(new MainMenuWindow());
                        //MainForm1.MyrefeshMethod();

                        
                        
                    }
                    else{
                        MessageBox.Show("Order Failed!", "Order Status!", MessageBoxButtons.OK);
                    }
                    cnn.Close();
                }

            }
            //dispay order status
            


        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items) 
            {
                Console.WriteLine(item.SubItems[0].Text);
                Console.WriteLine(item.SubItems[1].Text);
                Console.WriteLine(item.SubItems[2].Text);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("papersizen", 380, 600);
            printPreviewDialog1.ShowDialog();
        }
        public static void setTableNum(int ix)
        {
            
            tablenum = ix;

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Graphics grafic = e.Graphics;
            Font font = new Font("Courer New", 12);
            float fontHeight = font.GetHeight();
            int StartX = 10;
            int StartY = 10;
            int offSet = 40;

            grafic.DrawString("     King's Grill Restaurant Reservation", new Font("Courer New", 14), new SolidBrush(Color.Black), StartX, StartY);
            grafic.DrawString(" ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 5);

            grafic.DrawString("\t\t===============================", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 20);

            grafic.DrawString("Order ID", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + 40);
            grafic.DrawString("\t\t" + orderid.ToString().PadRight(30), new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + 40);

            grafic.DrawString("\t\t\tDay: " + lblDate.Text, new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + 40);


            grafic.DrawString("Table #: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
            grafic.DrawString("\t\t" + tablenum.ToString().PadRight(30), new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
            

            string Liners = "====================================================";
            grafic.DrawString(Liners, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));


            grafic.DrawString("Item Name ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));
            grafic.DrawString("\t\t\t  Qty", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));
            //grafic.DrawString("\t\t\t\tUnit", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));
             grafic.DrawString("\t\t\t\t\tAmount ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));


            grafic.DrawString("===================================================", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 120));


            int j = listView1.Items.Count;
            for (int i = 0; i <= j - 1; i++)
            {

                string strTotalQty, proPrice, proName;
                proName = listView1.Items[i].SubItems[0].Text;
                strTotalQty = Convert.ToInt32(listView1.Items[i].SubItems[1].Text).ToString();
                proPrice = Convert.ToInt32(listView1.Items[i].SubItems[2].Text).ToString();
                if (proName.Length > 6)
                {
                    proName = proName.Substring(0, 6);
                }
                //  string productLine = proName + "\t\t" + strTotalQty + "\t" + proPrice.PadRight(5); //+ proPrice;
                string productLine = proName.PadLeft(10) + "\t\t"+  strTotalQty.PadRight(30) + proPrice.PadRight(10); //+ proPrice;
               

                grafic.DrawString(productLine, font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 140));
                offSet += (int)fontHeight + 5;

            }


        }

        private void tablelablblbl1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
