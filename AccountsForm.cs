using Google.Protobuf.WellKnownTypes;
using Microsoft.Data.SqlClient;
using MySqlX.XDevAPI;
using RestaurantReservation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using SqlCommand = System.Data.SqlClient.SqlCommand;
using SqlConnection = System.Data.SqlClient.SqlConnection;
using SqlDataAdapter = System.Data.SqlClient.SqlDataAdapter;
using SqlException = System.Data.SqlClient.SqlException;

namespace RestaurantReservation
{
    public partial class AccountsForm : Form
    {
        string username;
        string position;
        string password;
        int usercount;
        Image profileimage;
        byte[] profiledata;
        public AccountsForm()
        {
            InitializeComponent();
        }

        private void AccountsForm_Load(object sender, EventArgs e)
        {
            reloadDGV();
            pictureBox1.Image = Resources.profile;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
           
        }
        public void reloadDGV() 
        {
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                cnn.Open();

                SqlCommand cmd2 = new SqlCommand("SELECT UserName,Position,Password,Picture FROM AccountUsers", cnn);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd2;
                dt.Clear();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                cnn.Close();
            }
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
                    username = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    position = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    password = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();


                    pictureBox1.Image = ConvertBinaryToImage((byte[])dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                    profiledata = (byte[])dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                    textBox1.Text = username;
                    textBox2.Text = password;
                    comboBox1.Text = position;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("Username Here.....") || textBox1.Text.Equals("")
                || textBox2.Text.Equals("Password here") || textBox2.Text.Equals("")|| pictureBox1.Image == null)
            {
                MessageBox.Show("Please fill each field!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string deletedaccname = textBox1.Text;
                try
                {
                    using (SqlConnection cnn = ConnectionClasss.connnect())
                    {
                        using (SqlCommand command = new SqlCommand("SELECT count(UserID) from AccountUsers", cnn))
                        {
                            cnn.Open();

                            var useridcount = command.ExecuteScalar();
                            if (useridcount == DBNull.Value)
                            {
                                usercount = 0;
                            }
                            else
                            {
                                usercount = Convert.ToInt32(useridcount);
                            }
                            cnn.Close();
                        }
                        Image copy = pictureBox1.Image;
                        using (SqlCommand command1 = new SqlCommand("INSERT INTO AccountUsers(UserID,Username,Password,Position,Picture)" +
                            " values(@useridcount,@username,@password,@position,@picture)", cnn))
                        {
                            command1.Parameters.AddWithValue("@useridcount", usercount + 1);
                            command1.Parameters.AddWithValue("@username", textBox1.Text);
                            command1.Parameters.AddWithValue("@password", textBox2.Text);
                            command1.Parameters.AddWithValue("@position", comboBox1.Text.ToString());
                            command1.Parameters.AddWithValue("@picture", ConvertImageToBinary(pictureBox1.Image));

                            cnn.Open();
                            command1.ExecuteNonQuery();
                            reloadDGV();
                            cnn.Close();
                        }

                        using (SqlCommand command1 = new SqlCommand("SELECT  case when EXISTs(SELECT * from " +
                            "AccountUsers where UserName = @username) THEN 'true' ELSE 'false' end", cnn))
                        {

                            command1.Parameters.AddWithValue("@username", deletedaccname);


                            cnn.Open();
                            var result = command1.ExecuteScalar();
                            //Boolean result = (Boolean)result1;
                            if (result == DBNull.Value)
                            {
                                MessageBox.Show("Not Found!");

                            }
                            else if (result.ToString().Equals("true"))
                            {


                                toolStripStatusLabel2.Visible = true;
                                statusStrip1.Visible = true;
                                statusStrip1.BackColor = Color.Green;
                                statusStrip1.Text = "ADDED SUCCESSFUL!";
                                statusStrip1.ForeColor = Color.White;
                                toolStripStatusLabel2.Text = "ADD SUCCESSFUL!";
                                toolStripStatusLabel2.BackColor = Color.Green;
                                toolStripStatusLabel2.ForeColor = Color.White;

                            }
                            else
                            {
                                toolStripStatusLabel2.Visible = true;
                                statusStrip1.Visible = true;
                                statusStrip1.BackColor = Color.OrangeRed;
                                statusStrip1.Text = "FAILED TO ADD";
                                statusStrip1.ForeColor = Color.White;
                                toolStripStatusLabel2.Text = "FAILED TO ADD";
                                toolStripStatusLabel2.BackColor = Color.OrangeRed;
                                toolStripStatusLabel2.ForeColor = Color.White;

                            }
                            timer1.Interval = (3000); // 1 secs
                            timer1.Tick += new EventHandler(timer1_Tick);
                            timer1.Start();
                            reloadDGV();
                            cnn.Close();
                        }

                    }
                }
                catch (SqlException exe)
                {

                    MessageBox.Show(exe.Message);
                }
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image ww = pictureBox1.Image;

            if (textBox1.Text.Equals("Username Here.....") || textBox1.Text.Equals("")
                || textBox2.Text.Equals("Password here") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("Please Select Account to Delete!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    using (SqlConnection cnn = ConnectionClasss.connnect())
                    {
                        using (SqlCommand command1 = new SqlCommand("delete from AccountUsers where UserName = @username AND Password = @password and position = @position and Picture = @picture", cnn))
                        {

                            command1.Parameters.AddWithValue("@username", textBox1.Text);
                            command1.Parameters.AddWithValue("@password", textBox2.Text);
                            command1.Parameters.AddWithValue("@position", comboBox1.Text.ToString());
                            command1.Parameters.AddWithValue("@picture", profiledata);

                            cnn.Open();
                            command1.ExecuteNonQuery();
                            reloadDGV();
                            cnn.Close();
                        }
                        using (SqlCommand command1 = new SqlCommand("SELECT  case when EXISTs(SELECT * from " +
                           "AccountUsers where UserName = @username) THEN 'true' ELSE 'false' end", cnn))
                        {

                            command1.Parameters.AddWithValue("@username", textBox1.Text);


                            cnn.Open();
                            var result = command1.ExecuteScalar();
                            if (result == DBNull.Value)
                            {
                                MessageBox.Show("Not Found!");

                            }
                            else if (result.Equals(true))
                            {


                                toolStripStatusLabel2.Visible = true;
                                statusStrip1.Visible = true;
                                statusStrip1.BackColor = Color.Green;
                                statusStrip1.Text = "DELETED SUCCESSFUL!";
                                statusStrip1.ForeColor = Color.White;
                                toolStripStatusLabel2.Text = "DELETED SUCCESSFULLY!";
                                toolStripStatusLabel2.BackColor = Color.Green;
                                toolStripStatusLabel2.ForeColor = Color.White;

                            }
                            else
                            {
                                toolStripStatusLabel2.Visible = true;
                                statusStrip1.Visible = true;
                                statusStrip1.BackColor = Color.OrangeRed;
                                statusStrip1.Text = "DELETED SUCCESSFUL!";
                                statusStrip1.ForeColor = Color.White;
                                toolStripStatusLabel2.Text = "DELETED SUCCESSFULLY!";
                                toolStripStatusLabel2.BackColor = Color.OrangeRed;
                                toolStripStatusLabel2.ForeColor = Color.White;

                            }
                            timer1.Interval = (3000); // 1 secs
                            timer1.Tick += new EventHandler(timer1_Tick);
                            timer1.Start();
                            reloadDGV();
                            cnn.Close();
                        }
                    }

                    textBox1.Clear();
                    textBox2.Clear();
                    comboBox1.ResetText();
                }
                catch (SqlException exe)
                {
                    MessageBox.Show(exe.Message+1);
                }
            }
        }

        private void timer1_Tick(object? sender, EventArgs e)
        {
            statusStrip1.Visible = false;
            statusStrip1.BackColor = SystemColors.Control;
            statusStrip1.Text = "";
            toolStripStatusLabel2.Visible = false;
            toolStripStatusLabel2.Text = "DELETED SUCCESSFULLY!";
            toolStripStatusLabel2.BackColor = SystemColors.Control;
            toolStripStatusLabel2.ForeColor = Color.White;
        }

        private void uploadbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fileName = ofd.FileName;
                    textBox3.Text = fileName;
                    pictureBox1.Image = Image.FromFile(fileName);
                    pictureBox1.BackColor = Color.White;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            reloadDGV();
        }
    }
}
