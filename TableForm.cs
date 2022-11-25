using Google.Protobuf.WellKnownTypes;
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
            this.Visible = true;
        }

         
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            currTablenum = 1;
            ReservationWindow rs = new ReservationWindow();
            rs.Show();
            this.setTableNum += new setvalueTableNum(rs.setTableNum);
            this.setTableNum(currTablenum);
            rs.setTableNum(currTablenum);
            this.Dispose();
            
           
        }

        public int getTableNum() 
        {

            return currTablenum;
        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            currTablenum = 2;
            ReservationWindow rs = new ReservationWindow();
            this.setTableNum += new setvalueTableNum(rs.setTableNum);
            this.setTableNum(currTablenum);
            rs.setTableNum(currTablenum);
            this.Dispose();



        }
    }
}
