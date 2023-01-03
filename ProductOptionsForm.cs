using MySqlX.XDevAPI;
using RestaurantReservation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantReservation
{
    public partial class ProductOptionsForm : Form
    {
        string ProductName;
        string ProductDescription;
        int ProductID;
        public ProductOptionsForm()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            View_Table();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            button3.Visible = false;
            toolStripStatusLabel2.Visible = false;
        }

        public void View_Table() 
        {
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                cnn.Open();

                SqlCommand cmd2 = new SqlCommand("SELECT * from ProductsTbl", cnn);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd2;
                dt.Clear();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                cnn.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            button3.Visible = true;
            



        }
        public void AddProduct()
        {
            ProductName = textBox1.Text;
            ProductDescription = textBox2.Text;

            if (textBox1.Text.ToString() == "" || textBox2.Text.ToString() == "")
            {
                MessageBox.Show("Please Enter Product Name", "Product Name not Found", MessageBoxButtons.OK); textBox1.Select();textBox2.Select();
            }
            else
            {
                try
                {
                    using (SqlConnection cnn = ConnectionClasss.connnect())
                    {
                        using (SqlCommand command = new SqlCommand("use RestaurantDB; SELECT MAX(ProductsID) from ProductsTbl", cnn))
                        {
                            cnn.Open();

                            ProductID = Convert.ToInt32(command.ExecuteScalar());

                            cnn.Close();
                        }
 
                    }
                    using (SqlConnection cnn = ConnectionClasss.connnect())
                    {

                        using (SqlCommand command1 = 
                        new SqlCommand("Insert into ProductsTbl(ProductsID,[Productname],[ProductDetails]) Values(@ProductID,@ProductName,@ProductDetails)", cnn))
                        {
                            command1.Parameters.AddWithValue("@ProductID",ProductID+1);
                            command1.Parameters.AddWithValue("@ProductName",ProductName);
                            command1.Parameters.AddWithValue("@ProductDetails", ProductDescription);
                            cnn.Open();
                            command1.ExecuteNonQuery();

                            cnn.Close();
                        }

                    }


                }
                catch (Exception eq)
                {
                    MessageBox.Show(eq.Message);
                }
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductOptionsForm_Load(object sender, EventArgs e)
        {
            

            splitContainer1.Panel1.BackgroundImage = Resources.texture_background_1404_991;
            splitContainer1.Panel1.BackgroundImageLayout = ImageLayout.None;
            splitContainer1.Panel2.BackgroundImage = Resources.texture_background_1404_991;
            splitContainer1.Panel2.BackgroundImageLayout = ImageLayout.None;
            BackgroundImage = Resources.texture_background_1404_991;
            BackgroundImageLayout = ImageLayout.Zoom;

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddProduct();
            
            Boolean AddSuccessfully;

            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                using (SqlCommand command = new SqlCommand("SELECT\r\n    CASE WHEN EXISTS \r\n    (\r\n        SELECT * FROM ProductsTbl WHERE ProductsID = @ProductID\r\n    )\r\n    THEN 'TRUE'\r\n    ELSE 'FALSE'\r\nEND", cnn))
                {
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    cnn.Open();

                    var result = Convert.ToBoolean(command.ExecuteScalar());
                    AddSuccessfully = result;
                    cnn.Close();
                }

            }
            textBox1.Clear();
            textBox2.Clear();
            toolStripStatusLabel2.BackColor = Color.Green;
            if (AddSuccessfully == true)
            {
                label4.Visible = true;
                label4.Text = "Product Successfully Added!";
                label4.ForeColor = Color.Green;
                toolStripStatusLabel2.Visible = true;
            }
            else {
                label4.Visible = true;
                label4.Text = "Product add failed";
                label4.BackColor = Color.Red;
                toolStripStatusLabel2.Visible = true;
                toolStripStatusLabel2.BackColor = Color.Red;
            }
            timer1.Interval = (3000); // 1 secs
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

        }

        private void timer1_Tick(object? sender, EventArgs e)
        {
            label4.Visible = false;
            toolStripStatusLabel2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            this.FormClosed += new FormClosedEventHandler(ProductOptionsForm_FormClosed);
        }

        private void ProductOptionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm1.loadform(new MainMenuWindow());
            MainForm1.MyrefeshMethod();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
