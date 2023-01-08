using Microsoft.Data.SqlClient;
using MySqlX.XDevAPI;
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
        public AccountsForm()
        {
            InitializeComponent();
        }

        private void AccountsForm_Load(object sender, EventArgs e)
        {
            reloadDGV();
        }
        public void reloadDGV() 
        {
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                cnn.Open();

                SqlCommand cmd2 = new SqlCommand("SELECT UserName,Position,Password FROM AccountUsers", cnn);
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
            username = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            position = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            password = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            textBox1.Text = username;
            textBox2.Text = password;
            comboBox1.Text = position;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                        else {
                            usercount = Convert.ToInt32(useridcount);
                        }
                        cnn.Close();
                    }
                    using (SqlCommand command1 = new SqlCommand("INSERT INTO AccountUsers(UserID,Username,Password,Position)" +
                        " values(@useridcount,@username,@password,@position)", cnn))
                    {
                        command1.Parameters.AddWithValue("@useridcount", usercount+1);
                        command1.Parameters.AddWithValue("@username", textBox1.Text);
                        command1.Parameters.AddWithValue("@password", textBox2.Text);
                        command1.Parameters.AddWithValue("@position", comboBox1.Text.ToString());

                        cnn.Open();
                        command1.ExecuteNonQuery();
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
            try
            {
                using (SqlConnection cnn = ConnectionClasss.connnect())
                {
                    using (SqlCommand command1 = new SqlCommand("delete from AccountUsers where UserName = @username AND Password = @password and position = @position ", cnn))
                    {
                       
                        command1.Parameters.AddWithValue("@username", textBox1.Text);
                        command1.Parameters.AddWithValue("@password", textBox2.Text);
                        command1.Parameters.AddWithValue("@position", comboBox1.Text.ToString());

                        cnn.Open();
                        command1.ExecuteNonQuery();
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
                MessageBox.Show(exe.Message);
            }
        }
    }
}
