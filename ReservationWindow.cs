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
    {   ComboBox combobox1 = new ComboBox();
        int resvid;
        string resevID;
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
        Boolean result;
        Boolean result1;
        ConnectionClasss cc = new ConnectionClasss();
        Boolean updateresult;
        Boolean updateresult1;
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
            
        }

        private void ReservationWindow_Load(object sender, EventArgs e)
        {

            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
           // timer1.Interval = (50000); // 1 secs
           // timer1.Tick += new EventHandler(timer1_Tick);
           // timer1.Start();
            combobox1.Text = tablenumber.ToString();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "hh-mm tt";
            myfresh();
            RefreshDGV();

            BackgroundImage = Resources.texture_background_1404_991;
            BackgroundImageLayout = ImageLayout.None;
            combobox1.Location = new Point(218,408);
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
            combobox1.Visible = false;
            string[] tablenumber22 =new string[50];
            for (int i = 1; i <= 10; i++)
            {
                tablenumber22[i] = i.ToString();
                comboBox2.Items.Add(tablenumber22[i]);
            }
            comboBox2.Text = tablenumber.ToString();

        }

        public static void myfresh() 
        {
           // TableLabel.Text = tablenumber.ToString();
           
        }

        public void reservationchecker() 
        {
            Boolean res;
            string ResTime1223 = dateTimePicker1.Value.ToString("HH:mm tt");
           string  ResDate1223 = monthCalendar1.SelectionRange.Start.ToString("dd/MM/yyyy");
            var fulldate1 = ResDate1223+" "+ResTime1223;
           var fulldate2 = DateTime.ParseExact(fulldate1, "dd/MM/yyyy HH:mm tt",null);
            //string userdate = fulldate.ToString("yyyy-MM-dd HH:mm:ss:tt", CultureInfo.CurrentCulture);
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                using (SqlCommand command = new SqlCommand("select tablenum,ResvDate from Reservations", cnn))
                {
                    
                    cnn.Open();

                   SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) 
                    {
                       
                        int tablen = (int)reader["tablenum"];
                        DateTime date1 = Convert.ToDateTime(reader["ResvDate"].ToString());
                        if (tablen == Convert.ToInt32(comboBox2.Text) && date1 >= fulldate2 && date1.AddHours(2) <= fulldate2)
                        {
                            result = true;
                            res = true;
                            break;
                        }
                        else { result = false;
                            res = false;
                        }
                        //label1.Text = result.ToString();
                        
                    }
                    cnn.Close();
                }
            }

               

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            string ResTime1223 = dateTimePicker1.Value.ToString("HH:mm");
            string ResDate1223 = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
           
           // DateTime timetime = Convert.ToDateTime(ResDate1223 + " " + ResTime1223);
           // string ResDateTime1223 = ResDate1223 + " " + ResTime1223;
            
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                using (SqlCommand command = new SqlCommand(
                    "SELECT CASE WHEN EXISTS(SELECT * from Reservations where " +
                    "tablenum = @tablenum and ResvDate = convert(datetime, @ResvDate, 105) and " +
                    "cast(ResvTime as time) <= @ResvTime and dateadd(hour, 2, cast(ResvTime as time)) >= @ResvTime)" +
                    "THEN 'true' ELSE 'false' end", cnn))
                {
                   
                    command.Parameters.Add("@ResvDate", SqlDbType.Date).Value = ResDate1223;
                    command.Parameters.Add("@ResvTime", SqlDbType.Time).Value = ResTime1223;
                    command.Parameters.AddWithValue("@tablenum", comboBox2.Text);

                    cnn.Open();
                   // label1.Text = ResTime1223;
                    
                    result = Convert.ToBoolean(command.ExecuteScalar());
                   
                    cnn.Close();
                }
                //OR " + "(ResvTime >= @ResvTime AND ResvTime <=  dateadd(hour, 2, cast(@ResvTime as time))) )
                using (SqlCommand command1 = new SqlCommand(
                   "SELECT CASE WHEN EXISTS(SELECT * from Reservations where " +
                   "tablenum = @tablenum and ResvDate = convert(datetime, @ResvDate, 105) and " +
                   "ResvTime >= @ResvTime AND ResvTime <=  dateadd(hour, 2, cast(@ResvTime as time)) )" +
                   "THEN 'true' ELSE 'false' end", cnn))
                {

                    command1.Parameters.Add("@ResvDate", SqlDbType.Date).Value = ResDate1223;
                    command1.Parameters.Add("@ResvTime", SqlDbType.Time).Value = ResTime1223;
                    command1.Parameters.AddWithValue("@tablenum", comboBox2.Text);

                    cnn.Open();
                    //label1.Text = ResTime1223;

                    result1 = Convert.ToBoolean(command1.ExecuteScalar());

                    cnn.Close();
                }



            }
            
           
            
            if (ClnNameTxtBox.Text.ToString() == "") {
                MessageBox.Show("Please Enter client name", "Client Name Not Found", MessageBoxButtons.OK); ClnNameTxtBox.Select();
            }
            else {
                try
                {
                    //reservationchecker();
                    if (result == true || result1 == true)
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
                                var check = command.ExecuteScalar();
                                if (check == DBNull.Value)
                                {
                                    clientid1 = 0;
                                }
                                else
                                {
                                    clientid1 = Convert.ToInt64(command.ExecuteScalar());
                                }

                                cnn.Close();
                            }
                            using (SqlCommand command = new SqlCommand("SELECT MAX(ReservationID) from Reservations", cnn))
                            {
                                cnn.Open();
                                var check = command.ExecuteScalar();
                                if (check == DBNull.Value)
                                {
                                    resrvationid1 = 0;
                                }
                                else 
                                {
                                    resrvationid1 = Convert.ToInt64(command.ExecuteScalar());
                                }
                                cnn.Close();
                            }

                        }
                      //  ResTime = dateTimePicker1.Value.ToString("HH:mm tt");
                      //  ResDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                      //  resdatefull = ResDate + " " + ResTime;
                        ClientName = ClnNameTxtBox.Text;
                        clientid = clientid1 + 1;
                        reservationid = resrvationid1 + 1;
                        using (SqlConnection cnn = ConnectionClasss.connnect())
                        {

                            using (SqlCommand command1 = new SqlCommand("INSERT INTO Reservations(ReservationID,ClientID,ResvDate,ResvTime,client,tablenum,diners) VALUES ('" + reservationid + "','" + clientid + "','" + ResDate1223 + "','" + ResTime1223 + "','" + ClientName + "','" + comboBox2.Text + " ','" + DinersCount.SelectedItem + "')", cnn))
                            {



                                cnn.Open();
                                command1.ExecuteNonQuery();

                                cnn.Close();
                            }

                        }

                       RefreshDGV();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    RefreshDGV();

                }

                
            }
        }


        public void RefreshDGV() 
        {
            try
            {
                using (SqlConnection cnn = ConnectionClasss.connnect())
                {
                    cnn.Open();

                    SqlCommand cmd2 = new SqlCommand("SELECT client as 'Client Name' ,ReservationID as 'Reservation Number',ResvDate as 'Date',format(cast(ResvTime as datetime), 'hh:mm tt') as 'Time',tablenum as 'Table',diners as 'Diner Count' FROM Reservations", cnn);
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    da.SelectCommand = cmd2;
                    dt.Clear();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                    cnn.Close();
                }
            }
            catch (SqlException ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReloadBtn_Click(object sender, EventArgs e)
        {
           
            RefreshDGV();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string date2;
            try
            {
                //date2 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                //  IList<string> datename = new List<string>(date2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                //  dateTimePicker1.Value = Convert.ToDateTime(datename[1]);
                //   monthCalendar1.SetDate(Convert.ToDateTime(datename[0]));

                if (e.RowIndex == -1 )
                {
                    return;
                }
                else
                {
                    dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    monthCalendar1.SetDate(Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    ClnNameTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                    //  TableLabel.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    //   TableLabel.Visible = false;
                    comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    DinersCount.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    // ResTime = dateTimePicker1.Value.ToString("HH:mm tt");
                    //   ResDate2 = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                    reservationid = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                    //resdatefull = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    //  resdatefull2 = ResDate2 + " " + ResTime; 
                    //  clientname2 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
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
            
            string ResTime1223 = dateTimePicker1.Value.ToString("HH:mm");
            string ResDate1223 = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");

            // DateTime timetime = Convert.ToDateTime(ResDate1223 + " " + ResTime1223);
            // string ResDateTime1223 = ResDate1223 + " " + ResTime1223;

            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                using (SqlCommand command = new SqlCommand(
                    "SELECT CASE WHEN EXISTS(SELECT * from Reservations where " +
                    "tablenum = @tablenum and ResvDate = convert(datetime, @ResvDate, 105) and " +
                    "cast(ResvTime as time) <= @ResvTime and dateadd(hour, 2, cast(ResvTime as time)) >= @ResvTime)" +
                    "THEN 'true' ELSE 'false' end", cnn))
                {

                    command.Parameters.Add("@ResvDate", SqlDbType.Date).Value = ResDate1223;
                    command.Parameters.Add("@ResvTime", SqlDbType.Time).Value = ResTime1223;
                    command.Parameters.AddWithValue("@tablenum", comboBox2.Text);

                    cnn.Open();
                  //  label1.Text = ResTime1223;

                    updateresult = Convert.ToBoolean(command.ExecuteScalar());

                    cnn.Close();
                }
                //OR " + "(ResvTime >= @ResvTime AND ResvTime <=  dateadd(hour, 2, cast(@ResvTime as time))) )
                using (SqlCommand command1 = new SqlCommand(
                   "SELECT CASE WHEN EXISTS(SELECT * from Reservations where " +
                   "tablenum = @tablenum and ResvDate = convert(datetime, @ResvDate, 105) and " +
                   "ResvTime >= @ResvTime AND ResvTime <=  dateadd(hour, 2, cast(@ResvTime as time)) )" +
                   "THEN 'true' ELSE 'false' end", cnn))
                {

                    command1.Parameters.Add("@ResvDate", SqlDbType.Date).Value = ResDate1223;
                    command1.Parameters.Add("@ResvTime", SqlDbType.Time).Value = ResTime1223;
                    command1.Parameters.AddWithValue("@tablenum", comboBox2.Text);

                    cnn.Open();
                   // label1.Text = ResTime1223;

                   updateresult1 = Convert.ToBoolean(command1.ExecuteScalar());

                    cnn.Close();
                }



            }


            try
            {
                if (updateresult == true || updateresult1 == true)
                {
                    MessageBox.Show("Chosen Date is Reserved!");

                }
                else { 
                using (SqlConnection cnn = ConnectionClasss.connnect()) 
                {
                    using(SqlCommand command = new SqlCommand("UPDATE Reservations SET Resvdate = @resvdate, " +
                        "client = @clientname, tablenum = @tablenum, " +
                        "Diners = @diners, ResvTime  = @ResvTime where ReservationID = @resvID",cnn)) 
                    {
                        cnn.Open();
                        command.Parameters.Add("@resvdate",SqlDbType.Date).Value = ResDate1223;
                        command.Parameters.AddWithValue("@clientname", ClnNameTxtBox.Text);
                        command.Parameters.AddWithValue("@tablenum", comboBox2.Text);
                        command.Parameters.AddWithValue("@diners", DinersCount.Text);
                        command.Parameters.AddWithValue("@resvID", reservationid);
                        command.Parameters.AddWithValue("@ResvTime", ResTime1223);
                        command.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                }
                RefreshDGV();
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

                    string reservationid = dataGridView1.SelectedCells[1].Value.ToString();
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
                    RefreshDGV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
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

                SqlCommand cmd2 = new SqlCommand("SELECT Client,ReservationID,ClientID,ResvDate,tablenum,diners FROM Reservations " +
                     "where client LIKE '%" + searchTextBox.Text + "%' or ClientID LIKE '%" + searchTextBox.Text + "%' " +
                     "or  ReservationID LIKE '%" + searchTextBox.Text + "%'", cnn);
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
          
            try
            {
                DateTime datetimer = Convert.ToDateTime(dateTimePicker2.Value.ToString("dd/MM/yyyy"));
                using (SqlConnection cnn = ConnectionClasss.connnect())
                {
                    cnn.Open();

                    SqlCommand cmd2 = new SqlCommand("SELECT client as 'Client Name' ,ReservationID as 'Reservation Number',ResvDate as 'Date'," +
                        "format(cast(ResvTime as datetime), 'hh:mm tt') as 'Time',tablenum as 'Table',diners as 'Diner Count'" +
                        " FROM Reservations where ResvDate = Convert(date,@date)", cnn);
                    cmd2.Parameters.AddWithValue("@date", datetimer);
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    da.SelectCommand = cmd2;
                    dt.Clear();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                    cnn.Close();
                }
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reservationchecker();

            
        }
    }
}
