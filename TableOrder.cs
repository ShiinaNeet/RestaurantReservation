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
    public partial class TableOrder : Form
    {
        int currTablenum;
        public delegate void setvalueTableNum(int ss);
        public setvalueTableNum setTableNum;
        CreateOrderForm orderForm = new CreateOrderForm();

        public TableOrder()
        {
            InitializeComponent();
            
           
            
        }

        private void rs_FormClosed(object? sender, FormClosedEventArgs e)
        {
            
        }

         
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            currTablenum = 1;
            
            
            this.setTableNum += new setvalueTableNum(orderForm.setTableNum);
           // this.setTableNum(currTablenum);
            orderForm.setTableNum(currTablenum);
            orderForm.ShowDialog();

        }

        public int getTableNum() 
        {

            return currTablenum;
        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            currTablenum = 2;
            

            this.setTableNum += new setvalueTableNum(orderForm.setTableNum);
            // this.setTableNum(currTablenum);
            orderForm.setTableNum(currTablenum);
            orderForm.ShowDialog();

        }

        private void TableOrder_Load(object sender, EventArgs e)
        {
            
            Table1Btn.BackgroundImage = Resources.table;
            Table1Btn.BackgroundImageLayout =ImageLayout.Zoom;
            button2.BackgroundImage = Resources.table;
            button2.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
