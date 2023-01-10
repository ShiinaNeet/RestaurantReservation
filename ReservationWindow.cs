using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Ocsp;
using Org.BouncyCastle.Utilities.Collections;
using RestaurantReservation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;


namespace RestaurantReservation
{
    public partial class ReservationWindow : Form
    {   static ComboBox combobox1 = new ComboBox();
        
        string ResDate;
        string ClientName;
        string ResTime;
        string resdatefull;
        static int tablenumber;
        int dc;
        Int64 clientid;
        Int64 IDcounter;
        Int64 reservationid = 0;
        string resv;
        string ResDate2;
        string resdatefull2;
        string clientname2;
        Int64 clientid1;
        Int64 resrvationid1;
        string clientname;
        ConnectionClasss cc = new ConnectionClasss();
        public ReservationWindow()
        {
            InitializeComponent();
        }



        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            ResDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            ClientName = ClnNameTxtBox.Text;




        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                cnn.Open();

                SqlCommand cmd2 = new SqlCommand("SELECT ReservationID,ClientID,ResvDate,client,tablenum,diners FROM Reservations", cnn);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd2;
                dt.Clear();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                cnn.Close();
            }
            //   TableForm tf = new TableForm();
            // TableLabel.Text = tf.getTableNum().ToString();
            //  tablenumber = tf.getTableNum();
            

        }
        public static void setTableNum(int ix)
        {
            //TableLabel.Text = ix.ToString();
            tablenumber = ix;
            ReservationWindow.myfresh();
            combobox1.Text = tablenumber.ToString();
        }

        private void ReservationWindow_Load(object sender, EventArgs e)
        {
            timer1.Interval = (50000); // 1 secs
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "hh-mm tt";
            myfresh();


            BackgroundImage = Resources.texture_background_1404_991;
            BackgroundImageLayout = ImageLayout.None;
            combobox1.Location = new Point(214, 466);
            combobox1.Show();
            combobox1.Visible = true;
            combobox1.Size= new System.Drawing.Size(79, 28);
            this.Controls.Add(combobox1);
            combobox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});

        }

        public static void myfresh() 
        {
           // TableLabel.Text = tablenumber.ToString();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean result;
            string ResTime1223 = dateTimePicker1.Value.ToString("HH:mm:ss");
            string ResDate1223 = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            string result1;
            DateTime timetime = Convert.ToDateTime(ResDate1223 + " " + ResTime1223);
            string timetime1q = ResDate1223 + " " + ResTime1223;
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                using (SqlCommand command = new SqlCommand("declare @timetime datetime;\r\nset @timetime =  cast(@timertime as datetime);\r\nSELECT CASE WHEN EXISTS(SELECT * from Reservations where ResvDate  BETWEEN @timertime AND DATEADD(HOUR,2,@timertime) AND tablenum = @tablenum) THEN 'TRUE' ELSE 'FALSE' end", cnn))
                {
                    command.Parameters.AddWithValue("@timertime",timetime1q);
                    command.Parameters.AddWithValue("@tablenum", TableLabel.Text);
                    cnn.Open();

                    //result = Convert.ToBoolean(command.ExecuteScalar());
                    result1 = command.ExecuteScalar().ToString();
                    cnn.Close();
                }

            }
            
           
            
            if (ClnNameTxtBox.Text.ToString() == "") {
                MessageBox.Show("Please Enter client name", "Client Name Not Found", MessageBoxButtons.OK); ClnNameTxtBox.Select();
            }
            else {
                try
                {
                    if (result1.Equals("TRUE"))
                    {
                        MessageBox.Show("Chosen Date is Reserved!");
                    }
                    else
                    {
                        using (SqlConnection cnn = ConnectionClasss.connnect())
                        {
                            using (SqlCommand command = new SqlCommand("SELECT MAX(ClientID) from Reservations", cnn))
                            {
                                cnn.Open();

                                clientid1 = Convert.ToInt64(command.ExecuteScalar());

                                cnn.Close();
                            }
                            using (SqlCommand command = new SqlCommand("SELECT MAX(ReservationID) from Reservations", cnn))
                            {
                                cnn.Open();

                                resrvationid1 = Convert.ToInt64(command.ExecuteScalar());

                                cnn.Close();
                            }

                        }
                        ResTime = dateTimePicker1.Value.ToString("HH:mm:ss");
                        ResDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                        resdatefull = ResDate + " " + ResTime;
                        ClientName = ClnNameTxtBox.Text;
                        clientid = clientid1 + 1;
                        reservationid = resrvationid1 + 1;
                        using (SqlConnection cnn = ConnectionClasss.connnect())
                        {

                            using (SqlCommand command1 = new SqlCommand("INSERT INTO Reservations(ReservationID,ClientID,ResvDate,client,tablenum,diners) VALUES ('" + reservationid + "','" + clientid + "','" + resdatefull + "','" + ClientName + "','" + tablenumber + " ','" + DinersCount.SelectedItem + "')", cnn))
                            {



                                cnn.Open();
                                command1.ExecuteNonQuery();

                                cnn.Close();
                            }

                        }

                        using (SqlConnection cnn2 = ConnectionClasss.connnect())
                        {
                            cnn2.Open();

                            SqlCommand cmd2 = new SqlCommand("SELECT * FROM Reservations", cnn2);
                            SqlDataAdapter da = new SqlDataAdapter();
                            DataTable dt = new DataTable();
                            da.SelectCommand = cmd2;
                            dt.Clear();
                            da.Fill(dt);

                            dataGridView1.DataSource = dt;
                            cnn2.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    using (SqlConnection cnn2 = ConnectionClasss.connnect())
                    {
                        cnn2.Open();

                        SqlCommand cmd2 = new SqlCommand("SELECT ReservationID,ClientID,ResvDate,client,tablenum,diners FROM Reservations", cnn2);
                        SqlDataAdapter da = new SqlDataAdapter();
                        DataTable dt = new DataTable();
                        da.SelectCommand = cmd2;
                        dt.Clear();
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                        cnn2.Close();
                    }

                }

                
            }
        }

        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                cnn.Open();

                SqlCommand cmd2 = new SqlCommand("SELECT ReservationID,ClientID,ResvDate,client,tablenum,diners FROM Reservations", cnn);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd2;
                dt.Clear();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                cnn.Close();
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string date2;
            try
            {
                date2 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                IList<string> datename = new List<string>(date2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                dateTimePicker1.Value = Convert.ToDateTime(datename[1]);
                monthCalendar1.SetDate(Convert.ToDateTime(datename[0]));

                ClnNameTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                
                TableLabel.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                DinersCount.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                ResTime = dateTimePicker1.Value.ToString("HH:mm:ss");
                ResDate2 = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
              
                resdatefull2 = ResDate2 + " " + ResTime;
                clientname2 = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }
        private void TableBtn_Click(object sender, EventArgs e)
        {
             TableForm tableform = new TableForm();
             tableform.ShowDialog();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //    
            try
            {
                using (SqlConnection cnn = ConnectionClasss.connnect())
                {
                    string ResTime2 = dateTimePicker1.Value.ToString("HH:mm:ss");
                    string ResDate3444 = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                    string resdateful43434 = ResDate3444 + " " + ResTime2;
                    
                    //ResvDate,client,tablenum,diners,clientid
                    using (SqlCommand command1 = new SqlCommand("UPDATE Reservations set Resvdate =' " + resdateful43434 + "',client ='" + ClnNameTxtBox.Text + "', tablenum = '" + TableLabel.Text + " ', Diners ='" + DinersCount.Text + "'where client = '"+ClnNameTxtBox.Text+"'", cnn))
                    {

                        cnn.Open();
                        command1.ExecuteNonQuery();

                        cnn.Close();

                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Equals(""))
            {
                
                MessageBox.Show("No Selection");
            }
            else
            {

                try
                {

                    string reservationid = dataGridView1.SelectedCells[0].Value.ToString();
                    using (SqlConnection cnn = ConnectionClasss.connnect())
                    {
                        //ResvDate,client,tablenum,diners
                        using (SqlCommand command1 = new SqlCommand("DELETE Reservations where ReservationID = @ReservationID", cnn))
                        {
                            command1.Parameters.Add("@ReservationID", SqlDbType.VarChar).Value = reservationid;
                            cnn.Open();
                            command1.ExecuteNonQuery();

                            cnn.Close();

                        }
                    }
                    using (SqlConnection cnn = ConnectionClasss.connnect())
                    {
                        cnn.Open();

                        SqlCommand cmd2 = new SqlCommand("SELECT ReservationID,ClientID,ResvDate,client,tablenum,diners FROM Reservations", cnn);
                        SqlDataAdapter da = new SqlDataAdapter();
                        DataTable dt = new DataTable();
                        da.SelectCommand = cmd2;
                        dt.Clear();
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                        cnn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.FormClosed += new FormClosedEventHandler(ReservationWindow_FormClosed);
        }

        private void ReservationWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void searchTextBox_Click(object sender, EventArgs e)
        {
            searchTextBox.Focus();
            searchTextBox.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime ww;
            //w = Convert.ToDateTime(searchTextBox.Text);
            
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                cnn.Open();

                SqlCommand cmd2 = new SqlCommand("SELECT ReservationID,ClientID,ResvDate,client,tablenum,diners FROM Reservations " +
                    "where client LIKE '%"+searchTextBox.Text+ "%' or ClientID LIKE '%"+searchTextBox.Text+"%' " +
                    "or  ReservationID LIKE '%"+searchTextBox.Text+"%'", cnn);

                cmd2.Parameters.AddWithValue("@clientID", searchTextBox.Text);
                cmd2.Parameters.AddWithValue("@ResvID", searchTextBox.Text);
                cmd2.Parameters.AddWithValue("@clientname", searchTextBox.Text);
                    
                
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd2;
                dt.Clear();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                cnn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
