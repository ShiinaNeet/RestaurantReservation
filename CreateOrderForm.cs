using MySql.Data.MySqlClient;
using MySqlConnector;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Ocsp;
using RestaurantReservation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Documents;
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
      
        string[] itemInside = new string[50];
        PictureBox[] pictureBox = new PictureBox[50];
        PictureBox[] pictureBox2 = new PictureBox[50];
        Image[] ImagesPanel = new Image[50];
        Image[] ImagesPanel1 = new Image[50];
        HashSet<string> myhashitemsinside = new HashSet<string>();
        Image curpic1;
        Image curpic2;
        int orderid = 0;
        int payment;
        public CreateOrderForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            displayfood();
           
            
        }
        public void displaydrinks()
        {
            int counter = 0;
            List<Button> buttonlist = new List<Button>();
            List<String> productlst = new List<string>();
            List<Image> imagelist = new List<Image>();
            List<int> pricelist = new List<int>();
            buttonlist.Add(button9); buttonlist.Add(button10); buttonlist.Add(button11); buttonlist.Add(button12); buttonlist.Add(button13);
            buttonlist.Add(button14); buttonlist.Add(button15); buttonlist.Add(button16); buttonlist.Add(button17); buttonlist.Add(button18);
            buttonlist.Add(button19); buttonlist.Add(button20);
            foreach (Button button in buttonlist)
            {
                button.Visible = false;
            }
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                using (SqlCommand command = new SqlCommand("SELECT Picture,Productname,Price from ProductsTbl where Type = 2", cnn))
                {
                    cnn.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        imagelist.Add(byteArrayToImage((byte[])reader["Picture"]));
                        productlst.Add(reader.GetString(1));
                        pricelist.Add(reader.GetInt32(2));
                        counter++;
                    }

                    cnn.Close();
                }
            }

            int ix = 0;
            for (int i = 0; i >= imagelist.Count; i++)
            {
                buttonlist[i].BackgroundImage = imagelist[i];
                buttonlist[i].BackgroundImageLayout = ImageLayout.Zoom;
                buttonlist[i].Name = productlst[i].ToString();
                buttonlist[i].Text = pricelist[i].ToString();
                buttonlist[i].Visible = true;
                buttonlist[i].Refresh();
                buttonlist[i].BringToFront();
            }
            foreach (Button btn in buttonlist)
            {
                ix++;
                if (ix == imagelist.Count)
                {
                    break;
                }
                btn.BackgroundImage = imagelist[ix];
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.Name = productlst[ix].ToString();
                btn.Text = pricelist[ix].ToString();
                btn.Visible = true;
                btn.Refresh();

            }
        }
        public Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }

        public void displayfood()
        {
            int counter = 0;
            List<Button> buttonlist = new List<Button>();
            List<String> productlst = new List<string>();
            List<Image> imagelist = new List<Image>();
            List<int> pricelist = new List<int>();
            buttonlist.Add(button9); buttonlist.Add(button10); buttonlist.Add(button11); buttonlist.Add(button12); buttonlist.Add(button13);
            buttonlist.Add(button14); buttonlist.Add(button15); buttonlist.Add(button16); buttonlist.Add(button17); buttonlist.Add(button18);
            buttonlist.Add(button19); buttonlist.Add(button20);
            foreach (Button button in buttonlist)
            {
                button.Visible = false;
            }
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                using (SqlCommand command = new SqlCommand("SELECT Picture,Productname,Price from ProductsTbl where Type = 1", cnn))
                {
                    cnn.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        imagelist.Add(byteArrayToImage((byte[])reader["Picture"]));
                        productlst.Add(reader.GetString(1));
                        pricelist.Add(reader.GetInt32(2));
                        counter++;
                    }

                    cnn.Close();
                }
            }

            int ix = 0;
            for (int i = 0; i >= imagelist.Count; i++)
            {
                buttonlist[i].BackgroundImage = imagelist[i];
                buttonlist[i].BackgroundImageLayout = ImageLayout.Zoom;
                buttonlist[i].Name = productlst[i].ToString();
                buttonlist[i].Text = pricelist[i].ToString();
                buttonlist[i].Visible = true;
                buttonlist[i].Refresh();
                buttonlist[i].BringToFront();
            }
            foreach (Button btn in buttonlist)
            {
               ix++;
                if (ix == imagelist.Count) 
                { 
                    break;
                }
                btn.BackgroundImage = imagelist[ix];
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.Name = productlst[ix].ToString();
                btn.Text = pricelist[ix].ToString();
                btn.Visible = true;
                btn.Refresh();

            }
        }
            private void CreateOrderForm_Load(object sender, EventArgs e)
        {

            displayfood();

            BackgroundImage = Resources.texture_background_1404_991;
            BackgroundImageLayout = ImageLayout.None;

            



            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Order List", 130);
            listView1.Columns.Add("Quantity", 70);
            listView1.Columns.Add("Price", 50);

            lblDate.Text = DateTime.Now.ToString();
          



            
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
            
            displaydrinks();
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
        
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void Timer1_tick(object sender, EventArgs e)
        {
            listView1.Update();
        }

      
           

        
        public void AddItems(string itemname, int quantity, int price)
        {
            string[] row = { itemname, quantity.ToString(), price.ToString() };
            ListViewItem itemss = new ListViewItem(row);

            listView1.Items.Add(itemss);
        Timer timer = new Timer();
        timer.Interval = 1000;
        timer.Tick += new System.EventHandler(Timer1_tick);

        }

        private void button8_Click(object sender, EventArgs e)
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
                MessageBox.Show("Theres no item to remove", "Warning: No Items to remove", MessageBoxButtons.OK);
            }
            else
            {
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            }
        }
        public Boolean isPaid() 
        {
            return false;
           
        }
        public void showForm() 
        {
            this.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {

            int productid;
            int ordernum;
            string orderdate = DateTime.Today.ToString();
            int orderqty = 0;




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
                            using (SqlCommand command1 = new SqlCommand("insert into Orders(OrderID,ProductsID,DateOrder,Quantity,Order_Number,tablenum,Price,Paid) " +
                                "\r\nVALUES(@OrderIDsss,@ProductsID,@GETDATE,@Quantity,@Order_Number,@tablenum,@Price,@Paid)", cnn))
                            {
                                command1.Parameters.AddWithValue("OrderIDsss", orderid + 1);
                                command1.Parameters.AddWithValue("ProductsID", productid);
                                command1.Parameters.AddWithValue("@GETDATE", DateTime.Today);
                                command1.Parameters.AddWithValue("Quantity", Convert.ToInt32(items.SubItems[1].Text));
                                command1.Parameters.AddWithValue("Order_Number", order_number.ToString());
                                command1.Parameters.AddWithValue("tablenum", tablenum);
                                command1.Parameters.AddWithValue("@Price", price);
                                command1.Parameters.AddWithValue("@Paid", 0);

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
                    command.Parameters.AddWithValue("@OrderID", orderid + 1);
                    cnn.Open();
                     int UpdatedOrderID = orderid + 1;
                    var result = Convert.ToBoolean(command.ExecuteScalar());
                    if (result == true)
                    {
                        MessageBox.Show("Order Successful!"+ System.Environment.NewLine+" Order ID: " +UpdatedOrderID, "Order Status!", MessageBoxButtons.OK);

                        if (MessageBox.Show("Do you want to print receipt?", "Print Order?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            printPreviewDialog1.Document = printDocument1;

                            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("papersizen", 380, 600);
                            printPreviewDialog1.ShowDialog();
                        }


                        listView1.Clear();
                        listView1.Refresh();
                        listView1.View = View.Details;
                        listView1.FullRowSelect = true;
                        listView1.Columns.Add("Order List", 130);
                        listView1.Columns.Add("Quantity", 70);
                        listView1.Columns.Add("Price", 50);

                       



                    }
                    else
                    {
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
           newMainForm wz = new newMainForm();
            PaymentForm rs = new PaymentForm() { Dock = DockStyle.Fill, TopLevel = true, TopMost = true };
            rs.ShowDialog();
           // this.Hide();
           

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
            grafic.DrawString("\t\t\t Server: "+Login.Account.Username, new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));

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

                string str = proName;
                string complete = "";
                str.Split(' ').ToList().ForEach(iw => complete += iw[0]+"");

                //  string productLine = proName + "\t\t" + strTotalQty + "\t" + proPrice.PadRight(5); //+ proPrice;
                string productLine = complete.PadLeft(10) + "\t\t" + strTotalQty.PadRight(30) + proPrice.PadRight(10); //+ proPrice;


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
        public void CheckAndADD(string btnName,string btnText) 
        {

            string[] selectedrow = new string[3];
            Boolean isInsideLV = false;
            foreach (ListViewItem itemv in listView1.Items)
            {
                int price = Convert.ToInt32(itemv.SubItems[2].Text);


                if (itemv.Text.ToString().Equals(btnName))
                {
                    double updQty = Convert.ToDouble(itemv.SubItems[1].Text) + 1;
                    double updPrice = Convert.ToDouble(itemv.SubItems[2].Text) + Convert.ToInt32(btnText);
                    string[] ww = { itemv.SubItems[0].Text, updQty.ToString(), updPrice.ToString() };
                    selectedrow = ww;
                    itemv.Remove();

                    isInsideLV = true;
                    break;
                }
            }

            if (isInsideLV == true)
            {
                AddItems(selectedrow[0], Convert.ToInt32(selectedrow[1]), Convert.ToInt32(selectedrow[2]));
            }
            else
            {
                AddItems(btnName, 1, Convert.ToInt32(btnText));
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string btnName = button9.Name;
            string btnText = button9.Text;
            CheckAndADD(btnName,btnText);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string btnName = button10.Name;
            string btnText = button10.Text;
            CheckAndADD(btnName, btnText);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string btnName = button11.Name;
            string btnText = button11.Text;
            CheckAndADD(btnName, btnText);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string btnName = button12.Name;
            string btnText = button12.Text;
            CheckAndADD(btnName, btnText);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string btnName = button13.Name;
            string btnText = button13.Text;
            CheckAndADD(btnName, btnText);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string btnName = button14.Name;
            string btnText = button14.Text;
            CheckAndADD(btnName, btnText);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string btnName = button15.Name;
            string btnText = button15.Text;
            CheckAndADD(btnName, btnText);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string btnName = button16.Name;
            string btnText = button16.Text;
            CheckAndADD(btnName, btnText);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string btnName = button17.Name;
            string btnText = button17.Text;
            CheckAndADD(btnName, btnText);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string btnName = button18.Name;
            string btnText = button18.Text;
            CheckAndADD(btnName, btnText);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string btnName = button19.Name;
            string btnText = button19.Text;
            CheckAndADD(btnName, btnText);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string btnName = button20.Name;
            string btnText = button20.Text;
            CheckAndADD(btnName, btnText);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
