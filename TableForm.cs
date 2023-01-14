using Google.Protobuf.WellKnownTypes;
using RestaurantReservation.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantReservation
{
    public partial class TableForm : Form
    {
        int currTablenum;
        public delegate void setvalueTableNum(int ss);
        public setvalueTableNum setTableNum;
        List<Button> btnarray = new List<Button>();
        Button currlastitem;
        int Tablecount;
        public TableForm()
        {
            InitializeComponent();
            
           
            
        }

        private void rs_FormClosed(object? sender, FormClosedEventArgs e)
        {
            
        }

         
        
       

        public int getTableNum() 
        {

            return currTablenum;
        
        }
        

        private void TableForm_Load(object sender, EventArgs e)
        {
            btnarray.Add(btn1); btnarray.Add(btn2); btnarray.Add(btn3); btnarray.Add(btn4); btnarray.Add(btn5);
            btnarray.Add(btn6); btnarray.Add(btn7); btnarray.Add(btn8); btnarray.Add(btn9); btnarray.Add(btn10);

            foreach (Button btn in btnarray)
            {
                btn.Visible = false;
                btn.Enabled = false;
            }
            using (SqlConnection cnn = ConnectionClasss.connnect())
            {
                using (SqlCommand command = new SqlCommand("select TableNum from TableNumber where id = 2 ", cnn))
                {


                    cnn.Open();

                    var tablenum = command.ExecuteScalar();
                    if (tablenum == DBNull.Value)
                    {
                        Tablecount = 0;
                    }
                    else if(Convert.ToInt32(tablenum) >= 10)
                    {
                        Tablecount = 10;
                    }
                    else
                    {
                        Tablecount = Convert.ToInt32(tablenum);
                    }
                    cnn.Close();
                }

            }
            for (int i = 0; i < Tablecount; i++)
            {
                btnarray[i].Visible = true;
                btnarray[i].Enabled = true;
            }
            btn1.BackgroundImage = Resources.table;
            btn1.BackgroundImageLayout = ImageLayout.Zoom;
            btn2.BackgroundImage = Resources.table;
            btn2.BackgroundImageLayout = ImageLayout.Zoom;
            btn3.BackgroundImage = Resources.table;
            btn3.BackgroundImageLayout = ImageLayout.Zoom;
            btn4.BackgroundImage = Resources.table;
            btn4.BackgroundImageLayout = ImageLayout.Zoom;
            btn5.BackgroundImage = Resources.table;
            btn5.BackgroundImageLayout = ImageLayout.Zoom;
            btn6.BackgroundImage = Resources.table;
            btn6.BackgroundImageLayout = ImageLayout.Zoom;
            btn7.BackgroundImage = Resources.table;
            btn7.BackgroundImageLayout = ImageLayout.Zoom; 
            btn8.BackgroundImage = Resources.table;
            btn8.BackgroundImageLayout = ImageLayout.Zoom; 
            btn9.BackgroundImage = Resources.table;
            btn9.BackgroundImageLayout = ImageLayout.Zoom;
            btn10.BackgroundImage = Resources.table;
            btn10.BackgroundImageLayout = ImageLayout.Zoom;
            BackgroundImage = Resources.texture_background_1404_991;
            BackgroundImageLayout = ImageLayout.None;
           

           /* btn1.Enabled = true;
            btn2.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
            btn10.Enabled = false;

            btn7.Visible = false;
            btn8.Visible = false;
            btn9.Visible = false;
            btn10.Visible = false;*/
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

       

       

        private void button5_Click(object sender, EventArgs e)
        {
            currTablenum = 5;
            ReservationWindow rs = new ReservationWindow()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.Close();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            // nmf.formselect(new ReservationWindow());
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();

            ReservationWindow.setTableNum(currTablenum);
            ReservationWindow.myfresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currTablenum = 6;
            ReservationWindow rs = new ReservationWindow()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.Close();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            // nmf.formselect(new ReservationWindow());
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();

            ReservationWindow.setTableNum(currTablenum);
            ReservationWindow.myfresh();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            currTablenum = 1;
            ReservationWindow rs = new ReservationWindow()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.Close();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            // nmf.formselect(new ReservationWindow());
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();

            ReservationWindow.setTableNum(currTablenum);
            ReservationWindow.myfresh();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            currTablenum = 2;
            ReservationWindow rs = new ReservationWindow()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.Close();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            // nmf.formselect(new ReservationWindow());
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();

            ReservationWindow.setTableNum(currTablenum);
            ReservationWindow.myfresh();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            currTablenum = 3;
            ReservationWindow rs = new ReservationWindow()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.Close();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            // nmf.formselect(new ReservationWindow());
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();

            ReservationWindow.setTableNum(currTablenum);
            ReservationWindow.myfresh();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            currTablenum = 4;
            ReservationWindow rs = new ReservationWindow()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.Close();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            // nmf.formselect(new ReservationWindow());
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();

            ReservationWindow.setTableNum(currTablenum);
            ReservationWindow.myfresh();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            currTablenum = 5;
            ReservationWindow rs = new ReservationWindow()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.Close();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            // nmf.formselect(new ReservationWindow());
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();

            ReservationWindow.setTableNum(currTablenum);
            ReservationWindow.myfresh();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            currTablenum = 6;
            ReservationWindow rs = new ReservationWindow()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.Close();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            // nmf.formselect(new ReservationWindow());
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();

            ReservationWindow.setTableNum(currTablenum);
            ReservationWindow.myfresh();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            currTablenum = 7;
            ReservationWindow rs = new ReservationWindow()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.Close();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            // nmf.formselect(new ReservationWindow());
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();

            ReservationWindow.setTableNum(currTablenum);
            ReservationWindow.myfresh();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            currTablenum = 8;
            ReservationWindow rs = new ReservationWindow()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.Close();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            // nmf.formselect(new ReservationWindow());
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();

            ReservationWindow.setTableNum(currTablenum);
            ReservationWindow.myfresh();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            currTablenum = 9;
            ReservationWindow rs = new ReservationWindow()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.Close();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            // nmf.formselect(new ReservationWindow());
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();

            ReservationWindow.setTableNum(currTablenum);
            ReservationWindow.myfresh();
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            currTablenum = 10;
            ReservationWindow rs = new ReservationWindow()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.Close();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            // nmf.formselect(new ReservationWindow());
            newMainForm ww = (newMainForm)Application.OpenForms["newMainForm"];
            Panel panel1 = (Panel)ww.Controls["panel2"];
            panel1.Controls.Add(rs);
            rs.Show();

            ReservationWindow.setTableNum(currTablenum);
            ReservationWindow.myfresh();
        }

        private void add_Click(object sender, EventArgs e)
        {
            Tablecount++;
            foreach (Button button in btnarray)
            {
                if (button.Enabled == true)
                {

                }
                else
                {
                    try
                    {
                        using (SqlConnection cnn = ConnectionClasss.connnect())
                        {
                            using (SqlCommand command = new SqlCommand("update TableNumber set TableNum = @tablenumm where id =2 ", cnn))
                            {
                                command.Parameters.AddWithValue("@tablenumm", Tablecount);

                                cnn.Open();

                                command.ExecuteNonQuery();
                                cnn.Close();
                            }



                        }
                        button.Enabled = true;
                        button.Visible = true;

                        break;

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (Tablecount == 1)
            {
                MessageBox.Show("Table can't be deleted!");
                Tablecount = 1;
               
            }
            else
            {
                foreach (Button button in btnarray)
                {

                    if (button.Enabled == true)
                    {

                    }
                    else if (button.Enabled == false)
                    {
                        try
                        {

                            using (SqlConnection cnn = ConnectionClasss.connnect())
                            {
                                using (SqlCommand command = new SqlCommand("update TableNumber set TableNum = @tablenumm where id =2 ", cnn))
                                {
                                    Tablecount--;
                                    command.Parameters.AddWithValue("@tablenumm", Tablecount);

                                    cnn.Open();

                                    command.ExecuteNonQuery();
                                    cnn.Close();
                                }
                            }
                            currlastitem.Enabled = false;
                            currlastitem.Visible = false;
                            break;

                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    currlastitem = button;
                    if (button == btn10)
                    {
                        try
                        {
                            using (SqlConnection cnn = ConnectionClasss.connnect())
                            {
                                using (SqlCommand command = new SqlCommand("update TableNumber set TableNum = @tablenumm where id =2 ", cnn))
                                {
                                    command.Parameters.AddWithValue("@tablenumm", Tablecount);

                                    cnn.Open();

                                    command.ExecuteNonQuery();
                                    cnn.Close();
                                }
                            }
                            currlastitem = btnarray[9];
                            currlastitem.Enabled = false;
                            currlastitem.Visible = false;

                            break;
                        }
                        catch (SqlException ex) { MessageBox.Show(ex.Message); }

                    }

                }
            }
        }

        private void goback_Click(object sender, EventArgs e)
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
    }
}
