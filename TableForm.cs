using Google.Protobuf.WellKnownTypes;
using RestaurantReservation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        

        public TableForm()
        {
            InitializeComponent();
            
           
            
        }

        private void rs_FormClosed(object? sender, FormClosedEventArgs e)
        {
            
        }

         
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            currTablenum = 1;
            ReservationWindow rs = new ReservationWindow();
            
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            ReservationWindow.setTableNum(currTablenum);
            ReservationWindow.myfresh();
            MainForm1.loadform(new ReservationWindow());
            MainForm1.MyrefeshMethod();

        }

        public int getTableNum() 
        {

            return currTablenum;
        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            currTablenum = 2;
            ReservationWindow rs = new ReservationWindow();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            ReservationWindow.setTableNum(currTablenum);
            //rs.ShowDialog();
            MainForm1.loadform(new ReservationWindow());
            MainForm1.MyrefeshMethod();



        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            Table1Btn.BackgroundImage = Resources.table;
            Table1Btn.BackgroundImageLayout = ImageLayout.Zoom;
            button2.BackgroundImage = Resources.table;
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button3.BackgroundImage = Resources.table;
            button3.BackgroundImageLayout = ImageLayout.Zoom;
            button4.BackgroundImage = Resources.table;
            button4.BackgroundImageLayout = ImageLayout.Zoom;
            button5.BackgroundImage = Resources.table;
            button5.BackgroundImageLayout = ImageLayout.Zoom;
            button6.BackgroundImage = Resources.table;
            button6.BackgroundImageLayout = ImageLayout.Zoom;

            BackgroundImage = Resources.texture_background_1404_991;
            BackgroundImageLayout = ImageLayout.None;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MainForm1.loadform(new MainMenuWindow());
            MainForm1.MyrefeshMethod();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currTablenum = 3;
            ReservationWindow rs = new ReservationWindow();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            ReservationWindow.setTableNum(currTablenum);
            //rs.ShowDialog();
            MainForm1.loadform(new ReservationWindow());
            MainForm1.MyrefeshMethod();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currTablenum = 4;
            ReservationWindow rs = new ReservationWindow();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            ReservationWindow.setTableNum(currTablenum);
            //rs.ShowDialog();
            MainForm1.loadform(new ReservationWindow());
            MainForm1.MyrefeshMethod();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currTablenum = 5;
            ReservationWindow rs = new ReservationWindow();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            ReservationWindow.setTableNum(currTablenum);
            //rs.ShowDialog();
            MainForm1.loadform(new ReservationWindow());
            MainForm1.MyrefeshMethod();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currTablenum = 6;
            ReservationWindow rs = new ReservationWindow();
            this.setTableNum += new setvalueTableNum(ReservationWindow.setTableNum);
            this.setTableNum(currTablenum);
            ReservationWindow.setTableNum(currTablenum);
            //rs.ShowDialog();
            MainForm1.loadform(new ReservationWindow());
            MainForm1.MyrefeshMethod();
        }
    }
}
