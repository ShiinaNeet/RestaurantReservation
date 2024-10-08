﻿using MySqlX.XDevAPI;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantReservation
{
    public partial class ProductOptionsForm : Form
    {
        string ProductName;
        string ProductDescription;
        int ProductID;
        int productid;
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
            pictureBox1.Visible = false;
            cbProductType.Visible = false;
            txtBoxPrice.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox3.Visible = false;
            button5.Visible = false;
            deletebtn.Visible = true;
            reloadbtn.Visible = true;
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
            label5.Visible = true;
            label6.Visible = true;
            cbProductType.Visible = true;
            txtBoxPrice.Visible = true;
            pictureBox1.Visible=true;
            label5.Visible=true;
            button5.Visible=true;
            pictureBox1.Visible = true;
            textBox3.Visible=true;
            deletebtn.Visible = false;
            reloadbtn.Visible = false;

        }
        Image ConvertBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {

                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }

        }
        public void AddProduct()
        {
            ProductName = textBox1.Text;
            ProductDescription = textBox2.Text;
            int prodType = 0;
            
            if (cbProductType.Text.Equals("Drinks"))
            {
                prodType = 2;
            }
            else if(cbProductType.Text.Equals("Foods")){ prodType = 1; }
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
                        using (SqlCommand command = new SqlCommand("SELECT MAX(ProductsID) from ProductsTbl", cnn))
                        {
                            cnn.Open();

                            ProductID = Convert.ToInt32(command.ExecuteScalar());

                            cnn.Close();
                        }
 
                    }
                    using (SqlConnection cnn = ConnectionClasss.connnect())
                    {

                        using (SqlCommand command1 = 
                        new SqlCommand("Insert into ProductsTbl(ProductsID,[Productname],[ProductDetails],Price,Type,Picture) Values(@ProductID,@ProductName,@ProductDetails,@Price,@Type,@Picture)", cnn))
                        {
                            command1.Parameters.AddWithValue("@ProductID",ProductID+1);
                            command1.Parameters.AddWithValue("@ProductName",ProductName);
                            command1.Parameters.AddWithValue("@ProductDetails", ProductDescription);
                            command1.Parameters.AddWithValue("@Price", txtBoxPrice.Text);
                            command1.Parameters.AddWithValue("@Type", prodType);
                            command1.Parameters.AddWithValue("@Picture",ConvertImageToBinary(pictureBox1.Image));

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
            if ( textBox1.Equals("") || textBox2.Equals("") ||
                txtBoxPrice.Equals("") || cbProductType.SelectedItem.Equals(""))
            {
                MessageBox.Show("Please fill all blank fields");
            }
            else
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
                else
                {
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
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                else
                {
                    productid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                   string fileName = ofd.FileName;
                    textBox3.Text = fileName;
                    pictureBox1.Image = Image.FromFile(fileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cnn = ConnectionClasss.connnect())
                {
                    using (SqlCommand command1 = new SqlCommand("delete from ProductsTbl where ProductsID = @productid ", cnn))
                    {

                        command1.Parameters.AddWithValue("@productid", productid);

                        cnn.Open();
                        command1.ExecuteNonQuery();

                        cnn.Close();
                    }
                    using (SqlCommand command1 = new SqlCommand("SELECT  case when EXISTs(SELECT * from " +
                       "ProductsTbl where ProductsID = @prodid) THEN 'true' ELSE 'false' end", cnn))
                    {

                        command1.Parameters.AddWithValue("@prodid", productid);


                        cnn.Open();
                        var result = command1.ExecuteScalar();
                        if (result == DBNull.Value)
                        {
                            MessageBox.Show("Not Found!");

                        }
                        else if (result.Equals(true))
                        {
                            MessageBox.Show("Failed to Delete");
                        }
                        if (Convert.ToString(result).Equals("false"))
                        {
                            MessageBox.Show("Successfully Deleted Product:" + productid, "Deleted Successfully!");
                        }
                        cnn.Close();
                    }
                    View_Table();

                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void reloadbtn_Click(object sender, EventArgs e)
        {
            View_Table();
        }
    }
}
