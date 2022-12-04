using MySqlX.XDevAPI;
using Org.BouncyCastle.Ocsp;
using RestaurantReservation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        string[] images2 = Directory.GetFiles(@"C:\Users\dayan\source\repos\New Restaurant Reservation\Mode 2\", "*.png");
        PictureBox[] pictureBox = new PictureBox[50];
        PictureBox[] pictureBox2= new PictureBox[50];
        Image[] ImagesPanel = new Image[50];
        Image[] ImagesPanel1 = new Image[50];

        Image curpic1;
        Image curpic2;
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
            }
        }

        private void CreateOrderForm_Load(object sender, EventArgs e)
        {
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


            }
            timer1.Interval = (100); // 1 secs
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void timer1_Tick(object? sender, EventArgs e)
        {
            TableNumLabel.Text = tablenum.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            curMode = 1;
            Image image1 = Resources.coke;
            //  pictureBox1.Image = image1;
            // pictureBox2.Image = imgCoffee;
            flowLayoutPanel2.Controls.Clear();

            lblDate.Text = DateTime.Now.ToString();
            images2 = Directory.GetFiles(@"C:\Users\dayan\source\repos\New Restaurant Reservation\Mode 2\", "*.png");
           
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
                else if (i == 1) {
                    pictureBox2[i].Click += new EventHandler(pictureBox2_Click);
                    ImagesPanel1[i] = pictureBox2[i].Image;
                    curMode = 1;
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

            int BurgerPrice = 29;
            int CokePrice = 19;
            Boolean isInsideLV=false;
            foreach (ListViewItem itemv in listView1.Items) 
            {
                if (curMode == 0)
                {
                    curpic1 = ImagesPanel[0];


                    if (itemv.Text.ToLower().Equals("burger"))
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
                    if (itemv.Text.ToLower().Equals("coffee"))
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
                    AddItems("Coffee", 1, 19);
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
            int i = 0;
            int CoffeePrice = 29;
            int FriesPRice = 20;
            Boolean isInsideLV = false;
            foreach (ListViewItem itemv in listView1.Items)
            {
                if (curMode == 0) 
                {
                    curpic2 = ImagesPanel[1];
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
                    curpic2 = ImagesPanel1[1];
                    if (itemv.Text.Equals("Coke"))
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

            if (curpic2 == ImagesPanel[1])
            {
                if (isInsideLV == true)
                {
                    AddItems(selectedrow[0], Convert.ToInt32(selectedrow[1]), Convert.ToInt32(selectedrow[2]));
                }
                else
                {
                    AddItems("French Fries", 1, 45);
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
                    AddItems("Coke", 1, 20);
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
            int orderid;
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
                            using (SqlCommand command1 = new SqlCommand("insert into Orders(OrderID,ProductsID,DateOrder,Quantity,Order_Number,tablenum) " +
                                "\r\nVALUES(@OrderIDsss,@ProductsID,@GETDATE,@Quantity,@Order_Number,@tablenum)", cnn))
                            {
                                command1.Parameters.AddWithValue("OrderIDsss", orderid + 1);
                                command1.Parameters.AddWithValue("ProductsID", productid);
                                command1.Parameters.AddWithValue("@GETDATE", DateTime.Today);
                                command1.Parameters.AddWithValue("Quantity", Convert.ToInt32(items.SubItems[1].Text));
                                command1.Parameters.AddWithValue("Order_Number", order_number.ToString());
                                command1.Parameters.AddWithValue("tablenum", tablenum);

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

        }
        public static void setTableNum(int ix)
        {
            
            tablenum = ix;

        }
    }
}
