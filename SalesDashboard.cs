using RestaurantReservation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantReservation
{
    public partial class SalesDashboard : Form
    {
        int today = 0;
        int PreviousDay=0;
        int PrevMonth = 0;
        int currMonthOrder=0;
        int yearly = 0;
        int prevyearly=0;
        int todayrevenue = 0;
        int prevrevenue = 0;
        int yearorder = 0;
        int prevyearoder=0;
        public SalesDashboard()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //daily order count
                using (SqlConnection cnn = ConnectionClasss.connnect())
                {
                    using (SqlCommand command = new SqlCommand("select count(DateOrder) from Orders where DateOrder = CONVERT(date, GETDATE())", cnn))
                    {
                        cnn.Open();

                        today = Convert.ToInt32(command.ExecuteScalar());
                        label3.Text = today.ToString();
                        cnn.Close();
                    }
                    using (SqlCommand command = new SqlCommand("select count(DateOrder) from Orders where DateOrder = DATEADD(day, -1,CONVERT(date, GETDATE()))", cnn))
                    {
                        cnn.Open();

                        PreviousDay = Convert.ToInt32(command.ExecuteScalar());

                        cnn.Close();
                    }

                    using (SqlCommand command = new SqlCommand("select count(DateOrder) from Orders where DateOrder = DATEADD(MONTH, -1,CONVERT(date, GETDATE()))", cnn))
                    {
                        cnn.Open();

                        PrevMonth = Convert.ToInt32(command.ExecuteScalar());
                        //   label5.Text = PrevMonth.ToString();
                        cnn.Close();
                    }
                    // this month sale orders

                    using (SqlCommand command = new SqlCommand("select count(*) from Orders where DateOrder between FORMAT(GETDATE(),'yyyy-MM-01') " +
                        "and FORMAT(GETDATE(),'yyyy-MM-31')", cnn))
                    {
                        cnn.Open();

                        currMonthOrder = Convert.ToInt32(command.ExecuteScalar());
                        label5.Text = currMonthOrder.ToString();
                        cnn.Close();
                    }
                    //this year's revenue
                    using (SqlCommand command = new SqlCommand("SELECT SUM(Price) from Orders where DateOrder between FORMAT(GETDATE(),'yyyy-01-01') " +
                        "and FORMAT(GETDATE(),'yyyy-12-31')", cnn))
                    {
                        cnn.Open();

                        yearly = Convert.ToInt32(command.ExecuteScalar());
                        label12.Text = yearly.ToString();
                        label12.Text = String.Format(CultureInfo.CreateSpecificCulture("en-PH"), "{0:C}", double.Parse(label12.Text));
                        cnn.Close();
                    }
                    //previous year's revenue
                    using (SqlCommand command = new SqlCommand("SELECT SUM(Price) from Orders where DateOrder between DATEADD(YEAR, -1,CONVERT(date, GETDATE())) " +
                        "and FORMAT(DATEADD(YEAR, -1,CONVERT(date, GETDATE())),'yyyy-12-31') ", cnn))
                    {
                        cnn.Open();

                        prevyearly = Convert.ToInt32(command.ExecuteScalar());
                        //label12.Text = yearly.ToString();
                        cnn.Close();
                    }
                    // today revenue
                    using (SqlCommand command = new SqlCommand("SELECT SUM(Price) from Orders where DateOrder = FORMAT(GETDATE(),'yyyy-MM-dd') ", cnn))
                    {
                        cnn.Open();

                        todayrevenue = Convert.ToInt32(command.ExecuteScalar());
                        label9.Text = todayrevenue.ToString();
                        label9.Text = String.Format(CultureInfo.CreateSpecificCulture("en-PH"), "{0:C}", double.Parse(label9.Text));
                        cnn.Close();
                    }
                    //last day revenue
                    using (SqlCommand command = new SqlCommand("SELECT SUM(Price) from Orders where DateOrder = DATEADD(day, -1,CONVERT(date, GETDATE())) ", cnn))
                    {
                        cnn.Open();

                        prevrevenue = Convert.ToInt32(command.ExecuteScalar());
                        //  label9.Text = prevrevenue.ToString();
                        //  label9.Text = String.Format(CultureInfo.CreateSpecificCulture("en-PH"), "{0:C}", double.Parse(label9.Text));


                        cnn.Close();
                    }
                    // this year's total order
                    using (SqlCommand command = new SqlCommand("select count(*) from Orders where DateOrder between FORMAT(GETDATE(),'yyyy-01-01') " +
                        " and FORMAT(GETDATE(),'yyyy-12-31')", cnn))
                    {
                        cnn.Open();

                        yearorder = Convert.ToInt32(command.ExecuteScalar());
                        label15.Text = currMonthOrder.ToString();
                        cnn.Close();
                    }
                    //previous year's total order
                    using (SqlCommand command = new SqlCommand("select count(*) from Orders where DateOrder between Dateadd(YEAR,-1,FORMAT(GETDATE(),'yyyy-01-01')) " +
                        " and dateadd(year,-1,FORMAT(GETDATE(),'yyyy-12-31'))", cnn))
                    {
                        cnn.Open();

                        prevyearoder = Convert.ToInt32(command.ExecuteScalar());
                        //   label15.Text = currMonthOrder.ToString();
                        cnn.Close();
                    }
                }
            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }
        }

            private void SalesDashboard_Load(object sender, EventArgs e)
        {
            BackgroundImage = Resources.texture_background_1404_991;
            BackgroundImageLayout = ImageLayout.None;
            timer1.Interval = (200); // 1 secs
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            int x = 20;
            try
            {
                //daily order count
                using (SqlConnection cnn = ConnectionClasss.connnect())
                {
                    using (SqlCommand command = new SqlCommand("select count(DateOrder) from Orders where DateOrder = CONVERT(date, GETDATE())", cnn))
                    {
                        cnn.Open();

                        today = Convert.ToInt32(command.ExecuteScalar());
                        label3.Text = today.ToString();
                        cnn.Close();
                    }
                    using (SqlCommand command = new SqlCommand("select count(DateOrder) from Orders where DateOrder = DATEADD(day, -1,CONVERT(date, GETDATE()))", cnn))
                    {
                        cnn.Open();

                        PreviousDay = Convert.ToInt32(command.ExecuteScalar());

                        cnn.Close();
                    }

                    using (SqlCommand command = new SqlCommand("select count(DateOrder) from Orders where DateOrder = DATEADD(MONTH, -1,CONVERT(date, GETDATE()))", cnn))
                    {
                        cnn.Open();

                        PrevMonth = Convert.ToInt32(command.ExecuteScalar());
                        //   label5.Text = PrevMonth.ToString();
                        cnn.Close();
                    }
                    // this month sale orders

                    using (SqlCommand command = new SqlCommand("select count(*) from Orders where DateOrder between FORMAT(GETDATE(),'yyyy-MM-01') " +
                        "and FORMAT(GETDATE(),'yyyy-MM-31')", cnn))
                    {
                        cnn.Open();

                        currMonthOrder = Convert.ToInt32(command.ExecuteScalar());
                        label5.Text = currMonthOrder.ToString();
                        cnn.Close();
                    }
                    //this year's revenue
                    using (SqlCommand command = new SqlCommand("SELECT SUM(Price) from Orders where DateOrder between FORMAT(GETDATE(),'yyyy-01-01') " +
                        "and FORMAT(GETDATE(),'yyyy-12-31')", cnn))
                    {
                        cnn.Open();

                        yearly = Convert.ToInt32(command.ExecuteScalar());
                        label12.Text = yearly.ToString();
                        label12.Text = String.Format(CultureInfo.CreateSpecificCulture("en-PH"), "{0:C}", double.Parse(label12.Text));
                        cnn.Close();
                    }
                    //previous year's revenue
                    using (SqlCommand command = new SqlCommand("SELECT SUM(Price) from Orders where DateOrder between DATEADD(YEAR, -1,CONVERT(date, GETDATE())) " +
                        "and FORMAT(DATEADD(YEAR, -1,CONVERT(date, GETDATE())),'yyyy-12-31') ", cnn))
                    {
                        cnn.Open();

                        prevyearly = Convert.ToInt32(command.ExecuteScalar());
                        //label12.Text = yearly.ToString();
                        cnn.Close();
                    }
                    // today revenue
                    using (SqlCommand command = new SqlCommand("SELECT SUM(Price) from Orders where DateOrder = FORMAT(GETDATE(),'yyyy-MM-dd') ", cnn))
                    {
                        cnn.Open();

                        todayrevenue = Convert.ToInt32(command.ExecuteScalar());
                        label9.Text = todayrevenue.ToString();
                        label9.Text = String.Format(CultureInfo.CreateSpecificCulture("en-PH"), "{0:C}", double.Parse(label9.Text));
                        cnn.Close();
                    }
                    //last day revenue
                    using (SqlCommand command = new SqlCommand("SELECT SUM(Price) from Orders where DateOrder = DATEADD(day, -1,CONVERT(date, GETDATE())) ", cnn))
                    {
                        cnn.Open();

                        prevrevenue = Convert.ToInt32(command.ExecuteScalar());
                        //  label9.Text = prevrevenue.ToString();
                        //  label9.Text = String.Format(CultureInfo.CreateSpecificCulture("en-PH"), "{0:C}", double.Parse(label9.Text));


                        cnn.Close();
                    }
                    // this year's total order
                    using (SqlCommand command = new SqlCommand("select count(*) from Orders where DateOrder between FORMAT(GETDATE(),'yyyy-01-01') " +
                        " and FORMAT(GETDATE(),'yyyy-12-31')", cnn))
                    {
                        cnn.Open();

                        yearorder = Convert.ToInt32(command.ExecuteScalar());
                        label15.Text = currMonthOrder.ToString();
                        cnn.Close();
                    }
                    //previous year's total order
                    using (SqlCommand command = new SqlCommand("select count(*) from Orders where DateOrder between Dateadd(YEAR,-1,FORMAT(GETDATE(),'yyyy-01-01')) " +
                        " and dateadd(year,-1,FORMAT(GETDATE(),'yyyy-12-31'))", cnn))
                    {
                        cnn.Open();

                        prevyearoder = Convert.ToInt32(command.ExecuteScalar());
                        //   label15.Text = currMonthOrder.ToString();
                        cnn.Close();
                    }
                }
            }
            catch (Exception exw) {
                MessageBox.Show(exw.Message);
            }

            if (PreviousDay < today)
            {
                pictureBox1.Image = Resources.increase;
                pictureBox1.Update();
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (PreviousDay > today)
            {
                pictureBox1.Image = Resources.decrease;
                pictureBox1.Update();
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox1.Image = Resources._3097256;
                pictureBox1.Update();
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }


            // label2 monthly orders

            int y = 3;
            if (currMonthOrder > PrevMonth)
            {
                pictureBox2.Image = Resources.increase;

            }
            else if (currMonthOrder < PrevMonth)
            {
                pictureBox2.Image = Resources.decrease;

            }
            else
            {
                pictureBox2.Image = Resources._3097256;

            }
            pictureBox2.Update();
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            // todays income
            int z = 23;
            if (prevrevenue < todayrevenue)
            {
                pictureBox3.Image = Resources.increase;

            }
            else if (prevrevenue > todayrevenue)
            {
                pictureBox3.Image = Resources.decrease;

            }
            else
            {
                pictureBox3.Image = Resources._3097256;

            }
            pictureBox3.Update();
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            //yearly sales
            int c = 14;
            if (yearly> prevyearly)
            {
                pictureBox4.Image = Resources.increase;

            }
            else if (yearly < prevyearly)
            {
                pictureBox4.Image = Resources.decrease;

            }
            else
            {
                pictureBox4.Image = Resources._3097256;

            }
            pictureBox4.Update();
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            //yearly sales

            // Total year order vs previous year order
            if (yearorder > prevyearoder)
            {
                pictureBox5.Image = Resources.increase;

            }
            else if (yearorder < prevyearoder)
            {
                pictureBox5.Image = Resources.decrease;

            }
            else
            {
                pictureBox5.Image = Resources._3097256;

            }
            pictureBox5.Update();
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
