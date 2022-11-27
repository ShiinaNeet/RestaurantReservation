﻿using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Ocsp;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;


namespace RestaurantReservation
{
    public partial class ReservationWindow : Form
    {
        string ResDate;
        string ClientName;
        string ResTime;
        string resdatefull;
        int tablenumber;
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
            TableForm tf = new TableForm();
            TableLabel.Text = tf.getTableNum().ToString();
            tablenumber = tf.getTableNum();
           
            

        }
        public void setTableNum(int ix)
        {
           TableLabel.Text = ix.ToString();
            tablenumber = ix;

        }

        private void ReservationWindow_Load(object sender, EventArgs e)
        {
            timer1.Interval = (50000); // 1 secs
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
           dateTimePicker1.CustomFormat = "hh-mm tt";
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (ClnNameTxtBox.Text.ToString() == "") {
                MessageBox.Show("Please Enter client name", "Client Name Not Found", MessageBoxButtons.OK); ClnNameTxtBox.Select();
            }
            else {
                try
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
               // MessageBox.Show(ex.Message);
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
                    //ResvDate,client,tablenum,diners,clientid
                    using (SqlCommand command1 = new SqlCommand("UPDATE Reservations set Resvdate =' " + resdatefull2 + "',client ='" + ClnNameTxtBox.Text + "', tablenum = '" + TableLabel.Text + " ', Diners ='" + DinersCount.Text + "'where client = '"+ClnNameTxtBox.Text+"'", cnn))
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
            int CurIndexRow = dataGridView1.CurrentCell.RowIndex;
            int currentrow = dataGridView1.SelectedCells[0].RowIndex;
            string reservationid = dataGridView1.SelectedCells[0].Value.ToString();

            try
            {
               
                using (SqlConnection cnn = ConnectionClasss.connnect())
                {
                    //ResvDate,client,tablenum,diners
                    using (SqlCommand command1 = new SqlCommand("DELETE Reservations where ReservationID = @ReservationID",  cnn))
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
}
