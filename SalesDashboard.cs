using MySqlX.XDevAPI.Common;
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
        List<Panel> Orderspanellist = new List<Panel>();
        List<Panel> Revenuepanellist = new List<Panel>();
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
        int currentmonthlysales = 0;
        int lastmonthlysales =0;
        public SalesDashboard()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
        public void PanelVisibilityReset() {
            foreach (Panel panel in Orderspanellist) 
            {
                panel.Visible = true;
            }
        }
        public void RevenuePanelVisibility() 
        {
            foreach (Panel panel in Orderspanellist)
            {
                panel.Visible = true;
                panel.Enabled = true;
            }
        }
        private void SalesDashboard_Load(object sender, EventArgs e)
        {
            

            Orderspanellist.Add(Orderspanel1);
            Orderspanellist.Add(Orderspanel2); Orderspanellist.Add(Orderspanel3);
            Revenuepanellist.Add(revpanel2); Revenuepanellist.Add(Revpanel1); Revenuepanellist.Add(revpanel3);
            BackgroundImage = Resources.texture_background_1404_991;
            BackgroundImageLayout = ImageLayout.None;
            timer1.Interval = (100); // 1 secs
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            int x = 20;
            
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
                    using (SqlCommand command21 = new SqlCommand("SELECT SUM(Price) from Orders where DateOrder = FORMAT(GETDATE(),'yyyy-MM-dd') ", cnn))
                    {
                        cnn.Open();

                        var ttodayrevenue = command21.ExecuteScalar();
                        if (ttodayrevenue == DBNull.Value)
                         {
                            todayrevenue= 0;
                        }
                        else
                        {
                           todayrevenue = Convert.ToInt32(ttodayrevenue);
                        }
                        label9.Text = todayrevenue.ToString();
                        label9.Text = String.Format(CultureInfo.CreateSpecificCulture("en-PH"), "{0:C}", double.Parse(label9.Text));
                        cnn.Close();
                    }
                    //last day revenue
                    using (SqlCommand command = new SqlCommand("SELECT SUM(Price) from Orders where DateOrder = DATEADD(day, -1,CONVERT(date, GETDATE())) ", cnn))
                    {
                        cnn.Open();

                        var prevrerevue =  command.ExecuteScalar();
                    if (prevrerevue == DBNull.Value)
                    {
                        prevrevenue = 0;
                    }
                    else
                    {
                        prevrevenue = Convert.ToInt32(prevrerevue);
                    }
                        
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
                        
                        label15.Text = yearorder.ToString();
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
                    //monthly sales
                    //thismonth
                    using (SqlCommand command = new SqlCommand("select sum(Price) from Orders where DateOrder between FORMAT(GETDATE(),'yyyy-MM-01') and FORMAT(GETDATE(),'yyyy-MM-31')", cnn))
                    {
                        cnn.Open();
                        
                        currentmonthlysales = Convert.ToInt32(command.ExecuteScalar());
                        MonthlySalesLabel.Text = currentmonthlysales.ToString();
                        MonthlySalesLabel.Text = String.Format(CultureInfo.CreateSpecificCulture("en-PH"), "{0:C}", double.Parse(MonthlySalesLabel.Text));
                    cnn.Close();
                    }
                    //last month
                    using (SqlCommand command = new SqlCommand("select sum(Price) from Orders where DateOrder = DATEADD(MONTH, -1,CONVERT(date, GETDATE()))", cnn))
                    {
                        cnn.Open();
                        var www = command.ExecuteScalar();
                        if (www== DBNull.Value)
                        {
                         lastmonthlysales = 0;
                        }
                        else
                        {
                            lastmonthlysales = Convert.ToInt32(www);
                        }

                        
                                            
                        cnn.Close();
                    }

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
            //monthlly sales

            if (currentmonthlysales > lastmonthlysales)
            {
                pictureBox8.Image = Resources.increase;

            }
            else if (currentmonthlysales < lastmonthlysales)
            {
                pictureBox8.Image = Resources.decrease;

            }
            else
            {
                pictureBox8.Image = Resources._3097256;

            }
            pictureBox8.Update();
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

          
            label1.Text = comboBox1.SelectedText.ToString();
            label1.Update();
            if (comboBox1.SelectedIndex == 0)
            {
                PanelVisibilityReset();
               
                Orderspanel2.Visible = false;
                Orderspanel3.Visible = false;
                revpanel2.Visible = false;
                revpanel3.Visible = false;


            }
            else if (comboBox1.SelectedIndex == 1)
            {
                PanelVisibilityReset();
                
                Orderspanel1.Visible = false;
                Orderspanel3.Visible = false;

                Orderspanel2.Location = new Point(3, 44);
                 
                //revpanel2.Visible = true;
               // Revpanel1.Visible = true;
               // revpanel3.Visible = true;

                if (comboBox4.SelectedIndex == 0) 
                {
                    revpanel2.Visible = false;
                    Revpanel1.Visible = true;
                    revpanel3.Visible = false;

                }
                else if(comboBox4.SelectedIndex==1)
                {
                    revpanel2.Visible = true;
                    Revpanel1.Visible = false;
                    revpanel3.Visible = false;
                  //  Orderspanel2.Visible = true;
                }
                else if (comboBox4.SelectedIndex == 2) 
                {
                    revpanel2.Visible = false;
                    Revpanel1.Visible = false;
                    revpanel3.Visible = true;
                }


            }
            else if (comboBox1.SelectedIndex == 2) 
            {
                PanelVisibilityReset();
                
                Orderspanel2.Visible = false;
               
                Orderspanel1.Visible = false;
                Orderspanel3.Visible = true;
                Orderspanel3.Location = new Point(3, 44);
                if (comboBox4.SelectedIndex == 0)
                {
                    Revpanel1.Visible = false;
                    revpanel2.Visible = false;
                }
                else if (comboBox4.SelectedIndex == 1)
                {
                    Revpanel1.Visible = false;
                    revpanel2.Visible = false;
                    revpanel3.Visible = true;
                }
                else if (comboBox4.SelectedIndex == 2)
                {
                    revpanel2.Visible = false;
                    Revpanel1.Visible = false;
                    revpanel3.Visible = true;
                }


            }
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox4.SelectedText.ToString();
            label1.Update();
            RevenuePanelVisibility();
            if (comboBox4.SelectedIndex == 0)
            {
                
                OrdersPanel.Visible = true;
                OrdersPanel.Enabled = true;
                s.Enabled = false;
                s.Visible =false;
               

            }
            else if (comboBox4.SelectedIndex == 1)
            {
                
                s.Visible = true;
                s.Enabled = true;
                OrdersPanel.Enabled = false;
                OrdersPanel.Visible = false;
                revpanel2.Visible = true;
                Revpanel1.Visible = true;
                revpanel3.Visible = true;
                s.Location = new Point(12, 73);   
            }
            else if (comboBox4.SelectedIndex == 2)
            {
               
                
                s.Enabled = false;
                s.Visible = false;
                OrdersPanel.Enabled = false;
                OrdersPanel.Visible = false;
                
            }
        }

        public void resetallfilters()
        {
            label1.Text = "Sales Dashboard";
            comboBox1.Text = "Days";
            comboBox4.Text = "Order,Revenue....";
            OrdersPanel.Visible = true;
            s.Visible = true;
            
            OrdersPanel.Location = new Point(12, 73);
            s.Location = new Point(12, 398);
         
            OrdersPanel.Enabled = true;
            s.Enabled = true;
           
            Orderspanel1.Enabled = true;
            Orderspanel2.Enabled = true;
            Orderspanel3.Enabled = true;
            PanelVisibilityReset();
            Orderspanel1.Location = new Point(3, 44);
            Orderspanel2.Location = new Point(368, 44);
            Orderspanel3.Location = new Point(738, 44);
            RevenuePanelVisibility();
            revpanel2.Location = new Point(369, 48);
            revpanel3.Location = new Point(738, 48);
            Revpanel1.Location = new Point(4, 48);
            revpanel2.Visible = true;
            Revpanel1.Visible = true;
            revpanel3.Visible = true;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            resetallfilters();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Orderspanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
